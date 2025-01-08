// Purpose: To test that all the headers contain valid code, and that they compile.

#include <steamclient/IClientEngine.h>
#include <steamclient/IClientAppDisableUpdate.h>
#include <steamclient/IClientAppManager.h>
#include <steamclient/IClientApps.h>
#include <steamclient/IClientAudio.h>
#include <steamclient/IClientBilling.h>
#include <steamclient/IClientCompat.h>
#include <steamclient/IClientConfigStore.h>
#include <steamclient/IClientControllerSerialized.h>
#include <steamclient/IClientDepotBuilder.h>
#include <steamclient/IClientDeviceAuth.h>
#include <steamclient/IClientFriends.h>
#include <steamclient/IClientGameCoordinator.h>
#include <steamclient/IClientGameNotifications.h>
#include <steamclient/IClientGameSearch.h>
#include <steamclient/IClientGameServerInternal.h>
#include <steamclient/IClientGameServerPacketHandler.h>
#include <steamclient/IClientGameServerStats.h>
#include <steamclient/IClientGameStats.h>
#include <steamclient/IClientHTMLSurface.h>
#include <steamclient/IClientHTTP.h>
#include <steamclient/IClientInstallUtils.h>
#include <steamclient/IClientInventory.h>
#include <steamclient/IClientMatchmaking.h>
#include <steamclient/IClientModuleManager.h>
#include <steamclient/IClientMusic.h>
#include <steamclient/IClientNetworkDeviceManager.h>
#include <steamclient/IClientNetworking.h>
#include <steamclient/IClientNetworkingSocketsSerialized.h>
#include <steamclient/IClientNetworkingUtilsSerialized.h>
#include <steamclient/IClientParentalSettings.h>
#include <steamclient/IClientParties.h>
#include <steamclient/IClientProcessMonitor.h>
#include <steamclient/IClientProductBuilder.h>
#include <steamclient/IClientRemoteClientManager.h>
#include <steamclient/IClientRemotePlay.h>
#include <steamclient/IClientRemoteStorage.h>
#include <steamclient/IClientScreenshots.h>
#include <steamclient/IClientSecureDesktop.h>
#include <steamclient/IClientShader.h>
#include <steamclient/IClientSharedConnection.h>
#include <steamclient/IClientShortcuts.h>
#include <steamclient/IClientStreamClient.h>
#include <steamclient/IClientStreamLauncher.h>
#include <steamclient/IClientSystemAudioManager.h>
#include <steamclient/IClientSystemDisplayManager.h>
#include <steamclient/IClientSystemDockManager.h>
#include <steamclient/IClientSystemManager.h>
#include <steamclient/IClientSystemPerfManager.h>
#include <steamclient/IClientTimeline.h>
#include <steamclient/IClientUGC.h>
#include <steamclient/IClientUnifiedMessages.h>
#include <steamclient/IClientUser.h>
#include <steamclient/IClientUserStats.h>
#include <steamclient/IClientUtils.h>
#include <steamclient/IClientVideo.h>
#include <steamclient/IClientVR.h>
#include <steamclient/IRegistryInterface.h>

#include <dlfcn.h>
#include <cstdio>
#include <cstdlib>
#include <string.h>
#include <thread>

#include <tier1/cvar.h>

#include "console.h"

class CSteamConCommandBaseAccessor : public CConCommandBaseAccessor
{
public:
    ConCommand *m_pTestConCommand;
    ConVar *m_pTestConVar;

    bool RegisterConCommandBase( ConCommandBase *pVar ) override
    {
        CConCommandBaseAccessor::RegisterConCommandBase(pVar);

        if (pVar->BIsCommand())
        {
            auto cmd = reinterpret_cast<ConCommand*>(pVar);

            printf("cmd: %s, desc: %s, flags: %u,  hcc: %i\n", cmd->GetName(), cmd->GetHelpText(), cmd->GetFlags(), static_cast<int>(cmd->BHasCompletionCallback()));
            if (strcmp(cmd->GetName(), "app_info_print") == 0)
            {
                m_pTestConCommand = cmd;
            }
        } else
        {
            auto cvar = reinterpret_cast<ConVar*>(pVar);
            printf("cvar: %s : %s, flags %u, strval: %s, fval: %f, u64val: %llu\n", cvar->GetName(), cvar->GetHelpText(), cvar->GetFlags(), cvar->GetStringValue(), cvar->GetFloatValue(), cvar->GetUInt64Value());
        }

        return true;
    }
};

