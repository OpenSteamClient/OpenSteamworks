using System.Runtime.InteropServices;
using OpenSteamClient.Logging;

namespace OpenSteamworks.Data.Interop;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct CUtlMemory<T> : IDisposable where T : unmanaged
{
    /// <summary>
    /// Use with care. This may change on reallocation.
    /// </summary>
	public T* Pointer { get; private set; }
    public int AllocationCount { get; private set; }
    public int GrowSize { get; private set;  }

    private const int EXTERNAL_BUFFER_MARKER = -1;
    private const int EXTERNAL_CONST_BUFFER_MARKER = -2;

    public CUtlMemory(int growSize = 0, int nInitSize = 0) {
        this.AllocationCount = nInitSize;
        nuint size = (nuint)(sizeof(T) * this.AllocationCount);
        UtlLogging.UtlMemory.Debug($"Allocating CUtlMemory of size {size}");
        this.Pointer = (T*)NativeMemory.AllocZeroed(size);
        this.GrowSize = growSize;
    }

    public CUtlMemory(bool isConst, T* ptr, int len)
    {
        this.Pointer = ptr;
        this.AllocationCount = len;
        this.GrowSize = isConst ? EXTERNAL_CONST_BUFFER_MARKER : EXTERNAL_BUFFER_MARKER;
    }
    
    private static int UtlMemory_CalcNewAllocationCount( int nAllocationCount, int nGrowSize, int nNewSize, int nBytesItem )
    {
        if ( nGrowSize != 0 )
        { 
            nAllocationCount = ((1 + ((nNewSize - 1) / nGrowSize)) * nGrowSize);
        }
        else 
        {
            if ( nAllocationCount == 0 )
            {
                if ( nBytesItem > 0 )
                {
                    // Compute an allocation which is at least as big as a cache line...
                    nAllocationCount = (31 + nBytesItem) / nBytesItem;
                }
                else
                {
                    // Should be impossible, but if hit try to grow an amount that may be large
                    // enough for most cases and thus avoid both divide by zero above as well as
                    // likely memory corruption afterwards.
                    UtlLogging.UtlMemory.Debug("nBytesItem is " + nBytesItem + "in UtlMemory_CalcNewAllocationCount");
                    nAllocationCount = 256;
                }
            }

            // Cap growth to avoid high-end doubling insanity (1 GB -> 2 GB -> overflow)
            int nMaxGrowStep = int.Max( 1, 256*1024*1024 / ( nBytesItem > 0 ? nBytesItem : 1 ) );
            while (nAllocationCount < nNewSize)
            {
                // Grow by doubling, but at most 256 MB at a time.
                nAllocationCount += int.Min( nAllocationCount, nMaxGrowStep );
            }
        }

        return nAllocationCount;
    }

    public bool IsExternal => GrowSize < 0;
    public bool IsReadOnly => GrowSize is EXTERNAL_CONST_BUFFER_MARKER;
    
    public void ConvertToGrowableMemory(int growSize)
    {
        if (!IsExternal)
            return;

        GrowSize = growSize;
        if (AllocationCount == 0)
        {
            Pointer = null;
            return;
        }

        var bytesSize = (nuint)(AllocationCount * sizeof(T));
        var newMemory = (T*)NativeMemory.Alloc(bytesSize);
        NativeMemory.Copy(Pointer, newMemory, bytesSize);
        Pointer = newMemory;
    }
    
    public void Grow(int num) {
        ThrowIfDisposed();
        
        if (IsExternal)
            throw new InvalidOperationException("Attempt to grow buffer that is externally allocated");
        
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(num);
        
        // Make sure we have at least numallocated + num allocations.
        // Use the grow rules specified for this memory (in m_nGrowSize)
        int nAllocationRequested = AllocationCount + num;

        var was = AllocationCount * sizeof(T);
        this.AllocationCount = UtlMemory_CalcNewAllocationCount(AllocationCount, GrowSize, nAllocationRequested, sizeof(T));
        UtlLogging.UtlMemory.Info("Growing memory to " + AllocationCount * sizeof(T) + ", was: " + was);
        this.Pointer = (T*)NativeMemory.Realloc(this.Pointer, (nuint)(AllocationCount * sizeof(T)));
    }
    
    public ReadOnlySpan<T> GetSpan()
    {
        ThrowIfDisposed();
        return new(this.Pointer, this.AllocationCount);
    }

    public Span<T> GetWritableSpan()
    {
        ThrowIfDisposed();
        if (IsReadOnly)
            throw new InvalidOperationException("Buffer is read-only but a write was attempted.");
        
        return new(this.Pointer, this.AllocationCount);
    }

    public T this[int i] {
        get => GetSpan()[i];
        set => GetWritableSpan()[i] = value;
    }

    private readonly bool isDisposed 
        => Pointer == null && AllocationCount == 0 && GrowSize == 0;

    public void Dispose()
    {
        ThrowIfDisposed();
        
        GrowSize = 0;
        AllocationCount = 0;
        Pointer = null;
        
        UtlLogging.UtlMemory.Debug("Disposing CUtlMemory");
        NativeMemory.Free(this.Pointer);
    }

    public readonly void ThrowIfDisposed()
    {
        ObjectDisposedException.ThrowIf(isDisposed, typeof(CUtlMemory<T>));
    }
}