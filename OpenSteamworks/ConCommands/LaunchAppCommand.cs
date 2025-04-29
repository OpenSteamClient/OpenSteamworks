using OpenSteamClient.Logging;
using OpenSteamworks.Data;
using OpenSteamworks.Data.Enums;

namespace OpenSteamworks.ConCommands;

internal sealed class LaunchAppCommand : BaseCommand
{
    public override string Name => "app_launch";
    public override string HelpText => "app_launch <appid> <launch_option> (ELaunchSource)";

    public LaunchAppCommand(ISteamClient steamClient, ILogger logger) : base(steamClient, logger) { }

    public override void Invoke(in CCommand args)
    {
        if (!args.TryGetArg(0, out AppId_t appid) || !args.TryGetArg(1, out uint optionID))
        {
            OnInvalidArgs("AppID and LaunchOption must be specified and positive numbers!");
            return;
        }

        if (!args.TryGetArgEnum(2, out ELaunchSource launchSource))
        {
            // No correct analytics launch source for us to use, default to the launch URL.
            launchSource = ELaunchSource.SteamURL_Launch;
        }

        Logger.Info($"Launching app {appid} with launch option {optionID}...");

        SteamClient.AppManagerHelper.LaunchApp(appid, optionID, launchSource).ContinueWith(t =>
        {
            if (!t.IsFaulted)
                return;

            Logger.Error($"Failed to launch app {appid}: {t.Exception}");
        });
    }
}
