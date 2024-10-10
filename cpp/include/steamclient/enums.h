#pragma once

enum EAccountType {
    EAccountType_Invalid = 0,
    // single user account
    EAccountType_Individual = 1,	
    // multiseat (e.g. cybercafe) account
    EAccountType_Multiseat = 2,	
    // game server account
    EAccountType_GameServer = 3,
    //  anonymous game server account
    EAccountType_AnonGameServer = 4,	
    EAccountType_Pending = 5,		
    // content server
    EAccountType_ContentServer = 6,	
    EAccountType_Clan = 7,
    EAccountType_Chat = 8,
    // Fake SteamID for local PSN account on PS3 or Live account on 360, etc.
    EAccountType_ConsoleUser = 9,	
    EAccountType_AnonUser = 10,

    // Max of 16 items in this field
    EAccountType_Max
};

//-----------------------------------------------------------------------------
// Purpose: list of states a friend can be in
//-----------------------------------------------------------------------------
enum EPersonaState
{
	k_EPersonaStateOffline = 0,			// friend is not currently logged on
	k_EPersonaStateOnline = 1,			// friend is logged on
	k_EPersonaStateBusy = 2,			// user is on, but busy
	k_EPersonaStateAway = 3,			// auto-away feature
	k_EPersonaStateSnooze = 4,			// auto-away for a long time
	k_EPersonaStateLookingToTrade = 5,	// Online, trading
	k_EPersonaStateLookingToPlay = 6,	// Online, wanting to play
	k_EPersonaStateInvisible = 7,		// Online, but appears offline to friends.  This status is never published to clients.
	k_EPersonaStateMax,
};


//-----------------------------------------------------------------------------
// Purpose: flags for enumerating friends list, or quickly checking a the relationship between users
//-----------------------------------------------------------------------------
enum EFriendFlags
{
	k_EFriendFlagNone			= 0x00,
	k_EFriendFlagBlocked		= 0x01,
	k_EFriendFlagFriendshipRequested	= 0x02,
	k_EFriendFlagImmediate		= 0x04,			// "regular" friend
	k_EFriendFlagClanMember		= 0x08,
	k_EFriendFlagOnGameServer	= 0x10,	
	// k_EFriendFlagHasPlayedWith	= 0x20,	// not currently used
	// k_EFriendFlagFriendOfFriend	= 0x40, // not currently used
	k_EFriendFlagRequestingFriendship = 0x80,
	k_EFriendFlagRequestingInfo = 0x100,
	k_EFriendFlagIgnored		= 0x200,
	k_EFriendFlagIgnoredFriend	= 0x400,
	// k_EFriendFlagSuggested		= 0x800,	// not used
	k_EFriendFlagChatMember		= 0x1000,
	k_EFriendFlagAll			= 0xFFFF,
};

//-----------------------------------------------------------------------------
// Purpose: set of relationships to other users
//-----------------------------------------------------------------------------
enum EFriendRelationship
{
	k_EFriendRelationshipNone = 0,
	k_EFriendRelationshipBlocked = 1,			// this doesn't get stored; the user has just done an Ignore on an friendship invite
	k_EFriendRelationshipRequestRecipient = 2,
	k_EFriendRelationshipFriend = 3,
	k_EFriendRelationshipRequestInitiator = 4,
	k_EFriendRelationshipIgnored = 5,			// this is stored; the user has explicit blocked this other user from comments/chat/etc
	k_EFriendRelationshipIgnoredFriend = 6,
	k_EFriendRelationshipSuggested_DEPRECATED = 7,		// was used by the original implementation of the facebook linking feature, but now unused.

	// keep this updated
	k_EFriendRelationshipMax = 8,
};

enum ESteamUserStatType
{
	k_ESteamUserStatTypeINVALID = 0,
	k_ESteamUserStatTypeINT = 1,
	k_ESteamUserStatTypeFLOAT = 2,
	// Read as FLOAT, set with count / session length
	k_ESteamUserStatTypeAVGRATE = 3,
	k_ESteamUserStatTypeACHIEVEMENTS = 4,
	k_ESteamUserStatTypeGROUPACHIEVEMENTS = 5,
};

