using System.Text;

namespace CppSourceGen.Generator;

public static class StringExtensions
{
    public static string Repeat(this string thiz, int repeat)
        => new StringBuilder(thiz.Length * repeat).Insert(0, thiz, repeat).ToString();
}