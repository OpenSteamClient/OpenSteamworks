using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using OpenSteamClient.Logging;
using OpenSteamworks.Extensions;
using OpenSteamworks.Utils;

namespace OpenSteamworks.Native;

public class NativeLibraryEx {
    public class Section {
        private NativeLibraryEx nativeLibrary;
        public string Name { get; private set; }
        public UIntPtr StartAddress { get; private set; }
        public UIntPtr EndAddress { get; private set; }
        public ulong Length { get; private set; }
        private RefCount widenedSecurityRefCount = new RefCount();
        private int previousSecurity = 0;
        
        internal Section(string name, UIntPtr startAddress, ulong length, NativeLibraryEx nativeLibrary) {
            this.Name = name;
            this.StartAddress = startAddress;
            this.Length = length;
            this.EndAddress = this.StartAddress + new UIntPtr(this.Length);
            this.nativeLibrary = nativeLibrary;
        }

        /// <summary>
        /// Widens security of this section temporarily.
        /// </summary>
        public void WidenSecurity() {
            if (widenedSecurityRefCount.Increment()) {
                if (OperatingSystem.IsLinux()) {
                    previousSecurity = LinuxNative.PROT_READ + LinuxNative.PROT_EXEC;
                    if (LinuxNative.mprotect((nint)StartAddress, (nuint)this.Length, LinuxNative.PROT_READ + LinuxNative.PROT_WRITE + LinuxNative.PROT_EXEC) != 0) {
                        Logging.GeneralLogger.Warning($"Failed to widen {this.Name} security, errno: " + Marshal.GetLastWin32Error());
                    }
                } else if (OperatingSystem.IsWindows()) {
                    unsafe {
                        uint oldProtect = 0;
                        if (!WindowsNative.VirtualProtect((void*)StartAddress, (nuint)this.Length, WindowsNative.PAGE_READWRITE, &oldProtect)) {
                            Logging.GeneralLogger.Warning($"Failed to widen {this.Name} security, errno: " + Marshal.GetLastWin32Error());
                        } else {
                            previousSecurity = (int)oldProtect;
                        }
                    }
                } else {
                    Logging.GeneralLogger.Error($"Failed to widen {this.Name} security, not implemented on your OS");
                }
            }
        }

        /// <summary>
        /// Restores this section's security to what it was before a call to WidenSecurity.
        /// </summary>
        public void RestoreSecurity() {
            if (widenedSecurityRefCount.Decrement()) {
                if (OperatingSystem.IsLinux()) {
                    if(LinuxNative.mprotect((nint)StartAddress, (UIntPtr)Length, previousSecurity) != 0) {
                        Logging.GeneralLogger.Warning($"Failed to restore {this.Name} security, errno: " + Marshal.GetLastWin32Error());
                    }
                } else if (OperatingSystem.IsWindows()) {
                    unsafe {
                        uint oldProtect = 0;
                        if (!WindowsNative.VirtualProtect((void*)StartAddress, (nuint)this.Length, (uint)previousSecurity, &oldProtect)) {
                            Logging.GeneralLogger.Warning($"Failed to restore {this.Name} security, errno: " + Marshal.GetLastWin32Error());
                        } else {
                            previousSecurity = (int)oldProtect;
                        }
                    }
                } else {
                    Logging.GeneralLogger.Error($"Failed to restore {this.Name} security, not implemented on your OS");
                }
            }
        }

    }

    private static nint? _libc;
    [SupportedOSPlatform("linux")]
    [SupportedOSPlatform("macos")]
    public static nint Libc {
        get {
            if (_libc != null) {
                return _libc.Value;
            }
            
            _libc = NativeLibrary.Load("libc");
            return _libc.Value;
        }
    }
    public string FileName { get; private set; }
    public IntPtr Handle { get; private set; }
    private Dictionary<IntPtr, byte[]> hookedFunctions = new();
    private List<Section> sections = new();
    public ReadOnlyCollectionEx<Section> Sections {
        get {
            return new ReadOnlyCollectionEx<Section>(sections);
        }
    }

