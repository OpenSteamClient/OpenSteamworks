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
    virtual unknown BGetDepotBuildStatus() = 0; //argc: -1, index 1
    virtual unknown VerifyChunkStore() = 0; //argc: -1, index 2
    virtual unknown DownloadDepot() = 0; //argc: -1, index 3
    virtual unknown DownloadChunk() = 0; //argc: -1, index 4
    virtual unknown StartDepotBuild() = 0; //argc: -1, index 5
    virtual unknown CommitAppBuild() = 0; //argc: -1, index 6
};