using System.Runtime.InteropServices;
using System.Text;

namespace OpenSteamworks.Data;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct CUtlString : IDisposable
{
    private void* m_pchString;
    
    public CUtlString() {}

    public CUtlString(string? str) {
        Set(str);
    }

    public static CUtlString Empty { get; } = new(string.Empty);
    public static CUtlString Null { get; } = new();
    

    /// <summary>
    /// Get the current value. If the pointer is null, returns null.
    /// </summary>
    /// <returns></returns>
    public readonly string? ToManaged()
    {
        return Marshal.PtrToStringUTF8((nint)m_pchString);
    }
    
    /// <summary>
    /// Get the current value. If the pointer is null, return an empty string.
    /// </summary>
    /// <returns></returns>
    public readonly override string ToString()
    {
        return ToManaged() ?? string.Empty;
    }
    
    public void Dispose()
    {
        NativeMemory.Free(m_pchString);
        m_pchString = null;
    }

    public void Set(string? newValue)
    {
        if (newValue == null)
        {
            // If we get a null value, free the pointer and set it to a null pointer.
            Dispose();
            return;
        }
        
        Set(Encoding.UTF8.GetBytes(newValue + "\0"));
    }

    /// <summary>
    /// Set the value to the specified UTF8 string. The string may be null terminated or not, but in both scenarios only a single null terminator will exist.
    /// </summary>
    public void Set(ReadOnlySpan<byte> utf8Bytes)
    {
        // Check if the last character is null
        bool isNullTerminated = utf8Bytes[^1] == 0;
        
        // If it is, allocate an extra byte for the null terminator
        int lengthToAlloc = isNullTerminated ? utf8Bytes.Length : utf8Bytes.Length + 1;
        
        if (m_pchString != null)
        {
            // If we have an existing string use realloc
            m_pchString = NativeMemory.Realloc(m_pchString, (nuint)lengthToAlloc);
        }
        else
        {
            // If not, use alloc
            m_pchString = NativeMemory.Alloc((nuint)lengthToAlloc);
        }

        var newMemory = new Span<byte>(m_pchString, lengthToAlloc);
        utf8Bytes.CopyTo(newMemory);
        
        // Set the last character to null if it wasn't already
        if (!isNullTerminated)
        {
            newMemory[^1] = 0;
        }
    }
}