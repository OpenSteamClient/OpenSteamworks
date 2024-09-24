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
    virtual unknown_ret RequestUserStats() = 0; //argc: 3, index 1
    virtual unknown_ret GetUserStat(unknown_ret) = 0; //argc: 5, index 2
    virtual unknown_ret GetUserStat(unknown_ret, unknown_ret) = 0; //argc: 5, index 3
    virtual unknown_ret GetUserAchievement() = 0; //argc: 6, index 4
    virtual unknown_ret SetUserStat(unknown_ret) = 0; //argc: 5, index 5
    virtual unknown_ret SetUserStat(unknown_ret, unknown_ret) = 0; //argc: 5, index 6
    virtual unknown_ret UpdateUserAvgRateStat() = 0; //argc: 6, index 7
    virtual unknown_ret SetUserAchievement() = 0; //argc: 4, index 8
    virtual unknown_ret ClearUserAchievement() = 0; //argc: 4, index 9
    virtual unknown_ret StoreUserStats() = 0; //argc: 3, index 10
    virtual unknown_ret SetMaxStatsLoaded() = 0; //argc: 1, index 11
};