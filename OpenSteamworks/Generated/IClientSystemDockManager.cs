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
public unsafe interface IClientSystemDockManager
{
    public bool IsInterfaceValid();  // argc: -1, index: 1, ipc args: [], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown GetState();  // argc: -1, index: 2, ipc args: [], ipc returns: [bytes1, protobuf]
    // WARNING: Arguments are unknown!
    public unknown UpdateFirmware();  // argc: -1, index: 3, ipc args: [protobuf], ipc returns: [bytes8]
    public bool DisarmSafetyNet();  // argc: -1, index: 4, ipc args: [], ipc returns: [bytes1]
}