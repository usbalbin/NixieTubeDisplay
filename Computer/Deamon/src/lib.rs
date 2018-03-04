
extern crate sys_info;

extern crate nvapi;
extern crate nvapi_sys;

extern crate chrono;

use nvapi_sys::nvapi::NvAPI_Initialize;
use nvapi_sys::gpu::NvAPI_EnumPhysicalGPUs;
use nvapi_sys::handles::NvPhysicalGpuHandle;

use nvapi_sys::gpu::thermal::{
    NVAPI_THERMAL_TARGET_ALL,
    NvAPI_GPU_GetThermalSettings
};

pub mod cpu;

pub fn get_gpus() -> Vec<NvPhysicalGpuHandle> {
    unsafe {
        let status = NvAPI_Initialize();
        if status != 0 {
            println!("Failed to initialize NvAPI with status: {}. No Nvidia GPU present?", status);
            return vec![];
        }
    }

    let mut gpu_count = 0;
    let mut gpus = [NvPhysicalGpuHandle::default(); 64];

    unsafe {
        let status = NvAPI_EnumPhysicalGPUs(&mut gpus, &mut gpu_count);
        if status != 0 {
            println!("Failed to get Nvidia GPUs with status: {}", status);
            return vec![];
        }
    }
    (0..gpu_count).map(|i| gpus[i as usize]).collect()
}

pub fn gpu_temp(gpu: &NvPhysicalGpuHandle) -> i32 {
    use nvapi_sys::gpu::thermal::{
        NV_GPU_THERMAL_SETTINGS,
        NV_GPU_THERMAL_SETTINGS_VER
    };

    let mut info = NV_GPU_THERMAL_SETTINGS::zeroed();
    info.version = NV_GPU_THERMAL_SETTINGS_VER;

    unsafe {
        let status = NvAPI_GPU_GetThermalSettings(*gpu, NVAPI_THERMAL_TARGET_ALL as u32, &mut info);
        if status != 0 {
            println!("Failed to get GPU-temp with status: {}", status);
            return 0;
        };
    }

    info.sensor[0 as usize].currentTemp
}

pub fn gpu_usage(gpu: &NvPhysicalGpuHandle) -> i32 {
    use nvapi_sys::gpu::pstate::{
        NV_GPU_DYNAMIC_PSTATES_INFO_EX,
        NV_GPU_DYNAMIC_PSTATES_INFO_EX_VER,
        NvAPI_GPU_GetDynamicPstatesInfoEx,
        NVAPI_GPU_UTILIZATION_DOMAIN_GPU
    };

    let mut info = NV_GPU_DYNAMIC_PSTATES_INFO_EX::zeroed();
    info.version = NV_GPU_DYNAMIC_PSTATES_INFO_EX_VER;

    unsafe {
        let status = NvAPI_GPU_GetDynamicPstatesInfoEx(*gpu, &mut info);
        if status != 0 {
            println!("Failed to get GPU-usage with status: {}", status);
            return 0;
        };
    }

    info.utilization[NVAPI_GPU_UTILIZATION_DOMAIN_GPU as usize].percentage as i32
}

pub fn cpu_usage() -> i32 {
    if let Ok(load) = sys_info::loadavg(){
        (load.one * 100.0) as i32
    } else {
        0
    }
}

pub fn ram_usage() -> i32 {
    if let Ok(mem_info) = sys_info::mem_info() {
        ((1024 * 100 * ram_usage_mb() as u64) / mem_info.total as u64) as i32
    } else {
        0
    }
}

pub fn ram_usage_mb() -> i32 {
    if let Ok(mem_info) = sys_info::mem_info() {
        ((mem_info.total - mem_info.free) / 1024) as i32
    } else {
        0
    }
}

pub fn disk_usage() -> i32 {
    if let Ok(mem_info) = sys_info::mem_info() {
        ((1024 * 10 * disk_usage_mb() as u64) / mem_info.total as u64) as i32
    } else {
        0
    }
}

pub fn disk_usage_mb() -> i32 {
    if let Ok(disk_info) = sys_info::disk_info() {
        ((disk_info.total - disk_info.free) / 1024) as i32
    } else {
        0
    }
}

pub fn time_clock() -> i32 {
    let values: Vec<_> = chrono::Local::now().time()
        .format("%H%M").to_string()
        .chars().collect();

    let mut res = 0;
    let mut f = 1;
    for value in values.iter().rev() {
        res += f * (*value as u8 - '0' as u8) as i32;
        f *= 10;
    }
    res
}

pub fn time_date() -> i32 {
    let values: Vec<_> = chrono::Local::now()
        .format("%y%m%d").to_string()
        .chars().collect();

    let mut res = 0;
    let mut f = 1;
    for value in values.iter().rev() {
        res += f * (*value as u8 - '0' as u8) as i32;
        f *= 10;
    }
    res
}