using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SourceGeneratorsKit;

[Generator]
public class NativeClassSourceGenerator : IIncrementalGenerator
{
	public const string CPP_INTERFACE_ATTRIBUTE_NAME = "CppSourceGen.Attributes.CppClassAttribute";
	public const string CROSSPROC_IPC_BLOCKED_ATTRIBUTE_NAME = "OpenSteamworks.Attributes.BlacklistedInCrossProcessIPCAttribute";
	
	private static string DetermineNativeReturnType(IMethodSymbol managedFunction) {
		if (managedFunction.ReturnsVoid) {
			return "void";
		}

		return DetermineNativeType(managedFunction.ReturnType, false);
	}

	private static string DetermineNativeType(ITypeSymbol typeSymbol, bool isByRef) {
		if (typeSymbol is IArrayTypeSymbol arrayTypeSymbol) {
			return DetermineNativeType(arrayTypeSymbol.ElementType, true);
		}

		string ptrSuffix = "";
		if (isByRef) {
			ptrSuffix = "*";
		}

		var type = typeSymbol;

		if (type is IPointerTypeSymbol pointerTypeSymbol) {
			ptrSuffix = "*";
			type = pointerTypeSymbol.PointedAtType;
		}


		if (type is INamedTypeSymbol namedTypeSymbol && namedTypeSymbol.IsGenericType) 
		{
			return $"{GetCSharpTypeName(type)}<{string.Join(", ", namedTypeSymbol.TypeArguments.Select(GetCSharpTypeName))}>{ptrSuffix}";
		}
		
		// Strings get manually marshalled.
		if (GetCSharpTypeName(type) == typeof(string).FullName) {
			return $"nint{ptrSuffix}";
		}

		// Out strings get manually marshalled.
		if (GetCSharpTypeName(type) == typeof(StringBuilder).FullName) {
			return $"nint{ptrSuffix}";
		}

		// Bool is not blittable. Use byte.
		if (GetCSharpTypeName(type) == typeof(bool).FullName) {
			return $"byte{ptrSuffix}";
		}

		// If it's a protobuf type, it gets marshalled via ProtobufHack.
		if (type.AllInterfaces.Any(i => GetCSharpTypeName(i) == "Google.Protobuf.IMessage"))
		{
			return $"nint";
		}

		// Compatible interfaces get manually marshalled.
		if (type.HasAttribute(CPP_INTERFACE_ATTRIBUTE_NAME)) {
			return $"nint";
		}

		// Delegates get marshalled as pointers.
		if (type.TypeKind == TypeKind.Delegate) {
			return $"nint{ptrSuffix}";
		}

		// Managed (contains reference types) should get marshalled via Marshal.PtrToStruct family of functions. This one shouldn't care about the pointer suffix.
		if (!type.IsUnmanagedType) {
			return $"nint";
		}

		return GetCSharpTypeName(type) + ptrSuffix;
	}

	private static string GenerateNativeFunctionPointer(IMethodSymbol managedFunction, IEnumerable<string> previouslyUsedNames, out string functionPointerName) {
		List<string> returns = ["ref N"];
		foreach (var item in managedFunction.Parameters)
		{
			returns.Add(DetermineNativeType(item.Type, item.RefKind == RefKind.Ref || item.RefKind == RefKind.Out || item.RefKind == RefKind.In));
		}

		returns.Add(DetermineNativeReturnType(managedFunction));

		// For many functions with the same name, generate different pointer names so they don't clash.
		int iteration = 1;
		string currentNumber = "";
		while (true)
		{
			string currentName = $"p_{managedFunction.Name}{currentNumber}";
			if (!previouslyUsedNames.Any(n => n == currentName)) {
				functionPointerName = currentName;
				break;
			}

			iteration++;
			currentNumber = iteration.ToString();
		}

		return $"				public readonly delegate* unmanaged[Thiscall]<{string.Join(", ", returns)}> {functionPointerName};";
	}

	private static string RefKindToString(RefKind refKind) {
		return refKind switch
		{
			RefKind.Ref => "ref",
			RefKind.In => "in",
			RefKind.Out => "out",
			_ => ""
		};
	}

