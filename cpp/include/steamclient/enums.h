#pragma once
#include <stdint.h>
// enums.h purpose: All Client API enums. Add new enums at the top.


// used in PersonaStateChange_t::m_nChangeFlags to describe what's changed about a user
// these flags describe what the client has learned has changed recently, so on startup you'll see a name, avatar & relationship change for every friend
enum EPersonaChange
{
	k_EPersonaChangeName		= 0x0001,
	k_EPersonaChangeStatus		= 0x0002,
	k_EPersonaChangeComeOnline	= 0x0004,
	k_EPersonaChangeGoneOffline	= 0x0008,
	k_EPersonaChangeGamePlayed	= 0x0010,
	k_EPersonaChangeGameServer	= 0x0020,
	k_EPersonaChangeAvatar		= 0x0040,
	k_EPersonaChangeJoinedSource= 0x0080,
	k_EPersonaChangeLeftSource	= 0x0100,
	k_EPersonaChangeRelationshipChanged = 0x0200,
	k_EPersonaChangeNameFirstSet = 0x0400,
	k_EPersonaChangeBroadcast = 0x0800,
	k_EPersonaChangeNickname =	0x1000,
	k_EPersonaChangeSteamLevel = 0x2000,
	k_EPersonaChangeRichPresence = 0x4000,
};

enum EChatEntryType
{
	k_EChatEntryTypeInvalid = 0, 
	k_EChatEntryTypeChatMsg = 1,			// Normal text message from another user
	k_EChatEntryTypeTyping = 2,				// Another user is typing (not used in multi-user chat)
	k_EChatEntryTypeInviteGame = 3,			// Invite from other user into that users current game
	k_EChatEntryTypeEmote = 4,				// text emote message (deprecated, should be treated as ChatMsg)
	//k_EChatEntryTypeLobbyGameStart = 5,	// lobby game is starting (dead - listen for LobbyGameCreated_t callback instead)
	k_EChatEntryTypeLeftConversation = 6,   // user has left the conversation ( closed chat window )
	// Above are previous FriendMsgType entries, now merged into more generic chat entry types
	k_EChatEntryTypeEntered = 7,			// user has entered the conversation (used in multi-user chat and group chat)
	k_EChatEntryTypeWasKicked = 8,			// user was kicked (data: 64-bit steamid of actor performing the kick)
	k_EChatEntryTypeWasBanned = 9,			// user was banned (data: 64-bit steamid of actor performing the ban)
	k_EChatEntryTypeDisconnected = 10,		// user disconnected
	k_EChatEntryTypeHistoricalChat = 11,	// a chat message from user's chat history or offilne message
	//k_EChatEntryTypeReserved1 = 12, 		// No longer used
	//k_EChatEntryTypeReserved2 = 13, 		// No longer used
	k_EChatEntryTypeLinkBlocked = 14, 		// a link was removed by the chat filter.
};

// These values are passed as parameters to the store
enum EOverlayToStoreFlag
{
	k_EOverlayToStoreFlag_None = 0,
	k_EOverlayToStoreFlag_AddToCart = 1,
	k_EOverlayToStoreFlag_AddToCartAndShow = 2,
};


//-----------------------------------------------------------------------------
// Purpose: Tells Steam where to place the browser window inside the overlay
//-----------------------------------------------------------------------------
enum EActivateGameOverlayToWebPageMode
{
	k_EActivateGameOverlayToWebPageMode_Default = 0,		// Browser will open next to all other windows that the user has open in the overlay.
															// The window will remain open, even if the user closes then re-opens the overlay.

	k_EActivateGameOverlayToWebPageMode_Modal = 1			// Browser will be opened in a special overlay configuration which hides all other windows
															// that the user has open in the overlay. When the user closes the overlay, the browser window
															// will also close. When the user closes the browser window, the overlay will automatically close.
};

