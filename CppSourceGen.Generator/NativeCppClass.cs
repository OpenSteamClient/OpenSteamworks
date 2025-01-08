using System.Collections.Generic;
using System.Linq;
using System.Text;
using CppSourceGen.Generator.Marshal;
using Microsoft.CodeAnalysis;

namespace CppSourceGen.Generator;

public class NativeCppClass
{
    public StructBuilder NativeStruct { get; }
    public StructBuilder NativeFieldsStruct { get; }
    
    public StructBuilder VTableStruct { get; }
    public ClassBuilder WrapperClass { get; }
    
    public VarOrArgInfo ObjectPtr { get; }
    public VarOrArgInfo VTPtr { get; }
    public VarOrArgInfo FieldsAccessor { get; }
    
    public string ImplName { get; }
    public TypeInfo Interface { get; }
    

    private readonly NativeMarshalGenerator marshalGenerator;
    
    
    public NativeCppClass(SourceProductionContext? context, TypeInfo interfaceType)
    {
        var subInterfaces = interfaceType.InheritedFrom.Where(i =>
            i.TryGetAttribute(CppClassMarshaller.CPP_INTERFACE_ATTRIBUTE_NAME, out _));
        
        Interface = interfaceType;
        ImplName = Interface.Name + "_Impl";

        var preTextNative = $"""
                       /// <summary>
                       /// Native memory layout of "{interfaceType.Name}"
                       /// </summary>
                       [StructLayout(LayoutKind.Sequential)]
                       """;
        
        var preTextNativeFields = $"""
                             /// <summary>
                             /// Native memory layout of "{interfaceType.Name}"'s fields
                             /// </summary>
                             [StructLayout(LayoutKind.Sequential)]
                             """;
        
        var preTextVT = $"""
                       /// <summary>
                       /// Virtual function call table of "{interfaceType.Name}" 
                       /// </summary>
                       [StructLayout(LayoutKind.Sequential)]
                       """;
        
        WrapperClass = new ClassBuilder(interfaceType.Root, ImplName, "internal unsafe partial", string.Empty, [interfaceType, new ThinTypeInfo("CppSourceGen", $"ICppClass<{Interface.FullName}>", "interface")]);
        NativeStruct = new(interfaceType.Root, $"{Interface.Name}_Native", "internal unsafe", preTextNative, []);
        NativeFieldsStruct = new(interfaceType.Root, $"{Interface.Name}_NativeFields", "internal unsafe", preTextNativeFields, []);
        VTableStruct = new(interfaceType.Root,  $"{Interface.Name}_VT", "internal unsafe readonly", preTextVT, []);
        
        var ctorBody = $"""
                        this.objectPtr = ({NativeStruct.FullName}*)objectPtr;
                        this.MetadataObject = metadataObject;
                        """;

        VTPtr = new VarOrArgInfo(TypeInfo.MakePointerType(VTableStruct.Type), "vtable");
        FieldsAccessor = new VarOrArgInfo(NativeFieldsStruct.Type, "fields");
        
        NativeStruct.CreateField(VTPtr, "private readonly");
        NativeStruct.CreateField(FieldsAccessor);
        
        // Untyped "ObjectPtr" for implementing ICppClass.
        var untypedObjectPtr = new VarOrArgInfo(TypeInfo.NintType, "ObjectPtr");

        // Metadata object for ICppClass
        var metadataObject = new VarOrArgInfo(TypeInfo.ObjectType, "MetadataObject");
        WrapperClass.CreateAutoProperty(metadataObject, true, false, true);

        var ctorArgs = new[]
        {
            new VarOrArgInfo(TypeInfo.NintType, "objectPtr"), 
            new VarOrArgInfo(TypeInfo.ObjectType, "metadataObject", initializer: "null")
        };
        
        var ctor = new FunctionInfo(ImplName, ctorArgs, null);
        WrapperClass.CreateFunction(ctor, ctorBody, "private");

        var createFunc = new FunctionInfo("Create", ctorArgs, interfaceType);
        WrapperClass.CreateFunction(createFunc, $"=> new {ImplName}(objectPtr, metadataObject);", "public static");
        
        // Typed "objectPtr" for actually using the native code.
        ObjectPtr = new VarOrArgInfo(TypeInfo.MakePointerType(NativeStruct.Type), "objectPtr");
        WrapperClass.CreateManualProperty(untypedObjectPtr, $"\t=> (nint){ObjectPtr.Name};");
        WrapperClass.CreateField(ObjectPtr, "private readonly");

        marshalGenerator = new(context, this);
        
        // Handle inherited classes
        foreach (var subInterface in subInterfaces)
        {
            var nativeFields = new VarOrArgInfo(new ThinTypeInfo(subInterface.Root, $"{subInterface.Name}_NativeFields", "struct"), "parentFields");
            
            NativeFieldsStruct.CreateField(nativeFields);
            
            foreach (var member in subInterface.Members)
            {
                switch (member)
                {
                    case VarOrArgMemberInfo fieldInfo:
                        GenerateProperty(fieldInfo.Member, nativeFields);
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
        
        foreach (var member in interfaceType.Members)
        {
            switch (member)
            {
                case VarOrArgMemberInfo fieldInfo:
                    GenerateProperty(fieldInfo.Member, null);
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
    
    public void Build(out string marshallableClassesImpl, out string managedToNativeClass)
    {
        marshallableClassesImpl = $$"""
                                    namespace CppSourceGen
                                    {
                                    	public static partial class MarshallableClasses
                                    	{
                                    		public static {{Interface.FullName}} Create_{{Interface.Name}}({{TypeInfo.NintType.FullName}} objectPtr, object metadataObject = null)
                                    			=> {{WrapperClass.FullName}}.Create(objectPtr, metadataObject);
                                    	}
                                    }
                                    """;

        StringBuilder classes = new();
        classes.AppendLine(VTableStruct.Build());
        classes.AppendLine(NativeFieldsStruct.Build());
        classes.AppendLine(NativeStruct.Build());
        classes.AppendLine(WrapperClass.Build());
        managedToNativeClass = classes.ToString();
    }

    private void GenerateProperty(VarOrArgInfo member, VarOrArgInfo? subtypeStruct)
    {
        var privateField = new VarOrArgInfo(Marshallers.GetMarshalInfo(member).MarshalledVariable.Type, "fld_" + member.Name);
        
        StringBuilder getterSetter = new(128);
        StringBuilder marshallerGetterSetter = new(256);
        
        string memberAccess = subtypeStruct != null ? ObjectPtr.AccessMember(FieldsAccessor.AccessMember(subtypeStruct.AccessMember(member.Name))) : ObjectPtr.AccessMember(FieldsAccessor.AccessMember(member.Name));
        if (member.HasSetter)
        {
            getterSetter.Append($"set => {memberAccess} = value;");
            marshallerGetterSetter.AppendLine(marshalGenerator.GenerateSetter(privateField, member.Type));
        }

        if (member.HasGetter)
        {
            getterSetter.Append($"get => {memberAccess};");
            marshallerGetterSetter.AppendLine(marshalGenerator.GenerateGetter(privateField, member.Type));
        }
        
        WrapperClass.CreateManualProperty(member, $" {{ {getterSetter} }}");

        if (subtypeStruct == null)
        {
            NativeFieldsStruct.CreateField(privateField, "private");
            NativeFieldsStruct.CreateManualProperty(member, $$"""
                                                              { 
                                                              {{marshallerGetterSetter}} 
                                                              }
                                                              """);
        }
    }

    private void GenerateMethod(FunctionInfo member)
    {
        var vtField = marshalGenerator.GenerateMarshal(member, out string marshalBody, out _);
        VTableStruct.CreateField(vtField, "public readonly");

        var wrapperArg = new VarOrArgInfo(this.WrapperClass.Type, "wrapper");
        
        List<VarOrArgInfo> args = new();
        args.Add(wrapperArg);
        args.AddRange(member.Arguments);
        
        var wrapperMember = new FunctionInfo(member.Name, args, member.ReturnType, member.ReturnRefKind);
        NativeStruct.CreateFunction(wrapperMember, marshalBody);
        WrapperClass.CreateFunction(member, $"=> {member.GetProxyCall(ObjectPtr, true)};");
    }
}