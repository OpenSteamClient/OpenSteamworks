//==========================  AUTO-GENERATED FILE  ================================
//
// This file is partially auto-generated.
// If functions are removed, your changes to that function will be lost.
// Parameter types and names however are preserved if the function stays unchanged.
// Feel free to change parameters to be more accurate. 
//=============================================================================

using System;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data;
using CppSourceGen.Attributes;

namespace OpenSteamworks.Generated;

[CppClass]
public unsafe interface IClientUnifiedMessages
{
    // WARNING: Arguments are unknown!
    public ulong SendMethod(string method, ReadOnlySpan<byte> msg, uint msgLen, ulong previousCallHandle = 0);  // argc: -1, index: 1, ipc args: [string, bytes4, bytes_external_length, bytes8], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public bool GetMethodResponseInfo(ulong methodID, out uint unk, out EResult eResult);  // argc: -1, index: 2, ipc args: [bytes8], ipc returns: [bytes1, bytes4, bytes4]
    // WARNING: Arguments are unknown!
    public bool GetMethodResponseData(ulong methodID, Span<byte> buf, uint bufLen, bool unk);  // argc: -1, index: 3, ipc args: [bytes8, bytes4, bytes1], ipc returns: [bytes1, bytes_external_length]
    // WARNING: Arguments are unknown!
    public bool ReleaseMethod(ulong methodID);  // argc: -1, index: 4, ipc args: [bytes8], ipc returns: [bytes1]
    public bool SendNotification(string method, ReadOnlySpan<byte> msg, uint msgLen);  // argc: -1, index: 5, ipc args: [string, bytes4, bytes_external_length], ipc returns: [bytes1]
}