//-----------------------------------------------------------------------------
// Purpose: See GetProfileItemPropertyString and GetProfileItemPropertyUint
//-----------------------------------------------------------------------------
enum ECommunityProfileItemType
{
	k_ECommunityProfileItemType_AnimatedAvatar		 = 0,
	k_ECommunityProfileItemType_AvatarFrame			 = 1,
	k_ECommunityProfileItemType_ProfileModifier		 = 2,
	k_ECommunityProfileItemType_ProfileBackground	 = 3,
	k_ECommunityProfileItemType_MiniProfileBackground = 4,
};
enum ECommunityProfileItemProperty
{
	k_ECommunityProfileItemProperty_ImageSmall	   = 0, // string
	k_ECommunityProfileItemProperty_ImageLarge	   = 1, // string
	k_ECommunityProfileItemProperty_InternalName   = 2, // string
	k_ECommunityProfileItemProperty_Title		   = 3, // string
	k_ECommunityProfileItemProperty_Description	   = 4, // string
	k_ECommunityProfileItemProperty_AppID		   = 5, // uint32
	k_ECommunityProfileItemProperty_TypeID		   = 6, // uint32
	k_ECommunityProfileItemProperty_Class		   = 7, // uint32
	k_ECommunityProfileItemProperty_MovieWebM	   = 8, // string
	k_ECommunityProfileItemProperty_MovieMP4	   = 9, // string
	k_ECommunityProfileItemProperty_MovieWebMSmall = 10, // string
	k_ECommunityProfileItemProperty_MovieMP4Small  = 11, // string
};

//-----------------------------------------------------------------------------
// Purpose: user restriction flags
//-----------------------------------------------------------------------------
enum EUserRestriction
{
	k_nUserRestrictionNone		= 0,	// no known chat/content restriction
	k_nUserRestrictionUnknown	= 1,	// we don't know yet (user offline)
	k_nUserRestrictionAnyChat	= 2,	// user is not allowed to (or can't) send/recv any chat
	k_nUserRestrictionVoiceChat	= 4,	// user is not allowed to (or can't) send/recv voice chat
	k_nUserRestrictionGroupChat	= 8,	// user is not allowed to (or can't) send/recv group chat
	k_nUserRestrictionRating	= 16,	// user is too young according to rating in current region
	k_nUserRestrictionGameInvites	= 32,	// user cannot send or recv game invites (e.g. mobile)
	k_nUserRestrictionTrading	= 64,	// user cannot participate in trading (console, mobile)
};

// connection progress indicators, used by CreateP2PConnectionSocket()
enum ESNetSocketState
{
	k_ESNetSocketStateInvalid = 0,						

	// communication is valid
	k_ESNetSocketStateConnected = 1,				
	
	// states while establishing a connection
	k_ESNetSocketStateInitiated = 10,				// the connection state machine has started

	// p2p connections
	k_ESNetSocketStateLocalCandidatesFound = 11,	// we've found our local IP info
	k_ESNetSocketStateReceivedRemoteCandidates = 12,// we've received information from the remote machine, via the Steam back-end, about their IP info

	// direct connections
	k_ESNetSocketStateChallengeHandshake = 15,		// we've received a challenge packet from the server

	// failure states
	k_ESNetSocketStateDisconnecting = 21,			// the API shut it down, and we're in the process of telling the other end	
	k_ESNetSocketStateLocalDisconnect = 22,			// the API shut it down, and we've completed shutdown
	k_ESNetSocketStateTimeoutDuringConnect = 23,	// we timed out while trying to creating the connection
	k_ESNetSocketStateRemoteEndDisconnected = 24,	// the remote end has disconnected from us
	k_ESNetSocketStateConnectionBroken = 25,		// connection has been broken; either the other end has disappeared or our local network connection has broke

};

// describes how the socket is currently connected
enum ESNetSocketConnectionType
{
	k_ESNetSocketConnectionTypeNotConnected = 0,
	k_ESNetSocketConnectionTypeUDP = 1,
	k_ESNetSocketConnectionTypeUDPRelay = 2,
};

