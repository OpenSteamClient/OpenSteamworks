using System.Collections.Generic;
using CppSourceGen.Generator.Operations;

namespace CppSourceGen.Generator.Marshal;

/// <summary>
/// Marshals CppClasses to their pointers (and vice versa)
/// </summary>
public class CppClassMarshaller : IMarshaller
{
    public const string CPP_INTERFACE_ATTRIBUTE_NAME = "CppSourceGen.Attributes.CppClassAttribute";
    public const string CPP_INTERFACE_IMPL_ATTRIBUTE_NAME = "CppSourceGen.Attributes.CppClassImplAttribute";
    public const string LENGTHARG_ATTRIBUTE_NAME = "CppSourceGen.Attributes.LengthArgAttribute";
    public const string MANUAL_ARGUMENT_ORDER_ATTRIBUTE_NAME = "CppSourceGen.Attributes.ManualArgumentOrderAttribute";
    
    public bool TryGetMarshalInfo(VarOrArgInfo arg, out MarshalInfo? marshalInfo)
    {
        if (!arg.Type.TryGetAttribute(CPP_INTERFACE_ATTRIBUTE_NAME, out _))
        {
            marshalInfo = null;
            return false;
        }
        
        List<MarshalOperation> toManagedOperations = new();
        List<MarshalOperation> toNativeOperations = new();
        
        var nativeVar = new VarOrArgInfo(TypeInfo.NintType, $"{arg.Name}_ptr");
        toNativeOperations.Add(AssignmentOperation.Assign(nativeVar, $"CppClassMarshal.ClassToPtr({arg.Name})"));
        
        // The sub-object creation should inherit the parents metadataObject.
        toManagedOperations.Add(AssignmentOperation.Assign(arg, $"{arg.Type.FullName}_Impl.Create({nativeVar.Name}, wrapper.MetadataObject)"));

        marshalInfo = new(arg, nativeVar, [nativeVar], toNativeOperations, toManagedOperations);
        return true;
    }
}