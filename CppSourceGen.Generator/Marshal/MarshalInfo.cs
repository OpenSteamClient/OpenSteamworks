using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CppSourceGen.Generator.Operations;
using Microsoft.CodeAnalysis;

namespace CppSourceGen.Generator.Marshal;

public sealed class MarshalInfo
{
    /// <summary>
    /// The source argument.
    /// This is a managed parameter.
    /// </summary>
    public VarOrArgInfo SourceArgument { get; }
    
    /// <summary>
    /// The marshalled variable.
    /// This is a native variable.
    /// </summary>
    public VarOrArgInfo MarshalledVariable { get; }
    
    /// <summary>
    /// All variables required by this marshaller.
    /// </summary>
    public IReadOnlyList<VarOrArgInfo> Variables { get; }
    
    public IReadOnlyList<MarshalOperation> ToNativeOperations { get; }
    public IReadOnlyList<MarshalOperation> ToManagedOperations { get; }
    public IReadOnlyList<MarshalOperation> CommonOperations { get; }
    
    /// <summary>
    /// Create a <see cref="MarshalInfo"/> with the specified conversions and variables.
    /// </summary>
    /// <param name="sourceVariable">The variable that is being marshalled. This must be the same as 'arg' in <see cref="IMarshaller.TryGetMarshalInfo"/></param>
    /// <param name="marshalledVariable">The native variable</param>
    /// <param name="variables">Any variables this marshalling depends on</param>
    /// <param name="toNativeOperations">Operations to convert a managed value to a native value</param>
    /// <param name="toManagedOperations">Operations to convert a native value to a managed value</param>
    /// <param name="commonOperations">Common operations for both ToNative and ToManaged, for example ProtobufHack allocations. These will happen once before the function call.</param>
    public MarshalInfo(VarOrArgInfo sourceVariable, VarOrArgInfo marshalledVariable, List<VarOrArgInfo> variables, IEnumerable<MarshalOperation> toNativeOperations,
        IEnumerable<MarshalOperation> toManagedOperations, IEnumerable<MarshalOperation>? commonOperations = null)
    {
        Variables = variables;
        SourceArgument = sourceVariable;
        MarshalledVariable = marshalledVariable;
        ToNativeOperations = toNativeOperations.ToList();
        ToManagedOperations = toManagedOperations.ToList();
        
        CommonOperations = commonOperations != null ? commonOperations.ToList() : [];
    }

    /// <summary>
    /// Wraps a managed-to-native function.
    /// You are expected to do:
    /// <code>
    /// try {
    /// // Contents of preCallBuilder
    /// // Your native call
    /// // Contents of postCallBuilder
    /// } finally {
    /// // Contents of finallyBuilder
    /// }
    /// </code>
    /// </summary>
    public void WrapMtoNFunction(StringBuilder preCallBuilder, StringBuilder postCallBuilder, StringBuilder finallyBuilder, StringBuilder definedVariablesBuilder, SourceProductionContext? context)
        => WrapFunction(preCallBuilder, postCallBuilder, finallyBuilder, definedVariablesBuilder, context, WrapType.ManagedToNative, false);
    
    /// <summary>
    /// Wraps a native-to-managed function.
    /// You are expected to do:
    /// <code>
    /// // Contents of definedVariablesBuilder
    /// try {
    /// // Contents of preCallBuilder
    /// // Your managed call
    /// // Contents of postCallBuilder
    /// } finally {
    /// // Contents of finallyBuilder
    /// }
    /// </code>
    /// </summary>
    public void WrapNtoMFunction(StringBuilder preCallBuilder, StringBuilder postCallBuilder, StringBuilder finallyBuilder, StringBuilder definedVariablesBuilder, SourceProductionContext? context)
        => WrapFunction(preCallBuilder, postCallBuilder, finallyBuilder, definedVariablesBuilder, context, WrapType.NativeToManaged, false);
    
