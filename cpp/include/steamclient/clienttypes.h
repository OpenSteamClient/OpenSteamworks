#pragma once

#include <cstdint>
#include "enums.h"
#include <tier1/utlbuffer.h>
#include <tier1/utlmap.h>
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
const GID_t k_GIDNil = 0xffffffffffffffffull;

typedef uint64_t SteamAPICall_t;

typedef uint64_t UGCFileWriteStreamHandle_t;
const UGCFileWriteStreamHandle_t k_UGCFileStreamHandleInvalid = 0xffffffffffffffffull;

typedef uint64_t UGCHandle_t;
typedef uint64_t SteamLeaderboard_t;
typedef uint64_t SteamLeaderboardEntries_t;

// A handle to a piece of user generated content
typedef uint64_t UGCHandle_t;
const UGCHandle_t k_UGCHandleInvalid = 0xffffffffffffffffull;

typedef uint64_t PublishedFileUpdateHandle_t;
const PublishedFileUpdateHandle_t k_PublishedFileUpdateHandleInvalid = 0xffffffffffffffffull;

typedef uint64_t PublishedFileId_t;
const PublishedFileId_t k_PublishedFileIdInvalid = 0;

typedef int16_t FriendsGroupID_t;
const FriendsGroupID_t k_FriendsGroupID_Invalid = -1;

typedef uint8_t uint8;
typedef uint16_t uint16;
typedef uint32_t uint32;
typedef uint64_t uint64;

typedef int8_t int8;
typedef int16_t int16;
typedef int32_t int32;
typedef int64_t int64;

// ControllerHandle_t is used to refer to a specific controller.
// This handle will consistently identify a controller, even if it is disconnected and re-connected
typedef uint64 ControllerHandle_t;
#define InputHandle_t ControllerHandle_t

// These handles are used to refer to a specific in-game action or action set
// All action handles should be queried during initialization for performance reasons
typedef uint64 ControllerActionSetHandle_t;
typedef uint64 ControllerDigitalActionHandle_t;
typedef uint64 ControllerAnalogActionHandle_t;
#define InputActionSetHandle_t ControllerActionSetHandle_t
#define InputDigitalActionHandle_t ControllerDigitalActionHandle_t
#define InputAnalogActionHandle_t ControllerAnalogActionHandle_t

// handle to a socket
typedef uint32 SNetSocket_t;		// CreateP2PConnectionSocket()
typedef uint32 SNetListenSocket_t;	// CreateListenSocket()

#define STEAM_CALL_RESULT(x)
#define STEAM_PRIVATE_API(x) x
#define STEAM_OUT_ARRAY_COUNT(x, y)
#define STEAM_FLAT_NAME(x)
#define STEAM_CALL_BACK(x)
#define STEAM_METHOD_DESC(x)
#define STEAM_ARRAY_COUNT_D(x, y)
#define STEAM_ARRAY_COUNT(x)
#define STEAM_OUT_STRING()
#define STEAM_OUT_STRUCT()
#define STEAM_OUT_ARRAY_CALL(x, y, z)

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

// maximum number of characters in a user's name. Two flavors; one for UTF-8 and one for UTF-16.
// The UTF-8 version has to be very generous to accomodate characters that get large when encoded
// in UTF-8.
enum
{
	k_cchPersonaNameMax = 128,
	k_cwchPersonaNameMax = 32,
};

// size limit on chat room or member metadata
const uint32 k_cubChatMetadataMax = 8192;

// size limits on Rich Presence data
enum { k_cchMaxRichPresenceKeys = 30 };
enum { k_cchMaxRichPresenceKeyLength = 64 };
enum { k_cchMaxRichPresenceValueLength = 256 };

// maximum length of friend group name (not including terminating nul!)
const int k_cchMaxFriendsGroupName = 64;

// maximum number of groups a single user is allowed
const int k_cFriendsGroupLimit = 100;

const int k_cEnumerateFollowersMax = 50;

#define STEAM_CONTROLLER_MAX_COUNT 16
#define STEAM_CONTROLLER_MAX_ANALOG_ACTIONS 24
#define STEAM_CONTROLLER_MAX_DIGITAL_ACTIONS 256
#define STEAM_CONTROLLER_MAX_ORIGINS 8
#define STEAM_CONTROLLER_MAX_ACTIVE_LAYERS 16

// When sending an option to a specific controller handle, you can send to all controllers via this command
#define STEAM_CONTROLLER_HANDLE_ALL_CONTROLLERS UINT64_MAX

#define STEAM_CONTROLLER_MIN_ANALOG_ACTION_DATA -1.0f
#define STEAM_CONTROLLER_MAX_ANALOG_ACTION_DATA 1.0f

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

//-----------------------------------------------------------------------------
// Purpose: information about user sessions
//-----------------------------------------------------------------------------
struct FriendSessionStateInfo_t
{
	uint32 m_uiOnlineSessionInstances;
	uint8 m_uiPublishedToFriendsSessionInstance;
};

#pragma pack( push, VALVE_CALLBACK_SIZE )

// connection state to a specified user, returned by GetP2PSessionState()
// this is under-the-hood info about what's going on with a SendP2PPacket(), shouldn't be needed except for debuggin
struct P2PSessionState_t
{
	uint8 m_bConnectionActive;		// true if we've got an active open connection
	uint8 m_bConnecting;			// true if we're currently trying to establish a connection
	uint8 m_eP2PSessionError;		// last error recorded (see enum above)
	uint8 m_bUsingRelay;			// true if it's going through a relay server (TURN)
	int32 m_nBytesQueuedForSend;
	int32 m_nPacketsQueuedForSend;
	uint32 m_nRemoteIP;				// potential IP:Port of remote host. Could be TURN server. 
	uint16 m_nRemotePort;			// Only exists for compatibility with older authentication api's
};

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

//-----------------------------------------------------------------------------
// Purpose: Structure that contains an array of const char * strings and the number of those strings
//-----------------------------------------------------------------------------
struct SteamParamStringArray_t
{
    SteamParamStringArray_t()
	{
		m_ppStrings = nullptr;
		m_nNumStrings = 0;
	}

	const char ** m_ppStrings;
	int32 m_nNumStrings;
};

#pragma pack( pop )