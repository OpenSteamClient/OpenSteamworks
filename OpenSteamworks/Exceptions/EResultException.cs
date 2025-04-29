using System;
using OpenSteamworks.Data.Enums;

namespace OpenSteamworks.Exceptions;

/// <summary>
/// An exception that wraps an EResult.
/// </summary>
public class EResultException : Exception
{
    public EResult Result { get; }
    
    public EResultException(EResult result) : base(result.ToString())
    {
        if (result == EResult.OK)
            throw new ArgumentException("Do not construct a EResultException with OK.", nameof(result));
        
        this.Result = result;
    }

    public EResultException(EResult result, string message) : base(message)
    {
        if (result == EResult.OK)
            throw new ArgumentException("Do not construct a EResultException with OK.", nameof(result));
        
        this.Result = result;
    }

    public EResultException(EResult result, string message, Exception inner) : base(message, inner)
    {
        if (result == EResult.OK)
            throw new ArgumentException("Do not construct a EResultException with OK.", nameof(result));
        
        this.Result = result;
    }

    public static void ThrowIfNotOK(EResult result)
    {
        if (result != EResult.OK)
            throw new EResultException(result);
    }
}