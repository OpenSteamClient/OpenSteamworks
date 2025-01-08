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

class IClientConfigStore
{
public:
    virtual unknown IsSet() = 0; //argc: 2, index 1
    virtual unknown GetBool() = 0; //argc: 3, index 2
    virtual unknown GetInt() = 0; //argc: 3, index 3
    virtual unknown GetUint64() = 0; //argc: 4, index 4
    virtual unknown GetFloat() = 0; //argc: 3, index 5
    virtual unknown GetString() = 0; //argc: 3, index 6
    virtual uint32_t GetBinary(EConfigStore configstore, const char *key, void *buf, uint32_t bufLen) = 0; //argc: 4, index 7
    virtual uint32_t GetBinary(EConfigStore configstore, const char *key, CUtlBuffer *buf) = 0; //argc: 3, index 8
    virtual unknown GetBinaryWatermarked() = 0; //argc: 4, index 9
    virtual unknown SetBool() = 0; //argc: 3, index 10
    virtual unknown SetInt() = 0; //argc: 3, index 11
    virtual unknown SetUint64() = 0; //argc: 4, index 12
    virtual unknown SetFloat() = 0; //argc: 3, index 13
    virtual unknown SetString() = 0; //argc: 3, index 14
    virtual unknown SetBinary() = 0; //argc: 4, index 15
    virtual unknown SetBinaryWatermarked() = 0; //argc: 4, index 16
    virtual unknown RemoveKey() = 0; //argc: 2, index 17
    virtual unknown GetKeySerialized() = 0; //argc: 4, index 18
    virtual unknown FlushToDisk() = 0; //argc: 1, index 19
    virtual unknown GetSubKeyCount() = 0; //argc: 2, index 20
    virtual unknown GetSubKeyName() = 0; //argc: 3, index 21
};