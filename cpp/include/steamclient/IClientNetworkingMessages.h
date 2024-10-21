#pragma once

#include "clienttypes.h"
#include <steam/steamnetworkingtypes.h>

class IClientNetworkingMessages
{
public:
    virtual EResult SendMessageToUser( const SteamNetworkingIdentity &identityRemote, const void *pubData, uint32 cubData, int nSendFlags, int nChannel ) = 0;
	virtual int ReceiveMessagesOnChannel( int nChannel, SteamNetworkingMessage_t **ppOutMessages, int nMaxMessages ) = 0;
	virtual bool AcceptSessionWithUser( const SteamNetworkingIdentity &identityRemote ) = 0;
	virtual bool CloseSessionWithUser( const SteamNetworkingIdentity &identityRemote ) = 0;
	virtual bool CloseChannelWithUser( const SteamNetworkingIdentity &identityRemote, int nChannel ) = 0;
	virtual ESteamNetworkingConnectionState GetSessionConnectionInfo( const SteamNetworkingIdentity &identityRemote, SteamNetConnectionInfo_t *pConnectionInfo, SteamNetConnectionRealTimeStatus_t *pQuickStatus ) = 0;

    #ifdef DBGFLAG_VALIDATE
	virtual void Validate( CValidator &validator, const char *pchName ) = 0;
    #endif
};