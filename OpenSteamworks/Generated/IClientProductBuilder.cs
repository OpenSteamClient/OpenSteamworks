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
public unsafe interface IClientProductBuilder
{
    // WARNING: Arguments are unknown!
    public unknown_ret SignInstallScript();  // argc: 3, index: 1, ipc args: [bytes4, string, string], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown_ret DRMWrap();  // argc: 6, index: 2, ipc args: [bytes4, string, string, string, bytes4, bytes4], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown_ret CEGWrap();  // argc: 4, index: 3, ipc args: [bytes4, string, string, string], ipc returns: [bytes8]
}