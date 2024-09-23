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

class IClientGameServerInternal
{
public:
    virtual unknown_ret Unknown_0_DONTUSE() = 0; //argc: -1, index 1
    virtual unknown_ret Unknown_1_DONTUSE() = 0; //argc: -1, index 2
    virtual unknown_ret SetSDRLogin() = 0; //argc: 1, index 3
    virtual unknown_ret Unknown_3_DONTUSE() = 0; //argc: -1, index 4
    virtual unknown_ret InitGameServerSerialized() = 0; //argc: 8, index 5
    virtual unknown_ret SetProduct() = 0; //argc: 1, index 6
    virtual unknown_ret SetGameDescription() = 0; //argc: 1, index 7
    virtual unknown_ret SetModDir() = 0; //argc: 1, index 8
    virtual unknown_ret SetDedicatedServer() = 0; //argc: 1, index 9
    virtual unknown_ret LogOn() = 0; //argc: 1, index 10
    virtual unknown_ret LogOnAnonymous() = 0; //argc: 0, index 11
    virtual unknown_ret LogOff() = 0; //argc: 0, index 12
    virtual unknown_ret GetSteamID() = 0; //argc: 1, index 13
    virtual unknown_ret BLoggedOn() = 0; //argc: 0, index 14
    virtual unknown_ret BSecure() = 0; //argc: 0, index 15
    virtual unknown_ret WasRestartRequested() = 0; //argc: 0, index 16
    virtual unknown_ret SetMaxPlayerCount() = 0; //argc: 1, index 17
    virtual unknown_ret SetBotPlayerCount() = 0; //argc: 1, index 18
    virtual unknown_ret SetServerName() = 0; //argc: 1, index 19
    virtual unknown_ret SetMapName() = 0; //argc: 1, index 20
    virtual unknown_ret SetPasswordProtected() = 0; //argc: 1, index 21
    virtual unknown_ret SetSpectatorPort() = 0; //argc: 1, index 22
    virtual unknown_ret SetSpectatorServerName() = 0; //argc: 1, index 23
    virtual unknown_ret ClearAllKeyValues() = 0; //argc: 0, index 24
    virtual unknown_ret SetKeyValue() = 0; //argc: 2, index 25
    virtual unknown_ret SetGameTags() = 0; //argc: 1, index 26
    virtual unknown_ret SetGameData() = 0; //argc: 1, index 27
    virtual unknown_ret SetRegion() = 0; //argc: 1, index 28
    virtual unknown_ret SendUserConnectAndAuthenticate() = 0; //argc: 4, index 29
    virtual unknown_ret CreateUnauthenticatedUserConnection() = 0; //argc: 1, index 30
    virtual unknown_ret SendUserDisconnect() = 0; //argc: 2, index 31
    virtual unknown_ret BUpdateUserData() = 0; //argc: 4, index 32
    virtual unknown_ret GetAuthSessionTicket() = 0; //argc: 3, index 33
    virtual unknown_ret GetAuthSessionTicketV2() = 0; //argc: 4, index 34
    virtual unknown_ret BeginAuthSession() = 0; //argc: 4, index 35
    virtual unknown_ret EndAuthSession() = 0; //argc: 2, index 36
    virtual unknown_ret CancelAuthTicket() = 0; //argc: 1, index 37
    virtual unknown_ret IsUserSubscribedAppInTicket() = 0; //argc: 3, index 38
    virtual unknown_ret RequestUserGroupStatus() = 0; //argc: 4, index 39
    virtual unknown_ret GetGameplayStats() = 0; //argc: 0, index 40
    virtual unknown_ret GetServerReputation() = 0; //argc: 0, index 41
    virtual unknown_ret GetPublicIP() = 0; //argc: 1, index 42
    virtual unknown_ret EnableHeartbeats() = 0; //argc: 1, index 43
    virtual unknown_ret SetHeartbeatInterval() = 0; //argc: 1, index 44
    virtual unknown_ret ForceHeartbeat() = 0; //argc: 0, index 45
    virtual unknown_ret GetLogonState() = 0; //argc: 0, index 46
    virtual unknown_ret BConnected() = 0; //argc: 0, index 47
    virtual unknown_ret RaiseConnectionPriority() = 0; //argc: 1, index 48
    virtual unknown_ret ResetConnectionPriority() = 0; //argc: 1, index 49
    virtual unknown_ret SetCellID() = 0; //argc: 1, index 50
    virtual unknown_ret TrackSteamUsageEvent() = 0; //argc: 3, index 51
    virtual unknown_ret SetCountOfSimultaneousGuestUsersPerSteamAccount() = 0; //argc: 1, index 52
    virtual unknown_ret EnumerateConnectedUsers() = 0; //argc: 2, index 53
    virtual unknown_ret AssociateWithClan() = 0; //argc: 2, index 54
    virtual unknown_ret ComputeNewPlayerCompatibility() = 0; //argc: 2, index 55
    virtual unknown_ret _BGetUserAchievementStatus() = 0; //argc: 3, index 56
    virtual unknown_ret _GSSetSpawnCount() = 0; //argc: 1, index 57
    virtual unknown_ret _GSGetSteam2GetEncryptionKeyToSendToNewClient() = 0; //argc: 3, index 58
    virtual unknown_ret _GSSendSteam2UserConnect() = 0; //argc: 7, index 59
    virtual unknown_ret _GSSendSteam3UserConnect() = 0; //argc: 5, index 60
    virtual unknown_ret _GSSendUserConnect() = 0; //argc: 5, index 61
    virtual unknown_ret _GSRemoveUserConnect() = 0; //argc: 1, index 62
    virtual unknown_ret _GSUpdateStatus() = 0; //argc: 6, index 63
    virtual unknown_ret _GSCreateUnauthenticatedUser() = 0; //argc: 1, index 64
    virtual unknown_ret _GSSetServerType() = 0; //argc: 9, index 65
    virtual unknown_ret _SetBasicServerData() = 0; //argc: 7, index 66
    virtual unknown_ret _GSSendUserDisconnect() = 0; //argc: 3, index 67
};