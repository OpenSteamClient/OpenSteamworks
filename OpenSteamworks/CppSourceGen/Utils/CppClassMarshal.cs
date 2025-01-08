using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CppSourceGen.Utils;

public sealed unsafe class CppClassMarshal
{
    public static nint ClassToPtr(object? unkObject)
    {
        if (unkObject is null)
            return 0;

        if (unkObject is not ICppClass cppClass)
            throw new ArgumentException("Tried to get marshal a class, but the class does not implement ICppClass.", nameof(unkObject));
        
        return cppClass.ObjectPtr;
    }

    public static TVT* AllocateVT<TVT>(in TVT staticVT) where TVT: unmanaged
    {
        var vtPtr = (TVT*)RuntimeHelpers.AllocateTypeAssociatedMemory(typeof(TVT), sizeof(TVT));
        *vtPtr = staticVT;
        return vtPtr;
    }

    private static readonly object allocatedNativesLock = new();
    private static readonly Dictionary<nint, object> allocatedNatives = new();

    public static TManaged GetManagedForPtr<TManaged>(void* objectPtr) where TManaged: class
    {
        lock (allocatedNativesLock)
        {
            if (!allocatedNatives.TryGetValue((nint)objectPtr, out object? obj))
                throw new ArgumentException("Pointer is free'd or not allocated by us. Cannot get corresponding managed object.", nameof(objectPtr));
            
            if (obj is not TManaged targetObj)
                throw new ArgumentException("Object type does not match expected type", nameof(TManaged));

            return targetObj;
        }
    }
    
    public static nint AllocateNativeImpl<TNative, TVT>(TVT *vtPtr, object managedWrapper) 
        where TNative: unmanaged 
        where TVT: unmanaged
    {
        var nativePtr = NativeMemory.Alloc((nuint)sizeof(TNative));
        lock (allocatedNativesLock)
        {
            allocatedNatives.Add((nint)nativePtr, managedWrapper);
        }
        
        // Set the first field of TNative to the vtable pointer (the first field is always the vtable ptr)
        // In the case of multiple inheritance, there may be multiple vtable pointers which is why we don't support it.
        TVT** targetVTPtr = (TVT**)(nativePtr);
        *targetVTPtr = vtPtr;

        return (nint)nativePtr;
    }
    
    public static void ReleaseNativeImpl(nint ptr)
    {
        if (ptr == 0)
            return;

        lock (allocatedNativesLock)
        {
            allocatedNatives.Remove(ptr);
        }
        
        // Don't free the VTable, it's automatically freed when the type is unloaded
        NativeMemory.Free((void*)ptr);
    }
}