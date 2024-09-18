using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data.Structs;
using OpenSteamworks.Data;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(4503)]
[StructLayout(LayoutKind.Sequential, Pack = SteamClient.Pack)]
public struct HTML_StartRequest_t
{
	public HHTMLBrowser unBrowserHandle;
	public string pchURL;
	public string pchTarget;
	public string pchPostData;

	[MarshalAs(UnmanagedType.I1)]
	public bool bIsRedirect;
}
