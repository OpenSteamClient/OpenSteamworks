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
public unsafe interface IClientGameServerPacketHandler
{
    // WARNING: Arguments are unknown!
    public unknown HandleIncomingPacket();  // argc: -1, index: 1, ipc args: [bytes4, bytes_external_length, bytes4, bytes2], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown GetNextOutgoingPacket();  // argc: -1, index: 2, ipc args: [bytes4], ipc returns: [bytes4, bytes_external_length, bytes4, bytes2]
}