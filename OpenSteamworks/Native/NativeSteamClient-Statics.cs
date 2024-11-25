using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using CppSourceGen;
using OpenSteamClient.Logging;
using OpenSteamworks.Data;
using OpenSteamworks.Data.Structs;
using OpenSteamworks.Exceptions;
using OpenSteamworks.Generated;
using OpenSteamworks.Utils;

namespace OpenSteamworks.Native;

internal partial class NativeSteamClient
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private unsafe delegate IntPtr FnCreateInterface(string name, int *error);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private unsafe delegate bool FnBGetCallback(HSteamPipe steamPipe, NativeCallbackMsg_t *pCallbackMsg);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void FnFreeLastCallback(HSteamPipe steamPipe);
    
    private static readonly object loadedClientLibLock = new();
    private static readonly RefCount loadedClientLibRefCount = new();
    private static NativeLibraryEx? loadedClientLib;
    private static FnCreateInterface? fnCreateInterface;
    private static FnBGetCallback? fnBGetCallback;
    private static FnFreeLastCallback? fnFreeLastCallback;
    
    private static ILogger? clientDLLLogger;
    private static IClientEngine? clientEngine;
    
    [MemberNotNull(nameof(IClientEngine))]
    [MemberNotNull(nameof(clientDLLLogger))]
    [MemberNotNull(nameof(fnCreateInterface))]
    [MemberNotNull(nameof(fnBGetCallback))]
    [MemberNotNull(nameof(fnFreeLastCallback))]
    [MemberNotNull(nameof(loadedClientLib))]
    [MemberNotNull(nameof(clientEngine))]
    private static void InitClientDLL(NativeSteamClientCreateOptions createOptions, NativeSteamClient creatingInstance)
    {
        lock (loadedClientLibLock)
        {
            using var constructLock = loadedClientLibRefCount.Increment(out bool shouldConstruct);
            if (shouldConstruct)
            {
                Trace.Assert(loadedClientLib == null, "Creating new client even though we already have one loaded? RefCount mismatch?");
                
                clientDLLLogger = createOptions.LoggingSettings.LoggerFactory.CreateLogger("ClientDLL");
                loadedClientLib = NativeLibraryEx.Load(createOptions.ClientDLLPath);
                fnCreateInterface = loadedClientLib.GetExport<FnCreateInterface>("CreateInterface");
                fnBGetCallback = loadedClientLib.GetExport<FnBGetCallback>("Steam_BGetCallback");
                fnFreeLastCallback = loadedClientLib.GetExport<FnFreeLastCallback>("Steam_FreeLastCallback");
                if (fnCreateInterface == null || fnBGetCallback == null || fnFreeLastCallback == null)
                    throw new ClientDLLException("Failed to retrieve any of: CreateInterface, Steam_BGetCallback or Steam_FreeLastCallback.");

                unsafe
                {
                    int failCode = 0;
                    var retPtr = fnCreateInterface(SteamPlatform.CLIENTENGINE_INTERFACE_VERSION, &failCode);
                    if (retPtr == IntPtr.Zero)
                        throw new ClientDLLException($"Failed to retrieve IClientEngine (ver {SteamPlatform.CLIENTENGINE_INTERFACE_VERSION}), failCode: {failCode}");

                    clientEngine = MarshallableClasses.Create_IClientEngine(retPtr);
                    creatingInstance.IClientEngine = clientEngine;
                    
                    if (createOptions.HookLoggingFunctions)
                        HookLoggingFunctions(creatingInstance);

                    if (createOptions.EnableConCommandSystem)
                        InitConCommands(creatingInstance);
                }
            }
            else
            {
                creatingInstance.logger.Trace($"Ignored ClientDLL \"{createOptions.ClientDLLPath}\", ClientDLL is already loaded in this process; using loaded.");
            }
        }
        
        Trace.Assert(clientDLLLogger != null);
        Trace.Assert(fnCreateInterface != null);
        Trace.Assert(fnBGetCallback != null);
        Trace.Assert(fnFreeLastCallback != null);
        Trace.Assert(clientEngine != null);
        Trace.Assert(loadedClientLib != null);
    }

    private static void DeinitClientDLL()
    {
        lock (loadedClientLibLock)
        {
            using var deconstructLock = loadedClientLibRefCount.Decrement(out bool shouldDeconstruct);
            if (shouldDeconstruct)
            {
                Trace.Assert(loadedClientLib != null, "This is impossible.");

                clientEngine?.BShutdownIfAllPipesClosed();
                
                loadedClientLib.Unload();
                loadedClientLib = null;
                fnCreateInterface = null;
                fnBGetCallback = null;
                fnFreeLastCallback = null;
                clientDLLLogger = null;
            }
        }
    }
}