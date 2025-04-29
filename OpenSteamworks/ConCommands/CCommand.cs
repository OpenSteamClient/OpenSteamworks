using System;
using OpenSteamworks.Data;
using OpenSteamworks.Data.Enums;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using OpenSteamworks.Data.Interop;

namespace OpenSteamworks.ConCommands;

public struct CCommand : IDisposable
{
    private CUtlString m_commandName;
    private CUtlStringList m_args;

    public CCommand(List<string> args)
    {
        this.m_commandName = new(args[0]);
        m_args = new(args.Slice(1, args.Count - 1));
    }

    public readonly string CommandName => m_commandName.ToManaged() ?? "";
    public readonly int NumArgs => m_args.Size;

    public readonly string this[int idx]
        => m_args.Element(idx).ToManaged() ?? "";

    public void Dispose()
    {
        m_commandName.Dispose();
        m_args.Dispose();
    }

    public readonly bool TryGetArg(int argIndex, [NotNullWhen(true)] out string? arg)
    {
        if (argIndex >= NumArgs)
        {
            arg = null;
            return false;
        }

        arg = this[argIndex];
        return true;
    }

    public readonly bool TryGetArg<T>(int argIndex, [NotNullWhen(true)] out T? arg) where T: IParsable<T>
    {
        if (!TryGetArg(argIndex, out var strArg))
        {
            arg = default;
            return false;
        }

        return T.TryParse(strArg, null, out arg);
    }
    
    public readonly bool TryGetArgEnum<TEnum>(int argIndex, out TEnum arg) where TEnum: struct
    {
        if (!TryGetArg(argIndex, out var strArg))
        {
            arg = default;
            return false;
        }

        return Enum.TryParse(strArg, true, out arg);
    }
}