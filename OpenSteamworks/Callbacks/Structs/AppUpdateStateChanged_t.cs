using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(1280010)]
[StructLayout(LayoutKind.Sequential, Pack = SteamPlatform.Pack)]
public record struct AppUpdateStateChanged_t(AppId_t AppID, EAppUpdateState OldState, EAppUpdateState NewState);