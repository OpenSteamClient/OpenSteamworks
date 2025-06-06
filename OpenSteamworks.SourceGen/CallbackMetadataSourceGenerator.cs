using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SourceGeneratorsKit;

[Generator(LanguageNames.CSharp)]
public class CallbackMetadataSourceGenerator : IIncrementalGenerator
{
	public const string ATTRIBUTE_NAME = "OpenSteamworks.Attributes.CallbackAttribute";
	public const string METADATA_STORE_NAMESPACE = "OpenSteamworks.Callbacks";
	public const string METADATA_STORE_NAME = "CallbackMetadata";
	
	private static string GenerateToStringMethod(INamedTypeSymbol structSymbol) {
		StringBuilder builder = new StringBuilder();

		builder.AppendLine($@"
	public static string {structSymbol.Name}_ToString({structSymbol.Name} cb) {{
		StringBuilder builder = new();
		builder.AppendLine(""Begin Callback {structSymbol.Name}"");");
		
		foreach (var item in structSymbol.GetMembers().Where(m => m is IFieldSymbol or IPropertySymbol))
		{
			ITypeSymbol type = null;
			if (item is IFieldSymbol fieldSymbol) 
			{
				// Skip backing fields.
				if (fieldSymbol.IsImplicitlyDeclared)
					continue;
				
				type = fieldSymbol.Type;
			} else if (item is IPropertySymbol propertySymbol)
			{
				type = propertySymbol.Type;
			}

			if (type is IArrayTypeSymbol) {
				// Handle arrays
				builder.AppendLine($"		builder.AppendLine($\"    {item.Name}: {{EnumerableToString(cb.{item.Name})}}\");");
				continue;
			}

			// Handle everything else
			builder.AppendLine($"		builder.AppendLine($\"    {item.Name}: {{FieldToString(cb.{item.Name})}}\");");
		}

		builder.AppendLine($@"		builder.AppendLine(""End Callback {structSymbol.Name}"");
		return builder.ToString();
	}}");
		return builder.ToString();
	}

	private string ifOrElseIf = "if";
	private string GenerateIDFromTypeMapping(INamedTypeSymbol structSymbol) {
		StringBuilder builder = new StringBuilder();
		builder.AppendLine($"		{ifOrElseIf} (typeof(T) == typeof({structSymbol.Name}))");
		builder.AppendLine($"		{{");
		builder.AppendLine($"			return {structSymbol.Name}_ID;");
		builder.AppendLine($"		}}");
		
		if (ifOrElseIf == "if") {
			ifOrElseIf = "else if";
		}

		return builder.ToString();
	}

	private static string GenerateCallbackToStringMapping(INamedTypeSymbol structSymbol) 
		=> $"			{structSymbol.Name}_ID => {structSymbol.Name}_ToString(GetStructForCallback<{structSymbol.Name}>(data)),";

	private void Generate(SourceProductionContext context, ImmutableArray<INamedTypeSymbol> structSymbols)
	{
		StringBuilder generatedToStringMethods = new StringBuilder();
		StringBuilder generatedIDs = new StringBuilder();
		StringBuilder generatedIDFromTypeMappings = new StringBuilder();
		StringBuilder generatedCallbackToStringMappings = new StringBuilder();
		
		// Process every callback struct and generate the sources
		foreach (INamedTypeSymbol structSymbol in structSymbols)
		{
			var attr = structSymbol.FindAttribute(ATTRIBUTE_NAME);
			if (attr == null) {
				// Skip this struct if it doesn't have this attribute
				continue;
			}

			int callbackID = (int)attr.ConstructorArguments[0].Value;
			generatedIDs.AppendLine($"	public const int {structSymbol.Name}_ID = {callbackID};");
			generatedToStringMethods.Append(GenerateToStringMethod(structSymbol));
			generatedCallbackToStringMappings.AppendLine(GenerateCallbackToStringMapping(structSymbol));
			generatedIDFromTypeMappings.Append(GenerateIDFromTypeMapping(structSymbol));
		}

		// Concat all this together
		string source = $@"// <auto-generated/>
using System;
using System.Text;
using OpenSteamworks.Callbacks.Structs;

namespace {METADATA_STORE_NAMESPACE};

internal static partial class {METADATA_STORE_NAME} {{
{generatedIDs}

{generatedToStringMethods}

	public static string CallbackToString(int callbackID, byte[] data) {{
		return callbackID switch
		{{
{generatedCallbackToStringMappings}
			_ => string.Empty,
		}};
	}}

	public static int GetIDFromType<T>() where T: struct {{
{generatedIDFromTypeMappings}
		throw new ArgumentException(""Type is not a callback type."", nameof(T));
	}}
}}
";

		// Add the source code to the compilation
		context.AddSource($"CallbackMetadata.g.cs", source);
	}
	
	private static INamedTypeSymbol Transform(GeneratorSyntaxContext context, CancellationToken token)
	{
		var symbol = context.SemanticModel.GetDeclaredSymbol(context.Node);
		
		if (symbol is not INamedTypeSymbol structSymbol)
			return null;
		
		if (!symbol.HasAttribute(ATTRIBUTE_NAME))
			return null;

		return structSymbol;
	}

	private static bool ShouldTransform(SyntaxNode node, CancellationToken token)
	{
		if (node is ClassDeclarationSyntax)
		{
			return false;
		}

		if (node is RecordDeclarationSyntax)
		{
			return true;
		}
		
		//TODO: More checks here?
		return node is StructDeclarationSyntax;
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