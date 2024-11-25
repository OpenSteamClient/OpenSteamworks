using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data.Structs;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(1040018)]
[StructLayout(LayoutKind.Sequential, Pack = SteamPlatform.Pack)]
public struct StartVRDashboard_t
{
}