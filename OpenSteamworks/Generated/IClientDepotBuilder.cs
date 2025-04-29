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
public unsafe interface IClientDepotBuilder
{
    // WARNING: Arguments are unknown!
    public unknown BGetDepotBuildStatus();  // argc: -1, index: 1, ipc args: [bytes8], ipc returns: [boolean, bytes4, bytes8, bytes8]
    // WARNING: Arguments are unknown!
    public unknown VerifyChunkStore();  // argc: -1, index: 2, ipc args: [bytes4, bytes4, string], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public SteamAPICall_t DownloadDepot(AppId_t appid, DepotId_t depotId, uint workshopItemID, uint depotFlagsFilter, ulong targetManifestID, ulong deltaManifestID, string? targetInstallPath);  // argc: -1, index: 3, ipc args: [bytes4, bytes4, bytes8, bytes8, bytes8, string], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public unknown DownloadChunk();  // argc: -1, index: 4, ipc args: [bytes4, bytes4, bytes4], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown StartDepotBuild();  // argc: -1, index: 5, ipc args: [bytes4, bytes4, bytes4, string], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown CommitAppBuild();  // argc: -1, index: 6, ipc args: [bytes4, bytes4, bytes_external_length, bytes_external_length, bytes1, string, string], ipc returns: [bytes8]
}