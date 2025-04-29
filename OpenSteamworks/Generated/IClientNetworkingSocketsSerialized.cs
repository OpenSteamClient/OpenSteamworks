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
using OpenSteamworks.Data;
using CppSourceGen.Attributes;

namespace OpenSteamworks.Generated;

[CppClass]
public unsafe interface IClientNetworkingSocketsSerialized
{
    // WARNING: Arguments are unknown!
    public void SendP2PRendezvous(UInt64 unk, uint unk1, ReadOnlySpan<byte> msg, uint msgLen);  // argc: -1, index: 1, ipc args: [uint64, bytes4, bytes4, bytes_external_length], ipc returns: []
    // WARNING: Arguments are unknown!
    public void SendP2PConnectionFailureLegacy(UInt64 unk, uint unk1, uint unk2, string str);  // argc: -1, index: 2, ipc args: [uint64, bytes4, bytes4, string], ipc returns: []
    public SteamAPICall_t GetCertAsync();  // argc: -1, index: 3, ipc args: [], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public void CacheRelayTicket(Span<byte> msg, uint len);  // argc: -1, index: 4, ipc args: [bytes4, bytes_external_length], ipc returns: []
    public uint GetCachedRelayTicketCount();  // argc: -1, index: 5, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public uint GetCachedRelayTicket(uint unk, uint unk1);  // argc: -1, index: 6, ipc args: [bytes4, bytes4], ipc returns: [bytes4, bytes_external_length]
    public bool GetSTUNServer(AppId_t appid, StringBuilder builder, int max);  // argc: -1, index: 7, ipc args: [bytes4, bytes4], ipc returns: [bytes1, bytes_external_length]
    // WARNING: Arguments are unknown!
    public uint AllowDirectConnectToPeerString(string peerString);  // argc: -1, index: 8, ipc args: [string], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public ulong BeginAsyncRequestFakeIP(uint unk);  // argc: -1, index: 9, ipc args: [bytes4], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown AllowDirectConnectToPeerString(string peerString, out uint unk);  // argc: -1, index: 10, ipc args: [string], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public void SetAllowShareIPUserSetting(uint setting);  // argc: -1, index: 11, ipc args: [bytes4], ipc returns: []
    public uint GetAllowShareIPUserSetting();  // argc: -1, index: 12, ipc args: [], ipc returns: [bytes4]
    public void TEST_ClearInMemoryCachedCredentials();  // argc: -1, index: 13, ipc args: [], ipc returns: []
}