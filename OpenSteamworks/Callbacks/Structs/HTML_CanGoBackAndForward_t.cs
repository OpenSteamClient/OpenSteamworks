using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data.Structs;
using OpenSteamworks.Data;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(4510)]
[StructLayout(LayoutKind.Sequential, Pack = SteamClient.Pack)]
public struct HTML_CanGoBackAndForward_t
{
	public HHTMLBrowser unBrowserHandle;
	
	[MarshalAs(UnmanagedType.I1)]
	public bool bCanGoBack;

	[MarshalAs(UnmanagedType.I1)]
	public bool bCanGoForward;
}
