#pragma once
#include <stdint.h>

enum EHTTPMethod
{
	k_EHTTPMethodINVALID, // INVALID
	k_EHTTPMethodGET, // GET
	k_EHTTPMethodHEAD, // HEAD
	k_EHTTPMethodPOST, // POST
	k_EHTTPMethodPUT, // PUT
	k_EHTTPMethodDELETE, // DELETE
	k_EHTTPMethodOPTIONS, // OPTIONS
	k_EHTTPMethodPATCH, // PATCH
};

enum EHTTPStatusCode
{
    k_EHTTPStatusCodeInvalid, // Invalid
    k_EHTTPStatusCodeContinue = 100, // Continue
    k_EHTTPStatusCodeSwitchingProtocols, // Switching Protocols
    k_EHTTPStatusCodeOK = 200, // OK
    k_EHTTPStatusCodeCreated, // Created
    k_EHTTPStatusCodeAccepted, // Accepted
    k_EHTTPStatusCodeNonAuthoritativeInformation, // Non-Authoritative Information
    k_EHTTPStatusCodeNoContent, // No Content
    k_EHTTPStatusCodeResetContent, // Reset Content
    k_EHTTPStatusCodePartialContent, // Partial Content
    k_EHTTPStatusCodeMultipleChoices = 300, // Multiple Choices
    k_EHTTPStatusCodeMovedPermanently, // Moved Permanently
    k_EHTTPStatusCodeFound, // Found
    k_EHTTPStatusCodeSeeOther, // See Other
    k_EHTTPStatusCodeNotModified, // Not Modified
    k_EHTTPStatusCodeUseProxy, // Use Proxy
    k_EHTTPStatusCodeTemporaryRedirect = 307, // Temporary Redirect
    k_EHTTPStatusCodeBadRequest = 400, // Bad Request
    k_EHTTPStatusCodeUnauthorized, // Unauthorized
    k_EHTTPStatusCodePaymentRequired, // Payment Required
    k_EHTTPStatusCodeForbidden, // Forbidden
    k_EHTTPStatusCodeNotFound, // Not Found
    k_EHTTPStatusCodeMethodNotAllowed, // Method Not Allowed
    k_EHTTPStatusCodeNotAcceptable, // Not Acceptable
    k_EHTTPStatusCodeProxyAuthenticationRequired, // Proxy Authentication Required
    k_EHTTPStatusCodeRequestTimeout, // Request Timeout
    k_EHTTPStatusCodeConflict, // Conflict
    k_EHTTPStatusCodeGone, // Gone
    k_EHTTPStatusCodeLengthRequired, // Length Required
    k_EHTTPStatusCodePreconditionFailed, // Precondition Failed
    k_EHTTPStatusCodeRequestEntityTooLarge, // Request Entity Too Large
    k_EHTTPStatusCodeRequestURITooLarge, // Request-URI Too Large
    k_EHTTPStatusCodeUnsupportedMediaType, // Unsupported Media Type
    k_EHTTPStatusCodeRequestedRangeNotSatisfiable, // Requested range not satisfiable
    k_EHTTPStatusCodeExpectationFailed, // Expectation Failed
    k_EHTTPStatusCodeUnknownHTTP4xx, // Unknown HTTP 4xx
    k_EHTTPStatusCodeTooManyRequests = 429, // Too Many Requests
    k_EHTTPStatusCodeConnectionClosed = 444, // Connection closed
    k_EHTTPStatusCodeInternalServerError = 500, // Internal Server Error
    k_EHTTPStatusCodeNotImplemented, // Not Implemented
    k_EHTTPStatusCodeBadGateway, // Bad Gateway
    k_EHTTPStatusCodeServiceUnavailable, // Service Unavailable
    k_EHTTPStatusCodeGatewayTimeout, // Gateway Time-out
    k_EHTTPStatusCodeHTTPVersionNotSupported, // HTTP Version not supported
    k_EHTTPStatusCodeUnknownHTTP5xx = 599, // Unknown HTTP 5xx
};

//-----------------------------------------------------------------------------
// Purpose: The form factor of a device
//-----------------------------------------------------------------------------
enum ESteamDeviceFormFactor
{
	k_ESteamDeviceFormFactorUnknown		= 0,
	k_ESteamDeviceFormFactorPhone		= 1,
	k_ESteamDeviceFormFactorTablet		= 2,
	k_ESteamDeviceFormFactorComputer	= 3,
	k_ESteamDeviceFormFactorTV			= 4,
};

