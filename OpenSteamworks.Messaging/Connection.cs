using OpenSteamworks.Protobuf;

namespace OpenSteamworks.Messaging;

/// <summary>
/// Helper class for wrapping a connection transport.
/// Provides high-level functionality.
/// </summary>
public sealed partial class Connection : IDisposable
{
    public BaseConnectionTransport Transport { get; }
    
    public Connection(BaseConnectionTransport transport)
    {
        this.Transport = transport;
        this.Transport.MessageReceived += OnMessageReceived;
    }

    /// <summary>
    /// Send a protobuf message and await a protobuf response.
    /// </summary>
    /// <param name="msg">The message to send</param>
    /// <param name="eMsgResponse">The eMsg of the response message to wait for</param>
    /// <typeparam name="TResult">The type of the result protobuf message</typeparam>
    /// <returns>A task which will contain the result message</returns>
    public Task<ProtoMsg<TResult>> SendAndAwaitResponse<TResult>(ProtoMsgBase msg, EMsg eMsgResponse) 
        where TResult: Google.Protobuf.IMessage<TResult>, new()
    {
        TaskCompletionSource<ProtoMsg<TResult>> tcs = new(TaskCreationOptions.RunContinuationsAsynchronously);
        
        void ReceiverFunc(IMessage resultMsg)
        {
            if (resultMsg is not ProtoMsgBase protoMsgBase)
            {
                tcs.SetException(new Exception("Result message is not a protobuf message."));
                return;
            }
            
            tcs.SetResult(protoMsgBase.AsProto<TResult>());
        }
        
        Transport.Send(msg, eMsgResponse, ReceiverFunc);
        return tcs.Task;
    }
    
    /// <summary>
    /// Send a struct message and await a struct response.
    /// </summary>
    /// <param name="msg">The message to send</param>
    /// <param name="eMsgResponse">The eMsg of the response message to wait for</param>
    /// <typeparam name="TResult">The type of the result struct message</typeparam>
    /// <returns>A task which will contain the result message</returns>
    public Task<StructMsg<TResult>> SendAndAwaitResponse<TResult>(StructMsgBase msg, EMsg eMsgResponse)
        where TResult : unmanaged
    {
        TaskCompletionSource<StructMsg<TResult>> tcs = new();
        
        void ReceiverFunc(IMessage resultMsg)
        {
            if (resultMsg is not StructMsgBase structMsgBase)
            {
                tcs.SetException(new Exception("Result message is not a struct message."));
                return;
            }
            
            tcs.SetResult(structMsgBase.AsStruct<TResult>());
        }
        
        Transport.Send(msg, eMsgResponse, ReceiverFunc);
        return tcs.Task;
    }
    
    /// <summary>
    /// Send a message without waiting for a response.
    /// </summary>
    /// <param name="msg">The message to send</param>
    public void Send(IMessage msg)
        => Transport.Send(msg);
    
    /// <summary>
    /// Sends a service method and waits for a response.
    /// </summary>
    /// <param name="msg"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public Task<ProtoMsg<TResult>> SendServiceMethod<TResult>(ProtoMsgBase msg)
        where TResult : Google.Protobuf.IMessage<TResult>, new()
        => SendAndAwaitResponse<TResult>(msg, EMsg.ServiceMethodResponse);
    
    /// <summary>
    /// Sends a service notification (i.e. no response expected)
    /// </summary>
    /// <param name="msg"></param>
    public void SendServiceNotification(ProtoMsgBase msg)
        => Send(msg);

    public void Dispose()
    {
        lock (handlersLock)
        {
            handlers.Clear();
        }
        
        this.Transport.MessageReceived -= OnMessageReceived;
        
        Transport.Dispose();
    }
}