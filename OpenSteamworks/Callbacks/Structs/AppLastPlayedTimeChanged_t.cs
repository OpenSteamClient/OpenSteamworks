using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(1020070)]
[StructLayout(LayoutKind.Sequential, Pack = SteamPlatform.Pack)]
public record struct AppLastPlayedTimeChanged_t(AppId_t AppID, RTime32 LastPlayed);