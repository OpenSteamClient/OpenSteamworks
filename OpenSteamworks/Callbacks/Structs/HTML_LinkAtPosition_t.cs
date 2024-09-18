using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data.Structs;
using OpenSteamworks.Data;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(4513)]
[StructLayout(LayoutKind.Sequential, Pack = SteamClient.Pack)]
public struct HTML_LinkAtPosition_t
{
	public HHTMLBrowser unBrowserHandle;
	public UInt32 x;
	public UInt32 y;
	public string pchURL;

	[MarshalAs(UnmanagedType.I1)]
	public bool bInput;

	[MarshalAs(UnmanagedType.I1)]
	public bool bLiveLink;
}
