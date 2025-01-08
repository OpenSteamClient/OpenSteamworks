using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(1020028)]
[StructLayout(LayoutKind.Sequential, Pack = SteamPlatform.Pack)]
public record struct AppOwnershipTicketReceived_t(AppId_t AppID);