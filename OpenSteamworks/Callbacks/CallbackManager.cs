using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using OpenSteamClient.Logging;
using OpenSteamworks.Data.Structs;

namespace OpenSteamworks.Callbacks;

public sealed partial class CallbackManager : IDisposable {
	private readonly ISteamClient steamClient;
	private readonly ILogger callbackLogger;
	private readonly ILogger callbackContentLogger;
	private readonly ILogger logger;

	private volatile bool shouldThreadRun = true;
	private readonly Thread callbackThread;

	public int CallbackThreadID => callbackThread.ManagedThreadId;

	internal CallbackManager(ISteamClient steamClient, ILoggerFactory loggerFactory) {
		this.steamClient = steamClient;
		this.logger = loggerFactory.CreateLogger("CallbackManager");
		this.callbackLogger = loggerFactory.CreateLogger("Callbacks");
		this.callbackContentLogger = loggerFactory.CreateLogger("CallbackContent");

		callbackThread = new(this.CallbackThreadMain)
        {
            Name = "CallbackThread"
        };
	}

	internal void Start()
		=> callbackThread.Start();

	private bool isDisposing = false;

	public void Dispose() {
		isDisposing = true;
		shouldThreadRun = false;
		try
		{
			// Try to release all the semaphore holders.
			while (threadsPausedSemaphore.CurrentCount < MAX_PAUSE_LOCKS) {
				threadsPausedSemaphore.Release();
			}
		}
		catch (Exception) { } // It might throw errors but we don't really care

		// Wake it from pause state
		pauseTcs = null;
		lock (pauseLock)
		{
			Monitor.Pulse(pauseLock);
		}

		while (!shouldThreadRun) { Thread.Sleep(1); } // Wait for the thread to finish.
	}

	// How many locks the threadsPausedSemaphore will accept at once.
	private const int MAX_PAUSE_LOCKS = 10;

	// Make sure multiple threads calling don't collide and resume the thread by refcounting.
	private readonly SemaphoreSlim threadsPausedSemaphore = new(MAX_PAUSE_LOCKS, MAX_PAUSE_LOCKS);

	// CPU-light pause system with Monitor.Wait and Monitor.Pulse.
	private readonly object pauseLock = new();

	// Signal when the loop has stopped.
	private TaskCompletionSource? pauseTcs;

	/// <summary>
	/// Pauses the callback thread, and waits for it to become paused before returning. Call ResumeThread to continue.
	/// </summary>
	private async Task PauseThreadAsync() {
		try
		{
			await threadsPausedSemaphore.WaitAsync();

			if (pauseTcs == null) {
				pauseTcs = new();
			}

			await pauseTcs.Task;
		}
		catch (Exception)
		{
			// Don't throw errors when we're disposing.
			if (!isDisposing) throw;
		}
	}

	/// <summary>
	/// Release one count of thread pausing. Does not guarantee the thread will be unpaused immediately after.
	/// Does not wait for the thread to begin re-executing.
	/// </summary>
	private void ResumeThread() {
		try
		{
			if (threadsPausedSemaphore.Release() == (MAX_PAUSE_LOCKS - 1)) {
				// If there's no locks left, continue with the loop
				pauseTcs = null;
				lock (pauseLock)
				{
					Monitor.Pulse(pauseLock);
				}
			}

			// Otherwise, do nothing.
		}
		catch (Exception)
		{
			// Don't throw errors when we're disposing.
			if (!isDisposing) throw;
		}
	}

