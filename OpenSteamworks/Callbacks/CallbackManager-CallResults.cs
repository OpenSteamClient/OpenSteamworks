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
		var buf = new byte[expectedSize];

		if (!clientUtils.GetAPICallResult(handle, buf, expectedSize, expectedCallbackID, out bool failed)) {
			throw new Exception("API call not completed");
		}

		if (failed) {
			return new(failed, clientUtils.GetAPICallFailureReason(handle), new());
		}

		T inst;
		fixed (byte* bptr = buf) 
			inst = Marshal.PtrToStructure<T>((nint)bptr);

		return new(failed, clientUtils.GetAPICallFailureReason(handle), inst);
	}
	
	private CallResult GetCompletedCall(SteamAPICall_t handle) {
		if (!clientUtils.IsAPICallCompleted(handle, out bool failed)) {
			throw new Exception("API call not completed");
		}
		
		return new(failed, clientUtils.GetAPICallFailureReason(handle));
	}
	
	private async Task<CallResult<T>> WaitCallResultAsync<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>(SteamAPICall_t handle, CancellationToken cancellationToken = default) where T: struct
	{
		if (!clientUtils.IsAPICallCompleted(handle, out bool failed)) {
			await WaitAsync<SteamAPICallCompleted_t>(cb => cb.m_hAsyncCall == handle, cancellationToken);
		}
		
		return GetCompletedCall<T>(handle);
	}

	private async Task<CallResult> WaitCallResultAsync(SteamAPICall_t handle,
		CancellationToken cancellationToken = default)
	{
		if (!clientUtils.IsAPICallCompleted(handle, out bool failed)) {
			await WaitAsync<SteamAPICallCompleted_t>(cb => cb.m_hAsyncCall == handle, cancellationToken);
		}
		
		return GetCompletedCall(handle);
	}
	
	
	/// <summary>
	/// Run an async call. If a function returns SteamApiCall_t, only ever call it with this function. This takes care of avoiding deadlocks.
	/// </summary>
	/// <typeparam name="T">The type of callback that will be received</typeparam>
	/// <param name="apiCall">The function to call, which will return a call handle. </param>
	/// <param name="cancellationToken">A cancellation token, if wanted.</param>
	/// <returns></returns>
	public async Task<CallResult> RunAsyncCall(Func<SteamAPICall_t> apiCall, CancellationToken cancellationToken = default)
	{
		await PauseThreadAsync();
		var task = WaitCallResultAsync(apiCall(), cancellationToken);
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