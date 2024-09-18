using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Generated;
using OpenSteamworks.Data.Structs;
using OpenSteamworks.Data;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(1020094)]
[StructLayout(LayoutKind.Sequential, Pack = SteamClient.Pack)]
public struct AppLicensesChanged_t
{
	[MarshalAs(UnmanagedType.I1)]
	public bool bReloadAll;
	
	public UInt32 m_unAppsUpdated;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public AppId_t[] m_rgAppsUpdated;
}