#pragma once

#include <cstdint>
#include "enums.h"
#include <tier1/utlbuffer.h>
#include <tier1/minbase_endian.h>

// Handle types
typedef int32_t HSteamPipe;
typedef int32_t HSteamUser;
typedef uint32_t HImage;
typedef uint32_t HHTMLBrowser;
typedef uint32_t HImage;
typedef uint32_t HSharedConnection;

typedef uint32_t HAuthTicket;
const HAuthTicket k_HAuthTicketInvalid = 0;

// Forward declare
class SteamNetworkingIdentity;

typedef int32_t unknown_ret;

typedef int32_t LibraryFolder_t;

typedef uint32_t AppId_t;
const AppId_t k_uAppIdInvalid = 0x0;

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

typedef int8_t int8;
typedef int16_t int16;
typedef int32_t int32;
typedef int64_t int64;

#define STEAM_CALL_RESULT(x)
#define STEAM_PRIVATE_API(x) x
#define STEAM_OUT_ARRAY_COUNT(COUNTER, DESC)

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

// These have to be here instead of at the top of the file, since it would lead to recursion
// This also has a major downside; these files cannot be included separately, and must be included as part of this file
#define VALID_STEAMID_INCLUDE
#include <steam/steamid.h>
#include <steam/ipaddr.h>
#include <steam/gameid.h>

struct AppStateInfo_s {
    // Purpose unknown.
    // If we have appinfo, it's 4, otherwise 0.
    uint32 unk1;
    EAppOwnershipFlags appOwnershipFlags;
    EAppState appState;
    uint32 ownerAccountID;
    uint64 unk6;
    uint32 lastChangeNumber;
    uint32 unk8;
    uint32 unk9;
    uint32 unk10;
    uint32 unk11;
};