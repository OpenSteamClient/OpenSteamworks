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
    public unknown SendP2PPacket();  // argc: 6, index: 1, ipc args: [uint64, bytes4, bytes_length_from_mem, bytes4, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown IsP2PPacketAvailable();  // argc: 2, index: 2, ipc args: [bytes4], ipc returns: [boolean, bytes4]
    // WARNING: Arguments are unknown!
    public unknown ReadP2PPacket();  // argc: 5, index: 3, ipc args: [bytes4, bytes4], ipc returns: [bytes1, bytes4, uint64, bytes_length_from_reg]
    // WARNING: Arguments are unknown!
    public unknown AcceptP2PSessionWithUser();  // argc: 2, index: 4, ipc args: [uint64], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown CloseP2PSessionWithUser();  // argc: 2, index: 5, ipc args: [uint64], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown CloseP2PChannelWithUser();  // argc: 3, index: 6, ipc args: [uint64, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown GetP2PSessionState();  // argc: 3, index: 7, ipc args: [uint64], ipc returns: [bytes1, bytes20]
    // WARNING: Arguments are unknown!
    public unknown AllowP2PPacketRelay();  // argc: 1, index: 8, ipc args: [bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown CreateListenSocket();  // argc: 8, index: 9, ipc args: [bytes4, bytes20, bytes2, bytes1], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown CreateP2PConnectionSocket();  // argc: 5, index: 10, ipc args: [uint64, bytes4, bytes4, bytes1], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown CreateConnectionSocket();  // argc: 7, index: 11, ipc args: [bytes20, bytes2, bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown DestroySocket();  // argc: 2, index: 12, ipc args: [bytes4, bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown DestroyListenSocket();  // argc: 2, index: 13, ipc args: [bytes4, bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SendDataOnSocket();  // argc: 4, index: 14, ipc args: [bytes4, bytes4, bytes1, bytes_length_from_mem], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown IsDataAvailableOnSocket();  // argc: 2, index: 15, ipc args: [bytes4], ipc returns: [boolean, bytes4]
    // WARNING: Arguments are unknown!
    public unknown RetrieveDataFromSocket();  // argc: 4, index: 16, ipc args: [bytes4, bytes4], ipc returns: [bytes1, bytes4, bytes_length_from_reg]
    // WARNING: Arguments are unknown!
    public unknown IsDataAvailable();  // argc: 3, index: 17, ipc args: [bytes4], ipc returns: [boolean, bytes4, bytes4]
    // WARNING: Arguments are unknown!
    public unknown RetrieveData();  // argc: 5, index: 18, ipc args: [bytes4, bytes4], ipc returns: [bytes1, bytes4, bytes4, bytes_length_from_reg]
    // WARNING: Arguments are unknown!
    public unknown GetSocketInfo();  // argc: 5, index: 19, ipc args: [bytes4], ipc returns: [bytes1, uint64, bytes4, bytes20, bytes2]
    // WARNING: Arguments are unknown!
    public unknown GetListenSocketInfo();  // argc: 3, index: 20, ipc args: [bytes4], ipc returns: [bytes1, bytes20, bytes2]
    // WARNING: Arguments are unknown!
    public unknown GetSocketConnectionType();  // argc: 1, index: 21, ipc args: [bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetMaxPacketSize();  // argc: 1, index: 22, ipc args: [bytes4], ipc returns: [bytes4]
}