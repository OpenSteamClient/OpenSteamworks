using System;
using System.Collections.Immutable;
using System.Linq.Expressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Operations;

namespace OpenSteamworks.SourceGen;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class DontUseConsole : DiagnosticAnalyzer
{
    internal static DiagnosticDescriptor Rule =
        new DiagnosticDescriptor(
            "OSW001",
            "Use of Console is discouraged",
            "Console should not be used internally. Always use ILogger.",
            "InternalAnalyzers",
            DiagnosticSeverity.Warning,
            isEnabledByDefault: true);

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } = ImmutableArray.Create(Rule);
    
    public override void Initialize(AnalysisContext context)
    {
        context.EnableConcurrentExecution();
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.ReportDiagnostics);
        context.RegisterSyntaxNodeAction(OnSyntaxNode, SyntaxKind.InvocationExpression, SyntaxKind.ExpressionStatement, SyntaxKind.TypeOfExpression, SyntaxKind.SimpleMemberAccessExpression);
        context.RegisterOperationAction(OnOperation, OperationKind.NameOf);
    }

    private void OnOperation(OperationAnalysisContext cb)
    {
        if (cb.Operation is not INameOfOperation nameOfOperation)
            return;

        if (nameOfOperation.Argument.Type == null)
            return;

        if (GetCSharpTypeName(nameOfOperation.Argument.Type) != typeof(Console).FullName)
            return;
        
        cb.ReportDiagnostic(Diagnostic.Create(Rule, cb.Operation.Syntax.GetLocation()));
    }

    private static void OnSyntaxNode(SyntaxNodeAnalysisContext cb)
    {
        static bool Check(SyntaxNodeAnalysisContext cb, ISymbol symbol)
        {
            if (symbol is not ITypeSymbol typeSymbol)
                return false;
            
            if (GetCSharpTypeName(typeSymbol) == typeof(Console).FullName)
            {
                cb.ReportDiagnostic(Diagnostic.Create(Rule, cb.Node.GetLocation()));
                return true;
            }

            return false;
        }

        static bool CheckSymbol(SyntaxNodeAnalysisContext cb, ISymbol symbol)
        {
            switch (symbol)
            {
                case IMethodSymbol methodSymbol2 when CheckSymbol(cb, methodSymbol2.ContainingSymbol):
                case IAliasSymbol aliasSymbol when CheckSymbol(cb, aliasSymbol.Target):
                case ITypeSymbol ts when Check(cb, ts):
                    return true;
            }

            return false;
        }
        
        switch (cb.Node)
        {
            case TypeOfExpressionSyntax typeofSyntax when CheckSymbol(cb, cb.SemanticModel.GetSymbolInfo(typeofSyntax.Type).Symbol):
            case MemberAccessExpressionSyntax memberAccessExpressionSyntax when CheckSymbol(cb, cb.SemanticModel.GetSymbolInfo(memberAccessExpressionSyntax.Expression).Symbol):
            case InvocationExpressionSyntax invocationExpressionSyntax when CheckSymbol(cb, cb.SemanticModel.GetSymbolInfo(invocationExpressionSyntax.Expression).Symbol):
                return;
            
            default:
                CheckSymbol(cb, cb.SemanticModel.GetSymbolInfo(cb.Node).Symbol);
                return;
        }
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
}