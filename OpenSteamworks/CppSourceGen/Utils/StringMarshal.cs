using System.Runtime.InteropServices;
using System.Text;

namespace CppSourceGen.Utils;

public static class StringMarshal
{
	public unsafe static nint[] CopyStringArray(string[] array) 
	{
		nint[] pointers = new nint[array.Length];
		for (int i = 0; i < pointers.Length; i++)
		{
			var asBytes = Encoding.UTF8.GetBytes(array[i] + "\0");
			void* ptr = NativeMemory.Alloc((nuint)asBytes.Length);
			fixed (byte* bptr = asBytes) {
				NativeMemory.Copy(bptr, ptr, (nuint)asBytes.Length);
			}

			pointers[i] = (nint)ptr;
		}

		return pointers;
	}

	public unsafe static void FreeStringArray(nint[] array) {
		foreach (var item in array)
		{
			NativeMemory.Free((void*)item);
		}
	}
}