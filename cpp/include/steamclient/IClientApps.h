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

class IClientApps
{
public:
    virtual int GetAppData(AppId_t unAppID, const char *pchKey, char *pchValue, int cchValueMax) = 0; //argc: 4, index 1
    virtual bool SetLocalAppConfig(AppId_t appid, uint8_t *buf, int bufLen) = 0; //argc: 3, index 2
    virtual AppId_t GetInternalAppIDFromGameID(CGameID gameid) = 0; //argc: 1, index 3
    virtual unknown_ret GetAllOwnedMultiplayerApps() = 0; //argc: 2, index 4
    virtual int GetAvailableLaunchOptions(AppId_t unAppID, int *outOptions, int optionsMax) = 0; //argc: 3, index 5
    virtual unknown_ret GetAppDataSection(AppId_t appid, EAppInfoSection section, uint8 *buf, int bufMax, bool bSharedKVSymbols) = 0; //argc: 5, index 6
    virtual unknown_ret GetMultipleAppDataSections(AppId_t appid, EAppInfoSection *pSections, int numSections, uint8 *buf, int bufMax, bool bSharedKVSymbols, int *outSectionLengths) = 0; //argc: 7, index 7
    virtual bool RequestAppInfoUpdate(AppId_t *pAppIDs, int numAppIDs) = 0; //argc: 2, index 8
    virtual int GetDLCCount(AppId_t appid) = 0; //argc: 1, index 9
    virtual unknown_ret BGetDLCDataByIndex(AppId_t appid, int iDLC, AppId_t *pDlcAppID, bool *pbAvailable, char *pchName, int cchNameBufferSize) = 0; //argc: 6, index 10
    virtual EAppType GetAppType(AppId_t appid) = 0; //argc: 1, index 11
    virtual bool TakeUpdateLock() = 0; //argc: 0, index 12
    virtual unknown_ret GetAllAppsKVRaw() = 0; //argc: 3, index 13
    virtual void ReleaseUpdateLock() = 0; //argc: 0, index 14
    virtual int GetLastChangeNumberReceived() = 0; //argc: 0, index 15
};