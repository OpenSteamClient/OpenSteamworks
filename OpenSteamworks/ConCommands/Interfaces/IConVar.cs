using System;

namespace OpenSteamworks.ConCommands.Interfaces;

public interface IConVar : IConCommandBase
{
    public bool IsDefault { get; }
    
    /// <summary>
    /// Set the value of all types in this CVar, attempting to parse them from the string.
    /// This is the definitive value, exactly how it was set.
    /// </summary>
    public string StringValue { get; set; }
    public float FloatValue { get; set; }
    public int IntValue { get; set; }
    public Int64 Int64Value { get; set; }
    public double DoubleValue { get; set; }
    public UInt64 UInt64Value { get; set; }
}