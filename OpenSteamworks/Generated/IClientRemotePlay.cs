//==========================  AUTO-GENERATED FILE  ================================
//
// This file is partially auto-generated.
// If functions are removed, your changes to that function will be lost.
// Parameter types and names however are preserved if the function stays unchanged.
// Feel free to change parameters to be more accurate. 
//=============================================================================

using System;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data.Structs;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data;
using CppSourceGen.Attributes;

namespace OpenSteamworks.Generated;

[CppClass]
public unsafe interface IClientRemotePlay
{
    public int GetSessionCount();  // argc: -1, index: 1, ipc args: [], ipc returns: [bytes4]
    public RemotePlaySessionID_t GetSessionID(int index);  // argc: -1, index: 2, ipc args: [bytes4], ipc returns: [bytes4]
    public CSteamID GetSessionSteamID(RemotePlaySessionID_t unSessionID, int unk);  // argc: -1, index: 3, ipc args: [bytes4], ipc returns: [uint64]
    public string GetSessionClientName(RemotePlaySessionID_t unSessionID);  // argc: -1, index: 4, ipc args: [bytes4], ipc returns: [string]
    public ESteamDeviceFormFactor GetSessionClientFormFactor(RemotePlaySessionID_t unSessionID);  // argc: -1, index: 5, ipc args: [bytes4], ipc returns: [bytes4]
    public bool BGetSessionClientResolution(RemotePlaySessionID_t unSessionID, out int pnResolutionX, out int pnResolutionY);  // argc: -1, index: 6, ipc args: [bytes4], ipc returns: [boolean, bytes4, bytes4]
    public unknown ShowRemotePlayTogetherUI();  // argc: -1, index: 7, ipc args: [], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public bool BSendRemotePlayTogetherInvite(CSteamID recipientFriend);  // argc: -1, index: 8, ipc args: [uint64], ipc returns: [boolean]
    public unknown BEnableRemotePlayTogetherInputEvents();  // argc: -1, index: 9, ipc args: [], ipc returns: [boolean]
    public unknown DisableRemotePlayTogetherInputEvents();  // argc: -1, index: 10, ipc args: [], ipc returns: []
    public unknown CreateRemotePlayTogetherMouseCursor();  // argc: -1, index: 11, ipc args: [bytes4, bytes4, bytes4, bytes4, utlbuf], ipc returns: [bytes4]
}