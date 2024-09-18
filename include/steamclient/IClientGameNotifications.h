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

class IClientGameNotifications
{
public:
    virtual unknown_ret EnumerateNotifications() = 0; //argc: 1, index 1
    virtual unknown_ret GetNotificationCount() = 0; //argc: 1, index 2
    virtual unknown_ret GetNotification() = 0; //argc: 3, index 3
    virtual unknown_ret RemoveSession() = 0; //argc: 3, index 4
    virtual unknown_ret UpdateSession() = 0; //argc: 3, index 5
};