using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(1270009)]
[StructLayout(LayoutKind.Sequential, Pack = SteamPlatform.Pack)]
public struct DownloadScheduleChanged_t
{
	/// <summary>
	/// Is downloading enabled?
	/// </summary>
	[MarshalAs(UnmanagedType.I1)]
	public bool m_bDownloadEnabled;

	/// <summary>
	/// How many apps have been in the previously fired callbacks
	/// </summary>
	public int m_nLastTotalAppsScheduled;

	/// <summary>
	/// Is this the last callback that will be fired?
	/// </summary>
	[MarshalAs(UnmanagedType.I1)]
	public bool m_bisLastCallback;

	/// <summary>
	/// How many apps are scheduled in this callback (length of valid data in <see cref="m_rgunAppSchedule"/>
	/// </summary>
	public int m_nTotalAppsScheduled;

	/// <summary>
	/// The download schedule. Not all data is valid, check <see cref="m_nTotalAppsScheduled"/> to see how many valid items.
	/// </summary>
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public AppId_t[] m_rgunAppSchedule;
}
