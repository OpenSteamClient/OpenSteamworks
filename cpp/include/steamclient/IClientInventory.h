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
    virtual EResult GetResultStatus(SteamInventoryResult_t resultHandle) = 0; //argc: -1, index 1
    virtual void DestroyResult(SteamInventoryResult_t resultHandle) = 0; //argc: -1, index 2
    virtual bool GetResultItems(SteamInventoryResult_t resultHandle, SteamItemDetails_t *pOutItemsArray, uint32 outItemsArrayMax, uint32 *punOutItemsArraySize) = 0; //argc: -1, index 3
    virtual bool GetResultItemProperty(SteamInventoryResult_t resultHandle, uint32 unItemIndex, const char *pchPropertyName, char *pchValueBuffer, uint32 unValueBufferSize, uint32 *punValueBufferSizeOut) = 0; //argc: -1, index 4
    virtual uint32 GetResultTimestamp(SteamInventoryResult_t resultHandle) = 0; //argc: -1, index 5
    virtual bool CheckResultSteamID(SteamInventoryResult_t resultHandle, CSteamID steamIDExpected) = 0; //argc: -1, index 6
    virtual bool SerializeResult(SteamInventoryResult_t resultHandle, void *pOutBuffer, uint32 *punOutBufferSize) = 0; //argc: -1, index 7
    virtual bool DeserializeResult(SteamInventoryResult_t *pOutResultHandle, const void *pBuffer, uint32 unBufferSize, bool bRESERVED_MUST_BE_FALSE = false) = 0; //argc: -1, index 8
    virtual bool GetAllItems(SteamInventoryResult_t *pResultHandle) = 0; //argc: -1, index 9
    virtual bool GetItemsByID(SteamInventoryResult_t *pResultHandle, const SteamItemInstanceID_t *pInstanceIDs, uint32 unCountInstanceIDs) = 0; //argc: -1, index 10
    virtual bool GenerateItems(SteamInventoryResult_t *pResultHandle, const SteamItemDef_t *pArrayItemDefs, uint32 unArrayItemDefs, const uint32 *punArrayQuantity, uint32 unArrayLength) = 0; //argc: -1, index 11
    virtual bool AddPromoItems(SteamInventoryResult_t *pResultHandle, const SteamItemDef_t *pArrayItemDefs, uint32 unArrayLength) = 0; //argc: -1, index 12
    virtual bool ConsumeItem(SteamInventoryResult_t *pResultHandle, SteamItemInstanceID_t itemConsume, uint32 unQuantity) = 0; //argc: -1, index 13
    virtual bool ExchangeItems( SteamInventoryResult_t *pResultHandle, const SteamItemDef_t *pArrayGenerate, uint32 unArrayGenerateLen, const uint32 *punArrayGenerateQuantity, uint32 unArrayGenerateQuantityLength, const SteamItemInstanceID_t *pArrayDestroy, uint32 unArrayDestroyLen, const uint32 *punArrayDestroyQuantity, uint32 unArrayDestroyQuantityLength) = 0; //argc: -1, index 14
    virtual bool TransferItemQuantity(SteamInventoryResult_t *pResultHandle, SteamItemInstanceID_t itemIdSource, uint32 unQuantity, SteamItemInstanceID_t itemIdDest) = 0; //argc: -1, index 15
    virtual void SendItemDropHeartbeat() = 0; //argc: -1, index 16
    virtual bool TriggerItemDrop(SteamInventoryResult_t *pResultHandle, SteamItemDef_t dropListDefinition) = 0; //argc: -1, index 17
    virtual bool TradeItems(SteamInventoryResult_t *pResultHandle, CSteamID steamIDTradePartner, const SteamItemInstanceID_t *pArrayGive, uint32 unArrayGiveLen, const uint32 *pArrayGiveQuantity, uint32 nArrayGiveQuantityLength, const SteamItemInstanceID_t *pArrayGet, uint32 unArrayGetLen, const uint32 *pArrayGetQuantity, uint32 nArrayGetQuantityLength) = 0; //argc: -1, index 18
    virtual bool LoadItemDefinitions() = 0; //argc: -1, index 19
    virtual bool GetItemDefinitionIDs(SteamItemDef_t *pItemDefIDs, uint32 unItemDefIDsLen, uint32 *punItemDefIDsArraySize) = 0; //argc: -1, index 20
    virtual bool GetItemDefinitionProperty(SteamItemDef_t iDefinition, const char *pchPropertyName, char *pchValueBuffer, uint32 cubValueBuffer, uint32 *punValueBufferSizeOut) = 0; //argc: -1, index 21
    virtual SteamAPICall_t RequestEligiblePromoItemDefinitionsIDs(CSteamID steamID) = 0; //argc: -1, index 22
    virtual bool GetEligiblePromoItemDefinitionIDs(CSteamID steamID, SteamItemDef_t *pItemDefIDs, uint32 itemDefIDsLen, uint32 *punItemDefIDsArraySize) = 0; //argc: -1, index 23
    virtual SteamAPICall_t StartPurchase(const SteamItemDef_t *pArrayItemDefs, uint32 arrayItemDefsLen, const uint32 *punArrayQuantity, uint32 unArrayQuantityLength) = 0; //argc: -1, index 24
    virtual SteamAPICall_t RequestPrices() = 0; //argc: -1, index 25
    virtual uint32 GetNumItemsWithPrices() = 0; //argc: -1, index 26
    virtual bool GetItemsWithPrices(SteamItemDef_t *pArrayItemDefs, uint64 *pCurrentPrices, uint64 *pBasePrices, uint32 unPricesLength) = 0; //argc: -1, index 27
    virtual bool GetItemPrice(SteamItemDef_t iDefinition, uint64 *pCurrentPrice, uint64 *pBasePrice) = 0; //argc: -1, index 28
    virtual SteamInventoryUpdateHandle_t StartUpdateProperties() = 0; //argc: -1, index 29
    virtual bool RemoveProperty(SteamInventoryUpdateHandle_t handle, SteamItemInstanceID_t nItemID, const char *pchPropertyName) = 0; //argc: -1, index 30
    virtual bool SetProperty(SteamInventoryUpdateHandle_t handle, SteamItemInstanceID_t nItemID, const char *pchPropertyName, const char *pchPropertyValue) = 0; //argc: -1, index 31
    virtual bool SetProperty(SteamInventoryUpdateHandle_t handle, SteamItemInstanceID_t nItemID, const char *pchPropertyName, bool bValue) = 0; //argc: -1, index 32
    virtual bool SetProperty(SteamInventoryUpdateHandle_t handle, SteamItemInstanceID_t nItemID, const char *pchPropertyName, int64 nValue) = 0; //argc: -1, index 33
    virtual bool SetProperty(SteamInventoryUpdateHandle_t handle, SteamItemInstanceID_t nItemID, const char *pchPropertyName, float flValue) = 0; //argc: -1, index 34
    virtual bool SubmitUpdateProperties(SteamInventoryUpdateHandle_t handle, SteamInventoryResult_t * pResultHandle) = 0; //argc: -1, index 35
    virtual bool InspectItem(SteamInventoryResult_t *pResultHandle, const char *pchItemToken) = 0; //argc: -1, index 36
    virtual void TEST_ClearMsgCache() = 0; //argc: -1, index 37
};