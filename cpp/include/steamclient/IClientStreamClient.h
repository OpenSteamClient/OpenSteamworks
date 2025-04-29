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
    virtual unknown Launched() = 0; //argc: -1, index 1
    virtual unknown FocusGained() = 0; //argc: -1, index 2
    virtual unknown FocusLost() = 0; //argc: -1, index 3
    virtual unknown Finished() = 0; //argc: -1, index 4
    virtual unknown BGetStreamingClientConfig() = 0; //argc: -1, index 5
    virtual unknown BSaveStreamingClientConfig() = 0; //argc: -1, index 6
    virtual unknown SetQualityOverride() = 0; //argc: -1, index 7
    virtual unknown SetBitrateOverride() = 0; //argc: -1, index 8
    virtual unknown ShowOnScreenKeyboard() = 0; //argc: -1, index 9
    virtual unknown BQueueControllerConfigMessageForLocal() = 0; //argc: -1, index 10
    virtual unknown BGetControllerConfigMessageForRemote() = 0; //argc: -1, index 11
    virtual unknown GetSystemInfo() = 0; //argc: -1, index 12
    virtual unknown StartStreamingSession() = 0; //argc: -1, index 13
    virtual unknown ReportStreamingSessionEvent() = 0; //argc: -1, index 14
    virtual unknown FinishStreamingSession() = 0; //argc: -1, index 15
};