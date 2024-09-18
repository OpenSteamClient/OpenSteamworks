using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data.Structs;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(1080003)]
[StructLayout(LayoutKind.Sequential, Pack = SteamClient.Pack)]
public struct StopPlayingBorrowedApp_t
{
    public UInt32 m_unAppID;
    public CSteamID m_OwnerAccountID;
    public Int32 m_nSecondLeft;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 65)]
    public string m_szOwnerName;
}