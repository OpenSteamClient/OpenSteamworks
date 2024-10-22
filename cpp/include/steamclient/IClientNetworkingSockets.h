#pragma once

#include "clienttypes.h"
#include <steam/steamnetworkingtypes.h>

class IClientNetworkingSockets
{
public:
    virtual HSteamListenSocket CreateListenSocketIP( const SteamNetworkingIPAddr &localAddress, int nOptions, const SteamNetworkingConfigValue_t *pOptions ) = 0;
	virtual HSteamNetConnection ConnectByIPAddress( const SteamNetworkingIPAddr &adress, int nOptions, const SteamNetworkingConfigValue_t *pOptions ) = 0;
	virtual HSteamListenSocket CreateListenSocketP2P( int nLocalVirtualPort, int nOptions, const SteamNetworkingConfigValue_t *pOptions ) = 0;
	virtual HSteamNetConnection ConnectP2P( const SteamNetworkingIdentity &identityRemote, int nRemoteVirtualPort, int nOptions, const SteamNetworkingConfigValue_t *pOptions ) = 0;
	virtual EResult AcceptConnection( HSteamNetConnection hConn ) = 0;
	virtual bool CloseConnection( HSteamNetConnection hConn, int nReason, const char *pszDebug, bool bEnableLinger ) = 0;
	virtual bool CloseListenSocket( HSteamListenSocket hSocket ) = 0;
	virtual bool SetConnectionUserData( HSteamNetConnection hPeer, int64 nUserData ) = 0;
	virtual int64 GetConnectionUserData( HSteamNetConnection hPeer ) = 0;
	virtual void SetConnectionName( HSteamNetConnection hPeer, const char *pszName ) = 0;
	virtual bool GetConnectionName( HSteamNetConnection hPeer, char *pszName, int nMaxLen ) = 0;
	virtual EResult SendMessageToConnection( HSteamNetConnection hConn, const void *pData, uint32 cbData, int nSendFlags, int64 *pOutMessageNumber ) = 0;
	virtual void SendMessages( int nMessages, SteamNetworkingMessage_t *const *pMessages, int64 *pOutMessageNumberOrResult ) = 0;
	virtual EResult FlushMessagesOnConnection( HSteamNetConnection hConn ) = 0;
	virtual int ReceiveMessagesOnConnection( HSteamNetConnection hConn, SteamNetworkingMessage_t **ppOutMessages, int nMaxMessages ) = 0;
	virtual bool GetConnectionInfo( HSteamNetConnection hConn, SteamNetConnectionInfo_t *pInfo ) = 0;
	virtual EResult GetConnectionRealTimeStatus( HSteamNetConnection hConn, SteamNetConnectionRealTimeStatus_t *pStatus, int nLanes, SteamNetConnectionRealTimeLaneStatus_t *pLanes ) = 0;
	virtual int GetDetailedConnectionStatus( HSteamNetConnection hConn, char *pszBuf, int cbBuf ) = 0;
	virtual bool GetListenSocketAddress( HSteamListenSocket hSocket, SteamNetworkingIPAddr *pAddress ) = 0;
	virtual bool CreateSocketPair( HSteamNetConnection *pOutConnection1, HSteamNetConnection *pOutConnection2, bool bUseNetworkLoopback, const SteamNetworkingIdentity *pIdentity1, const SteamNetworkingIdentity *pIdentity2 ) = 0;
	virtual EResult ConfigureConnectionLanes( HSteamNetConnection hConn, int nNumLanes, const int *pLanePriorities, const uint16 *pLaneWeights ) = 0;
	virtual bool GetIdentity( SteamNetworkingIdentity *pIdentity ) = 0;

