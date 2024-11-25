using OpenSteamClient.Logging;
using OpenSteamworks.Data;
using System;
using System.Diagnostics.CodeAnalysis;

namespace OpenSteamworks;

/// <summary>
/// Contains static logging for OpenSteamworks and its dependencies.
/// For per-instance logging, see <see cref="BaseSteamClientCreateOptions"/>.
/// </summary>
public static class Logging {
	[MemberNotNull(nameof(GeneralLogger))]
	[MemberNotNull(nameof(LoggerFactory))]
	public static void SetFromLoggerFactory(ILoggerFactory factory)
	{
		LoggerFactory = factory;
		GeneralLogger = factory.CreateLogger("General");
		UtlLogging.SetLoggerFactory(factory);
	}

	static Logging()
	{
		SetFromLoggerFactory(new ConsoleLoggerFactory());
	}

    internal static ILogger GeneralLogger { get; private set; }
    internal static ILoggerFactory LoggerFactory { get; private set; }
}