//==========================  AUTO-GENERATED FILE  ================================
//
// This file is partially auto-generated.
// If functions are removed, your changes to that function will be lost.
// Parameter types and names however are preserved if the function stays unchanged.
// Feel free to change parameters to be more accurate. 
//=============================================================================

using System;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;

using OpenSteamworks.Data.Structs;
using OpenSteamworks.Data;
using CppSourceGen.Attributes;

namespace OpenSteamworks.Generated;

[CppClass]
public unsafe interface IClientGameServerInternal
{
    // WARNING: Do not use this function! Unknown behaviour will occur!
    public unknown Unknown_0_DONTUSE();  // argc: -1, index: 1, ipc args: [], ipc returns: []
    // WARNING: Do not use this function! Unknown behaviour will occur!
    public unknown Unknown_1_DONTUSE();  // argc: -1, index: 2, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetSDRLogin(CUtlBuffer* buf);  // argc: 1, index: 3, ipc args: [unknown], ipc returns: []
    // WARNING: Do not use this function! Unknown behaviour will occur!
    public unknown Unknown_3_DONTUSE();  // argc: -1, index: 4, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown InitGameServerSerialized();  // argc: 8, index: 5, ipc args: [bytes4, bytes2, bytes2, bytes4, bytes4, string, bytes4], ipc returns: [bytes1, bytes_length_from_mem]
    // WARNING: Arguments are unknown!
    public unknown SetProduct(string product);  // argc: 1, index: 6, ipc args: [string], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetGameDescription(string desc);  // argc: 1, index: 7, ipc args: [string], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetModDir(string dir);  // argc: 1, index: 8, ipc args: [string], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetDedicatedServer(bool val);  // argc: 1, index: 9, ipc args: [bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown LogOn(string unk);  // argc: 1, index: 10, ipc args: [string], ipc returns: []
    public unknown LogOnAnonymous();  // argc: 0, index: 11, ipc args: [], ipc returns: []
    public unknown LogOff();  // argc: 0, index: 12, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public CSteamID GetSteamID();  // argc: 1, index: 13, ipc args: [], ipc returns: [uint64]
    public bool BLoggedOn();  // argc: 0, index: 14, ipc args: [], ipc returns: [boolean]
    public bool BSecure();  // argc: 0, index: 15, ipc args: [], ipc returns: [boolean]
    public unknown WasRestartRequested();  // argc: 0, index: 16, ipc args: [], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetMaxPlayerCount(int maxPlayerCount);  // argc: 1, index: 17, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetBotPlayerCount(int maxPlayerCount);  // argc: 1, index: 18, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetServerName(string name);  // argc: 1, index: 19, ipc args: [string], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetMapName(string name);  // argc: 1, index: 20, ipc args: [string], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetPasswordProtected(bool isPasswordProtected);  // argc: 1, index: 21, ipc args: [bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetSpectatorPort();  // argc: 1, index: 22, ipc args: [bytes2], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetSpectatorServerName();  // argc: 1, index: 23, ipc args: [string], ipc returns: []
    public unknown ClearAllKeyValues();  // argc: 0, index: 24, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetKeyValue();  // argc: 2, index: 25, ipc args: [string, string], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetGameTags();  // argc: 1, index: 26, ipc args: [string], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetGameData();  // argc: 1, index: 27, ipc args: [string], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetRegion(string region);  // argc: 1, index: 28, ipc args: [string], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SendUserConnectAndAuthenticate();  // argc: 4, index: 29, ipc args: [bytes4, bytes4, bytes_length_from_mem], ipc returns: [bytes4, uint64]
    // WARNING: Arguments are unknown!
    public unknown CreateUnauthenticatedUserConnection();  // argc: 1, index: 30, ipc args: [], ipc returns: [uint64]
    // WARNING: Arguments are unknown!
    public unknown SendUserDisconnect();  // argc: 2, index: 31, ipc args: [uint64], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown BUpdateUserData();  // argc: 4, index: 32, ipc args: [uint64, string, bytes4], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown GetAuthSessionTicket();  // argc: 3, index: 33, ipc args: [bytes4], ipc returns: [bytes4, bytes_length_from_mem, bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetAuthSessionTicketV2();  // argc: 4, index: 34, ipc args: [bytes4, steamnetworkingidentity], ipc returns: [bytes4, bytes_length_from_mem, bytes4]
    // WARNING: Arguments are unknown!
    public unknown BeginAuthSession();  // argc: 4, index: 35, ipc args: [bytes4, bytes_length_from_mem, uint64], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown EndAuthSession();  // argc: 2, index: 36, ipc args: [uint64], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown CancelAuthTicket();  // argc: 1, index: 37, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown IsUserSubscribedAppInTicket();  // argc: 3, index: 38, ipc args: [uint64, bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown RequestUserGroupStatus();  // argc: 4, index: 39, ipc args: [uint64, uint64], ipc returns: [bytes1]
    public unknown GetGameplayStats();  // argc: 0, index: 40, ipc args: [], ipc returns: []
    public unknown GetServerReputation();  // argc: 0, index: 41, ipc args: [], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown GetPublicIP();  // argc: 1, index: 42, ipc args: [], ipc returns: [bytes20]
    // WARNING: Arguments are unknown!
    public unknown EnableHeartbeats();  // argc: 1, index: 43, ipc args: [bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetHeartbeatInterval();  // argc: 1, index: 44, ipc args: [bytes4], ipc returns: []
    public unknown ForceHeartbeat();  // argc: 0, index: 45, ipc args: [], ipc returns: []
    public ELogonState GetLogonState();  // argc: 0, index: 46, ipc args: [], ipc returns: [bytes4]
    public bool BConnected();  // argc: 0, index: 47, ipc args: [], ipc returns: [boolean]
    // WARNING: Arguments are unknown!§
    public unknown RaiseConnectionPriority();  // argc: 1, index: 48, ipc args: [bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown ResetConnectionPriority();  // argc: 1, index: 49, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetCellID(uint cellid);  // argc: 1, index: 50, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown TrackSteamUsageEvent();  // argc: 3, index: 51, ipc args: [bytes4, bytes4, bytes_length_from_mem], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetCountOfSimultaneousGuestUsersPerSteamAccount();  // argc: 1, index: 52, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown EnumerateConnectedUsers();  // argc: 2, index: 53, ipc args: [bytes4], ipc returns: [bytes1, bytes40]
    // WARNING: Arguments are unknown!
    public unknown AssociateWithClan();  // argc: 2, index: 54, ipc args: [uint64], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown ComputeNewPlayerCompatibility();  // argc: 2, index: 55, ipc args: [uint64], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown _BGetUserAchievementStatus();  // argc: 3, index: 56, ipc args: [uint64, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown _GSSetSpawnCount();  // argc: 1, index: 57, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown _GSGetSteam2GetEncryptionKeyToSendToNewClient();  // argc: 3, index: 58, ipc args: [bytes4], ipc returns: [bytes1, bytes4, bytes_length_from_mem]
    // WARNING: Arguments are unknown!
    public unknown _GSSendSteam2UserConnect();  // argc: 7, index: 59, ipc args: [bytes4, bytes4, bytes_length_from_mem, bytes4, bytes2, bytes4, bytes_length_from_mem], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown _GSSendSteam3UserConnect();  // argc: 5, index: 60, ipc args: [uint64, bytes4, bytes4, bytes_length_from_mem], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown _GSSendUserConnect();  // argc: 5, index: 61, ipc args: [bytes4, bytes4, bytes2, bytes4, bytes_length_from_mem], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown _GSRemoveUserConnect();  // argc: 1, index: 62, ipc args: [bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown _GSUpdateStatus();  // argc: 6, index: 63, ipc args: [bytes4, bytes4, bytes4, string, string, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown _GSCreateUnauthenticatedUser();  // argc: 1, index: 64, ipc args: [], ipc returns: [bytes1, uint64]
    // WARNING: Arguments are unknown!
    public unknown _GSSetServerType();  // argc: 9, index: 65, ipc args: [bytes4, bytes4, bytes4, bytes2, bytes2, bytes2, string, string, bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown _SetBasicServerData();  // argc: 7, index: 66, ipc args: [bytes2, bytes1, string, string, bytes2, bytes1, string], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown _GSSendUserDisconnect();  // argc: 3, index: 67, ipc args: [uint64, bytes4], ipc returns: [bytes1]
}