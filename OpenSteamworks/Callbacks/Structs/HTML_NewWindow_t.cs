using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data.Structs;
using OpenSteamworks.Data;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(4521)]
[StructLayout(LayoutKind.Sequential, Pack = SteamPlatform.Pack)]
public struct HTML_NewWindow_t
{
	public HHTMLBrowser unBrowserHandle;
	public string pchURL;
	public UInt32 unX;
	public UInt32 unY;
	public UInt32 unWide;
	public UInt32 unTall;
	public HHTMLBrowser unNewWindow_BrowserHandle_IGNORE;
}
