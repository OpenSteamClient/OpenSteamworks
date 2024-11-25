using System.Runtime.InteropServices;

namespace CppSourceGen.Utils;

public sealed class CppClassMarshal
{
    public static nint ClassToPtr(object? unkObject)
    {
        if (unkObject is not ICppClass cppClass)
        {
            return 0;
        }
        
        return cppClass.ObjectPtr;
    }
}