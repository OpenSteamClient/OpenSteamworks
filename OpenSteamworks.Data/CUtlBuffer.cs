using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using OpenSteamClient.Logging;

namespace OpenSteamworks.Data;

// ReSharper disable InconsistentNaming
// ReSharper disable PrivateFieldCanBeConvertedToLocalVariable
// ReSharper disable MemberCanBePrivate.Global

[StructLayout(LayoutKind.Sequential)]
public unsafe struct CUtlBuffer : IDisposable {
    private CUtlMemory<byte> m_Memory;
    public int ReadPosition { get; set; }
	public int WritePosition { get; set; }

	public int MaxWritten { get; private set; }
    private UInt16 m_nTab = 0;

	private ErrorFlags_t m_Error;
    private BufferFlags_t m_Flags;

    private delegate* unmanaged[Thiscall]<CUtlBuffer*, int, byte> ReadOverflowFunc;
    private uint padding = 0;
    private delegate* unmanaged[Thiscall]<CUtlBuffer*, int, byte> WriteOverflowFunc;
    private uint padding1 = 0;
    
    [Flags]
    private enum ErrorFlags_t : byte 
    {
        WRITE_OVERFLOW = 0x1,
        READ_OVERFLOW = 0x2
    }
    
    [Flags]
    public enum BufferFlags_t : byte
	{
		TEXT_BUFFER = 0x1,			// Describes how get + put work (as strings, or binary)
		EXTERNAL_GROWABLE = 0x2,	// This is used w/ external buffers and causes the utlbuf to switch to reallocatable memory if an overflow happens when Putting.
		CONTAINS_CRLF = 0x4,		// For text buffers only, does this contain \n or \n\r?
		READ_ONLY = 0x8,			// For external buffers; prevents null termination from happening.
		AUTO_TABS_DISABLED = 0x10,	// Used to disable/enable push/pop tabs
		LITTLE_ENDIAN_BUFFER = 0x20,// ensures that data is stored in little endian format
		BIG_ENDIAN_BUFFER = 0x40,	// ensures that data is stored in big endian format
	};
    
    public enum SeekType_t : byte
	{
		SEEK_HEAD = 0,
		SEEK_CURRENT,
		SEEK_TAIL
	};

    public CUtlBuffer()
    {
        this.m_Error = 0;
        this.ReadPosition = 0;
        this.WritePosition = 0;
        this.MaxWritten = -1;
        this.m_Flags = 0;
        this.ReadOverflowFunc = &ReadOverflow;
        this.WriteOverflowFunc = &WriteOverflow;
    }
    
    public CUtlBuffer(int length, int growSize = 0) : this() { 
        this.m_Memory = new CUtlMemory<byte>(growSize, length);
        
        if (length != 0)
            AddNullTermination();
    }

