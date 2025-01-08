using System;
using System.Collections.Generic;
using CppSourceGen.Generator.Operations;

namespace CppSourceGen.Generator.Marshal;

public sealed class StringArrayMarshaller : IMarshaller
{
    public bool TryGetMarshalInfo(VarOrArgInfo arg, out MarshalInfo? marshalInfo)
    {
        if (!arg.Type.IsArray || arg.Type.PierceType != TypeInfo.StringType)
        {
            marshalInfo = null;
            return false;
        }
        
        List<MarshalOperation> toManagedOperations = new();
        List<MarshalOperation> toNativeOperations = new();

        var ptrArrVar = new VarOrArgInfo(new CLRTypeInfo(typeof(Span<nint>)), $"{arg.Name}_strarr", initializer: "[]");
        
        toNativeOperations.Add(AssignmentOperation.Assign(ptrArrVar, $"CppSourceGen.Utils.StringMarshal.CopyStringArray({arg.Name})", $"CppSourceGen.Utils.StringMarshal.FreeStringArray({ptrArrVar.Name});"));
        toNativeOperations.Add(FixedBlockOperation.Fix(ptrArrVar, out var ptrptrVar));

        if (arg.TryGetAttribute(CppClassMarshaller.LENGTHARG_ATTRIBUTE_NAME, out var lengthargAttribute))
        {
            var lengthargObj = lengthargAttribute!.ConstructorArguments[0].Value;
            if (lengthargObj is string lengtharg)
            {
                toManagedOperations.Add(AssignmentOperation.Assign(ptrArrVar, $"new System.Span<nint>({ptrptrVar}, {lengtharg})"));
            } else if (lengthargObj is null)
            {
                toManagedOperations.Add(new ErrorOperation("CPP", "Internal", "Internal error: lengtharg is not of type string, was null"));
            }
            else
            {
                toManagedOperations.Add(new ErrorOperation("CPP", "Internal", "Internal error: lengtharg is not of type string, was " + lengthargObj.GetType().FullName));
            }
        }
        else
        {
            toManagedOperations.Add(new ErrorOperation("CPP001", "Arguments", "Marshalling string arrays native-to-managed must have a lengtharg"));
        }
        
        toManagedOperations.Add(AssignmentOperation.Assign(arg, $"CppSourceGen.Utils.StringMarshal.GetStringArray(ref {arg.Name}, {ptrArrVar.Name})"));

        marshalInfo = new(arg, ptrptrVar, [ptrArrVar, ptrptrVar], toNativeOperations, toManagedOperations);
        return true;
    }
}