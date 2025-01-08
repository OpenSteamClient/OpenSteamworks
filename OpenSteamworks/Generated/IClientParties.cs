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
public unsafe interface IClientParties
{
    public unknown GetNumActiveBeacons();  // argc: 0, index: 1, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetBeaconByIndex();  // argc: 1, index: 2, ipc args: [bytes4], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown GetBeaconDetails();  // argc: 6, index: 3, ipc args: [bytes8, bytes4], ipc returns: [bytes1, uint64, bytes12, bytes_length_from_mem]
    // WARNING: Arguments are unknown!
    public unknown JoinParty();  // argc: 2, index: 4, ipc args: [bytes8], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown GetNumAvailableBeaconLocations();  // argc: 1, index: 5, ipc args: [], ipc returns: [bytes1, bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetAvailableBeaconLocations();  // argc: 2, index: 6, ipc args: [bytes4], ipc returns: [bytes1, bytes_length_from_reg]
    // WARNING: Arguments are unknown!
    public unknown CreateBeacon();  // argc: 5, index: 7, ipc args: [bytes4, bytes4, bytes_length_from_reg, string, string], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown OnReservationCompleted();  // argc: 4, index: 8, ipc args: [bytes8, uint64], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown CancelReservation();  // argc: 4, index: 9, ipc args: [bytes8, uint64], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown ChangeNumOpenSlots();  // argc: 3, index: 10, ipc args: [bytes8, bytes4], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown DestroyBeacon();  // argc: 2, index: 11, ipc args: [bytes8], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown GetBeaconLocationData();  // argc: 6, index: 12, ipc args: [bytes12, bytes4, bytes4], ipc returns: [bytes1, bytes_length_from_mem]
    // WARNING: Arguments are unknown!
    public unknown ReservePartySlot();  // argc: 3, index: 13, ipc args: [bytes4, bytes8], ipc returns: [bytes8]
}