	virtual HSteamNetPollGroup CreatePollGroup() = 0;
	virtual bool DestroyPollGroup( HSteamNetPollGroup hPollGroup ) = 0;
	virtual bool SetConnectionPollGroup( HSteamNetConnection hConn, HSteamNetPollGroup hPollGroup ) = 0;
	virtual int ReceiveMessagesOnPollGroup( HSteamNetPollGroup hPollGroup, SteamNetworkingMessage_t **ppOutMessages, int nMaxMessages ) = 0; 
	virtual HSteamNetConnection ConnectP2PCustomSignaling( ISteamNetworkingConnectionSignaling *pSignaling, const SteamNetworkingIdentity *pPeerIdentity, int nVirtualPort, int nOptions, const SteamNetworkingConfigValue_t *pOptions ) = 0;
	virtual bool ReceivedP2PCustomSignal( const void *pMsg, int cbMsg, ISteamNetworkingSignalingRecvContext *pContext ) = 0;
	virtual int GetP2P_Transport_ICE_Enable( const SteamNetworkingIdentity &identityRemote, int *pOutUserFlags ) = 0;

	virtual bool GetCertificateRequest( int *pcbBlob, void *pBlob, SteamNetworkingErrMsg &errMsg ) = 0;
	virtual bool SetCertificate( const void *pCertificate, int cbCertificate, SteamNetworkingErrMsg &errMsg ) = 0;
	virtual void ResetIdentity( const SteamNetworkingIdentity *pIdentity ) = 0;

	virtual HSteamListenSocket CreateListenSocketP2PFakeIP( int idxFakePort, int nOptions, const SteamNetworkingConfigValue_t *pOptions ) = 0;
	virtual EResult GetRemoteFakeIPForConnection( HSteamNetConnection hConn, SteamNetworkingIPAddr *pOutAddr ) = 0;
    virtual int GetFakePortIndex( const SteamNetworkingIPAddr &fakeIP ) = 0;
    virtual int ReceiveMessagesOnListenSocketLegacyPollGroup( HSteamListenSocket hSocket, SteamNetworkingMessage_t **ppOutMessages, int nMaxMessages ) = 0;
	virtual void TEST_EnableP2PLooopbackOptimization( bool flag ) = 0;
    virtual void RunCallbacks() = 0;

    virtual ESteamNetworkingAvailability InitAuthentication() = 0;
	virtual ESteamNetworkingAvailability GetAuthenticationStatus( SteamNetAuthenticationStatus_t *pAuthStatus ) = 0;

    virtual int FindRelayAuthTicketForServer( const SteamNetworkingIdentity &identityGameServer, int nRemoteVirtualPort, SteamDatagramRelayAuthTicket *pOutParsedTicket ) = 0;
	virtual HSteamNetConnection ConnectToHostedDedicatedServer( const SteamNetworkingIdentity &identityTarget, int nRemoteVirtualPort, int nOptions, const SteamNetworkingConfigValue_t *pOptions ) = 0;
	virtual uint16 GetHostedDedicatedServerPort() = 0;
	virtual SteamNetworkingPOPID GetHostedDedicatedServerPOPID() = 0;
	virtual EResult GetHostedDedicatedServerAddress( SteamDatagramHostedAddress *pRouting ) = 0;
	virtual HSteamListenSocket CreateHostedDedicatedServerListenSocket( int nLocalVirtualPort, int nOptions, const SteamNetworkingConfigValue_t *pOptions ) = 0;
	virtual bool ReceivedRelayAuthTicket( const void *pvTicket, int cbTicket, SteamDatagramRelayAuthTicket *pOutParsedTicket ) = 0;
	virtual EResult GetGameCoordinatorServerLogin( SteamDatagramGameCoordinatorServerLogin *pLogin, int *pcbSignedBlob, void *pBlob ) = 0;

	virtual bool BeginAsyncRequestFakeIP( int nNumPorts ) = 0;
	virtual void GetFakeIP( int idxFirstPort, SteamNetworkingFakeIPResult_t *pInfo ) = 0;
	virtual ISteamNetworkingFakeUDPPort *CreateFakeUDPPort( int idxFakeServerPort ) = 0;
};