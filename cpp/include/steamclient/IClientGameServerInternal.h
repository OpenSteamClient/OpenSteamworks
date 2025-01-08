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
    virtual unknown Unknown_0_DONTUSE() = 0; //argc: -1, index 1
    virtual unknown Unknown_1_DONTUSE() = 0; //argc: -1, index 2
    virtual unknown SetSDRLogin() = 0; //argc: 1, index 3
    virtual unknown Unknown_3_DONTUSE() = 0; //argc: -1, index 4
    virtual unknown InitGameServerSerialized() = 0; //argc: 8, index 5
    virtual unknown SetProduct() = 0; //argc: 1, index 6
    virtual unknown SetGameDescription() = 0; //argc: 1, index 7
    virtual unknown SetModDir() = 0; //argc: 1, index 8
    virtual unknown SetDedicatedServer() = 0; //argc: 1, index 9
    virtual unknown LogOn() = 0; //argc: 1, index 10
    virtual unknown LogOnAnonymous() = 0; //argc: 0, index 11
    virtual unknown LogOff() = 0; //argc: 0, index 12
    virtual unknown GetSteamID() = 0; //argc: 1, index 13
    virtual unknown BLoggedOn() = 0; //argc: 0, index 14
    virtual unknown BSecure() = 0; //argc: 0, index 15
    virtual unknown WasRestartRequested() = 0; //argc: 0, index 16
    virtual unknown SetMaxPlayerCount() = 0; //argc: 1, index 17
    virtual unknown SetBotPlayerCount() = 0; //argc: 1, index 18
    virtual unknown SetServerName() = 0; //argc: 1, index 19
    virtual unknown SetMapName() = 0; //argc: 1, index 20
    virtual unknown SetPasswordProtected() = 0; //argc: 1, index 21
    virtual unknown SetSpectatorPort() = 0; //argc: 1, index 22
    virtual unknown SetSpectatorServerName() = 0; //argc: 1, index 23
    virtual unknown ClearAllKeyValues() = 0; //argc: 0, index 24
    virtual unknown SetKeyValue() = 0; //argc: 2, index 25
    virtual unknown SetGameTags() = 0; //argc: 1, index 26
    virtual unknown SetGameData() = 0; //argc: 1, index 27
    virtual unknown SetRegion() = 0; //argc: 1, index 28
    virtual unknown SendUserConnectAndAuthenticate() = 0; //argc: 4, index 29
    virtual unknown CreateUnauthenticatedUserConnection() = 0; //argc: 1, index 30
    virtual unknown SendUserDisconnect() = 0; //argc: 2, index 31
    virtual unknown BUpdateUserData() = 0; //argc: 4, index 32
    virtual unknown GetAuthSessionTicket() = 0; //argc: 3, index 33
    virtual unknown GetAuthSessionTicketV2() = 0; //argc: 4, index 34
    virtual unknown BeginAuthSession() = 0; //argc: 4, index 35
    virtual unknown EndAuthSession() = 0; //argc: 2, index 36
    virtual unknown CancelAuthTicket() = 0; //argc: 1, index 37
    virtual unknown IsUserSubscribedAppInTicket() = 0; //argc: 3, index 38
    virtual unknown RequestUserGroupStatus() = 0; //argc: 4, index 39
    virtual unknown GetGameplayStats() = 0; //argc: 0, index 40
    virtual unknown GetServerReputation() = 0; //argc: 0, index 41
    virtual unknown GetPublicIP() = 0; //argc: 1, index 42
    virtual unknown EnableHeartbeats() = 0; //argc: 1, index 43
    virtual unknown SetHeartbeatInterval() = 0; //argc: 1, index 44
    virtual unknown ForceHeartbeat() = 0; //argc: 0, index 45
    virtual unknown GetLogonState() = 0; //argc: 0, index 46
    virtual unknown BConnected() = 0; //argc: 0, index 47
    virtual unknown RaiseConnectionPriority() = 0; //argc: 1, index 48
    virtual unknown ResetConnectionPriority() = 0; //argc: 1, index 49
    virtual unknown SetCellID() = 0; //argc: 1, index 50
    virtual unknown TrackSteamUsageEvent() = 0; //argc: 3, index 51
    virtual unknown SetCountOfSimultaneousGuestUsersPerSteamAccount() = 0; //argc: 1, index 52
    virtual unknown EnumerateConnectedUsers() = 0; //argc: 2, index 53
    virtual unknown AssociateWithClan() = 0; //argc: 2, index 54
    virtual unknown ComputeNewPlayerCompatibility() = 0; //argc: 2, index 55
    virtual unknown _BGetUserAchievementStatus() = 0; //argc: 3, index 56
    virtual unknown _GSSetSpawnCount() = 0; //argc: 1, index 57
    virtual unknown _GSGetSteam2GetEncryptionKeyToSendToNewClient() = 0; //argc: 3, index 58
    virtual unknown _GSSendSteam2UserConnect() = 0; //argc: 7, index 59
    virtual unknown _GSSendSteam3UserConnect() = 0; //argc: 5, index 60
    virtual unknown _GSSendUserConnect() = 0; //argc: 5, index 61
    virtual unknown _GSRemoveUserConnect() = 0; //argc: 1, index 62
    virtual unknown _GSUpdateStatus() = 0; //argc: 6, index 63
    virtual unknown _GSCreateUnauthenticatedUser() = 0; //argc: 1, index 64
    virtual unknown _GSSetServerType() = 0; //argc: 9, index 65
    virtual unknown _SetBasicServerData() = 0; //argc: 7, index 66
    virtual unknown _GSSendUserDisconnect() = 0; //argc: 3, index 67
};