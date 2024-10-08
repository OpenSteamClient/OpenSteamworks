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
    virtual void StartVoiceRecording() = 0; //argc: 0, index 1
    virtual void StopVoiceRecording() = 0; //argc: 0, index 2
    virtual void ResetVoiceRecording() = 0; //argc: 0, index 3
    virtual EVoiceResult GetAvailableVoice(uint32 *pcbCompressed, uint32 *pcbUncompressed, uint32 nUncompressedVoiceDesiredSampleRate) = 0; //argc: 3, index 4
    virtual EVoiceResult GetVoice(bool bWantCompressed, void *pDestBuffer, uint32 cbDestBufferSize, uint32 *nBytesWritten, bool bWantUncompressed, void *pUncompressedDestBuffer, uint32 cbUncompressedDestBufferSize, uint32 *nUncompressBytesWritten, uint32 nUncompressedVoiceDesiredSampleRate) = 0; //argc: 9, index 5
    virtual EVoiceResult GetCompressedVoice(void *pDestBuffer, uint32 cbDestBufferSize, uint32 *nBytesWritten) = 0; //argc: 3, index 6
    virtual EVoiceResult DecompressVoice(const void *pCompressed, uint32 cbCompressed, void *pDestBuffer, uint32 cbDestBufferSize, uint32 *nBytesWritten, uint32 nDesiredSampleRate) = 0; //argc: 6, index 7
    virtual uint32 GetVoiceOptimalSampleRate() = 0; //argc: 0, index 8
    virtual bool BAppUsesVoice(AppId_t) = 0; //argc: 1, index 9
    virtual float GetGameSystemVolume() = 0; //argc: 0, index 10
    virtual void SetGameSystemVolume(float) = 0; //argc: 1, index 11
};