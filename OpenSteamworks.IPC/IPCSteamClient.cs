using OpenSteamClient.Logging;
using OpenSteamworks.Data;
using OpenSteamworks.Data.Structs;
using OpenSteamworks.Generated;

namespace OpenSteamworks.IPC;

internal sealed class IPCSteamClientImpl : ISteamClientImpl
{
    public void Dispose()
    {
        //TODO: Dispose IPCClient, etc.
    }


    private readonly ILogger logger;
    private readonly IPCSteamClientEngine ipcClientEngine;
    public IPCSteamClientImpl(ILogger logger, IPCSteamClientCreateOptions createOptions)
    {
        this.logger = logger;
        ipcClientEngine = new IPCSteamClientEngine();
    }

    public HSteamPipe Pipe { get; set; }
    public HSteamUser User { get; set; }

    public int SteamPID
        => ipcClientEngine.GetPipe(Pipe).RemotePID;

    public IClientEngine IClientEngine 
        => ipcClientEngine;
    
    public bool BGetCallback(out CallbackMsg_t callbackMsg)
    {
        //TODO: Callbacks.
        callbackMsg = default;
        return false;
    }

    public void FreeLastCallback()
    {
        //TODO: Callbacks.
    }
}