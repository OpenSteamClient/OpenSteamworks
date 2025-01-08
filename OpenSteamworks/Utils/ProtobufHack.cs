using System;
using System.Runtime.InteropServices;
using Google.Protobuf;
using OpenSteamworks.Native;
using OpenSteamworks.Protobuf;

namespace OpenSteamworks.Utils;

/// <summary>
/// A class for marshalling managed protobuf objects to unmanaged pointers for the sake of interoperability with native binaries.
/// ValveSteam uses an archaic version of C++ protobuf, which is required by some function's args...
/// </summary>
internal static unsafe partial class ProtobufHack {
    [LibraryImport("protobufhack")]
    private static partial UInt32 Protobuf_ByteSizeLong(IntPtr ptr);

    [LibraryImport("protobufhack")]
    [return: MarshalAs(UnmanagedType.U1)]
    private static partial bool Protobuf_SerializeToArray(IntPtr ptr, void* buffer, UInt32 maxLen);
    
    //[LibraryImport("protobufhack")]
    //private static extern bool Protobuf_GetFuncs(string name, out nint constructor, out nint destructor, out nint dezerializer);

    // GRRRRRR. This should be replaced with a single, LibraryImportable function that takes a string and plops out the required ctor, dtor, and deserializer function pointers. Example above. Will require changing the natives though :(
    private static Lazy<NativeLibraryEx> loadedLibraryLazy =
        new Lazy<NativeLibraryEx>(() => NativeLibraryEx.Load("protobufhack", false, true));

    private static NativeLibraryEx LoadedLibrary => loadedLibraryLazy.Value;
    
    public static nint AllocateNative<T>(T? proto) where T: IMessage<T>
    {
        var constructor = (delegate* unmanaged[Cdecl]<IntPtr>)LoadedLibrary.GetExport(typeof(T).Name + "_Construct");
        var deserializer = (delegate* unmanaged[Cdecl]<void*, int, IntPtr>)LoadedLibrary.GetExport(typeof(T).Name + "_Deserialize");
            
        if (constructor == null || deserializer == null) {
            throw new InvalidOperationException("This type is not supported in protobufhack native lib");
        }
        
        if (proto == null)
        {
            return constructor();
        }

        var bytes = proto.ToByteArray();
        fixed (byte* bptr = bytes) {
            return deserializer(bptr, bytes.Length);
        }
    }

    public static T NativeToProtobuf<T>(nint ptr) where T: IMessage<T>, new()
    {
        var parser = new MessageParser<T>(() => new T());
        var length = Protobuf_ByteSizeLong(ptr);
        var bytes = new byte[length];
        fixed (byte* bptr = bytes) {
            if (!Protobuf_SerializeToArray(ptr, bptr, length)) {
                throw new Exception("Failed to serialize in native code!");
            }
        }
            
        return parser.ParseFrom(bytes);
    }

    public static void FreeNative<T>(nint ptr) where T: IMessage<T>, new()
    {
        if (ptr == 0)
            return;
        
        var deletor = (delegate* unmanaged[Cdecl]<IntPtr, void>)LoadedLibrary.GetExport(typeof(T).Name + "_Delete");
        if (deletor == null) {
            throw new InvalidOperationException("This type is not supported in protobufhack native lib");
        }

        deletor(ptr);
    }
}