// list of possible errors returned by SendP2PPacket() API
// these will be posted in the P2PSessionConnectFail_t callback
enum EP2PSessionError
{
	k_EP2PSessionErrorNone = 0,
	k_EP2PSessionErrorNotRunningApp = 1,			// target is not running the same game
	k_EP2PSessionErrorNoRightsToApp = 2,			// local user doesn't own the app that is running
	k_EP2PSessionErrorDestinationNotLoggedIn = 3,	// target user isn't connected to Steam
	k_EP2PSessionErrorTimeout = 4,					// target isn't responding, perhaps not calling AcceptP2PSessionWithUser()
													// corporate firewalls can also block this (NAT traversal is not firewall traversal)
													// make sure that UDP ports 3478, 4379, and 4380 are open in an outbound direction
	k_EP2PSessionErrorMax = 5
};

// SendP2PPacket() send types
// Typically k_EP2PSendUnreliable is what you want for UDP-like packets, k_EP2PSendReliable for TCP-like packets
enum EP2PSend
{
	// Basic UDP send. Packets can't be bigger than 1200 bytes (your typical MTU size). Can be lost, or arrive out of order (rare).
	// The sending API does have some knowledge of the underlying connection, so if there is no NAT-traversal accomplished or
	// there is a recognized adjustment happening on the connection, the packet will be batched until the connection is open again.
	k_EP2PSendUnreliable = 0,

	// As above, but if the underlying p2p connection isn't yet established the packet will just be thrown away. Using this on the first
	// packet sent to a remote host almost guarantees the packet will be dropped.
	// This is only really useful for kinds of data that should never buffer up, i.e. voice payload packets
	k_EP2PSendUnreliableNoDelay = 1,

	// Reliable message send. Can send up to 1MB of data in a single message. 
	// Does fragmentation/re-assembly of messages under the hood, as well as a sliding window for efficient sends of large chunks of data. 
	k_EP2PSendReliable = 2,

	// As above, but applies the Nagle algorithm to the send - sends will accumulate 
	// until the current MTU size (typically ~1200 bytes, but can change) or ~200ms has passed (Nagle algorithm). 
	// Useful if you want to send a set of smaller messages but have the coalesced into a single packet
	// Since the reliable stream is all ordered, you can do several small message sends with k_EP2PSendReliableWithBuffering and then
	// do a normal k_EP2PSendReliable to force all the buffered data to be sent.
	k_EP2PSendReliableWithBuffering = 3,
};

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

enum ERemoteStorageSyncFlags : uint64_t
{
	k_ERemoteStorageSyncFlagsNoFlags = 0,
	k_ERemoteStorageSyncFlagsIgnorePending = 1,
	k_ERemoteStorageSyncFlagsAutoCloud_Launch = 2,
	k_ERemoteStorageSyncFlagsAutoCloud_Exit = 4,
};

enum ERemoteStorageSyncType
{
	k_ERemoteStorageSyncTypeDown = 1,
	k_ERemoteStorageSyncTypeUp = 2
};

