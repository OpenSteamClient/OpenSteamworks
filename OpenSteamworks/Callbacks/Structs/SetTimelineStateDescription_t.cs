using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data.Structs;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(1360001)]
[StructLayout(LayoutKind.Sequential, Pack = SteamPlatform.Pack)]
public struct SetTimelineStateDescription_t 
{
    public CGameID gameid;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    public string description;
    public float deltaTime;
} 