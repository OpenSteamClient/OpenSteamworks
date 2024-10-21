#pragma once

#include "clienttypes.h"
#include <steam/steamnetworkingtypes.h>

class IClientNetworkingUtils
{
public:
    virtual SteamNetworkingMessage_t *AllocateMessage( int cbAllocateBuffer ) = 0;

	virtual SteamNetworkingMicroseconds GetLocalTimestamp() = 0;
	virtual void SetDebugOutputFunction( ESteamNetworkingSocketsDebugOutputType eDetailLevel, FSteamNetworkingSocketsDebugOutput pfnFunc ) = 0;

	virtual ESteamNetworkingFakeIPType GetIPv4FakeIPType( uint32 nIPv4 ) = 0;
	virtual EResult GetRealIdentityForFakeIP( const SteamNetworkingIPAddr &fakeIP, SteamNetworkingIdentity *pOutRealIdentity ) = 0;

	virtual bool SetConfigValue( ESteamNetworkingConfigValue eValue,
		ESteamNetworkingConfigScope eScopeType, intptr_t scopeObj,
		ESteamNetworkingConfigDataType eDataType, const void *pValue ) = 0;

	virtual ESteamNetworkingGetConfigValueResult GetConfigValue(
		ESteamNetworkingConfigValue eValue, ESteamNetworkingConfigScope eScopeType,
		intptr_t scopeObj, ESteamNetworkingConfigDataType *pOutDataType,
		void *pResult, size_t *cbResult ) = 0;

	virtual const char *GetConfigValueInfo( ESteamNetworkingConfigValue eValue, ESteamNetworkingConfigDataType *pOutDataType, ESteamNetworkingConfigScope *pOutScope ) = 0;
	virtual ESteamNetworkingConfigValue IterateGenericEditableConfigValues( ESteamNetworkingConfigValue eCurrent, bool bEnumerateDevVars ) = 0;

	virtual void SteamNetworkingIPAddr_ToString( const SteamNetworkingIPAddr &addr, char *buf, size_t cbBuf, bool bWithPort ) = 0;
	virtual bool SteamNetworkingIPAddr_ParseString( SteamNetworkingIPAddr *pAddr, const char *pszStr ) = 0;
	virtual ESteamNetworkingFakeIPType SteamNetworkingIPAddr_GetFakeIPType( const SteamNetworkingIPAddr &addr ) = 0;
	virtual void SteamNetworkingIdentity_ToString( const SteamNetworkingIdentity &identity, char *buf, size_t cbBuf ) = 0;
	virtual bool SteamNetworkingIdentity_ParseString( SteamNetworkingIdentity *pIdentity, const char *pszStr ) = 0;
    virtual ESteamNetworkingAvailability GetRelayNetworkStatus( SteamRelayNetworkStatus_t *pDetails ) = 0;
	virtual bool CheckPingDataUpToDate( float flMaxAgeSeconds ) = 0;
	virtual float GetLocalPingLocation( SteamNetworkPingLocation_t &result ) = 0;
	virtual int EstimatePingTimeBetweenTwoLocations( const SteamNetworkPingLocation_t &location1, const SteamNetworkPingLocation_t &location2 ) = 0;
	virtual int EstimatePingTimeFromLocalHost( const SteamNetworkPingLocation_t &remoteLocation ) = 0;
	virtual void ConvertPingLocationToString( const SteamNetworkPingLocation_t &location, char *pszBuf, int cchBufSize ) = 0;
	virtual bool ParsePingLocationString( const char *pszString, SteamNetworkPingLocation_t &result ) = 0;
	virtual int GetPingToDataCenter( SteamNetworkingPOPID popID, SteamNetworkingPOPID *pViaRelayPoP ) = 0;
	virtual int GetDirectPingToPOP( SteamNetworkingPOPID popID ) = 0;
	virtual int GetPOPCount() = 0;
	virtual int GetPOPList( SteamNetworkingPOPID *list, int nListSz ) = 0;

	void InitRelayNetworkAccess();

	bool SetGlobalConfigValueInt32( ESteamNetworkingConfigValue eValue, int32 val );
	bool SetGlobalConfigValueFloat( ESteamNetworkingConfigValue eValue, float val );
	bool SetGlobalConfigValueString( ESteamNetworkingConfigValue eValue, const char *val );
	bool SetGlobalConfigValuePtr( ESteamNetworkingConfigValue eValue, void *val );
	bool SetConnectionConfigValueInt32( HSteamNetConnection hConn, ESteamNetworkingConfigValue eValue, int32 val );
	bool SetConnectionConfigValueFloat( HSteamNetConnection hConn, ESteamNetworkingConfigValue eValue, float val );
	bool SetConnectionConfigValueString( HSteamNetConnection hConn, ESteamNetworkingConfigValue eValue, const char *val );

	bool SetGlobalCallback_SteamNetConnectionStatusChanged( FnSteamNetConnectionStatusChanged fnCallback );
	bool SetGlobalCallback_SteamNetAuthenticationStatusChanged( FnSteamNetAuthenticationStatusChanged fnCallback );
	bool SetGlobalCallback_SteamRelayNetworkStatusChanged( FnSteamRelayNetworkStatusChanged fnCallback );
	bool SetGlobalCallback_FakeIPResult( FnSteamNetworkingFakeIPResult fnCallback );
	bool SetGlobalCallback_MessagesSessionRequest( FnSteamNetworkingMessagesSessionRequest fnCallback );
	bool SetGlobalCallback_MessagesSessionFailed( FnSteamNetworkingMessagesSessionFailed fnCallback );

