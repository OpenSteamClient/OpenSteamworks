using System;
using OpenSteamworks.Data.Enums;

namespace OpenSteamworks.Exceptions;

/// <summary>
/// Thrown when an API call fails.
/// </summary>
public sealed class APICallException : Exception
{
    /// <summary>
    /// The reason for the failure, if this exception came from awaiting a SteamAPICall_t.
    /// In other cases this will be <see cref="ESteamAPICallFailure.None"/>
    /// </summary>
    public ESteamAPICallFailure FailureReason { get; } = ESteamAPICallFailure.None;
    
    public APICallException()
    {
    }

    public APICallException(string message) : base(message)
    {
    }

    public APICallException(string message, Exception inner) : base(message, inner)
    {
    }
}