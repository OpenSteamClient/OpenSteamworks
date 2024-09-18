using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace OpenSteamworks.ConCommands;

public unsafe class ConsoleNative {
    public ConsoleNative(Native.ClientNative clientNative) {
        IConCommandBaseAccessor accessor;
        delegate* unmanaged[Cdecl]<IConCommandBaseAccessor*, nint, byte> ptr = &RegisterConCommandBase;
        accessor.accessorFunc = &ptr;

        clientNative.IClientEngine.ConCommandInit(in accessor);
    }

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static unsafe byte RegisterConCommandBase(IConCommandBaseAccessor *acc, nint pVar)
    {        
        return Convert.ToByte(ConCommandHandler.RegisterNativeConCommandBase(pVar));
    }
}