// Matching UGC types for queries
enum EUGCMatchingUGCType
{
	k_EUGCMatchingUGCType_Items				 = 0,		// both mtx items and ready-to-use items
	k_EUGCMatchingUGCType_Items_Mtx			 = 1,
	k_EUGCMatchingUGCType_Items_ReadyToUse	 = 2,
	k_EUGCMatchingUGCType_Collections		 = 3,
	k_EUGCMatchingUGCType_Artwork			 = 4,
	k_EUGCMatchingUGCType_Videos			 = 5,
	k_EUGCMatchingUGCType_Screenshots		 = 6,
	k_EUGCMatchingUGCType_AllGuides			 = 7,		// both web guides and integrated guides
	k_EUGCMatchingUGCType_WebGuides			 = 8,
	k_EUGCMatchingUGCType_IntegratedGuides	 = 9,
	k_EUGCMatchingUGCType_UsableInGame		 = 10,		// ready-to-use items and integrated guides
	k_EUGCMatchingUGCType_ControllerBindings = 11,
	k_EUGCMatchingUGCType_GameManagedItems	 = 12,		// game managed items (not managed by users)
	k_EUGCMatchingUGCType_All				 = ~0,		// @note: will only be valid for CreateQueryUserUGCRequest requests
};

// Different lists of published UGC for a user.
// If the current logged in user is different than the specified user, then some options may not be allowed.
enum EUserUGCList
{
	k_EUserUGCList_Published,
	k_EUserUGCList_VotedOn,
	k_EUserUGCList_VotedUp,
	k_EUserUGCList_VotedDown,
	k_EUserUGCList_WillVoteLater,
	k_EUserUGCList_Favorited,
	k_EUserUGCList_Subscribed,
	k_EUserUGCList_UsedOrPlayed,
	k_EUserUGCList_Followed,
};

// Sort order for user published UGC lists (defaults to creation order descending)
enum EUserUGCListSortOrder
{
	k_EUserUGCListSortOrder_CreationOrderDesc,
	k_EUserUGCListSortOrder_CreationOrderAsc,
	k_EUserUGCListSortOrder_TitleAsc,
	k_EUserUGCListSortOrder_LastUpdatedDesc,
	k_EUserUGCListSortOrder_SubscriptionDateDesc,
	k_EUserUGCListSortOrder_VoteScoreDesc,
	k_EUserUGCListSortOrder_ForModeration,
};

// Combination of sorting and filtering for queries across all UGC
enum EUGCQuery
{
	k_EUGCQuery_RankedByVote								  = 0,
	k_EUGCQuery_RankedByPublicationDate						  = 1,
	k_EUGCQuery_AcceptedForGameRankedByAcceptanceDate		  = 2,
	k_EUGCQuery_RankedByTrend								  = 3,
	k_EUGCQuery_FavoritedByFriendsRankedByPublicationDate	  = 4,
	k_EUGCQuery_CreatedByFriendsRankedByPublicationDate		  = 5,
	k_EUGCQuery_RankedByNumTimesReported					  = 6,
	k_EUGCQuery_CreatedByFollowedUsersRankedByPublicationDate = 7,
	k_EUGCQuery_NotYetRated									  = 8,
	k_EUGCQuery_RankedByTotalVotesAsc						  = 9,
	k_EUGCQuery_RankedByVotesUp								  = 10,
	k_EUGCQuery_RankedByTextSearch							  = 11,
	k_EUGCQuery_RankedByTotalUniqueSubscriptions			  = 12,
	k_EUGCQuery_RankedByPlaytimeTrend						  = 13,
	k_EUGCQuery_RankedByTotalPlaytime						  = 14,
	k_EUGCQuery_RankedByAveragePlaytimeTrend				  = 15,
	k_EUGCQuery_RankedByLifetimeAveragePlaytime				  = 16,
	k_EUGCQuery_RankedByPlaytimeSessionsTrend				  = 17,
	k_EUGCQuery_RankedByLifetimePlaytimeSessions			  = 18,
	k_EUGCQuery_RankedByLastUpdatedDate						  = 19,
};

enum EItemUpdateStatus
{
	k_EItemUpdateStatusInvalid 				= 0, // The item update handle was invalid, job might be finished, listen too SubmitItemUpdateResult_t
	k_EItemUpdateStatusPreparingConfig 		= 1, // The item update is processing configuration data
	k_EItemUpdateStatusPreparingContent		= 2, // The item update is reading and processing content files
	k_EItemUpdateStatusUploadingContent		= 3, // The item update is uploading content changes to Steam
	k_EItemUpdateStatusUploadingPreviewFile	= 4, // The item update is uploading new preview file image
	k_EItemUpdateStatusCommittingChanges	= 5  // The item update is committing all changes
};

