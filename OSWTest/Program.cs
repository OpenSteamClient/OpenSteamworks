using System.Diagnostics;
using OpenSteamClient.Logging;
using OpenSteamworks;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Messaging;
using OpenSteamworks.Messaging.SharedConnection;
using OpenSteamworks.Native;
using OpenSteamworks.Protobuf;

// Simple test app for testing OSW functionality, and ensuring there's no memory leaks or non-disposed resources.
// Also acts as a neat little demo app.

{
    var sc = new SteamClientBuilder()
        .WithNativeBackend(new()
        {
            ClientDLLPath = Environment.GetEnvironmentVariable("CLIENTDLL_PATH") ??
                            throw new ArgumentException("CLIENTDLL_PATH envvar must be set."),
            ConnectionTypes = ConnectionType.ExistingClient
        })
        .Build();

    // Init these interfaces here so the timer is more accurately measuring only function calls, not interface lazy init
    var iface = sc.IClientAppDisableUpdate;
    var iface2 = sc.IClientUtils;
    Stopwatch sw = new();

    Console.WriteLine("call SetAppUpdateDisabledSecondsRemaining");
    sw.Start();
    iface.SetAppUpdateDisabledSecondsRemaining(730, 9000);
    sw.Stop();
    Console.WriteLine($"SetAppUpdateDisabledSecondsRemaining took {sw.Elapsed.TotalMilliseconds}ms");

    Console.WriteLine("call GetInstallPath");
    sw.Start();
    string installPath = iface2.GetInstallPath();
    sw.Stop();
    
    Console.WriteLine($"InstallPath: {installPath}");
    Console.WriteLine($"GetInstallPath took {sw.Elapsed.TotalMilliseconds}ms");
    
    Console.WriteLine($"UserBaseFolderInstallImage: {iface2.GetUserBaseFolderInstallImage()}");
    Console.WriteLine($"UserBaseFolderPersistentStorage: {iface2.GetUserBaseFolderPersistentStorage()}");
    Console.WriteLine($"ManagedContentRoot: {iface2.GetManagedContentRoot()}");
    
    Console.WriteLine("Testing compat stuff");
    Console.WriteLine("All compat tools:");
    foreach (var tool in sc.CompatHelper.GetCompatTools())
    {
        Console.WriteLine($"- {tool} (display name: {sc.CompatHelper.GetCompatToolDisplayName(tool)})");
    }
    
    
    
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