using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using CppSourceGen.Generator.Marshal;
using Microsoft.CodeAnalysis;

namespace CppSourceGen.Generator;

public class NativeMarshalGenerator
{
    public const string THROW_ON_REMOTE_PIPE_ATTRIBUTE = "OpenSteamworks.Attributes.BlacklistedInCrossProcessIPCAttribute";

    public VarOrArgInfo RefNative { get; }
    public VarOrArgInfo? VTPtr { get; }
    public TypeInfo InterfaceType { get; }
    public TypeInfo TargetType { get; }


    private readonly SourceProductionContext? context;

    private readonly WrapType wrapType;
    public NativeMarshalGenerator(SourceProductionContext? context, NativeCppClass nativeCppClass)
    {
        this.wrapType = WrapType.ManagedToNative;
        this.context = context;

        this.RefNative = new VarOrArgInfo(nativeCppClass.NativeStruct.Type, "this", isStatic: false, hasGetter: true, hasSetter: true, refKind: RefKind.Ref);
        this.VTPtr = nativeCppClass.VTPtr;
        this.InterfaceType = nativeCppClass.Interface;
        this.TargetType = nativeCppClass.WrapperClass.Type;
    }

    public NativeMarshalGenerator(SourceProductionContext? context, NativeCppClassImpl nativeCppClassImpl)
    {
        this.wrapType = WrapType.NativeToManaged;
        this.RefNative = new VarOrArgInfo(TypeInfo.MakePointerType(nativeCppClassImpl.NativeStruct), "native", isStatic: false, hasGetter: true, hasSetter: true, refKind: RefKind.None);
        this.InterfaceType = nativeCppClassImpl.InterfaceType;
        this.TargetType = nativeCppClassImpl.WrapperClass.Type;
    }

