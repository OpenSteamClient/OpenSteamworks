#ifndef VALID_STEAMID_INCLUDE
#error "Invalid include of gameid.h, you must include clienttypes.h instead"
#endif

#pragma once

#pragma pack( push, 1 )

struct SteamIPAddress_t
{
    enum ESteamIPType
    {
        k_ESteamIPTypeIPv4 = 0,
        k_ESteamIPTypeIPv6 = 1,
    };

	union {

		uint32_t			m_unIPv4;		    // Host order
		uint8_t			    m_rgubIPv6[16];		// Network order! Same as inaddr_in6.  (0011:2233:4455:6677:8899:aabb:ccdd:eeff)

		// Internal use only
		uint64_t			m_ipv6Qword[2];	    // big endian
	};

	ESteamIPType m_eType;

	bool IsSet() const 
	{ 
		if ( k_ESteamIPTypeIPv4 == m_eType )
		{
			return m_unIPv4 != 0;
		}
		else 
		{
			return m_ipv6Qword[0] !=0 || m_ipv6Qword[1] != 0; 
		}
	}

	static SteamIPAddress_t FromIPv4(uint32_t ip)
	{
		SteamIPAddress_t ipOut;
		ipOut.m_eType = k_ESteamIPTypeIPv4;
		ipOut.m_unIPv4 = ip;

		return ipOut;
	}

	static SteamIPAddress_t IPv4Any()
	{
		SteamIPAddress_t ipOut;
		ipOut.m_eType = k_ESteamIPTypeIPv4;
		ipOut.m_unIPv4 = 0;

		return ipOut;
	}

	static SteamIPAddress_t IPv6Any()
	{
		SteamIPAddress_t ipOut;
		ipOut.m_eType = k_ESteamIPTypeIPv6;
		ipOut.m_ipv6Qword[0] = 0;
		ipOut.m_ipv6Qword[1] = 0;

		return ipOut;
	}

	static SteamIPAddress_t IPv4Loopback()
	{
		SteamIPAddress_t ipOut;
		ipOut.m_eType = k_ESteamIPTypeIPv4;
		ipOut.m_unIPv4 = 0x7f000001;

		return ipOut;
	}

	static SteamIPAddress_t IPv6Loopback()
	{
		SteamIPAddress_t ipOut;
		ipOut.m_eType = k_ESteamIPTypeIPv6;
		ipOut.m_ipv6Qword[0] = 0;
		ipOut.m_ipv6Qword[1] = 0;
		ipOut.m_rgubIPv6[15] = 1;

		return ipOut;
	}
};

#pragma pack( pop )