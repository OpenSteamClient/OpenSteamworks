using System;
using OpenSteamworks.Data;
using OpenSteamworks.Data.Structs;
using OpenSteamworks.Generated;

namespace OpenSteamworks;

internal interface ISteamClientImpl : IDisposable
{
    /// <summary>
    /// The current pipe which was retrieved from IClientEngine.
    /// Do not modify this value yourself, it is managed by the wrapper class.
    /// </summary>
    public HSteamPipe Pipe { get; set; }
    
    /// <summary>
    /// The current user which was retrieved from IClientEngine.
    /// Do not modify this value yourself, it is managed by the wrapper class.
    /// </summary>
    public HSteamUser User { get; set; }
    
    /// <summary>
    /// The remote PID of the connected Steam instance. 
    /// </summary>
    public int SteamPID { get; }
    
    public IClientEngine IClientEngine { get; }
    
    public bool BGetCallback(out CallbackMsg_t callbackMsg);
    public void FreeLastCallback();
}