using System.Diagnostics;
using CppSourceGen;
using OpenSteamworks;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data.Structs;
using OpenSteamworks.Helpers;
using OpenSteamworks.Native;

// Simple test app for testing OSW functionality, and ensuring there's no memory leaks or non-disposed resources.
// Also acts as a neat little demo app.

{
    var sc = new SteamClientBuilder()
        .WithNativeBackend(new()
        {
            ClientDLLPath = Environment.GetEnvironmentVariable("CLIENTDLL_PATH") ??
                            throw new ArgumentException("CLIENTDLL_PATH envvar must be set."),
            ConnectionTypes = ConnectionType.ExistingClient,
            EnableSpew = true,
            LoggingSettings = new() { LogIncomingCallbacks = true, LogCallbackContents = true }
        })
        .Build();

    while (false)
    {
        sc.IClientShortcuts.GetShortcutAppIds(out var shortcutAppIds);
        var appid = shortcutAppIds.Appids.First();
        Console.WriteLine("Shortcut appid " + appid);
        sc.IClientShortcuts.GetShortcutInfoByAppID(appid, out var info);
        Console.WriteLine("Shortcut info: " + info);
    
        //var gameid = CGameID.CreateFromShortcut(appid);
        //var err = sc.IClientShortcuts.LaunchShortcut(appid, ELaunchSource._2ftLibraryDetails);
        CGameID gameid;
        sc.IClientShortcuts.GetGameIDForAppID(out gameid, appid);
        Console.WriteLine("Shortcut gameid " + gameid);
        var appid2 = sc.IClientShortcuts.GetAppIDForGameID(gameid);
        Console.WriteLine("Shortcut appid2 " + appid2);
        Debugger.Break();  
    }

    //await sc.UserHelper.LogOn(76561198264836001, "onska9");

    if (sc.UserHelper.LoggedIn)
    {
        foreach (var appid in sc.UserHelper.GetSubscribedApps())
        {
            var priority = sc.IClientCompat.GetCompatToolMappingPriority(appid);
            if (priority == ECompatToolPriority.OverrideFromAppInfo)
            {
                Console.WriteLine(
                    $"{sc.AppsHelper.GetAppLocalizedName(appid)} has {priority}: {sc.IClientCompat.GetCompatToolName(appid)}");
            }
        }
    }

    foreach (var cmd in sc.ConsoleHelper.GetRegisteredCommands())
    {
        Console.WriteLine(cmd.Key);
    }
    
    sc.DownloadsHelper.DownloadChanged += OnDownloadChanged;
    
    void OnDownloadChanged(object? sender, DownloadsHelper.DownloadChangedEventArgs e)
    {
        Console.WriteLine("Download changed: ");
        Console.WriteLine(e.Paused ? "Paused" : "Running");
        if (e.DownloadingAppID == 0)
        {
            Console.WriteLine("Not downloading an app.");
        }
        else
        {
            Console.WriteLine("Downloading app: " + sc.AppsHelper.GetAppLocalizedName(e.DownloadingAppID));
        }
        
        if (e.DownloadRate == 0)
        {
            Console.WriteLine("Download speed: 0bps");
        }
        else
        {
            Console.WriteLine("Download speed: " + (e.DownloadRate / 1_000_000) + "MB/s");
            Console.WriteLine("Disk speed: " + (e.DiskRate / 1_000_000) + "MB/s");
        }
    }
    
    sc.ConsoleHelper.ExecuteCommand(["download_depot", "730", "731", "718406683749122620"]);

    // Console.WriteLine("Press any key to logout");
    // Console.ReadLine();
    //
    //sc.IClientUser.LogOff();
    
    
    while (true)
    {
        Thread.Sleep(50);
    }

    // Console.WriteLine();
    //     
    // Console.WriteLine(sc.IClientCompat.BIsCompatibilityToolEnabled(730));
    // Console.WriteLine(sc.IClientCompat.GetCompatToolName(730));
    // Console.WriteLine();
    
    // sc.IClientCompat.SpecifyCompatTool(633060, "proton_experimental", "", ECompatToolPriority.UserSetGlobal);
    //
    // Console.WriteLine(sc.IClientCompat.BIsCompatibilityToolEnabled(633060));
    // Console.WriteLine(sc.IClientCompat.GetCompatToolName(633060));
    // Console.WriteLine(sc.IClientCompat.GetCompatToolMappingPriority(633060));

    // Init these interfaces here so the timer is more accurately measuring only function calls, not interface lazy init
    // var iface = sc.IClientAppDisableUpdate;
    // var iface2 = sc.IClientUtils;
    // Stopwatch sw = new();
    //
    // Console.WriteLine("call SetAppUpdateDisabledSecondsRemaining");
    // sw.Start();
    // iface.SetAppUpdateDisabledSecondsRemaining(730, 9000);
    // sw.Stop();
    // Console.WriteLine($"SetAppUpdateDisabledSecondsRemaining took {sw.Elapsed.TotalMilliseconds}ms");
    //
    // Console.WriteLine("call GetInstallPath");
    // sw.Start();
    // string installPath = iface2.GetInstallPath();
    // sw.Stop();
    //
    // Console.WriteLine($"InstallPath: {installPath}");
    // Console.WriteLine($"GetInstallPath took {sw.Elapsed.TotalMilliseconds}ms");
    //
    // Console.WriteLine($"UserBaseFolderInstallImage: {iface2.GetUserBaseFolderInstallImage()}");
    // Console.WriteLine($"UserBaseFolderPersistentStorage: {iface2.GetUserBaseFolderPersistentStorage()}");
    // Console.WriteLine($"ManagedContentRoot: {iface2.GetManagedContentRoot()}");
    //
    // Console.WriteLine("Testing compat stuff");
    // Console.WriteLine("All compat tools:");
    // foreach (var tool in sc.CompatHelper.GetCompatTools())
    // {
    //     Console.WriteLine($"- {tool} (display name: {sc.CompatHelper.GetCompatToolDisplayName(tool)})");
    // }
    
    
    
    // Uncomment to test Messaging.
    // var conn = new Connection(new SharedConnectionTransport(sc, new ConsoleLoggerFactory()));
    // var msg = new ProtoMsg<CMsgClientChangeStatus>(EMsg.ClientChangeStatus);
    // msg.Body.PersonaSetByUser = true;
    // msg.Body.PersonaState = (uint)EPersonaState.Away;
    // var resp = await conn.SendAndAwaitResponse<CMsgPersonaChangeResponse>(msg, EMsg.ClientPersonaChangeResponse);
    // Console.WriteLine(resp.ToString());
    
    GC.Collect();
        
    // Uncomment to test Messaging.
    //conn.Dispose();
    sc.Dispose();
}

GC.Collect();
Console.WriteLine("Execution finished.");