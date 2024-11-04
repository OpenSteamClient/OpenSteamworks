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

class IClientGameCoordinator
{
public:
    virtual EGCResults SendMessage(AppId_t nAppID, uint32 unMsgType, const void *pubData, uint32 cubData) = 0; //argc: 4, index 1
    virtual bool IsMessageAvailable(AppId_t nAppID, uint32 *pcubMsgSize) = 0; //argc: 2, index 2
    virtual EGCResults RetrieveMessage(AppId_t nAppID, uint32 *punMsgType, void *pubDest, uint32 cubDest, uint32 *pcubMsgSize) = 0; //argc: 5, index 3
};