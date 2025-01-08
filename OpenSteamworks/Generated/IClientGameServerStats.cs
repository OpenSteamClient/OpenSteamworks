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
public unsafe interface IClientGameServerStats
{
    // WARNING: Arguments are unknown!
    public unknown RequestUserStats();  // argc: 3, index: 1, ipc args: [uint64, bytes8], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown GetUserStat(bool unk1);  // argc: 5, index: 2, ipc args: [uint64, bytes8, string], ipc returns: [bytes1, bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetUserStat(double unk1, bool unk2);  // argc: 5, index: 3, ipc args: [uint64, bytes8, string], ipc returns: [bytes1, bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetUserAchievement();  // argc: 6, index: 4, ipc args: [uint64, bytes8, string], ipc returns: [bytes1, bytes1, bytes4]
    // WARNING: Arguments are unknown!
    public unknown SetUserStat(bool unk1);  // argc: 5, index: 5, ipc args: [uint64, bytes8, string, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetUserStat(double unk1, bool unk2);  // argc: 5, index: 6, ipc args: [uint64, bytes8, string, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown UpdateUserAvgRateStat();  // argc: 6, index: 7, ipc args: [uint64, bytes8, string, bytes4, bytes8], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetUserAchievement();  // argc: 4, index: 8, ipc args: [uint64, bytes8, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown ClearUserAchievement();  // argc: 4, index: 9, ipc args: [uint64, bytes8, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown StoreUserStats();  // argc: 3, index: 10, ipc args: [uint64, bytes8], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown SetMaxStatsLoaded();  // argc: 1, index: 11, ipc args: [bytes4], ipc returns: []
}