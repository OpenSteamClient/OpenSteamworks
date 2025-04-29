using System;
using System.Runtime.InteropServices;

namespace OpenSteamworks.Data.Structs;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public record struct AppPlaytime_t(UInt32 AllTime, UInt32 LastTwoWeeks);