    private readonly HashSet<string> usedNames = new();
    public VarOrArgInfo GenerateMarshal(FunctionInfo managedFunc, out string marshalBody, out FunctionInfo nativeToManagedFuncInfo)
    {
        StringBuilder definedVariablesBuilder = new();
        StringBuilder preCallBuilder = new();
        StringBuilder postCallBuilder = new();
        StringBuilder finallyBuilder = new();

        var fnPtrArgs = new List<VarOrArgInfo>();
        var nativeArgs = new List<VarOrArgInfo>();

        var orderedArguments = new Dictionary<int, VarOrArgInfo>();

        bool hasArgOrder = false;
        if (managedFunc.TryGetAttribute(CppClassMarshaller.MANUAL_ARGUMENT_ORDER_ATTRIBUTE_NAME, out var argumentOrderAttr))
        {
            hasArgOrder = true;
            orderedArguments[argumentOrderAttr!.ConstructorArguments.First().GetValue<int>(context)] = RefNative;
        }
        else
        {
            nativeArgs.Add(RefNative);
        }

        var returnWrapType = WrapType.NativeToManaged;
        if (wrapType == WrapType.NativeToManaged)
        {
            returnWrapType = WrapType.ManagedToNative;
            preCallBuilder.AppendLine($"var wrapper = CppClassMarshal.GetManagedForPtr<{TargetType.FullName}>(native);");
        }

        foreach (var managedArg in managedFunc.Arguments)
        {
            var marshaller = Marshallers.GetMarshalInfo(managedArg);

            if (managedArg.TryGetAttribute(CppClassMarshaller.MANUAL_ARGUMENT_ORDER_ATTRIBUTE_NAME, out argumentOrderAttr))
            {
                var idx = argumentOrderAttr!.ConstructorArguments.First().GetValue<int>(context);
                if (orderedArguments.TryGetValue(idx, out var otherArg))
                {
                    context?.ReportDiagnostic(Diagnostic.Create("CPP003", "Arguments", $"Argument {managedArg.Name} index {idx} conflicts with other argument {otherArg.Name}. Overriding.", DiagnosticSeverity.Warning, DiagnosticSeverity.Warning, true, 1));
                }

                orderedArguments[idx] = marshaller.MarshalledVariable;
            }
            else if (hasArgOrder)
            {
                context?.ReportDiagnostic(Diagnostic.Create("CPP002", "Arguments", $"Method tagged with {CppClassMarshaller.MANUAL_ARGUMENT_ORDER_ATTRIBUTE_NAME}, but argument {managedArg.Name} is missing the attribute.", DiagnosticSeverity.Error, DiagnosticSeverity.Error, true, 0));
            }
            else
            {
                nativeArgs.Add(marshaller.MarshalledVariable);
            }

            marshaller.WrapFunction(preCallBuilder, postCallBuilder, finallyBuilder, definedVariablesBuilder, context, wrapType, true);
        }

        var managedReturn = new VarOrArgInfo(managedFunc.ReturnType ?? TypeInfo.VoidType, "ret", refKind: managedFunc.ReturnRefKind);
        var returnMarshal = Marshallers.GetMarshalInfo(managedReturn);

        if (managedReturn.Type != TypeInfo.VoidType && managedFunc.ReturnRefKind == RefKind.None)
            definedVariablesBuilder.AppendLine($"{managedReturn.GetVariableDeclaration()};");

        returnMarshal.WrapFunction(postCallBuilder, postCallBuilder, finallyBuilder, definedVariablesBuilder, context, returnWrapType, false);

        if (nativeArgs.Count == 0)
        {
            nativeArgs.AddRange(orderedArguments.OrderBy(a => a.Key).Select(a => a.Value));
        }

        fnPtrArgs.AddRange(nativeArgs);
        fnPtrArgs.Add(returnMarshal.MarshalledVariable);

        var usedName = managedFunc.Name;
        while (usedNames.Contains(usedName))
        {
            var lastNum = usedName.Replace(managedFunc.Name, "");
            if (!int.TryParse(lastNum, out int num))
            {
                usedName += "1";
                continue;
            }

            num++;
            usedName = $"{managedFunc.Name}{num.ToString()}";
        }

        string initializer = "";
        if (wrapType == WrapType.NativeToManaged)
        {
            initializer = $"&{usedName}";
        }

        nativeToManagedFuncInfo = new FunctionInfo(usedName, nativeArgs, returnMarshal.MarshalledVariable.Type);

        var nativeFuncPtr = new VarOrArgInfo(TypeInfo.MakeUnmanagedDelegateType(fnPtrArgs, SignatureCallingConvention.ThisCall), usedName + "VTPtr", initializer);
        usedNames.Add(usedName);

        string nativeRetStr = "";
        string managedRetStr = "";
        if (managedReturn.Type != TypeInfo.VoidType)
        {
            if (managedFunc.ReturnRefKind != RefKind.None)
            {
                nativeRetStr = $"{managedFunc.RetRefKindString()}var {returnMarshal.MarshalledVariable.Name} = {managedFunc.RetRefKindString()}";
                managedRetStr = $"{managedFunc.RetRefKindString()}var {returnMarshal.SourceArgument.Name} = {managedFunc.RetRefKindString()}";
            }
            else
            {
                nativeRetStr = $"{returnMarshal.MarshalledVariable.Name} = ";
                managedRetStr = $"{returnMarshal.SourceArgument.Name} = ";
            }



            if (wrapType == WrapType.NativeToManaged)
            {
                postCallBuilder.AppendLine($"return {managedFunc.RetRefKindString()}{returnMarshal.MarshalledVariable.Name};");
            } else if (wrapType == WrapType.ManagedToNative)
            {
                postCallBuilder.AppendLine($"return {managedFunc.RetRefKindString()}{managedReturn.Name};");
            }
        }

        StringBuilder builder = new();

        bool hasFinally = finallyBuilder.Length > 0;
        string indent = hasFinally ? "\t" : "";

        void AppendLineIndented(string lines)
        {
            foreach (var line in lines.Split('\n'))
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                builder.AppendLine(indent + line);
            }
        }

        if (definedVariablesBuilder.Length > 0)
            builder.AppendLine(definedVariablesBuilder.ToString());

        if (hasFinally)
        {
            builder.AppendLine("try {");
        }

        if (preCallBuilder.Length > 0)
            AppendLineIndented(preCallBuilder.ToString());

        AppendLineIndented($"OpenSteamworks.SteamClient.OnInterfaceCall(wrapper, \"{InterfaceType.Name}\", \"{managedFunc.Name}\");");

        if (managedFunc.TryGetAttribute(THROW_ON_REMOTE_PIPE_ATTRIBUTE, out _))
        {
            AppendLineIndented("OpenSteamworks.SteamClient.ThrowIfRemotePipe(wrapper);");
        }

