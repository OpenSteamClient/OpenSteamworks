using System;

namespace OpenSteamworks.Callbacks;

public interface ICallbackHandler : IDisposable {
	public int CallbackID { get; }
	internal void Invoke(byte[] callbackData);
}