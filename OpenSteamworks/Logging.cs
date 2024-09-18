using OpenSteamClient.Logging;
using OpenSteamworks.Data;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("OpenSteamworks.Messaging")]
[assembly: InternalsVisibleTo("OpenSteamworks.IPC")]
[assembly: InternalsVisibleTo("OpenSteamworks.ConCommands")]

namespace OpenSteamworks;

internal static class Logging {
	[MemberNotNull(nameof(GeneralLogger))]
	[MemberNotNull(nameof(NativeClientLogger))]
	[MemberNotNull(nameof(IPCLogger))]
	[MemberNotNull(nameof(LoggerFactory))]
	[MemberNotNull(nameof(ConCommandsLogger))]
	public static void SetFromLoggerFactory(ILoggerFactory factory)
	{
		string dllSuffix = ".so";
		if (OperatingSystem.IsWindows())
		{
			dllSuffix = ".dll";
		} else if (OperatingSystem.IsMacOS())
		{
			dllSuffix = ".dylib";
		}

		LoggerFactory = factory;
		GeneralLogger = factory.CreateLogger("General");
		NativeClientLogger = factory.CreateLogger($"steamclient{dllSuffix}");
		ConCommandsLogger = factory.CreateLogger("ConCommands");
		IPCLogger = factory.CreateLogger("IPC");
		UtlLogging.SetLoggerFactory(factory);
	}

	static Logging()
	{
		SetFromLoggerFactory(new ConsoleLoggerFactory());
	}

    public static ILogger GeneralLogger { get; set; }
    /// <summary>
    /// The logger used explicitly for messages coming straight from the underlying steamclient library.
    /// Or in the case of IPCClient, messages from IPCClient
    /// </summary>
    public static ILogger NativeClientLogger { get; set; }
    /// <summary>
    /// Logs all IPC activity from IPCClient
    /// </summary>
    public static ILogger IPCLogger { get; set; }
    public static ILogger ConCommandsLogger { get; set; }

	public static ILoggerFactory LoggerFactory { get; set; }

	public static bool LogIncomingCallbacks { get; set; } = false;
	public static bool LogCallbackContents { get; set; } = false;
}