//==========================  AUTO-GENERATED FILE  ================================
//
// This file is partially auto-generated.
// If functions are removed, your changes to that function will be lost.
// Parameter types and names however are preserved if the function stays unchanged.
// Feel free to change parameters to be more accurate. 
//
//=============================================================================

#pragma once

#include "clienttypes.h"

class IClientNetworking
{
public:
    virtual bool SendP2PPacket(CSteamID steamIDRemote, const void *pubData, uint32 cubData, EP2PSend eP2PSendType, int nChannel) = 0; //argc: 6, index 1
    virtual bool IsP2PPacketAvailable(uint32 *pcubMsgSize, int nChannel) = 0; //argc: 2, index 2
    virtual bool ReadP2PPacket(void *pubDest, uint32 cubDest, uint32 *pcubMsgSize, CSteamID *psteamIDRemote, int nChannel) = 0; //argc: 5, index 3
    virtual bool AcceptP2PSessionWithUser(CSteamID steamIDRemote) = 0; //argc: 2, index 4
    virtual bool CloseP2PSessionWithUser(CSteamID steamIDRemote) = 0; //argc: 2, index 5
    virtual bool CloseP2PChannelWithUser(CSteamID steamIDRemote, int nChannel) = 0; //argc: 3, index 6
    virtual bool GetP2PSessionState(CSteamID steamIDRemote, P2PSessionState_t *pConnectionState) = 0; //argc: 3, index 7
    virtual bool AllowP2PPacketRelay(bool bAllow) = 0; //argc: 1, index 8
    virtual SNetListenSocket_t CreateListenSocket(int nVirtualP2PPort, SteamIPAddress_t nIP, uint16 nPort, bool bAllowUseOfPacketRelay) = 0; //argc: 8, index 9
    virtual SNetSocket_t CreateP2PConnectionSocket(CSteamID steamIDTarget, int nVirtualPort, int nTimeoutSec, bool bAllowUseOfPacketRelay) = 0; //argc: 5, index 10
    virtual SNetSocket_t CreateConnectionSocket(SteamIPAddress_t nIP, uint16 nPort, int nTimeoutSec) = 0; //argc: 7, index 11
    virtual bool DestroySocket(SNetSocket_t hSocket, bool bNotifyRemoteEnd) = 0; //argc: 2, index 12
    virtual bool DestroyListenSocket(SNetListenSocket_t hSocket, bool bNotifyRemoteEnd) = 0; //argc: 2, index 13
    virtual bool SendDataOnSocket(SNetSocket_t hSocket, void *pubData, uint32 cubData, bool bReliable) = 0; //argc: 4, index 14
    virtual bool IsDataAvailableOnSocket(SNetSocket_t hSocket, uint32 *pcubMsgSize) = 0; //argc: 2, index 15
    virtual bool RetrieveDataFromSocket(SNetSocket_t hSocket, void *pubDest, uint32 cubDest, uint32 *pcubMsgSize) = 0; //argc: 4, index 16
    virtual bool IsDataAvailable(SNetListenSocket_t hListenSocket, uint32 *pcubMsgSize, SNetSocket_t *phSocket) = 0; //argc: 3, index 17
    virtual bool RetrieveData(SNetListenSocket_t hListenSocket, void *pubDest, uint32 cubDest, uint32 *pcubMsgSize, SNetSocket_t *phSocket) = 0; //argc: 5, index 18
    virtual bool GetSocketInfo(SNetSocket_t hSocket, CSteamID *pSteamIDRemote, int *peSocketStatus, SteamIPAddress_t *punIPRemote, uint16 *punPortRemote) = 0; //argc: 5, index 19
    virtual bool GetListenSocketInfo(SNetListenSocket_t hListenSocket, SteamIPAddress_t *pnIP, uint16 *pnPort) = 0; //argc: 3, index 20
    virtual ESNetSocketConnectionType GetSocketConnectionType(SNetSocket_t hSocket) = 0; //argc: 1, index 21
    virtual int GetMaxPacketSize(SNetSocket_t hSocket) = 0; //argc: 1, index 22
};