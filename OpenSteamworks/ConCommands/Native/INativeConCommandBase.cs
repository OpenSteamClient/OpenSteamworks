using System;
using CppSourceGen.Attributes;
using OpenSteamworks.Data.Enums;

namespace OpenSteamworks.ConCommands.Native;

// ReSharper disable InconsistentNaming : C++ -style names.

[CppClass]
public unsafe interface INativeConCommandBase
{
    protected IntPtr m_pNext { get; set; }
    protected byte m_bRegistered { get; set; }
    protected IntPtr m_pszName { get; set; }
    protected IntPtr m_pszDescription { get; set; }
    protected UInt64 m_nFlags { get; set; }
    
    public void Dtor();
#if !_WINDOWS
    public void Dtor2();
#endif

    public bool BIsCommand();
    public bool IsFlagSet(ConCommandFlags_t flag);
    public void AddFlags(ConCommandFlags_t flags);
    public UInt64 GetFlagsRaw();
    public ConCommandFlags_t GetFlags();
    public string GetName();
    public string? GetHelpText();
    public bool BRegistered();
    public void Register();
}