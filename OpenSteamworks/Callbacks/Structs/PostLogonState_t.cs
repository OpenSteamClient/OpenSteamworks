using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data.Structs;
using OpenSteamworks.Utils;

namespace OpenSteamworks.Callbacks.Structs;

/// <summary>
/// I have no idea what any of the fields in here mean. I've done a rough guess though, and according to ghidra the lengths of the fields seem to be correct.
/// </summary>
[Callback(1020087)]
[StructLayout(LayoutKind.Sequential)]
public struct PostLogonState_t 
{
	static PostLogonState_t() {
		unsafe
		{
			UtilityFunctions.Assert(sizeof(PostLogonState_t) == 10);
		}
    }

	public byte unk1;
	public byte unk2;
	public byte unk3;
	public byte unk4;
	public byte unk5;
	public byte unk6;
    public byte connectedToCMs;
    public byte unk8;
	public byte hasAppInfo;
	public byte unk10;
}