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
    virtual uint32 GetNumActiveBeacons() = 0; //argc: -1, index 1
    virtual PartyBeaconID_t GetBeaconByIndex(uint32 unIndex) = 0; //argc: -1, index 2
    virtual bool GetBeaconDetails(PartyBeaconID_t ulBeaconID, CSteamID *pSteamIDBeaconOwner, SteamPartyBeaconLocation_t *pLocation, char *pchMetadata, int cchMetadata) = 0; //argc: -1, index 3
    virtual SteamAPICall_t JoinParty(PartyBeaconID_t ulBeaconID) = 0; //argc: -1, index 4
    virtual bool GetNumAvailableBeaconLocations(uint32 *puNumLocations) = 0; //argc: -1, index 5
    virtual bool GetAvailableBeaconLocations(SteamPartyBeaconLocation_t *pLocationList, uint32 uMaxNumLocations) = 0; //argc: -1, index 6
    virtual SteamAPICall_t CreateBeacon(uint32 unOpenSlots, SteamPartyBeaconLocation_t *pBeaconLocations, int numBeaconLocations, const char *pchConnectString, const char *pchMetadata) = 0; //argc: -1, index 7
    virtual void OnReservationCompleted(PartyBeaconID_t ulBeacon, CSteamID steamIDUser) = 0; //argc: -1, index 8
    virtual void CancelReservation(PartyBeaconID_t ulBeacon, CSteamID steamIDUser) = 0; //argc: -1, index 9
    virtual SteamAPICall_t ChangeNumOpenSlots(PartyBeaconID_t ulBeacon, uint32 unOpenSlots) = 0; //argc: -1, index 10
    virtual bool DestroyBeacon(PartyBeaconID_t ulBeacon) = 0; //argc: -1, index 11
    virtual bool GetBeaconLocationData(SteamPartyBeaconLocation_t BeaconLocation, ESteamPartyBeaconLocationData eData, char *pchDataStringOut, int cchDataStringOut) = 0; //argc: -1, index 12
    virtual unknown ReservePartySlot() = 0; //argc: -1, index 13
};