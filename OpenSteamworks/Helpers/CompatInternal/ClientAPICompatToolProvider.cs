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
        using var stringList = new CUtlStringList();
        clientCompat.GetAvailableCompatTools(&stringList);

        return stringList.ToManaged();
    }

    public unsafe IEnumerable<string> GetCompatTools(ERemoteStoragePlatform target)
    {
        using var stringList = new CUtlStringList();
        clientCompat.GetAvailableCompatToolsFiltered(&stringList, target);

        return stringList.ToManaged();
    }

    public unsafe IEnumerable<string> GetCompatToolsForApp(AppId_t appid)
    {
        using var stringList = new CUtlStringList();
        clientCompat.GetAvailableCompatToolsForApp(&stringList, appid);

        return stringList.ToManaged();
    }
}