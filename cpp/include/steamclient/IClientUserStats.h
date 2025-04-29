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
    virtual uint32 GetNumStats(CGameID nGameID) = 0; //argc: -1, index 1
    virtual const char *GetStatName(CGameID nGameID, uint32 iStat) = 0; //argc: -1, index 2
    virtual ESteamUserStatType GetStatType(CGameID nGameID, const char *pchName) = 0; //argc: -1, index 3
    virtual uint32 GetNumAchievements(CGameID gameID) = 0; //argc: -1, index 4
    virtual const char *GetAchievementName(CGameID gameID, uint32 iAchievement) = 0; //argc: -1, index 5
    virtual bool RequestCurrentStats(CGameID gameID) = 0; //argc: -1, index 6
    virtual bool DeprecatedPublic_RequestCurrentStats(CGameID gameID) = 0; //argc: -1, index 7
    virtual bool GetStat(CGameID gameid, const char *pchName, int32 *pnData) = 0; //argc: -1, index 8
    virtual bool GetStat(CGameID gameid, const char *pchName, float *pfData) = 0; //argc: -1, index 9
    virtual bool SetStat(CGameID gameid, const char *pchName, int32 nData) = 0; //argc: -1, index 10
    virtual bool SetStat(CGameID gameid, const char *pchName, float fData) = 0; //argc: -1, index 11
    virtual bool UpdateAvgRateStat(CGameID nGameID, const char *pchName, float flCountThisSession, double dSessionLength) = 0; //argc: -1, index 12
    virtual bool GetAchievement(CGameID nGameID, const char *pchName, bool *pbAchieved) = 0; //argc: -1, index 13
    virtual bool SetAchievement(CGameID nGameID, const char *pchName) = 0; //argc: -1, index 14
    virtual bool ClearAchievement(CGameID nGameID, const char *pchName) = 0; //argc: -1, index 15
    virtual bool GetAchievementProgress(CGameID nGameID, const char *pchName, float*, float*, float*) = 0; //argc: -1, index 16
    virtual bool StoreStats(CGameID nGameID) = 0; //argc: -1, index 17
    virtual int GetAchievementIcon(CGameID nGameID, const char *pchName) = 0; //argc: -1, index 18
    virtual unknown BGetAchievementIconURL() = 0; //argc: -1, index 19
    virtual const char *GetAchievementDisplayAttribute(CGameID nGameID, const char *pchName, const char *pchKey) = 0; //argc: -1, index 20
    virtual bool IndicateAchievementProgress(CGameID nGameID, const char *pchName, uint32 nCurProgress, uint32 nMaxProgress) = 0; //argc: -1, index 21
    virtual unknown SetMaxStatsLoaded() = 0; //argc: -1, index 22
    virtual SteamAPICall_t RequestUserStats(CSteamID steamIDUser, CGameID nGameID) = 0; //argc: -1, index 23
    virtual bool GetUserStat(CSteamID steamIDUser, CGameID nGameID, const char *pchName, int32 *pData) = 0; //argc: -1, index 24
    virtual bool GetUserStat(CSteamID steamIDUser, CGameID nGameID, const char *pchName, float *pData) = 0; //argc: -1, index 25
    virtual bool GetUserAchievement(CSteamID steamIDUser, CGameID nGameID, const char *pchName, bool *pbAchieved) = 0; //argc: -1, index 26
    virtual unknown GetUserAchievementProgress() = 0; //argc: -1, index 27
    virtual bool ResetAllStats(CGameID nGameID, bool bAchievementsToo) = 0; //argc: -1, index 28
    virtual SteamAPICall_t FindOrCreateLeaderboard(const char *pchLeaderboardName, ELeaderboardSortMethod eLeaderboardSortMethod, ELeaderboardDisplayType eLeaderboardDisplayType) = 0; //argc: -1, index 29
    virtual SteamAPICall_t FindLeaderboard(const char *pchLeaderboardName) = 0; //argc: -1, index 30
    virtual const char *GetLeaderboardName(SteamLeaderboard_t hSteamLeaderboard) = 0; //argc: -1, index 31
    virtual int GetLeaderboardEntryCount(SteamLeaderboard_t hSteamLeaderboard) = 0; //argc: -1, index 32
    virtual ELeaderboardSortMethod GetLeaderboardSortMethod(SteamLeaderboard_t hSteamLeaderboard) = 0; //argc: -1, index 33
    virtual ELeaderboardDisplayType GetLeaderboardDisplayType(SteamLeaderboard_t hSteamLeaderboard) = 0; //argc: -1, index 34
    virtual SteamAPICall_t DownloadLeaderboardEntries(SteamLeaderboard_t hSteamLeaderboard, ELeaderboardDataRequest eLeaderboardDataRequest, int nRangeStart, int nRangeEnd) = 0; //argc: -1, index 35
    virtual SteamAPICall_t DownloadLeaderboardEntriesForUsers(SteamLeaderboard_t hSteamLeaderboard, CSteamID *prgUsers, int cUsers) = 0; //argc: -1, index 36
    virtual bool GetDownloadedLeaderboardEntry(SteamLeaderboardEntries_t hSteamLeaderboardEntries, int index, LeaderboardEntry_t *pLeaderboardEntry, int32 *pDetails, int cDetailsMax) = 0; //argc: -1, index 37
    virtual SteamAPICall_t AttachLeaderboardUGC(SteamLeaderboard_t hSteamLeaderboard, UGCHandle_t hUGC) = 0; //argc: -1, index 38
    virtual SteamAPICall_t UploadLeaderboardScore(SteamLeaderboard_t hSteamLeaderboard, ELeaderboardUploadScoreMethod eLeaderboardUploadScoreMethod, int32 nScore, const int32 *pScoreDetails, int cScoreDetailsCount) = 0; //argc: -1, index 39
    virtual SteamAPICall_t GetNumberOfCurrentPlayers() = 0; //argc: -1, index 40
    virtual unknown GetNumAchievedAchievements() = 0; //argc: -1, index 41
    virtual unknown GetLastAchievementUnlocked() = 0; //argc: -1, index 42
    virtual unknown GetMostRecentAchievementUnlocked() = 0; //argc: -1, index 43
    virtual SteamAPICall_t RequestGlobalAchievementPercentages(CGameID nGameID) = 0; //argc: -1, index 44
    virtual int GetMostAchievedAchievementInfo(CGameID nGameID, char *pchName, uint32 unNameBufLen, float *pflPercent, bool *pbAchieved) = 0; //argc: -1, index 45
    virtual int GetNextMostAchievedAchievementInfo(CGameID nGameID, int iIteratorPrevious, char *pchName, uint32 unNameBufLen, float *pflPercent, bool *pbAchieved) = 0; //argc: -1, index 46
    virtual bool GetAchievementAchievedPercent(CGameID nGameID, const char *pchName, float *pflPercent) = 0; //argc: -1, index 47
    virtual SteamAPICall_t RequestGlobalStats(CGameID nGameID, int nHistoryDays) = 0; //argc: -1, index 48
    virtual bool GetGlobalStat(CGameID nGameID, const char *pchStatName, int64 *pData) = 0; //argc: -1, index 49
    virtual bool GetGlobalStat(CGameID nGameID, const char *pchStatName, double *pData) = 0; //argc: -1, index 50
    virtual int32 GetGlobalStatHistory(CGameID nGameID, const char *pchStatName, int64 *pData, uint32 cubData) = 0; //argc: -1, index 51
    virtual int32 GetGlobalStatHistory(CGameID nGameID, const char *pchStatName, double *pData, uint32 cubData) = 0; //argc: -1, index 52
    virtual bool GetAchievementProgressLimits(CGameID nGameID, const char *pchName, int32 *pnMinProgress, int32 *pnMaxProgress) = 0; //argc: -1, index 53
    virtual bool GetAchievementProgressLimits(CGameID nGameID, const char *pchName, float *pnMinProgress, float *pnMaxProgress) = 0; //argc: -1, index 54
    virtual unknown BAchievementIconLoaded() = 0; //argc: -1, index 55
};