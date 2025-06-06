//==========================  AUTO-GENERATED FILE  ================================
//
// This file is partially auto-generated.
// If functions are removed, your changes to that function will be lost.
// Parameter types and names however are preserved if the function stays unchanged.
// Feel free to change parameters to be more accurate. 
//=============================================================================

using System;
using System.Text;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Protobuf;
using OpenSteamworks.Data.Structs;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data;
using CppSourceGen.Attributes;

namespace OpenSteamworks.Generated;

[CppClass]
public unsafe interface IClientFriends
{
    public string GetPersonaName();  // argc: -1, index: 1, ipc args: [], ipc returns: [string]
    public SteamAPICall_t SetPersonaName(string name);  // argc: -1, index: 2, ipc args: [string], ipc returns: [bytes8]
    public unknown SetPersonaNameSDK();  // argc: -1, index: 3, ipc args: [string], ipc returns: [bytes8]
    public bool IsPersonaNameSet();  // argc: -1, index: 4, ipc args: [], ipc returns: [boolean]
    public EPersonaState GetPersonaState();  // argc: -1, index: 5, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public void SetPersonaState(EPersonaState state);  // argc: -1, index: 6, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public bool NotifyUIOfMenuChange(bool bShowAvatars, bool bSortByName, bool bShowOnlineOnly, bool bShowUntaggedFriends);  // argc: -1, index: 7, ipc args: [bytes1, bytes1, bytes1, bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    // 4 = Direct
    // 8 = Group
    public unknown GetFriendCount(EFriendFlags flags = EFriendFlags.Immediate);  // argc: -1, index: 8, ipc args: [bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetFriendArray(CSteamID[] steamid, StringBuilder wtf, int max, EFriendFlags flags);  // argc: -1, index: 9, ipc args: [bytes4, bytes4], ipc returns: [bytes4, bytes_external_length, bytes_external_length]
    // WARNING: Arguments are unknown!
    public unknown GetFriendArrayInGame();  // argc: -1, index: 10, ipc args: [bytes4], ipc returns: [bytes4, bytes_external_length, bytes_external_length]
    // WARNING: Arguments are unknown!
    public CSteamID GetFriendByIndex(int index, EFriendFlags flags = EFriendFlags.Immediate);  // argc: -1, index: 11, ipc args: [bytes4, bytes4], ipc returns: [uint64]
    public unknown GetOnlineFriendCount();  // argc: -1, index: 12, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public EFriendRelationship GetFriendRelationship(CSteamID steamid);  // argc: -1, index: 13, ipc args: [uint64], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public EPersonaState GetFriendPersonaState(CSteamID friend);  // argc: -1, index: 14, ipc args: [uint64], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public string GetFriendPersonaName(CSteamID steamid);  // argc: -1, index: 15, ipc args: [uint64], ipc returns: [string]
    public HImage GetSmallFriendAvatar(CSteamID steamid);  // argc: -1, index: 16, ipc args: [uint64], ipc returns: [bytes4]
    public HImage GetMediumFriendAvatar(CSteamID steamid);  // argc: -1, index: 17, ipc args: [uint64], ipc returns: [bytes4]
    public HImage GetLargeFriendAvatar(CSteamID steamid);  // argc: -1, index: 18, ipc args: [uint64], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public bool BGetFriendAvatarURL(StringBuilder avatarOut, int avatarOutMax, CSteamID steamid, int unk);  // argc: -1, index: 19, ipc args: [bytes4, uint64, bytes4], ipc returns: [boolean, bytes_external_length]
    // WARNING: Arguments are unknown!
    public bool GetFriendAvatarHash(StringBuilder avatarOut, int avatarOutMax, CSteamID steamid);  // argc: -1, index: 20, ipc args: [bytes4, uint64], ipc returns: [bytes1, bytes_external_length]
    // WARNING: Arguments are unknown!
    public void SetFriendRegValue(CSteamID steamIDFriend, string key, string value);  // argc: -1, index: 21, ipc args: [uint64, string, string], ipc returns: []
    // WARNING: Arguments are unknown!
    public string GetFriendRegValue(CSteamID steamIDFriend, string key);  // argc: -1, index: 22, ipc args: [uint64, string], ipc returns: [string]
    // WARNING: Arguments are unknown!
    public bool DeleteFriendRegValue(CSteamID steamIDFriend, string key);  // argc: -1, index: 23, ipc args: [uint64, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public bool GetFriendGamePlayed(CSteamID steamid, out FriendGameInfo_t info);  // argc: -1, index: 24, ipc args: [uint64], ipc returns: [bytes1, bytes24]
    // WARNING: Arguments are unknown!
    public string GetFriendGamePlayedExtraInfo(CSteamID steamid);  // argc: -1, index: 25, ipc args: [uint64], ipc returns: [string]
    // WARNING: Arguments are unknown!
    public unknown GetFriendGameServer();  // argc: -1, index: 26, ipc args: [uint64], ipc returns: [uint64]
    // WARNING: Arguments are unknown!
    public EPersonaStateFlag GetFriendPersonaStateFlags(CSteamID steamid);  // argc: -1, index: 27, ipc args: [uint64], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown64 GetFriendBroadcastID(CSteamID steamid);  // argc: -1, index: 28, ipc args: [uint64], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public string GetFriendPersonaNameHistory(CSteamID steamid, int index);  // argc: -1, index: 29, ipc args: [uint64, bytes4], ipc returns: [string]
    // WARNING: Arguments are unknown!
    public SteamAPICall_t RequestPersonaNameHistory(CSteamID steamid);  // argc: -1, index: 30, ipc args: [uint64], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public string GetFriendPersonaNameHistoryAndDate(CSteamID steamid, int index, out RTime32 timestamp);  // argc: -1, index: 31, ipc args: [uint64, bytes4], ipc returns: [string, bytes4]
    // WARNING: Arguments are unknown!
    public bool AddFriend(CSteamID steamID);  // argc: -1, index: 32, ipc args: [uint64], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public bool RemoveFriend(CSteamID steamID);  // argc: -1, index: 33, ipc args: [uint64], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public bool HasFriend(CSteamID steamID, EFriendFlags flags);  // argc: -1, index: 34, ipc args: [uint64, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public bool RequestUserInformation(CSteamID steamID, bool requireNameOnly);  // argc: -1, index: 35, ipc args: [uint64, bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public bool SetIgnoreFriend(CSteamID steamID, bool blocked);  // argc: -1, index: 36, ipc args: [uint64, bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown ReportChatDeclined(CSteamID steamID);  // argc: -1, index: 37, ipc args: [uint64], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown CreateFriendsGroup(string groupname);  // argc: -1, index: 38, ipc args: [string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown DeleteFriendsGroup(short id);  // argc: -1, index: 39, ipc args: [bytes2], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown RenameFriendsGroup(string newname, short id);  // argc: -1, index: 40, ipc args: [string, bytes2], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown AddFriendToGroup(CSteamID steamid, short groupid);  // argc: -1, index: 41, ipc args: [uint64, bytes2], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown RemoveFriendFromGroup(CSteamID steamid, short groupid);  // argc: -1, index: 42, ipc args: [uint64, bytes2], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public bool IsFriendMemberOfFriendsGroup(CSteamID steamid, short groupid);  // argc: -1, index: 43, ipc args: [uint64, bytes2], ipc returns: [boolean]
    public int GetFriendsGroupCount();  // argc: -1, index: 44, ipc args: [], ipc returns: [bytes2]
    public short GetFriendsGroupIDByIndex(int index);  // argc: -1, index: 45, ipc args: [bytes2], ipc returns: [bytes2]
    public string GetFriendsGroupName(short groupid);  // argc: -1, index: 46, ipc args: [bytes2], ipc returns: [string]
    // WARNING: Arguments are unknown!
    public int GetFriendsGroupMembershipCount(short groupid);  // argc: -1, index: 47, ipc args: [bytes2], ipc returns: [bytes2]
    // WARNING: Arguments are unknown!
    public CSteamID GetFirstFriendsGroupMember(short groupid);  // argc: -1, index: 48, ipc args: [bytes2], ipc returns: [uint64]
    // WARNING: Arguments are unknown!
    public CSteamID GetNextFriendsGroupMember(short groupid);  // argc: -1, index: 49, ipc args: [bytes2], ipc returns: [uint64]
    // WARNING: Arguments are unknown!
    public unknown GetGroupFriendsMembershipCount();  // argc: -1, index: 50, ipc args: [uint64], ipc returns: [bytes2]
    // WARNING: Arguments are unknown!
    public unknown GetFirstGroupFriendsMember();  // argc: -1, index: 51, ipc args: [uint64], ipc returns: [bytes2]
    // WARNING: Arguments are unknown!
    public unknown GetNextGroupFriendsMember();  // argc: -1, index: 52, ipc args: [uint64], ipc returns: [bytes2]
    // WARNING: Arguments are unknown!
    public string GetPlayerNickname(CSteamID steamid);  // argc: -1, index: 53, ipc args: [uint64], ipc returns: [string]
    // WARNING: Arguments are unknown!
    public bool SetPlayerNickname(CSteamID steamid, string nickname);  // argc: -1, index: 54, ipc args: [uint64, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown GetFriendSteamLevel(CSteamID steamid);  // argc: -1, index: 55, ipc args: [uint64], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetChatMessagesCount(CSteamID steamid);  // argc: -1, index: 56, ipc args: [uint64], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetChatMessage();  // argc: -1, index: 57, ipc args: [uint64, bytes4, bytes4], ipc returns: [bytes4, bytes_external_length, bytes4, bytes8, bytes4]
    // WARNING: Arguments are unknown!
    public unknown SendMsgToFriend(CSteamID steamIDFriend, EChatEntryType eFriendMsgType, string msg);  // argc: -1, index: 58, ipc args: [uint64, bytes4, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown ClearChatHistory(CSteamID steamIDFriend);  // argc: -1, index: 59, ipc args: [uint64], ipc returns: []
    public unknown GetKnownClanCount();  // argc: -1, index: 60, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetKnownClanByIndex();  // argc: -1, index: 61, ipc args: [bytes4], ipc returns: [uint64]
    public unknown GetClanCount();  // argc: -1, index: 62, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetClanByIndex();  // argc: -1, index: 63, ipc args: [bytes4], ipc returns: [uint64]
    // WARNING: Arguments are unknown!
    public unknown GetClanName();  // argc: -1, index: 64, ipc args: [uint64], ipc returns: [string]
    // WARNING: Arguments are unknown!
    public unknown GetClanTag();  // argc: -1, index: 65, ipc args: [uint64], ipc returns: [string]
    // WARNING: Arguments are unknown!
    public unknown GetFriendActivityCounts();  // argc: -1, index: 66, ipc args: [bytes1], ipc returns: [bytes1, bytes4, bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetClanActivityCounts();  // argc: -1, index: 67, ipc args: [uint64], ipc returns: [bytes1, bytes4, bytes4, bytes4]
    // WARNING: Arguments are unknown!
    public unknown DownloadClanActivityCounts();  // argc: -1, index: 68, ipc args: [bytes4, bytes_external_length], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown GetFriendsGroupActivityCounts();  // argc: -1, index: 69, ipc args: [bytes2], ipc returns: [bytes1, bytes4, bytes4]
    // WARNING: Arguments are unknown!
    public unknown IsClanPublic();  // argc: -1, index: 70, ipc args: [uint64], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown IsClanOfficialGameGroup();  // argc: -1, index: 71, ipc args: [uint64], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown JoinClanChatRoom(CSteamID steamID);  // argc: -1, index: 72, ipc args: [uint64], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown LeaveClanChatRoom();  // argc: -1, index: 73, ipc args: [uint64], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown GetClanChatMemberCount();  // argc: -1, index: 74, ipc args: [uint64], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetChatMemberByIndex();  // argc: -1, index: 75, ipc args: [uint64, bytes4], ipc returns: [uint64]
    // WARNING: Arguments are unknown!
    public unknown SendClanChatMessage();  // argc: -1, index: 76, ipc args: [uint64, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown GetClanChatMessage();  // argc: -1, index: 77, ipc args: [uint64, bytes4, bytes4], ipc returns: [bytes4, bytes_external_length, bytes4, uint64]
    // WARNING: Arguments are unknown!
    public unknown IsClanChatAdmin();  // argc: -1, index: 78, ipc args: [uint64, uint64], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown IsClanChatWindowOpenInSteam();  // argc: -1, index: 79, ipc args: [uint64], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown OpenClanChatWindowInSteam();  // argc: -1, index: 80, ipc args: [uint64], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown CloseClanChatWindowInSteam();  // argc: -1, index: 81, ipc args: [uint64], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetListenForFriendsMessages(bool listen);  // argc: -1, index: 82, ipc args: [bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown ReplyToFriendMessage(CSteamID steamid, string msg);  // argc: -1, index: 83, ipc args: [uint64, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown GetFriendMessage();  // argc: -1, index: 84, ipc args: [uint64, bytes4, bytes4], ipc returns: [bytes4, bytes_external_length, bytes4]
    // WARNING: Arguments are unknown!
    public unknown InviteFriendToClan();  // argc: -1, index: 85, ipc args: [uint64, uint64], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown AcknowledgeInviteToClan();  // argc: -1, index: 86, ipc args: [uint64, bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown GetFriendCountFromSource();  // argc: -1, index: 87, ipc args: [uint64], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetFriendFromSourceByIndex();  // argc: -1, index: 88, ipc args: [uint64, bytes4], ipc returns: [uint64]
    // WARNING: Arguments are unknown!
    public unknown IsUserInSource();  // argc: -1, index: 89, ipc args: [uint64, uint64], ipc returns: [boolean]
    public unknown GetCoplayFriendCount();  // argc: -1, index: 90, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetCoplayFriend();  // argc: -1, index: 91, ipc args: [bytes4], ipc returns: [uint64]
    // WARNING: Arguments are unknown!
    public unknown GetFriendCoplayTime();  // argc: -1, index: 92, ipc args: [uint64], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetFriendCoplayGame();  // argc: -1, index: 93, ipc args: [uint64], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public bool SetRichPresence(AppId_t appid, string key, string value);  // argc: -1, index: 94, ipc args: [bytes4, string, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown ClearRichPresence(AppId_t appid);  // argc: -1, index: 95, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public string GetFriendRichPresence(AppId_t appid, CSteamID steamid, string key);  // argc: -1, index: 96, ipc args: [bytes4, uint64, string], ipc returns: [string]
    // WARNING: Arguments are unknown!
    public int GetFriendRichPresenceKeyCount(AppId_t appid, CSteamID steamid);  // argc: -1, index: 97, ipc args: [bytes4, uint64], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public string GetFriendRichPresenceKeyByIndex(AppId_t appid, CSteamID steamid, int index);  // argc: -1, index: 98, ipc args: [bytes4, uint64, bytes4], ipc returns: [string]
    // WARNING: Arguments are unknown!
    public void RequestFriendRichPresence(AppId_t appid, CSteamID steamid);  // argc: -1, index: 99, ipc args: [bytes4, uint64], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown JoinChatRoom(CSteamID steamID);  // argc: -1, index: 100, ipc args: [uint64], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown LeaveChatRoom(CSteamID steamID);  // argc: -1, index: 101, ipc args: [uint64], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown InviteUserToChatRoom(CSteamID steamID,CSteamID steamID2);  // argc: -1, index: 102, ipc args: [uint64, uint64], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public bool SendChatMsg(CSteamID steamIDFriend, EChatEntryType eFriendMsgType, string msg);  // argc: -1, index: 103, ipc args: [uint64, bytes4, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown GetChatRoomMessagesCount(CSteamID steamID);  // argc: -1, index: 104, ipc args: [uint64], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetChatRoomEntry();  // argc: -1, index: 105, ipc args: [uint64, bytes4, bytes4], ipc returns: [bytes4, bytes_external_length, uint64, bytes4]
    // WARNING: Arguments are unknown!
    public unknown ClearChatRoomHistory();  // argc: -1, index: 106, ipc args: [uint64], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SerializeChatRoomDlg();  // argc: -1, index: 107, ipc args: [uint64, bytes4, bytes_external_length], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown GetSizeOfSerializedChatRoomDlg();  // argc: -1, index: 108, ipc args: [uint64], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetSerializedChatRoomDlg();  // argc: -1, index: 109, ipc args: [uint64, bytes4], ipc returns: [bytes1, bytes4, bytes_external_length, bytes4]
    // WARNING: Arguments are unknown!
    public unknown ClearSerializedChatRoomDlg();  // argc: -1, index: 110, ipc args: [uint64], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown KickChatMember();  // argc: -1, index: 111, ipc args: [uint64, uint64], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown BanChatMember();  // argc: -1, index: 112, ipc args: [uint64, uint64], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown UnBanChatMember();  // argc: -1, index: 113, ipc args: [uint64, uint64], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetChatRoomType();  // argc: -1, index: 114, ipc args: [uint64, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown GetChatRoomLockState();  // argc: -1, index: 115, ipc args: [uint64], ipc returns: [bytes1, bytes1]
    // WARNING: Arguments are unknown!
    public unknown GetChatRoomPermissions();  // argc: -1, index: 116, ipc args: [uint64], ipc returns: [bytes1, bytes4]
    // WARNING: Arguments are unknown!
    public unknown SetChatRoomModerated();  // argc: -1, index: 117, ipc args: [uint64, bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown BChatRoomModerated();  // argc: -1, index: 118, ipc args: [uint64], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown NotifyChatRoomDlgsOfUIChange();  // argc: -1, index: 119, ipc args: [uint64, bytes1, bytes1, bytes1, bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown TerminateChatRoom();  // argc: -1, index: 120, ipc args: [uint64], ipc returns: [bytes1]
    public unknown GetChatRoomCount();  // argc: -1, index: 121, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetChatRoomByIndex();  // argc: -1, index: 122, ipc args: [bytes4], ipc returns: [uint64]
    // WARNING: Arguments are unknown!
    public string GetChatRoomName(CSteamID steamidGroup);  // argc: -1, index: 123, ipc args: [uint64], ipc returns: [string]
    // WARNING: Arguments are unknown!
    public unknown BGetChatRoomMemberDetails();  // argc: -1, index: 124, ipc args: [uint64, uint64], ipc returns: [boolean, bytes4, bytes4]
    // WARNING: Arguments are unknown!
    public unknown CreateChatRoom();  // argc: -1, index: 125, ipc args: [bytes4, bytes8, string, bytes4, uint64, uint64, uint64, bytes4, bytes4, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown JoinChatRoomGroup();  // argc: -1, index: 126, ipc args: [bytes8, bytes8, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown ShowChatRoomGroupInvite();  // argc: -1, index: 127, ipc args: [string], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown VoiceCallNew(CSteamID steamIDLocalPeer, CSteamID steamIDRemotePeer);  // argc: -1, index: 128, ipc args: [uint64, uint64], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown VoiceCall(CSteamID steamIDLocalPeer, CSteamID steamIDRemotePeer);  // argc: -1, index: 129, ipc args: [uint64, uint64], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown VoiceHangUp(CSteamID steamIDLocalPeer, int hVoiceCall);  // argc: -1, index: 130, ipc args: [uint64, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetVoiceSpeakerVolume();  // argc: -1, index: 131, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetVoiceMicrophoneVolume();  // argc: -1, index: 132, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetAutoAnswer(bool autoAnswer);  // argc: -1, index: 133, ipc args: [bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown VoiceAnswer(int hVoiceCall);  // argc: -1, index: 134, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown AcceptVoiceCall(CSteamID steamIDLocalPeer, CSteamID steamIDRemotePeer);  // argc: -1, index: 135, ipc args: [uint64, uint64], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown VoicePutOnHold();  // argc: -1, index: 136, ipc args: [bytes4, bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown BVoiceIsLocalOnHold();  // argc: -1, index: 137, ipc args: [bytes4], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown BVoiceIsRemoteOnHold();  // argc: -1, index: 138, ipc args: [bytes4], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown SetDoNotDisturb();  // argc: -1, index: 139, ipc args: [bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown EnableVoiceNotificationSounds(bool enable);  // argc: -1, index: 140, ipc args: [bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetPushToTalkEnabled();  // argc: -1, index: 141, ipc args: [bytes1, bytes1], ipc returns: []
    public unknown IsPushToTalkEnabled();  // argc: -1, index: 142, ipc args: [], ipc returns: [boolean]
    public unknown IsPushToMuteEnabled();  // argc: -1, index: 143, ipc args: [], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown SetPushToTalkKey(int nVirtualKey);  // argc: -1, index: 144, ipc args: [bytes4], ipc returns: []
    public int GetPushToTalkKey();  // argc: -1, index: 145, ipc args: [], ipc returns: [bytes4]
    public bool IsPushToTalkKeyDown();  // argc: -1, index: 146, ipc args: [], ipc returns: [boolean]
    public void EnableVoiceCalibration(bool enable);  // argc: -1, index: 147, ipc args: [bytes1], ipc returns: []
    public bool IsVoiceCalibrating();  // argc: -1, index: 148, ipc args: [], ipc returns: [boolean]
    public unknown GetVoiceCalibrationSamplePeak();  // argc: -1, index: 149, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown SetMicBoost();  // argc: -1, index: 150, ipc args: [bytes1], ipc returns: []
    public unknown GetMicBoost();  // argc: -1, index: 151, ipc args: [], ipc returns: [bytes1]
    public unknown HasHardwareMicBoost();  // argc: -1, index: 152, ipc args: [], ipc returns: [bytes1]
    public string GetMicDeviceName();  // argc: -1, index: 153, ipc args: [], ipc returns: [string]
    // WARNING: Arguments are unknown!
    public unknown StartTalking();  // argc: -1, index: 154, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown EndTalking();  // argc: -1, index: 155, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown VoiceIsValid();  // argc: -1, index: 156, ipc args: [bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetAutoReflectVoice();  // argc: -1, index: 157, ipc args: [bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown GetCallState();  // argc: -1, index: 158, ipc args: [bytes4], ipc returns: [bytes4]
    public unknown GetVoiceMicrophoneVolume();  // argc: -1, index: 159, ipc args: [], ipc returns: [bytes4]
    public unknown GetVoiceSpeakerVolume();  // argc: -1, index: 160, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown TimeSinceLastVoiceDataReceived();  // argc: -1, index: 161, ipc args: [bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown TimeSinceLastVoiceDataSend();  // argc: -1, index: 162, ipc args: [bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown BCanSend();  // argc: -1, index: 163, ipc args: [bytes4], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown BCanReceive();  // argc: -1, index: 164, ipc args: [bytes4], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown GetEstimatedBitsPerSecond();  // argc: -1, index: 165, ipc args: [bytes4, bytes1], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetPeakSample();  // argc: -1, index: 166, ipc args: [bytes4, bytes1], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown SendResumeRequest();  // argc: -1, index: 167, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public void OpenFriendsDialog(bool unk = false, bool unk1 = false);  // argc: -1, index: 168, ipc args: [bytes1, bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public void OpenChatDialog(CSteamID steamIDuser);  // argc: -1, index: 169, ipc args: [uint64], ipc returns: []
    // WARNING: Arguments are unknown!
    public void OpenInviteToTradeDialog(CSteamID steamIDuser);  // argc: -1, index: 170, ipc args: [uint64], ipc returns: []
    // WARNING: Arguments are unknown!
    public void StartChatRoomVoiceSpeaking(CSteamID steamIDchat, CSteamID steamIDuser);  // argc: -1, index: 171, ipc args: [uint64, uint64], ipc returns: []
    // WARNING: Arguments are unknown!
    public void EndChatRoomVoiceSpeaking(CSteamID steamIDchat, CSteamID steamIDuser);  // argc: -1, index: 172, ipc args: [uint64, uint64], ipc returns: []
    // WARNING: Arguments are unknown!
    public RTime32 GetFriendLastLogonTime(CSteamID steamid);  // argc: -1, index: 173, ipc args: [uint64], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public RTime32 GetFriendLastLogoffTime(CSteamID steamid);  // argc: -1, index: 174, ipc args: [uint64], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetChatRoomVoiceTotalSlotCount();  // argc: -1, index: 175, ipc args: [uint64], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetChatRoomVoiceUsedSlotCount();  // argc: -1, index: 176, ipc args: [uint64], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetChatRoomVoiceUsedSlot();  // argc: -1, index: 177, ipc args: [uint64, bytes4], ipc returns: [uint64]
    // WARNING: Arguments are unknown!
    public unknown GetChatRoomVoiceStatus();  // argc: -1, index: 178, ipc args: [uint64, uint64], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown BChatRoomHasAvailableVoiceSlots();  // argc: -1, index: 179, ipc args: [uint64], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown BIsChatRoomVoiceSpeaking();  // argc: -1, index: 180, ipc args: [uint64, uint64], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown GetChatRoomPeakSample();  // argc: -1, index: 181, ipc args: [uint64, uint64, bytes1], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown ChatRoomVoiceRetryConnections();  // argc: -1, index: 182, ipc args: [uint64], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetPortTypes();  // argc: -1, index: 183, ipc args: [bytes4], ipc returns: []
    public void ReinitAudio();  // argc: -1, index: 184, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetInGameVoiceSpeaking();  // argc: -1, index: 185, ipc args: [uint64, bytes1], ipc returns: []
    public unknown IsInGameVoiceSpeaking();  // argc: -1, index: 186, ipc args: [], ipc returns: [boolean]
    public void ActivateGameOverlay(string dialog);  // argc: -1, index: 187, ipc args: [string], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown ActivateGameOverlayToUser(string dialog, CSteamID steamid);  // argc: -1, index: 188, ipc args: [string, uint64], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown ActivateGameOverlayToWebPage();  // argc: -1, index: 189, ipc args: [string, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown ActivateGameOverlayToStore();  // argc: -1, index: 190, ipc args: [bytes4, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown ActivateGameOverlayInviteDialog(CSteamID serverid);  // argc: -1, index: 191, ipc args: [uint64], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown ActivateGameOverlayRemotePlayTogetherInviteDialog();  // argc: -1, index: 192, ipc args: [uint64], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown ActivateGameOverlayInviteDialogConnectString();  // argc: -1, index: 193, ipc args: [string], ipc returns: []
    // WARNING: Arguments are unknown!
    public byte ProcessActivateGameOverlayInMainUI(string unk, CSteamID unk1, uint unk2, bool unk3, uint unk4);  // argc: -1, index: 194, ipc args: [string, uint64, bytes4, bytes1, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public void NotifyGameOverlayStateChanged(uint unk1, uint unk2, bool unk3, bool unk4);  // argc: -1, index: 195, ipc args: [bytes4, bytes4, bytes1, bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown NotifyGameServerChangeRequested();  // argc: -1, index: 196, ipc args: [string, string], ipc returns: []
    // WARNING: Arguments are unknown!
    public bool NotifyLobbyJoinRequested(AppId_t appid, CSteamID steamidFriend, CSteamID steamidLobby);  // argc: -1, index: 197, ipc args: [bytes4, uint64, uint64], ipc returns: [bytes1]
    public bool NotifyRichPresenceJoinRequested(AppId_t appid, CSteamID friendid, string data);  // argc: -1, index: 198, ipc args: [bytes4, uint64, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown GetClanRelationship();  // argc: -1, index: 199, ipc args: [uint64], ipc returns: [bytes4]
    public unknown GetClanInviteCount();  // argc: -1, index: 200, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetFriendClanRank();  // argc: -1, index: 201, ipc args: [uint64, uint64], ipc returns: [bytes4]
    public bool VoiceIsAvailable();  // argc: -1, index: 202, ipc args: [], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown TestVoiceDisconnect();  // argc: -1, index: 203, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown TestChatRoomPeerDisconnect();  // argc: -1, index: 204, ipc args: [uint64, uint64], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown TestVoicePacketLoss();  // argc: -1, index: 205, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown FindFriendVoiceChatHandle(CSteamID steamid);  // argc: -1, index: 206, ipc args: [uint64], ipc returns: [bytes4]
    public void RequestFriendsWhoPlayGame(CGameID gameid);  // argc: -1, index: 207, ipc args: [bytes8], ipc returns: []
    public int GetCountFriendsWhoPlayGame(CGameID gameid);  // argc: -1, index: 208, ipc args: [bytes8], ipc returns: [bytes4]
    public CSteamID GetFriendWhoPlaysGame(int index, CGameID gameid);  // argc: -1, index: 209, ipc args: [bytes4, bytes8], ipc returns: [uint64]
    public int GetCountFriendsInGame(CGameID gameid);  // argc: -1, index: 210, ipc args: [bytes8], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown SetPlayedWith(CSteamID steamid);  // argc: -1, index: 211, ipc args: [uint64], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown RequestClanOfficerList();  // argc: -1, index: 212, ipc args: [uint64], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown GetClanOwner();  // argc: -1, index: 213, ipc args: [uint64], ipc returns: [uint64]
    // WARNING: Arguments are unknown!
    public unknown GetClanOfficerCount();  // argc: -1, index: 214, ipc args: [uint64], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetClanOfficerByIndex();  // argc: -1, index: 215, ipc args: [uint64, bytes4], ipc returns: [uint64]
    // WARNING: Arguments are unknown!
    public SteamAPICall_t RequestFriendProfileInfo(CSteamID steamid);  // argc: -1, index: 216, ipc args: [uint64], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public string GetFriendProfileInfo(CSteamID steamid, string key);  // argc: -1, index: 217, ipc args: [uint64, string], ipc returns: [string]
    // WARNING: Arguments are unknown!
    public bool InviteUserToGame(AppId_t appid, CSteamID friendid, string msg);  // argc: -1, index: 218, ipc args: [bytes4, uint64, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public SteamAPICall_t RequestTrade(CSteamID friendid);  // argc: -1, index: 219, ipc args: [uint64], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown TradeResponse();  // argc: -1, index: 220, ipc args: [bytes4, bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown CancelTradeRequest();  // argc: -1, index: 221, ipc args: [uint64], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown HideFriend();  // argc: -1, index: 222, ipc args: [uint64, bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown GetFollowerCount();  // argc: -1, index: 223, ipc args: [uint64], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown IsFollowing();  // argc: -1, index: 224, ipc args: [uint64], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown EnumerateFollowingList();  // argc: -1, index: 225, ipc args: [bytes4], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown RequestFriendMessageHistory();  // argc: -1, index: 226, ipc args: [uint64], ipc returns: []
    public unknown RequestFriendMessageHistoryForOfflineMessages();  // argc: -1, index: 227, ipc args: [], ipc returns: []
    public unknown GetCountFriendsWithOfflineMessages();  // argc: -1, index: 228, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetFriendWithOfflineMessage();  // argc: -1, index: 229, ipc args: [bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown ClearFriendHasOfflineMessage();  // argc: -1, index: 230, ipc args: [bytes4], ipc returns: []
    public unknown RequestEmoticonList();  // argc: -1, index: 231, ipc args: [], ipc returns: []
    public unknown GetEmoticonCount();  // argc: -1, index: 232, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetEmoticonName();  // argc: -1, index: 233, ipc args: [bytes4], ipc returns: [string]
    public void ClientLinkFilterInit();  // argc: -1, index: 234, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown LinkDisposition();  // argc: -1, index: 235, ipc args: [string], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public string GetFriendPersonaName_Public();  // argc: -1, index: 236, ipc args: [uint64], ipc returns: [string]
    // WARNING: Arguments are unknown!
    public string GetPlayerNickname_Public();  // argc: -1, index: 237, ipc args: [uint64], ipc returns: [string]
    // WARNING: Arguments are unknown!
    public unknown SetFriendsUIActiveClanChatList();  // argc: -1, index: 238, ipc args: [bytes4, bytes_external_length], ipc returns: []
    public unknown GetNumChatsWithUnreadPriorityMessages();  // argc: -1, index: 239, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown SetNumChatsWithUnreadPriorityMessages();  // argc: -1, index: 240, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown RegisterProtocolInOverlayBrowser();  // argc: -1, index: 241, ipc args: [string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown HandleProtocolForOverlayBrowser();  // argc: -1, index: 242, ipc args: [bytes4, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown RequestEquippedProfileItems();  // argc: -1, index: 243, ipc args: [uint64], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown BHasEquippedProfileItem();  // argc: -1, index: 244, ipc args: [uint64, bytes4], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown GetProfileItemPropertyString();  // argc: -1, index: 245, ipc args: [uint64, bytes4, bytes4], ipc returns: [string]
    // WARNING: Arguments are unknown!
    public unknown GetProfileItemPropertyUint();  // argc: -1, index: 246, ipc args: [uint64, bytes4, bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown DownloadCommunityItemAsset();  // argc: -1, index: 247, ipc args: [bytes8, string, string], ipc returns: [bytes8]
    public string GetMultiplayerSessionShareURL(AppId_t appid);  // argc: -1, index: 248, ipc args: [bytes4, bytes1], ipc returns: [string]
}