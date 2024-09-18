using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(703)]
[StructLayout(LayoutKind.Sequential, Pack = SteamClient.Pack)]
public struct SteamAPICallCompleted_t {
    public SteamAPICall_t m_hAsyncCall;
    public int k_iCallback;
    public UInt32 m_cubParam;
}