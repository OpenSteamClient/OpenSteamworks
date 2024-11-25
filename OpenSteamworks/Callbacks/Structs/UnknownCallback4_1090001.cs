using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data.Structs;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(1090001)]
[StructLayout(LayoutKind.Sequential, Pack = SteamPlatform.Pack)]
public struct UnknownCallback4_1090001
{
    public UInt32 unk;
}