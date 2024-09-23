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
    virtual unknown_ret GetAppData() = 0; //argc: 4, index 1
    virtual unknown_ret SetLocalAppConfig() = 0; //argc: 3, index 2
    virtual unknown_ret GetInternalAppIDFromGameID() = 0; //argc: 1, index 3
    virtual unknown_ret GetAllOwnedMultiplayerApps() = 0; //argc: 2, index 4
    virtual unknown_ret GetAvailableLaunchOptions() = 0; //argc: 3, index 5
    virtual unknown_ret GetAppDataSection() = 0; //argc: 5, index 6
    virtual unknown_ret GetMultipleAppDataSections() = 0; //argc: 7, index 7
    virtual unknown_ret RequestAppInfoUpdate() = 0; //argc: 2, index 8
    virtual unknown_ret GetDLCCount() = 0; //argc: 1, index 9
    virtual unknown_ret BGetDLCDataByIndex() = 0; //argc: 6, index 10
    virtual unknown_ret GetAppType() = 0; //argc: 1, index 11
    virtual unknown_ret TakeUpdateLock() = 0; //argc: 0, index 12
    virtual unknown_ret GetAllAppsKVRaw() = 0; //argc: 3, index 13
    virtual unknown_ret ReleaseUpdateLock() = 0; //argc: 0, index 14
    virtual unknown_ret GetLastChangeNumberReceived() = 0; //argc: 0, index 15
};