// type of data request, when downloading leaderboard entries
enum ELeaderboardDataRequest
{
	k_ELeaderboardDataRequestGlobal = 0,
	k_ELeaderboardDataRequestGlobalAroundUser = 1,
	k_ELeaderboardDataRequestFriends = 2,
	k_ELeaderboardDataRequestUsers = 3
};

// the sort order of a leaderboard
enum ELeaderboardSortMethod
{
	k_ELeaderboardSortMethodNone = 0,
	k_ELeaderboardSortMethodAscending = 1,	// top-score is lowest number
	k_ELeaderboardSortMethodDescending = 2,	// top-score is highest number
};

// the display type (used by the Steam Community web site) for a leaderboard
enum ELeaderboardDisplayType
{
	k_ELeaderboardDisplayTypeNone = 0, 
	k_ELeaderboardDisplayTypeNumeric = 1,			// simple numerical score
	k_ELeaderboardDisplayTypeTimeSeconds = 2,		// the score represents a time, in seconds
	k_ELeaderboardDisplayTypeTimeMilliSeconds = 3,	// the score represents a time, in milliseconds
};

enum ELeaderboardUploadScoreMethod
{
	k_ELeaderboardUploadScoreMethodNone = 0,
	k_ELeaderboardUploadScoreMethodKeepBest = 1,	// Leaderboard will keep user's best score
	k_ELeaderboardUploadScoreMethodForceUpdate = 2,	// Leaderboard will always replace score with specified
};

enum EAppOwnershipFlags
{
	k_EAppOwnershipFlagsNone = 0,
	k_EAppOwnershipFlagsOwnsLicense = 1,
	k_EAppOwnershipFlagsFreeLicense = 2,
	k_EAppOwnershipFlagsRegionRestricted = 4,
	k_EAppOwnershipFlagsLowViolence = 8,
	k_EAppOwnershipFlagsInvalidPlatform = 16,
	k_EAppOwnershipFlagsSharedLicense = 32,
	k_EAppOwnershipFlagsFreeWeekend = 64,
	k_EAppOwnershipFlagsRetailLicense = 128,
	k_EAppOwnershipFlagsLicenseLocked = 256,
	k_EAppOwnershipFlagsLicensePending = 512,
	k_EAppOwnershipFlagsLicenseExpired = 1024,
	k_EAppOwnershipFlagsLicensePermanent = 2048,
	k_EAppOwnershipFlagsLicenseRecurring = 4096,
	k_EAppOwnershipFlagsLicenseCanceled = 8192,
	k_EAppOwnershipFlagsAutoGrant = 16384,
	k_EAppOwnershipFlagsPendingGift = 32768,
	k_EAppOwnershipFlagsRentalNotActivated = 65536,
	k_EAppOwnershipFlagsRental = 131072,
	k_EAppOwnershipFlagsSiteLicense = 262144,
	k_EAppOwnershipFlagsLegacyFreeSub = 524288,
	k_EAppOwnershipFlagsInvalidOSType = 1048576,
	k_EAppOwnershipFlagsTimedTrial = 2097152,
};

enum EAppState
{
    k_EAppStateInvalid = 0,
    k_EAppStateUninstalled = 1,
    k_EAppStateUpdateRequired = 1 << 1,
    k_EAppStateFullyInstalled = 1 << 2,
    k_EAppStateUpdateQueued = 1 << 3,
    k_EAppStateUpdateOptional = 1 << 4,
    k_EAppStateFilesMissing = 1 << 5,
    k_EAppStateSharedOnly = 1 << 6,
    k_EAppStateFilesCorrupt = 1 << 7,
    k_EAppStateUpdateRunning = 1 << 8,
    k_EAppStateUpdatePaused = 1 << 9,
    k_EAppStateUpdateStarted = 1 << 10,
    k_EAppStateUninstalling = 1 << 11,
    k_EAppStateBackupRunning = 1 << 12,
    k_EAppStateAppRunning = 1 << 13,
    k_EAppStateComponentInUse = 1 << 14,
    k_EAppStateMovingFolder = 1 << 15,
    k_EAppStateTerminating = 1 << 16,
    k_EAppStatePrefetchingInfo = 1 << 17,
    k_EAppStatePeerServer = 1 << 18,
};

