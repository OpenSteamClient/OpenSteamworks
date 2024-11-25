using System;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using CppSourceGen;
using OpenSteamClient.Logging;
using OpenSteamworks.Data;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data.Structs;
using OpenSteamworks.Exceptions;
using OpenSteamworks.Generated;
using OpenSteamworks.Utils;

namespace OpenSteamworks.Native;

internal partial class NativeSteamClient : ISteamClientImpl
{
    public HSteamPipe Pipe { get; set; }
    public HSteamUser User { get; set; }
    
    public int SteamPID { get; }
    
    public IClientEngine IClientEngine { get; private set; }
    
    public unsafe bool BGetCallback(out CallbackMsg_t callbackMsg)
    {
        Trace.Assert(fnBGetCallback != null);
        
        NativeCallbackMsg_t nativeCallbackMsg;
        if (!fnBGetCallback(Pipe, &nativeCallbackMsg))
        {
            callbackMsg = new();
            return false;
        }

        callbackMsg = new()
        {
            CallbackID = nativeCallbackMsg.m_iCallback,
            SteamUser = nativeCallbackMsg.m_hSteamUser,
            CallbackData = new(nativeCallbackMsg.m_pubParam, nativeCallbackMsg.m_cubParam),
        };
        
        return true;
    }

    public void FreeLastCallback()
    {
        Trace.Assert(fnFreeLastCallback != null);
        fnFreeLastCallback(Pipe);
    }
    
    private readonly ILogger logger;
    
    public NativeSteamClient(ILogger logger, NativeSteamClientCreateOptions createOptions)
    {
        this.logger = logger;
        
        InitClientDLL(createOptions, this);
        Trace.Assert(IClientEngine != null);
        
        // No better way to determine this with native client.
        if (SteamPIDFile.TryGetGlobalInstancePID(out int steamPID))
        {
            SteamPID = steamPID;
        }
        else
        {
            logger.Warning("Cannot determine if client is in a cross process context!");
        }
        
        // SteamService trickery.
        if (OperatingSystem.IsLinux())
        {
            UtilityFunctions.SetEnvironmentVariable($"SteamClientService_{Environment.ProcessId}", "127.0.0.1:57344");
        }
    }

    private bool isDisposed = false;
    public void Dispose()
    {
        ObjectDisposedException.ThrowIf(isDisposed, this);
        isDisposed = true;
        
        DeinitClientDLL();
    }
}