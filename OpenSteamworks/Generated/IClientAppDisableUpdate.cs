//==========================  AUTO-GENERATED FILE  ================================
//
// This file is partially auto-generated.
// If functions are removed, your changes to that function will be lost.
// Parameter types and names however are preserved if the function stays unchanged.
// Feel free to change parameters to be more accurate. 
//=============================================================================

using System;
using System.Text;
using OpenSteamworks.Attributes;
using OpenSteamworks.Native;
using OpenSteamworks.Data;

namespace OpenSteamworks.Generated;

[CppInterface]
public unsafe interface IClientAppDisableUpdate
{
    public unknown_ret SetAppUpdateDisabledSecondsRemaining(AppId_t appId, uint disableLength);  // argc: 2, index: 1, ipc args: [bytes4, bytes4], ipc returns: []
}