
#[link(name = "Cpu", kind="static")]
extern "C" {
    fn cpu_temp(tj_max: i32) -> i32;

    fn cpu_tj_max() -> i32;

    fn test();

    fn init_cpu();

    fn uninit_cpu(h: *mut i32);
}

pub fn get_cpu_temp(tj_max: i32) -> i32 {
    unsafe{
        cpu_temp(tj_max)
    }
}

pub fn get_cpu_tj_max() -> i32 {
    unsafe {
        cpu_tj_max()
    }
}

pub fn try_test() {
    unsafe {
        test();
    }
}

pub fn cpu_init() {
    unsafe {
        init_cpu();
    }
}

pub unsafe fn cpu_drop(h: *mut i32) {
    uninit_cpu(h);
}