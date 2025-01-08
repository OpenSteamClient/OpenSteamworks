using System.Collections.Generic;
using System.Linq;
using System.Text;
using CppSourceGen.Generator.Marshal;
using Microsoft.CodeAnalysis;

namespace CppSourceGen.Generator;

public class NativeCppClassImpl
{
    public TypeInfo NativeStruct { get; }
    public StructBuilder VTableStruct { get; }
    public ClassBuilder WrapperClass { get; }
    public string ImplName { get; }
    public TypeInfo ClassType { get; }
    public TypeInfo InterfaceType { get; }
    
    
    public VarOrArgInfo ObjectPtr { get; }
    public VarOrArgInfo FieldsAccessor { get; }
    
    private readonly NativeMarshalGenerator marshalGenerator;
    
    
    private static readonly ThinTypeInfo vtImplIFace = new("CppSourceGen", "IVTImpl<VT>", "interface");
    public NativeCppClassImpl(SourceProductionContext? context, TypeInfo classType)
    {
        ClassType = classType;
        InterfaceType = classType.InheritedFrom.First(i => i.IsInterface && i.TryGetAttribute(CppClassMarshaller.CPP_INTERFACE_ATTRIBUTE_NAME, out _));
        
        ImplName = ClassType.Name;
        
        var preTextVT = $"""
                       /// <summary>
                       /// Virtual function call table of "{classType.Name}" 
                       /// </summary>
                       [StructLayout(LayoutKind.Sequential)]
                       """;
        
        WrapperClass = new ClassBuilder(classType.Root, ImplName, "internal unsafe partial", string.Empty, [new ThinTypeInfo("CppSourceGen", $"CppClassBase<{InterfaceType.FullName}_Native, {ClassType.Name}.VT, {InterfaceType.FullName}>", "class")]);
        VTableStruct = new(WrapperClass.FullName,  "VT", "internal readonly", preTextVT, [vtImplIFace]);
        WrapperClass.AddSubtype(VTableStruct);

        NativeStruct = new ThinTypeInfo(InterfaceType.Root, $"{InterfaceType.Name}_Native", "struct");
        FieldsAccessor = new VarOrArgInfo(new ThinTypeInfo(InterfaceType.Root, $"{InterfaceType.Name}_NativeFields", "struct"), "fields");
        
        // Typed "objectPtr" for actually using the native code.
        ObjectPtr = new VarOrArgInfo(TypeInfo.MakePointerType(NativeStruct), "NativeObject");
        
        VTableStruct.CreateFunction(new FunctionInfo("VT", [], null), "");
        VTableStruct.CreateField(new VarOrArgInfo(VTableStruct.Type, "staticVT", "new()", isStatic: true));
        VTableStruct.CreateAutoProperty(new VarOrArgInfo(TypeInfo.MakePointerType(VTableStruct.Type), "VTPtr", "CppClassMarshal.AllocateVT(in staticVT)", isStatic: true), true, false);
        
        marshalGenerator = new(context, this);
        
        foreach (var member in InterfaceType.Members)
        {
            switch (member)
            {
                case VarOrArgMemberInfo fieldInfo:
                    GenerateProperty(fieldInfo.Member);
                    break;
                case MethodMemberInfo method:
                    // Skip constructors always.
                    if (method.Member.ReturnType == null)
                        break;

                    // Skip static methods always.
                    if (method.Member.IsStatic)
                        break;

                    if (method.Member.IsPropertyAccessor)
                        break;
                    
                    GenerateMethod(method.Member);
                    break;
            }
        }
    }
    
    public void Build(out string managedToNativeClass)
    {
        StringBuilder classes = new();
        classes.AppendLine(WrapperClass.Build());
        managedToNativeClass = classes.ToString();
    }

    private void GenerateProperty(VarOrArgInfo member)
    {
        StringBuilder getterSetter = new(128);
        
        string memberAccess = ObjectPtr.AccessMember(FieldsAccessor.AccessMember(member.Name));
        if (member.HasSetter)
        {
            getterSetter.Append($"set => {memberAccess} = value;");
        }

        if (member.HasGetter)
        {
            getterSetter.Append($"get => {memberAccess};");
        }
        
        WrapperClass.CreateManualProperty(member, $" {{ {getterSetter} }}");
    }

    private void GenerateMethod(FunctionInfo member)
    {
        var vtField = marshalGenerator.GenerateMarshal(member, out string marshalBody, out var nativeToManagedFuncInfo);
        VTableStruct.CreateField(vtField, "public readonly");
        VTableStruct.CreateFunction(nativeToManagedFuncInfo, marshalBody, attributes: ["[UnmanagedCallersOnly(CallConvs = [typeof(CallConvThiscall)])]"], modifiers: "public static");
    }
}