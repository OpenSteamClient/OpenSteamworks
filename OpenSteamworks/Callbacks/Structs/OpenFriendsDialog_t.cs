using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data.Structs;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(1010056)]
[StructLayout(LayoutKind.Sequential, Pack = SteamClient.Pack)]
public struct OpenFriendsDialog_t
{
    public short unk;
}
