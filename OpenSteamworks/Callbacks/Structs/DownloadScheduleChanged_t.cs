using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(1280009)]
[StructLayout(LayoutKind.Sequential, Pack = SteamClient.Pack)]
public struct DownloadScheduleChanged_t
{
	[MarshalAs(UnmanagedType.I1)]
	public bool m_bDownloadEnabled;

	public int m_nLastTotalAppsScheduled;

	[MarshalAs(UnmanagedType.I1)]
	public bool unk2;
	
	public int m_nTotalAppsScheduled;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public AppId_t[] m_rgunAppSchedule;
}