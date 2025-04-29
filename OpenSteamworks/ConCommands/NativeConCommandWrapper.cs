using System;
using System.Collections.Generic;
using CppSourceGen;
using OpenSteamworks.ConCommands.Interfaces;
using OpenSteamworks.ConCommands.Native;
using OpenSteamworks.Data;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data.Interop;

namespace OpenSteamworks.ConCommands;

internal abstract class NativeConCommandBaseWrapper : IConCommandBase
{ 
    private readonly INativeConCommandBase nativeBase;

    protected NativeConCommandBaseWrapper(INativeConCommandBase nativeBase)
    {
        this.nativeBase = nativeBase;
    }

    public string Name
        => nativeBase.GetName();

    public string? HelpText
        => nativeBase.GetHelpText();

    public bool IsCommand
        => nativeBase.BIsCommand();

    public ConCommandFlags_t Flags
        => nativeBase.GetFlags();

    public bool IsRegistered
        => nativeBase.BRegistered();

    public void Register()
        => nativeBase.Register();

    internal static IConCommandBase CreateFromNative(INativeConCommandBase impl)
    {
        if (impl.BIsCommand())
            return new NativeConCommandWrapper(
                MarshallableClasses.Create_INativeConCommand(impl.ObjectPtr, impl.MetadataObject));
        
        return new NativeConVarWrapper(MarshallableClasses.Create_INativeConVar(impl.ObjectPtr, impl.MetadataObject));
    }
}

internal sealed class NativeConCommandWrapper : NativeConCommandBaseWrapper, IConCommand
{
    private readonly INativeConCommand nativeConCommand;
    
    public NativeConCommandWrapper(INativeConCommand nativeConCommand) : base(nativeConCommand)
    {
        this.nativeConCommand = nativeConCommand;
    }

    public bool SupportsCompletion
        => nativeConCommand.BHasCompletionCallback();
    
    public void RunCompletion(in CCommand partial, out IEnumerable<string> suggestions)
    {
        var stringList = new CUtlStringList();
        try
        {
            nativeConCommand.RunCompletion(in partial, ref stringList);
            suggestions = stringList.ToManaged();
        }
        finally
        {
            stringList.Dispose();   
        }
    }

    public void Invoke(in CCommand args)
        => nativeConCommand.Invoke(in args);
}

internal sealed class NativeConVarWrapper : NativeConCommandBaseWrapper, IConVar
{
    private readonly INativeConVar nativeConVar;
    internal NativeConVarWrapper(INativeConVar native) : base(native)
    {
        this.nativeConVar = native;
    }

    public float FloatValue
    {
        get => nativeConVar.m_flValue;
        set => nativeConVar.SetValue(value);
    }
    
    public int IntValue 
    {
        get => nativeConVar.m_iValue;
        set => nativeConVar.SetValue(value);
    }
    
    public long Int64Value
    {
        get => nativeConVar.m_llValue;
        set => nativeConVar.SetValue(value);
    }
    
    public ulong UInt64Value
    {
        get => nativeConVar.m_ullValue;
        set => nativeConVar.SetValue(value);
    }
    
    public double DoubleValue
    {
        get => nativeConVar.m_dblValue;
        set => nativeConVar.SetValue(value);
    }

    public bool IsDefault
        => nativeConVar.BIsDefaultValue();

    public string StringValue
    {
        get => nativeConVar.m_currentValue.ToString();
        set => nativeConVar.m_currentValue.Set(value);
    }
}