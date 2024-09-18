using OpenSteamClient.Logging;
using OpenSteamworks.Callbacks;
using OpenSteamworks.Callbacks.Structs;
using OpenSteamworks.Data;
using OpenSteamworks.Generated;
using OpenSteamworks.Messaging;
using OpenSteamworks.Protobuf;

namespace OpenSteamworks.Messaging;

public interface IConnectionMsgHandler
{
	public EMsg EMsg { get; }
	public string? ServiceMethod { get; }
	internal void Invoke(MsgBase msg);
}


public sealed class SharedConnection : IDisposable
{
	private class EMsgHandler : IConnectionMsgHandler
	{
		public EMsg EMsg { get; }
		public string? ServiceMethod => null;

		private readonly Action<IConnectionMsgHandler, MsgBase> handler;
		public EMsgHandler(EMsg msg, Action<IConnectionMsgHandler, MsgBase> handler)
		{
			this.EMsg = msg;
			this.handler = handler;
		}

		public void Invoke(MsgBase msg)
			=> handler.Invoke(this, msg);
	}

	private class ServiceMethodHandler : IConnectionMsgHandler
	{
		public EMsg EMsg => EMsg.Invalid;
		public string? ServiceMethod { get; }

		private readonly Action<IConnectionMsgHandler, ProtoMsgBase> handler;
		public ServiceMethodHandler(string serviceMethod, Action<IConnectionMsgHandler, ProtoMsgBase> handler)
		{
			this.ServiceMethod = serviceMethod;
			this.handler = handler;
		}

		public void Invoke(MsgBase msg)
			=> handler.Invoke(this, msg.AsProtoBase());
	}

	private readonly IClientUser clientUser;
	private readonly IClientSharedConnection sharedConnection;
	private readonly ILogger logger;
	private readonly SharedConnectionFrameTask sharedConnectionFrameTask;
	private SharedConnection(IClientUser clientUser, IClientSharedConnection sharedConnection, ILoggerFactory loggerFactory)
	{
		this.logger = loggerFactory.CreateLogger("SharedConnection");
		this.clientUser = clientUser;
		this.sharedConnection = sharedConnection;
		this.Handle = sharedConnection.AllocateSharedConnection();
		this.Register(EMsg.ServiceMethod, OnServiceMethod);
		this.Register(EMsg.ServiceMethodResponse, OnServiceMethod);
		this.sharedConnectionFrameTask = SharedConnectionFrameTask.InitializeFor(this);
	}

	private void OnServiceMethod(IConnectionMsgHandler handler, MsgBase msg)
	{
		if (!msg.IsProto)
		{
			logger.Warning("Got non-proton service method!");
			return;
		}

		// Run service method handlers
		var asProto = msg.AsProtoBase();
		if (string.IsNullOrEmpty(asProto.JobName)) 
		{
			logger.Warning("Got empty JobName!");
			return;
		}

		ExecuteServiceMethodHandlers(asProto);
	}

	public static SharedConnection AllocateConnection()
		=> new(SteamClient.GetIClientUser(), SteamClient.GetIClientSharedConnection(), Logging.LoggerFactory);


	public HSharedConnection Handle { get; }
	public async Task SendMessage(IMessage message)
	{
		await ConnectIfNotConnected();
		RewriteMessage(message);
		using var stream = new MemoryStream();
		message.Serialize(stream);

		sharedConnection.SendMessage(Handle, stream.ToArray(), (uint)stream.Length);
	}

	public async Task<MsgBase> SendAndWaitForResponse(EMsg responseMsg, IMessage message)
	{
		if (responseMsg == EMsg.ServiceMethodResponse)
		{
			throw new ArgumentException("Cannot wait for service method response with this function! Use SendAndWaitForServiceResponse(IMessage) function instead.");
		}

		await ConnectIfNotConnected();
		RewriteMessage(message);
		using var stream = new MemoryStream();
		message.Serialize(stream);

		var task = WaitForMessage(responseMsg);
		sharedConnection.SendMessageAndAwaitResponse(Handle, stream.ToArray(), (uint)stream.Length);

		return await task;
	} 

