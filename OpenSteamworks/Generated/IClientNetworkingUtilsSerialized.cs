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
public unsafe interface IClientNetworkingUtilsSerialized
{
    // WARNING: Arguments are unknown!
    public unknown GetNetworkConfigJSON_DEPRECATED();  // argc: -1, index: 1, ipc args: [bytes4, string], ipc returns: [bytes4, bytes_external_length]
    public unknown GetLauncherType();  // argc: -1, index: 2, ipc args: [], ipc returns: [bytes4]
    public void TEST_ClearCachedNetworkConfig();  // argc: -1, index: 3, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public void PostConnectionStateMsg();  // argc: -1, index: 4, ipc args: [bytes4, bytes_external_length], ipc returns: []
    public void PostConnectionStateUpdatesForAllConnections();  // argc: -1, index: 5, ipc args: [], ipc returns: []
    public void PostAppSummaryUpdates();  // argc: -1, index: 6, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public void GotLocationString(string str);  // argc: -1, index: 7, ipc args: [string], ipc returns: []
}