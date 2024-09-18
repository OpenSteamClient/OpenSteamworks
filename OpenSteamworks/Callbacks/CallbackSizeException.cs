using System;
using OpenSteamClient.Logging;

namespace OpenSteamworks.Callbacks;

/// <summary>
/// Represents errors in cases where a callback's input data is too small to be used. Also shows warnings when a callback is unexpectedly large.
/// </summary>
[Serializable]
public class CallbackSizeException : Exception
{
	public CallbackSizeException() { }
	public CallbackSizeException(string message) : base(message) { }
	public CallbackSizeException(string message, Exception inner) : base(message, inner) { }

	public static void ThrowOrWarn(int dataSize, int structSize, string debugName) {
		if (dataSize < structSize) {
			throw new CallbackSizeException($"Size of callback data is too small. Got only {dataSize}, but expected {structSize}. Callback {debugName} is broken!");
		} else if (dataSize > structSize) {
			Logging.GeneralLogger.Warning($"Size of callback data is bigger than expected. Got {dataSize}, but expected only {structSize}. Callback {debugName} needs to be updated!");
		}
	}
}