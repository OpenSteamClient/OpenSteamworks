using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text;

namespace CppSourceGen.Utils;

public static unsafe class StringMarshal
{
	public static Span<nint> CopyStringArray(string?[] array) 
	{
		nint[] pointers = new nint[array.Length];
		for (int i = 0; i < pointers.Length; i++)
		{
			pointers[i] = StringToPtrUTF8(array[i]);
		}

		return pointers;
	}

	public static void FreeStringArray(Span<nint> array) {
		for (int i = 0; i < array.Length; i++)
		{
			FreeUTF8String(array[i]);
		}
	}

	/// <summary>
	/// Populates the given array with the strings from the pointers
	/// </summary>
	/// <param name="targetArr"></param>
	/// <param name="ptrs"></param>
	public static void GetStringArray(ref string?[] targetArr, ReadOnlySpan<nint> ptrs)
	{
		if (targetArr.Length < ptrs.Length)
			targetArr = new string?[ptrs.Length];

		for (int i = 0; i < ptrs.Length; i++)
		{
			targetArr[i] = PtrToStringUTF8(ptrs[i]);
		}
	}

	public static nint StringToPtrUTF8(string? str) => (nint)Utf8StringMarshaller.ConvertToUnmanaged(str);
	public static string? PtrToStringUTF8(nint ptr) => Utf8StringMarshaller.ConvertToManaged((byte*)ptr);
	public static void FreeUTF8String(nint ptr) => Utf8StringMarshaller.Free((byte*)ptr);
}