	public async Task<ProtoMsg<TResult>> SendAndWaitForServiceResponse<TResult, TMessage>(ProtoMsg<TMessage> message)
	where TResult: Google.Protobuf.IMessage<TResult>, new()
    where TMessage: Google.Protobuf.IMessage<TMessage>, new() {
		await ConnectIfNotConnected();
		RewriteMessage(message);
		using var stream = new MemoryStream();
		message.Serialize(stream);

		var task = WaitForServiceMessage(message.JobName);

		sharedConnection.SendMessageAndAwaitResponse(Handle, stream.ToArray(), (uint)stream.Length);
		return (await task).AsProto<TResult>();
	} 

	private void RewriteMessage(IMessage msg)
	{
		msg.SteamID = clientUser.GetSteamID();
	}

	private async Task ConnectIfNotConnected()
	{
		if (!clientUser.BConnected()) {
			clientUser.EConnect();
			while (!clientUser.BConnected())
			{
				await Task.Delay(50);
			}
		}
	}

	public Task<MsgBase> WaitForMessage(EMsg eMsg)
	{
		TaskCompletionSource<MsgBase> tcs = new(TaskCreationOptions.RunContinuationsAsynchronously);
		this.Register(eMsg, (IConnectionMsgHandler handler, MsgBase msg) =>
		{
			tcs.SetResult(msg);
			DisposeHandler(handler);
		});

		return tcs.Task;
	}

	public Task<ProtoMsgBase> WaitForServiceMessage(string serviceMethod)
	{
		TaskCompletionSource<ProtoMsgBase> tcs = new(TaskCreationOptions.RunContinuationsAsynchronously);
		this.RegisterServiceMsg(serviceMethod, (IConnectionMsgHandler handler, ProtoMsgBase msg) =>
		{
			tcs.SetResult(msg);
			DisposeHandler(handler);
		});

		return tcs.Task;
	}
	
	public void DisposeHandler(IConnectionMsgHandler handler)
	{
		lock (recvLock)
		{
			handlers.Remove(handler);
			serviceHandlers.Remove(handler);
		}
	}


	private readonly object recvLock = new();
	internal void OnMsgReceived(byte[] msgBytes, uint hCall)
	{
		logger.Debug($"Got message {hCall}, size: {msgBytes.Length}");
		
		lock (recvLock)
		{
			var msg = MsgBase.GetMsg(msgBytes);
			Console.WriteLine("Got msg " + msg.ToString());
			ExecuteHandlers(msg);
		}
	}

	private void ExecuteServiceMethodHandlers(ProtoMsgBase msg)
	{
		lock (recvLock)
		{
			// This is still not ideal. Ideally we would see the SourceJobIDs and use those to match response messages, but the API doesn't expose us a way to get them, as they're generated by steamclient.so after passing in our message.
			foreach (var item in serviceHandlers.ToList().Where(h => h.ServiceMethod == msg.JobName))
			{
				item.Invoke(msg);
			}
		}
	}
	
	private void ExecuteHandlers(MsgBase msg)
	{		
		lock (recvLock)
		{
			// This will call OnServiceMethod, if it was a service method
			foreach (var item in handlers.ToList().Where(h => h.EMsg == msg.EMsg))
			{
				item.Invoke(msg);
			}
		}

	}

	private readonly List<IConnectionMsgHandler> handlers = new();
	private readonly List<IConnectionMsgHandler> serviceHandlers = new();
	public void Register(EMsg msg, Action<IConnectionMsgHandler, MsgBase> handler)
	{
		lock (recvLock)
		{
			sharedConnection.RegisterEMsgHandler(Handle, msg);
			handlers.Add(new EMsgHandler(msg, handler));
		}
	}

	public void RegisterServiceMsg(string serviceMethod, Action<IConnectionMsgHandler, ProtoMsgBase> handler)
	{
		lock (recvLock)
		{
			sharedConnection.RegisterServiceMethodHandler(Handle, serviceMethod);
			serviceHandlers.Add(new ServiceMethodHandler(serviceMethod, handler));
		}
	}

	public void Dispose()
	{
		lock (recvLock)
		{
			sharedConnectionFrameTask.RemoveConnection(this);
			sharedConnection.ReleaseSharedConnection(Handle);
			handlers.Clear();
			serviceHandlers.Clear();
		}
	}
}