using System;
using CppSourceGen.Attributes;
using OpenSteamworks.ConCommands.Interfaces;
using OpenSteamworks.Data;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data.Interop;

namespace OpenSteamworks.ConCommands.Native;

// ReSharper disable InconsistentNaming : C++ -style names.

[CppClass]
public unsafe interface INativeConVar : INativeConCommandBase
{
    public IntPtr m_pParent { get; set; }
    public CUtlString m_pszDefaultValue { get; }

    // Purpose unknown.
    public CUtlString m_utlString { get; }
    public bool m_bUtlStringSet { get; }

    // Purpose unknown, other than possibly having something to do with replicated vars. Don't seem to do anything important.
    public CUtlString m_replicatedWaitingString { get; }
    public int m_iReplicatedWaitingStringLength { get; }

    public CUtlString m_currentValue { get; }
    public int m_iCurrentValueLength { get; }

    // Purpose unknown. Filled by _some_ cvars, but seemingly never read.
    public CUtlString m_decimalValue { get; }

    public float m_flValue { get; }
    public int m_iValue { get; }
    public Int64 m_llValue { get; }
    public UInt64 m_ullValue { get; }
    public double m_dblValue { get; }

    // A couple of unknown arrays, which don't seem to do anything (meaningful).
    public int *pUnk { get; }
    public int *pUnk2 { get; }

    public bool m_bHasMax { get; }
    public float m_fMaxVal { get; }

    public bool m_bHasMin { get; }
    public float m_fMinVal { get; }

    public bool m_bIsDefaultValue { get; }
    public bool m_bIsReplicatedAndSet { get; }
    public bool m_bIsReplicatedSet { get; }
    public bool m_bUnkBool3 { get; }

    public CUtlVector<IntPtr> m_vecCallbacks { get; }
    
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
    
}