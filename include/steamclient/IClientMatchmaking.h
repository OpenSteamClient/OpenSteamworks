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

class IClientMatchmaking
{
public:
    virtual unknown_ret GetFavoriteGameCount() = 0; //argc: 0, index 1
    virtual unknown_ret GetFavoriteGame() = 0; //argc: 7, index 2
    virtual unknown_ret AddFavoriteGame() = 0; //argc: 6, index 3
    virtual unknown_ret RemoveFavoriteGame() = 0; //argc: 5, index 4
    virtual unknown_ret RequestLobbyList() = 0; //argc: 0, index 5
    virtual unknown_ret AddRequestLobbyListStringFilter() = 0; //argc: 3, index 6
    virtual unknown_ret AddRequestLobbyListNumericalFilter() = 0; //argc: 3, index 7
    virtual unknown_ret AddRequestLobbyListNearValueFilter() = 0; //argc: 2, index 8
    virtual unknown_ret AddRequestLobbyListFilterSlotsAvailable() = 0; //argc: 1, index 9
    virtual unknown_ret AddRequestLobbyListDistanceFilter() = 0; //argc: 1, index 10
    virtual unknown_ret AddRequestLobbyListResultCountFilter() = 0; //argc: 1, index 11
    virtual unknown_ret AddRequestLobbyListCompatibleMembersFilter() = 0; //argc: 2, index 12
    virtual unknown_ret GetLobbyByIndex() = 0; //argc: 2, index 13
    virtual unknown_ret CreateLobby() = 0; //argc: 2, index 14
    virtual unknown_ret JoinLobby() = 0; //argc: 2, index 15
    virtual unknown_ret LeaveLobby() = 0; //argc: 2, index 16
    virtual unknown_ret InviteUserToLobby() = 0; //argc: 4, index 17
    virtual unknown_ret GetNumLobbyMembers() = 0; //argc: 2, index 18
    virtual unknown_ret GetLobbyMemberByIndex() = 0; //argc: 4, index 19
    virtual unknown_ret GetLobbyData() = 0; //argc: 3, index 20
    virtual unknown_ret SetLobbyData() = 0; //argc: 4, index 21
    virtual unknown_ret GetLobbyDataCount() = 0; //argc: 2, index 22
    virtual unknown_ret GetLobbyDataByIndex() = 0; //argc: 7, index 23
    virtual unknown_ret DeleteLobbyData() = 0; //argc: 3, index 24
    virtual unknown_ret GetLobbyMemberData() = 0; //argc: 5, index 25
    virtual unknown_ret SetLobbyMemberData() = 0; //argc: 4, index 26
    virtual unknown_ret SendLobbyChatMsg() = 0; //argc: 4, index 27
    virtual unknown_ret GetLobbyChatEntry() = 0; //argc: 7, index 28
    virtual unknown_ret RequestLobbyData() = 0; //argc: 2, index 29
    virtual unknown_ret SetLobbyGameServer() = 0; //argc: 6, index 30
    virtual unknown_ret GetLobbyGameServer() = 0; //argc: 5, index 31
    virtual unknown_ret SetLobbyMemberLimit() = 0; //argc: 3, index 32
    virtual unknown_ret GetLobbyMemberLimit() = 0; //argc: 2, index 33
    virtual unknown_ret SetLobbyVoiceEnabled() = 0; //argc: 3, index 34
    virtual unknown_ret RequestFriendsLobbies() = 0; //argc: 0, index 35
    virtual unknown_ret SetLobbyType() = 0; //argc: 3, index 36
    virtual unknown_ret SetLobbyJoinable() = 0; //argc: 3, index 37
    virtual unknown_ret GetLobbyOwner() = 0; //argc: 3, index 38
    virtual unknown_ret SetLobbyOwner() = 0; //argc: 4, index 39
    virtual unknown_ret SetLinkedLobby() = 0; //argc: 4, index 40
    virtual unknown_ret BeginGMSQuery() = 0; //argc: 3, index 41
    virtual unknown_ret PollGMSQuery() = 0; //argc: 2, index 42
    virtual unknown_ret GetGMSQueryResults() = 0; //argc: 3, index 43
    virtual unknown_ret ReleaseGMSQuery() = 0; //argc: 2, index 44
    virtual unknown_ret QueryServerByFakeIP() = 0; //argc: 4, index 45
    virtual unknown_ret EnsureFavoriteGameAccountsUpdated() = 0; //argc: 1, index 46
};