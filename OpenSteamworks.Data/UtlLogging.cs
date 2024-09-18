using System.Diagnostics.CodeAnalysis;
using OpenSteamClient.Logging;

namespace OpenSteamworks.Data;

public static class UtlLogging
{
	static UtlLogging() {
		SetLoggerFactory(new ConsoleLoggerFactory());
	}

	[MemberNotNull(nameof(UtlBuffer))]
	[MemberNotNull(nameof(UtlMemory))]
	[MemberNotNull(nameof(UtlMap))]
	public static void SetLoggerFactory(ILoggerFactory factory) 
	{
		UtlBuffer = factory.CreateLogger("CUtlBuffer");
		UtlMemory = factory.CreateLogger("CUtlMemory");
		UtlMap = factory.CreateLogger("CUtlMap");
	}

	internal static ILogger UtlBuffer;
	internal static ILogger UtlMemory;
	internal static ILogger UtlMap;
}