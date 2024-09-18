using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data.Structs;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(1040026)]
[StructLayout(LayoutKind.Sequential, Pack = SteamClient.Pack)]
public struct UnknownCallback8_1040026
{
    public UInt32 unk;
    public UInt16 unk1;
    public UInt16 unk2;
}