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

class IClientStreamClient
{
public:
    virtual unknown_ret Launched() = 0; //argc: 1, index 1
    virtual unknown_ret FocusGained() = 0; //argc: 2, index 2
    virtual unknown_ret FocusLost() = 0; //argc: 1, index 3
    virtual unknown_ret Finished() = 0; //argc: 2, index 4
    virtual unknown_ret BGetStreamingClientConfig() = 0; //argc: 1, index 5
    virtual unknown_ret BSaveStreamingClientConfig() = 0; //argc: 1, index 6
    virtual unknown_ret SetQualityOverride() = 0; //argc: 1, index 7
    virtual unknown_ret SetBitrateOverride() = 0; //argc: 1, index 8
    virtual unknown_ret ShowOnScreenKeyboard() = 0; //argc: 0, index 9
    virtual unknown_ret BQueueControllerConfigMessageForLocal() = 0; //argc: 1, index 10
    virtual unknown_ret BGetControllerConfigMessageForRemote() = 0; //argc: 1, index 11
    virtual unknown_ret GetSystemInfo() = 0; //argc: 0, index 12
    virtual unknown_ret StartStreamingSession() = 0; //argc: 1, index 13
    virtual unknown_ret ReportStreamingSessionEvent() = 0; //argc: 2, index 14
    virtual unknown_ret FinishStreamingSession() = 0; //argc: 3, index 15
};