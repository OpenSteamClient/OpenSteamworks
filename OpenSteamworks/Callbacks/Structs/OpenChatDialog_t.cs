using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data.Structs;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(1010016)]
[StructLayout(LayoutKind.Sequential, Pack = SteamClient.Pack)]
public struct OpenChatDialog_t
{
    public CSteamID ChatID;
    public uint unk;
    public uint unk2;
}
