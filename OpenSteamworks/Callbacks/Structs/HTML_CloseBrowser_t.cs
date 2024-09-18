using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data.Structs;
using OpenSteamworks.Data;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(4504)]
[StructLayout(LayoutKind.Sequential, Pack = SteamClient.Pack)]
public struct HTML_CloseBrowser_t
{
	public HHTMLBrowser unBrowserHandle;
}
