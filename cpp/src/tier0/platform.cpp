#include <tier0/platform.h>
#include <chrono>

#ifdef _WIN32
#include <processthreadsapi.h>
#else
#include <unistd.h>
#endif
#include <string.h>

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
