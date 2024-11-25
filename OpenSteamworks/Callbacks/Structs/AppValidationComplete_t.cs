using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(1280007)]
[StructLayout(LayoutKind.Sequential, Pack = SteamPlatform.Pack)]
public struct AppValidationComplete_t
{
	public AppId_t m_nAppID;

	[MarshalAs(UnmanagedType.I1)]
	public bool m_bFinished;

	public UInt64 m_TotalBytesValidated;
	public UInt64 m_TotalBytesFailed;
	public UInt32 m_TotalFilesValidated;
	public UInt32 m_TotalFilesFailed;
}