//==========================  AUTO-GENERATED FILE  ================================
//
// This file is partially auto-generated.
// If functions are removed, your changes to that function will be lost.
// Parameter types and names however are preserved if the function stays unchanged.
// Feel free to change parameters to be more accurate. 
//=============================================================================

using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data;
using OpenSteamworks.Protobuf;

using CppSourceGen.Attributes;
using OpenSteamworks.Data.Interop;

namespace OpenSteamworks.Generated;

[CppClass]
public unsafe interface IClientSharedConnection
{
    public HSharedConnection AllocateSharedConnection();  // argc: -1, index: 1, ipc args: [], ipc returns: [bytes4]
    public void ReleaseSharedConnection(HSharedConnection connection);  // argc: -1, index: 2, ipc args: [bytes4], ipc returns: []
    public bool SendMessage(HSharedConnection connection, ReadOnlySpan<byte> msg, UInt32 size);  // argc: -1, index: 3, ipc args: [bytes4, bytes4, bytes_external_length], ipc returns: [bytes1]
    public HSharedConnectionMsg SendMessageAndAwaitResponse(HSharedConnection connection, ReadOnlySpan<byte> msg, UInt32 size);  // argc: -1, index: 4, ipc args: [bytes4, bytes4, bytes_external_length], ipc returns: [bytes4]
    public void RegisterEMsgHandler(HSharedConnection hConn, EMsg eMsg);  // argc: -1, index: 5, ipc args: [bytes4, bytes4], ipc returns: []
    public void RegisterServiceMethodHandler(HSharedConnection hConn, string method);  // argc: -1, index: 6, ipc args: [bytes4, string], ipc returns: []
    public bool BPopReceivedMessage(HSharedConnection hConn, in CUtlBuffer bufOut, out HSharedConnectionMsg hCall);  // argc: -1, index: 7, ipc args: [bytes4], ipc returns: [boolean, utlbuf, bytes4]
    public void InitiateConnection(HSharedConnection connection);  // argc: -1, index: 8, ipc args: [bytes4], ipc returns: []
}