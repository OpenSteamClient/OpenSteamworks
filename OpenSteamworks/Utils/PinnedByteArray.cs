using System;
using System.Runtime.InteropServices;

namespace OpenSteamworks.Utils;

public unsafe sealed class PinnedByteArray : IDisposable {
    private int currentLength = 0;

    /// <summary>
    /// Gets the pointer to the current data. This pointer will never point to a non-existent block of memory. It can be null if the memory hasn't been set.
    /// </summary>
    public byte* CurrentPtr { get; private set; } = null;
    public ReadOnlySpan<byte> CurrentBytes => new(CurrentPtr, currentLength);

    public void SetData(byte[] newBytes) {
        ResizeBuffer(newBytes.Length);
        Marshal.Copy(newBytes, 0, (nint)CurrentPtr, currentLength);
    }

    public PinnedByteArray(int startingLength = 1024) {
        ResizeBuffer(startingLength);
    }

    private void ResizeBuffer(int newLength) {
        if (newLength == currentLength) {
            return;
        }
        
        CurrentPtr = (byte*)NativeMemory.Realloc(CurrentPtr, (nuint)newLength);
        currentLength = newLength;
    }

    private void ZeroMemory() {
        // This might be slow.
        for (int i = 0; i < currentLength; i++)
        {
            CurrentPtr[i] = 0;
        }
    }

    public void Dispose()
    {
        NativeMemory.Free(CurrentPtr);
        CurrentPtr = null;
        currentLength = 0;
    }
}