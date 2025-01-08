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

class IClientGameServerStats
{
public:
    virtual unknown RequestUserStats() = 0; //argc: 3, index 1
    virtual unknown GetUserStat(unknown) = 0; //argc: 5, index 2
    virtual unknown GetUserStat(unknown, unknown) = 0; //argc: 5, index 3
    virtual unknown GetUserAchievement() = 0; //argc: 6, index 4
    virtual unknown SetUserStat(unknown) = 0; //argc: 5, index 5
    virtual unknown SetUserStat(unknown, unknown) = 0; //argc: 5, index 6
    virtual unknown UpdateUserAvgRateStat() = 0; //argc: 6, index 7
    virtual unknown SetUserAchievement() = 0; //argc: 4, index 8
    virtual unknown ClearUserAchievement() = 0; //argc: 4, index 9
    virtual unknown StoreUserStats() = 0; //argc: 3, index 10
    virtual unknown SetMaxStatsLoaded() = 0; //argc: 1, index 11
};