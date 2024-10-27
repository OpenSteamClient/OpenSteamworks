#pragma once
#include <minbase/minbase_endian.h>
#include <minbase/minbase_identify.h>
#include <minbase/minbase_types.h>

typedef int32_t HSteamPipe;
typedef int32_t HSteamUser;
typedef uint32_t HImage;
typedef uint32_t HHTMLBrowser;

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

// Party Beacon ID
typedef uint64 PartyBeaconID_t;
const PartyBeaconID_t k_ulPartyBeaconIdInvalid = 0;

typedef uint64 GMSQueryHandle_t;
const GMSQueryHandle_t k_ulQueryHandleInvalid = 0;

typedef uint32_t HAuthTicket;
const HAuthTicket k_HAuthTicketInvalid = 0;

// Types of items in your game are identified by a 32-bit "item definition number".
// Valid definition numbers are between 1 and 999999999; numbers less than or equal to
// zero are invalid, and numbers greater than or equal to one billion (1x10^9) are
// reserved for internal Steam use.
typedef int32 SteamItemDef_t;

typedef int32 SteamInventoryResult_t;
static const SteamInventoryResult_t k_SteamInventoryResultInvalid = -1;

typedef uint64 SteamInventoryUpdateHandle_t;
const SteamInventoryUpdateHandle_t k_SteamInventoryUpdateHandleInvalid = 0xffffffffffffffffull;

// Every individual instance of an item has a globally-unique ItemInstanceID.
// This ID is unique to the combination of (player, specific item instance)
// and will not be transferred to another player or re-used for another item.
typedef uint64 SteamItemInstanceID_t;
static const SteamItemInstanceID_t k_SteamItemInstanceIDInvalid = (SteamItemInstanceID_t)~0;

const uint32 k_nScreenshotMaxTaggedUsers = 32;
const uint32 k_nScreenshotMaxTaggedPublishedFiles = 32;
const int k_cubUFSTagTypeMax = 255;
const int k_cubUFSTagValueMax = 255;

// Required with of a thumbnail provided to AddScreenshotToLibrary.  If you do not provide a thumbnail
// one will be generated.
const int k_ScreenshotThumbWidth = 200;

// Handle is valid for the lifetime of your process and no longer
typedef uint32 ScreenshotHandle;
#define INVALID_SCREENSHOT_HANDLE 0

typedef uint64 UGCQueryHandle_t;
const UGCQueryHandle_t k_UGCQueryHandleInvalid = 0xffffffffffffffffull;

typedef uint64 UGCUpdateHandle_t;
const UGCUpdateHandle_t k_UGCUpdateHandleInvalid = 0xffffffffffffffffull;

// Steam Remote Play session ID
typedef uint32 RemotePlaySessionID_t;

const uint32 kNumUGCResultsPerPage = 50;
const uint32 k_cchDeveloperMetadataMax = 5000;
const uint32 k_cchPublishedDocumentTitleMax = 128 + 1;
const uint32 k_cchPublishedDocumentDescriptionMax = 8000;
const uint32 k_cchPublishedDocumentChangeDescriptionMax = 8000;
const uint32 k_unEnumeratePublishedFilesMaxResults = 50;
const uint32 k_cchTagListMax = 1024 + 1;
const uint32 k_cchFilenameMax = 260;
const uint32 k_cchPublishedFileURLMax = 256;

// Forward declare
class SteamNetworkingIdentity;

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
#define STEAM_OUT_STRING_COUNT(x)
#define STEAM_OUT_BUFFER_COUNT(x)
#define STEAM_BUFFER_COUNT(x)
#define STEAM_DESC(x)

// maximum number of characters a lobby metadata key can be
#define k_nMaxLobbyKeyLength 255

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