	bool SetConfigValueStruct( const SteamNetworkingConfigValue_t &opt, ESteamNetworkingConfigScope eScopeType, intptr_t scopeObj );
};

inline void IClientNetworkingUtils::InitRelayNetworkAccess() { CheckPingDataUpToDate( 1e10f ); }
inline bool IClientNetworkingUtils::SetGlobalConfigValueInt32( ESteamNetworkingConfigValue eValue, int32 val ) { return SetConfigValue( eValue, k_ESteamNetworkingConfig_Global, 0, k_ESteamNetworkingConfig_Int32, &val ); }
inline bool IClientNetworkingUtils::SetGlobalConfigValueFloat( ESteamNetworkingConfigValue eValue, float val ) { return SetConfigValue( eValue, k_ESteamNetworkingConfig_Global, 0, k_ESteamNetworkingConfig_Float, &val ); }
inline bool IClientNetworkingUtils::SetGlobalConfigValueString( ESteamNetworkingConfigValue eValue, const char *val ) { return SetConfigValue( eValue, k_ESteamNetworkingConfig_Global, 0, k_ESteamNetworkingConfig_String, val ); }
inline bool IClientNetworkingUtils::SetGlobalConfigValuePtr( ESteamNetworkingConfigValue eValue, void *val ) { return SetConfigValue( eValue, k_ESteamNetworkingConfig_Global, 0, k_ESteamNetworkingConfig_Ptr, &val ); } // Note: passing pointer to pointer.
inline bool IClientNetworkingUtils::SetConnectionConfigValueInt32( HSteamNetConnection hConn, ESteamNetworkingConfigValue eValue, int32 val ) { return SetConfigValue( eValue, k_ESteamNetworkingConfig_Connection, hConn, k_ESteamNetworkingConfig_Int32, &val ); }
inline bool IClientNetworkingUtils::SetConnectionConfigValueFloat( HSteamNetConnection hConn, ESteamNetworkingConfigValue eValue, float val ) { return SetConfigValue( eValue, k_ESteamNetworkingConfig_Connection, hConn, k_ESteamNetworkingConfig_Float, &val ); }
inline bool IClientNetworkingUtils::SetConnectionConfigValueString( HSteamNetConnection hConn, ESteamNetworkingConfigValue eValue, const char *val ) { return SetConfigValue( eValue, k_ESteamNetworkingConfig_Connection, hConn, k_ESteamNetworkingConfig_String, val ); }
inline bool IClientNetworkingUtils::SetGlobalCallback_SteamNetConnectionStatusChanged( FnSteamNetConnectionStatusChanged fnCallback ) { return SetGlobalConfigValuePtr( k_ESteamNetworkingConfig_Callback_ConnectionStatusChanged, (void*)fnCallback ); }
inline bool IClientNetworkingUtils::SetGlobalCallback_SteamNetAuthenticationStatusChanged( FnSteamNetAuthenticationStatusChanged fnCallback ) { return SetGlobalConfigValuePtr( k_ESteamNetworkingConfig_Callback_AuthStatusChanged, (void*)fnCallback ); }
inline bool IClientNetworkingUtils::SetGlobalCallback_SteamRelayNetworkStatusChanged( FnSteamRelayNetworkStatusChanged fnCallback ) { return SetGlobalConfigValuePtr( k_ESteamNetworkingConfig_Callback_RelayNetworkStatusChanged, (void*)fnCallback ); }
inline bool IClientNetworkingUtils::SetGlobalCallback_FakeIPResult( FnSteamNetworkingFakeIPResult fnCallback ) { return SetGlobalConfigValuePtr( k_ESteamNetworkingConfig_Callback_FakeIPResult, (void*)fnCallback ); }
inline bool IClientNetworkingUtils::SetGlobalCallback_MessagesSessionRequest( FnSteamNetworkingMessagesSessionRequest fnCallback ) { return SetGlobalConfigValuePtr( k_ESteamNetworkingConfig_Callback_MessagesSessionRequest, (void*)fnCallback ); }
inline bool IClientNetworkingUtils::SetGlobalCallback_MessagesSessionFailed( FnSteamNetworkingMessagesSessionFailed fnCallback ) { return SetGlobalConfigValuePtr( k_ESteamNetworkingConfig_Callback_MessagesSessionFailed, (void*)fnCallback ); }

inline bool IClientNetworkingUtils::SetConfigValueStruct( const SteamNetworkingConfigValue_t &opt, ESteamNetworkingConfigScope eScopeType, intptr_t scopeObj )
{
	// Locate the argument.  Strings are a special case, since the
	// "value" (the whole string buffer) doesn't fit in the struct
	// NOTE: for pointer values, we pass a pointer to the pointer,
	// we do not pass the pointer directly.
	const void *pVal = ( opt.m_eDataType == k_ESteamNetworkingConfig_String ) ? (const void *)opt.m_val.m_string : (const void *)&opt.m_val;
	return SetConfigValue( opt.m_eValue, eScopeType, scopeObj, opt.m_eDataType, pVal );
}