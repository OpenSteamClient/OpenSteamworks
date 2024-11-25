using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(1040011)]
[StructLayout(LayoutKind.Sequential, Pack = SteamPlatform.Pack)]
public struct SteamConfigStoreChanged_t
{
	public EConfigStore ConfigStore;
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string PathToChange;
}