    public Section TextSection { 
        get {
            return sections.Where(s => s.Name == ".text").First();
        }
    }

    public unsafe void HookFunction(IntPtr functionToHook, IntPtr jmpTargetFunction) {
        checked {
            Logging.GeneralLogger.Debug("Hooking function " + functionToHook);
            TextSection.WidenSecurity();
            if (!hookedFunctions.ContainsKey(functionToHook)) {
                byte[] saved_buffer = new byte[5];
                fixed (byte* p = saved_buffer)
                {
                    Buffer.MemoryCopy((void*)functionToHook, p, 5, 5);
                }
                Logging.GeneralLogger.Debug("Copied old data");
                hookedFunctions[functionToHook] = saved_buffer;
            }


            // mov r10, addr
            var patch_mov = new byte[10] { 0x49, 0xBA, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            // jmp r10
            var patch_jmp = new byte[3] { 0x41, 0xFF, 0xE2 };

            var finalPatch = new byte[13];

            fixed (byte* p = patch_mov)
            {
                Buffer.MemoryCopy(&jmpTargetFunction, p+2, 8, 8);
            }

            patch_mov.CopyTo(finalPatch, 0);
            patch_jmp.CopyTo(finalPatch, 10);

            Logging.GeneralLogger.Debug("Created hook, copying");
            fixed (byte* p = finalPatch)
            {
                Buffer.MemoryCopy(p, (void*)functionToHook, 13, 13);
            }

            Logging.GeneralLogger.Debug("Final patch: '" + Convert.ToHexString(finalPatch) + "'");

            Logging.GeneralLogger.Debug("Overwrote function");
            TextSection.RestoreSecurity();
        }
    }

    /// <summary>
    /// Removes the hook from a previously hooked function.
    /// </summary>
    /// <param name="functionToUnhook"></param>
    public unsafe void UnhookFunction(IntPtr functionToUnhook) {
        if (!hookedFunctions.ContainsKey(functionToUnhook)) {
            throw new ArgumentException("Function has not been hooked", nameof(functionToUnhook));
        }

        TextSection.WidenSecurity();

        var originalCode = hookedFunctions[functionToUnhook];
        fixed (byte* p = originalCode)
        {
            Buffer.MemoryCopy(p, (void*)functionToUnhook, 5, 5);
        }
        hookedFunctions.Remove(functionToUnhook);

        TextSection.RestoreSecurity();
    }

    private static byte[] ParsePatternString(string pattern, string mask)
	{
		List<byte> patternbytes = new();

        for (int i = 0; i < mask.Length; i++)
        {
            if (mask[i] == '?') {
                patternbytes.Add(0x0);
            } else {
                patternbytes.Add((byte)pattern[i]);
            }
        }

		return patternbytes.ToArray();
	}

    private unsafe bool PatternCheck(int nOffset, byte[] arrPattern, byte* memory)
    {
        for (int i = 0; i < arrPattern.Length; i++)
        {
            if (arrPattern[i] == 0x0)
                continue;
 
            if (arrPattern[i] != memory[nOffset + i]) {
                return false;
            }
        }
 
        return true;
    }
    
    /// <summary>
    /// Finds a signature
    /// </summary>
    /// <param name="signature">The signature to find</param>
    /// <param name="signatureMask">The mask to use</param>
    /// <param name="customStart">A custom start position to use, should be in range of memoryStart</param>
    /// <returns>An absolute pointer to the start of the found signature or nullptr if not found</returns>
    public unsafe IntPtr FindSignature(string szPattern, string signatureMask, UIntPtr? offset = null)
    {
        checked
        {
            TextSection.WidenSecurity();
            byte* memoryPtr;
            int memoryLen = 0;
            if(offset.HasValue)
            {
                memoryPtr = (byte*)(TextSection.StartAddress + offset);
                memoryLen = (int)(TextSection.EndAddress - (uint)memoryPtr);
            } else {
                memoryPtr = (byte*)TextSection.StartAddress;
                memoryLen = (int)TextSection.Length;
            }
            

            byte[] arrPattern = ParsePatternString(szPattern, signatureMask);
            Logging.GeneralLogger.Debug("Search starts at " + (nint)memoryPtr + " and ends at " + TextSection.EndAddress + ", offset is " + offset + ", length of signature " + szPattern.Length + ", length of mask " + signatureMask.Length + ", length of memory region " + memoryLen);
            for (int nModuleIndex = 0; nModuleIndex < memoryLen; nModuleIndex++)
            {
                if (memoryPtr[nModuleIndex] != arrPattern[0])
                    continue;

                if (PatternCheck(nModuleIndex, arrPattern, memoryPtr))
                {
                    TextSection.RestoreSecurity();
                    return (IntPtr)(memoryPtr + nModuleIndex);
                }
            }

            TextSection.RestoreSecurity();
            return 0;
        }
    }

    /// <summary>
    /// Finds a signature and casts it to a callable function
    /// </summary>
    /// <param name="signature">The signature to find</param>
    /// <param name="signatureMask">The mask to use</param>
    /// <param name="offset">An offset to apply to memoryStart before starting a search</param>
    /// <returns>A function to call</returns>
    public T FindSignature<T>(string signature, string signatureMask, UIntPtr? offset = null) {
        var ptr = FindSignature(signature, signatureMask, offset);
        return Marshal.GetDelegateForFunctionPointer<T>(ptr);
    }

    private NativeLibraryEx(string filename, bool withSectionInfo, bool withSearch) {
        FileName = filename;
        if (withSearch) {
            Handle = NativeLibrary.Load(filename, Assembly.GetExecutingAssembly(), DllImportSearchPath.ApplicationDirectory | DllImportSearchPath.AssemblyDirectory | DllImportSearchPath.UserDirectories);
        } else {
            Handle = NativeLibrary.Load(filename);
        }

        // Need to load the file a second time so we can iterate over the sections, since section info is removed at runtime (the entire library is NOT mapped into RAM, only the sections that matter (on linux, windows is untested for now))
        //NOTE: this could be bad if some OS decides to lock the file from being read if it's loaded
        if (withSectionInfo) {
            byte[] bytes = File.ReadAllBytes(filename);
            unsafe {
                fixed (byte* ptr = bytes ) {
                    if (OperatingSystem.IsWindows()) {
                        PopulateSectionsWindows(bytes, (byte*)this.Handle);
                    } else if (OperatingSystem.IsLinux()) {
                        PopulateSectionsLinux(ptr);
                    } else {
                        throw new NotSupportedException("OS unsupported");
                    }
                }
            }
        }
    }

    [SupportedOSPlatform("linux")]
    private unsafe void PopulateSectionsLinux(byte* data) {
        checked
        {
            link_map* linkMap = null;
            var dlinfoResult = LinuxNative.dlinfo(this.Handle, LinuxNative.RTLD_DI_LINKMAP, &linkMap);
            if (linkMap == null || dlinfoResult != 0) {
                throw new Exception("Call to dlinfo failed, errno: " + LinuxNative.dlerror());
            }

            var ehdr = (Elf64_Ehdr*)data;
            var shdrs = (Elf64_Shdr*)(data + ehdr->e_shoff);
            var shstrtab = (byte*)(data + shdrs[ehdr->e_shstrndx].sh_offset);
            for (int j = 0; j < ehdr->e_shnum; j++)
            {
                var shdr = shdrs[j];
                var sectionName = Marshal.PtrToStringUTF8((IntPtr)(shstrtab + shdr.sh_name));
                if (string.IsNullOrEmpty(sectionName))
                {
                    Logging.GeneralLogger.Warning($"Detected empty section name for section at idx {j}, skipping");
                    continue;
                }
                Logging.GeneralLogger.Debug($"Found section " + sectionName + ", which is " + shdr.sh_size + " bytes");
                Section sect = new Section(sectionName, (UIntPtr)(linkMap->l_addr + shdr.sh_addr), shdr.sh_size, this);
                this.sections.Add(sect);
            }
        }
    }

    [SupportedOSPlatform("windows")]
    private unsafe void PopulateSectionsWindows(byte[] data, byte* loadedLibraryHandle) {
        checked {
            using (var stream = new MemoryStream(data))
            {
                BinaryReader reader = new BinaryReader(stream);
                var dosHeader = reader.ReadStruct<IMAGE_DOS_HEADER>();

                // Add 4 bytes to the offset
                stream.Seek(dosHeader.e_lfanew, SeekOrigin.Begin);

                UInt32 ntHeadersSignature = reader.ReadUInt32();
                var fileHeader = reader.ReadStruct<IMAGE_FILE_HEADER>();
                var optionalHeader64 = reader.ReadStruct<IMAGE_OPTIONAL_HEADER64>();

                var imageSectionHeaders = new IMAGE_SECTION_HEADER[fileHeader.NumberOfSections];
                for(int headerNo = 0; headerNo < imageSectionHeaders.Length; ++headerNo) {
                    imageSectionHeaders[headerNo] = reader.ReadStruct<IMAGE_SECTION_HEADER>();
                }

                foreach (var section in imageSectionHeaders)
                {
                    int len = strnlen(section.Name, 8);
                    var sectionName = System.Text.Encoding.UTF8.GetString(section.Name, len);
                    Logging.GeneralLogger.Debug($"Found section " + sectionName + ", which is " + section.PhysicalAddressOrVirtualSize + " bytes");
                    Section sect = new Section(sectionName, (UIntPtr)(loadedLibraryHandle + section.VirtualAddress), section.PhysicalAddressOrVirtualSize, this);
                    this.sections.Add(sect);
                }
            }
        }
    }

    // There's no alternative to this in C#, so add it in here for cross platform sakes
    /// <summary>
    /// The strnlen() function returns the number of bytes in the string
    /// pointed to by s, excluding the terminating null byte ('\0'), but
    /// at most maxlen.  In doing this, strnlen() looks only at the first
    /// maxlen characters in the string pointed to by s and never beyond
    /// s[maxlen-1]
    /// </summary>
    private unsafe int strnlen(byte* bytes, int maxLen) {
        checked
        {
            for (int i = 0; i < maxLen; i++)
            {
                if (bytes[i] == 0x0) {
                    if (i == 0) {
                        return 0;
                    }
                    return i-1;
                }
                i++;
            } 

            return maxLen;
        }
    }

    public static NativeLibraryEx Load(string filename, bool withSectionInfo = true, bool withSearch = false) {
        return new NativeLibraryEx(filename, withSectionInfo, withSearch);
    }

    public void Unload() {
        NativeLibrary.Free(this.Handle);
    }

    /// <summary>
    /// Gets the address of an exported symbol.
    /// </summary>
    /// <param name="exportName">The name of the exported symbol.</param>
    /// <returns>The address of the symbol.</returns>
    /// <exception cref="System.ArgumentNullException">name is null.</exception>
    /// <exception cref="System.EntryPointNotFoundException">The symbol is not found.</exception>
    public IntPtr GetExport(string exportName) {
        return NativeLibrary.GetExport(this.Handle, exportName);
    }
    
    /// <summary>
    /// Gets a delegate for an exported symbol.
    /// </summary>
    /// <param name="exportName">The name of the exported symbol.</param>
    /// <returns>A delegate for the symbol.</returns>
    /// <exception cref="System.ArgumentNullException">name is null.</exception>
    /// <exception cref="System.EntryPointNotFoundException">The symbol is not found.</exception>
    public T GetExport<T>(string exportName) {
        return Marshal.GetDelegateForFunctionPointer<T>(GetExport(exportName));
    }
}