    public CUtlBuffer(bool isConst, byte* ptr, int len) : this()
    {
        this.m_Memory = new CUtlMemory<byte>(isConst, ptr, len);
        this.m_Flags = BufferFlags_t.EXTERNAL_GROWABLE;
        if (isConst)
        {
            this.m_Flags |= BufferFlags_t.READ_ONLY;
            this.MaxWritten = len;
            this.WritePosition = len;
        }
        else
        {
            AddNullTermination();
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvThiscall)])]
    public static byte WriteOverflow(CUtlBuffer *buf, int nSize) {
        UtlLogging.UtlBuffer.Debug("PutOverflow called");
        buf->Grow(nSize);
            
        return 1;
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvThiscall)])]
    public static byte ReadOverflow(CUtlBuffer *buf, int nSize) {
        UtlLogging.UtlBuffer.Debug("GetOverflow called");
        return 0;
    }

    /// <summary>
    /// Change where I'm reading
    /// </summary>
    public bool SeekRead( SeekType_t type, int offset )	
    {
        m_Memory.ThrowIfDisposed();
        
        switch( type )
        {
            case SeekType_t.SEEK_HEAD:						 
                ReadPosition = offset; 
                break;

            case SeekType_t.SEEK_CURRENT:
                ReadPosition += offset;
                break;

            case SeekType_t.SEEK_TAIL:
                ReadPosition = MaxWritten - offset;
                break;
        }

        if ( ReadPosition > MaxWritten )
        {
            m_Error |= ErrorFlags_t.READ_OVERFLOW;
            return false;
        }
        else
        {
            m_Error &= ~ErrorFlags_t.READ_OVERFLOW;
            return true;
        }
    }
    
    /// <summary>
    /// Change where I'm writing
    /// </summary>
    public void SeekWrite( SeekType_t type, int offset )	
    {
        m_Memory.ThrowIfDisposed();
        
        switch( type )
        {
            case SeekType_t.SEEK_HEAD:						 
                WritePosition = offset; 
                break;

            case SeekType_t.SEEK_CURRENT:
                WritePosition += offset;
                break;

            case SeekType_t.SEEK_TAIL:
                WritePosition = MaxWritten - offset;
                break;
        }
        
        AddNullTermination();
    }

    private bool CheckRead(int num)
    {
        ThrowIfInvalidFlags();
        
        if (num < 0)
            return false;

        if (m_Error.HasFlag(ErrorFlags_t.READ_OVERFLOW))
            return false;

        if (MaxWritten < ReadPosition + num)
        {
            m_Error |= ErrorFlags_t.READ_OVERFLOW;
            return false;
        }

        if (ReadPosition < 0 || m_Memory.AllocationCount < ReadPosition + num)
        {
            if (!OnReadOverflow(num))
            {
                m_Error |= ErrorFlags_t.READ_OVERFLOW;
                return false;
            }
        }

        return true;
    }

    private bool OnReadOverflow(int num)
    {
        if (this.ReadOverflowFunc == null)
            return false;

        fixed (CUtlBuffer* thisptr = &this)
        {
            return ReadOverflowFunc(thisptr, num) != 0;
        }
    }

    private bool CheckWrite(int num)
    {
        ThrowIfInvalidFlags(true);
        ArgumentOutOfRangeException.ThrowIfNegative(num);

        if (m_Error.HasFlag(ErrorFlags_t.WRITE_OVERFLOW))
            return false;

        if (m_Flags.HasFlag(BufferFlags_t.READ_ONLY))
            return false;

        if (WritePosition < 0)
            throw new InvalidDataException($"WritePosition is invalid. (a negative value of {WritePosition}");

        if (num <= m_Memory.AllocationCount - WritePosition)
            return true;

        if (OnWriteOverflow(num)) 
            return true;
        
        m_Error |= ErrorFlags_t.WRITE_OVERFLOW;
        return false;

    }
    
    private bool OnWriteOverflow(int num)
    {
        if (this.WriteOverflowFunc == null)
            return false;
        
        fixed (CUtlBuffer* thisptr = &this)
        {
            return WriteOverflowFunc(thisptr, num) != 0;
        }
    }

    public bool TryRead(Span<byte> buffer, int num)
    {
        if (!CheckRead(num))
            return false;
        
        GetReadSpan().CopyTo(buffer);
        ReadPosition += num;
        return true;
    }
    
    /// <summary>
    /// Tries to write data. If the write fails, no exception is thrown and false is returned. Returns true on success.
    /// </summary>
    /// <param name="data"></param>
    public bool TryWrite(ReadOnlySpan<byte> data)
    {
        if (data.Length > 0 && CheckWrite(data.Length))
        {
            data.CopyTo(GetWriteSpan());
            WritePosition += data.Length;
            AddNullTermination();
            return true;
        }

        return false;
    }

    public void Grow(int newSize)
    {
        ThrowIfInvalidFlags(true);
        
        if (m_Flags.HasFlag(BufferFlags_t.EXTERNAL_GROWABLE))
            throw new NotImplementedException("Growing external memory not implemented.");
        
        int nGrowDelta = (ReadPosition + newSize) - m_Memory.AllocationCount;
        if ( nGrowDelta >  0 )
        {
            m_Memory.Grow( nGrowDelta );
        }
    }

    private void ThrowIfInvalidFlags(bool isWriteOperation = false)
    {
        if (isWriteOperation && m_Flags.HasFlag(BufferFlags_t.READ_ONLY))
            throw new InvalidOperationException("Buffer is read-only, and a write was attempted.");
        
        if (m_Flags.HasFlag(BufferFlags_t.TEXT_BUFFER))
            throw new NotImplementedException("Text buffers are currently unsupported");
    }
    
    
    public void Dispose()
    {
        m_Memory.ThrowIfDisposed();
        this.m_Memory.Dispose();
    }

    public void AddNullTermination()
    {
        if (WritePosition > MaxWritten)
        {
            //TODO: For text buffers, this should actually null terminate.
            MaxWritten = WritePosition;
        }
    }
    
    /// <summary>
    /// Gets the span for reading.
    /// You must increment <see cref="ReadPosition"/> manually.
    /// </summary>
    /// <returns></returns>
    public ReadOnlySpan<byte> GetReadSpan()
        => new(m_Memory.Pointer + ReadPosition, MaxWritten);
    
    /// <summary>
    /// Gets the span for writing.
    /// You must increment <see cref="WritePosition"/> manually, and call <see cref="AddNullTermination"/> afterwards.
    /// </summary>
    /// <returns></returns>
    public Span<byte> GetWriteSpan()
        => new(m_Memory.Pointer + WritePosition, m_Memory.AllocationCount - WritePosition);
}