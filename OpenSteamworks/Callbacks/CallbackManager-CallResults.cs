using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using OpenSteamworks.Callbacks.Structs;
using OpenSteamworks.Utils;
using OpenSteamworks.Data;

namespace OpenSteamworks.Callbacks;

public partial class CallbackManager {
	private unsafe CallResult<T> GetCompletedCall<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>(SteamAPICall_t handle) where T: struct {
		int expectedCallbackID = CallbackMetadata.GetIDFromType<T>();
		int expectedSize = Marshal.SizeOf<T>();
		using var mem = NativeMemoryBlock.AllocZeroed((nuint)expectedSize);

		if (!clientUtils.GetAPICallResult(handle, mem.Ptr, expectedSize, expectedCallbackID, out bool failed)) {
			throw new Exception("API call not completed");
		}

		if (failed) {
			return new CallResult<T>(failed, clientUtils.GetAPICallFailureReason(handle), new());
		}

		T inst;
		inst = Marshal.PtrToStructure<T>((nint)mem.Ptr);

		return new CallResult<T>(failed, clientUtils.GetAPICallFailureReason(handle), inst);
	}
	
	private async Task<CallResult<T>> WaitCallResultAsync<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>(SteamAPICall_t handle, CancellationToken cancellationToken = default) where T: struct
	{
		int expectedCallbackID = CallbackMetadata.GetIDFromType<T>();
		int expectedSize = Marshal.SizeOf<T>();

		// Check to see if the call has already completed, before starting to wait.
		if (clientUtils.IsAPICallCompleted(handle, out bool failed)) {
			return GetCompletedCall<T>(handle);
		}

		// If the call isn't complete yet, wait for the callback.
		await WaitAsync<SteamAPICallCompleted_t>(cb => cb.m_hAsyncCall == handle, cancellationToken);
		return GetCompletedCall<T>(handle);
	}

	/// <summary>
	/// Run an async call. If a function returns SteamApiCall_t, only ever call it with this function. This takes care of avoiding deadlocks.
	/// </summary>
	/// <typeparam name="T">The type of callback that will be received</typeparam>
	/// <param name="apiCall">The function to call, which will return a call handle. </param>
	/// <param name="cancellationToken">A cancellation token, if wanted.</param>
	/// <returns></returns>
	public async Task<CallResult<T>> RunAsyncCall<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>(Func<SteamAPICall_t> apiCall, CancellationToken cancellationToken = default) where T: struct
	{
		await PauseThreadAsync();
		var task = WaitCallResultAsync<T>(apiCall(), cancellationToken);
		ResumeThread();

		return await task;
	}

	/// <summary>
	/// Run an async call. If a function returns SteamApiCall_t, only ever call it with this function. This takes care of avoiding deadlocks.
	/// </summary>
	/// <typeparam name="T">The type of callback that will be received</typeparam>
	/// <param name="apiCall">The function to call, which will return a call handle. </param>
	/// <param name="cancellationToken">A cancellation token, if wanted.</param>
	/// <returns></returns>
	public async Task<CallResult<T>> RunAsyncCall<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>(Func<SteamAPICall<T>> apiCall, CancellationToken cancellationToken = default) where T: struct
	{
		await PauseThreadAsync();
		var task = WaitCallResultAsync<T>(apiCall(), cancellationToken);
		ResumeThread();

		return await task;
	}
}