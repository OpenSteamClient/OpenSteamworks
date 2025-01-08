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
public unsafe interface IClientSystemManager
{
    // WARNING: Arguments are unknown!
    public unknown GetSettings();  // argc: 1, index: 1, ipc args: [], ipc returns: [bytes1, unknown]
    // WARNING: Arguments are unknown!
    public unknown UpdateSettings();  // argc: 1, index: 2, ipc args: [protobuf], ipc returns: [bytes8]
    public unknown ShutdownSystem();  // argc: 0, index: 3, ipc args: [], ipc returns: []
    public unknown SuspendSystem();  // argc: 0, index: 4, ipc args: [], ipc returns: []
    public unknown RestartSystem();  // argc: 0, index: 5, ipc args: [], ipc returns: []
    public unknown FactoryReset();  // argc: 0, index: 6, ipc args: [], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown RebootToFactoryTestImage();  // argc: 1, index: 7, ipc args: [bytes1], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown GetDisplayBrightness();  // argc: 1, index: 8, ipc args: [], ipc returns: [bytes1, bytes4]
    // WARNING: Arguments are unknown!
    public unknown SetDisplayBrightness();  // argc: 1, index: 9, ipc args: [bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown FormatRemovableStorage();  // argc: 1, index: 10, ipc args: [bytes1], ipc returns: [bytes8]
    public unknown GetOSBranchList();  // argc: 0, index: 11, ipc args: [], ipc returns: [bytes8]
    public unknown GetCurrentOSBranch();  // argc: 0, index: 12, ipc args: [], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown SelectOSBranch();  // argc: 1, index: 13, ipc args: [protobuf], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown GetUpdateState();  // argc: 1, index: 14, ipc args: [], ipc returns: [bytes1, unknown]
    public unknown CheckForUpdate();  // argc: 0, index: 15, ipc args: [], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown ApplyUpdate();  // argc: 1, index: 16, ipc args: [protobuf], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown SetBackgroundUpdateCheckInterval();  // argc: 1, index: 17, ipc args: [bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown ClearAudioDefaults();  // argc: 1, index: 18, ipc args: [bytes4], ipc returns: [bytes8]
    public unknown RunDeckMicEnableHack();  // argc: 0, index: 19, ipc args: [], ipc returns: [bytes8]
    public unknown RunDeckEchoCancellationHack();  // argc: 0, index: 20, ipc args: [], ipc returns: [bytes8]
}