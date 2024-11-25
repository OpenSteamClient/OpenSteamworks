using OpenSteamworks.Protobuf;

namespace OpenSteamworks.Messaging;

public sealed partial class Connection
{
    private abstract class BaseHandler(Connection connection) : IDisposable
    {
        public abstract void Execute(IMessage msg);

        public void Dispose()
        {
            lock (connection.handlersLock)
            {
                connection.handlers.Remove(this);
            }
        }
    }

    private sealed class EMsgHandler(Connection connection, EMsg eMsg, Action<IMessage> handlerFunc)
        : BaseHandler(connection)
    {
        internal readonly EMsg EMsg = eMsg;

        public override void Execute(IMessage msg)
        {
            if (msg.EMsg != EMsg)
                return;

            handlerFunc(msg);
        }
    }
    
    private sealed class ServiceHandler(Connection connection, string serviceMethod, Action<ProtoMsgBase> handlerFunc)
        : BaseHandler(connection)
    {
        internal readonly string ServiceMethod = serviceMethod;

        public override void Execute(IMessage msg)
        {
            if (!msg.IsServiceMethod())
                return;
            
            if (msg is not ProtoMsgBase protoMsg)
                return;

            if (!string.Equals(protoMsg.JobName, ServiceMethod, StringComparison.OrdinalIgnoreCase))
                return;

            handlerFunc(protoMsg);
        }
    }
    
    private readonly object handlersLock = new();
    private readonly List<BaseHandler> handlers = new();
    
    private void OnMessageReceived(object? sender, MessageReceivedEventArgs e)
    {
        lock (handlersLock)
        {
            foreach (var handler in handlers)
            {
                handler.Execute(e.ReceivedMessage);
            }
        }
    }

    private BaseHandler RegisterHandlerInternal(BaseHandler handler)
    {
        lock (handlersLock)
        {
            handlers.Add(handler);
        }
        
        // If filtering is required, figure out the type of handler and register filters appropriately.
        if (!Transport.RequiresFiltering) 
            return handler;
        
        switch (handler)
        {
            case EMsgHandler eMsgHandler:
                Transport.RegisterEMsgHandler(eMsgHandler.EMsg);
                break;
            case ServiceHandler serviceHandler:
                Transport.RegisterEMsgHandler(EMsg.ServiceMethod);
                Transport.RegisterServiceMethodHandler(serviceHandler.ServiceMethod);
                break;
        }


        return handler;
    }

    /// <summary>
    /// Registers a handler function for an eMsg.
    /// </summary>
    /// <param name="eMsg">The eMsg to listen for</param>
    /// <param name="handler">The handler to invoke</param>
    public IDisposable RegisterHandler(EMsg eMsg, Action<IMessage> handler)
        => RegisterHandlerInternal(new EMsgHandler(this, eMsg, handler));
    
    /// <summary>
    /// Registers a handler function for a service method.
    /// </summary>
    /// <param name="serviceMethod">The service method to listen for</param>
    /// <param name="handler">The handler to invoke</param>
    public IDisposable RegisterHandler(string serviceMethod, Action<ProtoMsgBase> handler)
        => RegisterHandlerInternal(new ServiceHandler(this, serviceMethod, handler));
}