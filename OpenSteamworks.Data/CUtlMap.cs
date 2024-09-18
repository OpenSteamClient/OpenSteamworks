using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using OpenSteamClient.Logging;

namespace OpenSteamworks.Data;

/// <summary>
/// Creates a LessFunc for an IComparisonOperators value.
/// </summary>
public class LessFuncFactory {
	private static Dictionary<IntPtr, GCHandle> usedFuncs = new();

	/// <summary>
	/// Compare the two blocks of data for equality.
	/// </summary>
	/// <param name="firstPtr"></param>
	/// <param name="secondPtr"></param>
	/// <returns>1 if first parameter is less than the second, 0 otherwise.</returns>
	delegate byte LessFunc(IntPtr firstPtr, IntPtr secondPtr);
	public static unsafe IntPtr CreateLessFunc<T>() where T: unmanaged, IComparisonOperators<T, T, bool> {
		var type = typeof(T);
		var func = new LessFunc(new Func<IntPtr, IntPtr, byte>((IntPtr firstPtr, IntPtr secondPtr) => {
			if (firstPtr == IntPtr.Zero && secondPtr != IntPtr.Zero) {
				return 1;
			}

			if (firstPtr != IntPtr.Zero && secondPtr == IntPtr.Zero) {
				return 0;
			}

			T first = *(T*)firstPtr;
			T second = *(T*)secondPtr;
			
			return Convert.ToByte(first < second);
		}));

		GCHandle handle = GCHandle.Alloc(func);
		IntPtr ptr = Marshal.GetFunctionPointerForDelegate<LessFunc>(func);
		UtlLogging.UtlMap.Debug("Allocated LessFunc " + ptr);
		usedFuncs.Add(ptr, handle);
		return ptr;
	}
	public static unsafe void Free(IntPtr func) {
		if (!usedFuncs.TryGetValue(func, out GCHandle value)) {
			throw new ArgumentException("Func not found in usedFuncs");
		}

		UtlLogging.UtlMap.Debug("Freeing LessFunc " + func);
		value.Free();
		usedFuncs.Remove(func);
	}
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct CUtlMap<KeyType_t, ElemType_t> where KeyType_t : unmanaged, IComparisonOperators<KeyType_t, KeyType_t, bool> where ElemType_t : unmanaged {
    public CUtlRBTree<Node_t, int, KeyType_t, CKeyLess> m_Tree;

	/// <summary>
	/// Creates a new CUtlMap
	/// </summary>
	/// <param name="growSize"></param>
	/// <param name="initSize"></param>
    public CUtlMap(int growSize = 0, int initSize = 0) {
        this.m_Tree = new CUtlRBTree<Node_t, int, KeyType_t, CKeyLess>(-1, 0, 1, growSize, initSize, (delegate* unmanaged[Cdecl]<KeyType_t*, KeyType_t*, byte>)LessFuncFactory.CreateLessFunc<KeyType_t>());
    }

	public Dictionary<KeyType_t, ElemType_t> ToManaged()
    {
        var dict = new Dictionary<KeyType_t, ElemType_t>();
		for (int i = 0; i < this.Count(); i++)
		{
			var node = Node(i);
			// Dictionaries are meant to be unique. Maps are meant to be unique. Are CUtlMaps? They can sometimes contain two of the same element though...
			if (dict.ContainsKey(node.key)) {
                UtlLogging.UtlMap.Warning("Skipping duplicate key " + node.key + " in CUtlMap.ToManaged. Incorrect datatype lengths?");
                continue;
            }
			dict.Add(node.key, node.elem);
		}
		
		return dict;
    }

    public Dictionary<KeyType_t, ElemType_t> ToManagedAndFree() {
        var dict = this.ToManaged();
        this.Free();
        return dict;
    }

	public void Free() {
		LessFuncFactory.Free((nint)this.m_Tree.m_LessFunc);
		this.m_Tree.Free();
	}

	public ElemType_t Element( int i ) { 
		return m_Tree.Element( i ).elem; 
	}

	public Node_t Node( int i ) { 
		return m_Tree.Element( i ); 
	}

	public int Count() {
        return m_Tree.Count();
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct Node_t
	{
		public Node_t()
		{
		}

		public Node_t( Node_t from )
		{
            this.key = from.key;
            this.elem = from.elem;
		}

		public KeyType_t key;
		public ElemType_t elem;
	};

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct CKeyLess
	{
		public CKeyLess( delegate* unmanaged[Cdecl]<KeyType_t*, KeyType_t*, byte> lessFunc ) {
            this.m_LessFunc = lessFunc;
        }
		public delegate* unmanaged[Cdecl]<KeyType_t*, KeyType_t*, byte> m_LessFunc;
	};
}