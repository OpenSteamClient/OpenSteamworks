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
    virtual unknown_ret GetCurrentHmd() = 0; //argc: 0, index 1
    virtual unknown_ret GetCompositor() = 0; //argc: 0, index 2
    virtual unknown_ret GetOverlay() = 0; //argc: 0, index 3
    virtual unknown_ret GetSettings() = 0; //argc: 0, index 4
    virtual unknown_ret GetProperties() = 0; //argc: 0, index 5
    virtual unknown_ret GetPaths() = 0; //argc: 0, index 6
    virtual unknown_ret IsHmdPresent() = 0; //argc: 0, index 7
    virtual unknown_ret UpdateHmdStatus() = 0; //argc: 0, index 8
    virtual unknown_ret IsVRModeActive() = 0; //argc: 0, index 9
    virtual unknown_ret InitVR() = 0; //argc: 3, index 10
    virtual unknown_ret StartSteamVR() = 0; //argc: 1, index 11
    virtual unknown_ret CleanupVR() = 0; //argc: 0, index 12
    virtual unknown_ret QuitAllVR() = 0; //argc: 0, index 13
    virtual unknown_ret QuitApplication() = 0; //argc: 1, index 14
    virtual unknown_ret GetStringForHmdError() = 0; //argc: 1, index 15
    virtual unknown_ret LaunchApplication() = 0; //argc: 1, index 16
    virtual unknown_ret GetSteamVRAppId() = 0; //argc: 0, index 17
    virtual unknown_ret GetWebSecret() = 0; //argc: 0, index 18
    virtual unknown_ret BGetMutualCapabilities() = 0; //argc: 1, index 19
    virtual unknown_ret BSteamCanMakeVROverlays() = 0; //argc: 0, index 20
    virtual unknown_ret BServeVRGamepadUIOverlay() = 0; //argc: 0, index 21
    virtual unknown_ret BServeVRGamepadUIViaGamescope() = 0; //argc: 0, index 22
    virtual unknown_ret SetVRConnectionParams() = 0; //argc: 1, index 23
    virtual unknown_ret GetVRConnectionParams() = 0; //argc: 0, index 24
    virtual unknown_ret BVRDeviceSeenRecently() = 0; //argc: 0, index 25
};