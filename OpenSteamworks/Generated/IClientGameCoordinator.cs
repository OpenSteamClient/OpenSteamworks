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

namespace OpenSteamworks.Generated;

[CppInterface]
public unsafe interface IClientGameCoordinator
{
    // WARNING: Arguments are unknown!
    public unknown_ret SendMessage();  // argc: 4, index: 1, ipc args: [bytes4, bytes4, bytes4, bytes_length_from_mem], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown_ret IsMessageAvailable();  // argc: 2, index: 2, ipc args: [bytes4], ipc returns: [boolean, bytes4]
    // WARNING: Arguments are unknown!
    public unknown_ret RetrieveMessage();  // argc: 5, index: 3, ipc args: [bytes4, bytes4], ipc returns: [bytes4, bytes4, bytes4, bytes_length_from_mem]
}