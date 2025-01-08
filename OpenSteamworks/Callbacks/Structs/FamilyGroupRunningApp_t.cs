using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(1080008)]
[StructLayout(LayoutKind.Sequential, Pack = SteamPlatform.Pack)]
public record struct FamilyGroupRunningApp_t(AppId_t AppID, bool Locked, uint NumMembersPlaying);