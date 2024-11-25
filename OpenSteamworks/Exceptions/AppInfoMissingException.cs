using System;

namespace OpenSteamworks.Exceptions;

/// <summary>
/// Thrown when attempting to call synchronous functions that require appinfo in cases where appinfo is missing.
/// </summary>
public class AppInfoMissingException : Exception
{
    public AppInfoMissingException()
    {
    }

    public AppInfoMissingException(string message) : base(message)
    {
    }

    public AppInfoMissingException(string message, Exception inner) : base(message, inner)
    {
    }
}