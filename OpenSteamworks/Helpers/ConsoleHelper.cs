using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using CppSourceGen;
using CppSourceGen.Attributes;
using CppSourceGen.Utils;
using OpenSteamClient.Logging;
using OpenSteamworks.Callbacks.Structs;
using OpenSteamworks.ConCommands;
using OpenSteamworks.ConCommands.Interfaces;
using OpenSteamworks.ConCommands.Native;

namespace OpenSteamworks.Helpers;

[CppClassImpl]
internal partial class CConCommandAccessor : INativeConCommandBaseAccessor
{
    private readonly Func<INativeConCommandBase, bool> handler;
    public CConCommandAccessor(Func<INativeConCommandBase, bool> handler)
    {
        this.handler = handler;
    }

    public bool RegisterConCommandBase(INativeConCommandBase commandBase)
    {
        return handler(commandBase);
    }
}

public sealed class ConsoleHelper : IDisposable
{
    private readonly CConCommandAccessor? nativeAccessor;
    private readonly ILogger logger;
    private readonly ISteamClient steamClient;
    public ConsoleHelper(ISteamClient steamClient, ILoggerFactory loggerFactory)
    {
        this.logger = loggerFactory.CreateLogger("ConsoleHelper");
        this.steamClient = steamClient;

        RegisterCommand(new LaunchAppCommand(steamClient, logger));
        RegisterCommand(new DownloadDepotCommand(steamClient, logger));
        RegisterCommand(new DownloadItemCommand(steamClient, logger));
        RegisterCommand(new InstallAppCommand(steamClient, logger));

        // Only register native concommands if we're the host.
        if (steamClient.IsCrossProcess)
            return;

        this.nativeAccessor = new CConCommandAccessor(OnConCommandRegistered);
        steamClient.IClientEngine.ConCommandInit(nativeAccessor);
    }

    private readonly object commandsLock = new();
    private readonly Dictionary<string, IConCommandBase> registeredCommands = new();
    public bool RegisterCommand(IConCommandBase conCommandBase)
    {
        lock (commandsLock)
        {
            if (registeredCommands.TryAdd(conCommandBase.Name, conCommandBase))
                return true;
        }

        logger.Warning($"Attempted to register duplicate command '{conCommandBase.Name}'");
        return false;
    }

    private bool OnConCommandRegistered(INativeConCommandBase arg)
        => RegisterCommand(NativeConCommandBaseWrapper.CreateFromNative(arg));

    public IReadOnlyDictionary<string, IConCommandBase> GetRegisteredCommands()
    {
        lock (commandsLock)
        {
            return registeredCommands.ToImmutableDictionary();
        }
    }

    /// <summary>
    /// Run a command by inputting a text string, for example "download_depot 730 731".
    /// This function is currently not implemented.
    /// </summary>
    /// <param name="commandText"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void ExecuteCommand(string commandText) // Implementation details: Should split by space, unless there's a " character.
        => throw new NotImplementedException("Command tokenization not implemented.");

    /// <summary>
    /// Run a command by inputting separate parts of a command, for example ["download_depot", "730", "731"]
    /// </summary>
    /// <param name="commandArgs"></param>
    public void ExecuteCommand(IEnumerable<string> commandArgs)
    {
        var enumerable = commandArgs.ToList();

        IConCommandBase? commandBase;
        lock (commandsLock)
        {
            if (!registeredCommands.TryGetValue(enumerable[0], out commandBase))
            {
                logger.Error($">>> Command '{enumerable[0]}' not found.");
                return;
            }
        }

        if (commandBase.IsCommand)
        {
            if (commandBase is not IConCommand command)
            {
                logger.Error($">>> Command '{enumerable[0]}' IsCommand=True, but not an IConCommand.");
                return;
            }

            using var cmdArgs = new CCommand(enumerable);
            command.Invoke(cmdArgs);
        }
        else
        {
            if (commandBase is not IConVar conVar)
            {
                logger.Error($">>> ConVar '{enumerable[0]}' IsCommand=False, but not an IConVar.");
                return;
            }

            if (enumerable.Count > 1)
            {
                if (enumerable.Count > 2)
                    logger.Warning(">>> ConVar set operation has more than 1 argument. Ignoring.");

                conVar.StringValue = enumerable[1];
            }

            logger.Info($"\"{enumerable[0]}\" = \"{conVar.StringValue}\"");
        }
    }

    public void Dispose()
    {
        nativeAccessor?.Dispose();
    }
}