	private static string FormatArgTypesAndNames(IMethodSymbol managedFunction)
	{
		static string FormatArg(IParameterSymbol p) {
			var first = RefKindToString(p.RefKind);
			if (!string.IsNullOrEmpty(first)) {
				first += " ";
			}

			string suffix = "";

			var type = p.Type;
			if (type is IPointerTypeSymbol pointerTypeSymbol) {
				suffix = "*";
				type = pointerTypeSymbol.PointedAtType;
			}


			if (type is INamedTypeSymbol namedTypeSymbol && namedTypeSymbol.IsGenericType) 
			{
				return $"{first}{GetCSharpTypeName(type)}<{string.Join(", ", namedTypeSymbol.TypeArguments.Select(GetCSharpTypeName))}>{suffix} {p.Name}";
			}

			return $"{first}{GetCSharpTypeName(type)}{suffix} {p.Name}";
		}

		return string.Join(", ", managedFunction.Parameters.Select(FormatArg));
	}
	
	private static string FormatArgNames(IMethodSymbol managedFunction)
	{
		static string FormatArg(IParameterSymbol p) {
			var first = RefKindToString(p.RefKind);
			if (!string.IsNullOrEmpty(first)) {
				first += " ";
			}

			return $"{first}{p.Name}";
		}

		return string.Join(", ", managedFunction.Parameters.Select(FormatArg));
	}

