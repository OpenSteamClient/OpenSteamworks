#pragma once

enum EAccountType {
    EAccountType_Invalid = 0,
    // single user account
    EAccountType_Individual = 1,	
    // multiseat (e.g. cybercafe) account
    EAccountType_Multiseat = 2,	
    // game server account
    EAccountType_GameServer = 3,
    //  anonymous game server account
    EAccountType_AnonGameServer = 4,	
    EAccountType_Pending = 5,		
    // content server
    EAccountType_ContentServer = 6,	
    EAccountType_Clan = 7,
    EAccountType_Chat = 8,
    // Fake SteamID for local PSN account on PS3 or Live account on 360, etc.
    EAccountType_ConsoleUser = 9,	
    EAccountType_AnonUser = 10,

    // Max of 16 items in this field
    EAccountType_Max
};

enum EUniverse
{
	EUniverse_Invalid = 0,
	EUniverse_Public = 1,
	EUniverse_Beta = 2,
	EUniverse_Internal = 3,
	EUniverse_Dev = 4,
	EUniverse_Max
};

enum ENotificationPosition
{
    ENotificationPosition_TopLeft = 0,
	ENotificationPosition_TopRight = 1,
	ENotificationPosition_BottomLeft = 2,
	ENotificationPosition_BottomRight = 3,
};

enum ELanguage
{
	ELanguage_None = -1,
	ELanguage_English = 0,
	ELanguage_German = 1,
	ELanguage_French = 2,
	ELanguage_Italian = 3,
	ELanguage_Korean = 4,
	ELanguage_Spanish = 5,
	ELanguage_Simplified_Chinese = 6,
	ELanguage_Traditional_Chinese = 7,
	ELanguage_Russian = 8,
	ELanguage_Thai = 9,
	ELanguage_Japanese = 10,
	ELanguage_Portuguese = 11,
	ELanguage_Polish = 12,
	ELanguage_Danish = 13,
	ELanguage_Dutch = 14,
	ELanguage_Finnish = 15,
	ELanguage_Norwegian = 16,
	ELanguage_Swedish = 17,
	ELanguage_Hungarian = 18,
	ELanguage_Czech = 19,
	ELanguage_Romanian = 20,
	ELanguage_Turkish = 21,
	ELanguage_Brazilian = 22,
	ELanguage_Bulgarian = 23,
	ELanguage_Greek = 24,
	ELanguage_Arabic = 25,
	ELanguage_Ukrainian = 26,
	ELanguage_Latam_Spanish = 27,
	ELanguage_Vietnamese = 28,
};

enum EConfigStore
{
	EConfigStore_Invalid = 0,
	EConfigStore_Install = 1,
	EConfigStore_UserRoaming = 2,
	EConfigStore_UserLocal = 3,
	EConfigStore_Max = 4,
};

enum EHTMLMouseButton
{
	EHTMLMouseButton_Left = 0,
	EHTMLMouseButton_Right = 1,
	EHTMLMouseButton_Middle = 2
};

enum EHTMLKeyModifiers : unsigned int
{
	EHTMLKeyModifiers_None = 0,
	EHTMLKeyModifiers_AltDown = 1 << 0,
	EHTMLKeyModifiers_CtrlDown = 1 << 1,
    EHTMLKeyModifiers_ShiftDown = 1 << 2,
};