        if (wrapType == WrapType.ManagedToNative)
        {
            AppendLineIndented($"{nativeRetStr}{VTPtr!.AccessMember(nativeFuncPtr.Name)}({string.Join(", ", nativeArgs.Select(n => n.AsFedParam()))});");
        } else if (wrapType == WrapType.NativeToManaged)
        {
            AppendLineIndented($"{managedRetStr}wrapper.{managedFunc.Name}({string.Join(", ", managedFunc.Arguments.Select(n => n.AsFedParam()))});");
        }

        if (postCallBuilder.Length > 0)
            AppendLineIndented(postCallBuilder.ToString());

        if (hasFinally)
        {
            builder.AppendLine("} finally {");
            AppendLineIndented(finallyBuilder.ToString());
            builder.AppendLine("}");
        }

        marshalBody = builder.ToString();
        return nativeFuncPtr;
    }

    public string GenerateSetter(VarOrArgInfo nativeVar, TypeInfo managedType)
    {
        StringBuilder definedVariablesBuilder = new();
        StringBuilder preCallBuilder = new();
        StringBuilder postCallBuilder = new();
        StringBuilder finallyBuilder = new();

        VarOrArgInfo valueArg = new VarOrArgInfo(managedType, "value");

        var marshalInfo = Marshallers.GetMarshalInfo(valueArg);
        marshalInfo.WrapMtoNFunction(preCallBuilder, postCallBuilder, finallyBuilder, definedVariablesBuilder, context);

        StringBuilder builder = new();

        bool hasFinally = finallyBuilder.Length > 0;
        int indent = 1;

        void AppendLineIndented(string lines)
        {
            foreach (var line in lines.Split('\n'))
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                builder.AppendLine("\t".Repeat(indent) + line);
            }
        }

        AppendLineIndented("set {");
        indent++;

        if (definedVariablesBuilder.Length > 0)
            AppendLineIndented(definedVariablesBuilder.ToString());

        if (hasFinally)
        {
            AppendLineIndented("try {");
            indent++;
        }

        if (preCallBuilder.Length > 0)
            AppendLineIndented(preCallBuilder.ToString());

        AppendLineIndented($"{nativeVar.Name} = {marshalInfo.MarshalledVariable.Name};");

        if (postCallBuilder.Length > 0)
            AppendLineIndented(postCallBuilder.ToString());

        if (hasFinally)
        {
            indent--;
            AppendLineIndented("} finally {");
            indent++;
            AppendLineIndented(finallyBuilder.ToString());
            indent--;
            AppendLineIndented("}");
        }

        indent--;
        AppendLineIndented("}");

        return builder.ToString();
    }

    public string GenerateGetter(VarOrArgInfo nativeVar, TypeInfo managedType)
    {
        StringBuilder definedVariablesBuilder = new();
        StringBuilder preCallBuilder = new();
        StringBuilder postCallBuilder = new();
        StringBuilder finallyBuilder = new();

        var retVar = new VarOrArgInfo(managedType, "ret", refKind: RefKind.Out);
        var marshalInfo = Marshallers.GetMarshalInfo(retVar);

        definedVariablesBuilder.AppendLine($"{retVar.Type.KeywordName} {retVar.Name};");

        preCallBuilder.AppendLine($"{marshalInfo.MarshalledVariable.Name} = {nativeVar.Name};");
        marshalInfo.WrapMtoNFunction(preCallBuilder, postCallBuilder, finallyBuilder, definedVariablesBuilder, context);

        StringBuilder builder = new();

        bool hasFinally = finallyBuilder.Length > 0;
        int indent = 1;

        void AppendLineIndented(string lines)
        {
            foreach (var line in lines.Split('\n'))
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                builder.AppendLine("\t".Repeat(indent) + line);
            }
        }

        AppendLineIndented("get {");
        indent++;

        if (definedVariablesBuilder.Length > 0)
            AppendLineIndented(definedVariablesBuilder.ToString());

        if (hasFinally)
        {
            AppendLineIndented("try {");
            indent++;
        }

        if (preCallBuilder.Length > 0)
            AppendLineIndented(preCallBuilder.ToString());

        if (postCallBuilder.Length > 0)
            AppendLineIndented(postCallBuilder.ToString());

        AppendLineIndented($"return {retVar.Name};");

        if (hasFinally)
        {
            indent--;
            AppendLineIndented("} finally {");
            indent++;
            AppendLineIndented(finallyBuilder.ToString());
            indent--;
            AppendLineIndented("}");
        }

        indent--;
        AppendLineIndented("}");

        return builder.ToString();
    }
}
