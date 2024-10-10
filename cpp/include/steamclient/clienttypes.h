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
typedef uint64_t UGCHandle_t;
typedef uint64 SteamLeaderboard_t;
typedef uint64 SteamLeaderboardEntries_t;

typedef int16 FriendsGroupID_t;
const FriendsGroupID_t k_FriendsGroupID_Invalid = -1;

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
#define STEAM_OUT_ARRAY_COUNT(x, y)
#define STEAM_FLAT_NAME(x)
#define STEAM_CALL_BACK(x)
#define STEAM_METHOD_DESC(x)
#define STEAM_ARRAY_COUNT_D(x, y)
#define STEAM_ARRAY_COUNT(x)

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

// Maximum sizes

// size limit on stat or achievement name (UTF-8 encoded)
enum { k_cchStatNameMax = 128 };

// maximum number of bytes for a leaderboard name (UTF-8 encoded)
enum { k_cchLeaderboardNameMax = 128 };

// maximum number of details int32's storable for a single leaderboard entry
enum { k_cLeaderboardDetailsMax = 64 };

// maximum length of friend group name (not including terminating nul!)
const int k_cchMaxFriendsGroupName = 64;

// maximum number of groups a single user is allowed
const int k_cFriendsGroupLimit = 100;

const int k_cEnumerateFollowersMax = 50;

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

#if defined( VALVE_CALLBACK_PACK_SMALL )
#pragma pack( push, 4 )
#elif defined( VALVE_CALLBACK_PACK_LARGE )
#pragma pack( push, 8 )
#else
#error VALVE_CALLBACK_PACK_xxx should be defined
#endif 

// friend game played information
struct FriendGameInfo_t
{
	CGameID m_gameID;
	uint32 m_unGameIP;
	uint16 m_usGamePort;
	uint16 m_usQueryPort;
	CSteamID m_steamIDLobby;
};

// a single entry in a leaderboard, as returned by GetDownloadedLeaderboardEntry()
struct LeaderboardEntry_t
{
	CSteamID m_steamIDUser; // user with the entry - use SteamFriends()->GetFriendPersonaName() & SteamFriends()->GetFriendAvatar() to get more info
	int32 m_nGlobalRank;	// [1..N], where N is the number of users with an entry in the leaderboard
	int32 m_nScore;			// score as set in the leaderboard
	int32 m_cDetails;		// number of int32 details available for this entry
	UGCHandle_t m_hUGC;		// handle for UGC attached to the entry
};

#pragma pack( pop )