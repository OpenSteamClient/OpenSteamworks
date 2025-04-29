//==========================  AUTO-GENERATED FILE  ================================
//
// This file is partially auto-generated.
// If functions are removed, your changes to that function will be lost.
// Parameter types and names however are preserved if the function stays unchanged.
// Feel free to change parameters to be more accurate.
//=============================================================================

using System;
using OpenSteamworks.Data.Structs;
using OpenSteamworks.Data.Enums;
using System.Text;

using OpenSteamworks.Protobuf;
using Google.Protobuf;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Callbacks.Structs;
using OpenSteamworks.Data;
using CppSourceGen.Attributes;
using OpenSteamworks.Data.Interop;

namespace OpenSteamworks.Generated;

[CppClass]
public unsafe interface IClientUser
{
    public unknown Unknown_1();  // argc: -1, index: 1, ipc args: [], ipc returns: []
    public EResult LogOn(CSteamID steamid);  // argc: -1, index: 2, ipc args: [uint64], ipc returns: [bytes4]
    public SteamAPICall_t InvalidateCredentials(string accountName, EAuthTokenRevokeAction revokeAction = EAuthTokenRevokeAction.EauthTokenRevokePermanent);  // argc: -1, index: 3, ipc args: [string, bytes4], ipc returns: [bytes8]
    public void LogOff();  // argc: -1, index: 4, ipc args: [], ipc returns: []
    public bool BLoggedOn();  // argc: -1, index: 5, ipc args: [], ipc returns: [boolean]
    public ELogonState GetLogonState();  // argc: -1, index: 6, ipc args: [], ipc returns: [bytes4]
    public bool BConnected();  // argc: -1, index: 7, ipc args: [], ipc returns: [boolean]
    public bool BInitiateReconnect();  // argc: -1, index: 8, ipc args: [], ipc returns: [boolean]
    public EResult EConnect();  // argc: -1, index: 9, ipc args: [], ipc returns: [bytes4]
    public bool BTryingToLogin();  // argc: -1, index: 10, ipc args: [], ipc returns: [boolean]
    public CSteamID GetSteamID();  // argc: -1, index: 11, ipc args: [], ipc returns: [uint64]
    public ulong GetClientInstanceID();  // argc: -1, index: 12, ipc args: [], ipc returns: [bytes8]
    public string GetUserCountry();  // argc: -1, index: 13, ipc args: [], ipc returns: [string]
    public bool IsVACBanned(AppId_t appid);  // argc: -1, index: 14, ipc args: [bytes4], ipc returns: [boolean]
    public bool SetEmail(string newEmail);  // argc: -1, index: 15, ipc args: [string], ipc returns: [bytes1]
    public bool SetConfigString(ERegistrySubTree eSubTree, string key, string value);  // argc: -1, index: 16, ipc args: [bytes4, string, string], ipc returns: [bytes1]
    public bool GetConfigString(ERegistrySubTree eSubTree, string key, StringBuilder stringOut, Int32 stringOutMax);  // argc: -1, index: 17, ipc args: [bytes4, string, bytes4], ipc returns: [bytes1, bytes_external_length]
    public bool SetConfigInt(ERegistrySubTree eSubTree, string key, int value);  // argc: -1, index: 18, ipc args: [bytes4, string, bytes4], ipc returns: [bytes1]
    public bool GetConfigInt(ERegistrySubTree eSubTree, string key, out int value);  // argc: -1, index: 19, ipc args: [bytes4, string], ipc returns: [bytes1, bytes4]
    public bool SetConfigBinaryBlob(ERegistrySubTree eSubTree, string key, in CUtlBuffer buf);  // argc: -1, index: 20, ipc args: [bytes4, string, utlbuf], ipc returns: [bytes1]
    public bool GetConfigBinaryBlob(ERegistrySubTree eSubTree, string key, in CUtlBuffer buf);  // argc: -1, index: 21, ipc args: [bytes4, string], ipc returns: [bytes1, utlbuf]
    public bool DeleteConfigKey(ERegistrySubTree eSubTree, string key);  // argc: -1, index: 22, ipc args: [bytes4, string], ipc returns: [bytes1]
    public bool GetConfigStoreKeyName(ERegistrySubTree eSubTree, string key, StringBuilder pchStoreName, Int32 cbStoreName);  // argc: -1, index: 23, ipc args: [bytes4, string, bytes4], ipc returns: [bytes1, bytes_external_length]
    // WARNING: Arguments are unknown!
    public unknown InitiateGameConnection();  // argc: -1, index: 24, ipc args: [bytes4, uint64, bytes8, bytes4, bytes2, bytes1], ipc returns: [bytes4, bytes_external_length]
    // WARNING: Arguments are unknown!
    public unknown InitiateGameConnectionOld();  // argc: -1, index: 25, ipc args: [bytes4, uint64, bytes8, bytes4, bytes2, bytes1, bytes4, bytes_external_length], ipc returns: [bytes4, bytes_external_length]
    // WARNING: Arguments are unknown!
    public void TerminateGameConnection(uint ip, ushort port);  // argc: -1, index: 26, ipc args: [bytes4, bytes2], ipc returns: []
    // WARNING: Arguments are unknown!
    public bool TerminateGame(CGameID gameid, bool force);  // argc: -1, index: 27, ipc args: [bytes8, bytes1], ipc returns: [bytes1]
    /// <summary>
    /// Apparently deprecated, but still called by ValveSteam.
    /// </summary>
    /// <returns></returns>
    public void SetSelfAsChatDestination(bool online);  // argc: -1, index: 28, ipc args: [bytes1], ipc returns: []
    public bool IsPrimaryChatDestination();  // argc: -1, index: 29, ipc args: [], ipc returns: [boolean]
    public void RequestLegacyCDKey(AppId_t appid);  // argc: -1, index: 30, ipc args: [bytes4], ipc returns: []
    public bool AckGuestPass(string guestPassId);  // argc: -1, index: 31, ipc args: [string], ipc returns: [bytes1]
    public bool RedeemGuestPass(string guestPassId);  // argc: -1, index: 32, ipc args: [string], ipc returns: [bytes1]
    public int GetGuestPassToGiveCount();  // argc: -1, index: 33, ipc args: [], ipc returns: [bytes4]
    public int GetGuestPassToRedeemCount();  // argc: -1, index: 34, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public bool GetGuestPassToGiveInfo(int iPass);  // argc: -1, index: 35, ipc args: [bytes4, bytes4], ipc returns: [bytes1, bytes_external_length, bytes8, bytes4, bytes4, bytes4, bytes4, bytes4]
    // WARNING: Arguments are unknown!
    public SteamAPICall_t GetGuestPassToGiveOut(AppId_t appid);  // argc: -1, index: 36, ipc args: [bytes4], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public SteamAPICall_t GetGuestPassToRedeem(AppId_t appid);  // argc: -1, index: 37, ipc args: [bytes4], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown GetGuestPassToRedeemInfo();  // argc: -1, index: 38, ipc args: [bytes4], ipc returns: [bytes1, bytes8, bytes4, bytes4, bytes4, bytes4, bytes4]
    public bool GetGuestPassToRedeemSenderName(AppId_t appid, StringBuilder name, int nameMax);  // argc: -1, index: 39, ipc args: [bytes4, bytes4], ipc returns: [bytes1, bytes_external_length]
    public int GetNumAppsInGuestPassesToRedeem();  // argc: -1, index: 40, ipc args: [], ipc returns: [bytes4]
    public uint GetAppsInGuestPassesToRedeem(Span<AppId_t> appids, int appidsMax);  // argc: -1, index: 41, ipc args: [bytes4], ipc returns: [bytes4, bytes_external_length]
    public int GetCountUserNotifications();  // argc: -1, index: 42, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public int GetCountUserNotification(int EUserNotification);  // argc: -1, index: 43, ipc args: [bytes4], ipc returns: [bytes4]
    public SteamAPICall_t RequestStoreAuthURL(string url);  // argc: -1, index: 44, ipc args: [string], ipc returns: [bytes8]
    public bool SetLanguage(string language);  // argc: -1, index: 45, ipc args: [string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown TrackAppUsageEvent();  // argc: -1, index: 46, ipc args: [bytes8, bytes4, string], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown RaiseConnectionPriority();  // argc: -1, index: 47, ipc args: [bytes4, bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown ResetConnectionPriority();  // argc: -1, index: 48, ipc args: [bytes4], ipc returns: []
    public unknown GetDesiredNetQOSLevel();  // argc: -1, index: 49, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public bool BHasCachedCredentials(string username);  // argc: -1, index: 50, ipc args: [string], ipc returns: [boolean]
    public bool SetAccountNameForCachedCredentialLogin(string username, bool unk1 = false);  // argc: -1, index: 51, ipc args: [string, bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public void DestroyCachedCredentials(string username, EAuthTokenRevokeAction revokeAction = EAuthTokenRevokeAction.EauthTokenRevokeLogout);  // argc: -1, index: 52, ipc args: [string, bytes4], ipc returns: []
    public bool GetCurrentWebAuthToken(StringBuilder tokenOut, UInt32 bufSize);  // argc: -1, index: 53, ipc args: [bytes4], ipc returns: [bytes1, bytes_external_length]
    public SteamAPICall<WebAuthRequestCallback_t> RequestWebAuthToken();  // argc: -1, index: 54, ipc args: [], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public void SetLoginInformation(string username, string password, bool remember);  // argc: -1, index: 55, ipc args: [string, string, bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public void SetTwoFactorCode(string twoFactorCode);  // argc: -1, index: 56, ipc args: [string], ipc returns: []
    public void SetLoginToken(string token, string username);  // argc: -1, index: 57, ipc args: [string, string], ipc returns: []
    public UInt64 GetLoginTokenID();  // argc: -1, index: 58, ipc args: [], ipc returns: [bytes8]
    public void ClearAllLoginInformation();  // argc: -1, index: 59, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public bool BEnableEmbeddedClient(uint unk);  // argc: -1, index: 60, ipc args: [bytes4], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public void ResetEmbeddedClient(uint unk);  // argc: -1, index: 61, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public bool BHasEmbeddedClientToken(uint unk);  // argc: -1, index: 62, ipc args: [bytes4], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public void RequestEmbeddedClientToken(uint unk);  // argc: -1, index: 63, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public void AuthorizeNewDevice(uint unk, uint unk1, string unk2);  // argc: -1, index: 64, ipc args: [bytes4, bytes4, string], ipc returns: []
    public bool GetLanguage(StringBuilder langOut, int maxOut);  // argc: -1, index: 65, ipc args: [bytes4], ipc returns: [bytes1, bytes_external_length]
    // WARNING: Arguments are unknown!
    public void TrackSteamUsageEvent();  // argc: -1, index: 66, ipc args: [bytes4, bytes4, bytes_external_length], ipc returns: []
    public void SetComputerInUse();  // argc: -1, index: 67, ipc args: [bytes4], ipc returns: []
    public bool BIsGameRunning(CGameID gameid);  // argc: -1, index: 68, ipc args: [bytes8], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public bool BIsGameWindowReady(CGameID gameid);  // argc: -1, index: 69, ipc args: [bytes8], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public bool BUpdateAppOwnershipTicket(uint unk1, bool unk);  // argc: -1, index: 70, ipc args: [bytes4, bytes1], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public UInt32 GetCustomBinariesState(AppId_t unAppID, out UInt64 unk, out UInt64 unk1);  // argc: -1, index: 71, ipc args: [bytes4], ipc returns: [bytes4, bytes8, bytes8]
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public unknown RequestCustomBinaries(AppId_t appid, bool unk1, bool unk2, uint unk);  // argc: -1, index: 72, ipc args: [bytes4, bytes1, bytes1, bytes4], ipc returns: [bytes4]
    public void SetCellID(uint cellid);  // argc: -1, index: 73, ipc args: [bytes4], ipc returns: []
    public bool GetCellList(out CMsgCellList cellList);  // argc: -1, index: 74, ipc args: [], ipc returns: [bytes1, protobuf]
    public string GetUserBaseFolder();  // argc: -1, index: 75, ipc args: [], ipc returns: [string]
    public bool GetUserDataFolder(CGameID gameID, StringBuilder buf, int bufMax);  // argc: -1, index: 76, ipc args: [bytes8, bytes4], ipc returns: [bytes1, bytes_external_length]
    public bool GetUserConfigFolder(StringBuilder buf, int bufMax);  // argc: -1, index: 77, ipc args: [bytes4], ipc returns: [bytes1, bytes_external_length]
    public bool GetAccountName(StringBuilder usernameOut, int strMaxLen);  // argc: -1, index: 78, ipc args: [bytes4], ipc returns: [bytes1, bytes_external_length]
    // WARNING: Arguments are unknown!
    public bool GetAccountName(CSteamID steamid, StringBuilder usernameOut, int strMaxLen);  // argc: -1, index: 79, ipc args: [uint64, bytes4], ipc returns: [bytes1, bytes_external_length]
    public bool IsPasswordRemembered();  // argc: -1, index: 80, ipc args: [], ipc returns: [boolean]
    public bool IsSiteLicenseAssociationPending();  // argc: -1, index: 81, ipc args: [], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public void CheckoutSiteLicenseSeat(AppId_t appid);  // argc: -1, index: 82, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public void GetAvailableSeats(AppId_t appid);  // argc: -1, index: 83, ipc args: [bytes4], ipc returns: []
    public string GetAssociatedSiteName();  // argc: -1, index: 84, ipc args: [], ipc returns: [string]
    public bool BIsRunningInCafe();  // argc: -1, index: 85, ipc args: [], ipc returns: [boolean]
    public bool BAllowCachedCredentialsInCafe();  // argc: -1, index: 86, ipc args: [], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public bool RequiresLegacyCDKey(AppId_t appid, out bool unk);  // argc: -1, index: 87, ipc args: [bytes4], ipc returns: [bytes1, bytes1]
    // WARNING: Arguments are unknown!
    public bool GetLegacyCDKey(AppId_t appid, StringBuilder keyData, int keyDataMax);  // argc: -1, index: 88, ipc args: [bytes4, bytes4], ipc returns: [bytes1, bytes_external_length]
    // WARNING: Arguments are unknown!
    public bool SetLegacyCDKey(AppId_t appid, string keyData);  // argc: -1, index: 89, ipc args: [bytes4, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public bool WriteLegacyCDKey(AppId_t appid);  // argc: -1, index: 90, ipc args: [bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public void RemoveLegacyCDKey(AppId_t appid);  // argc: -1, index: 91, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public void RequestLegacyCDKeyFromApp();  // argc: -1, index: 92, ipc args: [bytes4, bytes4, bytes4], ipc returns: []
    public bool BIsAnyGameRunning();  // argc: -1, index: 93, ipc args: [], ipc returns: [boolean]
    public void GetSteamGuardDetails();  // argc: -1, index: 94, ipc args: [], ipc returns: []
    public void GetTwoFactorDetails();  // argc: -1, index: 95, ipc args: [], ipc returns: []
    public bool BHasTwoFactor();  // argc: -1, index: 96, ipc args: [], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public bool GetEmail(StringBuilder email, int emailMax, out bool validated);  // argc: -1, index: 97, ipc args: [bytes4], ipc returns: [bytes1, bytes_external_length, bytes1]
    public void Test_FakeConnectionTimeout();  // argc: -1, index: 98, ipc args: [], ipc returns: []
    public bool RunInstallScript(AppId_t appid, bool uninstall);  // argc: -1, index: 99, ipc args: [bytes4, bytes1], ipc returns: [bytes1]
    public AppId_t IsInstallScriptRunning();  // argc: -1, index: 100, ipc args: [], ipc returns: [bytes4]
    public bool GetInstallScriptState(StringBuilder pchDescription, UInt32 cchDescription, out UInt32 punNumSteps, out UInt32 punCurrStep);  // argc: -1, index: 101, ipc args: [bytes4], ipc returns: [bytes1, bytes_external_length, bytes4, bytes4]
    public bool StopInstallScript(AppId_t appid);  // argc: -1, index: 102, ipc args: [bytes4], ipc returns: [bytes1]
    public bool ResetInstallScript(AppId_t appid);  // argc: -1, index: 103, ipc args: [bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown GetAppOwnershipTicketLength(AppId_t app);  // argc: -1, index: 104, ipc args: [bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetAppOwnershipTicketData();  // argc: -1, index: 105, ipc args: [bytes4, bytes4], ipc returns: [bytes4, bytes_external_length]
    // WARNING: Arguments are unknown!
    public unknown GetAppOwnershipTicketExtendedData();  // argc: -1, index: 106, ipc args: [bytes4, bytes4], ipc returns: [bytes4, bytes_external_length, bytes4, bytes4, bytes4, bytes4]
    public int GetMarketingMessageCount();  // argc: -1, index: 107, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetMarketingMessage(int cMarketingMessage, out GID_t gidMarketingMessageID, StringBuilder pubMsgUrl, int cubMessageUrl, out EMarketingMessageFlags eMarketingMssageFlags);  // argc: -1, index: 108, ipc args: [bytes4, bytes4], ipc returns: [bytes1, bytes8, bytes_external_length, bytes4]
    // WARNING: Arguments are unknown!
    public unknown MarkMarketingMessageSeen(GID_t gidMarketingMessageID);  // argc: -1, index: 109, ipc args: [bytes8], ipc returns: []
    public unknown CheckForPendingMarketingMessages();  // argc: -1, index: 110, ipc args: [], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown GetAuthSessionTicket();  // argc: -1, index: 111, ipc args: [bytes4], ipc returns: [bytes4, bytes_external_length, bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetAuthSessionTicketV2();  // argc: -1, index: 112, ipc args: [bytes4, steamnetworkingidentity], ipc returns: [bytes4, bytes_external_length, bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetAuthSessionTicketV3();  // argc: -1, index: 113, ipc args: [bytes4, steamnetworkingidentity], ipc returns: [bytes4, bytes_external_length, bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetAuthTicketForWebApi();  // argc: -1, index: 114, ipc args: [string], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetAuthSessionTicketForGameID();  // argc: -1, index: 115, ipc args: [bytes4, bytes8, steamnetworkingidentity], ipc returns: [bytes4, bytes_external_length, bytes4]
    // WARNING: Arguments are unknown!
    public unknown BeginAuthSession();  // argc: -1, index: 116, ipc args: [bytes4, uint64, bytes_external_length], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown EndAuthSession();  // argc: -1, index: 117, ipc args: [uint64], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown CancelAuthTicket();  // argc: -1, index: 118, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown IsUserSubscribedAppInTicket();  // argc: -1, index: 119, ipc args: [uint64, bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown AdvertiseGame(CSteamID steamIDGameServer, UInt32 unIPServer, UInt16 usPortServer);  // argc: -1, index: 120, ipc args: [bytes8, uint64, bytes4, bytes2], ipc returns: []
    // WARNING: Arguments are unknown!
    public SteamAPICall_t RequestEncryptedAppTicket();  // argc: -1, index: 121, ipc args: [bytes4, bytes_external_length], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown GetEncryptedAppTicket();  // argc: -1, index: 122, ipc args: [bytes4], ipc returns: [bytes1, bytes4, bytes_external_length]
    // WARNING: Arguments are unknown!
    public uint GetGameBadgeLevel(AppId_t app, bool unk);  // argc: -1, index: 123, ipc args: [bytes4, bytes1], ipc returns: [bytes4]
    public uint GetPlayerSteamLevel();  // argc: -1, index: 124, ipc args: [], ipc returns: [bytes4]
    /// <summary>
    /// Don't use this. It does strange things and will probably get you flagged.
    /// </summary>
    public void SetAccountLimited(bool val);  // argc: -1, index: 125, ipc args: [bytes1], ipc returns: []
    public bool BIsAccountLimited();  // argc: -1, index: 126, ipc args: [], ipc returns: [boolean]
    /// <summary>
    /// Don't use this. It does strange things and will probably get you flagged.
    /// </summary>
    public void SetAccountCommunityBanned(bool val);  // argc: -1, index: 127, ipc args: [bytes1], ipc returns: []
    public bool BIsAccountCommunityBanned();  // argc: -1, index: 128, ipc args: [], ipc returns: [boolean]
    /// <summary>
    /// Don't use this. It does strange things and will probably get you flagged.
    /// </summary>
    public void SetLimitedAccountCanInviteFriends(bool val);  // argc: -1, index: 129, ipc args: [bytes1], ipc returns: []
    public bool BLimitedAccountCanInviteFriends();  // argc: -1, index: 130, ipc args: [], ipc returns: [boolean]
    public bool BGameConnectTokensAvailable();  // argc: -1, index: 131, ipc args: [], ipc returns: [boolean]
    public int NumGamesRunning();  // argc: -1, index: 132, ipc args: [], ipc returns: [bytes4]
    public CGameID GetRunningGameID(int i);  // argc: -1, index: 133, ipc args: [bytes4], ipc returns: [bytes8]
    public UInt32 GetRunningGamePID(int i);  // argc: -1, index: 134, ipc args: [bytes4], ipc returns: [bytes4]
    public unknown RaiseWindowForGame(CGameID gameid);  // argc: -1, index: 135, ipc args: [bytes8], ipc returns: [bytes4]
    public UInt32 GetAccountSecurityPolicyFlags();  // argc: -1, index: 136, ipc args: [], ipc returns: [bytes4]
    public bool BSupportUser();  // argc: -1, index: 137, ipc args: [], ipc returns: [boolean]
    public bool BNeedsSSANextSteamLogon();  // argc: -1, index: 138, ipc args: [], ipc returns: [boolean]
    public void ClearNeedsSSANextSteamLogon();  // argc: -1, index: 139, ipc args: [], ipc returns: []
    public bool BIsAppOverlayEnabled(CGameID gameid);  // argc: -1, index: 140, ipc args: [bytes8], ipc returns: [boolean]
    public bool BOverlayIgnoreChildProcesses(CGameID gameid);  // argc: -1, index: 141, ipc args: [bytes8], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public void SetOverlayState(CGameID appid, uint unk);  // argc: -1, index: 142, ipc args: [bytes8, bytes4], ipc returns: []
    public void NotifyOverlaySettingsChanged();  // argc: -1, index: 143, ipc args: [], ipc returns: []
    public bool BIsBehindNAT();  // argc: -1, index: 144, ipc args: [], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown GetMicroTxnAppID(GID_t transactionId);  // argc: -1, index: 145, ipc args: [bytes8], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetMicroTxnOrderID(GID_t transactionId);  // argc: -1, index: 146, ipc args: [bytes8], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown BGetMicroTxnPrice(GID_t transactionId, ref CAmount unk, ref CAmount unk2, ref bool unk3, int unk4);  // argc: -1, index: 147, ipc args: [bytes8], ipc returns: [boolean, bytes12, bytes12, boolean, bytes12]
    public ESteamRealm GetMicroTxnSteamRealm(GID_t transactionId);  // argc: -1, index: 148, ipc args: [bytes8], ipc returns: [bytes4]
    public int GetMicroTxnLineItemCount(GID_t transactionId);  // argc: -1, index: 149, ipc args: [bytes8], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown BGetMicroTxnLineItem(GID_t transactionId, uint unk, ref int unk2, ref uint unk3, StringBuilder name, int nameMax, ref int unk4, byte* unk5, ref int unk6, ref bool unk7);  // argc: -1, index: 150, ipc args: [bytes8, bytes4, bytes4], ipc returns: [boolean, bytes12, bytes4, bytes_external_length, bytes4, boolean, bytes12, boolean]
    public bool BIsSandboxMicroTxn(GID_t transactionId, out bool isSandbox);  // argc: -1, index: 151, ipc args: [bytes8], ipc returns: [boolean, boolean]
    public bool BMicroTxnRequiresCachedPmtMethod(GID_t transactionId, out bool requiresCachedPmtMethod);  // argc: -1, index: 152, ipc args: [bytes8], ipc returns: [boolean, boolean]
    public SteamAPICall_t AuthorizeMicroTxn(GID_t transactionId, int unk);  // argc: -1, index: 153, ipc args: [bytes8, bytes4], ipc returns: [bytes8]
    public bool BGetWalletBalance(out bool hasWallet, out CAmount amount, out CAmount amountPending);  // argc: -1, index: 154, ipc args: [], ipc returns: [boolean, boolean, bytes12, bytes12]
    public SteamAPICall_t RequestMicroTxnInfo(GID_t transactionId);  // argc: -1, index: 155, ipc args: [bytes8], ipc returns: [bytes8]
    public bool BMicroTxnRefundable(GID_t transactionId);  // argc: -1, index: 156, ipc args: [bytes8], ipc returns: [boolean]
    public bool BGetAppMinutesPlayed(AppId_t appid, out uint allTime, out uint lastTwoWeeks);  // argc: -1, index: 157, ipc args: [bytes4], ipc returns: [boolean, bytes4, bytes4]
    public RTime32 GetAppLastPlayedTime(AppId_t appid);  // argc: -1, index: 158, ipc args: [bytes4], ipc returns: [bytes4]
    public uint GetAppUpdateDisabledSecondsRemaining(AppId_t appid);  // argc: -1, index: 159, ipc args: [bytes4], ipc returns: [bytes4]
    public bool BGetGuideURL(AppId_t appid, StringBuilder url, int urlMax);  // argc: -1, index: 160, ipc args: [bytes4, bytes4], ipc returns: [boolean, bytes_external_length]
    public bool BPromptToChangePassword();  // argc: -1, index: 161, ipc args: [], ipc returns: [boolean]
    public bool BAccountExtraSecurity();  // argc: -1, index: 162, ipc args: [], ipc returns: [boolean]
    public bool BAccountShouldShowLockUI();  // argc: -1, index: 163, ipc args: [], ipc returns: [boolean]
    public int GetCountAuthedComputers();  // argc: -1, index: 164, ipc args: [], ipc returns: [bytes4]
    public RTime32 GetSteamGuardEnabledTime();  // argc: -1, index: 165, ipc args: [], ipc returns: [bytes4]
    public void SetPhoneIsVerified(bool val);  // argc: -1, index: 166, ipc args: [bytes1], ipc returns: []
    public bool BIsPhoneVerified();  // argc: -1, index: 167, ipc args: [], ipc returns: [boolean]
    public void SetPhoneIsIdentifying(bool val);  // argc: -1, index: 168, ipc args: [bytes1], ipc returns: []
    public bool BIsPhoneIdentifying();  // argc: -1, index: 169, ipc args: [], ipc returns: [boolean]
    public void SetPhoneIsRequiringVerification(bool val);  // argc: -1, index: 170, ipc args: [bytes1], ipc returns: []
    public bool BIsPhoneRequiringVerification();  // argc: -1, index: 171, ipc args: [], ipc returns: [boolean]
    public void Set2ndFactorAuthCode(string code, bool remember);  // argc: -1, index: 172, ipc args: [string, bytes1], ipc returns: []
    public void SetUserMachineName(string name);  // argc: -1, index: 173, ipc args: [string], ipc returns: []
    public void GetUserMachineName(StringBuilder name, int len);  // argc: -1, index: 174, ipc args: [bytes4], ipc returns: [bytes1, bytes_external_length]
    // WARNING: Arguments are unknown!
    public bool GetEmailDomainFromLogonFailure(StringBuilder domain, int domainMax);  // argc: -1, index: 175, ipc args: [bytes4], ipc returns: [bytes1, bytes_external_length]
    public string GetAgreementSessionUrl();  // argc: -1, index: 176, ipc args: [], ipc returns: [string]
    public SteamAPICall_t GetDurationControl();  // argc: -1, index: 177, ipc args: [], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public UInt64 GetDurationControlForApp(AppId_t appid);  // argc: -1, index: 178, ipc args: [bytes4], ipc returns: [bytes8]
    public bool BSetDurationControlOnlineState(EDurationControlOnlineState eNewState);  // argc: -1, index: 179, ipc args: [bytes4], ipc returns: [boolean]
    public bool BSetDurationControlOnlineStateForApp(AppId_t appid, EDurationControlOnlineState eNewState);  // argc: -1, index: 180, ipc args: [bytes4, bytes4], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public bool BGetDurationControlExtendedResults();  // argc: -1, index: 181, ipc args: [bytes4], ipc returns: [boolean, boolean, boolean]
    /// <summary>
    /// Checks if the active user owns a specific app.
    /// </summary>
    /// <param name="appid">AppID to check</param>
    /// <returns>Whether user owns game or not</returns>
    public bool BIsSubscribedApp(AppId_t appid);  // argc: -1, index: 182, ipc args: [bytes4], ipc returns: [boolean]
    /// <summary>
    /// Gets a list of all appid's the current user owns.
    /// </summary>
    /// <param name="arr">The preallocated array to populate</param>
    /// <param name="lengthOfArr">The length of the preallocated array</param>
    /// <param name="unk">Unknown...</param>
    /// <returns>How many apps the user owns</returns>
    public int GetSubscribedApps(Span<AppId_t> arr, int lengthOfArr, bool unk);  // argc: -1, index: 183, ipc args: [bytes4, bytes1], ipc returns: [bytes4, bytes_external_length]
    public void AckSystemIM(GID_t id);  // argc: -1, index: 184, ipc args: [bytes8], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown RequestSpecialSurvey(uint surveyId);  // argc: -1, index: 185, ipc args: [bytes4], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public SteamAPICall_t SendSpecialSurveyResponse(uint surveyId, ReadOnlySpan<byte> data, int dataLength);  // argc: -1, index: 186, ipc args: [bytes4, bytes4, bytes_external_length], ipc returns: [bytes8]
    public void RequestNotifications();  // argc: -1, index: 187, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    /// <summary>
    ///
    /// </summary>
    /// <param name="appid"></param>
    /// <param name="timeCreated"></param>
    /// <param name="country">Use a 3 byte buffer for the country</param>
    /// <returns></returns>
    public unknown GetAppOwnershipInfo(AppId_t appid, out RTime32 timeCreated, out UInt32 unk, StringBuilder country);  // argc: -1, index: 188, ipc args: [bytes4], ipc returns: [bytes1, bytes4, bytes4, bytes3]
    // WARNING: Arguments are unknown!
    public unknown SendGameWebCallback(AppId_t appid, string data);  // argc: -1, index: 189, ipc args: [bytes4, string], ipc returns: []
    public bool BIsStreamingUIToRemoteDevice();  // argc: -1, index: 190, ipc args: [], ipc returns: [boolean]
    public bool BIsCurrentlyNVStreaming();  // argc: -1, index: 191, ipc args: [], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public unknown OnBigPictureForStreamingStartResult();  // argc: -1, index: 192, ipc args: [bytes1, bytes4], ipc returns: []
    public void OnBigPictureForStreamingDone();  // argc: -1, index: 193, ipc args: [], ipc returns: []
    public void OnBigPictureForStreamingRestarting();  // argc: -1, index: 194, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public void StopStreaming(AppId_t appid);  // argc: -1, index: 195, ipc args: [bytes4], ipc returns: []
    public unknown GetAllAccountFlags();  // argc: -1, index: 196, ipc args: [], ipc returns: [bytes4]
    public void LockParentalLock();  // argc: -1, index: 197, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public bool UnlockParentalLock(string unk);  // argc: -1, index: 198, ipc args: [string], ipc returns: [bytes1]
    public bool BIsParentalLockEnabled();  // argc: -1, index: 199, ipc args: [], ipc returns: [boolean]
    public bool BIsParentalLockLocked();  // argc: -1, index: 200, ipc args: [], ipc returns: [boolean]
    public bool BIsAppBlocked(AppId_t appid);  // argc: -1, index: 201, ipc args: [bytes4], ipc returns: [boolean]
    public bool BIsAppInBlockList(AppId_t appid);  // argc: -1, index: 202, ipc args: [bytes4], ipc returns: [boolean]
    public bool BIsFeatureBlocked(EParentalFeature eParentalFeature);  // argc: -1, index: 203, ipc args: [bytes4], ipc returns: [boolean]
    public bool BIsFeatureInBlockList(EParentalFeature eParentalFeature);  // argc: -1, index: 204, ipc args: [bytes4], ipc returns: [boolean]
    public RTime32 GetParentalUnlockTime();  // argc: -1, index: 205, ipc args: [], ipc returns: [bytes4]
    public bool BGetRecoveryEmail(StringBuilder email, uint strMaxLen);  // argc: -1, index: 206, ipc args: [bytes4], ipc returns: [boolean, bytes_external_length]
    public bool BIsLockFromSiteLicense();  // argc: -1, index: 207, ipc args: [], ipc returns: [boolean]
    public unknown EIsParentalPlaytimeBlocked();  // argc: -1, index: 208, ipc args: [], ipc returns: [bytes4]
    public bool BGetSerializedParentalSettings(CUtlBuffer* serialized);  // argc: -1, index: 209, ipc args: [], ipc returns: [boolean, utlbuf]
    public bool BGetParentalWebToken(CUtlBuffer* unk1, CUtlBuffer* unk2);  // argc: -1, index: 210, ipc args: [], ipc returns: [boolean, utlbuf, utlbuf]
    /// <summary>
    /// Only preference 0 seems to exist.
    /// </summary>
    public uint GetCommunityPreference(int preference);  // argc: -1, index: 211, ipc args: [bytes4], ipc returns: [bytes1]
    /// <summary>
    /// Only preference 0 seems to exist.
    /// </summary>
    public void SetCommunityPreference(int preference, uint value);  // argc: -1, index: 212, ipc args: [bytes4, bytes1], ipc returns: []
    public uint GetTextFilterSetting();  // argc: -1, index: 213, ipc args: [], ipc returns: [bytes4]
    public bool BTextFilterIgnoresFriends();  // argc: -1, index: 214, ipc args: [], ipc returns: [boolean]
    /// <summary>
    /// Can return 0, 1 or 2 or a mystery uint. Probably is an enum of some sort.
    /// </summary>
    public unknown CanLogonOffline();  // argc: -1, index: 215, ipc args: [], ipc returns: [bytes4]
    /// <summary>
    /// Returns 19, same mystery uint as CanLogonOffline or 1
    /// Also unk1 only seems to affect the callback that gets posted.
    /// </summary>
    public unknown LogOnOffline(bool bUnk);  // argc: -1, index: 216, ipc args: [bytes1], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown ValidateOfflineLogonTicket();  // argc: -1, index: 217, ipc args: [string], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public bool BGetOfflineLogonTicket(StringBuilder ticket, int ticketMax);  // argc: -1, index: 218, ipc args: [string], ipc returns: [boolean, protobuf]
    public SteamAPICall_t UploadLocalClientLogs();  // argc: -1, index: 219, ipc args: [], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public void SetAsyncNotificationEnabled(AppId_t appid, bool val);  // argc: -1, index: 220, ipc args: [bytes4, bytes1], ipc returns: []
    public bool BIsOtherSessionPlaying(ref UInt32 accountID);  // argc: -1, index: 221, ipc args: [], ipc returns: [boolean, bytes4]
    public bool BKickOtherPlayingSession();  // argc: -1, index: 222, ipc args: [], ipc returns: [boolean]
    public bool BIsAccountLockedDown();  // argc: -1, index: 223, ipc args: [], ipc returns: [boolean]
    public SteamAPICall_t RequestAccountLinkInfo();  // argc: -1, index: 224, ipc args: [], ipc returns: [bytes8]
    public void RequestSurveySchedule();  // argc: -1, index: 225, ipc args: [], ipc returns: []
    public void RequestNewSteamAnnouncementState();  // argc: -1, index: 226, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown UpdateSteamAnnouncementLastRead();  // argc: -1, index: 227, ipc args: [bytes8, bytes4], ipc returns: []
    public unknown GetMarketEligibility();  // argc: -1, index: 228, ipc args: [], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown UpdateGameVrDllState(CGameID gameid, bool unk, bool unk2);  // argc: -1, index: 229, ipc args: [bytes8, bytes1, bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown KillVRTheaterPancakeGame(CGameID gameid);  // argc: -1, index: 230, ipc args: [bytes8], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetVRIsHMDAwake();  // argc: -1, index: 231, ipc args: [bytes1], ipc returns: []
    public bool BIsAnyGameOrServiceAppRunning();  // argc: -1, index: 232, ipc args: [], ipc returns: [boolean]
    public bool BGetAppPlaytimeMap(CUtlMap<AppId_t, AppPlaytime_t>* vec);  // argc: -1, index: 233, ipc args: [bytes4], ipc returns: [boolean]
    public bool BGetAppsLastPlayedMap(CUtlMap<AppId_t, RTime32>* vec);  // argc: -1, index: 234, ipc args: [bytes4], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown SendSteamServiceStatusUpdate(EResult unk1, ESteamServiceStatusUpdate unk2);  // argc: -1, index: 235, ipc args: [bytes4, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public EResult RequestSteamGroupChatMessageNotifications();  // argc: -1, index: 236, ipc args: [bytes8, bytes8, bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown RequestSteamGroupChatMessageHistory();  // argc: -1, index: 237, ipc args: [bytes8, bytes8, bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown RequestSendSteamGroupChatMessage();  // argc: -1, index: 238, ipc args: [bytes8, bytes8, bytes4, string], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown OnNewGroupChatMsgAdded();  // argc: -1, index: 239, ipc args: [bytes8, bytes8, bytes4, bytes4, bytes4, string], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown OnGroupChatUserStateChange();  // argc: -1, index: 240, ipc args: [bytes8, bytes4, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown OnReceivedGroupChatSubscriptionResponse();  // argc: -1, index: 241, ipc args: [bytes8, bytes8, bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown GetTimedTrialStatus();  // argc: -1, index: 242, ipc args: [bytes4], ipc returns: [bytes1, bytes1, bytes4, bytes4]
    public SteamAPICall_t RequestTimedTrialStatus(AppId_t appid);  // argc: -1, index: 243, ipc args: [bytes4], ipc returns: [bytes1]
    public unknown PrepareForSystemSuspend();  // argc: -1, index: 244, ipc args: [], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown ResumeSuspendedGames();  // argc: -1, index: 245, ipc args: [bytes1], ipc returns: [bytes8]
    public UInt64 GetClientInstallationID();  // argc: -1, index: 246, ipc args: [], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public AppId_t GetAppIDForGameID(in CGameID gameid);  // argc: -1, index: 247, ipc args: [bytes8], ipc returns: [bytes4]
    public bool BDoNotDisturb();  // argc: -1, index: 248, ipc args: [], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public void SetAdditionalClientArgData();  // argc: -1, index: 249, ipc args: [bytes5], ipc returns: []
    public ulong GetFamilyGroupID();  // argc: -1, index: 250, ipc args: [], ipc returns: [bytes8]
    public string GetFamilyGroupName();  // argc: -1, index: 251, ipc args: [], ipc returns: [string]
    public uint GetFamilyGroupRole();  // argc: -1, index: 252, ipc args: [], ipc returns: [bytes4]
    public int GetFamilyGroupMembers(Span<AccountID_t> memberAccountIDs, int maxLen);  // argc: -1, index: 253, ipc args: [bytes4, bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public bool GetSharedAppLockInfo(AppId_t appid, out bool isLocked, out uint unk, out uint unk2, out uint unk3, out bool unk4);  // argc: -1, index: 254, ipc args: [bytes4], ipc returns: [bytes1, bytes4, bytes4, bytes4, bytes1]
    // WARNING: Arguments are unknown!
    public bool GetFamilyDLCForApp(AppId_t appid, CUtlVector<uint>* dlcIDs);  // argc: -1, index: 255, ipc args: [bytes4, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public SteamAPICall_t SetPreferredLender(AppId_t appid, uint accountID);  // argc: -1, index: 256, ipc args: [bytes4, bytes4], ipc returns: [bytes8]
    public bool GetFamilyCopyCounts(CUtlMap<AppId_t, int>* counts);  // argc: -1, index: 257, ipc args: [bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public void NotifyPendingGameLaunch_FetchSteamStreamingEncoderConfig(AppId_t appid);  // argc: -1, index: 258, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public bool BShouldWaitForSteamStreamingEncoderConfig(AppId_t appid);  // argc: -1, index: 259, ipc args: [bytes4], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public bool BGetProcessIDsForGame(CGameID gameid, CUtlVector<uint>* gameIDs);  // argc: -1, index: 260, ipc args: [bytes8, bytes4, bytes4], ipc returns: [boolean]
    public SteamAPICall_t CancelLicenseForApp(AppId_t appid);  // argc: -1, index: 261, ipc args: [bytes4], ipc returns: [bytes8]
}