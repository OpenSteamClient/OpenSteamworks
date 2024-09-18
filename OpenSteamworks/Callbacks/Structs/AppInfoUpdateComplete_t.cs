using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(1280003)]
[StructLayout(LayoutKind.Sequential, Pack = SteamClient.Pack)]
public struct AppInfoUpdateComplete_t
{
    
}