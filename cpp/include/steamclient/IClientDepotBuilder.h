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

class IClientDepotBuilder
{
public:
    virtual unknown_ret BGetDepotBuildStatus() = 0; //argc: 5, index 1
    virtual unknown_ret VerifyChunkStore() = 0; //argc: 3, index 2
    virtual unknown_ret Unknown_2_DONTUSE() = 0; //argc: -1, index 3
    virtual unknown_ret DownloadChunk() = 0; //argc: 3, index 4
    virtual unknown_ret StartDepotBuild() = 0; //argc: 4, index 5
    virtual unknown_ret CommitAppBuild() = 0; //argc: 6, index 6
};