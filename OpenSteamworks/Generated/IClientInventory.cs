//==========================  AUTO-GENERATED FILE  ================================
//
// This file is partially auto-generated.
// If functions are removed, your changes to that function will be lost.
// Parameter types and names however are preserved if the function stays unchanged.
// Feel free to change parameters to be more accurate. 
//=============================================================================

using System;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data;
using CppSourceGen.Attributes;

namespace OpenSteamworks.Generated;

[CppClass]
public unsafe interface IClientInventory
{
    // WARNING: Arguments are unknown!
    public unknown GetResultStatus();  // argc: -1, index: 1, ipc args: [bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown DestroyResult();  // argc: -1, index: 2, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown GetResultItems();  // argc: -1, index: 3, ipc args: [bytes4, bytes4], ipc returns: [bytes1, bytes_external_length, bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetResultItemProperty();  // argc: -1, index: 4, ipc args: [bytes4, bytes4, string, bytes4], ipc returns: [bytes1, bytes_external_length, bytes4, bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetResultTimestamp();  // argc: -1, index: 5, ipc args: [bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown CheckResultSteamID();  // argc: -1, index: 6, ipc args: [bytes4, uint64], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SerializeResult();  // argc: -1, index: 7, ipc args: [bytes4, bytes4], ipc returns: [bytes1, bytes_external_length, bytes4]
    // WARNING: Arguments are unknown!
    public unknown DeserializeResult();  // argc: -1, index: 8, ipc args: [bytes4, bytes1, bytes_external_length], ipc returns: [bytes1, bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetAllItems();  // argc: -1, index: 9, ipc args: [], ipc returns: [bytes1, bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetItemsByID();  // argc: -1, index: 10, ipc args: [bytes4, bytes_external_length], ipc returns: [bytes1, bytes4]
    // WARNING: Arguments are unknown!
    public unknown GenerateItems();  // argc: -1, index: 11, ipc args: [bytes4, bytes4, bytes_external_length, bytes_external_length], ipc returns: [bytes1, bytes4]
    // WARNING: Arguments are unknown!
    public unknown AddPromoItems();  // argc: -1, index: 12, ipc args: [bytes4, bytes_external_length], ipc returns: [bytes1, bytes4]
    // WARNING: Arguments are unknown!
    public unknown ConsumeItem();  // argc: -1, index: 13, ipc args: [bytes8, bytes4], ipc returns: [bytes1, bytes4]
    // WARNING: Arguments are unknown!
    public unknown ExchangeItems();  // argc: -1, index: 14, ipc args: [bytes4, bytes4, bytes4, bytes4, bytes_external_length, bytes_external_length, bytes_external_length, bytes_external_length], ipc returns: [bytes1, bytes4]
    // WARNING: Arguments are unknown!
    public unknown TransferItemQuantity();  // argc: -1, index: 15, ipc args: [bytes8, bytes4, bytes8], ipc returns: [bytes1, bytes4]
    public unknown SendItemDropHeartbeat();  // argc: -1, index: 16, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown TriggerItemDrop();  // argc: -1, index: 17, ipc args: [bytes4], ipc returns: [bytes1, bytes4]
    // WARNING: Arguments are unknown!
    public unknown TradeItems();  // argc: -1, index: 18, ipc args: [uint64, bytes4, bytes4, bytes4, bytes4, bytes_external_length, bytes_external_length, bytes_external_length, bytes_external_length], ipc returns: [bytes1, bytes4]
    public unknown LoadItemDefinitions();  // argc: -1, index: 19, ipc args: [], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown GetItemDefinitionIDs();  // argc: -1, index: 20, ipc args: [bytes4], ipc returns: [bytes1, bytes_external_length, bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetItemDefinitionProperty();  // argc: -1, index: 21, ipc args: [bytes4, string, bytes4], ipc returns: [bytes1, bytes_external_length, bytes4]
    // WARNING: Arguments are unknown!
    public unknown RequestEligiblePromoItemDefinitionsIDs();  // argc: -1, index: 22, ipc args: [uint64], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown GetEligiblePromoItemDefinitionIDs();  // argc: -1, index: 23, ipc args: [uint64, bytes4], ipc returns: [bytes1, bytes_external_length, bytes4]
    // WARNING: Arguments are unknown!
    public unknown StartPurchase();  // argc: -1, index: 24, ipc args: [bytes4, bytes4, bytes_external_length, bytes_external_length], ipc returns: [bytes8]
    public unknown RequestPrices();  // argc: -1, index: 25, ipc args: [], ipc returns: [bytes8]
    public unknown GetNumItemsWithPrices();  // argc: -1, index: 26, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetItemsWithPrices();  // argc: -1, index: 27, ipc args: [bytes4], ipc returns: [bytes1, bytes_external_length, bytes_external_length, bytes_external_length]
    // WARNING: Arguments are unknown!
    public unknown GetItemPrice();  // argc: -1, index: 28, ipc args: [bytes4], ipc returns: [bytes1, bytes8, bytes8]
    public unknown StartUpdateProperties();  // argc: -1, index: 29, ipc args: [], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown RemoveProperty();  // argc: -1, index: 30, ipc args: [bytes8, bytes8, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetProperty(bool unk1);  // argc: -1, index: 31, ipc args: [bytes8, bytes8, string, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetProperty(double unk1, bool unk2);  // argc: -1, index: 32, ipc args: [bytes8, bytes8, string, bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetProperty(int unk1, bool unk2, double unk3);  // argc: -1, index: 33, ipc args: [bytes8, bytes8, string, bytes8], ipc returns: [bytes1]
    public unknown SetProperty();  // argc: -1, index: 34, ipc args: [bytes8, bytes8, string, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SubmitUpdateProperties();  // argc: -1, index: 35, ipc args: [bytes8], ipc returns: [bytes1, bytes4]
    // WARNING: Arguments are unknown!
    public unknown InspectItem();  // argc: -1, index: 36, ipc args: [string], ipc returns: [bytes1, bytes4]
    public unknown TEST_ClearMsgCache();  // argc: -1, index: 37, ipc args: [], ipc returns: []
}