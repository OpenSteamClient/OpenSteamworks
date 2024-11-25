using System;
using CppSourceGen.Attributes;
using OpenSteamworks.ConCommands.Interfaces;
using OpenSteamworks.Data;

namespace OpenSteamworks.ConCommands.Native;

// ReSharper disable InconsistentNaming : C++ -style names.

public unsafe interface INativeConVar_Ext
{
    public float FloatValue { get; set; }
    public int IntValue { get; set; }
    public Int64 Int64Value { get; set; }
    public UInt64 UInt64Value { get; set; }
    public double DoubleValue { get; set; }
}

[CppClass]
public unsafe interface INativeConVar : INativeConCommandBase, INativeConVar_Ext
{
    protected IntPtr m_pParent { get; set; }
    protected CUtlString m_pszDefaultValue { get; }

    // Purpose unknown.
    protected CUtlString m_utlString { get; }
    protected bool m_bUtlStringSet { get; }

    // Purpose unknown, other than possibly having something to do with replicated vars. Don't seem to do anything important.
    protected CUtlString m_replicatedWaitingString { get; }
    protected int m_iReplicatedWaitingStringLength { get; }

    protected CUtlString m_currentValue { get; }
    protected int m_iCurrentValueLength { get; }

    // Purpose unknown. Filled by _some_ cvars, but seemingly never read.
    protected CUtlString m_decimalValue { get; }

    protected float m_flValue { get; }
    protected int m_iValue { get; }
    protected Int64 m_llValue { get; }
    protected UInt64 m_ullValue { get; }
    protected double m_dblValue { get; }

    // A couple of unknown arrays, which don't seem to do anything (meaningful).
    protected int *pUnk { get; }
    protected int *pUnk2 { get; }

    protected bool m_bHasMax { get; }
    protected float m_fMaxVal { get; }

    protected bool m_bHasMin { get; }
    protected float m_fMinVal { get; }

    protected bool m_bIsDefaultValue { get; }
    protected bool m_bIsReplicatedAndSet { get; }
    protected bool m_bIsReplicatedSet { get; }
    protected bool m_bUnkBool3 { get; }

    protected CUtlVector<IntPtr> m_vecCallbacks { get; }
    
    public bool SetValue(string val);
    public bool SetValue(float val);
    public bool SetValue(int val);
    public bool SetValue(Int64 val);
    public bool SetValue(double val);
    public bool SetValue(UInt64 val);
    public void Unk1();
    public void Validate(IntPtr cValidator);
    public bool BIsDefaultValue();
    public void SetIsDefaultValue();
    public void SetIsNotDefaultValue();
    
    // These are absolutely not accurate. I haven't got the slightest clue what these could be. Replicated convar stuff?
    // Replicated convars aren't even used in Steam, so this is basically useless.
    public bool BIsReplicatedValueSet();

    public bool BGetUnk3();
    public void SetUnk3_True();
    public void SetUnk3_False();
    public void SetReplicatedWaitingValue(string val, bool bSetValue, bool bIsNotDefault);
    public void SetUnkUtlString(string val);
    public void InternalSetValue(string val);
    public void InternalSetValue(float flValue);
    public void InternalSetValue(int iValue);
    public void InternalSetValue(Int64 lValue);
    public void InternalSetValue(UInt64 ullValue);
    public void InternalSetValue(double dValue);
    public bool ClampValue(ref float flValue);
    public void ChangeStringValue(string val);
}

internal unsafe partial class INativeConVar_Impl
{
    public float FloatValue
    {
        get => m_flValue;
        set => SetValue(value);
    }
    
    public int IntValue 
    {
        get => m_iValue;
        set => SetValue(value);
    }
    
    public long Int64Value
    {
        get => m_llValue;
        set => SetValue(value);
    }
    
    public ulong UInt64Value
    {
        get => m_ullValue;
        set => SetValue(value);
    }
    
    public double DoubleValue
    {
        get => m_dblValue;
        set => SetValue(value);
    }

    public bool IsDefault
        => BIsDefaultValue();
}

// internal unsafe partial class INativeConVar_Impl : IConVar
// {
//     
// }