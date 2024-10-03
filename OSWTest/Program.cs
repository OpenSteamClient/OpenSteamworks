using System.Diagnostics;
using OpenSteamworks;

// Simple test app for testing OSW functionality. 
var sc = new SteamClient(Environment.GetEnvironmentVariable("CLIENTDLL_PATH") ?? throw new ArgumentException("CLIENTDLL_PATH envvar must be set."), ConnectionType.ExistingClient, new LoggingSettings());

// Init these interfaces here so the timer is more accurately measuring only function calls
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