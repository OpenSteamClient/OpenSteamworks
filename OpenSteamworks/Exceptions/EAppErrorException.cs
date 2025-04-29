using System;
using OpenSteamworks.Data.Enums;

namespace OpenSteamworks.Exceptions;


/// <summary>
/// An exception that wraps an EResult.
/// </summary>
public class EAppErrorException : Exception
{
    public EAppError Result { get; }
    
    public EAppErrorException(EAppError result) : base(result.ToString())
    {
        if (result == EAppError.NoError)
            throw new ArgumentException("Do not construct a EAppErrorException with NoError.", nameof(result));
        
        this.Result = result;
    }

    public EAppErrorException(EAppError result, string message) : base(message)
    {
        if (result == EAppError.NoError)
            throw new ArgumentException("Do not construct a EAppErrorException with NoError.", nameof(result));
        
        this.Result = result;
    }

    public EAppErrorException(EAppError result, string message, Exception inner) : base(message, inner)
    {
        if (result == EAppError.NoError)
            throw new ArgumentException("Do not construct a EAppErrorException with NoError.", nameof(result));
        
        this.Result = result;
    }
    
    public static void ThrowIfNotOK(EAppError result)
    {
        if (result != EAppError.NoError)
            throw new EAppErrorException(result);
    }
}