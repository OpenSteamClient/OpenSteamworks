using CppSourceGen.Attributes;
using OpenSteamworks.ConCommands.Native;


namespace OpenSteamworks.ConCommands.Native;

[CppClass]
public interface INativeConCommandBaseAccessor
{
    public bool RegisterConCommandBase(INativeConCommandBase commandBase);
}