enum EAppType
{
	k_EAppTypeDepotonly = -2147483648,
	k_EAppTypeInvalid = 0,
	k_EAppTypeGame = 1,
	k_EAppTypeApplication = 2,
	k_EAppTypeTool = 4,
	k_EAppTypeDemo = 8,
	k_EAppTypeMedia = 16,
	k_EAppTypeDlc = 32,
	k_EAppTypeGuide = 64,
	k_EAppTypeDriver = 128,
	k_EAppTypeConfig = 256,
	k_EAppTypeHardware = 512,
	k_EAppTypeFranchise = 1024,
	k_EAppTypeVideo = 2048,
	k_EAppTypePlugin = 4096,
	k_EAppTypeMusic = 8192,
	k_EAppTypeSeries = 16384,
	k_EAppTypeComic = 32768,
	k_EAppTypeBeta = 65536,
	k_EAppTypeShortcut = 1073741824
};

enum EAppInfoSection
{
	k_EAppInfoSectionUnknown = 0,
	k_EAppInfoSectionAll,
	k_EAppInfoSectionCommon,
	k_EAppInfoSectionExtended,
	k_EAppInfoSectionConfig,
	k_EAppInfoSectionStats,
	k_EAppInfoSectionInstall,
	k_EAppInfoSectionDepots,
	k_EAppInfoSectionVac,
	k_EAppInfoSectionDrm,
	k_EAppInfoSectionUfs,
	k_EAppInfoSectionOgg,
	k_EAppInfoSectionItems,
	k_EAppInfoSectionPolicies,
	k_EAppInfoSectionSysreqs,
	k_EAppInfoSectionCommunity,
	k_EAppInfoSectionStore,
    k_EAppInfoSectionLocalization,
    k_EAppInfoSectionBroadcastgamedata,
	k_EAppInfoSectionComputed,
	k_EAppInfoSectionAlbummetadata,
};

enum ESteamControllerPad
{
	k_ESteamControllerPad_Left,
	k_ESteamControllerPad_Right
};

// results from BeginAuthSession
enum EBeginAuthSessionResult
{
	k_EBeginAuthSessionResultOK = 0,						// Ticket is valid for this game and this steamID.
	k_EBeginAuthSessionResultInvalidTicket = 1,				// Ticket is not valid.
	k_EBeginAuthSessionResultDuplicateRequest = 2,			// A ticket has already been submitted for this steamID
	k_EBeginAuthSessionResultInvalidVersion = 3,			// Ticket is from an incompatible interface version
	k_EBeginAuthSessionResultGameMismatch = 4,				// Ticket is not for this game
	k_EBeginAuthSessionResultExpiredTicket = 5,				// Ticket has expired
};

// Callback values for callback ValidateAuthTicketResponse_t which is a response to BeginAuthSession
enum EAuthSessionResponse
{
	k_EAuthSessionResponseOK = 0,							// Steam has verified the user is online, the ticket is valid and ticket has not been reused.
	k_EAuthSessionResponseUserNotConnectedToSteam = 1,		// The user in question is not connected to steam
	k_EAuthSessionResponseNoLicenseOrExpired = 2,			// The license has expired.
	k_EAuthSessionResponseVACBanned = 3,					// The user is VAC banned for this game.
	k_EAuthSessionResponseLoggedInElseWhere = 4,			// The user account has logged in elsewhere and the session containing the game instance has been disconnected.
	k_EAuthSessionResponseVACCheckTimedOut = 5,				// VAC has been unable to perform anti-cheat checks on this user
	k_EAuthSessionResponseAuthTicketCanceled = 6,			// The ticket has been canceled by the issuer
	k_EAuthSessionResponseAuthTicketInvalidAlreadyUsed = 7,	// This ticket has already been used, it is not valid.
	k_EAuthSessionResponseAuthTicketInvalid = 8,			// This ticket is not from a user instance currently connected to steam.
	k_EAuthSessionResponsePublisherIssuedBan = 9,			// The user is banned for this game. The ban came via the web api and not VAC
	k_EAuthSessionResponseAuthTicketNetworkIdentityFailure = 10,	// The network identity in the ticket does not match the server authenticating the ticket
};

