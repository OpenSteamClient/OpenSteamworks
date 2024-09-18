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

class IClientNetworkDeviceManager
{
public:
    virtual unknown_ret IsInterfaceValid() = 0; //argc: 0, index 1
    virtual unknown_ret RefreshDevices() = 0; //argc: 0, index 2
    virtual unknown_ret GetNetworkDevicesData() = 0; //argc: 1, index 3
    virtual unknown_ret ConnectToDevice() = 0; //argc: 1, index 4
    virtual unknown_ret DisconnectFromDevice() = 0; //argc: 1, index 5
    virtual unknown_ret SetWifiEnabled() = 0; //argc: 1, index 6
    virtual unknown_ret SetWifiScanningEnabled() = 0; //argc: 1, index 7
    virtual unknown_ret ForgetWirelessEndpoint() = 0; //argc: 2, index 8
    virtual unknown_ret SetWirelessEndpointAutoconnect() = 0; //argc: 3, index 9
    virtual unknown_ret SetCustomIPSettings() = 0; //argc: 6, index 10
    virtual unknown_ret GetCustomIPSettings() = 0; //argc: 6, index 11
    virtual unknown_ret SetProxyInfo() = 0; //argc: 4, index 12
    virtual unknown_ret GetProxyInfo() = 0; //argc: 5, index 13
    virtual unknown_ret GetObviousConnectivityProblem() = 0; //argc: 0, index 14
    virtual unknown_ret TEST_SetFakeLocalSystemStateSetting() = 0; //argc: 1, index 15
    virtual unknown_ret TEST_GetFakeLocalSystemStateSetting() = 0; //argc: 0, index 16
    virtual unknown_ret TEST_GetFakeLocalSystemEffectiveState() = 0; //argc: 0, index 17
    virtual unknown_ret TEST_SetEmulateSingleWirelessDevice() = 0; //argc: 1, index 18
    virtual unknown_ret TEST_GetEmulateSingleWirelessDevice() = 0; //argc: 0, index 19
    virtual unknown_ret LEGACY_EnumerateNetworkDevices() = 0; //argc: 2, index 20
    virtual unknown_ret LEGACY_GetDeviceType() = 0; //argc: 1, index 21
    virtual unknown_ret LEGACY_IsCurrentDevice() = 0; //argc: 1, index 22
    virtual unknown_ret LEGACY_IsCurrentlyConnected() = 0; //argc: 1, index 23
    virtual unknown_ret LEGACY_GetDeviceIP4() = 0; //argc: 3, index 24
    virtual unknown_ret LEGACY_GetDeviceBroadcastIP4() = 0; //argc: 3, index 25
    virtual unknown_ret LEGACY_GetDeviceIPV6InterfaceIndex() = 0; //argc: 1, index 26
    virtual unknown_ret LEGACY_GetDeviceVendor() = 0; //argc: 1, index 27
    virtual unknown_ret LEGACY_GetDeviceProduct() = 0; //argc: 1, index 28
    virtual unknown_ret LEGACY_GetMacAddress() = 0; //argc: 1, index 29
    virtual unknown_ret LEGACY_GetSubnetMaskBitCount() = 0; //argc: 3, index 30
    virtual unknown_ret LEGACY_GetRouterAddressIP4() = 0; //argc: 3, index 31
    virtual unknown_ret LEGACY_GetDNSResolversIP4() = 0; //argc: 3, index 32
    virtual unknown_ret LEGACY_GetDeviceState() = 0; //argc: 1, index 33
    virtual unknown_ret LEGACY_GetDevicePluggedState() = 0; //argc: 1, index 34
    virtual unknown_ret LEGACY_EnumerateWirelessEndpoints() = 0; //argc: 3, index 35
    virtual unknown_ret LEGACY_GetConnectedWirelessEndpointSSID() = 0; //argc: 1, index 36
    virtual unknown_ret LEGACY_GetWirelessSecurityCapabilities() = 0; //argc: 1, index 37
    virtual unknown_ret LEGACY_GetWirelessEndpointSSIDUserDisplayString() = 0; //argc: 2, index 38
    virtual unknown_ret LEGACY_GetWirelessEndpointStrength() = 0; //argc: 2, index 39
    virtual unknown_ret LEGACY_IsSecurityRequired() = 0; //argc: 2, index 40
    virtual unknown_ret LEGACY_GetCachedWirelessCredentials() = 0; //argc: 2, index 41
    virtual unknown_ret LEGACY_IsWirelessEndpointForgettable() = 0; //argc: 2, index 42
    virtual unknown_ret LEGACY_IsUsingDHCP() = 0; //argc: 1, index 43
};