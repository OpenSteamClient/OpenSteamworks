#pragma once
#include <cstdint>
#include <steam/steamuniverse.h>
// enums.h purpose: All Client API enums. Add new enums at the top. Add public enums in steam/steamenums.h

enum ERegionCode
{
	k_ERegionCodeUSEast = 0x00,
	k_ERegionCodeUSWest = 0x01,
	k_ERegionCodeSouthAmerica = 0x02,
	k_ERegionCodeEurope = 0x03,
	k_ERegionCodeAsia = 0x04,
	k_ERegionCodeAustralia = 0x05,
	k_ERegionCodeMiddleEast = 0x06,
	k_ERegionCodeAfrica = 0x07,
	k_ERegionCodeWorld = 0xFF,
};

enum EPersonaStateFlag {
  k_EPersonaStateFlagHasRichPresence = 1,
  k_EPersonaStateFlagInJoinableGame = 2,
  k_EPersonaStateFlagGolden = 4,
  k_EPersonaStateFlagRemotePlayTogether = 8,
  k_EPersonaStateFlagClientTypeWeb = 256,
  k_EPersonaStateFlagClientTypeMobile = 512,
  k_EPersonaStateFlagClientTypeTenfoot = 1024,
  k_EPersonaStateFlagClientTypeVR = 2048,
  k_EPersonaStateFlagLaunchTypeGamepad = 4096,
  k_EPersonaStateFlagLaunchTypeCompatTool = 8192
};

enum EFileRemoteStorageSyncState
{
	//TODO
};

enum ERemoteStorageSyncState
{
    k_ERemoteStorageSyncStateDisabled,
    k_ERemoteStorageSyncStateUnknown,
    k_ERemoteStorageSyncStateSynchronized,
    k_ERemoteStorageSyncStateInProgress,
    k_ERemoteStorageSyncStateChangesInCloud,
    k_ERemoteStorageSyncStateChangesLocally,
    k_ERemoteStorageSyncStateChangesInCloudAndLocally,
    k_ERemoteStorageSyncStateConflictingChanges,
    k_ERemoteStorageSyncStateNotInitialized
};

enum EUCMListType : uint8_t
{
	k_EUCMListTypeSubscribed = 1,
	k_EUCMListTypeFavorites = 2,
	k_EUCMListTypePlayed = 3,
	k_EUCMListTypeCompleted = 4,
	k_EUCMListTypeShortcutFavorites = 5,
	k_EUCMListTypeFollowed = 6
};

enum EPublishedFileInfoMatchingFileType
{
	k_PFI_MatchingFileType_Items = 0,
	k_PFI_MatchingFileType_Collections = 1,
	k_PFI_MatchingFileType_Art = 2,
	k_PFI_MatchingFileType_Videos = 3,
	k_PFI_MatchingFileType_Screenshots = 4,
	k_PFI_MatchingFileType_CollectionEligible = 5,
	k_PFI_MatchingFileType_Games = 6,
	k_PFI_MatchingFileType_Software = 7,
	k_PFI_MatchingFileType_Concepts = 8,
	k_PFI_MatchingFileType_GreenlightItems = 9,
	k_PFI_MatchingFileType_Guides = 10,
	k_PFI_MatchingFileType_WebGuides = 11,
	k_PFI_MatchingFileType_IntegratedGuides = 12,
	k_PFI_MatchingFileType_UsableInGame = 13,
	k_PFI_MatchingFileType_Merch = 14,
	k_PFI_MatchingFileType_ControllerBindings = 15,
	k_PFI_MatchingFileType_SteamworksAccessInvites = 16,
	k_PFI_MatchingFileType_Microtransaction = 17,
	k_PFI_MatchingFileType_ReadyToUse = 18,
	k_PFI_MatchingFileType_WorkshopShowcase = 19,
	k_PFI_MatchingFileType_GameManagedItems = 20,
};

enum ERemoteStorageFileRoot
{
    k_ERemoteStorageFileRootInvalid = -1, // Invalid
    k_ERemoteStorageFileRootDefault, // Default
    k_ERemoteStorageFileRootGameInstall, // GameInstall
    k_ERemoteStorageFileRootWinMyDocuments, // WinMyDocuments
    k_ERemoteStorageFileRootWinAppDataLocal, // WinAppDataLocal
    k_ERemoteStorageFileRootWinAppDataRoaming, // WinAppDataRoaming
    k_ERemoteStorageFileRootSteamUserBaseStorage, // SteamUserBaseStorage
    k_ERemoteStorageFileRootMacHome, // MacHome
    k_ERemoteStorageFileRootMacAppSupport, // MacAppSupport
    k_ERemoteStorageFileRootMacDocuments, // MacDocuments
    k_ERemoteStorageFileRootWinSavedGames, // WinSavedGames
    k_ERemoteStorageFileRootWinProgramData, // WinProgramData
    k_ERemoteStorageFileRootSteamCloudDocuments, // SteamCloudDocuments
    k_ERemoteStorageFileRootWinAppDataLocalLow, // WinAppDataLocalLow
    k_ERemoteStorageFileRootMacCaches, // MacCaches
    k_ERemoteStorageFileRootLinuxHome, // LinuxHome
    k_ERemoteStorageFileRootLinuxXdgDataHome, // LinuxXdgDataHome
    k_ERemoteStorageFileRootLinuxXdgConfigHome, // LinuxXdgConfigHome
    k_ERemoteStorageFileRootAndroidSteamPackageRoot, // AndroidSteamPackageRoot
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