int main(int argc, char** argv)
{
    if (argc < 2)
    {
        fprintf(stderr, "Mode is required: [connect, create]\n");
        return 1;
    }

    bool connect;
    if (strcmp(argv[1], "connect") == 0)
    {
        connect = true;
    } else if (strcmp(argv[1], "create") == 0)
    {
        connect = false;
    } else {
        fprintf(stderr, "Invalid mode %s\n", argv[1]);
        return 1;
    }

    auto lib = dlopen("steamclient.so", RTLD_LAZY);
    if (lib == nullptr)
    {
        fprintf(stderr, "Failed to load steamclient.so! Err: %s\n", dlerror());
        lib = dlopen("libsteamclient.so", RTLD_LAZY);
        if (lib == nullptr)
        {
            fprintf(stderr, "Failed to load libsteamclient.so! Err: %s\n", dlerror());
            return 1;
        }
    }

    auto CreateInterface = reinterpret_cast<CreateInterfaceFn>(dlsym(lib, "CreateInterface"));
    if (CreateInterface == nullptr)
    {
        fprintf(stderr, "Failed to get CreateInterface!\n");
        return 1;
    }

    int ret = 0;
    auto engine = static_cast<IClientEngine*>(CreateInterface(CLIENTENGINE_INTERFACE_VERSION, &ret));
    if (engine == nullptr)
    {
        fprintf(stderr, "Failed to get IClientEngine! Err: %d\n", ret);
        return 1;
    }

    printf("Got IClientEngine %p\n", engine);


    printf("Retrieving ConCommands list\n");
    ConCommandBase::s_pAccessor = new CSteamConCommandBaseAccessor();
    engine->ConCommandInit(ConCommandBase::s_pAccessor);

    HSteamPipe pipe;
    HSteamUser user;
    if (connect)
    {
        pipe = engine->CreateSteamPipe();
        printf("Got SteamPipe handle %d\n", pipe);

        user = engine->ConnectToGlobalUser(pipe);
        printf("Connected to SteamUser handle %d\n", user);
    } else {
        user = engine->CreateGlobalUser(&pipe);
        printf("Created SteamUser handle %d, pipe %d\n", user, pipe);
    }

    IClientUtils *utils = engine->GetIClientUtils(pipe);
    if (utils == nullptr)
    {
        fprintf(stderr, "Failed to get IClientUtils!\n", ret);
    } else {
        printf("Got IClientUtils %p\n", utils);
        printf("Install path: %s\n", utils->GetInstallPath());
    }

    IClientAppManager *appManager = engine->GetIClientAppManager(user, pipe);
    if (appManager == nullptr)
    {
        fprintf(stderr, "Failed to get IClientAppManager!\n", ret);
    } else {
        printf("Got IClientAppManager %p\n", appManager);
        printf("Num installed apps: %d\n", appManager->GetNumInstalledApps());

        char buf[256];
        printf("CS2 installdir: %s, string length: %d\n", buf, appManager->GetAppInstallDir(730, buf, sizeof(buf)));
    }

    IClientUser *clientUser = engine->GetIClientUser(user, pipe);
    if (clientUser == nullptr)
    {
        fprintf(stderr, "Failed to get IClientUser!\n", ret);
    } else {
        printf("Got IClientUser %p\n", clientUser);
        printf("Logged in SteamID: %llu\n", clientUser->GetSteamID().ConvertToUint64());

        char buf[256];
        printf("Logged in user: %s, success: %d\n", buf, clientUser->GetAccountName(buf, sizeof(buf)));
    }

    printf("Release pipe, success %d\n", engine->BReleaseSteamPipe(pipe));
    printf("Shutdown client, success %d\n", engine->BShutdownIfAllPipesClosed());
    if (dlclose(lib) != 0) {
        printf("Failed to unload: %s\n", dlerror());
    } else {
        printf("Unloaded client, successfully\n");
    }

    printf("Press enter key to exit...\n");
    std::system("read");
}