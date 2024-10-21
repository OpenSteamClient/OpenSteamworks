#include <tier0/platform.h>
#include <chrono>

#ifdef _WIN32
#include <processthreadsapi.h>
#else
#include <unistd.h>
#endif
#include <string.h>

#include <time.h>

#ifdef _WIN32
	#include "winlite.h"
	#include <errno.h>
#else
	#include <sys/time.h>
	#include <unistd.h>
	#if IsOSX()
		#include <mach/mach.h>
		#include <mach/mach_time.h>
	#endif

#endif

#if defined( _WIN32 ) || IsOSX()
	static uint64 g_TickFrequency;
	static double g_TickFrequencyDouble;
	static double g_TicksToUS;
#else
	static constexpr uint64 g_TickFrequency = 1000000000;
	static constexpr double g_TickFrequencyDouble = 1.0e9;
	static constexpr double g_TicksToUS = 1.0e6 / g_TickFrequencyDouble;
#endif

// NOTE:
// If Plat_RelativeTicks, Plat_MSTime, etc. are called by a
// global constructor in another file then g_TickBase may be
// already initialized before executing the following line!
// InitTicks returns existing value of g_TickBase, if set.
static uint64 InitTicks();
static uint64 g_TickBase = InitTicks();

#ifdef _WIN32
static uint64 g_TickLastReturned_XPWorkaround;
#endif

static uint64 InitTicks()
{
	if ( g_TickBase != 0 )
		return g_TickBase;
	
#if defined(_WIN32)
	LARGE_INTEGER Large;
	QueryPerformanceFrequency(&Large);
	g_TickFrequency = Large.QuadPart;
	g_TickFrequencyDouble = (double)g_TickFrequency;
	// Before Windows Vista, multicore system QPC can be non-monotonic 
	QueryPerformanceCounter( &Large );
	g_TickBase = g_TickLastReturned_XPWorkaround = Large.QuadPart;
#elif IsOSX()
	mach_timebase_info_data_t TimebaseInfo;
	mach_timebase_info(&TimebaseInfo);
	g_TickFrequencyDouble = (double) TimebaseInfo.denom / (double) TimebaseInfo.numer * 1.0e9;
	g_TickFrequency = (uint64)( g_TickFrequencyDouble + 0.5 );
	g_TickBase = mach_absolute_time();
#elif IsPosix()
	// TickFrequency is constant since clock_gettime always returns nanoseconds
	timespec TimeSpec;
	clock_gettime( CLOCK_MONOTONIC, &TimeSpec );
	g_TickBase = (uint64)TimeSpec.tv_sec * 1000000000 + TimeSpec.tv_nsec;
#else
#error Unknown platform
#endif

	#if defined( _WIN32 ) || IsOSX()
		g_TicksToUS = 1.0e6 / g_TickFrequencyDouble;
	#endif

	return g_TickBase;
}

uint64 Plat_RelativeTicks()
{
	if ( g_TickBase == 0 )
		InitTicks();
	
	uint64 Ticks;

#if defined(_WIN32)
	LARGE_INTEGER Large;
	QueryPerformanceCounter(&Large);
	Ticks = Large.QuadPart;
	// On WinXP w/ multi-core CPU, ticks can go slightly backwards. Fixed in Vista+
	if ( Ticks < g_TickLastReturned_XPWorkaround )
	{
		Ticks = g_TickLastReturned_XPWorkaround;
	}
	else
	{
		g_TickLastReturned_XPWorkaround = Ticks;
	}
#elif IsOSX()
	Ticks = mach_absolute_time();
#elif IsPosix()
	timespec TimeSpec;
	clock_gettime( CLOCK_MONOTONIC, &TimeSpec );
	Ticks = (uint64)TimeSpec.tv_sec * 1000000000 + TimeSpec.tv_nsec;
#else
#error Unknown platform
#endif

	return Ticks;
}

double Plat_FloatTime()
{
	// We subtract off the tick base to keep the diff as small
	// as possible so that our conversion math is more accurate.
	uint64 Ticks = Plat_RelativeTicks(); // NOTE: inits globals
	return ((double)(int64)(Ticks - g_TickBase)) / g_TickFrequencyDouble;
}

uint32 Plat_MSTime()
{
	// We subtract off the tick base to keep the diff as small
	// as possible so that our conversion math is more accurate.
	uint64 Ticks = Plat_RelativeTicks(); // NOTE: inits globals
	return (uint32)(((Ticks - g_TickBase) * 1000) / g_TickFrequency);
}

uint64 Plat_USTime()
{
	// We subtract off the tick base to keep the diff as small
	// as possible so that our conversion math is more accurate.
	uint64 Ticks = Plat_RelativeTicks(); // NOTE: inits globals
	return (uint64)( (Ticks - g_TickBase) * g_TicksToUS );
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

static const char **g_Argv;
static int g_Argc;

__attribute__((constructor))
void set_args(int argc, const char **argv)
{
    g_Argc = argc;
    g_Argv = argv;
}

const char **Plat_GetProcessArgv(int *pArgc)
{
    *pArgc = g_Argc;
    return g_Argv;
}

bool Plat_CommandLineParamExists(const char *argToCheck)
{
    if (argToCheck == nullptr)
    {
        return false;
    }

    int argc;
    const char **argv = Plat_GetProcessArgv(&argc);

    for (int i = 0; i < argc; i++)
    {
        const char *arg = argv[i];
        if (arg == nullptr)
        {
            return false;
        }

        if (strcmp(arg, argToCheck) == 0)
        {
            return true;
        }
    }

    return false;
}

bool Plat_IsSteamDeck()
{
    static bool bIsSet = false;
    static bool bIsDeck = false;

    if (bIsSet)
    {
        return bIsDeck;
    }

    bIsSet = true;

    bIsDeck = Plat_CommandLineParamExists("-steamdeck");
    return bIsDeck;
}

bool Plat_IsInDebugSession()
{
#ifdef _WIN32
	return (IsDebuggerPresent() != 0);
#elif IsOSX()
	int mib[4];
	struct kinfo_proc info;
	size_t size;
	mib[0] = CTL_KERN;
	mib[1] = KERN_PROC;
	mib[2] = KERN_PROC_PID;
	mib[3] = getpid();
	size = sizeof(info);
	info.kp_proc.p_flag = 0;
	sysctl(mib,4,&info,&size,NULL,0);
	return ((info.kp_proc.p_flag & P_TRACED) == P_TRACED);
#elif IsLinux()
	static FILE *fp;
	if ( !fp )
	{
		char rgchProcStatusFile[256]; rgchProcStatusFile[0] = '\0';
		snprintf( rgchProcStatusFile, sizeof(rgchProcStatusFile), "/proc/%d/status", getpid() );
		fp = fopen( rgchProcStatusFile, "r" );
	}

	char rgchLine[256]; rgchLine[0] = '\0';
	int nTracePid = 0;
	if ( fp )
	{
		const char *pszSearchString = "TracerPid:";
		const uint cchSearchString = strlen( pszSearchString );
		rewind( fp );
		while ( fgets( rgchLine, sizeof(rgchLine), fp ) )
		{
			if ( !strncasecmp( pszSearchString, rgchLine, cchSearchString ) )
			{
				char *pszVal = rgchLine+cchSearchString+1;
				nTracePid = atoi( pszVal );
				break;
			}
		}
	}
	return (nTracePid != 0);
#else
	#error "HALP"
#endif
}