enum EItemState
{
	k_EItemStateNone			= 0,	// item not tracked on client
	k_EItemStateSubscribed		= 1,	// current user is subscribed to this item. Not just cached.
	k_EItemStateLegacyItem		= 2,	// item was created with ISteamRemoteStorage
	k_EItemStateInstalled		= 4,	// item is installed and usable (but maybe out of date)
	k_EItemStateNeedsUpdate		= 8,	// items needs an update. Either because it's not installed yet or creator updated content
	k_EItemStateDownloading		= 16,	// item update is currently downloading
	k_EItemStateDownloadPending	= 32,	// DownloadItem() was called for this item, content isn't available until DownloadItemResult_t is fired
};

enum EItemStatistic
{
	k_EItemStatistic_NumSubscriptions					 = 0,
	k_EItemStatistic_NumFavorites						 = 1,
	k_EItemStatistic_NumFollowers						 = 2,
	k_EItemStatistic_NumUniqueSubscriptions				 = 3,
	k_EItemStatistic_NumUniqueFavorites					 = 4,
	k_EItemStatistic_NumUniqueFollowers					 = 5,
	k_EItemStatistic_NumUniqueWebsiteViews				 = 6,
	k_EItemStatistic_ReportScore						 = 7,
	k_EItemStatistic_NumSecondsPlayed					 = 8,
	k_EItemStatistic_NumPlaytimeSessions				 = 9,
	k_EItemStatistic_NumComments						 = 10,
	k_EItemStatistic_NumSecondsPlayedDuringTimePeriod	 = 11,
	k_EItemStatistic_NumPlaytimeSessionsDuringTimePeriod = 12,
};

enum EItemPreviewType
{
	k_EItemPreviewType_Image							= 0,	// standard image file expected (e.g. jpg, png, gif, etc.)
	k_EItemPreviewType_YouTubeVideo						= 1,	// video id is stored
	k_EItemPreviewType_Sketchfab						= 2,	// model id is stored
	k_EItemPreviewType_EnvironmentMap_HorizontalCross	= 3,	// standard image file expected - cube map in the layout
																// +---+---+-------+
																// |   |Up |       |
																// +---+---+---+---+
																// | L | F | R | B |
																// +---+---+---+---+
																// |   |Dn |       |
																// +---+---+---+---+
	k_EItemPreviewType_EnvironmentMap_LatLong			= 4,	// standard image file expected
	k_EItemPreviewType_ReservedMax						= 255,	// you can specify your own types above this value
};

enum EUGCContentDescriptorID
{
	k_EUGCContentDescriptor_NudityOrSexualContent	= 1,
	k_EUGCContentDescriptor_FrequentViolenceOrGore	= 2,
	k_EUGCContentDescriptor_AdultOnlySexualContent	= 3,
	k_EUGCContentDescriptor_GratuitousSexualContent = 4,
	k_EUGCContentDescriptor_AnyMatureContent		= 5,
};

enum EVRScreenshotType
{
	k_EVRScreenshotType_None			= 0,
	k_EVRScreenshotType_Mono			= 1,
	k_EVRScreenshotType_Stereo			= 2,
	k_EVRScreenshotType_MonoCubemap		= 3,
	k_EVRScreenshotType_MonoPanorama	= 4,
	k_EVRScreenshotType_StereoPanorama	= 5
};

// Feature types for parental settings
enum EParentalFeature
{
	k_EFeatureInvalid = 0,
	k_EFeatureStore = 1,
	k_EFeatureCommunity = 2,
	k_EFeatureProfile = 3,
	k_EFeatureFriends = 4,
	k_EFeatureNews = 5,
	k_EFeatureTrading = 6,
	k_EFeatureSettings = 7,
	k_EFeatureConsole = 8,
	k_EFeatureBrowser = 9,
	k_EFeatureParentalSetup = 10,
	k_EFeatureLibrary = 11,
	k_EFeatureTest = 12,
	k_EFeatureSiteLicense = 13,
	k_EFeatureKioskMode = 14,
	k_EFeatureMax
};

enum AudioPlayback_Status
{
	AudioPlayback_Undefined = 0, 
	AudioPlayback_Playing = 1,
	AudioPlayback_Paused = 2,
	AudioPlayback_Idle = 3
};

