using System;
using OpenSteamworks.Data;
using OpenSteamworks.Data.Enums;
using System.Collections.Generic;

namespace OpenSteamworks.ConCommands;

public struct CCommand
{
    private CUtlString m_fullCommand;
    private CUtlVector<CUtlString> m_args;

    private CCommand(List<string> args)
    {
        this.m_fullCommand = new(args[0]);

        for (int i = 1; i < args.Count; i++)
        {
            m_args.Add(new(args[i]));
        }
    }
    
    public static CCommand Tokenize(out string commandName)
    {
        throw new NotImplementedException();
    }
}