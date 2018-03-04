#[macro_use]
extern crate lazy_static;

extern crate serialport;
extern crate deamon;
extern crate nvapi_sys;

use std::io::Read;
use std::io::Write;
use std::io::BufRead;
use std::io::BufReader;

use nvapi_sys::handles::NvPhysicalGpuHandle;

use deamon::*;
use deamon::cpu;

use std::collections::HashMap;

thread_local!{
    static GPUS: Vec<NvPhysicalGpuHandle> =  get_gpus();
}

macro_rules! map {
    ($ ( $x:expr ),* ) => {
        {
            let mut map = HashMap::<String, fn() -> i32>::new();
            $(
                map.insert(stringify!($x).to_owned(), $x);
            )*
            map
        }
    };
}

lazy_static!{
    static ref TJ_MAX: i32 = cpu::get_cpu_tj_max();

    static ref FUNCTION_MAP: HashMap<String, fn() -> i32> = map![
        get_cpu_temp,
        get_first_gpu_temp,

        get_cpu_usage,
        get_first_gpu_usage,
        get_ram_usage,
        get_disk_usage
    ];

}








fn get_cpu_temp() -> i32 {
    cpu::get_cpu_temp(*TJ_MAX)
}

fn get_first_gpu_temp() -> i32 {
    GPUS.with(|gpus|
        get_gpu_temp(&gpus[0])
    )
}

fn get_first_gpu_usage() -> i32 {
    GPUS.with(|gpus|
        get_gpu_usage(&gpus[0])
    )
}


struct Config {
    baud_rate: u32,
    com_name: String,

    properties: Vec<String>,
}

fn load_config(path: &str) -> Config {
    let file = std::fs::File::open(path).expect("Config not found!");
    let reader = BufReader::new(&file);


    let mut baud_rate = 0;
    let mut com_name = "".to_owned();
    let mut properties: Vec<String> = vec![];


    for (i, line) in reader.lines().enumerate() {
        let line = line.unwrap();
        let mut parts = line.split("//");
        let line = parts.next().unwrap();
        let parts: Vec<&str> = line.split(" ").collect();

        let key = parts[0];
        let ref values = parts[1..];

        assert!(!values.is_empty(), "No value specified after {} at: {}:{} ", key, i, key.len());

        match key {
            "baud_rate" => {
                assert_eq!(values.len(), 1,
                           "Too many values specified after {} at: {}:{}\n\t'{}'",
                           key, i, key.len(), line
                );
                baud_rate = values[0].parse::<u32>().expect("Invalid baud_rate");
            },

            "com_name" => {
                assert_eq!(values.len(), 1,
                           "Too many values specified after {} at: {}:{}\n\t'{}'",
                           key, i, key.len(), line
                );
                com_name = values[0].to_owned();
            }

            "properties" => {
                let mut c = key.len();
                let x = values.iter().map(|v: &&str| {
                    let name = (*(v)).to_owned();
                    assert!(FUNCTION_MAP.contains_key(&name),
                            "Invalid property name for {} at: {}:{}\n\t'{}'",
                            key, i, c, line
                    );
                    c += name.len();
                    name
                });
                properties = x.collect();
            }

            "" => { }

            _ => {
                panic!("Invalid syntax at {}:{}:\n\t'{}'", i, 0, key);
            }
        };
    }

    assert_ne!(baud_rate, 0, "No baud rate specified!");
    assert_ne!(com_name, "", "No com port specified!");
    assert!(!properties.is_empty(), "No selected properties");

    Config {
        baud_rate,
        com_name,

        properties,
    }
}


fn open_comport(config: &Config) -> Box<serialport::SerialPort> {
    use serialport::prelude::*;
    use std::time::Duration;



    let settings = SerialPortSettings {
        baud_rate: BaudRate::BaudOther(config.baud_rate),
        data_bits: DataBits::Eight,
        flow_control: FlowControl::None,
        parity: Parity::None,
        stop_bits: StopBits::One,
        timeout: Duration::from_millis(100)
    };

    serialport::open_with_settings(
        "COM1",
        &settings
    ).expect(&format!("Failed to open serial connection on port {}", config.com_name))
}

fn main() {
    let config = load_config("");

    cpu::cpu_init();
    let mut com_port = open_comport(&config);

    let functions: Vec<_> = config.properties.iter()
        .map(|property| FUNCTION_MAP[property]).collect();
    let mut index = 0;

    loop {
        debug_print_all();

        let mut step = [0u8; 1];
        com_port.read_exact(step.as_mut()).expect("Failed to read from arduino");
        let step = step[0] as i8;

        index += step as usize;
        index %= functions.len();

        let value = functions[index]();
        let data = format!("{}", value);

        com_port.write(data.as_bytes()).expect("Failed to write to arduino!");
    }

    //unsafe{ cpu::cpu_drop(h) };
}

fn debug_print_all() {
    print!("{}", "\n".repeat(5));

    GPUS.with(|gpus| {
        for (i, gpu) in gpus.iter().enumerate() {
            println!("GPU {} temperature: {} degrees", i, get_gpu_temp(&gpu));
            println!("GPU {} usage: {} %", i, get_gpu_usage(&gpu));
        }
    });

    println!("CPU usage: {}%", get_cpu_usage());
    println!("CPU temp: {} C", get_cpu_temp());
    println!("RAM usage: {} MB", get_ram_usage());
    println!("Disk usage: {} MB", get_disk_usage());
}