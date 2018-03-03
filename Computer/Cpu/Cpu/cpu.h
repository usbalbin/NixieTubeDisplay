#include <stdint.h>

extern "C" {
	extern int32_t cpu_temp(int32_t tjMax);

	extern int32_t cpu_tj_max();

	extern void test();


	extern void init_cpu();
	extern void uninit_cpu(void* h);
}