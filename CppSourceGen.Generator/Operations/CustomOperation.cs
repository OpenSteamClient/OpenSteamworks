using System.Collections.Generic;
using System.Text;

namespace CppSourceGen.Generator.Operations;

public class CustomOperation : MarshalOperation
{
    private readonly string preCallStr1;
    private readonly string postCallStr1;
    private readonly string finallyStr1;
    
    public override IEnumerable<VarOrArgInfo> DeclaresVariables { get; }
    private CustomOperation(IEnumerable<VarOrArgInfo> declaresVariables, string preCallStr, string postCallStr, string finallyStr)
    {
        DeclaresVariables = declaresVariables;
        preCallStr1 = preCallStr;
        postCallStr1 = postCallStr;
        finallyStr1 = finallyStr;
    }

    public override void Build(StringBuilder preCallBuilder, StringBuilder postCallBuilder, StringBuilder finallyBuilder)
    {
        if (!string.IsNullOrEmpty(preCallStr1))
            preCallBuilder.AppendLine(preCallStr1);

        if (!string.IsNullOrEmpty(postCallStr1))
            postCallBuilder.AppendLine(postCallStr1);

        if (!string.IsNullOrEmpty(finallyStr1))
            finallyBuilder.AppendLine(finallyStr1);
    }

    public static MarshalOperation Create(string preCallStr = "", string postCallStr = "", string finallyStr = "", IEnumerable<VarOrArgInfo>? declaresVariables = null)
        => new CustomOperation(declaresVariables ?? new List<VarOrArgInfo>(), preCallStr, postCallStr, finallyStr);
}