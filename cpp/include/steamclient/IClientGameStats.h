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

class IClientGameStats
{
public:
    virtual unknown GetNewSession() = 0; //argc: 5, index 1
    virtual unknown EndSession() = 0; //argc: 4, index 2
    virtual unknown AddSessionAttributeInt() = 0; //argc: 4, index 3
    virtual unknown AddSessionAttributeString() = 0; //argc: 4, index 4
    virtual unknown AddSessionAttributeFloat() = 0; //argc: 4, index 5
    virtual unknown AddNewRow() = 0; //argc: 4, index 6
    virtual unknown CommitRow() = 0; //argc: 2, index 7
    virtual unknown CommitOutstandingRows() = 0; //argc: 2, index 8
    virtual unknown AddRowAttributeInt() = 0; //argc: 4, index 9
    virtual unknown AddRowAttributeString() = 0; //argc: 4, index 10
    virtual unknown AddRowAttributeFloat() = 0; //argc: 4, index 11
    virtual unknown AddSessionAttributeInt64() = 0; //argc: 5, index 12
    virtual unknown AddRowAttributeInt64() = 0; //argc: 5, index 13
};