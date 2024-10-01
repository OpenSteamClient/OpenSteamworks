using OpenSteamworks;

// See https://aka.ms/new-console-template for more information
var sc = new SteamClient("../../clientdll/build_l64/steamclient.so", ConnectionType.ExistingClient, new LoggingSettings());
sc.IClientAppDisableUpdate.SetAppUpdateDisabledSecondsRemaining(730, 9000);