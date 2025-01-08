using OpenSteamClient.Logging;
using OpenSteamworks.Data;

namespace OpenSteamworks.ConCommands;

internal sealed class DownloadDepotCommand : BaseCommand
{
    public override string Name => "download_depot";
    public override string HelpText => "download_depot <appid> <depotid> (target manifestid) (delta manifestid) (depot flags filter) (destination folder) : download a depot by id and optional version";
    
    public DownloadDepotCommand(ISteamClient steamClient, ILogger logger) : base(steamClient, logger) { }
    
    public override void Invoke(in CCommand args)
    {
        if (!args.TryGetArg(0, out AppId_t appid) || !args.TryGetArg(1, out uint depotID))
        {
            OnInvalidArgs("AppID and DepotID must be specified and positive numbers!");
            return;
        }

        args.TryGetArg(2, out ulong targetManifestID);
        args.TryGetArg(3, out ulong deltaManifestID);
        args.TryGetArg(4, out uint depotFlagsFilter);
        args.TryGetArg(5, out string? targetInstallPath);
        
        SteamClient.IClientDepotBuilder.DownloadDepot(appid, depotID, 0, depotFlagsFilter, targetManifestID, deltaManifestID,
            targetInstallPath);
    }
}