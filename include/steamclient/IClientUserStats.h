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

class IClientUserStats
{
public:
    virtual unknown_ret GetNumStats() = 0; //argc: 1, index 1
    virtual unknown_ret GetStatName() = 0; //argc: 2, index 2
    virtual unknown_ret GetStatType() = 0; //argc: 2, index 3
    virtual unknown_ret GetNumAchievements() = 0; //argc: 1, index 4
    virtual unknown_ret GetAchievementName() = 0; //argc: 2, index 5
    virtual unknown_ret RequestCurrentStats() = 0; //argc: 1, index 6
    virtual unknown_ret DeprecatedPublic_RequestCurrentStats() = 0; //argc: 1, index 7
    virtual unknown_ret GetStat(unknown_ret) = 0; //argc: 3, index 8
    virtual unknown_ret GetStat(unknown_ret, unknown_ret) = 0; //argc: 3, index 9
    virtual unknown_ret SetStat(unknown_ret) = 0; //argc: 3, index 10
    virtual unknown_ret SetStat(unknown_ret, unknown_ret) = 0; //argc: 3, index 11
    virtual unknown_ret UpdateAvgRateStat() = 0; //argc: 4, index 12
    virtual unknown_ret GetAchievement() = 0; //argc: 4, index 13
    virtual unknown_ret SetAchievement() = 0; //argc: 2, index 14
    virtual unknown_ret ClearAchievement() = 0; //argc: 2, index 15
    virtual unknown_ret GetAchievementProgress() = 0; //argc: 5, index 16
    virtual unknown_ret StoreStats() = 0; //argc: 1, index 17
    virtual unknown_ret GetAchievementIcon() = 0; //argc: 3, index 18
    virtual unknown_ret BGetAchievementIconURL() = 0; //argc: 5, index 19
    virtual unknown_ret GetAchievementDisplayAttribute() = 0; //argc: 4, index 20
    virtual unknown_ret IndicateAchievementProgress() = 0; //argc: 4, index 21
    virtual unknown_ret SetMaxStatsLoaded() = 0; //argc: 1, index 22
    virtual unknown_ret RequestUserStats() = 0; //argc: 3, index 23
    virtual unknown_ret GetUserStat(unknown_ret) = 0; //argc: 5, index 24
    virtual unknown_ret GetUserStat(unknown_ret, unknown_ret) = 0; //argc: 5, index 25
    virtual unknown_ret GetUserAchievement() = 0; //argc: 6, index 26
    virtual unknown_ret GetUserAchievementProgress() = 0; //argc: 7, index 27
    virtual unknown_ret ResetAllStats() = 0; //argc: 2, index 28
    virtual unknown_ret FindOrCreateLeaderboard() = 0; //argc: 3, index 29
    virtual unknown_ret FindLeaderboard() = 0; //argc: 1, index 30
    virtual unknown_ret GetLeaderboardName() = 0; //argc: 2, index 31
    virtual unknown_ret GetLeaderboardEntryCount() = 0; //argc: 2, index 32
    virtual unknown_ret GetLeaderboardSortMethod() = 0; //argc: 2, index 33
    virtual unknown_ret GetLeaderboardDisplayType() = 0; //argc: 2, index 34
    virtual unknown_ret DownloadLeaderboardEntries() = 0; //argc: 5, index 35
    virtual unknown_ret DownloadLeaderboardEntriesForUsers() = 0; //argc: 4, index 36
    virtual unknown_ret GetDownloadedLeaderboardEntry() = 0; //argc: 6, index 37
    virtual unknown_ret AttachLeaderboardUGC() = 0; //argc: 4, index 38
    virtual unknown_ret UploadLeaderboardScore() = 0; //argc: 6, index 39
    virtual unknown_ret GetNumberOfCurrentPlayers() = 0; //argc: 0, index 40
    virtual unknown_ret GetNumAchievedAchievements() = 0; //argc: 1, index 41
    virtual unknown_ret GetLastAchievementUnlocked() = 0; //argc: 1, index 42
    virtual unknown_ret GetMostRecentAchievementUnlocked() = 0; //argc: 2, index 43
    virtual unknown_ret RequestGlobalAchievementPercentages() = 0; //argc: 1, index 44
    virtual unknown_ret GetMostAchievedAchievementInfo() = 0; //argc: 5, index 45
    virtual unknown_ret GetNextMostAchievedAchievementInfo() = 0; //argc: 6, index 46
    virtual unknown_ret GetAchievementAchievedPercent() = 0; //argc: 3, index 47
    virtual unknown_ret RequestGlobalStats() = 0; //argc: 2, index 48
    virtual unknown_ret GetGlobalStat(unknown_ret) = 0; //argc: 3, index 49
    virtual unknown_ret GetGlobalStat(unknown_ret, unknown_ret) = 0; //argc: 3, index 50
    virtual unknown_ret GetGlobalStatHistory(unknown_ret) = 0; //argc: 4, index 51
    virtual unknown_ret GetGlobalStatHistory(unknown_ret, unknown_ret) = 0; //argc: 4, index 52
    virtual unknown_ret GetAchievementProgressLimits(unknown_ret) = 0; //argc: 4, index 53
    virtual unknown_ret GetAchievementProgressLimits(unknown_ret, unknown_ret) = 0; //argc: 4, index 54
    virtual unknown_ret BAchievementIconLoaded() = 0; //argc: 3, index 55
};