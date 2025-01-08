using OpenSteamworks.Data.Enums;

namespace OpenSteamworks.Callbacks;

public class CallResult
{
	public bool Failed { get; }
	public ESteamAPICallFailure FailureReason { get; }

	public CallResult(bool failed, ESteamAPICallFailure failureReason)
	{
		this.Failed = failed;
		this.FailureReason = failureReason;
	}
}

public sealed class CallResult<T>(bool failed, ESteamAPICallFailure failureReason, T data) : CallResult(failed, failureReason)
	where T : struct
{
	public T Data { get; } = data;
}