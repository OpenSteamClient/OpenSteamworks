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
public unsafe interface IClientGameStats
{
    // WARNING: Arguments are unknown!
    public unknown GetNewSession();  // argc: -1, index: 1, ipc args: [bytes1, bytes8, bytes4, bytes4], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown EndSession();  // argc: -1, index: 2, ipc args: [bytes8, bytes4, bytes2], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown AddSessionAttributeInt();  // argc: -1, index: 3, ipc args: [bytes8, string, bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown AddSessionAttributeString();  // argc: -1, index: 4, ipc args: [bytes8, string, string], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown AddSessionAttributeFloat();  // argc: -1, index: 5, ipc args: [bytes8, string, bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown AddNewRow();  // argc: -1, index: 6, ipc args: [bytes8, string], ipc returns: [bytes4, bytes8]
    // WARNING: Arguments are unknown!
    public unknown CommitRow();  // argc: -1, index: 7, ipc args: [bytes8], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown CommitOutstandingRows();  // argc: -1, index: 8, ipc args: [bytes8], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown AddRowAttributeInt();  // argc: -1, index: 9, ipc args: [bytes8, string, bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown AddRowAttributeString();  // argc: -1, index: 10, ipc args: [bytes8, string, string], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown AddRowAttributeFloat();  // argc: -1, index: 11, ipc args: [bytes8, string, bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown AddSessionAttributeInt64();  // argc: -1, index: 12, ipc args: [bytes8, string, bytes8], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown AddRowAttributeInt64();  // argc: -1, index: 13, ipc args: [bytes8, string, bytes8], ipc returns: [bytes4]
}