enum ESteamItemFlags
{
	// Item status flags - these flags are permanently attached to specific item instances
	k_ESteamItemNoTrade = 1 << 0, // This item is account-locked and cannot be traded or given away.

	// Action confirmation flags - these flags are set one time only, as part of a result set
	k_ESteamItemRemoved = 1 << 8,	// The item has been destroyed, traded away, expired, or otherwise invalidated
	k_ESteamItemConsumed = 1 << 9,	// The item quantity has been decreased by 1 via ConsumeItem API.

	// All other flag bits are currently reserved for internal Steam use at this time.
	// Do not assume anything about the state of other flags which are not defined here.
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

enum EPlayerResult
{
	k_EPlayerResultFailedToConnect = 1, // failed to connect after confirming
	k_EPlayerResultAbandoned = 2,		// quit game without completing it
	k_EPlayerResultKicked = 3,			// kicked by other players/moderator/server rules
	k_EPlayerResultIncomplete = 4,		// player stayed to end but game did not conclude successfully ( nofault to player )
	k_EPlayerResultCompleted = 5,		// player completed game
};

enum EGameSearchErrorCode
{
	k_EGameSearchErrorCode_OK = 1,
	k_EGameSearchErrorCode_Failed_Search_Already_In_Progress = 2,
	k_EGameSearchErrorCode_Failed_No_Search_In_Progress = 3,
	k_EGameSearchErrorCode_Failed_Not_Lobby_Leader = 4, // if not the lobby leader can not call SearchForGameWithLobby
	k_EGameSearchErrorCode_Failed_No_Host_Available = 5, // no host is available that matches those search params
	k_EGameSearchErrorCode_Failed_Search_Params_Invalid = 6, // search params are invalid
	k_EGameSearchErrorCode_Failed_Offline = 7, // offline, could not communicate with server
	k_EGameSearchErrorCode_Failed_NotAuthorized = 8, // either the user or the application does not have priveledges to do this
	k_EGameSearchErrorCode_Failed_Unknown_Error = 9, // unknown error
};

enum ESteamPartyBeaconLocationData
{
	k_ESteamPartyBeaconLocationDataInvalid = 0,
	k_ESteamPartyBeaconLocationDataName = 1,
	k_ESteamPartyBeaconLocationDataIconURLSmall = 2,
	k_ESteamPartyBeaconLocationDataIconURLMedium = 3,
	k_ESteamPartyBeaconLocationDataIconURLLarge = 4,
};

enum ESteamPartyBeaconLocationType
{
	k_ESteamPartyBeaconLocationType_Invalid = 0,
	k_ESteamPartyBeaconLocationType_ChatGroup = 1,

	k_ESteamPartyBeaconLocationType_Max,
};

// lobby type description
enum ELobbyType
{
	k_ELobbyTypePrivate = 0,		// only way to join the lobby is to invite to someone else
	k_ELobbyTypeFriendsOnly = 1,	// shows for friends or invitees, but not in lobby list
	k_ELobbyTypePublic = 2,			// visible for friends and in lobby list
	k_ELobbyTypeInvisible = 3,		// returned by search, but not visible to other friends
									//    useful if you want a user in two lobbies, for example matching groups together
									//	  a user can be in only one regular lobby, and up to two invisible lobbies
	k_ELobbyTypePrivateUnique = 4,	// private, unique and does not delete when empty - only one of these may exist per unique keypair set
									// can only create from webapi
};

// lobby search filter tools
enum ELobbyComparison
{
	k_ELobbyComparisonEqualToOrLessThan = -2,
	k_ELobbyComparisonLessThan = -1,
	k_ELobbyComparisonEqual = 0,
	k_ELobbyComparisonGreaterThan = 1,
	k_ELobbyComparisonEqualToOrGreaterThan = 2,
	k_ELobbyComparisonNotEqual = 3,
};

// lobby search distance. Lobby results are sorted from closest to farthest.
enum ELobbyDistanceFilter
{
	k_ELobbyDistanceFilterClose,		// only lobbies in the same immediate region will be returned
	k_ELobbyDistanceFilterDefault,		// only lobbies in the same region or near by regions
	k_ELobbyDistanceFilterFar,			// for games that don't have many latency requirements, will return lobbies about half-way around the globe
	k_ELobbyDistanceFilterWorldwide,	// no filtering, will match lobbies as far as India to NY (not recommended, expect multiple seconds of latency between the clients)
};

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