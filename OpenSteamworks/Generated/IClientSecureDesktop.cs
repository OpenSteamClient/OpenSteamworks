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
public unsafe interface IClientSecureDesktop
{
    public bool BStartStreaming();  // argc: 0, index: 1, ipc args: [], ipc returns: [boolean]
    public void StopStreaming();  // argc: 0, index: 2, ipc args: [], ipc returns: []
    public void SendSAS();  // argc: 0, index: 3, ipc args: [], ipc returns: []
}