enum EResult
{
	k_EResultOK = 1,		   // success
	k_EResultFail = 2,		   // generic failure
	k_EResultNoConnection = 3, // no/failed network connection
	//	k_EResultNoConnectionRetry = 4,						// OBSOLETE - removed
	k_EResultInvalidPassword = 5,						   // password/ticket is invalid
	k_EResultLoggedInElsewhere = 6,						   // same user logged in elsewhere
	k_EResultInvalidProtocolVer = 7,					   // protocol version is incorrect
	k_EResultInvalidParam = 8,							   // a parameter is incorrect
	k_EResultFileNotFound = 9,							   // file was not found
	k_EResultBusy = 10,									   // called method busy - action not taken
	k_EResultInvalidState = 11,							   // called object was in an invalid state
	k_EResultInvalidName = 12,							   // name is invalid
	k_EResultInvalidEmail = 13,							   // email is invalid
	k_EResultDuplicateName = 14,						   // name is not unique
	k_EResultAccessDenied = 15,							   // access is denied
	k_EResultTimeout = 16,								   // operation timed out
	k_EResultBanned = 17,								   // VAC2 banned
	k_EResultAccountNotFound = 18,						   // account not found
	k_EResultInvalidSteamID = 19,						   // steamID is invalid
	k_EResultServiceUnavailable = 20,					   // The requested service is currently unavailable
	k_EResultNotLoggedOn = 21,							   // The user is not logged on
	k_EResultPending = 22,								   // Request is pending (may be in process, or waiting on third party)
	k_EResultEncryptionFailure = 23,					   // Encryption or Decryption failed
	k_EResultInsufficientPrivilege = 24,				   // Insufficient privilege
	k_EResultLimitExceeded = 25,						   // Too much of a good thing
	k_EResultRevoked = 26,								   // Access has been revoked (used for revoked guest passes)
	k_EResultExpired = 27,								   // License/Guest pass the user is trying to access is expired
	k_EResultAlreadyRedeemed = 28,						   // Guest pass has already been redeemed by account, cannot be acked again
	k_EResultDuplicateRequest = 29,						   // The request is a duplicate and the action has already occurred in the past, ignored this time
	k_EResultAlreadyOwned = 30,							   // All the games in this guest pass redemption request are already owned by the user
	k_EResultIPNotFound = 31,							   // IP address not found
	k_EResultPersistFailed = 32,						   // failed to write change to the data store
	k_EResultLockingFailed = 33,						   // failed to acquire access lock for this operation
	k_EResultLogonSessionReplaced = 34,					   // The logon session has been replaced.
	k_EResultConnectFailed = 35,						   // Failed to connect.
	k_EResultHandshakeFailed = 36,						   // The authentication handshake has failed.
	k_EResultIOFailure = 37,							   // There has been a genic IO failure.
	k_EResultRemoteDisconnect = 38,						   // The remote server has disconnected.
	k_EResultShoppingCartNotFound = 39,					   // failed to find the shopping cart requested
	k_EResultBlocked = 40,								   // a user didn't allow it
	k_EResultIgnored = 41,								   // target is ignoring sender
	k_EResultNoMatch = 42,								   // nothing matching the request found
	k_EResultAccountDisabled = 43,						   // The account is disabled.
	k_EResultServiceReadOnly = 44,						   // this service is not accepting content changes right now
	k_EResultAccountNotFeatured = 45,					   // account doesn't have value, so this feature isn't available
	k_EResultAdministratorOK = 46,						   // allowed to take this action, but only because requester is admin
	k_EResultContentVersion = 47,						   // A Version mismatch in content transmitted within the Steam protocol.
	k_EResultTryAnotherCM = 48,							   // The current CM can't service the user making a request, user should try another.
	k_EResultPasswordRequiredToKickSession = 49,		   // You are already logged in elsewhere, this cached credential login has failed.
	k_EResultAlreadyLoggedInElsewhere = 50,				   // You are already logged in elsewhere, you must wait
	k_EResultSuspended = 51,							   // Long running operation (content download) suspended/paused
	k_EResultCancelled = 52,							   // Operation canceled (typically by user: content download)
	k_EResultDataCorruption = 53,						   // Operation canceled because data is ill formed or unrecoverable
	k_EResultDiskFull = 54,								   // Operation canceled - not enough disk space.
	k_EResultRemoteCallFailed = 55,						   // an remote call or IPC call failed
	k_EResultPasswordUnset = 56,						   // Password could not be verified as it's unset server side
	k_EResultPSNAccountUnlinked = 57,					   // Attempt to logon from a PS3 failed because the PSN online id is not linked to a Steam account
	k_EResultPSNTicketInvalid = 58,						   // PSN ticket was invalid
	k_EResultPSNAccountAlreadyLinked = 59,				   // PSN account is already linked to some other account, must explicitly request to replace/delete the link first
	k_EResultRemoteFileConflict = 60,					   // The sync cannot resume due to a conflict between the local and remote files
	k_EResultIllegalPassword = 61,						   // The requested new password is not legal
	k_EResultSameAsPreviousValue = 62,					   // new value is the same as the old one ( secret question and answer )
	k_EResultAccountLogonDenied = 63,					   // account login denied due to 2nd factor authentication failure
	k_EResultCannotUseOldPassword = 64,					   // The requested new password is not legal
	k_EResultInvalidLoginAuthCode = 65,					   // account login denied due to auth code invalid
	k_EResultAccountLogonDeniedNoMail = 66,				   // account login denied due to 2nd factor auth failure - and no mail has been sent
	k_EResultHardwareNotCapableOfIPT = 67,				   // The users hardware does not support Intel's Identity Protection Technology (IPT).
	k_EResultIPTInitError = 68,							   // Intel's Identity Protection Technology (IPT) has failed to initialize.
	k_EResultParentalControlRestrictions = 69,			   // Operation failed due to parental control restrictions for current user
	k_EResultFacebookQueryError = 70,					   // Facebook query returned an error
	k_EResultExpiredLoginAuthCode = 71,					   // Expired Login Auth Code
	k_EResultIPLoginRestrictionFailed = 72,				   // IP Login Restriction Failed
	k_EResultAccountLockedDown = 73,					   // Account Locked Down
	k_EResultAccountLogonDeniedVerifiedEmailRequired = 74, // Account Logon Denied Verified Email Required
	k_EResultNoMatchingURL = 75,						   // No matching URL
	k_EResultBadResponse = 76,							   // parse failure, missing field, etc.
	k_EResultRequirePasswordReEntry = 77,				   // The user cannot complete the action until they re-enter their password
	k_EResultValueOutOfRange = 78,						   // the value entered is outside the acceptable range
	k_EResultUnexpectedError = 79,						   // Something happened that we didn't expect to ever happen.
	k_EResultDisabled = 80,								   // The requested service has been configured to be unavailable.
	k_EResultInvalidCEGSubmission = 81,					   // The files submitted to the CEG server are not valid.
	k_EResultRestrictedDevice = 82,						   // The device being used is not allowed to perform this action.
	k_EResultRegionLocked = 83,							   // The action could not be complete because it is region restricted.
	k_EResultRateLimitExceeded = 84,					   // Temporary rate limit exceeded, try again later, different from k_EResultLimitExceeded which may be permanent.
	k_EResultAccountLoginDeniedNeedTwoFactor = 85,		   // Need two-factor code to login
	k_EResultItemDeleted = 86,							   // The thing we're trying to access has been deleted
	k_EResultAccountLoginDeniedThrottle = 87,			   // login attempt failed, try to throttle response to possible attacker
	k_EResultTwoFactorCodeMismatch = 88,				   // two factor code mismatch
	k_EResultTwoFactorActivationCodeMismatch = 89,		   // activation code for two-factor didn't match
	k_EResultAccountAssociatedToMultiplePartners = 90,	   // account has been associated with multiple partners
	k_EResultNotModified = 91,							   // data not modified
	k_EResultNoMobileDevice = 92,						   // the account does not have a mobile device associated with it
	k_EResultTimeNotSynced = 93,						   // the time presented is out of range or tolerance
	k_EResultSmsCodeFailed = 94,						   // SMS code failure (no match, none pending, etc.)
	k_EResultAccountLimitExceeded = 95,					   // Too many accounts access this resource
	k_EResultAccountActivityLimitExceeded = 96,			   // Too many changes to this account
	k_EResultPhoneActivityLimitExceeded = 97,			   // Too many changes to this phone
	k_EResultRefundToWallet = 98,						   // Cannot refund to payment method, must use wallet
	k_EResultEmailSendFailure = 99,						   // Cannot send an email
	k_EResultNotSettled = 100,							   // Can't perform operation till payment has settled
	k_EResultNeedCaptcha = 101,							   // The user needs to provide a valid captcha.
	k_EResultGSLTDenied = 102,							   // A game server login token owned by this token's owner has been banned.
	k_EResultGSOwnerDenied = 103,						   // Game server owner is denied for some other reason such as account locked, community ban, vac ban, missing phone, etc.
	k_EResultInvalidItemType = 104,						   // The type of thing we were requested to act on is invalid.
	k_EResultIPBanned = 105,							   // The IP address has been banned from taking this action.
	k_EResultGSLTExpired = 106,							   // This Game Server Login Token (GSLT) has expired from disuse; it can be reset for use.
	k_EResultInsufficientFunds = 107,					   // user doesn't have enough wallet funds to complete the action
	k_EResultTooManyPending = 108,						   // There are too many of this thing pending already

