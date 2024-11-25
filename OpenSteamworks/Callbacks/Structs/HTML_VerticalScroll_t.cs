using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data.Structs;
using OpenSteamworks.Data;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(4512)]
[StructLayout(LayoutKind.Sequential, Pack = SteamPlatform.Pack)]
public struct HTML_VerticalScroll_t
{
	public HHTMLBrowser unBrowserHandle;
	public UInt32 unScrollMax;
	public UInt32 unScrollCurrent;
	public float flPageScale;
	
	[MarshalAs(UnmanagedType.I1)]
	public bool bVisible;
	
	public UInt32 unPageSize;
}
