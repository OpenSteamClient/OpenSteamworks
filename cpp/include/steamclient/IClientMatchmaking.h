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

class CMsgGMSClientServerQueryResponse;

class IClientMatchmaking
{
public:
    virtual int GetFavoriteGameCount() = 0; //argc: 0, index 1
    virtual bool GetFavoriteGame(int iGame, AppId_t* pnAppID, uint32* pnIP, uint16* pnConnPort, uint16* pnQueryPort, uint32* punFlags, uint32* pRTime32LastPlayedOnServer) = 0; //argc: 7, index 2
    virtual int AddFavoriteGame(AppId_t nAppID, uint32 nIP, uint16 nConnPort, uint16 nQueryPort, uint32 unFlags, uint32 rTime32LastPlayedOnServer) = 0; //argc: 6, index 3
    virtual bool RemoveFavoriteGame(AppId_t nAppID, uint32 nIP, uint16 nConnPort, uint16 nQueryPort, uint32 unFlags) = 0; //argc: 5, index 4
    virtual SteamAPICall_t RequestLobbyList() = 0; //argc: 0, index 5
    virtual void AddRequestLobbyListStringFilter(const char* pchKeyToMatch, const char* pchValueToMatch, ELobbyComparison eComparisonType) = 0; //argc: 3, index 6
    virtual void AddRequestLobbyListNumericalFilter(const char* pchKeyToMatch, int nValueToMatch, ELobbyComparison eComparisonType) = 0; //argc: 3, index 7
    virtual void AddRequestLobbyListNearValueFilter(const char* pchKeyToMatch, int nValueToBeCloseTo) = 0; //argc: 2, index 8
    virtual void AddRequestLobbyListFilterSlotsAvailable(int nSlotsAvailable) = 0; //argc: 1, index 9
    virtual void AddRequestLobbyListDistanceFilter(ELobbyDistanceFilter eLobbyDistanceFilter) = 0; //argc: 1, index 10
    virtual void AddRequestLobbyListResultCountFilter(int cMaxResults) = 0; //argc: 1, index 11
    virtual void AddRequestLobbyListCompatibleMembersFilter(CSteamID steamIDLobby) = 0; //argc: 2, index 12
    virtual CSteamID GetLobbyByIndex(int iLobby) = 0; //argc: 2, index 13
    virtual SteamAPICall_t CreateLobby(ELobbyType eLobbyType, int cMaxMembers) = 0; //argc: 2, index 14
    virtual SteamAPICall_t JoinLobby(CSteamID steamIDLobby) = 0; //argc: 2, index 15
    virtual void LeaveLobby(CSteamID steamIDLobby) = 0; //argc: 2, index 16
    virtual bool InviteUserToLobby(CSteamID steamIDLobby, CSteamID steamIDInvitee) = 0; //argc: 4, index 17
    virtual int GetNumLobbyMembers(CSteamID steamIDLobby) = 0; //argc: 2, index 18
    virtual CSteamID GetLobbyMemberByIndex(CSteamID steamIDLobby, int iMember) = 0; //argc: 4, index 19
    virtual const char* GetLobbyData(CSteamID steamIDLobby, const char* pchKey) = 0; //argc: 3, index 20
    virtual bool SetLobbyData(CSteamID steamIDLobby, const char* pchKey, const char* pchValue) = 0; //argc: 4, index 21
    virtual int GetLobbyDataCount(CSteamID steamIDLobby) = 0; //argc: 2, index 22
    virtual bool GetLobbyDataByIndex(CSteamID steamIDLobby, int iLobbyData, char* pchKey, int cchKeyBufferSize, char* pchValue, int cchValueBufferSize) = 0; //argc: 7, index 23
    virtual bool DeleteLobbyData(CSteamID steamIDLobby, const char* pchKey) = 0; //argc: 3, index 24
    virtual const char* GetLobbyMemberData(CSteamID steamIDLobby, CSteamID steamIDUser, const char* pchKey) = 0; //argc: 5, index 25
    virtual void SetLobbyMemberData(CSteamID steamIDLobby, const char* pchKey, const char* pchValue) = 0; //argc: 4, index 26
    virtual bool SendLobbyChatMsg(CSteamID steamIDLobby, const void* pvMsgBody, int cubMsgBody) = 0; //argc: 4, index 27
    virtual int GetLobbyChatEntry(CSteamID steamIDLobby, int iChatID, CSteamID* pSteamIDUser, void* pvData, int cubData, EChatEntryType* peChatEntryType) = 0; //argc: 7, index 28
    virtual bool RequestLobbyData(CSteamID steamIDLobby) = 0; //argc: 2, index 29
    virtual void SetLobbyGameServer(CSteamID steamIDLobby, uint32 unGameServerIP, uint16 unGameServerPort, CSteamID steamIDGameServer) = 0; //argc: 6, index 30
    virtual bool GetLobbyGameServer(CSteamID steamIDLobby, uint32* punGameServerIP, uint16* punGameServerPort, CSteamID* psteamIDGameServer) = 0; //argc: 5, index 31
    virtual bool SetLobbyMemberLimit(CSteamID steamIDLobby, int cMaxMembers) = 0; //argc: 3, index 32
    virtual int GetLobbyMemberLimit(CSteamID steamIDLobby) = 0; //argc: 2, index 33
    virtual void SetLobbyVoiceEnabled(CSteamID steamIDLobby, bool bVoiceEnabled) = 0; //argc: 3, index 34
    virtual bool RequestFriendsLobbies() = 0; //argc: 0, index 35
    virtual bool SetLobbyType(CSteamID steamIDLobby, ELobbyType eLobbyType) = 0; //argc: 3, index 36
    virtual bool SetLobbyJoinable(CSteamID steamIDLobby, bool bLobbyJoinable) = 0; //argc: 3, index 37
    virtual CSteamID GetLobbyOwner(CSteamID steamIDLobby) = 0; //argc: 3, index 38
    virtual bool SetLobbyOwner(CSteamID steamIDLobby, CSteamID steamIDNewOwner) = 0; //argc: 4, index 39
    virtual bool SetLinkedLobby(CSteamID steamIDLobby, CSteamID steamIDLobbyDependent) = 0; //argc: 4, index 40
    virtual GMSQueryHandle_t BeginGMSQuery(AppId_t nAppId, ERegionCode eRegionCode, const char* szFilterText) = 0; //argc: 3, index 41

    // returns: -1 if query in progress
    virtual int32 PollGMSQuery(GMSQueryHandle_t queryHandle) = 0; //argc: 2, index 42
    virtual bool GetGMSQueryResults(GMSQueryHandle_t queryHandle, CMsgGMSClientServerQueryResponse *results) = 0; //argc: 3, index 43
    virtual void ReleaseGMSQuery(GMSQueryHandle_t queryHandle) = 0; //argc: 2, index 44
    virtual unknown_ret QueryServerByFakeIP() = 0; //argc: 4, index 45
    virtual unknown_ret EnsureFavoriteGameAccountsUpdated() = 0; //argc: 1, index 46
};