	// Not yet documented EResults
	k_EResultNoSiteLicensesFound = 109,						 //
	k_EResultNetworkSendExceeded = 110,						 //
	k_EResultAccountsNotFriends = 111,						 //
	k_EResultLimitedUserAccount = 112,						 //
	k_EResultCantRemoveItem = 113,							 // Cant remove item
	k_EResultAccountHasBeenDeleted = 114,					 // Account has been deleted
	k_EResultAccountHasAnExistingUserCancelledLicense = 115, // Account has an existing user cancelled license
	k_EResultDeniedDueToCommunityCooldown = 116,			 // Denied due to community cooldown
	k_EResultNoLauncherSpecified = 117,						 // No launcher specified
	k_EResultMustAgreeToSSA = 118,							 // Must agree to SSA
	k_EResultClientNoLongerSupported = 119,					 // Client no longer supported
	k_EResultSteamRealmMismatch = 120,						 // The current Steam realm does not match the requested resource
	k_EResultSignatureCheckFailed = 121,
	k_EResultFailedToParseInput = 122,
	k_EResultNoVerifiedPhoneNumber = 123,
	k_EResultInsufficientBatteryCharge = 124,
	k_EResultChargerRequired = 125,
	k_EResultCachedCredentialIsInvalid = 126,
	k_EResultPhoneNumberIsVoiceOverIP = 127,
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

enum EWorkshopFileType
{
	k_EWorkshopFileTypeFirst = 0,

