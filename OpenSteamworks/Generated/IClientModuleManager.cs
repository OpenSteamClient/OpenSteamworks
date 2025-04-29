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
public unsafe interface IClientModuleManager
{
    // WARNING: Arguments are unknown!
    public unknown LoadModule();  // argc: -1, index: 1, ipc args: [bytes4, bytes4, bytes_external_length], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown UnloadModule();  // argc: -1, index: 2, ipc args: [bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown CallFunction();  // argc: -1, index: 3, ipc args: [bytes4, bytes4, bytes4, bytes4, bytes_external_length, bytes4], ipc returns: [bytes4, bytes_external_length, bytes4]
    // WARNING: Arguments are unknown!
    public unknown CallFunctionAsync();  // argc: -1, index: 4, ipc args: [bytes4, bytes4, bytes4, bytes4, bytes4, bytes4, bytes4, bytes_external_length, bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown PollResponseAsync();  // argc: -1, index: 5, ipc args: [bytes4, bytes4, bytes4], ipc returns: [bytes4, bytes_external_length, bytes4]
    // WARNING: Arguments are unknown!
    public unknown SetProtonEnvironment(AppId_t appid, string envdata);  // argc: -1, index: 6, ipc args: [bytes4, string], ipc returns: []
}