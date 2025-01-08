using System.Collections.Generic;
using System.Text;
using Microsoft.CodeAnalysis;

namespace CppSourceGen.Generator.Operations;

public sealed class ErrorOperation : MarshalOperation
{
    public override IEnumerable<VarOrArgInfo> DeclaresVariables => new List<VarOrArgInfo>();
    
    public override void Build(StringBuilder preCallBuilder, StringBuilder postCallBuilder, StringBuilder finallyBuilder)
    {
        preCallBuilder.AppendLine($"#error \"{diagnostic.Id} {diagnostic.Descriptor.Title.ToString()}\"");
    }

    private readonly Diagnostic diagnostic;
    public ErrorOperation(Diagnostic diagnostic)
    {
        this.diagnostic = diagnostic;
    }

    public ErrorOperation(string id, string category, string msg)
    {
        this.diagnostic = Diagnostic.Create(id, category, msg, DiagnosticSeverity.Error, DiagnosticSeverity.Error, true, 0);
    }

    public void Report(SourceProductionContext? context)
    {
        context?.ReportDiagnostic(diagnostic);
    }
}