using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CppSourceGen.Attributes;
using CppSourceGen.Utils;
using JetBrains.Annotations;
using OpenSteamworks.ConCommands.Native;

namespace CppSourceGen;

public unsafe interface IVTImpl<TVT> where TVT: unmanaged
{
    public static abstract TVT* VTPtr { get; }
}

public abstract unsafe class CppClassBase<TNative, TVT, TIFace> : ICppClass<TIFace>, IDisposable
    where TNative: unmanaged 
    where TVT: unmanaged, IVTImpl<TVT>
{
    protected CppClassBase()
    {
        ObjectPtr = CppClassMarshal.AllocateNativeImpl<TNative, TVT>(TVT.VTPtr, this);
    }

    protected TNative* NativeObject => (TNative*)ObjectPtr;
    public nint ObjectPtr { get; private set; }
    public object? MetadataObject => null;
    
    public static TIFace Create(nint objectPtr, object? metadataObject = null)
        => throw new NotSupportedException("Cannot create class impl from native pointer!");

    private bool isDisposed;
    private void ReleaseUnmanagedResources()
    {
        CppClassMarshal.ReleaseNativeImpl(ObjectPtr);
        ObjectPtr = nint.Zero;
    }

    public void Dispose()
    {
        ObjectDisposedException.ThrowIf(isDisposed, this);
        isDisposed = true;
        
        ReleaseUnmanagedResources();
        GC.SuppressFinalize(this);
    }

    ~CppClassBase()
    {
        ReleaseUnmanagedResources();
    }
}