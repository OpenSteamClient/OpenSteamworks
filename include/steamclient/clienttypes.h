#pragma once

#include <cstdint>
#include "enums.h"
#include <steam/steamid.h>
#include <steam/utlbuf.h>

// Handle types
typedef int32_t HSteamPipe;
typedef int32_t HSteamUser;
typedef uint32_t HImage;
typedef uint32_t HHTMLBrowser;
typedef uint32_t HImage;
typedef uint32_t HSharedConnection;

typedef int32_t unknown_ret;

typedef int32_t LibraryFolder_t;
typedef uint32_t AppId_t;
typedef uint32_t RTime32;
typedef uint32_t DepotId_t;
typedef uint32_t AccountID_t;
typedef uint32_t RemotePlaySessionID_t;

typedef uint64_t GID_t;
typedef uint64_t SteamAPICall_t;
typedef uint64_t UGCFileWriteStreamHandle_t;

// Function pointers
typedef void*   (*CreateInterfaceFn)( const char *pName, int *pReturnCode );
typedef void    (*SteamAPIWarningMessageHook_t)(HSteamPipe pipe, const char *message);
typedef bool    (*SteamBGetCallbackFn)( HSteamPipe pipe, void *pCallbackMsg );
typedef void    (*SteamFreeLastCallbackFn)( HSteamPipe pipe );