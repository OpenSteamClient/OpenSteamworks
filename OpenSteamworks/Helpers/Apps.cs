using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenSteamworks.Callbacks;
using OpenSteamworks.Callbacks.Structs;
using OpenSteamworks.Data;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data.Structs;
using OpenSteamworks.Exceptions;
using OpenSteamworks.Generated;
using OpenSteamworks.KeyValue.Deserializers;
using OpenSteamworks.KeyValue.ObjectGraph;

namespace OpenSteamworks.Helpers;

/// <summary>
/// Helps with the reading of static app information.
/// </summary>
public sealed class AppsHelper : IDisposable
{
    private readonly IClientApps clientApps;
    
    private readonly ICallbackHandler cbAppInfoUpdateProgress;
    public AppsHelper(ISteamClient steamClient)
    {
        this.clientApps = steamClient.IClientApps;
        
        cbAppInfoUpdateProgress = steamClient.CallbackManager.Register<AppInfoUpdateProgress_t>(OnAppInfoUpdateProgress);
    }
    
    /// <summary>
    /// Retrieve a specific key from an app's appdata. 
    /// </summary>
    /// <param name="appid"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public string GetAppData(AppId_t appid, string key)
    {
        int len = clientApps.GetAppData(appid, key, null, 0);
        
        StringBuilder builder = new(len);
        clientApps.GetAppData(appid, key, builder, len);
        
        return builder.ToString();
    }
    
    public string GetAppLocalizedName(AppId_t appid)
        // This internally gets the correct localization. Very handy!
        => GetAppData(appid, "common/name");
    
    /// <summary>
    /// Tries to get an appinfo section.
    /// </summary>
    /// <param name="appid">The appid for which to retrieve the appinfo from.</param>
    /// <param name="eSection">The appinfo section to retrieve.</param>
    /// <param name="kvSection">The data from the appinfo section that was requested.</param>
    /// <returns>False if no appinfo is cached for the specified appid, true if the function call succeeded.</returns>
    public bool TryGetAppInfo(AppId_t appid, EAppInfoSection eSection, [NotNullWhen(true)] out KVObject? kvSection)
    {
        kvSection = null;
        
        int len = clientApps.GetAppDataSection(appid, eSection, null, 0, false);
        if (len <= 0)
        {
            return false;
        }
        
        // This code possibly causes a copy? Either way it's terrible but GetBuffer causes bytes to be truncated off at the end.    
        byte[] buf = new byte[len];
        Trace.Assert(len == clientApps.GetAppDataSection(appid, eSection, buf, len, false));
        using var ms = new MemoryStream(buf);
        kvSection = KVBinaryDeserializer.Deserialize(ms);

        return true;
    }
    
    /// <summary>
    /// Tries to get multiple appinfo sections. This function is more efficient than calling TryGetAppInfoSection multiple times.
    /// </summary>
    /// <param name="appid">The appid for which to retrieve the appinfo from.</param>
    /// <param name="eSections">The appinfo sections to retrieve.</param>
    /// <param name="kvSections">The data from the appinfo sections that were requested.</param>
    /// <returns>False if no appinfo is cached for the specified appid, true if the function call succeeded.</returns>
    public unsafe bool TryGetAppInfo(AppId_t appid, IEnumerable<EAppInfoSection> eSections, [NotNullWhen(true)] out IEnumerable<KVObject>? kvSections)
    {
        kvSections = null;

        var sections = eSections.ToArray();
        var sectionLengths = new int[sections.Length];
        var sectionKVs = new KVObject[sectionLengths.Length];
        
        int len = clientApps.GetMultipleAppDataSections(appid, sections, sections.Length, null, 0, false, null);
        if (len <= 0)
        {
            return false;
        }

        byte[] buf = new byte[len];
        Trace.Assert(len == clientApps.GetMultipleAppDataSections(appid, sections, sections.Length, buf, len, false, sectionLengths));

        int pos = 0;
        fixed (byte* bptr = buf)
        {
            for (int i = 0; i < sectionLengths.Length; i++)
            {
                var section = sections[i];
                var sectionLength = sectionLengths[i];
                if (sectionLength <= 0)
                {
                    sectionKVs[i] = new KVObject(section.ToAPIString(), new List<KVObject>());
                    continue;
                }
                
                // Use an UnmanagedMemoryStream to avoid creating unnecessary copies.
                using var substream = new UnmanagedMemoryStream(bptr + pos, sectionLength);
                pos += sectionLength;
                sectionKVs[i] = KVBinaryDeserializer.Deserialize(substream);
            }
        }

        kvSections = sectionKVs;

        return true;
    }
    
    private readonly object waitForAppInfoUpdateCompletionLock = new();
    private readonly Dictionary<AppId_t, TaskCompletionSource> waitForAppInfoUpdateCompletionList = new();
    
    private Task WaitForAppInfoUpdateCompletion(AppId_t appid)
    {
        lock (waitForAppInfoUpdateCompletionLock)
        {
            // Create a TCS if one doesn't exist already
            if (!waitForAppInfoUpdateCompletionList.TryGetValue(appid, out var tcs))
            {
                tcs = waitForAppInfoUpdateCompletionList[appid] = new TaskCompletionSource();
            }
            
            return tcs.Task;
        }
    }
    
    private void OnAppInfoUpdateProgress(ICallbackHandler handler, AppInfoUpdateProgress_t cb)
    {
        lock (waitForAppInfoUpdateCompletionLock)
        {
            if (!waitForAppInfoUpdateCompletionList.Remove(cb.m_nAppID, out var tcs))
            {
                return;
            }

            tcs.SetResult();
        }  
    }
    
    public async Task<KVObject> GetAppInfoAsync(AppId_t appid, EAppInfoSection eSection)
        => (await GetAppInfoAsync(appid, [eSection])).First();

    public async Task<IEnumerable<KVObject>> GetAppInfoAsync(AppId_t appid, IEnumerable<EAppInfoSection> eSections)
    {
        // Avoid multiple enumeration by simply enumerating once here so we don't have to do it again.
        eSections = eSections.ToList();
        
        if (TryGetAppInfo(appid, eSections, out var sections))
        {
            return sections;
        }
        
        // We don't have appinfo, request it and wait.
        var task = WaitForAppInfoUpdateCompletion(appid);
        if (!clientApps.RequestAppInfoUpdate([appid], 1))
            throw new APICallException($"RequestAppInfoUpdate failed for appid {appid}");
        
        // Now wait.
        await task;
        
        if (!TryGetAppInfo(appid, eSections, out sections))
        {
            // If it fails at this point it's likely a ownership problem. Shame there's no error code we could use here :(
            throw new APICallException($"Failed to retrieve appinfo for app {appid}, sections {string.Join(", ", eSections)}. Do we own this app?");
        }
        
        return sections;
    }
    
    public async Task<IDictionary<AppId_t, IEnumerable<KVObject>>> GetAppInfoAsync(IEnumerable<AppId_t> appids, IEnumerable<EAppInfoSection> eSections)
    {
        // There's no API way (except GetAppKVRaw) to get appinfo for multiple apps at once. Valve, pls fix.
        Dictionary<AppId_t, IEnumerable<KVObject>> objects = new();
        foreach (var appid in appids)
        {
            objects.Add(appid, await GetAppInfoAsync(appid, eSections));
        }

        return objects;
    }
    
    public void Dispose()
    {
        cbAppInfoUpdateProgress.Dispose();
    }
}