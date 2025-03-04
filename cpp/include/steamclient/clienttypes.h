#pragma once

#include <cstdint>
#include "enums.h"
#include <tier1/utlbuffer.h>
#include <tier1/utlmap.h>
#include <steam/steamtypes.h>
#include <steam/steam_api_common.h>

typedef uint32_t HSharedConnection;
typedef int32_t LibraryFolder_t;

typedef int32_t unknown;

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
public:

	// Zero-init ctor.
	CallbackMsg_t()
	{
		m_hSteamUser = 0;
		m_iCallback = 0;
		m_pubParam = nullptr;
		m_cubParam = 0;
	}


	// Does not copy.
	CallbackMsg_t(HSteamUser hSteamUser, int iCallback, void *pubParam, int cubParam)
	{
		m_hSteamUser = hSteamUser;
		m_iCallback = iCallback;
		m_pubParam = pubParam;
		m_cubParam = cubParam;
	}

	// Copies callback body from pubParam.
	static CallbackMsg_t *Copy(HSteamUser hSteamUser, int iCallback, const void *pubParam, int cubParam)
	{
		auto mem = malloc(cubParam);
		memcpy(mem, pubParam, cubParam);

		return new CallbackMsg_t(hSteamUser, iCallback, mem, cubParam);
	}
};

#include <steam/steamclientpublic.h>

#pragma pack(push, VALVE_CALLBACK_SIZE)

struct SteamNetworkingSocketsCert_t
{
	enum { k_iCallback = k_iSteamNetworkingCallbacks + 96 };

	EResult m_eResult;
	uint32 m_cbCert;
	char m_cert[0x200];
	uint64 m_caKeyID;
	uint32 m_cbSignature;
	char m_signature[0x80];

	// Pub/Priv keypair. Public is first 32, priv is next 32
	uint32 m_cbPrivKey;
	char m_privKey[0x80];
};

#pragma pack(pop)

#pragma pack( push, 1 )

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
};

#pragma pack( pop )

static_assert(sizeof(AppStateInfo_s) == 36);