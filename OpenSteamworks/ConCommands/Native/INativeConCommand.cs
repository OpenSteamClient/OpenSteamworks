using System;
using CppSourceGen.Attributes;
using OpenSteamworks.Data;
using OpenSteamworks.Data.Interop;

namespace OpenSteamworks.ConCommands.Native;

[CppClass]
public interface INativeConCommand : INativeConCommandBase
{
    public int RunCompletion(in CCommand args, ref CUtlStringList commandsOut);
    public void SetCompletionCallback(IntPtr pCompletionCallback);
    public bool BHasCompletionCallback();
    public void Invoke(in CCommand args);
}