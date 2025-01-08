using System.Collections.Generic;
using System.Text;

namespace CppSourceGen.Generator.Operations;

public class FixedBlockOperation : MarshalOperation
{
    private readonly VarOrArgInfo ptrVar;
    private readonly VarOrArgInfo sourceVar;

    public override int IndentLevel => 1;

    private FixedBlockOperation(VarOrArgInfo ptrVar, VarOrArgInfo sourceVar)
    {
        this.DeclaresVariables = new List<VarOrArgInfo>() { ptrVar };
        this.ptrVar = ptrVar;
        this.sourceVar = sourceVar;
    }

    public static FixedBlockOperation Fix(VarOrArgInfo varToFix, out VarOrArgInfo fixedVar)
    {
        fixedVar = new VarOrArgInfo(TypeInfo.MakePointerType(varToFix.Type), $"{varToFix.Name}_fptr");
        return new(fixedVar, varToFix);
    }
    
    public override IEnumerable<VarOrArgInfo> DeclaresVariables { get; }

    public override void Build(StringBuilder preCallBuilder, StringBuilder postCallBuilder, StringBuilder finallyBuilder)
    {
        // Arrays don't need &
        var addrOfOperator = sourceVar.Type.IsArray || sourceVar.Type.IsSpan ? "" : "&";
        preCallBuilder.AppendLine($"fixed ({ptrVar.Type.KeywordName} {ptrVar.Name} = {addrOfOperator}{sourceVar.Name}) {{");
        postCallBuilder.AppendLine($"}} // fixed {ptrVar.Name}");
    }
}