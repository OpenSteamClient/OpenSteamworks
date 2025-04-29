//==========================  AUTO-GENERATED FILE  ================================
//
// This file is partially auto-generated.
// If functions are removed, your changes to that function will be lost.
// Parameter types and names however are preserved if the function stays unchanged.
// Feel free to change parameters to be more accurate. 
//=============================================================================

using System;
using OpenSteamworks.Attributes;
using OpenSteamworks.Protobuf;
using OpenSteamworks.Data;
using CppSourceGen.Attributes;

namespace OpenSteamworks.Generated;

[CppClass]
public unsafe interface IClientMatchmaking
{
    public unknown GetFavoriteGameCount();  // argc: -1, index: 1, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetFavoriteGame();  // argc: -1, index: 2, ipc args: [bytes4], ipc returns: [bytes1, bytes4, bytes4, bytes2, bytes2, bytes4, bytes4]
    // WARNING: Arguments are unknown!
    public unknown AddFavoriteGame();  // argc: -1, index: 3, ipc args: [bytes4, bytes4, bytes2, bytes2, bytes4, bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown RemoveFavoriteGame();  // argc: -1, index: 4, ipc args: [bytes4, bytes4, bytes2, bytes2, bytes4], ipc returns: [bytes1]
    public unknown RequestLobbyList();  // argc: -1, index: 5, ipc args: [], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown AddRequestLobbyListStringFilter();  // argc: -1, index: 6, ipc args: [string, string, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown AddRequestLobbyListNumericalFilter();  // argc: -1, index: 7, ipc args: [string, bytes4, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown AddRequestLobbyListNearValueFilter();  // argc: -1, index: 8, ipc args: [string, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown AddRequestLobbyListFilterSlotsAvailable();  // argc: -1, index: 9, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown AddRequestLobbyListDistanceFilter();  // argc: -1, index: 10, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown AddRequestLobbyListResultCountFilter();  // argc: -1, index: 11, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown AddRequestLobbyListCompatibleMembersFilter();  // argc: -1, index: 12, ipc args: [uint64], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown GetLobbyByIndex();  // argc: -1, index: 13, ipc args: [bytes4], ipc returns: [uint64]
    // WARNING: Arguments are unknown!
    public unknown CreateLobby();  // argc: -1, index: 14, ipc args: [bytes4, bytes4], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown JoinLobby();  // argc: -1, index: 15, ipc args: [uint64], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown LeaveLobby();  // argc: -1, index: 16, ipc args: [uint64], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown InviteUserToLobby();  // argc: -1, index: 17, ipc args: [uint64, uint64], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown GetNumLobbyMembers();  // argc: -1, index: 18, ipc args: [uint64], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetLobbyMemberByIndex();  // argc: -1, index: 19, ipc args: [uint64, bytes4], ipc returns: [uint64]
    // WARNING: Arguments are unknown!
    public unknown GetLobbyData();  // argc: -1, index: 20, ipc args: [uint64, string], ipc returns: [string]
    // WARNING: Arguments are unknown!
    public unknown SetLobbyData();  // argc: -1, index: 21, ipc args: [uint64, string, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown GetLobbyDataCount();  // argc: -1, index: 22, ipc args: [uint64], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetLobbyDataByIndex();  // argc: -1, index: 23, ipc args: [uint64, bytes4, bytes4, bytes4], ipc returns: [bytes1, bytes_external_length, bytes_external_length]
    // WARNING: Arguments are unknown!
    public unknown DeleteLobbyData();  // argc: -1, index: 24, ipc args: [uint64, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown GetLobbyMemberData();  // argc: -1, index: 25, ipc args: [uint64, uint64, string], ipc returns: [string]
    // WARNING: Arguments are unknown!
    public unknown SetLobbyMemberData();  // argc: -1, index: 26, ipc args: [uint64, string, string], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SendLobbyChatMsg();  // argc: -1, index: 27, ipc args: [uint64, bytes4, bytes_external_length], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown GetLobbyChatEntry();  // argc: -1, index: 28, ipc args: [uint64, bytes4, bytes4], ipc returns: [bytes4, bytes_external_length, uint64, bytes4]
    // WARNING: Arguments are unknown!
    public unknown RequestLobbyData();  // argc: -1, index: 29, ipc args: [uint64], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetLobbyGameServer();  // argc: -1, index: 30, ipc args: [uint64, bytes4, bytes2, uint64], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown GetLobbyGameServer();  // argc: -1, index: 31, ipc args: [uint64], ipc returns: [bytes1, bytes4, bytes2, uint64]
    // WARNING: Arguments are unknown!
    public unknown SetLobbyMemberLimit();  // argc: -1, index: 32, ipc args: [uint64, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown GetLobbyMemberLimit();  // argc: -1, index: 33, ipc args: [uint64], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown SetLobbyVoiceEnabled();  // argc: -1, index: 34, ipc args: [uint64, bytes1], ipc returns: []
    public unknown RequestFriendsLobbies();  // argc: -1, index: 35, ipc args: [], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetLobbyType();  // argc: -1, index: 36, ipc args: [uint64, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetLobbyJoinable();  // argc: -1, index: 37, ipc args: [uint64, bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown GetLobbyOwner();  // argc: -1, index: 38, ipc args: [uint64], ipc returns: [uint64]
    // WARNING: Arguments are unknown!
    public unknown SetLobbyOwner();  // argc: -1, index: 39, ipc args: [uint64, uint64], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetLinkedLobby();  // argc: -1, index: 40, ipc args: [uint64, uint64], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public SteamAPICall_t BeginGMSQuery(AppId_t appid, int regionCode, string searchText);  // argc: -1, index: 41, ipc args: [bytes4, bytes4, string], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown PollGMSQuery(SteamAPICall_t call);  // argc: -1, index: 42, ipc args: [bytes8], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public bool GetGMSQueryResults(SteamAPICall_t call, out GameServerClient_QueryServerData_Response response);  // argc: -1, index: 43, ipc args: [bytes8], ipc returns: [bytes1, protobuf]
    // WARNING: Arguments are unknown!
    public void ReleaseGMSQuery(SteamAPICall_t call);  // argc: -1, index: 44, ipc args: [bytes8], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown QueryServerByFakeIP();  // argc: -1, index: 45, ipc args: [bytes4, bytes2, bytes4, bytes4], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown EnsureFavoriteGameAccountsUpdated();  // argc: -1, index: 46, ipc args: [bytes1], ipc returns: [bytes8]
}