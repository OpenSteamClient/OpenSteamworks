using OpenSteamworks.Data.Enums;

namespace OpenSteamworks.Callbacks;

public sealed class CallResult<T> where T: struct {
    public bool Failed { get; }
	public ESteamAPICallFailure FailureReason { get; }
	public T Data { get; }

	public CallResult(bool failed, ESteamAPICallFailure failureReason, T data) {
        this.Failed = failed;
        this.FailureReason = failureReason;
        this.Data = data;
    }
}