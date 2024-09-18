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


namespace OpenSteamworks.Generated;

[CppInterface]
public unsafe interface IClientSharedConnection
{
    public HSharedConnection AllocateSharedConnection();  // argc: 0, index: 1, ipc args: [], ipc returns: [bytes4]
    public void ReleaseSharedConnection(HSharedConnection connection);  // argc: 1, index: 2, ipc args: [bytes4], ipc returns: []
    public int SendMessage(HSharedConnection connection, byte[] msg, UInt32 size);  // argc: 3, index: 3, ipc args: [bytes4, bytes4, bytes_length_from_mem], ipc returns: [bytes1]
    public int SendMessageAndAwaitResponse(HSharedConnection connection, byte[] msg, UInt32 size);  // argc: 3, index: 4, ipc args: [bytes4, bytes4, bytes_length_from_mem], ipc returns: [bytes4]
    public void RegisterEMsgHandler(HSharedConnection hConn, EMsg eMsg);  // argc: 2, index: 5, ipc args: [bytes4, bytes4], ipc returns: []
    public void RegisterServiceMethodHandler(HSharedConnection hConn, string method);  // argc: 2, index: 6, ipc args: [bytes4, string], ipc returns: []
    public bool BPopReceivedMessage(HSharedConnection hConn, in CUtlBuffer bufOut, out UInt32 hCall);  // argc: 3, index: 7, ipc args: [bytes4], ipc returns: [boolean, unknown, bytes4]
    public void InitiateConnection(HSharedConnection connection);  // argc: 1, index: 8, ipc args: [bytes4], ipc returns: []
}