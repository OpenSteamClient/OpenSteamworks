using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data.Structs;
using OpenSteamworks.Data;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(4507)]
[StructLayout(LayoutKind.Sequential, Pack = SteamPlatform.Pack)]
public struct HTML_OpenLinkInNewTab_t
{
	public HHTMLBrowser unBrowserHandle;
	public string pchURL;
}
