//==========================  AUTO-GENERATED FILE  ================================
//
// This file is partially auto-generated.
// If functions are removed, your changes to that function will be lost.
// Parameter types and names however are preserved if the function stays unchanged.
// Feel free to change parameters to be more accurate. 
//=============================================================================

using System;
using OpenSteamworks.Attributes;
using OpenSteamworks.Protobuf;
using OpenSteamworks.Data;
using CppSourceGen.Attributes;

namespace OpenSteamworks.Generated;

[CppClass]
public unsafe interface IClientNetworkDeviceManager
{
    public bool IsInterfaceValid();  // argc: -1, index: 1, ipc args: [], ipc returns: [boolean]
    public void RefreshDevices();  // argc: -1, index: 2, ipc args: [], ipc returns: []
    public bool GetNetworkDevicesData(out CMsgNetworkDevicesData data);  // argc: -1, index: 3, ipc args: [], ipc returns: [bytes1, protobuf]
    // WARNING: Arguments are unknown!
    public unknown ConnectToDevice();  // argc: -1, index: 4, ipc args: [protobuf], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown DisconnectFromDevice();  // argc: -1, index: 5, ipc args: [bytes4], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown SetWifiEnabled();  // argc: -1, index: 6, ipc args: [bytes1], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown SetWifiScanningEnabled();  // argc: -1, index: 7, ipc args: [bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown ForgetWirelessEndpoint();  // argc: -1, index: 8, ipc args: [bytes4, bytes4], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown SetWirelessEndpointAutoconnect();  // argc: -1, index: 9, ipc args: [bytes4, bytes4, bytes1], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown SetCustomIPSettings();  // argc: -1, index: 10, ipc args: [bytes4, bytes4, bytes4, bytes4, bytes4, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown GetCustomIPSettings();  // argc: -1, index: 11, ipc args: [bytes4], ipc returns: [bytes1, bytes4, bytes4, bytes4, bytes4, bytes4]
    // WARNING: Arguments are unknown!
    public unknown SetProxyInfo();  // argc: -1, index: 12, ipc args: [bytes4, string, bytes4, bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public unknown GetProxyInfo();  // argc: -1, index: 13, ipc args: [bytes4, bytes4, bytes4, bytes4], ipc returns: [bytes1, bytes_external_length]
    public unknown GetObviousConnectivityProblem();  // argc: -1, index: 14, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown TEST_SetFakeLocalSystemStateSetting();  // argc: -1, index: 15, ipc args: [bytes4], ipc returns: []
    public unknown TEST_GetFakeLocalSystemStateSetting();  // argc: -1, index: 16, ipc args: [], ipc returns: [bytes4]
    public unknown TEST_GetFakeLocalSystemEffectiveState();  // argc: -1, index: 17, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown TEST_SetEmulateSingleWirelessDevice();  // argc: -1, index: 18, ipc args: [bytes1, bytes4], ipc returns: []
    public unknown TEST_GetEmulateSingleWirelessDevice();  // argc: -1, index: 19, ipc args: [], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown LEGACY_EnumerateNetworkDevices();  // argc: -1, index: 20, ipc args: [bytes4], ipc returns: [bytes4, bytes_external_length]
    // WARNING: Arguments are unknown!
    public unknown LEGACY_GetDeviceType();  // argc: -1, index: 21, ipc args: [bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown LEGACY_IsCurrentDevice();  // argc: -1, index: 22, ipc args: [bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown LEGACY_IsCurrentlyConnected();  // argc: -1, index: 23, ipc args: [bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown LEGACY_GetDeviceIP4();  // argc: -1, index: 24, ipc args: [bytes4, bytes4], ipc returns: [bytes4, bytes_external_length]
    // WARNING: Arguments are unknown!
    public unknown LEGACY_GetDeviceBroadcastIP4();  // argc: -1, index: 25, ipc args: [bytes4, bytes4], ipc returns: [bytes4, bytes_external_length]
    // WARNING: Arguments are unknown!
    public unknown LEGACY_GetDeviceIPV6InterfaceIndex();  // argc: -1, index: 26, ipc args: [bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown LEGACY_GetDeviceVendor();  // argc: -1, index: 27, ipc args: [bytes4], ipc returns: [string]
    // WARNING: Arguments are unknown!
    public unknown LEGACY_GetDeviceProduct();  // argc: -1, index: 28, ipc args: [bytes4], ipc returns: [string]
    // WARNING: Arguments are unknown!
    public unknown LEGACY_GetMacAddress();  // argc: -1, index: 29, ipc args: [bytes4], ipc returns: [string]
    // WARNING: Arguments are unknown!
    public unknown LEGACY_GetSubnetMaskBitCount();  // argc: -1, index: 30, ipc args: [bytes4, bytes4], ipc returns: [bytes4, bytes_external_length]
    // WARNING: Arguments are unknown!
    public unknown LEGACY_GetRouterAddressIP4();  // argc: -1, index: 31, ipc args: [bytes4, bytes4], ipc returns: [bytes4, bytes_external_length]
    // WARNING: Arguments are unknown!
    public unknown LEGACY_GetDNSResolversIP4();  // argc: -1, index: 32, ipc args: [bytes4, bytes4], ipc returns: [bytes4, bytes_external_length]
    // WARNING: Arguments are unknown!
    public unknown LEGACY_GetDeviceState();  // argc: -1, index: 33, ipc args: [bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown LEGACY_GetDevicePluggedState();  // argc: -1, index: 34, ipc args: [bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown LEGACY_EnumerateWirelessEndpoints();  // argc: -1, index: 35, ipc args: [bytes4, bytes4], ipc returns: [bytes4, bytes_external_length]
    // WARNING: Arguments are unknown!
    public unknown LEGACY_GetConnectedWirelessEndpointSSID();  // argc: -1, index: 36, ipc args: [bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown LEGACY_GetWirelessSecurityCapabilities();  // argc: -1, index: 37, ipc args: [bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown LEGACY_GetWirelessEndpointSSIDUserDisplayString();  // argc: -1, index: 38, ipc args: [bytes4, bytes4], ipc returns: [string]
    // WARNING: Arguments are unknown!
    public unknown LEGACY_GetWirelessEndpointStrength();  // argc: -1, index: 39, ipc args: [bytes4, bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown LEGACY_IsSecurityRequired();  // argc: -1, index: 40, ipc args: [bytes4, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown LEGACY_GetCachedWirelessCredentials();  // argc: -1, index: 41, ipc args: [bytes4, bytes4], ipc returns: [string]
    // WARNING: Arguments are unknown!
    public unknown LEGACY_IsWirelessEndpointForgettable();  // argc: -1, index: 42, ipc args: [bytes4, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown LEGACY_IsUsingDHCP();  // argc: -1, index: 43, ipc args: [bytes4], ipc returns: [bytes1]
}