	k_EWorkshopFileTypeCommunity			  = 0,		// normal Workshop item that can be subscribed to
	k_EWorkshopFileTypeMicrotransaction		  = 1,		// Workshop item that is meant to be voted on for the purpose of selling in-game
	k_EWorkshopFileTypeCollection			  = 2,		// a collection of Workshop or Greenlight items
	k_EWorkshopFileTypeArt					  = 3,		// artwork
	k_EWorkshopFileTypeVideo				  = 4,		// external video
	k_EWorkshopFileTypeScreenshot			  = 5,		// screenshot
	k_EWorkshopFileTypeGame					  = 6,		// Greenlight game entry
	k_EWorkshopFileTypeSoftware				  = 7,		// Greenlight software entry
	k_EWorkshopFileTypeConcept				  = 8,		// Greenlight concept
	k_EWorkshopFileTypeWebGuide				  = 9,		// Steam web guide
	k_EWorkshopFileTypeIntegratedGuide		  = 10,		// application integrated guide
	k_EWorkshopFileTypeMerch				  = 11,		// Workshop merchandise meant to be voted on for the purpose of being sold
	k_EWorkshopFileTypeControllerBinding	  = 12,		// Steam Controller bindings
	k_EWorkshopFileTypeSteamworksAccessInvite = 13,		// internal
	k_EWorkshopFileTypeSteamVideo			  = 14,		// Steam video
	k_EWorkshopFileTypeGameManagedItem		  = 15,		// managed completely by the game, not the user, and not shown on the web

