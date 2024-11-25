using System;
using System.Runtime.InteropServices;

namespace OpenSteamworks.Utils;

/// <summary>
/// A block of native memory that implements IDisposable, for easy avoidance of memory leaks.
/// For docs, see NativeMemory (CLR class)
/// </summary>
internal sealed unsafe class NativeMemoryBlock : IDisposable {
	public bool IsAligned { get; }
	public void* Ptr { get; }

	private NativeMemoryBlock(void* allocatedPtr, bool aligned) {
		this.IsAligned = aligned;
		this.Ptr = allocatedPtr;
	}

	public void Dispose()
	{
		if (IsAligned) {
			NativeMemory.AlignedFree(Ptr);
		} else {
			NativeMemory.Free(Ptr);
		}
	}

	public static NativeMemoryBlock AlignedAlloc(nuint byteCount, nuint alignment)
		=> new(NativeMemory.AlignedAlloc(byteCount, alignment), true);

	public unsafe static NativeMemoryBlock Alloc(nuint byteCount)
		=> new(NativeMemory.Alloc(byteCount), false);

	public unsafe static NativeMemoryBlock Alloc(nuint elementCount, nuint elementSize)
		=> new(NativeMemory.Alloc(elementCount, elementSize), false);

	public unsafe static NativeMemoryBlock AllocZeroed(nuint byteCount)
		=> new(NativeMemory.AllocZeroed(byteCount), false);

	public unsafe static NativeMemoryBlock AllocZeroed(nuint elementCount, nuint elementSize)
		=> new(NativeMemory.AllocZeroed(elementCount, elementSize), false);
}