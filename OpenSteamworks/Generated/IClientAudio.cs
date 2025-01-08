//==========================  AUTO-GENERATED FILE  ================================
//
// This file is partially auto-generated.
// If functions are removed, your changes to that function will be lost.
// Parameter types and names however are preserved if the function stays unchanged.
// Feel free to change parameters to be more accurate. 
//=============================================================================

using System;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data;
using CppSourceGen.Attributes;

namespace OpenSteamworks.Generated;

[CppClass]
public unsafe interface IClientAudio
{
    public unknown StartVoiceRecording();  // argc: 0, index: 1, ipc args: [], ipc returns: []
    public unknown StopVoiceRecording();  // argc: 0, index: 2, ipc args: [], ipc returns: []
    public unknown ResetVoiceRecording();  // argc: 0, index: 3, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown GetAvailableVoice();  // argc: 3, index: 4, ipc args: [bytes4], ipc returns: [bytes4, bytes4, bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetVoice();  // argc: 9, index: 5, ipc args: [bytes1, bytes4, bytes1, bytes4, bytes4], ipc returns: [bytes4, bytes4, bytes_length_from_reg, bytes4, bytes_length_from_reg]
    // WARNING: Arguments are unknown!
    public unknown GetCompressedVoice();  // argc: 3, index: 6, ipc args: [bytes4], ipc returns: [bytes4, bytes4, bytes_length_from_mem]
    // WARNING: Arguments are unknown!
    public unknown DecompressVoice();  // argc: 6, index: 7, ipc args: [bytes4, bytes_length_from_mem, bytes4, bytes4], ipc returns: [bytes4, bytes4, bytes_length_from_reg]
    public unknown GetVoiceOptimalSampleRate();  // argc: 0, index: 8, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown BAppUsesVoice();  // argc: 1, index: 9, ipc args: [bytes4], ipc returns: [boolean]
    public unknown GetGameSystemVolume();  // argc: 0, index: 10, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown SetGameSystemVolume();  // argc: 1, index: 11, ipc args: [bytes4], ipc returns: []
}