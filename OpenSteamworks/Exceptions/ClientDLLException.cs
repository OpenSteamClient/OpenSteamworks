using System;

namespace OpenSteamworks.Exceptions;

/// <summary>
/// Thrown when an unexpected failure happens in the ClientDLL, such as a version change or unimplemented function call.
/// </summary>
public class ClientDLLException : Exception
{
    public ClientDLLException()
    {
    }

    public ClientDLLException(string message) : base(message)
    {
    }

    public ClientDLLException(string message, Exception inner) : base(message, inner)
    {
    }
}