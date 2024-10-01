#include <tier0/platform.h>
#include <chrono>

#ifdef _WIN32
#include <processthreadsapi.h>
#else
#include <unistd.h>
#endif

uint32_t Plat_MSTime()
{
    return std::chrono::duration_cast<std::chrono::milliseconds>(std::chrono::system_clock::now().time_since_epoch()).count();
}

uint32_t ThreadGetCurrentProcessId()
{
#ifdef _WIN32
    return GetCurrentProcessId();
#else
    return getpid();
#endif
}

uint32_t ThreadGetCurrentId()
{
#ifdef _WIN32
    return (uint32_t)GetCurrentThreadId();
#else
    return gettid();
#endif
}

