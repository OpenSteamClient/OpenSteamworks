//==========================  AUTO-GENERATED FILE  ================================
//
// This file is partially auto-generated.
// If functions are removed, your changes to that function will be lost.
// Parameter types and names however are preserved if the function stays unchanged.
// Feel free to change parameters to be more accurate. 
//
//=============================================================================

#pragma once

#include "clienttypes.h"

class IClientUser
{
public:
    virtual unknown_ret Unknown_0_DONTUSE() = 0; //argc: -1, index 1
    virtual unknown_ret LogOn(CSteamID steamid) = 0; //argc: 2, index 2
    virtual unknown_ret InvalidateCredentials() = 0; //argc: 2, index 3
    virtual unknown_ret LogOff() = 0; //argc: 0, index 4
    virtual bool BLoggedOn() = 0; //argc: 0, index 5
    virtual unknown_ret GetLogonState() = 0; //argc: 0, index 6
    virtual bool BConnected() = 0; //argc: 0, index 7
    virtual unknown_ret BInitiateReconnect() = 0; //argc: 0, index 8
    virtual unknown_ret EConnect() = 0; //argc: 0, index 9
    virtual unknown_ret BTryingToLogin() = 0; //argc: 0, index 10
    virtual CSteamID GetSteamID() = 0; //argc: 1, index 11
    virtual unknown_ret GetClientInstanceID() = 0; //argc: 0, index 12
    virtual unknown_ret GetUserCountry() = 0; //argc: 0, index 13
    virtual unknown_ret IsVACBanned() = 0; //argc: 1, index 14
    virtual unknown_ret SetEmail() = 0; //argc: 1, index 15
    virtual unknown_ret SetConfigString() = 0; //argc: 3, index 16
    virtual unknown_ret GetConfigString() = 0; //argc: 4, index 17
    virtual unknown_ret SetConfigInt() = 0; //argc: 3, index 18
    virtual unknown_ret GetConfigInt() = 0; //argc: 3, index 19
    virtual unknown_ret SetConfigBinaryBlob() = 0; //argc: 3, index 20
    virtual unknown_ret GetConfigBinaryBlob() = 0; //argc: 3, index 21
    virtual unknown_ret DeleteConfigKey() = 0; //argc: 2, index 22
    virtual unknown_ret GetConfigStoreKeyName() = 0; //argc: 4, index 23
    virtual unknown_ret InitiateGameConnection() = 0; //argc: 8, index 24
    virtual unknown_ret InitiateGameConnectionOld() = 0; //argc: 10, index 25
    virtual unknown_ret TerminateGameConnection() = 0; //argc: 2, index 26
    virtual unknown_ret TerminateGame() = 0; //argc: 2, index 27
    virtual unknown_ret SetSelfAsChatDestination() = 0; //argc: 1, index 28
    virtual unknown_ret IsPrimaryChatDestination() = 0; //argc: 0, index 29
    virtual unknown_ret RequestLegacyCDKey() = 0; //argc: 1, index 30
    virtual unknown_ret AckGuestPass() = 0; //argc: 1, index 31
    virtual unknown_ret RedeemGuestPass() = 0; //argc: 1, index 32
    virtual unknown_ret GetGuestPassToGiveCount() = 0; //argc: 0, index 33
    virtual unknown_ret GetGuestPassToRedeemCount() = 0; //argc: 0, index 34
    virtual unknown_ret GetGuestPassToGiveInfo() = 0; //argc: 9, index 35
    virtual unknown_ret GetGuestPassToGiveOut() = 0; //argc: 1, index 36
    virtual unknown_ret GetGuestPassToRedeem() = 0; //argc: 1, index 37
    virtual unknown_ret GetGuestPassToRedeemInfo() = 0; //argc: 7, index 38
    virtual unknown_ret GetGuestPassToRedeemSenderName() = 0; //argc: 3, index 39
    virtual unknown_ret GetNumAppsInGuestPassesToRedeem() = 0; //argc: 0, index 40
    virtual unknown_ret GetAppsInGuestPassesToRedeem() = 0; //argc: 2, index 41
    virtual unknown_ret GetCountUserNotifications() = 0; //argc: 0, index 42
    virtual unknown_ret GetCountUserNotification() = 0; //argc: 1, index 43
    virtual unknown_ret RequestStoreAuthURL() = 0; //argc: 1, index 44
    virtual unknown_ret SetLanguage() = 0; //argc: 1, index 45
    virtual unknown_ret TrackAppUsageEvent() = 0; //argc: 3, index 46
    virtual unknown_ret RaiseConnectionPriority() = 0; //argc: 2, index 47
    virtual unknown_ret ResetConnectionPriority() = 0; //argc: 1, index 48
    virtual unknown_ret GetDesiredNetQOSLevel() = 0; //argc: 0, index 49
    virtual unknown_ret BHasCachedCredentials() = 0; //argc: 1, index 50
    virtual unknown_ret SetAccountNameForCachedCredentialLogin() = 0; //argc: 2, index 51
    virtual unknown_ret DestroyCachedCredentials() = 0; //argc: 2, index 52
    virtual unknown_ret GetCurrentWebAuthToken() = 0; //argc: 2, index 53
    virtual unknown_ret RequestWebAuthToken() = 0; //argc: 0, index 54
    virtual unknown_ret SetLoginInformation() = 0; //argc: 3, index 55
    virtual unknown_ret SetTwoFactorCode() = 0; //argc: 1, index 56
    virtual unknown_ret SetLoginToken() = 0; //argc: 2, index 57
    virtual unknown_ret GetLoginTokenID() = 0; //argc: 0, index 58
    virtual unknown_ret ClearAllLoginInformation() = 0; //argc: 0, index 59
    virtual unknown_ret BEnableEmbeddedClient() = 0; //argc: 1, index 60
    virtual unknown_ret ResetEmbeddedClient() = 0; //argc: 1, index 61
    virtual unknown_ret BHasEmbeddedClientToken() = 0; //argc: 1, index 62
    virtual unknown_ret RequestEmbeddedClientToken() = 0; //argc: 1, index 63
    virtual unknown_ret AuthorizeNewDevice() = 0; //argc: 3, index 64
    virtual unknown_ret GetLanguage() = 0; //argc: 2, index 65
    virtual unknown_ret TrackSteamUsageEvent() = 0; //argc: 3, index 66
    virtual unknown_ret SetComputerInUse() = 0; //argc: 0, index 67
    virtual unknown_ret BIsGameRunning() = 0; //argc: 1, index 68
    virtual unknown_ret BIsGameWindowReady() = 0; //argc: 1, index 69
    virtual unknown_ret BUpdateAppOwnershipTicket() = 0; //argc: 2, index 70
    virtual unknown_ret GetCustomBinariesState() = 0; //argc: 3, index 71
    virtual unknown_ret RequestCustomBinaries() = 0; //argc: 4, index 72
    virtual unknown_ret SetCellID() = 0; //argc: 1, index 73
    virtual unknown_ret GetCellList() = 0; //argc: 1, index 74
    virtual const char *GetUserBaseFolder() = 0; //argc: 0, index 75
    virtual unknown_ret GetUserDataFolder() = 0; //argc: 3, index 76
    virtual unknown_ret GetUserConfigFolder() = 0; //argc: 2, index 77
    virtual bool GetAccountName(char* buf, int bufLen) = 0; //argc: 2, index 78
    virtual int GetAccountName(CSteamID steamid, char* buf, int bufLen) = 0; //argc: 4, index 79
    virtual unknown_ret IsPasswordRemembered() = 0; //argc: 0, index 80
    virtual unknown_ret IsSiteLicenseAssociationPending() = 0; //argc: 0, index 81
    virtual unknown_ret CheckoutSiteLicenseSeat() = 0; //argc: 1, index 82
    virtual unknown_ret GetAvailableSeats() = 0; //argc: 1, index 83
    virtual unknown_ret GetAssociatedSiteName() = 0; //argc: 0, index 84
    virtual unknown_ret BIsRunningInCafe() = 0; //argc: 0, index 85
    virtual unknown_ret BAllowCachedCredentialsInCafe() = 0; //argc: 0, index 86
    virtual unknown_ret RequiresLegacyCDKey() = 0; //argc: 2, index 87
    virtual unknown_ret GetLegacyCDKey() = 0; //argc: 3, index 88
    virtual unknown_ret SetLegacyCDKey() = 0; //argc: 2, index 89
    virtual unknown_ret WriteLegacyCDKey() = 0; //argc: 1, index 90
    virtual unknown_ret RemoveLegacyCDKey() = 0; //argc: 1, index 91
    virtual unknown_ret RequestLegacyCDKeyFromApp() = 0; //argc: 3, index 92
    virtual unknown_ret BIsAnyGameRunning() = 0; //argc: 0, index 93
    virtual unknown_ret GetSteamGuardDetails() = 0; //argc: 0, index 94
    virtual unknown_ret GetSentryFileData() = 0; //argc: 1, index 95
    virtual unknown_ret GetTwoFactorDetails() = 0; //argc: 0, index 96
    virtual unknown_ret BHasTwoFactor() = 0; //argc: 0, index 97
    virtual unknown_ret GetEmail() = 0; //argc: 3, index 98
    virtual unknown_ret Test_FakeConnectionTimeout() = 0; //argc: 0, index 99
    virtual unknown_ret RunInstallScript() = 0; //argc: 3, index 100
    virtual unknown_ret IsInstallScriptRunning() = 0; //argc: 0, index 101
    virtual unknown_ret GetInstallScriptState() = 0; //argc: 4, index 102
    virtual unknown_ret StopInstallScript() = 0; //argc: 1, index 103
    virtual unknown_ret ResetInstallScript() = 0; //argc: 1, index 104
    virtual unknown_ret SpawnProcess() = 0; //argc: 9, index 105
    virtual unknown_ret GetAppOwnershipTicketLength() = 0; //argc: 1, index 106
    virtual unknown_ret GetAppOwnershipTicketData() = 0; //argc: 3, index 107
    virtual unknown_ret GetAppOwnershipTicketExtendedData() = 0; //argc: 7, index 108
    virtual unknown_ret GetMarketingMessageCount() = 0; //argc: 0, index 109
    virtual unknown_ret GetMarketingMessage() = 0; //argc: 5, index 110
    virtual unknown_ret MarkMarketingMessageSeen() = 0; //argc: 2, index 111
    virtual unknown_ret CheckForPendingMarketingMessages() = 0; //argc: 0, index 112
    virtual unknown_ret GetAuthSessionTicket() = 0; //argc: 3, index 113
    virtual unknown_ret GetAuthSessionTicketV2() = 0; //argc: 4, index 114
    virtual unknown_ret GetAuthSessionTicketV3() = 0; //argc: 4, index 115
    virtual unknown_ret GetAuthTicketForWebApi() = 0; //argc: 1, index 116
    virtual unknown_ret GetAuthSessionTicketForGameID() = 0; //argc: 5, index 117
    virtual unknown_ret BeginAuthSession() = 0; //argc: 4, index 118
    virtual unknown_ret EndAuthSession() = 0; //argc: 2, index 119
    virtual unknown_ret CancelAuthTicket() = 0; //argc: 1, index 120
    virtual unknown_ret IsUserSubscribedAppInTicket() = 0; //argc: 3, index 121
    virtual unknown_ret AdvertiseGame() = 0; //argc: 5, index 122
    virtual unknown_ret RequestEncryptedAppTicket() = 0; //argc: 2, index 123
    virtual unknown_ret GetEncryptedAppTicket() = 0; //argc: 3, index 124
    virtual unknown_ret GetGameBadgeLevel() = 0; //argc: 2, index 125
    virtual unknown_ret GetPlayerSteamLevel() = 0; //argc: 0, index 126
    virtual unknown_ret SetAccountLimited() = 0; //argc: 1, index 127
    virtual unknown_ret BIsAccountLimited() = 0; //argc: 0, index 128
    virtual unknown_ret SetAccountCommunityBanned() = 0; //argc: 1, index 129
    virtual unknown_ret BIsAccountCommunityBanned() = 0; //argc: 0, index 130
    virtual unknown_ret SetLimitedAccountCanInviteFriends() = 0; //argc: 1, index 131
    virtual unknown_ret BLimitedAccountCanInviteFriends() = 0; //argc: 0, index 132
    virtual unknown_ret SendValidationEmail() = 0; //argc: 0, index 133
    virtual unknown_ret BGameConnectTokensAvailable() = 0; //argc: 0, index 134
    virtual unknown_ret NumGamesRunning() = 0; //argc: 0, index 135
    virtual unknown_ret GetRunningGameID() = 0; //argc: 2, index 136
    virtual unknown_ret GetRunningGamePID() = 0; //argc: 1, index 137
    virtual unknown_ret RaiseWindowForGame() = 0; //argc: 1, index 138
    virtual unknown_ret GetAccountSecurityPolicyFlags() = 0; //argc: 0, index 139
    virtual unknown_ret SetClientStat() = 0; //argc: 6, index 140
    virtual unknown_ret VerifyPassword() = 0; //argc: 1, index 141
    virtual unknown_ret BSupportUser() = 0; //argc: 0, index 142
    virtual unknown_ret BNeedsSSANextSteamLogon() = 0; //argc: 0, index 143
    virtual unknown_ret ClearNeedsSSANextSteamLogon() = 0; //argc: 0, index 144
    virtual unknown_ret BIsAppOverlayEnabled() = 0; //argc: 1, index 145
    virtual unknown_ret BOverlayIgnoreChildProcesses() = 0; //argc: 1, index 146
    virtual unknown_ret SetOverlayState() = 0; //argc: 2, index 147
    virtual unknown_ret NotifyOverlaySettingsChanged() = 0; //argc: 0, index 148
    virtual unknown_ret BIsBehindNAT() = 0; //argc: 0, index 149
    virtual unknown_ret GetMicroTxnAppID() = 0; //argc: 2, index 150
    virtual unknown_ret GetMicroTxnOrderID() = 0; //argc: 2, index 151
    virtual unknown_ret BGetMicroTxnPrice() = 0; //argc: 6, index 152
    virtual unknown_ret GetMicroTxnSteamRealm() = 0; //argc: 2, index 153
    virtual unknown_ret GetMicroTxnLineItemCount() = 0; //argc: 2, index 154
    virtual unknown_ret BGetMicroTxnLineItem() = 0; //argc: 11, index 155
    virtual unknown_ret BIsSandboxMicroTxn() = 0; //argc: 3, index 156
    virtual unknown_ret BMicroTxnRequiresCachedPmtMethod() = 0; //argc: 3, index 157
    virtual unknown_ret AuthorizeMicroTxn() = 0; //argc: 3, index 158
    virtual unknown_ret BGetWalletBalance() = 0; //argc: 3, index 159
    virtual unknown_ret RequestMicroTxnInfo() = 0; //argc: 2, index 160
    virtual unknown_ret BMicroTxnRefundable() = 0; //argc: 2, index 161
    virtual unknown_ret BGetAppMinutesPlayed() = 0; //argc: 3, index 162
    virtual unknown_ret GetAppLastPlayedTime() = 0; //argc: 1, index 163
    virtual unknown_ret GetAppUpdateDisabledSecondsRemaining() = 0; //argc: 1, index 164
    virtual unknown_ret BGetGuideURL() = 0; //argc: 3, index 165
    virtual unknown_ret BPromptToChangePassword() = 0; //argc: 0, index 166
    virtual unknown_ret BAccountExtraSecurity() = 0; //argc: 0, index 167
    virtual unknown_ret BAccountShouldShowLockUI() = 0; //argc: 0, index 168
    virtual unknown_ret GetCountAuthedComputers() = 0; //argc: 0, index 169
    virtual unknown_ret GetSteamGuardEnabledTime() = 0; //argc: 0, index 170
    virtual unknown_ret SetPhoneIsVerified() = 0; //argc: 1, index 171
    virtual unknown_ret BIsPhoneVerified() = 0; //argc: 0, index 172
    virtual unknown_ret SetPhoneIsIdentifying() = 0; //argc: 1, index 173
    virtual unknown_ret BIsPhoneIdentifying() = 0; //argc: 0, index 174
    virtual unknown_ret SetPhoneIsRequiringVerification() = 0; //argc: 1, index 175
    virtual unknown_ret BIsPhoneRequiringVerification() = 0; //argc: 0, index 176
    virtual unknown_ret Set2ndFactorAuthCode() = 0; //argc: 2, index 177
    virtual unknown_ret SetUserMachineName() = 0; //argc: 1, index 178
    virtual unknown_ret GetUserMachineName() = 0; //argc: 2, index 179
    virtual unknown_ret GetEmailDomainFromLogonFailure() = 0; //argc: 2, index 180
    virtual unknown_ret GetAgreementSessionUrl() = 0; //argc: 0, index 181
    virtual unknown_ret GetDurationControl() = 0; //argc: 0, index 182
    virtual unknown_ret GetDurationControlForApp() = 0; //argc: 1, index 183
    virtual unknown_ret BSetDurationControlOnlineState() = 0; //argc: 1, index 184
    virtual unknown_ret BSetDurationControlOnlineStateForApp() = 0; //argc: 2, index 185
    virtual unknown_ret BGetDurationControlExtendedResults() = 0; //argc: 3, index 186
    virtual unknown_ret BIsSubscribedApp() = 0; //argc: 1, index 187
    virtual unknown_ret GetSubscribedApps() = 0; //argc: 3, index 188
    virtual unknown_ret AckSystemIM() = 0; //argc: 2, index 189
    virtual unknown_ret RequestSpecialSurvey() = 0; //argc: 1, index 190
    virtual unknown_ret SendSpecialSurveyResponse() = 0; //argc: 3, index 191
    virtual unknown_ret RequestNotifications() = 0; //argc: 0, index 192
    virtual unknown_ret GetAppOwnershipInfo() = 0; //argc: 4, index 193
    virtual unknown_ret SendGameWebCallback() = 0; //argc: 2, index 194
    virtual unknown_ret BIsStreamingUIToRemoteDevice() = 0; //argc: 0, index 195
    virtual unknown_ret BIsCurrentlyNVStreaming() = 0; //argc: 0, index 196
    virtual unknown_ret OnBigPictureForStreamingStartResult() = 0; //argc: 2, index 197
    virtual unknown_ret OnBigPictureForStreamingDone() = 0; //argc: 0, index 198
    virtual unknown_ret OnBigPictureForStreamingRestarting() = 0; //argc: 0, index 199
    virtual unknown_ret StopStreaming() = 0; //argc: 1, index 200
    virtual unknown_ret GetAllAccountFlags() = 0; //argc: 0, index 201
    virtual unknown_ret LockParentalLock() = 0; //argc: 0, index 202
    virtual unknown_ret UnlockParentalLock() = 0; //argc: 1, index 203
    virtual unknown_ret BIsParentalLockEnabled() = 0; //argc: 0, index 204
    virtual unknown_ret BIsParentalLockLocked() = 0; //argc: 0, index 205
    virtual unknown_ret BIsAppBlocked() = 0; //argc: 1, index 206
    virtual unknown_ret BIsAppInBlockList() = 0; //argc: 1, index 207
    virtual unknown_ret BIsFeatureBlocked() = 0; //argc: 1, index 208
    virtual unknown_ret BIsFeatureInBlockList() = 0; //argc: 1, index 209
    virtual unknown_ret GetParentalUnlockTime() = 0; //argc: 0, index 210
    virtual unknown_ret BGetRecoveryEmail() = 0; //argc: 2, index 211
    virtual unknown_ret BIsLockFromSiteLicense() = 0; //argc: 0, index 212
    virtual unknown_ret EIsParentalPlaytimeBlocked() = 0; //argc: 0, index 213
    virtual unknown_ret BGetSerializedParentalSettings() = 0; //argc: 1, index 214
    virtual unknown_ret BGetParentalWebToken() = 0; //argc: 2, index 215
    virtual unknown_ret GetCommunityPreference() = 0; //argc: 1, index 216
    virtual unknown_ret SetCommunityPreference() = 0; //argc: 2, index 217
    virtual unknown_ret GetTextFilterSetting() = 0; //argc: 0, index 218
    virtual unknown_ret BTextFilterIgnoresFriends() = 0; //argc: 0, index 219
    virtual unknown_ret CanLogonOffline() = 0; //argc: 0, index 220
    virtual unknown_ret LogOnOffline() = 0; //argc: 1, index 221
    virtual unknown_ret ValidateOfflineLogonTicket() = 0; //argc: 1, index 222
    virtual unknown_ret BGetOfflineLogonTicket() = 0; //argc: 2, index 223
    virtual unknown_ret UploadLocalClientLogs() = 0; //argc: 0, index 224
    virtual unknown_ret SetAsyncNotificationEnabled() = 0; //argc: 2, index 225
    virtual unknown_ret BIsOtherSessionPlaying() = 0; //argc: 1, index 226
    virtual unknown_ret BKickOtherPlayingSession() = 0; //argc: 0, index 227
    virtual unknown_ret BIsAccountLockedDown() = 0; //argc: 0, index 228
    virtual unknown_ret RequestAccountLinkInfo() = 0; //argc: 0, index 229
    virtual unknown_ret RequestSurveySchedule() = 0; //argc: 0, index 230
    virtual unknown_ret RequestNewSteamAnnouncementState() = 0; //argc: 0, index 231
    virtual unknown_ret UpdateSteamAnnouncementLastRead() = 0; //argc: 3, index 232
    virtual unknown_ret GetMarketEligibility() = 0; //argc: 0, index 233
    virtual unknown_ret UpdateGameVrDllState() = 0; //argc: 3, index 234
    virtual unknown_ret KillVRTheaterPancakeGame() = 0; //argc: 1, index 235
    virtual unknown_ret SetVRIsHMDAwake() = 0; //argc: 1, index 236
    virtual unknown_ret BIsAnyGameOrServiceAppRunning() = 0; //argc: 0, index 237
    virtual unknown_ret BGetAppPlaytimeMap() = 0; //argc: 1, index 238
    virtual unknown_ret BGetAppsLastPlayedMap() = 0; //argc: 1, index 239
    virtual unknown_ret SendSteamServiceStatusUpdate() = 0; //argc: 2, index 240
    virtual unknown_ret RequestSteamGroupChatMessageNotifications() = 0; //argc: 5, index 241
    virtual unknown_ret RequestSteamGroupChatMessageHistory() = 0; //argc: 5, index 242
    virtual unknown_ret RequestSendSteamGroupChatMessage() = 0; //argc: 6, index 243
    virtual unknown_ret OnNewGroupChatMsgAdded() = 0; //argc: 8, index 244
    virtual unknown_ret OnGroupChatUserStateChange() = 0; //argc: 4, index 245
    virtual unknown_ret OnReceivedGroupChatSubscriptionResponse() = 0; //argc: 5, index 246
    virtual unknown_ret GetTimedTrialStatus() = 0; //argc: 4, index 247
    virtual unknown_ret RequestTimedTrialStatus() = 0; //argc: 1, index 248
    virtual unknown_ret PrepareForSystemSuspend() = 0; //argc: 0, index 249
    virtual unknown_ret ResumeSuspendedGames() = 0; //argc: 1, index 250
    virtual unknown_ret GetClientInstallationID() = 0; //argc: 0, index 251
    virtual unknown_ret GetAppIDForGameID() = 0; //argc: 1, index 252
    virtual unknown_ret BDoNotDisturb() = 0; //argc: 0, index 253
    virtual unknown_ret SetAdditionalClientArgData() = 0; //argc: 1, index 254
    virtual unknown_ret GetFamilyGroupID() = 0; //argc: 0, index 255
    virtual unknown_ret GetFamilyGroupName() = 0; //argc: 0, index 256
    virtual unknown_ret GetFamilyGroupRole() = 0; //argc: 0, index 257
    virtual unknown_ret GetFamilyGroupMembers() = 0; //argc: 2, index 258
    virtual unknown_ret GetSharedAppLockInfo() = 0; //argc: 5, index 259
    virtual unknown_ret GetFamilyDLCForApp() = 0; //argc: 2, index 260
    virtual unknown_ret SetPreferredLender() = 0; //argc: 2, index 261
    virtual unknown_ret GetFamilyCopyCounts() = 0; //argc: 1, index 262
    virtual unknown_ret NotifyPendingGameLaunch_FetchSteamStreamingEncoderConfig() = 0; //argc: 1, index 263
    virtual unknown_ret BShouldWaitForSteamStreamingEncoderConfig() = 0; //argc: 1, index 264
    virtual unknown_ret BGetProcessIDsForGame() = 0; //argc: 3, index 265
    virtual unknown_ret CancelLicenseForApp() = 0; //argc: 1, index 266
};