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

class IClientShader
{
public:
    virtual unknown_ret BIsShaderManagementEnabled() = 0; //argc: 0, index 1
    virtual unknown_ret BIsShaderBackgroundProcessingEnabled() = 0; //argc: 0, index 2
    virtual unknown_ret EnableShaderManagement() = 0; //argc: 1, index 3
    virtual unknown_ret EnableShaderBackgroundProcessing() = 0; //argc: 1, index 4
    virtual unknown_ret GetShaderDepotsTotalDiskUsage() = 0; //argc: 0, index 5
    virtual unknown_ret GetShaderCacheDiskSize() = 0; //argc: 3, index 6
    virtual unknown_ret StartShaderScan() = 0; //argc: 2, index 7
    virtual unknown_ret StartPipelineBuild() = 0; //argc: 2, index 8
    virtual unknown_ret StartShaderConversion() = 0; //argc: 4, index 9
    virtual unknown_ret StartShaderPruning() = 0; //argc: 0, index 10
    virtual unknown_ret ProcessShaderCache() = 0; //argc: 1, index 11
    virtual unknown_ret GetShaderCacheProcessingCompletion() = 0; //argc: 0, index 12
    virtual unknown_ret GetShaderCacheProcessingAppID() = 0; //argc: 0, index 13
    virtual unknown_ret SkipShaderProcessing() = 0; //argc: 1, index 14
    virtual unknown_ret BAppHasPendingShaderContentDownload() = 0; //argc: 1, index 15
    virtual unknown_ret GetAppPendingShaderDownloadSize() = 0; //argc: 1, index 16
    virtual unknown_ret CheckDepotManifestID() = 0; //argc: 1, index 17
    virtual unknown_ret GetBucketManifest() = 0; //argc: 3, index 18
    virtual unknown_ret GetStaleBucket() = 0; //argc: 2, index 19
    virtual unknown_ret ReportExternalBuild() = 0; //argc: 9, index 20
    virtual unknown_ret PrepopulatePrecompiledCache() = 0; //argc: 7, index 21
    virtual unknown_ret WritePrecompiledCache() = 0; //argc: 4, index 22
    virtual unknown_ret CompileShaders() = 0; //argc: 4, index 23
    virtual unknown_ret GetShaderBucketForGraphicsAPI() = 0; //argc: 2, index 24
    virtual unknown_ret EnableShaderManagementSystem() = 0; //argc: 1, index 25
};