	private static string GenerateFunctionImplementation(IMethodSymbol managedFunction, string nativePointerName) {
		StringBuilder builder = new();
		List<string> extraStatements = [];
		List<string> postExtraStatements = [];
		List<string> postReturnBraces = [];
		List<string> nativeArgs = ["ref this"];
		
		foreach (var item in managedFunction.Parameters)
		{
			string varType = GetCSharpTypeName(item.Type);
			string varName = item.Name;
			bool noFixed = false;

			builder.AppendLine("//"+ string.Join(", ", item.Type.AllInterfaces.Select(GetCSharpTypeName)));

			if (item.Type is IArrayTypeSymbol array) {
				varType = GetCSharpTypeName(array.ElementType);

				string suffix = "";
				if (varType == typeof(string).FullName) {
					extraStatements.Add($"var {varName}_strarr = StringMarshal.CopyStringArray({varName});");
					postExtraStatements.Add($"StringMarshal.FreeStringArray({varName}_strarr);");
					suffix = "_strarr";
					varType = "nint";
				}

				varName += suffix;

				extraStatements.Add($"fixed ({varType}* {varName}_ptr = {varName}) {{");
				postReturnBraces.Add($"}} // fixed {varName}");
				nativeArgs.Add($"{varName}_ptr");
				continue;
			}

			if (item.Type.AllInterfaces.Any(i => GetCSharpTypeName(i) == "Google.Protobuf.IMessage"))
			{
				extraStatements.Add($"using var {varName}_hack = ProtobufHack.Create<{GetCSharpTypeName(item.Type)}>();");
				if (item.RefKind == RefKind.Ref || item.RefKind == RefKind.In || item.RefKind == RefKind.None) 
				{
					extraStatements.Add($"{varName}_hack.CopyFrom({varName});");
				}

				if (item.RefKind == RefKind.Ref || item.RefKind == RefKind.Out) 
				{
					postExtraStatements.Add($"{varName} = {varName}_hack.GetManaged();");
				}
				
				nativeArgs.Add($"{varName}_hack.ptr");
				continue;
			}

			if (varType == typeof(bool).FullName) {
				varType = typeof(byte).FullName;
				string originalName = varName;
				varName += "_blit";
				
				if (item.RefKind == RefKind.Ref || item.RefKind == RefKind.In || item.RefKind == RefKind.None) {
					extraStatements.Add($"byte {varName} = Convert.ToByte({originalName});");
				} else {
					extraStatements.Add($"byte {varName} = 0;");
				}

				if (item.RefKind == RefKind.Ref || item.RefKind == RefKind.Out) {
					postExtraStatements.Add($"{originalName} = Convert.ToBoolean({varName});");
				}
				
				
				noFixed = true;
			} else if (varType == typeof(string).FullName) 
			{
				extraStatements.Add($"using var {varName}_unmanaged = new PinnedUTF8String({varName});");
				varName = $"(nint){varName}_unmanaged.CurrentPtr";
			} else if (varType == typeof(StringBuilder).FullName) 
			{
				string originalName = varName;

				extraStatements.Add($"using var {varName}_unmanaged = new PinnedUTF8String({varName}.Capacity);");
				varName = $"(nint){varName}_unmanaged.CurrentPtr";
				postExtraStatements.Add($"{originalName}.Append({originalName}_unmanaged.CurrentString);");
			} else if (item.Type.TypeKind == TypeKind.Delegate) {
				// Delegates get marshalled as pointers.
				nativeArgs.Add($"Marshal.GetFunctionPointerForDelegate({varName})");
				continue;
			} else if (item.Type.HasAttribute(CPP_INTERFACE_ATTRIBUTE_NAME))
			{
				extraStatements.Add($"nint {varName}_ptr = CppClassMarshal.ClassToPtr({varName});");
				nativeArgs.Add($"{varName}_ptr");
				continue;
			}
			else if (!item.Type.IsUnmanagedType) 
			{
				extraStatements.Add($"fixed (byte* {varName}_bytes = new byte[Marshal.SizeOf<{varType}>()]) {{");

				if (item.RefKind == RefKind.Ref || item.RefKind == RefKind.In) {
					extraStatements.Add($"Marshal.StructureToPtr({varName}, (nint){varName}_bytes, false);");
				} else {
					extraStatements.Add($"Marshal.StructureToPtr(new {varType}(), (nint){varName}_bytes, false);");
				}

				postReturnBraces.Add($"}} // fixed {varName}_bytes");
				if (item.RefKind == RefKind.Ref || item.RefKind == RefKind.Out) {
					postExtraStatements.Add($"{varName} = Marshal.PtrToStructure<{varType}>((nint){varName}_bytes);");
				}

				nativeArgs.Add($"(nint){varName}_bytes");
				continue;
			}

			if (item.RefKind == RefKind.Ref || item.RefKind == RefKind.Out || item.RefKind == RefKind.In) {
				// Never do any "ref logic" on generated interfaces, they marshal automatically if the underlying data changes due to the pointer changing
				if (!item.Type.HasAttribute(CPP_INTERFACE_ATTRIBUTE_NAME))
				{
					if (noFixed) {
						nativeArgs.Add($"&{varName}");
					} else {
						extraStatements.Add($"fixed ({varType}* {varName}_ptr = &{varName}) {{");
						postReturnBraces.Add($"}} // fixed {varName}");
						nativeArgs.Add($"{varName}_ptr");
					}
				}
				
				continue;
			}
			
			nativeArgs.Add(varName);
		}
		
		string nativeCall = $"vtable->{nativePointerName}({string.Join(", ", nativeArgs)})";

		builder.AppendLine($"			public {FunctionReturnTypeName(managedFunction.ReturnType)} {managedFunction.Name}({FormatArgTypesAndNames(managedFunction)}) {{");
		
		foreach (var item in extraStatements)
		{
			builder.AppendLine($"				{item}");
		}

		if (managedFunction.ReturnsVoid) {
			builder.AppendLine($"				{nativeCall};");
			foreach (var item in postExtraStatements)
			{
				builder.AppendLine($"				{item}");
			}

		} else {
			if (GetCSharpTypeName(managedFunction.ReturnType) == typeof(bool).FullName) {
				nativeCall = $"Convert.ToBoolean({nativeCall})";
			} else if (managedFunction.ReturnType.HasAttribute(CPP_INTERFACE_ATTRIBUTE_NAME)) {
				nativeCall = $"{GetCSharpTypeName(managedFunction.ReturnType)}_Impl.Create({nativeCall})";
			} else if (GetCSharpTypeName(managedFunction.ReturnType) == typeof(string).FullName) {
				nativeCall = $"Marshal.PtrToStringUTF8({nativeCall}) ?? string.Empty";
			}

			builder.AppendLine($"				var ret = {nativeCall};");
			foreach (var item in postExtraStatements)
			{
				builder.AppendLine($"				{item}");
			}

			builder.AppendLine($"				return ret;");
		}

		foreach (var item in postReturnBraces)
		{
			builder.AppendLine($"				{item}");
		}

		builder.AppendLine($"			}}");

		return builder.ToString();
	}
	
