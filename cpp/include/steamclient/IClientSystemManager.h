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
    virtual unknown GetSettings() = 0; //argc: -1, index 1
    virtual unknown UpdateSettings() = 0; //argc: -1, index 2
    virtual unknown ShutdownSystem() = 0; //argc: -1, index 3
    virtual unknown SuspendSystem() = 0; //argc: -1, index 4
    virtual unknown RestartSystem() = 0; //argc: -1, index 5
    virtual unknown FactoryReset() = 0; //argc: -1, index 6
    virtual unknown RebootToFactoryTestImage() = 0; //argc: -1, index 7
    virtual unknown GetDisplayBrightness() = 0; //argc: -1, index 8
    virtual unknown SetDisplayBrightness() = 0; //argc: -1, index 9
    virtual unknown FormatRemovableStorage() = 0; //argc: -1, index 10
    virtual unknown GetOSBranchList() = 0; //argc: -1, index 11
    virtual unknown GetCurrentOSBranch() = 0; //argc: -1, index 12
    virtual unknown SelectOSBranch() = 0; //argc: -1, index 13
    virtual unknown GetUpdateState() = 0; //argc: -1, index 14
    virtual unknown CheckForUpdate() = 0; //argc: -1, index 15
    virtual unknown ApplyUpdate() = 0; //argc: -1, index 16
    virtual unknown SetBackgroundUpdateCheckInterval() = 0; //argc: -1, index 17
    virtual unknown ClearAudioDefaults() = 0; //argc: -1, index 18
    virtual unknown RunDeckMicEnableHack() = 0; //argc: -1, index 19
    virtual unknown RunDeckEchoCancellationHack() = 0; //argc: -1, index 20
};