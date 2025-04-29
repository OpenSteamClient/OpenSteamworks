using System.Runtime.InteropServices;

namespace OpenSteamworks.Data.Interop;

[StructLayout(LayoutKind.Sequential)]
public struct CUtlVector<T> : IDisposable where T : unmanaged {
    private CUtlMemory<T> m_Memory;
    public int Size { get; private set; }
    
    public CUtlVector(int length, T defaultObject) {
        this.m_Memory = new CUtlMemory<T>(0, length);
        EnsureCapacity(length);
        for (int i = 0; i < length; i++)
        {
            this.m_Memory[i] = defaultObject;
        }
    }

    public CUtlVector() {
        this.Size = 0;
        this.m_Memory = new CUtlMemory<T>(0, this.Size);
    }
    
    public readonly T Element(int i)
    {
        m_Memory.ThrowIfDisposed();
        ArgumentOutOfRangeException.ThrowIfNegative(i);
        ArgumentOutOfRangeException.ThrowIfLessThan(this.Size, i);
        
        return m_Memory[i];
    }
    
    public readonly List<T> ToManaged() {
        m_Memory.ThrowIfDisposed();
        
        List<T> list = new();
        for (int i = 0; i < Size; i++)
        {
            list.Add(Element(i));
        }
        return list;
    }
    
    public T this[int i] {
        get => Element(i);
        set => Set(i, value);
    }

    public void Set(int i, T item)
    {
        m_Memory.ThrowIfDisposed();
        ArgumentOutOfRangeException.ThrowIfNegative(i);
        ArgumentOutOfRangeException.ThrowIfLessThan(this.Size, i);
        
        m_Memory[i] = item;
    }

    public void Add(T item)
    {
        m_Memory.ThrowIfDisposed();
        
        EnsureCapacity(Size + 1);
        Set(Size, item);
        m_Memory[Size] = item;
    }
    
    public void Dispose()
    {
        m_Memory.Dispose();
    }
    
    public void EnsureCapacity(int count)
    {
        int sizeDiff = count - Size;
        if (sizeDiff < 0)
            return;
        
        m_Memory.Grow(sizeDiff);
        Size += sizeDiff;
    }
}

/// <summary>
/// A CUtlVector&lt;CUtlString&gt;. Provided as a convenience so we can convert to a managed string list easily.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct CUtlStringList : IDisposable
{
    private CUtlVector<CUtlString> m_vec;
    public CUtlStringList(int length)
    {
        this.m_vec = new(length, CUtlString.Null);
    }

    public CUtlStringList(IEnumerable<string> existingList)
    {
        var list = existingList.ToList();
        this.m_vec = new CUtlVector<CUtlString>(list.Count, CUtlString.Null);
        for (int i = 0; i < list.Count; i++)
        {
            m_vec[i] = new CUtlString(list[i]);
        }
    }

    public CUtlStringList() {
        this.m_vec = new();
    }

    public int Size => m_vec.Size;

    public void EnsureCapacity(int count)
        => m_vec.EnsureCapacity(count);

    public readonly CUtlString Element(int i)
        => m_vec.Element(i);
    
    public void Add(string str)
    {
        m_vec.Add(new CUtlString(str));
    }
    
    public readonly List<string> ToManaged()
    {
        return this.m_vec.ToManaged().Select(utlString => utlString.ToManaged()).OfType<string>().ToList();
    }

    public void Dispose()
    {
        for (int i = 0; i < this.m_vec.Size; i++)
        {
            Element(i).Dispose();
        }
        
        m_vec.Dispose();
    }
}