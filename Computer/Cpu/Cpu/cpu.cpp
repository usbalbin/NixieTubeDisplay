#include <iostream>
#include <tchar.h>
#include "../WinRing0/stdafx.h"

#define DLL

#ifdef DLL
#include "../WinRing0/OlsApiInit.h"
#else
#include "../WinRing0/OlsApi.h"
#endif // DLL





// https://www.intel.com/content/dam/www/public/us/en/documents/manuals/64-ia-32-architectures-software-developers-manual.pdf
// -------------------------------------------------- -
// | IA32_THERM_STATUS Thermal Status Information(RO) |
// | Contains status information about the |
// | processor’s thermal sensor and automatic |
// | thermal monitoring facilities. |
// | See Section 14.7.2, “Thermal Monitor” |
// |													|
// | Register address 0x19C |
// | Requires  CPUID.01H:EDX[22] = 1 |
// -------------------------------------------------- -
// | bit | Description |
// | 0	| Thermal Status(RO) |
// | 1	| Thermal Status Log(R / W) |
// | 2	| PROCHOT # or FORCEPR# event(RO) |
// | 3	| PROCHOT # or FORCEPR# log(R / WC0) |
// | 4	| Critical Temperature Status(RO) |
// | 5	| Critical Temperature Status log(R / WC0) |
// | 6	| Thermal Threshold #1 Status(RO) |
// | 7	| Thermal Threshold #1 log(R / WC0) |
// | 8	| Thermal Threshold #2 Status(RO) |
// | 9	| Thermal Threshold #2 log(R / WC0) |
// | 10 | Power Limitation Status(RO) |
// | 11 | Power Limitation log(R / WC0) |
// | 12 | Current Limit Status(RO) |
// | 13 | Current Limit log(R / WC0) |
// | 14 | Cross Domain Limit Status(RO) |
// | 15 | Cross Domain Limit log(R / WC0) |
// | 22:16 | Digital Readout(RO) |
// | 26:23 | Reserved. |
// | 30:27 | Resolution in Degrees Celsius(RO) |
// | 31 | Reading Valid(RO) |
// | 63:32 | Reserved. |
// -------------------------------------------------- -



//cpuTemp proc
//	mov	ecx, 019CH; IA32_THERM_STATUS_MSR = 0x019C
//	rdmsr; ECX->EDX:EAX
//	mov ecx, eax; Move into output register
//	shr eax, 31; Set aex to bit 31 = Reading valid
//	ret
//	cpuTemp endp
//
// -------- -

int parse_temp(DWORD data) {
	return (data >> 16) & 0x7F;
}

bool is_valid_temp(DWORD data) {
	return ((1 << 31) & data) != 0;
}

int cpu_temp(int tjMax) {

	DWORD eax, edx;
	if(!Rdmsr(0x019C, &eax, &edx))
		throw "Failed to cpu temp";

	if (!is_valid_temp(eax))
		throw "Failed to cpu temp";

	return (tjMax - parse_temp(eax));
}

int cpu_tj_max() {

	DWORD eax, edx;
	if (!Rdmsr(0x01A2, &eax, &edx))
		throw "Failed to get cpu tj_max";

	return (eax >> 16) & 0xFF;
}



HMODULE init_cpu() {
	HMODULE h = NULL;

#ifdef DLL
	if (!InitOpenLibSys(&h)) {
#else
	if (!InitializeOls()) {
#endif
		std::cout << "ajaj" << std::endl;
		return NULL;
	}
	auto status = GetDllStatus();
	bool s = IsMsr();//Has support for temp stuff

	return h;
}


void uninit_cpu(HMODULE* h) {
#ifdef DLL
	if (h == NULL)
		return;
	DeinitOpenLibSys(h);
#else
	DeinitializeOls();
#endif
}




int main() {
	auto h = init_cpu();
	DWORD tj_max = cpu_tj_max();




	while (true) {
		
		std::cout << "Temp: " << cpu_temp(tj_max) << std::endl;
		Sleep(1000);
	}



	uninit_cpu(&h);
}