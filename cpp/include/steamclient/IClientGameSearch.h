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

class IClientGameSearch
{
public:
    virtual EGameSearchErrorCode AddGameSearchParams(const char* pchKeyToFind, const char* pchValuesToFind) = 0; //argc: 2, index 1
    virtual EGameSearchErrorCode SearchForGameWithLobby(CSteamID steamIDLobby, int nPlayerMin, int nPlayerMax) = 0; //argc: 4, index 2
    virtual EGameSearchErrorCode SearchForGameSolo(int nPlayerMin, int nPlayerMax) = 0; //argc: 2, index 3
    virtual EGameSearchErrorCode AcceptGame() = 0; //argc: 0, index 4
    virtual EGameSearchErrorCode DeclineGame() = 0; //argc: 0, index 5
    virtual EGameSearchErrorCode RetrieveConnectionDetails(CSteamID steamIDHost, char* pchConnectionDetails, int cubConnectionDetails) = 0; //argc: 4, index 6
    virtual EGameSearchErrorCode EndGameSearch() = 0; //argc: 0, index 7
    virtual EGameSearchErrorCode SetGameHostParams(const char* pchKey, const char* pchValue) = 0; //argc: 2, index 8
    virtual EGameSearchErrorCode SetConnectionDetails(const char* pchConnectionDetails, int cubConnectionDetails) = 0; //argc: 2, index 9
    virtual EGameSearchErrorCode RequestPlayersForGame(int nPlayerMin, int nPlayerMax, int nMaxTeamSize) = 0; //argc: 3, index 10
    virtual EGameSearchErrorCode HostConfirmGameStart(uint64 ullUniqueGameID) = 0; //argc: 2, index 11
    virtual EGameSearchErrorCode CancelRequestPlayersForGame() = 0; //argc: 0, index 12
    virtual EGameSearchErrorCode SubmitPlayerResult(uint64 ullUniqueGameID, CSteamID steamIDPlayer, EPlayerResult EPlayerResult) = 0; //argc: 5, index 13
    virtual EGameSearchErrorCode EndGame(uint64 ullUniqueGameID) = 0; //argc: 2, index 14
};