	private void CallbackThreadMain() 
	{
		void LogCallback(CallbackMsg_t callbackMsg) 
		{
			CallbackNameMap.CallbackNames.TryGetValue(callbackMsg.callbackID, out string? callbackName);
			callbackLogger.Debug($"Received callback [ID: {callbackMsg.callbackID}, name: {callbackName ?? "Unknown"}, param length: {callbackMsg.callbackData.Length}, data: {string.Join(" ", callbackMsg.callbackData)}]");
		
			string callbackString = CallbackMetadata.CallbackToString(callbackMsg.callbackID, callbackMsg.callbackData);
			if (!string.IsNullOrEmpty(callbackString)) 
			{
				callbackContentLogger.Debug(callbackString);
			}
			else 
			{
				callbackContentLogger.Debug("(no information available)");
			}
		}

		bool BRunFrame()
		{
			steamClient.IClientEngine.RunFrame();

			// Process callbacks
			bool hadCallbacks = false;
			while (BProcessCallback())
			{
				hadCallbacks = true;
				if (!shouldThreadRun) { return false; }
			}

			lock (frameTasksLock)
			{
				foreach (var item in frameTasks)
				{
					item.Invoke();
				}
			}

			return hadCallbacks;
		}

		// Tries to get and process a callback.
		// If there's no callbacks, does nothing.
		bool BProcessCallback() 
		{
			var hadCallback = steamClient.BGetCallback(out CallbackMsg_t callbackMsg);
			if (hadCallback) 
			{
				// If we have a callback, process it.
				LogCallback(callbackMsg);
				InvokeAllHandlers(callbackMsg.callbackID, callbackMsg.callbackData);
				steamClient.FreeLastCallback();
			}

			return hadCallback;
		}

		breakLoop:
		while (shouldThreadRun)
		{			
			// If the loop is requested to stop, stop it
			if (pauseTcs is not null) {

				// Signal it's stoppage
				pauseTcs.SetResult();

				lock (pauseLock)
				{
					// And wait until it needs to run again.
					Monitor.Wait(pauseLock);
				}
			}

			// Eco-friendly mode: Wait until callbacks are available to not stress the CPU.
			while (!BRunFrame())
			{
				if (!shouldThreadRun) { goto breakLoop; }

				Thread.Sleep(15); // Roughly 66FPS. Should keep chrome stuff responsive enough. 
			}

			// Run a frame.
			// - Process all the callbacks we get during that frame, and start the next frame.
			
			// Process all the callbacks of the current frame with 0 delay
			while (BRunFrame()) { 
				if (!shouldThreadRun) { goto breakLoop; }
			}
		}

		shouldThreadRun = true;
	}

	private readonly object frameTasksLock = new();
	private readonly List<Action> frameTasks = new();

	/// <summary>
	/// Runs the specified action after each frame.
	/// </summary>
	public void AddFrameTask(Action action)
	{
		lock (frameTasksLock)
		{
			frameTasks.Add(action);
		}
	}

	/// <summary>
	/// Stops the specified action being called each frame.
	/// </summary>
	public void RemoveFrameTask(Action action)
	{
		lock (frameTasksLock)
		{
			frameTasks.Remove(action);
		}
	}

	/// <summary>
	/// Runs the specified action after the next frame a single time.
	/// </summary>
	public void InvokeNextFrame(Action action)
	{
		// First define a no-op action
		Action wrap = () => { };

		// Then set the actual value
		wrap = () => {
			action();

			// So that 'wrap' is valid here
			RemoveFrameTask(wrap);	
		};

		AddFrameTask(wrap);
	}
	
	public Task<T> WaitAsync<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>(CancellationToken cancellationToken = default) where T: struct {
		TaskCompletionSource<T> taskCompletionSource = new();
		object lockObj = new();

		var handler = Register((ICallbackHandler handler, T cb) =>
		{
			lock (lockObj)
			{
				try
				{
					taskCompletionSource.SetResult(cb);
				}
				catch (System.Exception)
				{
					// Don't care if the result has already been set.
				}

				handler.Dispose();
			}
		});

		cancellationToken.Register(() => {
			lock (lockObj)
			{
				if (taskCompletionSource.Task.IsCompleted) {
					return;
				}
				
				handler.Dispose();
				taskCompletionSource.SetCanceled(cancellationToken);
			}
		});

		return taskCompletionSource.Task;
	}

	public Task<T> WaitAsync<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>(Func<T, bool> checkFunction, CancellationToken cancellationToken = default) where T: struct {
		TaskCompletionSource<T> taskCompletionSource = new();
		object lockObj = new();

		var handler = Register((ICallbackHandler handler, T cb) =>
		{
			if (!checkFunction.Invoke(cb)) {
				// Not the right one, keep waiting.
				return;
			}

			lock (lockObj)
			{
				try
				{
					taskCompletionSource.SetResult(cb);
				}
				catch (System.Exception)
				{
					// Don't care if the result has already been set.
				}

				handler.Dispose();
			}
		});

		cancellationToken.Register(() => {
			lock (lockObj)
			{
				if (taskCompletionSource.Task.IsCompleted) {
					return;
				}
				
				handler.Dispose();
				taskCompletionSource.SetCanceled(cancellationToken);
			}
		});

		return taskCompletionSource.Task;
	}
}