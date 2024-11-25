using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data.Structs;
using OpenSteamworks.Data;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(1040015)]
[StructLayout(LayoutKind.Sequential, Pack = SteamPlatform.Pack)]
public struct WindowFocusChanged_t
{
    public AppId_t appid;
    public UInt32 unk1;
    public UInt32 pidOfProgram;
    public byte unk3;
    public byte unk4;
    public byte unk5;
    public byte unk6;
}