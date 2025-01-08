# Typing guide
- Use spans for buffers (`void*`, `uint8*`)
- Use spans instead of arrays (`AppId_t[]`, `int[]`, etc.)
- Use strings for `const char*`
- Use StringBuilder for `char*`

Look at the generated code (`obj/Debug/net8.0/generated/CppSourceGen.Generator/NativeClassSourceGenerator/`) to ensure everything is valid.
