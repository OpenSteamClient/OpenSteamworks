using System;

namespace OpenSteamworks.Exceptions;

/// <summary>
/// Thrown when an API call fails for unknown reasons.
/// </summary>
public class APICallException : Exception
{
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