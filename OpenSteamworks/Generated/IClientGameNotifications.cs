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
public unsafe interface IClientGameNotifications
{
    // WARNING: Arguments are unknown!
    public unknown EnumerateNotifications();  // argc: -1, index: 1, ipc args: [bytes4], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown GetNotificationCount();  // argc: -1, index: 2, ipc args: [bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetNotification();  // argc: -1, index: 3, ipc args: [bytes4, bytes4], ipc returns: [bytes1, bytes_external_length]
    // WARNING: Arguments are unknown!
    public unknown RemoveSession();  // argc: -1, index: 4, ipc args: [bytes4, bytes8], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown UpdateSession();  // argc: -1, index: 5, ipc args: [bytes4, bytes8], ipc returns: []
}