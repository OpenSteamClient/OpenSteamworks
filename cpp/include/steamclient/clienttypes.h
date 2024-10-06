#pragma once

#include <cstdint>
#include "enums.h"
#include <steam/steamid.h>
#include <tier1/utlbuffer.h>
#include <steam/ipaddr.h>

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

typedef uint8_t uint8;
typedef uint16_t uint16;
typedef uint32_t uint32;
typedef uint64_t uint64;

#define STEAM_CALL_RESULT(x)
#define STEAM_PRIVATE_API(x) x

// Function pointers
extern "C" typedef void*    (*CreateInterfaceFn)( const char *pName, int *pReturnCode );
extern "C" typedef void     (*SteamAPIWarningMessageHook_t)(HSteamPipe pipe, const char *message);
extern "C" typedef void     (*SteamAPIPostAPIResultInProcess_t )(SteamAPICall_t callHandle, void *pBuf, uint32_t unCallbackSize, int iCallbackNum);
extern "C" typedef uint32_t (*SteamAPICheckCallbackRegistered_t )( int iCallbackNum );
extern "C" typedef bool     (*SteamBGetCallbackFn)( HSteamPipe pipe, void *pCallbackMsg );
extern "C" typedef void     (*SteamFreeLastCallbackFn)( HSteamPipe pipe );

struct CallbackMsg_t {
    HSteamUser m_hSteamUser;
	int m_iCallback;
	void* m_pubParam;
	int m_cubParam;
};