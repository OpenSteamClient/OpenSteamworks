using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(1270020)]
[StructLayout(LayoutKind.Sequential, Pack = SteamPlatform.Pack)]
public struct CheckAppBetaPasswordResponse_t
{
    public readonly AppId_t AppID;
    public readonly EResult Result;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    public readonly string BetaName;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    public readonly string BetaDesc;
}
