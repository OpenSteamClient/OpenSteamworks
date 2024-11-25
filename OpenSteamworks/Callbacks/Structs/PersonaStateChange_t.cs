using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data.Structs;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(304)]
[StructLayout(LayoutKind.Sequential, Pack = SteamPlatform.Pack)]
public struct PersonaStateChange_t
{
	public CSteamID steamid;
	public EPersonaChange changeFlags;
}