	public static string FunctionReturnTypeName(ITypeSymbol type)
	{
		string ptrSuffix = "";
		if (type is IPointerTypeSymbol pointerTypeSymbol) {
			ptrSuffix = "*";
			type = pointerTypeSymbol.PointedAtType;
		}

		if (type is INamedTypeSymbol namedTypeSymbol && namedTypeSymbol.IsGenericType) 
		{
			return $"{GetCSharpTypeName(type)}<{string.Join(", ", namedTypeSymbol.TypeArguments.Select(GetCSharpTypeName))}>{ptrSuffix}";
		}

		return GetCSharpTypeName(type) + ptrSuffix;
	}
	
    public static string GetCSharpTypeName(ITypeSymbol symbol) {
        if (symbol == null) {
            return "";
        }
        
        var toDS = symbol.ToDisplayString(new SymbolDisplayFormat(typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces));
        if (toDS.StartsWith("System.Void")) {
            toDS = toDS.Replace("System.Void", "void");
        }

        return toDS;
    }

    public static string GetCSharpTypeNameWithGenerics(INamedTypeSymbol symbol)
    {
	    if (!symbol.IsGenericType)
		    return GetCSharpTypeName(symbol);
	    
	    return
		    $"{GetCSharpTypeName(symbol)}<{string.Join(", ", symbol.TypeArguments.Select(GetCSharpTypeName))}>";
    }

    private static IEnumerable<ISymbol> ProcessInterfaceInheritanceTree(INamedTypeSymbol interfaceSymbol)
    {
	    List<ISymbol> recursiveMembers = new();
	    foreach (var validInterface in interfaceSymbol.Interfaces.Where(i => i.HasAttribute(CPP_INTERFACE_ATTRIBUTE_NAME)))
	    {
		    recursiveMembers.AddRange(ProcessInterfaceInheritanceTree(validInterface));
		    recursiveMembers.AddRange(validInterface.GetMembers());
	    }
	    
	    return recursiveMembers;
    }

