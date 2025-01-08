using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data.Structs;
using OpenSteamworks.Data;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(336)]
[StructLayout(LayoutKind.Sequential, Pack = SteamPlatform.Pack)]
public record struct FriendRichPresenceUpdate_t(CSteamID SteamID, AppId_t AppID);