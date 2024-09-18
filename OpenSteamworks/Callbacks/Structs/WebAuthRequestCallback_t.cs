using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(1020042)]
[StructLayout(LayoutKind.Sequential, Pack = SteamClient.Pack)]
public struct WebAuthRequestCallback_t
{
	[MarshalAs(UnmanagedType.I1)]
	public bool m_bSuccessful;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string m_rgchToken;
}