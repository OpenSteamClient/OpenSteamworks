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
public unsafe interface IClientNetworking
{
    // WARNING: Arguments are unknown!
    public unknown SendP2PPacket();  // argc: -1, index: 1, ipc args: [uint64, bytes4, bytes_external_length, bytes4, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown IsP2PPacketAvailable();  // argc: -1, index: 2, ipc args: [bytes4], ipc returns: [boolean, bytes4]
    // WARNING: Arguments are unknown!
    public unknown ReadP2PPacket();  // argc: -1, index: 3, ipc args: [bytes4, bytes4], ipc returns: [bytes1, bytes4, uint64, bytes_external_length]
    // WARNING: Arguments are unknown!
    public unknown AcceptP2PSessionWithUser();  // argc: -1, index: 4, ipc args: [uint64], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown CloseP2PSessionWithUser();  // argc: -1, index: 5, ipc args: [uint64], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown CloseP2PChannelWithUser();  // argc: -1, index: 6, ipc args: [uint64, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown GetP2PSessionState();  // argc: -1, index: 7, ipc args: [uint64], ipc returns: [bytes1, bytes20]
    // WARNING: Arguments are unknown!
    public unknown AllowP2PPacketRelay();  // argc: -1, index: 8, ipc args: [bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown CreateListenSocket();  // argc: -1, index: 9, ipc args: [bytes4, bytes20, bytes2, bytes1], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown CreateP2PConnectionSocket();  // argc: -1, index: 10, ipc args: [uint64, bytes4, bytes4, bytes1], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown CreateConnectionSocket();  // argc: -1, index: 11, ipc args: [bytes20, bytes2, bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown DestroySocket();  // argc: -1, index: 12, ipc args: [bytes4, bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown DestroyListenSocket();  // argc: -1, index: 13, ipc args: [bytes4, bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SendDataOnSocket();  // argc: -1, index: 14, ipc args: [bytes4, bytes4, bytes1, bytes_external_length], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown IsDataAvailableOnSocket();  // argc: -1, index: 15, ipc args: [bytes4], ipc returns: [boolean, bytes4]
    // WARNING: Arguments are unknown!
    public unknown RetrieveDataFromSocket();  // argc: -1, index: 16, ipc args: [bytes4, bytes4], ipc returns: [bytes1, bytes4, bytes_external_length]
    // WARNING: Arguments are unknown!
    public unknown IsDataAvailable();  // argc: -1, index: 17, ipc args: [bytes4], ipc returns: [boolean, bytes4, bytes4]
    // WARNING: Arguments are unknown!
    public unknown RetrieveData();  // argc: -1, index: 18, ipc args: [bytes4, bytes4], ipc returns: [bytes1, bytes4, bytes4, bytes_external_length]
    // WARNING: Arguments are unknown!
    public unknown GetSocketInfo();  // argc: -1, index: 19, ipc args: [bytes4], ipc returns: [bytes1, uint64, bytes4, bytes20, bytes2]
    // WARNING: Arguments are unknown!
    public unknown GetListenSocketInfo();  // argc: -1, index: 20, ipc args: [bytes4], ipc returns: [bytes1, bytes20, bytes2]
    // WARNING: Arguments are unknown!
    public unknown GetSocketConnectionType();  // argc: -1, index: 21, ipc args: [bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetMaxPacketSize();  // argc: -1, index: 22, ipc args: [bytes4], ipc returns: [bytes4]
}