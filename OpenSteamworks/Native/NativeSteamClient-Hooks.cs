using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using OpenSteamClient.Logging;
using OpenSteamworks.Data.Enums;

namespace OpenSteamworks.Native;

internal partial class NativeSteamClient
{
    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static unsafe SpewRetval_t SpewOutputFuncHook(SpewType_t pSeverity, void* str) {
        Trace.Assert(clientDLLLogger != null);
        
        string? message = Marshal.PtrToStringUTF8((IntPtr)str);
        message ??= string.Empty;
        if (!message.Contains(Environment.NewLine)) {
            clientDLLLogger.Write(message);
        } else {
            var lines = message.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                switch (pSeverity)
                {
                    case SpewType_t.SPEW_WARNING:
                        clientDLLLogger.Warning(line);
                        break;
                    case SpewType_t.SPEW_ERROR:
                        clientDLLLogger.Error(line);
                        break;
                    case SpewType_t.SPEW_ASSERT:
                        clientDLLLogger.Warning(line);
                        break;
                    case SpewType_t.SPEW_MESSAGE:
                    case SpewType_t.SPEW_LOG:
                    default:
                        clientDLLLogger.Info(line);
                        break;
                }
            }
        }
        
        if (pSeverity == SpewType_t.SPEW_ASSERT) {
            return SpewRetval_t.SPEW_DEBUGGER;
        }

        return SpewRetval_t.SPEW_CONTINUE;
    }
    
    private static void HookLoggingFunctions(NativeSteamClient creatingInstance)
    {
        Trace.Assert(loadedClientLib != null);
        
        // Spew stuff resides in tier0, which is statically linked on linux, but dynamically linked on Windows.
        NativeLibraryEx loggingTargetLibrary = loadedClientLib;
        if (OperatingSystem.IsWindows()) {
            try
            {
                loggingTargetLibrary = NativeLibraryEx.Load("tier0_s64.dll");
            }
            catch (Exception e)
            {
                creatingInstance.logger.Warning("Failed to open tier0, cannot hook logging.");
                creatingInstance.logger.Warning(e);
                return;
            }
            
        }
        
        // Hook DefaultSpewOutputFunc instead of using SpewOutputFunc setter, since steam replaces it internally in some unknown conditions
        var func = loggingTargetLibrary.FindSignature(SteamPlatform.DefaultSpewOutputFuncSig, SteamPlatform.DefaultSpewOutputFuncSigMask);
        if (func == 0) {
            creatingInstance.logger.Warning("Failed to find DefaultSpewOutputFunc, cannot hook logging.");
        } else {
            unsafe {
                loggingTargetLibrary.HookFunction(func, (IntPtr)(delegate* unmanaged[Cdecl]<SpewType_t, void*, SpewRetval_t>)&SpewOutputFuncHook);
            }
        }
    }
}