

fn main() {
    std::fs::copy("../Cpu/x64/Release/Cpu.dll", "Cpu.dll").unwrap();
    std::fs::copy("../Cpu/x64/Release/Cpu.dll", "target/debug/Cpu.dll").unwrap();
    std::fs::copy("../Cpu/x64/Release/Cpu.dll", "target/release/Cpu.dll").unwrap();
    println!(r"cargo:rustc-link-search=../Cpu/x64/Release");
    println!("cargo:rustc-link-lib=static=Cpu");
}