using System.Runtime.InteropServices;
// ReSharper disable InconsistentNaming

namespace OpenSteamworks.Data;

[StructLayout(LayoutKind.Sequential)]
public struct UtlRBTreeNode_t<T, I> where I : unmanaged where T : unmanaged
{
	public I m_Left;
	public I m_Right;
	public I m_Parent;
	public I m_Tag;
    public T m_Data;
};

[StructLayout(LayoutKind.Sequential)]
public unsafe struct CUtlRBTree<T, I, LessFuncType_t, M>: IDisposable where T : unmanaged where I : unmanaged where LessFuncType_t : unmanaged where M : unmanaged {
    // used in Links as the return value for InvalidIndex()
    public Links_t<I> m_Sentinel;
    public EmptyBaseOpt_t m_data;
	public I m_Root;
	public I m_NumElements;
	public I m_FirstFree;
    public I m_TotalElements;

    // Less func:
	// Returns true if the first parameter is "less" than the second
	public delegate* unmanaged[Cdecl]<LessFuncType_t*, LessFuncType_t*, byte> m_LessFunc;
	public CUtlMemory<UtlRBTreeNode_t<T, I>> m_Elements;

    // Have to do this hackyness to compensate for not being able to constrict to number types
    public CUtlRBTree(I INVALID_RBTREE_IDX, I zero, I one, int growSize, int initSize, delegate* unmanaged[Cdecl]<LessFuncType_t*, LessFuncType_t*, byte> lessfunc) {
        // CUtlRBTreeBase initialization
        unchecked {
            m_Root = INVALID_RBTREE_IDX;
            m_NumElements = zero;
	        m_TotalElements = zero;
            m_FirstFree = INVALID_RBTREE_IDX;
            m_Sentinel.m_Left = INVALID_RBTREE_IDX;
            m_Sentinel.m_Right = INVALID_RBTREE_IDX;
            m_Sentinel.m_Parent = INVALID_RBTREE_IDX;
            m_Sentinel.m_Tag = one;
        }

        // CUtlRBTree initialization
        m_LessFunc = lessfunc;
        m_Elements = new CUtlMemory<UtlRBTreeNode_t<T, I>>(growSize, initSize);
        ResetDbgInfo(m_Elements.Pointer);
    }

    private void ResetDbgInfo( void *pMemBase )
	{
		m_data.m_pElements = pMemBase;
	}

    public T Element( int i )        
    { 
        return m_Elements[i].m_Data; 
    }

    public T Element( ushort i )        
    { 
        return m_Elements[i].m_Data; 
    }

    public I Count() {
        return m_NumElements;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Links_t<I2> where I2 : unmanaged
	{
		public I2 m_Left;
		public I2 m_Right;
		public I2 m_Parent;
		public I2 m_Tag;
	};

    [StructLayout(LayoutKind.Sequential)]
    public struct EmptyBaseOpt_t
	{
		public void* m_pElements;
	};
    
	public void Dispose()
	{
		m_Elements.Dispose();
	}
}