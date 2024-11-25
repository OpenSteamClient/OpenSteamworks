using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(102)]
[StructLayout(LayoutKind.Sequential, Pack = SteamPlatform.Pack)]
public struct SteamServerConnectFailure_t
{
	public EResult m_EResult;

	[MarshalAs(UnmanagedType.I1)]
    public bool m_bStillRetrying;
}