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

use std::thread::spawn;
use std::sync::atomic::AtomicBool;
use std::sync::atomic::Ordering;

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

thread_local!{
    static GPUS: Vec<NvPhysicalGpuHandle> =  get_gpus();
}

lazy_static!{
    static ref TIME_TO_RELOAD: AtomicBool = AtomicBool::new(true);

    static ref TJ_MAX: i32 = cpu::get_cpu_tj_max();

    static ref FUNCTION_MAP: HashMap<String, fn() -> i32> = map![
        cpu_temp,
        cpu_usage,

        first_gpu_temp,
        first_gpu_usage,

        ram_usage,
        ram_usage_mb,
        disk_usage,
        disk_usage_mb,
        time_clock,
        time_date
    ];

}


fn cpu_temp() -> i32 {
    cpu::get_cpu_temp(*TJ_MAX)
}

fn first_gpu_temp() -> i32 {
    GPUS.with(|gpus|
        if !gpus.is_empty() {
            gpu_temp(&gpus[0])
        } else {
            0
        }
    )
}

fn first_gpu_usage() -> i32 {
    GPUS.with(|gpus|
        if !gpus.is_empty() {
            gpu_usage(&gpus[0])
        } else {
            0
        }
    )
}

struct Config {
    com_baud: u32,
    com_name: String,

    properties: Vec<String>,
}

fn load_config() -> Config {
    let path = std::env::home_dir().unwrap();

    let file = std::fs::File::open(path.join("NixieTubeController").join("settings.conf")).expect("Config not found!");
    let reader = BufReader::new(&file);

    let mut com_baud = 0;
    let mut com_name = "".to_owned();
    let mut properties: Vec<String> = vec![];

    for (i, line) in reader.lines().enumerate() {
        let line = line.unwrap();
        let line = line.trim();
        let mut parts = line.split("//");
        let line = parts.next().unwrap();
        let parts: Vec<&str> = line.split(" ").collect();

        let key = parts[0];
        let ref values = parts[1..];

        assert!(!values.is_empty(), "No value specified after {} at: {}:{} ", key, i + 1, key.len());

        match key {
            "com_baud" => {
                assert_eq!(values.len(), 1,
                           "Too many values specified after {} at: {}:{}\n\t'{}'",
                           key, i + 1, key.len(), line
                );
                com_baud = values[0].parse::<u32>().expect("Invalid baud rate");
            },

            "com_name" => {
                assert_eq!(values.len(), 1,
                           "Too many values specified after {} at: {}:{}\n\t'{}'",
                           key, i + 1, key.len(), line
                );
                com_name = values[0].to_owned();
            }

            "properties" => {
                let mut c = key.len() + 2;
                let x = values.iter().map(|v: &&str| {
                    let name = (*(v)).to_owned();
                    assert!(FUNCTION_MAP.contains_key(&name),
                            "Invalid property name '{}' for '{}' at: {}:{}\n\t'{}'",
                            name, key, i + 1, c, line
                    );
                    c += name.len() + 1;
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

    assert_ne!(com_baud, 0, "No baud rate specified!");
    assert_ne!(com_name, "", "No com port specified!");
    assert!(!properties.is_empty(), "No selected properties");

    Config {
        com_baud,
        com_name,

        properties,
    }
}

fn open_comport(config: &Config) -> Option<Box<serialport::SerialPort>> {
    use serialport::prelude::*;
    use std::time::Duration;



    let settings = SerialPortSettings {
        baud_rate: BaudRate::BaudOther(config.com_baud),
        data_bits: DataBits::Eight,
        flow_control: FlowControl::None,
        parity: Parity::None,
        stop_bits: StopBits::One,
        timeout: Duration::from_millis(200)
    };

    let port = serialport::open_with_settings(
        "COM1",
        &settings
    );
    match port {
        Ok(p) => Some(p),

        Err(e) => {
            println!("Failed to open serial connection on port {}, with: {}", config.com_name, e);
            None
        }
    }
}

fn handle_comport() {
    let mut index = 0;
    let mut config = load_config();
    let mut com_port = open_comport(&config);

    let mut functions: Vec<_> = config.properties.iter()
        .map(|property| FUNCTION_MAP[property]).collect();

    loop {
        if TIME_TO_RELOAD.swap(false, Ordering::Relaxed) {
            config = load_config();
            com_port = open_comport(&config);

            functions = config.properties.iter()
                .map(|property| FUNCTION_MAP[property]).collect();
            index %= functions.len();
        }


        if let Some(ref mut com_port) = com_port {
            let mut step = [0u8; 1];
            com_port.read_exact(step.as_mut()).expect("Failed to read from arduino");
            let step = step[0] as i8;

            index += step as usize;
            index %= functions.len();

            let value = functions[index]();
            let data = format!("{}", value);

            com_port.write(data.as_bytes()).expect("Failed to write to arduino!");
        } else {
            debug_print_all();
            std::thread::sleep(std::time::Duration::from_millis(1000));
        }
    }
}

fn handle_client(mut client: std::net::TcpStream) {
    use std::io::Read;
    println!("Client connected!!");

    loop {
        let mut data = [1];

        match client.read_exact(data.as_mut()) {
            Ok(()) => {
                if data[0] != 0 {
                    TIME_TO_RELOAD.store(true, Ordering::Relaxed);
                }
                let sensor_data = FUNCTION_MAP.iter()
                    .fold(String::new(), |acc, (name, f)|
                        format!("{}\n{} {}", acc, name, f())
                    );
                if let Err(_) = client.write_all(sensor_data.as_bytes()) {
                    println!("Client disconnected");
                    return;
                }
            },
            Err(_) =>{
                println!("Client disconnected");
                return
            },
        }
        std::thread::sleep(std::time::Duration::from_millis(100));
    }
}

fn handle_network() {
    use std::net::TcpListener;

    let listener = TcpListener::bind("127.0.0.1:12345").expect("Failed to open server at port: 12345");
    println!("Started server");

    loop {
        for client in listener.incoming() {
            match client {
                Ok(client) => {
                    spawn(move || handle_client(client));
                },
                Err(err) => {
                    println!("Client failed to connect with: {}", err)
                },
            }
        }
    }
}

fn main() {
    cpu::cpu_init();

    spawn(|| handle_comport());
    handle_network();

    //unsafe{ cpu::cpu_drop(h) };
}

fn debug_print_all() {
    print!("{}", "\n".repeat(5));

    GPUS.with(|gpus| {
        for (i, gpu) in gpus.iter().enumerate() {
            println!("GPU {} temperature: {} degrees", i, gpu_temp(&gpu));
            println!("GPU {} usage: {} %", i, gpu_usage(&gpu));
        }
    });

    println!("CPU usage: {}%", cpu_usage());
    println!("CPU temp: {} C", cpu_temp());
    println!("RAM usage: {} %", ram_usage());
    println!("RAM usage: {} MB", ram_usage_mb());
    println!("Disk usage: {} %", disk_usage());
    println!("Disk usage: {} MB", disk_usage_mb());
    println!("Time clock: {}", time_clock());
    println!("Time date: {}", time_date());
}