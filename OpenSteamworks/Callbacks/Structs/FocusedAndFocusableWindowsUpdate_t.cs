using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data.Structs;
using OpenSteamworks.Data;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(1040044)]
[StructLayout(LayoutKind.Sequential, Pack = SteamClient.Pack)]
public struct FocusedAndFocusableWindowsUpdate_t
{
    public AppId_t currentlyFocusedAppID;
    public UInt32 unkLen1;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
    public UInt32[] unk1;

    public UInt32 unkLen2;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
    public UInt32[] unk2;

    public UInt32 unkLen3;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
    public UInt32[] unk3;
}