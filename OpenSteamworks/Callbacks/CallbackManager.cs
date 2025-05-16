using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using OpenSteamClient.Logging;
using OpenSteamworks.Data.Structs;
using OpenSteamworks.Generated;
using OpenSteamworks.Utils;

namespace OpenSteamworks.Callbacks;

public sealed partial class CallbackManager : IDisposable {
	private readonly ISteamClientImpl steamClient;
	private readonly IClientUtils clientUtils;
	private readonly IClientController clientController;

	private readonly ILogger callbackLogger;
	private readonly ILogger callbackContentLogger;

	private volatile bool shouldThreadRun = true;
	private readonly Thread? callbackThread;

	private readonly bool logCallbackContents;
	private readonly bool logIncomingCallbacks;

	/// <summary>
	/// How much time has passed between the current and the last frame.
	/// </summary>
	public double DeltaTime
		=> timeBetweenFrames.Elapsed.TotalSeconds;

	public bool IsManualPump { get; }

	internal CallbackManager(ISteamClientImpl steamClientImpl, ISteamClient steamClient, ILoggerFactory loggerFactory, bool logIncomingCallbacks, bool logCallbackContents, bool isManualPump)
	{
		this.IsManualPump = isManualPump;
		this.steamClient = steamClientImpl;
		this.clientUtils = steamClient.IClientUtils;
		this.clientController = steamClient.IClientController;

		this.callbackLogger = loggerFactory.CreateLogger("Callbacks");
		this.callbackContentLogger = loggerFactory.CreateLogger("CallbackContent");

		this.logIncomingCallbacks = logIncomingCallbacks;
		this.logCallbackContents = logCallbackContents;

		if (!isManualPump)
		{
			callbackLogger.Info("CallbackThread in automatic mode!");
			callbackThread = new(CallbackThreadMain)
			{
				Name = "CallbackThread",
                IsBackground = true
			};
		}
		else
		{
			callbackLogger.Info("CallbackThread in manual mode! Remember to pump it manually.");
		}
	}

	internal void Start()
		=> callbackThread?.Start();

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
		catch (Exception)
		{
			// It might throw errors but we don't really care
		}

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
    //TODO: This could be refactored to use RefCount
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
	private void LogCallback(CallbackMsg_t callbackMsg)
    {
        // Don't log this callback, it is extremely spewy
        if (callbackMsg.CallbackID == CallbackMetadata.HTML_NeedsPaint_t_ID)
            return;

		if (!logIncomingCallbacks)
		{
			return;
		}

		if (!logCallbackContents)
		{
			callbackLogger.Debug($"Received callback [ID: {callbackMsg.CallbackID}, param length: {callbackMsg.CallbackData.Length}");
			return;
		}

		// Data copy happens here
		byte[] copied = callbackMsg.CallbackData.ToArray();

		callbackLogger.Debug($"Received callback [ID: {callbackMsg.CallbackID}, param length: {copied.Length}, data: {string.Join(" ", copied)}]");

		string callbackString = CallbackMetadata.CallbackToString(callbackMsg.CallbackID, copied);
		if (!string.IsNullOrEmpty(callbackString))
		{
			callbackContentLogger.Debug(callbackString);
		}
		else
		{
			callbackContentLogger.Debug("(no information available)");
		}
	}

	private Stopwatch timeBetweenFrames = new();
	private bool BRunFrame()
	{
		timeBetweenFrames.Stop();
		void StopAndReportDeltaTime()
		{
			timeBetweenFrames.Reset();
			timeBetweenFrames.Start();
		}

		steamClient.IClientEngine.RunFrame();
		clientController.RunFrame();

		// Process callbacks
		bool hadCallbacks = false;
		while (BProcessCallback())
		{
			hadCallbacks = true;
			if (!shouldThreadRun) { StopAndReportDeltaTime(); return false; }
		}

		using (new UsingSemaphore(frameTasksSem))
		{
			isFrameTasksLocked = true;

			foreach (var item in frameTasks)
			{
				item.Invoke();
			}

			foreach (var item in oneShotFrameTasks)
			{
				item.Invoke();
			}

			isFrameTasksLocked = false;
		}

		StopAndReportDeltaTime();
		return hadCallbacks;
	}

