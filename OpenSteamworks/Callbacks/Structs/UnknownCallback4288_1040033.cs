using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data.Structs;

namespace OpenSteamworks.Callbacks.Structs;

/// <summary>
/// Seems to be some sort of job state callback for tracking CJob:s.
/// </summary>
[Callback(1040033)]
[StructLayout(LayoutKind.Sequential, Pack = SteamClient.Pack)]
public struct UnknownCallback4288_1040033
{
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4288)]
    public string unk;
}