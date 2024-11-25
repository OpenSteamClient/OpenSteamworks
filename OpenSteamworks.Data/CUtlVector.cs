using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace OpenSteamworks.Data;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct CUtlVector<T> where T : unmanaged {
    public CUtlMemory<T> m_Memory;
    public int m_Size;
    public CUtlVector(int length, T defaultObject) {
        this.m_Size = length;
        this.m_Memory = new CUtlMemory<T>(0, this.m_Size);
        unsafe {
            for (int i = 0; i < length; i++)
            {
                this.Base()[i] = defaultObject;
            }
        }
    }

    public CUtlVector() {
        this.m_Size = 0;
        this.m_Memory = new CUtlMemory<T>(0, this.m_Size);
    }

    public T* Base() {
        return (T*)m_Memory.m_pMemory;
    }
    public T Element(int i) {
        unsafe {
            return Base()[i];
        }
    }

    public void Free() {
        this.m_Memory.Free();
    }

    public List<T> ToManagedAndFree() {
        var str = this.ToManaged();
        this.Free();
        return str;
    }
    public List<T> ToManaged() {
        List<T> list = new();
        for (int i = 0; i < this.m_Size; i++)
        {
            list.Add(this.Element(i));
        }
        return list;
    }

    public void Add(T item)
    {
        m_Memory.Grow(1);
        m_Size++;
        m_Memory[m_Size] = item;
    }
}

/// <summary>
/// A CUtlVector&lt;CUtlString&gt;. Provided as a convenience so we can convert to a native string list easily.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct CUtlStringList
{
    public CUtlVector<CUtlString> m_vec;
    public CUtlStringList(int length)
    {
        this.m_vec = new(length, new());
    }

    public CUtlStringList() {
        this.m_vec = new();
    }

    public CUtlString* Base()
        => m_vec.Base();
       
    public CUtlString Element(int i)
        => m_vec.Element(i);

    public void Free() {
        for (int i = 0; i < this.m_vec.m_Size; i++)
        {
            this.Element(i).Free();
        }
        
        m_vec.Free();
    }

    public void Add(string str)
    {
        m_vec.Add(new CUtlString(str));
    }

    public List<string> ToManagedAndFree() {
        var str = this.ToManaged();
        this.Free();
        return str;
    }
    
    public List<string> ToManaged() {
        List<string> list = new();
        foreach (var utlString in this.m_vec.ToManaged())
        {
            var elem = utlString.ToManaged();
            if (elem == null) {
                continue;
            }

            list.Add(elem);
        }        
        
        return list;
    }
}