	// Update k_EWorkshopFileTypeMax if you add values.
	k_EWorkshopFileTypeMax = 16
	
};

enum EWorkshopFileAction
{
	k_EWorkshopFileActionPlayed = 0,
	k_EWorkshopFileActionCompleted = 1,
};

enum EWorkshopEnumerationType
{
	k_EWorkshopEnumerationTypeRankedByVote = 0,
	k_EWorkshopEnumerationTypeRecent = 1,
	k_EWorkshopEnumerationTypeTrending = 2,
	k_EWorkshopEnumerationTypeFavoritesOfFriends = 3,
	k_EWorkshopEnumerationTypeVotedByFriends = 4,
	k_EWorkshopEnumerationTypeContentByFriends = 5,
	k_EWorkshopEnumerationTypeRecentFromFollowedUsers = 6,
};

enum EWorkshopVideoProvider
{
	k_EWorkshopVideoProviderNone = 0,
	k_EWorkshopVideoProviderYoutube = 1
};


enum EUGCReadAction
{
	// Keeps the file handle open unless the last byte is read.  You can use this when reading large files (over 100MB) in sequential chunks.
	// If the last byte is read, this will behave the same as k_EUGCRead_Close.  Otherwise, it behaves the same as k_EUGCRead_ContinueReading.
	// This value maintains the same behavior as before the EUGCReadAction parameter was introduced.
	k_EUGCRead_ContinueReadingUntilFinished = 0,

	// Keeps the file handle open.  Use this when using UGCRead to seek to different parts of the file.
	// When you are done seeking around the file, make a final call with k_EUGCRead_Close to close it.
	k_EUGCRead_ContinueReading = 1,

	// Frees the file handle.  Use this when you're done reading the content.  
	// To read the file from Steam again you will need to call UGCDownload again. 
	k_EUGCRead_Close = 2,	
};

enum ERemoteStorageLocalFileChange
{
	k_ERemoteStorageLocalFileChange_Invalid = 0,

	// The file was updated from another device
	k_ERemoteStorageLocalFileChange_FileUpdated = 1,

	// The file was deleted by another device
	k_ERemoteStorageLocalFileChange_FileDeleted = 2,
};

enum ERemoteStorageFilePathType
{
	k_ERemoteStorageFilePathType_Invalid = 0,
	
	// The file is directly accessed by the game and this is the full path
	k_ERemoteStorageFilePathType_Absolute = 1,

	// The file is accessed via the ISteamRemoteStorage API and this is the filename
	k_ERemoteStorageFilePathType_APIFilename = 2,
};

enum ERemoteStoragePlatform
{
	k_ERemoteStoragePlatformNone		= 0,
	k_ERemoteStoragePlatformWindows		= (1 << 0),
	k_ERemoteStoragePlatformOSX			= (1 << 1),
	k_ERemoteStoragePlatformPS3			= (1 << 2),
	k_ERemoteStoragePlatformLinux		= (1 << 3),
	k_ERemoteStoragePlatformSwitch		= (1 << 4),
	k_ERemoteStoragePlatformAndroid		= (1 << 5),
	k_ERemoteStoragePlatformIOS			= (1 << 6),
	// NB we get one more before we need to widen some things

	k_ERemoteStoragePlatformAll = 0xffffffff
};

enum ERemoteStoragePublishedFileVisibility
{
	k_ERemoteStoragePublishedFileVisibilityPublic = 0,
	k_ERemoteStoragePublishedFileVisibilityFriendsOnly = 1,
	k_ERemoteStoragePublishedFileVisibilityPrivate = 2,
	k_ERemoteStoragePublishedFileVisibilityUnlisted = 3,
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