// results from UserHasLicenseForApp
enum EUserHasLicenseForAppResult
{
	k_EUserHasLicenseResultHasLicense = 0,					// User has a license for specified app
	k_EUserHasLicenseResultDoesNotHaveLicense = 1,			// User does not have a license for the specified app
	k_EUserHasLicenseResultNoAuth = 2,						// User has not been authenticated
};

//
// Specifies a game's online state in relation to duration control
//
enum EDurationControlOnlineState
{
	k_EDurationControlOnlineState_Invalid = 0,				// nil value
	k_EDurationControlOnlineState_Offline = 1,				// currently in offline play - single-player, offline co-op, etc.
	k_EDurationControlOnlineState_Online = 2,				// currently in online play
	k_EDurationControlOnlineState_OnlineHighPri = 3,		// currently in online play and requests not to be interrupted
};


// Error codes for use with the voice functions
enum EVoiceResult
{
	k_EVoiceResultOK = 0,
	k_EVoiceResultNotInitialized = 1,
	k_EVoiceResultNotRecording = 2,
	k_EVoiceResultNoData = 3,
	k_EVoiceResultBufferTooSmall = 4,
	k_EVoiceResultDataCorrupted = 5,
	k_EVoiceResultRestricted = 6,
	k_EVoiceResultUnsupportedCodec = 7,
	k_EVoiceResultReceiverOutOfDate = 8,
	k_EVoiceResultReceiverDidNotAnswer = 9,

};

enum EUIMode
{
	EUIMode_VGUI = 0,
	EUIMode_Tenfoot = 1,
	EUIMode_Mobile = 2,
	EUIMode_Web = 3,
	EUIMode_GamePadUI = 4,
	EUIMode_MobileChat = 5,
	EUIMode_EmbeddedClient = 6,
	EUIMode_DesktopUI = 7,
	EUIMode_MAX = 8,
};

enum ESteamAPICallFailure
{
	ESteamAPICallFailure_None = -1,			// no failure
	ESteamAPICallFailure_SteamGone = 0,		// the local Steam process has gone away
	ESteamAPICallFailure_NetworkFailure = 1,	// the network connection to Steam has been broken, or was already broken
	// SteamServersDisconnected_t callback will be sent around the same time
	// SteamServersConnected_t will be sent when the client is able to talk to the Steam servers again
	ESteamAPICallFailure_InvalidHandle = 2,	// the SteamAPICall_t handle passed in no longer exists
	ESteamAPICallFailure_MismatchedCallback = 3,// GetAPICallResult() was called with the wrong callback type for this API call
};

// Input modes for the Big Picture gamepad text entry
enum EGamepadTextInputMode
{
	k_EGamepadTextInputModeNormal = 0,
	k_EGamepadTextInputModePassword = 1
};

// Controls number of allowed lines for the Big Picture gamepad text entry
enum EGamepadTextInputLineMode
{
	k_EGamepadTextInputLineModeSingleLine = 0,
	k_EGamepadTextInputLineModeMultipleLines = 1
};

// The context where text filtering is being done
enum ETextFilteringContext
{
	k_ETextFilteringContextUnknown = 0,	// Unknown context
	k_ETextFilteringContextGameContent = 1,	// Game content, only legally required filtering is performed
	k_ETextFilteringContextChat = 2,	// Chat from another player
	k_ETextFilteringContextName = 3,	// Character or item name
};

