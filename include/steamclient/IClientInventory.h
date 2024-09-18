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

class IClientInventory
{
public:
    virtual unknown_ret GetResultStatus() = 0; //argc: 1, index 1
    virtual unknown_ret DestroyResult() = 0; //argc: 1, index 2
    virtual unknown_ret GetResultItems() = 0; //argc: 4, index 3
    virtual unknown_ret GetResultItemProperty() = 0; //argc: 6, index 4
    virtual unknown_ret GetResultTimestamp() = 0; //argc: 1, index 5
    virtual unknown_ret CheckResultSteamID() = 0; //argc: 3, index 6
    virtual unknown_ret SerializeResult() = 0; //argc: 4, index 7
    virtual unknown_ret DeserializeResult() = 0; //argc: 4, index 8
    virtual unknown_ret GetAllItems() = 0; //argc: 1, index 9
    virtual unknown_ret GetItemsByID() = 0; //argc: 3, index 10
    virtual unknown_ret GenerateItems() = 0; //argc: 5, index 11
    virtual unknown_ret AddPromoItems() = 0; //argc: 3, index 12
    virtual unknown_ret ConsumeItem() = 0; //argc: 4, index 13
    virtual unknown_ret ExchangeItems() = 0; //argc: 9, index 14
    virtual unknown_ret TransferItemQuantity() = 0; //argc: 6, index 15
    virtual unknown_ret SendItemDropHeartbeat() = 0; //argc: 0, index 16
    virtual unknown_ret TriggerItemDrop() = 0; //argc: 2, index 17
    virtual unknown_ret TradeItems() = 0; //argc: 11, index 18
    virtual unknown_ret LoadItemDefinitions() = 0; //argc: 0, index 19
    virtual unknown_ret GetItemDefinitionIDs() = 0; //argc: 3, index 20
    virtual unknown_ret GetItemDefinitionProperty() = 0; //argc: 5, index 21
    virtual unknown_ret RequestEligiblePromoItemDefinitionsIDs() = 0; //argc: 2, index 22
    virtual unknown_ret GetEligiblePromoItemDefinitionIDs() = 0; //argc: 5, index 23
    virtual unknown_ret StartPurchase() = 0; //argc: 4, index 24
    virtual unknown_ret RequestPrices() = 0; //argc: 0, index 25
    virtual unknown_ret GetNumItemsWithPrices() = 0; //argc: 0, index 26
    virtual unknown_ret GetItemsWithPrices() = 0; //argc: 4, index 27
    virtual unknown_ret GetItemPrice() = 0; //argc: 3, index 28
    virtual unknown_ret StartUpdateProperties() = 0; //argc: 0, index 29
    virtual unknown_ret RemoveProperty() = 0; //argc: 5, index 30
    virtual unknown_ret SetProperty(unknown_ret) = 0; //argc: 6, index 31
    virtual unknown_ret SetProperty(unknown_ret, unknown_ret) = 0; //argc: 6, index 32
    virtual unknown_ret Unknown_32_DONTUSE() = 0; //argc: -1, index 33
    virtual unknown_ret SetProperty(unknown_ret, unknown_ret, unknown_ret) = 0; //argc: 6, index 34
    virtual unknown_ret SubmitUpdateProperties() = 0; //argc: 3, index 35
    virtual unknown_ret InspectItem() = 0; //argc: 2, index 36
    virtual unknown_ret TEST_ClearMsgCache() = 0; //argc: 0, index 37
};