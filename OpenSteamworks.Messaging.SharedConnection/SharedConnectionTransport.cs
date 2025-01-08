using OpenSteamClient.Logging;
using OpenSteamworks.Data;
using OpenSteamworks.Generated;
using OpenSteamworks.Protobuf;

namespace OpenSteamworks.Messaging.SharedConnection;

/// <summary>
/// Send messages via OpenSteamworks IClientSharedConnection.
/// Never share the same transport between multiple connections.
/// </summary>
public sealed class SharedConnectionTransport : BaseConnectionTransport
{
    private readonly IDisposable frameTask;
    private readonly IClientUser user;
    private readonly IClientSharedConnection sharedConnection;
    private readonly ILogger logger;
    private readonly HSharedConnection handle;
    
    private CUtlBuffer msgBuf = new(256);
    
    public SharedConnectionTransport(ISteamClient steamClient, ILoggerFactory loggerFactory)
    {
        this.user = steamClient.IClientUser;
        this.sharedConnection = steamClient.IClientSharedConnection;
        
        this.logger = loggerFactory.CreateLogger($"SharedConnectionTransport-{this.handle}");
        
        this.handle = sharedConnection.AllocateSharedConnection();
        sharedConnection.InitiateConnection(this.handle);
        
        frameTask = steamClient.CallbackManager.AddFrameTask(RunFrame);
    }
    
    private void RunFrame()
    {
        if (IsDisposed)
            return;
        
        msgBuf.SeekRead(CUtlBuffer.SeekType_t.SEEK_HEAD, 0);
        msgBuf.SeekWrite(CUtlBuffer.SeekType_t.SEEK_HEAD, 0);
        while (sharedConnection.BPopReceivedMessage(handle, in msgBuf, out var hCall))
        {
            msgBuf.SeekRead(CUtlBuffer.SeekType_t.SEEK_HEAD, 0);
            // Don't need to seek read afterwards, since this operation will always reset it to zero anyhow.
            OnMsgDataReceived(msgBuf.GetReadSpan(), hCall);
            msgBuf.SeekWrite(CUtlBuffer.SeekType_t.SEEK_HEAD, 0);
        }
    }

    private void OnMsgDataReceived(ReadOnlySpan<byte> msgData, HSharedConnectionMsg hCall)
    {
        logger.Debug($"Got message, handle: {hCall}, size: {msgData.Length}");
        
        var msg = MsgBase.GetMsg(msgData);
        logger.Debug($"Msg data: {msg}");
        lock (waitingHandlersLock)
        {
            if (waitingHandlers.Remove(hCall, out ResponseHandler? handler))
            {
                handler.Invoke(msg);
            }
        }

        OnMessageReceived(msg);
    }

    
    public override void Dispose()
    {
        base.Dispose();
        frameTask.Dispose();
        sharedConnection.ReleaseSharedConnection(handle);
        msgBuf.Dispose();
    }

    protected override void RewriteMessage(IMessage message)
    {
        message.SteamID = user.GetSteamID();
    }

    private readonly object waitingHandlersLock = new();
    private readonly Dictionary<HSharedConnectionMsg, ResponseHandler> waitingHandlers = new();
    public override void Send(IMessage message, EMsg responseEMsg = EMsg.Invalid, ResponseHandler? responseCallback = null)
    {
        base.Send(message, responseEMsg, responseCallback);
        
        using var stream = new MemoryStream();
        message.Serialize(stream);
        
        if (responseEMsg != EMsg.Invalid && responseCallback != null)
        {
            lock (waitingHandlersLock)
            {
                var respHandle = sharedConnection.SendMessageAndAwaitResponse(handle, stream.ToArray(), (uint)stream.Length);
                logger.Info($"Sent msg, waiting for response with handle: {respHandle}, eMsg: {responseEMsg}");
                waitingHandlers.Add(respHandle, responseCallback);
            }

            return;
        }
        
        if (!sharedConnection.SendMessage(handle, stream.ToArray(), (uint)stream.Length))
        {
            logger.Error("Failed to SendMessage()!");
        }
        else
        {
            logger.Info("Sent msg, not waiting for response.");
        }
    }

    public override bool RequiresFiltering => true;

    public override void RegisterEMsgHandler(EMsg eMsg)
        => sharedConnection.RegisterEMsgHandler(handle, eMsg);

    public override void RegisterServiceMethodHandler(string serviceMethod)
        => sharedConnection.RegisterServiceMethodHandler(handle, serviceMethod);
}