enum ESteamIPv6ConnectivityProtocol
{
	k_ESteamIPv6ConnectivityProtocol_Invalid = 0,
	k_ESteamIPv6ConnectivityProtocol_HTTP = 1,		// because a proxy may make this different than other protocols
	k_ESteamIPv6ConnectivityProtocol_UDP = 2,		// test UDP connectivity. Uses a port that is commonly needed for other Steam stuff. If UDP works, TCP probably works. 
};

// For the above transport protocol, what do we think the local machine's connectivity to the internet over ipv6 is like
enum ESteamIPv6ConnectivityState
{
	k_ESteamIPv6ConnectivityState_Unknown = 0,	// We haven't run a test yet
	k_ESteamIPv6ConnectivityState_Good = 1,		// We have recently been able to make a request on ipv6 for the given protocol
	k_ESteamIPv6ConnectivityState_Bad = 2,		// We failed to make a request, either because this machine has no ipv6 address assigned, or it has no upstream connectivity
};

enum EFloatingGamepadTextInputMode
{
	k_EFloatingGamepadTextInputModeModeSingleLine = 0,		// Enter dismisses the keyboard
	k_EFloatingGamepadTextInputModeModeMultipleLines = 1,	// User needs to explictly close the keyboard
	k_EFloatingGamepadTextInputModeModeEmail = 2,			// Keyboard layout is email, enter dismisses the keyboard
	k_EFloatingGamepadTextInputModeModeNumeric = 3,			// Keyboard layout is numeric, enter dismisses the keyboard
};


enum EUniverse
{
	EUniverse_Invalid = 0,
	EUniverse_Public = 1,
	EUniverse_Beta = 2,
	EUniverse_Internal = 3,
	EUniverse_Dev = 4,
	EUniverse_Max
};

enum ENotificationPosition
{
    ENotificationPosition_TopLeft = 0,
	ENotificationPosition_TopRight = 1,
	ENotificationPosition_BottomLeft = 2,
	ENotificationPosition_BottomRight = 3,
};

enum ELanguage
{
	ELanguage_None = -1,
	ELanguage_English = 0,
	ELanguage_German = 1,
	ELanguage_French = 2,
	ELanguage_Italian = 3,
	ELanguage_Korean = 4,
	ELanguage_Spanish = 5,
	ELanguage_Simplified_Chinese = 6,
	ELanguage_Traditional_Chinese = 7,
	ELanguage_Russian = 8,
	ELanguage_Thai = 9,
	ELanguage_Japanese = 10,
	ELanguage_Portuguese = 11,
	ELanguage_Polish = 12,
	ELanguage_Danish = 13,
	ELanguage_Dutch = 14,
	ELanguage_Finnish = 15,
	ELanguage_Norwegian = 16,
	ELanguage_Swedish = 17,
	ELanguage_Hungarian = 18,
	ELanguage_Czech = 19,
	ELanguage_Romanian = 20,
	ELanguage_Turkish = 21,
	ELanguage_Brazilian = 22,
	ELanguage_Bulgarian = 23,
	ELanguage_Greek = 24,
	ELanguage_Arabic = 25,
	ELanguage_Ukrainian = 26,
	ELanguage_Latam_Spanish = 27,
	ELanguage_Vietnamese = 28,
};

enum EConfigStore
{
	EConfigStore_Invalid = 0,
	EConfigStore_Install = 1,
	EConfigStore_UserRoaming = 2,
	EConfigStore_UserLocal = 3,
	EConfigStore_Max = 4,
};

enum EHTMLMouseButton
{
	EHTMLMouseButton_Left = 0,
	EHTMLMouseButton_Right = 1,
	EHTMLMouseButton_Middle = 2
};

enum EHTMLKeyModifiers : unsigned int
{
	EHTMLKeyModifiers_None = 0,
	EHTMLKeyModifiers_AltDown = 1 << 0,
	EHTMLKeyModifiers_CtrlDown = 1 << 1,
    EHTMLKeyModifiers_ShiftDown = 1 << 2,
};