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
    virtual unknown_ret AddGameSearchParams() = 0; //argc: 2, index 1
    virtual unknown_ret SearchForGameWithLobby() = 0; //argc: 4, index 2
    virtual unknown_ret SearchForGameSolo() = 0; //argc: 2, index 3
    virtual unknown_ret AcceptGame() = 0; //argc: 0, index 4
    virtual unknown_ret DeclineGame() = 0; //argc: 0, index 5
    virtual unknown_ret RetrieveConnectionDetails() = 0; //argc: 4, index 6
    virtual unknown_ret EndGameSearch() = 0; //argc: 0, index 7
    virtual unknown_ret SetGameHostParams() = 0; //argc: 2, index 8
    virtual unknown_ret SetConnectionDetails() = 0; //argc: 2, index 9
    virtual unknown_ret RequestPlayersForGame() = 0; //argc: 3, index 10
    virtual unknown_ret HostConfirmGameStart() = 0; //argc: 2, index 11
    virtual unknown_ret CancelRequestPlayersForGame() = 0; //argc: 0, index 12
    virtual unknown_ret SubmitPlayerResult() = 0; //argc: 5, index 13
    virtual unknown_ret EndGame() = 0; //argc: 2, index 14
};