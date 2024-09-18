using System;
using System.Runtime.InteropServices;
using OpenSteamworks;
using OpenSteamworks.Data.Structs;

namespace OpenSteamworks.Data.Structs;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct FriendSessionStateInfo_t
{
	public UInt32 m_uiOnlineSessionInstances;
	public byte m_uiPublishedToFriendsSessionInstance;

    public override string ToString()
    {
        return $"m_uiOnlineSessionInstances: {m_uiOnlineSessionInstances}, m_uiPublishedToFriendsSessionInstance: {m_uiPublishedToFriendsSessionInstance}";
    }
};