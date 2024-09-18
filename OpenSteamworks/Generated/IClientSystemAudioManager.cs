//==========================  AUTO-GENERATED FILE  ================================
//
// This file is partially auto-generated.
// If functions are removed, your changes to that function will be lost.
// Parameter types and names however are preserved if the function stays unchanged.
// Feel free to change parameters to be more accurate. 
//=============================================================================

using System;
using OpenSteamworks.Attributes;
using OpenSteamworks.Protobuf;
using OpenSteamworks.Data;

namespace OpenSteamworks.Generated;

[CppInterface]
public unsafe interface IClientSystemAudioManager
{
    public bool IsInterfaceValid();  // argc: 0, index: 1, ipc args: [], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public bool GetState(uint unk, out CMsgSystemAudioManagerState state);  // argc: 2, index: 2, ipc args: [bytes4], ipc returns: [bytes1, unknown]
    // WARNING: Arguments are unknown!
    public ulong UpdateSomething(CMsgSystemAudioManagerUpdateSomething update);  // argc: 1, index: 3, ipc args: [protobuf], ipc returns: [bytes8]
}