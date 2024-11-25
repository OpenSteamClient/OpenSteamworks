using OpenSteamworks.Protobuf;

namespace OpenSteamworks.Messaging;

public delegate void ResponseHandler(IMessage responseMsg);

public abstract class BaseConnectionTransport : IDisposable
{
    /// <summary>
    /// Is the transport allowed to rewrite the message?
    /// This is done to set clientids, user steamid, and other necessary stuff.
    /// Set to false if you prefer to do this yourself.
    /// </summary>
    public bool AllowRewrite { get; set; }

    /// <summary>
    /// Send a message.
    /// If responseEMsg is set to <see cref="EMsg.ServiceMethodResponse"/>, the message is expected to be a ProtoMsg.
    /// If expecting a response, you must set <see cref="responseEMsg"/> and <see cref="responseCallback"/>, which will also register handlers automatically if filtering is required.
    /// </summary>
    /// <param name="message">The message to send.</param>
    /// <param name="responseEMsg">The EMsg of the response.</param>
    /// <param name="responseCallback">An action to call when a response is received. Setting this to a null value indicates you are not interested in the response.</param>
    public virtual void Send(IMessage message, EMsg responseEMsg = EMsg.Invalid, ResponseHandler? responseCallback = null)
    {
        ObjectDisposedException.ThrowIf(IsDisposed, this);
        
        if (responseEMsg != EMsg.Invalid && responseCallback == null)
            throw new ArgumentException("Invalid arguments. responseCallback must be set if responseEMsg is set.", nameof(responseCallback));
        
        if (message.IsServiceMethod() && responseEMsg != EMsg.ServiceMethodResponse && responseEMsg != EMsg.Invalid)
            throw new ArgumentException("Service methods must have responseEMsg = ServiceMethodResponse!", nameof(responseEMsg));
        
        if (responseEMsg == EMsg.ServiceMethodResponse)
        {
            if (message is not ProtoMsgBase protoMsg)
                throw new ArgumentException("Service methods must be protobuf!", nameof(message));

            if (string.IsNullOrEmpty(protoMsg.JobName))
                throw new ArgumentException("Service methods must have a JobName!", nameof(message));
            
            if (!message.IsServiceMethod())
                throw new ArgumentException("Expecting a service method response, but we aren't sending a service call.", nameof(message));
            
            if (RequiresFiltering)
                RegisterServiceMethodHandler(protoMsg.JobName);
        }

        if (AllowRewrite)
            RewriteMessage(message);
        
        if (responseEMsg != EMsg.Invalid && responseCallback != null)
            RegisterEMsgHandler(responseEMsg);
        
        // Base class will handle actual sending and responses
    }

    protected void OnMessageReceived(IMessage msg)
        => MessageReceived?.Invoke(this, new(msg));
    
    /// <summary>
    /// Rewrite a message to include the current SteamID or other required fields.
    /// </summary>
    protected virtual void RewriteMessage(IMessage msg)
    {
        // No-op here.
    }
    
    /// <summary>
    /// Does this transport require filtering via RegisterXXXHandler functions?
    /// If filtering is required, you will not receive messages before explicitly registering you're interested in them.
    /// </summary>
    public virtual bool RequiresFiltering => false;
    
    /// <summary>
    /// Registers a service method filter.
    /// </summary>
    public virtual void RegisterServiceMethodHandler(string serviceMethod)
    {
        // No-op in base class. 
    }

    public virtual void RegisterEMsgHandler(EMsg eMsg)
    {
        // No-op in base class.
    }
    
    
    
    /// <summary>
    /// Sent whenever any message is received, including responses.
    /// Do not use this to try and read result messages, use <see cref="Send"/> with the response options.
    /// </summary>
    public event EventHandler<MessageReceivedEventArgs>? MessageReceived;


    protected bool IsDisposed { get; private set; } = false;
    public virtual void Dispose()
    {
        ObjectDisposedException.ThrowIf(IsDisposed, this);
        IsDisposed = true;
    }
}