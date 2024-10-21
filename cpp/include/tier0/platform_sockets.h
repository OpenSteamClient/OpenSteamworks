//====== Copyright Valve Corporation, All rights reserved. ====================
//
// Include the relevant platform-specific headers for socket-related
// stuff, and declare some functions make them look as similar to
// plain BSD sockets as possible.
// 
// This includes a bunch of stuff.  DO NOT INCLUDE THIS FROM A HEADER
//
// Some things that will be defined by this file:
// 
// closesocket()
// GetLastSocketError()
// SetSocketNonBlocking()
// 
// USE_EPOLL or USE_POLL
// If USE_EPOLL:
//		EPollHandle, INVALID_EPOLL_HANDLE, EPollCreate()
//
// WAKE_THREAD_USING_EVENT or WAKE_THREAD_USING_SOCKET_PAIR
// If WAKE_THREAD_USING_EVENT:
//		ThreadWakeEvent, INVALID_THREAD_WAKE_EVENT, SetWakeThreadEvent()

#ifndef TIER0_PLATFORM_SOCKETS_H
#define TIER0_PLATFORM_SOCKETS_H
#pragma once

#include "platform.h"
#include <tier1/strtools.h>
#include <minbase/minbase_identify.h>

// !KLUDGE!
typedef char SteamNetworkingErrMsg[ 1024 ];

// Socket headers
#if IsWindows()

	// MingW hackery...
	#ifdef __MINGW32__
		#define CMSGHDR WSACMSGHDR
		#define cmsghdr CMSGHDR
		#define CMSG_FIRSTHDR WSA_CMSG_FIRSTHDR
		#define CMSG_NXTHDR WSA_CMSG_NXTHDR
		
		#define WDK_NTDDI_VERSION 0x0A00000B

		namespace wlan_new
		{
			typedef enum _WLAN_INTF_OPCODE {
				wlan_intf_opcode_autoconf_start = 0x000000000,
				wlan_intf_opcode_autoconf_enabled,
				wlan_intf_opcode_background_scan_enabled,
				wlan_intf_opcode_media_streaming_mode,
				wlan_intf_opcode_radio_state,
				wlan_intf_opcode_bss_type,
				wlan_intf_opcode_interface_state,
				wlan_intf_opcode_current_connection,
				wlan_intf_opcode_channel_number,
				wlan_intf_opcode_supported_infrastructure_auth_cipher_pairs,
				wlan_intf_opcode_supported_adhoc_auth_cipher_pairs,
				wlan_intf_opcode_supported_country_or_region_string_list,
				wlan_intf_opcode_current_operation_mode,
				wlan_intf_opcode_supported_safe_mode,
				wlan_intf_opcode_certified_safe_mode,
				wlan_intf_opcode_hosted_network_capable,
				wlan_intf_opcode_management_frame_protection_capable,
				wlan_intf_opcode_secondary_sta_interfaces,
				wlan_intf_opcode_secondary_sta_synchronized_connections,
				wlan_intf_opcode_autoconf_end = 0x0fffffff,
				wlan_intf_opcode_msm_start = 0x10000100,
				wlan_intf_opcode_statistics,
				wlan_intf_opcode_rssi,
				wlan_intf_opcode_msm_end = 0x1fffffff,
				wlan_intf_opcode_security_start = 0x20010000,
				wlan_intf_opcode_security_end = 0x2fffffff,
				wlan_intf_opcode_ihv_start = 0x30000000,
				wlan_intf_opcode_ihv_end = 0x3fffffff
			} WLAN_INTF_OPCODE, *PWLAN_INTF_OPCODE;
		}

		const wlan_new::WLAN_INTF_OPCODE wlan_intf_opcode_secondary_sta_synchronized_connections = (wlan_new::WLAN_INTF_OPCODE)wlan_new::wlan_intf_opcode_secondary_sta_synchronized_connections;
		const wlan_new::WLAN_INTF_OPCODE wlan_intf_opcode_secondary_sta_interfaces = (wlan_new::WLAN_INTF_OPCODE)wlan_new::wlan_intf_opcode_secondary_sta_interfaces;
	#endif

	//#include <windows.h>
	#include <winsock2.h>
	#include <ws2tcpip.h>
	#ifndef _XBOX_ONE
		#include <iphlpapi.h>
	#endif

	// Windows is the worst
	#undef min
	#undef max
	#undef SetPort

	#define MSG_NOSIGNAL 0

	inline bool SetSocketNonBlocking( SOCKET s )
	{
		unsigned long opt = 1;
		return ioctlsocket( s, FIONBIO, &opt ) == 0;
	}

	#define WAKE_THREAD_USING_EVENT
	typedef HANDLE ThreadWakeEvent;
	#define INVALID_THREAD_WAKE_EVENT INVALID_HANDLE_VALUE
	inline void SetWakeThreadEvent( ThreadWakeEvent hEvent )
	{
		::SetEvent( hEvent );
	}

	inline int GetLastSocketError()
	{
		return (int)WSAGetLastError();
	}

	#if !IsXboxOne()
		#include <mswsock.h>
		#define PlatformSupportsRecvMsg() true
	#endif
#elif IsPosix()

	// POSIX-ish platform (Linux, OSX, Android, IOS)
	#include <sys/types.h>
	#include <sys/socket.h>
	#include <netinet/in.h>
	#include <sys/ioctl.h>
	#include <unistd.h>
	#include <poll.h>
	#include <errno.h>

	#if !IsAndroid()
		#include <ifaddrs.h>
	#endif
	#include <net/if.h>

	#ifndef closesocket
		#define closesocket close
	#endif
	#define WSAEWOULDBLOCK EWOULDBLOCK

	#define WAKE_THREAD_USING_SOCKET_PAIR

	inline bool SetSocketNonBlocking( SOCKET s )
	{
		unsigned long opt = 1;
		return ioctl( s, FIONBIO, &opt ) == 0;
	}

	inline int GetLastSocketError()
	{
		return errno;
	}

	#define PlatformSupportsRecvMsg() true

	#ifdef __APPLE__
		#define USE_POLL

		// I can't get this to work on MacOS.  If someboddy believes that
		// it should work, I would appreciate the help.
		#define PlatformSupportsRecvTOS() false

	#else
		#define USE_EPOLL
		#include <sys/epoll.h>

		typedef int EPollHandle;
		constexpr EPollHandle INVALID_EPOLL_HANDLE = -1;
		inline EPollHandle EPollCreate( SteamNetworkingErrMsg &errMsg )
		{
			int flags = 0;
			#if IsLinux()
				flags |= EPOLL_CLOEXEC;
			#endif
			EPollHandle e = epoll_create1( flags );
			if ( e == -1 )
			{
				V_sprintf_safe( errMsg, "epoll_create1() failed, errno=%d", errno );
				return INVALID_EPOLL_HANDLE;
			}
			return e;
		}

		#define EPollClose(x) close(x)

		// FIXME - should we try to use eventfd() here
		// instead of a socket pair?

	#endif
#else
	#error "How do?"
#endif

#ifndef PlatformSupportsRecvMsg
	#define PlatformSupportsRecvMsg() false
#endif

#ifndef PlatformSupportsRecvTOS
	#if PlatformSupportsRecvMsg() && defined( IP_RECVTOS )
		#define PlatformSupportsRecvTOS() true
	#else
		#define PlatformSupportsRecvTOS() false
	#endif
#endif

#endif // _H