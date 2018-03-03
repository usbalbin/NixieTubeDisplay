
extern crate deamon;
extern crate nvapi_sys;

use deamon::*;

fn main() {
    println!("Started!!!");
    let all_gpus = get_gpus();
    println!("CPU-init");
    let h = cpu::cpu_init();

    println!("Get tj max");
    let tj_max = cpu::get_cpu_tj_max();
    println!("Got tj max: {}", tj_max);
    loop {
        print!("{}", "\n".repeat(5));

        for (i, gpu) in all_gpus.iter().enumerate() {
            let gpu_temp = get_gpu_temp(&gpu);
            println!("GPU {} temperature: {} degrees", i, gpu_temp);

            let gpu_usage = get_gpu_usage(&gpu);
            println!("GPU {} usage: {} %", i, gpu_usage);
        }

        let cpu_usage = get_cpu_usage() * 100.0;
        println!("CPU usage: {}%", cpu_usage as u32);

        let cpu_temp = cpu::get_cpu_temp(tj_max);
        println!("CPU temp: {} C", cpu_temp);

        let ram_usage = get_ram_usage();
        println!("RAM usage: {} MB", ram_usage);

        let disk_usage = get_disk_usage();
        println!("Disk usage: {} MB", disk_usage);

        std::thread::sleep(std::time::Duration::from_millis(1000));
    }

    //unsafe{ cpu::cpu_drop(h) };
}