	// Tries to get and process a callback.
	// If there's no callbacks, does nothing.
	private bool BProcessCallback()
	{
		var hadCallback = steamClient.BGetCallback(out CallbackMsg_t callbackMsg);
		if (hadCallback)
		{
			// If we have a callback, process it.
			LogCallback(callbackMsg);
			InvokeAllHandlers(callbackMsg.CallbackID, callbackMsg.CallbackData);
			steamClient.FreeLastCallback();
		}

		return hadCallback;
	}

	/// <summary>
	/// Pumps the CallbackManager manually. This function may pause for an undefined amount of time.
	/// </summary>
	/// <exception cref="InvalidOperationException">If CallbackManager is being manually pumped.</exception>
	public void Pump()
	{
		if (!IsManualPump)
			throw new InvalidOperationException("Cannot pump CallbackManager, automatic mode is enabled.");

		if (!shouldThreadRun)
			return;

		// If the loop is requested to stop, freeze here in the pump function
		if (pauseTcs is not null) {

			// Signal we're stopped
			pauseTcs.SetResult();

			lock (pauseLock)
			{
				// And wait until we need to run again.
				Monitor.Wait(pauseLock);
			}
		}

		while (BRunFrame())
		{
			// Run all callbacks on a pump.
			if (!shouldThreadRun) { return; }
		}
	}

	private void CallbackThreadMain()
	{
		breakLoop:
		while (shouldThreadRun)
		{
			// If the loop is requested to stop, stop it
			if (pauseTcs is not null) {

				// Signal its stoppage
				pauseTcs.SetResult();

				lock (pauseLock)
				{
					// And wait until it needs to run again.
					Monitor.Wait(pauseLock);
				}
			}

			// Eco-friendliness: Wait until callbacks are available to not stress the CPU.
			while (!BRunFrame())
			{
				if (!shouldThreadRun) { goto breakLoop; }

				Thread.Sleep(15); // Roughly 66 "FPS". Should keep chrome stuff responsive enough.
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

	private volatile bool isFrameTasksLocked = false;

	private readonly SemaphoreSlim frameTasksSem = new(1, 1);
	private readonly List<Action> frameTasks = new();
	private readonly List<Action> oneShotFrameTasks = new();

	private sealed class FrameTaskDisposable : IDisposable
	{
		private readonly Action? action;
		private readonly CallbackManager callbackManager;

		public FrameTaskDisposable(CallbackManager callbackManager, Action? action)
		{
			this.action = action;
			this.callbackManager = callbackManager;
		}

		public void Dispose()
		{
			if (action != null)
				callbackManager.RemoveFrameTask(action);
		}
	}

	/// <summary>
	/// Runs the specified action after each frame, or once on the next frame if oneShot is specified.
	/// Returns a disposable you can dispose to remove the frame task. Only works for persistent tasks.
	/// </summary>
	public IDisposable AddFrameTask(Action action, bool oneShot = false)
	{
		using (new UsingSemaphore(frameTasksSem))
		{
			if (isFrameTasksLocked)
				throw new InvalidOperationException("Attempted to modify frame tasks list from frame task!");

			if (oneShot)
			{
				oneShotFrameTasks.Add(action);
				return new FrameTaskDisposable(this, null);
			}

			frameTasks.Add(action);
			return new FrameTaskDisposable(this, action);
		}
	}

	/// <summary>
	/// Stops the specified action being called each frame.
	/// </summary>
	public void RemoveFrameTask(Action action)
	{
		using (new UsingSemaphore(frameTasksSem))
		{
			if (isFrameTasksLocked)
				throw new InvalidOperationException("Attempted to modify frame tasks list from frame task!");

			frameTasks.Remove(action);
		}
	}

	/// <summary>
	/// Runs the specified action after the next frame a single time.
	/// </summary>
	public void InvokeNextFrame(Action action)
		=> AddFrameTask(action, true);

    public delegate bool CheckFunction<T>(in T callback) where T : struct;

	public Task<T> WaitAsync<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>(CheckFunction<T>? checkFunction = null, CancellationToken cancellationToken = default) where T: struct {
		TaskCompletionSource<T> taskCompletionSource = new();
		object lockObj = new();

		var handler = Register((ICallbackHandler handler, in T cb) =>
		{
			if (checkFunction != null && !checkFunction.Invoke(in cb)) {
				// Not the right one, keep waiting.
				return;
			}

			lock (lockObj)
			{
				try
				{
					taskCompletionSource.SetResult(cb);
				}
				catch (Exception)
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
