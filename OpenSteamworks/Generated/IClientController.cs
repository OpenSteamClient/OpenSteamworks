//==========================  AUTO-GENERATED FILE  ================================
//
// This file is partially auto-generated.
// If functions are removed, your changes to that function will be lost.
// Parameter types and names however are preserved if the function stays unchanged.
// Feel free to change parameters to be more accurate. 
//=============================================================================

using System;
using OpenSteamworks.Attributes;
using CppSourceGen.Attributes;
using OpenSteamworks.Data;

namespace OpenSteamworks.Generated;

// This interface doesn't get dumped. What does it contain?
[CppClass]
public unsafe interface IClientController
{
    public unknown Unknown_0_DONTUSE();
    // The second destructor only exists on Linux (and maybe macos?)
#if !_WINDOWS
    public unknown Unknown_1_DONTUSE();
#endif
    public bool Init(bool bHostProcess, IClientControllerSerialized? serialized, uint unk, bool bUnk);
    public unknown Shutdown();
    public void RunFrame(bool bFromSteamAPI = false);
}