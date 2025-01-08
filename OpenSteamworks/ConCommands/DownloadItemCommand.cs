using OpenSteamClient.Logging;
using OpenSteamworks.Data;

namespace OpenSteamworks.ConCommands;

internal sealed class DownloadItemCommand : BaseCommand
{
    public override string Name => "download_item";
    public override string HelpText => "download_item <appid> <workshopItemID> : download a workshop item by id";
    
    public DownloadItemCommand(ISteamClient steamClient, ILogger logger) : base(steamClient, logger) { }
    
    public override void Invoke(in CCommand args)
    {
        if (!args.TryGetArg(0, out AppId_t appid) || !args.TryGetArg(1, out uint workshopItemID))
        {
            OnInvalidArgs("AppID and WorkshopItemID must be specified and positive numbers!");
            return;
        }
        
        SteamClient.IClientDepotBuilder.DownloadDepot(appid, 0, workshopItemID, 0, 0, 0, null);
    }
}