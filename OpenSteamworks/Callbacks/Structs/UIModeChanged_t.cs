using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data.Structs;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(1040029)]
[StructLayout(LayoutKind.Sequential, Pack = SteamPlatform.Pack)]
public struct UIModeChanged_t
{
    public EUIMode m_uiModeOld;
    public EUIMode m_uiModeNew;
}