    private void Generate(SourceProductionContext context, ImmutableArray<INamedTypeSymbol> classSymbols)
    {
	    foreach (INamedTypeSymbol interfaceSymbol in classSymbols)
	    {
		    // Functions
		    StringBuilder nativeFunctionPointers = new();
		    StringBuilder managedToStructWrappers = new();
		    StringBuilder structToVTableWrappers = new();
		    List<string> functionPointerUsedNames = new();
		    
		    // Properties/data
			StringBuilder propertyImplementations = new();
		    StringBuilder nativeFields = new();

		    List<ISymbol> allMembersIncludingBase = new();
		    
		    allMembersIncludingBase.AddRange(ProcessInterfaceInheritanceTree(interfaceSymbol));
		    allMembersIncludingBase.AddRange(interfaceSymbol.GetMembers());
		    
		    foreach (var sym in allMembersIncludingBase)
		    {
			    if (sym is IPropertySymbol prop)
			    {
				    string fieldName = $"field_{prop.Name}";

				    string propertyType;
				    if (prop.Type is INamedTypeSymbol nts)
				    {
					    propertyType = GetCSharpTypeNameWithGenerics(nts);
				    }
				    else
				    {
					    propertyType = GetCSharpTypeName(prop.Type);
				    }

				    bool hasGetter = prop.GetMethod != null;
				    bool hasSetter = prop.SetMethod != null;

				    string getter = $"// No getter for {prop.Name}";
				    if (hasGetter)
					    getter = $"get => objectPtr->{fieldName};";
				    
				    string setter = $"// No setter for {prop.Name}";
				    if (hasSetter)
					    setter = $"set => objectPtr->{fieldName} = value;";
				    
				    nativeFields.AppendLine($"\t\t\tpublic {propertyType} {fieldName};");
				    propertyImplementations.AppendLine(@$"
						public {propertyType} {prop.Name}
						{{
							{getter}
							{setter}
						}}
					");
			    }
			    else if (sym is IMethodSymbol func)
			    {
				    // Skip properties here, they are not part of vtable.
				    if (func.AssociatedSymbol is IPropertySymbol)
					    continue;
				    
				    // Process single functions
				    nativeFunctionPointers.AppendLine(GenerateNativeFunctionPointer(func, functionPointerUsedNames, out string functionPointerName));
				    functionPointerUsedNames.Add(functionPointerName);
				    structToVTableWrappers.AppendLine(GenerateFunctionImplementation(func, functionPointerName));
				    managedToStructWrappers.AppendLine(GenerateClassToStructWrapper(func));
			    }
		    }

		    // Build up the source code
		    string source = $@"// <auto-generated/>
#pragma warning disable CS0649

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using OpenSteamworks.Native;
using OpenSteamworks.Utils;
using OpenSteamworks.Data;
using CppSourceGen;
using CppSourceGen.Utils;

namespace {interfaceSymbol.ContainingNamespace.ToDisplayString()}
{{
	internal unsafe partial class {interfaceSymbol.Name}_Impl : ICppClass<{interfaceSymbol.Name}_Impl>, {interfaceSymbol.Name} {{

		/// <summary>
		/// Native representation of ""{interfaceSymbol.Name}""
		/// </summary>
		[StructLayout(LayoutKind.Sequential, Pack = 0)]
		private struct N {{
			public readonly struct VT
			{{
{nativeFunctionPointers}
			}}

			public readonly VT* vtable;
{nativeFields}

{structToVTableWrappers}
		}}

		private readonly N* objectPtr;
		
		public nint ObjectPtr => (nint)objectPtr;
		
		public object MetadataObject {{ get; }}

		public static {interfaceSymbol.Name}_Impl Create(nint objectptr, object metadataObject = null) => new {interfaceSymbol.Name}_Impl(objectptr, metadataObject);
		private {interfaceSymbol.Name}_Impl(nint objectptr, object metadataObject) {{
			this.objectPtr = (N*)objectptr;
			this.MetadataObject = metadataObject;
		}}

{managedToStructWrappers}

{propertyImplementations}
	}}
}}

namespace CppSourceGen
{{
	public static partial class MarshallableClasses
	{{
		public static {GetCSharpTypeName(interfaceSymbol)} Create_{interfaceSymbol.Name}(IntPtr objectPtr)
			=> {GetCSharpTypeName(interfaceSymbol)}_Impl.Create(objectPtr);
	}}
}}
";

		    // Add the source code to the compilation
		    context.AddSource($"{interfaceSymbol.Name}_Impl.g.cs", source);
	    }
    }

    private static string GenerateClassToStructWrapper(IMethodSymbol func)
    {
	    StringBuilder builder = new();
	    builder.AppendLine($"public {FunctionReturnTypeName(func.ReturnType)} {func.Name}({FormatArgTypesAndNames(func)}) {{");
	    
	    if (func.HasAttribute(CROSSPROC_IPC_BLOCKED_ATTRIBUTE_NAME)) {
		    builder.AppendLine($"SteamClient.ThrowIfRemotePipe<{GetCSharpTypeName(func.ContainingType)}_Impl>(this);");
	    }

	    string ret = "return ";
	    if (func.ReturnsVoid)
	    {
		    ret = string.Empty;
	    }

	    builder.AppendLine($"{ret}objectPtr->{func.Name}({FormatArgNames(func)});");
	    builder.AppendLine("}");
	    return builder.ToString();
    }

    private static INamedTypeSymbol Transform(GeneratorSyntaxContext context, CancellationToken token)
    {
	    var symbol = context.SemanticModel.GetDeclaredSymbol(context.Node);
		
	    if (symbol is not INamedTypeSymbol structSymbol)
		    return null;
		
	    if (!symbol.HasAttribute(CPP_INTERFACE_ATTRIBUTE_NAME))
		    return null;

	    return structSymbol;
    }

    private static bool ShouldTransform(SyntaxNode node, CancellationToken token)
    {
	    if (node is not InterfaceDeclarationSyntax)
	    {
		    return false;
	    }
		
	    //TODO: More checks here?
	    return true;
    }
	
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
	    var provider = context.SyntaxProvider
		    .CreateSyntaxProvider(ShouldTransform, Transform)
		    .Where(x => x != null)
		    .Collect();
	    
	    context.RegisterSourceOutput(provider, Generate);
    }
}