#pragma once

#include <cstdint>
#include "enums.h"
#include <tier1/utlbuffer.h>
#include <tier1/utlmap.h>
#include <steam/steamtypes.h>

typedef uint32_t HSharedConnection;
typedef int32_t LibraryFolder_t;

typedef int32_t unknown_ret;

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

#include <steam/steamclientpublic.h>

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