using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(101)]
[StructLayout(LayoutKind.Sequential, Pack = SteamPlatform.Pack)]
public struct SteamServersConnected_t
{

}