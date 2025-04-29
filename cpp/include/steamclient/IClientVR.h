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

class IClientVR
{
public:
    virtual unknown GetCurrentHmd() = 0; //argc: -1, index 1
    virtual unknown GetCompositor() = 0; //argc: -1, index 2
    virtual unknown GetOverlay() = 0; //argc: -1, index 3
    virtual unknown GetSettings() = 0; //argc: -1, index 4
    virtual unknown GetProperties() = 0; //argc: -1, index 5
    virtual unknown GetPaths() = 0; //argc: -1, index 6
    virtual unknown IsHmdPresent() = 0; //argc: -1, index 7
    virtual unknown UpdateHmdStatus() = 0; //argc: -1, index 8
    virtual unknown IsVRModeActive() = 0; //argc: -1, index 9
    virtual unknown InitVR() = 0; //argc: -1, index 10
    virtual unknown StartSteamVR() = 0; //argc: -1, index 11
    virtual unknown CleanupVR() = 0; //argc: -1, index 12
    virtual unknown QuitAllVR() = 0; //argc: -1, index 13
    virtual unknown QuitApplication() = 0; //argc: -1, index 14
    virtual unknown GetStringForHmdError() = 0; //argc: -1, index 15
    virtual unknown LaunchApplication() = 0; //argc: -1, index 16
    virtual unknown GetSteamVRAppId() = 0; //argc: -1, index 17
    virtual unknown GetWebSecret() = 0; //argc: -1, index 18
    virtual unknown BGetMutualCapabilities() = 0; //argc: -1, index 19
    virtual unknown BSteamCanMakeVROverlays() = 0; //argc: -1, index 20
    virtual unknown BServeVRGamepadUIOverlay() = 0; //argc: -1, index 21
    virtual unknown BServeVRGamepadUIViaGamescope() = 0; //argc: -1, index 22
    virtual unknown SetVRConnectionParams() = 0; //argc: -1, index 23
    virtual unknown GetVRConnectionParams() = 0; //argc: -1, index 24
    virtual unknown BVRDeviceSeenRecently() = 0; //argc: -1, index 25
};