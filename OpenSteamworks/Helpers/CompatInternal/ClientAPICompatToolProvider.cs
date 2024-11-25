using System.Collections.Generic;
using OpenSteamworks.Data;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Generated;

namespace OpenSteamworks.Helpers.CompatInternal;

/// <summary>
/// Provides compat tool data from the ClientAPI hosted in-proc.
/// </summary>
internal sealed class ClientAPICompatToolProvider(ISteamClient steamClient) : ICompatToolProvider
{
    private readonly IClientCompat clientCompat = steamClient.IClientCompat;

    public unsafe IEnumerable<string> GetCompatTools()
    {
        CUtlStringList stringList = new();
        clientCompat.GetAvailableCompatTools(&stringList);

        return stringList.ToManagedAndFree();
    }

    public unsafe IEnumerable<string> GetCompatTools(ERemoteStoragePlatform target)
    {
        CUtlStringList stringList = new();
        clientCompat.GetAvailableCompatToolsFiltered(&stringList, target);

        return stringList.ToManagedAndFree();
    }

    public unsafe IEnumerable<string> GetCompatToolsForApp(AppId_t appid)
    {
        CUtlStringList stringList = new();
        clientCompat.GetAvailableCompatToolsForApp(&stringList, appid);

        return stringList.ToManagedAndFree();
    }
}