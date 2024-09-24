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

class IClientSystemManager
{
public:
    virtual unknown_ret GetSettings() = 0; //argc: 1, index 1
    virtual unknown_ret UpdateSettings() = 0; //argc: 1, index 2
    virtual unknown_ret ShutdownSystem() = 0; //argc: 0, index 3
    virtual unknown_ret SuspendSystem() = 0; //argc: 0, index 4
    virtual unknown_ret RestartSystem() = 0; //argc: 0, index 5
    virtual unknown_ret FactoryReset() = 0; //argc: 0, index 6
    virtual unknown_ret RebootToFactoryTestImage() = 0; //argc: 1, index 7
    virtual unknown_ret GetDisplayBrightness() = 0; //argc: 1, index 8
    virtual unknown_ret SetDisplayBrightness() = 0; //argc: 1, index 9
    virtual unknown_ret FormatRemovableStorage() = 0; //argc: 1, index 10
    virtual unknown_ret GetOSBranchList() = 0; //argc: 0, index 11
    virtual unknown_ret GetCurrentOSBranch() = 0; //argc: 0, index 12
    virtual unknown_ret SelectOSBranch() = 0; //argc: 1, index 13
    virtual unknown_ret GetUpdateState() = 0; //argc: 1, index 14
    virtual unknown_ret CheckForUpdate() = 0; //argc: 0, index 15
    virtual unknown_ret ApplyUpdate() = 0; //argc: 1, index 16
    virtual unknown_ret SetBackgroundUpdateCheckInterval() = 0; //argc: 1, index 17
    virtual unknown_ret ClearAudioDefaults() = 0; //argc: 1, index 18
    virtual unknown_ret RunDeckMicEnableHack() = 0; //argc: 0, index 19
    virtual unknown_ret RunDeckEchoCancellationHack() = 0; //argc: 0, index 20
};