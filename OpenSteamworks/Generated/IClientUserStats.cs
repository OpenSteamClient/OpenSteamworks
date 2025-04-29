//==========================  AUTO-GENERATED FILE  ================================
//
// This file is partially auto-generated.
// If functions are removed, your changes to that function will be lost.
// Parameter types and names however are preserved if the function stays unchanged.
// Feel free to change parameters to be more accurate. 
//=============================================================================

using System;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Structs;
using OpenSteamworks.Data;
using CppSourceGen.Attributes;

namespace OpenSteamworks.Generated;

[CppClass]
public unsafe interface IClientUserStats
{
    public UInt32 GetNumStats(in CGameID nGameID);  // argc: -1, index: 1, ipc args: [bytes8], ipc returns: [bytes4]
    public string GetStatName(in CGameID nGameID, UInt32 iStat);  // argc: -1, index: 2, ipc args: [bytes8, bytes4], ipc returns: [string]
    // WARNING: Arguments are unknown!
    public unknown GetStatType();  // argc: -1, index: 3, ipc args: [bytes8, string], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetNumAchievements();  // argc: -1, index: 4, ipc args: [bytes8], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetAchievementName();  // argc: -1, index: 5, ipc args: [bytes8, bytes4], ipc returns: [string]
    public bool RequestCurrentStats(CGameID gameID);  // argc: -1, index: 6, ipc args: [bytes8], ipc returns: [bytes1]
    public unknown DeprecatedPublic_RequestCurrentStats();  // argc: -1, index: 7, ipc args: [bytes8], ipc returns: [bytes1]
    public unknown GetStat(in CGameID nGameID, string pchName, ref Int32 pData);  // argc: -1, index: 8, ipc args: [bytes8, string], ipc returns: [bytes1, bytes4]
    public unknown GetStat(in CGameID nGameID, string pchName, ref float pData);  // argc: -1, index: 9, ipc args: [bytes8, string], ipc returns: [bytes1, bytes4]
    public unknown SetStat(in CGameID nGameID, string pchName, Int32 nData);  // argc: -1, index: 10, ipc args: [bytes8, string, bytes4], ipc returns: [bytes1]
    public unknown SetStat(in CGameID nGameID, string pchName, float nData);  // argc: -1, index: 11, ipc args: [bytes8, string, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown UpdateAvgRateStat();  // argc: -1, index: 12, ipc args: [bytes8, string, bytes4, bytes8], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown GetAchievement();  // argc: -1, index: 13, ipc args: [bytes8, string], ipc returns: [bytes1, bytes1, bytes4]
    // WARNING: Arguments are unknown!
    public unknown SetAchievement();  // argc: -1, index: 14, ipc args: [bytes8, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown ClearAchievement();  // argc: -1, index: 15, ipc args: [bytes8, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown GetAchievementProgress();  // argc: -1, index: 16, ipc args: [bytes8, string], ipc returns: [bytes1, bytes4, bytes4, bytes4]
    // WARNING: Arguments are unknown!
    public unknown StoreStats();  // argc: -1, index: 17, ipc args: [bytes8], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown GetAchievementIcon();  // argc: -1, index: 18, ipc args: [bytes8, string, bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown BGetAchievementIconURL();  // argc: -1, index: 19, ipc args: [bytes8, string, bytes4, bytes4], ipc returns: [boolean, bytes_external_length]
    // WARNING: Arguments are unknown!
    public unknown GetAchievementDisplayAttribute();  // argc: -1, index: 20, ipc args: [bytes8, string, string, bytes1], ipc returns: [string]
    // WARNING: Arguments are unknown!
    public unknown IndicateAchievementProgress();  // argc: -1, index: 21, ipc args: [bytes8, string, bytes4, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public void SetMaxStatsLoaded(int iMaxStats);  // argc: -1, index: 22, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown RequestUserStats();  // argc: -1, index: 23, ipc args: [uint64, bytes8, bytes4], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown GetUserStat(in CSteamID steamIDUser, in CGameID nGameID, string pchName, ref Int32 pData);  // argc: -1, index: 24, ipc args: [uint64, bytes8, string], ipc returns: [bytes1, bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetUserStat(in CSteamID steamIDUser, in CGameID nGameID, string pchName, ref float pData);  // argc: -1, index: 25, ipc args: [uint64, bytes8, string], ipc returns: [bytes1, bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetUserAchievement();  // argc: -1, index: 26, ipc args: [uint64, bytes8, string], ipc returns: [bytes1, bytes1, bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetUserAchievementProgress();  // argc: -1, index: 27, ipc args: [uint64, bytes8, string], ipc returns: [bytes1, bytes4, bytes4, bytes4]
    // WARNING: Arguments are unknown!
    public unknown ResetAllStats();  // argc: -1, index: 28, ipc args: [bytes8, bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown FindOrCreateLeaderboard();  // argc: -1, index: 29, ipc args: [string, bytes4, bytes4], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown FindLeaderboard();  // argc: -1, index: 30, ipc args: [string], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown GetLeaderboardName();  // argc: -1, index: 31, ipc args: [bytes8], ipc returns: [string]
    // WARNING: Arguments are unknown!
    public unknown GetLeaderboardEntryCount();  // argc: -1, index: 32, ipc args: [bytes8], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetLeaderboardSortMethod();  // argc: -1, index: 33, ipc args: [bytes8], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetLeaderboardDisplayType();  // argc: -1, index: 34, ipc args: [bytes8], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown DownloadLeaderboardEntries();  // argc: -1, index: 35, ipc args: [bytes8, bytes4, bytes4, bytes4], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown DownloadLeaderboardEntriesForUsers();  // argc: -1, index: 36, ipc args: [bytes8, bytes4, bytes_external_length], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown GetDownloadedLeaderboardEntry();  // argc: -1, index: 37, ipc args: [bytes8, bytes4, bytes4], ipc returns: [bytes1, bytes28, bytes_external_length]
    // WARNING: Arguments are unknown!
    public unknown AttachLeaderboardUGC();  // argc: -1, index: 38, ipc args: [bytes8, bytes8], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown UploadLeaderboardScore();  // argc: -1, index: 39, ipc args: [bytes8, bytes4, bytes4, bytes4, bytes_external_length], ipc returns: [bytes8]
    public unknown GetNumberOfCurrentPlayers();  // argc: -1, index: 40, ipc args: [], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown GetNumAchievedAchievements();  // argc: -1, index: 41, ipc args: [bytes8], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetLastAchievementUnlocked();  // argc: -1, index: 42, ipc args: [bytes8], ipc returns: [string]
    // WARNING: Arguments are unknown!
    public unknown GetMostRecentAchievementUnlocked();  // argc: -1, index: 43, ipc args: [bytes8, bytes4], ipc returns: [string]
    // WARNING: Arguments are unknown!
    public unknown RequestGlobalAchievementPercentages();  // argc: -1, index: 44, ipc args: [bytes8], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown GetMostAchievedAchievementInfo();  // argc: -1, index: 45, ipc args: [bytes8, bytes4], ipc returns: [bytes4, bytes_external_length, bytes4, bytes1]
    // WARNING: Arguments are unknown!
    public unknown GetNextMostAchievedAchievementInfo();  // argc: -1, index: 46, ipc args: [bytes8, bytes4, bytes4], ipc returns: [bytes4, bytes_external_length, bytes4, bytes1]
    // WARNING: Arguments are unknown!
    public unknown GetAchievementAchievedPercent();  // argc: -1, index: 47, ipc args: [bytes8, string], ipc returns: [bytes1, bytes4]
    // WARNING: Arguments are unknown!
    public unknown RequestGlobalStats();  // argc: -1, index: 48, ipc args: [bytes8, bytes4], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown GetGlobalStat(in CGameID nGameID, string pchName, ref Int64 pData);  // argc: -1, index: 49, ipc args: [bytes8, string], ipc returns: [bytes1, bytes8]
    // WARNING: Arguments are unknown!
    public unknown GetGlobalStat(in CGameID nGameID, string pchName, ref double pData);  // argc: -1, index: 50, ipc args: [bytes8, string], ipc returns: [bytes1, bytes8]
    // WARNING: Arguments are unknown!
    public unknown GetGlobalStatHistory(in CGameID nGameID, string pchName, ref Int64 pData, UInt32 cubData);  // argc: -1, index: 51, ipc args: [bytes8, string, bytes4], ipc returns: [bytes4, bytes_external_length]
    // WARNING: Arguments are unknown!
    public unknown GetGlobalStatHistory(in CGameID nGameID, string pchName, ref double pData, UInt32 cubData);  // argc: -1, index: 52, ipc args: [bytes8, string, bytes4, bytes4], ipc returns: [bytes4, bytes_external_length]
    // WARNING: Arguments are unknown!
    public unknown GetAchievementProgressLimits(in CGameID nGameID, string pchName, ref Int64 pData, UInt32 cubData);  // argc: -1, index: 53, ipc args: [bytes8, string], ipc returns: [bytes1, bytes4, bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetAchievementProgressLimits(in CGameID nGameID, string pchName, ref double pData, UInt32 cubData);  // argc: -1, index: 54, ipc args: [bytes8, string], ipc returns: [bytes1, bytes4, bytes4]
    // WARNING: Arguments are unknown!
    public unknown BAchievementIconLoaded();  // argc: -1, index: 55, ipc args: [bytes8, string, bytes1], ipc returns: [boolean]
}