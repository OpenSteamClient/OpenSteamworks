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

class IRegistryInterface
{
public:
    virtual unknown BGetValueStr() = 0; //argc: 5, index 1
    virtual unknown BGetValueUint() = 0; //argc: 4, index 2
    virtual unknown BGetValueBin() = 0; //argc: 5, index 3
    virtual unknown BSetValueStr() = 0; //argc: 4, index 4
    virtual unknown BSetValueUint() = 0; //argc: 4, index 5
    virtual unknown BSetValueBin() = 0; //argc: 5, index 6
    virtual unknown BDeleteValue() = 0; //argc: 3, index 7
    virtual unknown BDeleteKey() = 0; //argc: 2, index 8
    virtual unknown BKeyExists() = 0; //argc: 2, index 9
    virtual unknown BGetSubKeys() = 0; //argc: 4, index 10
    virtual unknown BGetValues() = 0; //argc: 5, index 11
    virtual unknown BEnumerateKey() = 0; //argc: 5, index 12
    virtual unknown BEnumerateValue() = 0; //argc: 6, index 13
};