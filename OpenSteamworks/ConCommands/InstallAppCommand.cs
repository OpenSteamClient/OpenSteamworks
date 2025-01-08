using OpenSteamClient.Logging;
using OpenSteamworks.Data;
using OpenSteamworks.Data.Enums;

namespace OpenSteamworks.ConCommands;

internal sealed class InstallAppCommand : BaseCommand
{
    public override string Name => "app_install";
    public override string HelpText => "app_install <appid> <libraryFolder>";
    
    public InstallAppCommand(ISteamClient steamClient, ILogger logger) : base(steamClient, logger) { }
    
    public override void Invoke(in CCommand args)
    {
        if (!args.TryGetArg(0, out AppId_t appid) || !args.TryGetArg(1, out LibraryFolder_t libraryFolder))
        {
            OnInvalidArgs("AppID and LibraryFolder must be specified and numbers!");
            return;
        }

        if (SteamClient.IClientAppManager.GetNumLibraryFolders() < libraryFolder)
        {
            OnInvalidArgs("Invalid LibraryFolder!");
            return;
        }
        
        Logger.Info($"Installing app {appid} to folder {libraryFolder}");
        var result = SteamClient.AppManagerHelper.InstallApp(appid, libraryFolder);
        if (result != EAppError.NoError)
        {
            Logger.Error($"Failed to install app {appid}: {result}");
        }
    }
}