    public void WrapFunction(StringBuilder preCallBuilder, StringBuilder postCallBuilder, StringBuilder finallyBuilder, StringBuilder definedVariablesBuilder, SourceProductionContext? context, WrapType wrapType, bool omitNativeToManagedVars)
    {
        bool marshalIn = SourceArgument.RefKind is RefKind.Ref or RefKind.In or RefKind.None;
        bool marshalOut = SourceArgument.RefKind is RefKind.Ref or RefKind.Out;

        IReadOnlyList<MarshalOperation> preOperations = new List<MarshalOperation>();
        IReadOnlyList<MarshalOperation> postOperations = new List<MarshalOperation>();
        switch (wrapType)
        {
            case WrapType.ManagedToNative:
                if (marshalIn)
                    preOperations = ToNativeOperations;
                
                if (marshalOut)
                    postOperations = ToManagedOperations;
                
                break;
            case WrapType.NativeToManaged:
                if (marshalIn)
                    preOperations = ToManagedOperations;
                
                if (marshalOut)
                    postOperations = ToNativeOperations;
                
                break;
        }

        // Add common operations here, before the main ops
        preOperations = CommonOperations.Concat(preOperations).ToList();

        var vars = Variables.AsEnumerable();
        if (wrapType == WrapType.NativeToManaged && omitNativeToManagedVars)
        {
            vars = vars.Concat([SourceArgument]).Except([MarshalledVariable]);
        }
        
        // Declare variables not declared by operations
        foreach (var var in vars.Except(preOperations.SelectMany(op => op.DeclaresVariables)).Concat(postOperations.SelectMany(op => op.DeclaresVariables)))
        {
            definedVariablesBuilder.AppendLine($"{var.GetVariableDeclaration()};");
        }

        List<Tuple<string, string, int>> calls = new();
        List<Tuple<string, string, int>> postCalls = new();
        
        StringBuilder subPreCallBuilder = new();
        StringBuilder subPostCallBuilder = new();
        foreach (var op in preOperations)
        {
            if (op is ErrorOperation errorOperation)
                errorOperation.Report(context);

            subPreCallBuilder.Length = 0;
            subPostCallBuilder.Length = 0;
            
            op.Build(subPreCallBuilder, subPostCallBuilder, finallyBuilder);
            calls.Add(new(subPreCallBuilder.ToString(), subPostCallBuilder.ToString(), op.IndentLevel));
        }
        
        foreach (var op in postOperations)
        {
            if (op is ErrorOperation errorOperation)
                errorOperation.Report(context);

            subPreCallBuilder.Length = 0;
            subPostCallBuilder.Length = 0;
            
            op.Build(subPreCallBuilder, subPostCallBuilder, finallyBuilder);
            postCalls.Add(new(subPreCallBuilder.ToString(), subPostCallBuilder.ToString(), op.IndentLevel));
        }

        // Order of calls: |PreOp.Pre|Op|PostOp.Pre|PostOp.Post|PreOp.Post
        int callIndent = 0;
        foreach (var call in calls)
        {
            foreach (var line in call.Item1.Split('\n'))
            {
                preCallBuilder.Append("\t".Repeat(callIndent));
                preCallBuilder.AppendLine(line);
            }
            
            callIndent += call.Item3;
        }
        
        foreach (var call in postCalls)
        {
            foreach (var line in call.Item1.Split('\n'))
            {
                postCallBuilder.Append("\t".Repeat(callIndent));
                postCallBuilder.AppendLine(line);
            }
            
            callIndent += call.Item3;
        }
        
        foreach (var call in postCalls)
        {
            callIndent -= call.Item3;
            foreach (var line in call.Item2.Split('\n'))
            {
                postCallBuilder.Append("\t".Repeat(callIndent));
                postCallBuilder.AppendLine(line);
            }
        }
        
        foreach (var call in calls)
        {
            callIndent -= call.Item3;
            foreach (var line in call.Item2.Split('\n'))
            {
                postCallBuilder.Append("\t".Repeat(callIndent));
                postCallBuilder.AppendLine(line);
            }
        }
    }
}