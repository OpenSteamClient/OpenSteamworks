using System.Collections.Generic;
using CppSourceGen.Generator.Operations;

namespace CppSourceGen.Generator.Marshal;

public class StringMarshaller : IMarshaller
{
    public bool TryGetMarshalInfo(VarOrArgInfo arg, out MarshalInfo? marshalInfo)
    {
        //TODO: Handle stringbuilders
        if (arg.Type != TypeInfo.StringType)
        {
            marshalInfo = null;
            return false;
        }

        List<MarshalOperation> toNativeOperations = new();
        List<MarshalOperation> toManagedOperations = new();
        var nativeArg = new VarOrArgInfo(TypeInfo.NintType, $"{arg.Name}_strptr", initializer: "0", refKind: arg.RefKind);
        toNativeOperations.Add(AssignmentOperation.Assign(nativeArg, $"CppSourceGen.Utils.StringMarshal.StringToPtrUTF8({arg.Name})", $"CppSourceGen.Utils.StringMarshal.FreeUTF8String({nativeArg.Name});"));
        toManagedOperations.Add(AssignmentOperation.Assign(arg, $"CppSourceGen.Utils.StringMarshal.PtrToStringUTF8({nativeArg.Name})"));

        marshalInfo = new(arg, nativeArg, [nativeArg], toNativeOperations, toManagedOperations);
        return true;
    }
}