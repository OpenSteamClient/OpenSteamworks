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
    virtual unknown BIsShaderManagementEnabled() = 0; //argc: -1, index 1
    virtual unknown BIsShaderBackgroundProcessingEnabled() = 0; //argc: -1, index 2
    virtual unknown EnableShaderManagement() = 0; //argc: -1, index 3
    virtual unknown EnableShaderBackgroundProcessing() = 0; //argc: -1, index 4
    virtual unknown GetShaderDepotsTotalDiskUsage() = 0; //argc: -1, index 5
    virtual unknown GetShaderCacheDiskSize() = 0; //argc: -1, index 6
    virtual unknown StartShaderScan() = 0; //argc: -1, index 7
    virtual unknown StartPipelineBuild() = 0; //argc: -1, index 8
    virtual unknown StartShaderConversion() = 0; //argc: -1, index 9
    virtual unknown StartShaderPruning() = 0; //argc: -1, index 10
    virtual unknown ProcessShaderCache() = 0; //argc: -1, index 11
    virtual unknown GetShaderCacheProcessingCompletion() = 0; //argc: -1, index 12
    virtual unknown GetShaderCacheProcessingAppID() = 0; //argc: -1, index 13
    virtual unknown SkipShaderProcessing() = 0; //argc: -1, index 14
    virtual unknown BAppHasPendingShaderContentDownload() = 0; //argc: -1, index 15
    virtual unknown GetAppPendingShaderDownloadSize() = 0; //argc: -1, index 16
    virtual unknown CheckDepotManifestID() = 0; //argc: -1, index 17
    virtual unknown GetBucketManifest() = 0; //argc: -1, index 18
    virtual unknown GetStaleBucket() = 0; //argc: -1, index 19
    virtual unknown ReportExternalBuild() = 0; //argc: -1, index 20
    virtual unknown PrepopulatePrecompiledCache() = 0; //argc: -1, index 21
    virtual unknown WritePrecompiledCache() = 0; //argc: -1, index 22
    virtual unknown CompileShaders() = 0; //argc: -1, index 23
    virtual unknown GetShaderBucketForGraphicsAPI() = 0; //argc: -1, index 24
    virtual unknown EnableShaderManagementSystem() = 0; //argc: -1, index 25
};