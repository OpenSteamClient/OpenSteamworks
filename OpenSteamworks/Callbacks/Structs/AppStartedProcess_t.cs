using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(1020078)]
[StructLayout(LayoutKind.Sequential, Pack = SteamPlatform.Pack)]
public record struct AppStartedProcess_t(UInt32 ProcessID, AppId_t AppID, UInt32 unk);