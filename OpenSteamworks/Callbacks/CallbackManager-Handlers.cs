using System;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSteamworks.Callbacks;

public partial class CallbackManager {
	private readonly ConcurrentDictionary<ICallbackHandler, int> callbackHandlers = new();

	private abstract class CallbackHandlerBase : ICallbackHandler
	{
		public int CallbackID { get; }
		private readonly CallbackManager mgr;

		public void Dispose()
			=> mgr.DisposeHandler(this);

		public CallbackHandlerBase(CallbackManager mgr, int callbackID) {
			this.mgr = mgr;
			this.CallbackID = callbackID;
		}

		public abstract void Invoke(byte[] callbackData);
	}

	private class TypedCallbackHandler<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T> : CallbackHandlerBase where T : struct
	{
		public int Size { get; }

		private readonly Action<ICallbackHandler, T> handler;
		public unsafe override void Invoke(byte[] callbackData)
		{
			CallbackSizeException.ThrowOrWarn(callbackData.Length, Size, typeof(T).Name);

			T inst;
			fixed (byte* ptr = callbackData) {
				inst = Marshal.PtrToStructure<T>((nint)ptr);
			}

			handler.Invoke(this, inst);
		}

		public TypedCallbackHandler(CallbackManager mgr, int callbackID, Action<ICallbackHandler, T> handler) : base(mgr, callbackID) {
			this.Size = Marshal.SizeOf<T>();
			this.handler = handler;
		}
	}

	private class ByteCallbackHandler : CallbackHandlerBase
	{		
		private readonly Action<ICallbackHandler, byte[]> handler;
		public override void Invoke(byte[] callbackData)
		{
			handler.Invoke(this, callbackData);
		}

		public ByteCallbackHandler(CallbackManager mgr, int callbackID, Action<ICallbackHandler, byte[]> handler) : base(mgr, callbackID) {
			this.handler = handler;
		}
	}

		public ICallbackHandler Register(int callbackID, Action<ICallbackHandler, byte[]> func) {
		var handler = new ByteCallbackHandler(this, callbackID, func);
		callbackHandlers[handler] = callbackID;
		return handler;
	}

	public ICallbackHandler Register<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>(Action<ICallbackHandler, T> func) where T: struct {
		var callbackID = CallbackMetadata.GetIDFromType<T>();
		var handler = new TypedCallbackHandler<T>(this, callbackID, func);
		callbackHandlers[handler] = callbackID;
		return handler;
	}

	/// <summary>
	/// Dispose the given handler. It will no longer receive callbacks.
	/// </summary>
	public bool DisposeHandler(ICallbackHandler handler) {
		return callbackHandlers.TryRemove(handler, out _);
	}

	/// <summary>
	/// Invoke all callback handlers 
	/// </summary>
	/// <param name="callbackID"></param>
	/// <param name="data"></param>
	private void InvokeAllHandlers(int callbackID, byte[] data) {
		foreach (var item in callbackHandlers.ToList().Where(e => e.Value == callbackID))
		{
			item.Key.Invoke(data);
		}
	}
}