using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using OpenSteamClient.Logging;

namespace OpenSteamworks.Data;

/// <summary>
/// Creates a LessFunc for an IComparisonOperators value.
/// </summary>
public static class LessFuncFactory {
	private static readonly Dictionary<IntPtr, GCHandle> usedFuncs = new();

	/// <summary>
	/// Compare the two blocks of data for equality.
	/// </summary>
	/// <param name="firstPtr"></param>
	/// <param name="secondPtr"></param>
	/// <returns>1 if first parameter is less than the second, 0 otherwise.</returns>
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	delegate byte LessFunc(IntPtr firstPtr, IntPtr secondPtr);
	public static unsafe IntPtr CreateLessFunc<T>() where T: unmanaged, IComparisonOperators<T, T, bool> {
		LessFunc func = (first, second) => {
			if (first == IntPtr.Zero && second != IntPtr.Zero) {
				return 1;
			}

			if (first != IntPtr.Zero && second == IntPtr.Zero) {
				return 0;
			}

			if (first == IntPtr.Zero && second == IntPtr.Zero)
			{
				return 0;
			}
			
			return Convert.ToByte(*(T*)first < *(T*)second);
		};

		GCHandle handle = GCHandle.Alloc(func);
		IntPtr ptr = Marshal.GetFunctionPointerForDelegate(func);
		UtlLogging.UtlMap.Debug("Allocated LessFunc " + ptr);
		usedFuncs.Add(ptr, handle);
		return ptr;
	}
	
	public static void Free(IntPtr func) {
		if (!usedFuncs.TryGetValue(func, out GCHandle value)) {
			throw new ArgumentException("Func not found in usedFuncs");
		}

		UtlLogging.UtlMap.Debug("Freeing LessFunc " + func);
		value.Free();
		usedFuncs.Remove(func);
	}
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct CUtlMap<KeyType_t, ElemType_t>: IDisposable where KeyType_t : unmanaged, IComparisonOperators<KeyType_t, KeyType_t, bool> where ElemType_t : unmanaged {
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
	    m_Tree.m_Elements.ThrowIfDisposed();
	    
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
    public struct Node_t
	{
		public KeyType_t key;
		public ElemType_t elem;
	};

    [StructLayout(LayoutKind.Sequential)]
    public struct CKeyLess
	{
		public delegate* unmanaged[Cdecl]<KeyType_t*, KeyType_t*, byte> m_LessFunc;
	};
    
	public void Dispose()
	{
		m_Tree.m_Elements.ThrowIfDisposed();
		LessFuncFactory.Free((nint)m_Tree.m_LessFunc);
		m_Tree.Dispose();
	}
}