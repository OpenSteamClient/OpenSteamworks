using System;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;
using System.Globalization;
using System.Diagnostics;

namespace OpenSteamworks.Data.Structs;

[DebuggerDisplay("{Value}")]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct JobID : System.IEquatable<JobID>, System.IComparable<JobID>
{
    public static readonly JobID Zero = new(0);
    public static readonly DateTime Epoch = new(2005, 1, 1);

    [field: MarshalAs(UnmanagedType.U8)]
    public ulong Value { get; set; }

    public JobID(uint boxid, uint processid, DateTime startTime, uint sequentialCount)
    {
        Set(boxid, processid, startTime, sequentialCount);
    }

    public JobID(ulong val)
    {
        Value = val;
    }

    public void Set(uint boxid, uint processid, DateTime startTime, uint sequentialCount)
    {
        BoxID = boxid;
        ProcessID = processid;
        StartTime = startTime;
        Sequential = sequentialCount;
    }

    public uint BoxID
    {
        get { return (uint)this[54, 0x3FF]; }
        set { this[54, 0x3FF] = (ulong)value; }
    }

    public uint ProcessID
    {
        get { return (uint)this[50, 0xF]; }
        set { this[50, 0xF] = (ulong)value; }
    }

    public DateTime StartTime
    {
        get
        {
            uint startTime = (uint)this[20, 0x3FFFFFFF];
            return Epoch.AddSeconds(startTime);
        }
        set
        {
            uint startTime = (uint)value.Subtract(Epoch).TotalSeconds;
            this[20, 0x3FFFFFFF] = (ulong)startTime;
        }
    }

    public uint Sequential
    {
        get { return (uint)this[0, 0xFFFFF]; }
        set { this[0, 0xFFFFF] = (ulong)value; }
    }

    private ulong this[uint bitoffset, ulong valuemask]
    {
        get => (Value >> (ushort)bitoffset) & valuemask;
        set => Value = (Value & ~(valuemask << (ushort)bitoffset)) | ((value & valuemask) << (ushort)bitoffset);
    }

    public bool IsValid()
    {
        return Value != 0;
    }

    public override string ToString()
    {
        return Value.ToString();
    }

    public override bool Equals(object? other)
    {
        return other is not null && other is JobID id && this.Value == id.Value;
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static bool operator ==(JobID x, JobID y)
    {
        return x.Value == y.Value;
    }

    public static bool operator !=(JobID x, JobID y)
    {
        return !(x == y);
    }

    public static implicit operator JobID(ulong value)
    {
        return new JobID(value);
    }
    public static implicit operator ulong(JobID that)
    {
        return that.Value;
    }

    public bool Equals(JobID other)
    {
        return Value == other.Value;
    }

    public int CompareTo(JobID other)
    {
        return Value.CompareTo(other.Value);
    }
}