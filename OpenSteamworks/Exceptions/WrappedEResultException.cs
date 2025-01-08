using System;
using OpenSteamworks.Data.Enums;

namespace OpenSteamworks.Exceptions;

/// <summary>
/// An exception that wraps an EResult.
/// </summary>
public class WrappedEResultException : Exception
{
    public EResult Result { get; }
    
    public WrappedEResultException(EResult result) : base(result.ToString())
    {
        if (result == EResult.OK)
            throw new ArgumentException("Do not construct a WrappedEResultException with OK.", nameof(result));
        
        this.Result = result;
    }

    public WrappedEResultException(EResult result, string message) : base(message)
    {
        if (result == EResult.OK)
            throw new ArgumentException("Do not construct a WrappedEResultException with OK.", nameof(result));
        
        this.Result = result;
    }

    public WrappedEResultException(EResult result, string message, Exception inner) : base(message, inner)
    {
        if (result == EResult.OK)
            throw new ArgumentException("Do not construct a WrappedEResultException with OK.", nameof(result));
        
        this.Result = result;
    }
}