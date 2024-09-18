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

class IClientAudio
{
public:
    virtual unknown_ret StartVoiceRecording() = 0; //argc: 0, index 1
    virtual unknown_ret StopVoiceRecording() = 0; //argc: 0, index 2
    virtual unknown_ret ResetVoiceRecording() = 0; //argc: 0, index 3
    virtual unknown_ret GetAvailableVoice() = 0; //argc: 3, index 4
    virtual unknown_ret GetVoice() = 0; //argc: 9, index 5
    virtual unknown_ret GetCompressedVoice() = 0; //argc: 3, index 6
    virtual unknown_ret DecompressVoice() = 0; //argc: 6, index 7
    virtual unknown_ret GetVoiceOptimalSampleRate() = 0; //argc: 0, index 8
    virtual unknown_ret BAppUsesVoice() = 0; //argc: 1, index 9
    virtual unknown_ret GetGameSystemVolume() = 0; //argc: 0, index 10
    virtual unknown_ret SetGameSystemVolume() = 0; //argc: 1, index 11
};