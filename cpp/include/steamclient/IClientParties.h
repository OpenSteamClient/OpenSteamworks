//==========================  AUTO-GENERATED FILE  ================================
//
// This file is partially auto-generated.
// If functions are removed, your changes to that function will be lost.
// Parameter types and names however are preserved if the function stays unchanged.
// Feel free to change parameters to be more accurate. 
//
//=============================================================================

#pragma once

#include "clienttypes.h"

class IClientParties
{
public:
    virtual unknown_ret GetNumActiveBeacons() = 0; //argc: 0, index 1
    virtual unknown_ret GetBeaconByIndex() = 0; //argc: 1, index 2
    virtual unknown_ret GetBeaconDetails() = 0; //argc: 6, index 3
    virtual unknown_ret JoinParty() = 0; //argc: 2, index 4
    virtual unknown_ret GetNumAvailableBeaconLocations() = 0; //argc: 1, index 5
    virtual unknown_ret GetAvailableBeaconLocations() = 0; //argc: 2, index 6
    virtual unknown_ret CreateBeacon() = 0; //argc: 5, index 7
    virtual unknown_ret OnReservationCompleted() = 0; //argc: 4, index 8
    virtual unknown_ret CancelReservation() = 0; //argc: 4, index 9
    virtual unknown_ret ChangeNumOpenSlots() = 0; //argc: 3, index 10
    virtual unknown_ret DestroyBeacon() = 0; //argc: 2, index 11
    virtual unknown_ret GetBeaconLocationData() = 0; //argc: 6, index 12
    virtual unknown_ret ReservePartySlot() = 0; //argc: 3, index 13
};