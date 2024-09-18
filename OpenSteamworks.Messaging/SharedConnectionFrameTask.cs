using OpenSteamworks.Callbacks;
using OpenSteamworks.Data;
using OpenSteamworks.Generated;

namespace OpenSteamworks.Messaging;

/// <summary>
/// Polls all registered SharedConnections for new messages.
/// The SharedConnectionMessageReady_t callback is broken, and does not fire when needed.
/// </summary>
internal class SharedConnectionFrameTask
{
	private static readonly object instanceLock = new();
	private static SharedConnectionFrameTask? instance;

	public static SharedConnectionFrameTask InitializeFor(SharedConnection sharedConnection)
	{
		lock (instanceLock)
		{
			if (instance == null) {
				instance = new SharedConnectionFrameTask(SteamClient.GetCallbackManager(), SteamClient.GetIClientSharedConnection());
			}

			instance.AddConnection(sharedConnection);

			return instance;
		}
	}

	private readonly List<SharedConnection> sharedConnections = new();
	private readonly IClientSharedConnection sharedConnection;
	private SharedConnectionFrameTask(CallbackManager callbackManager, IClientSharedConnection sharedConnection)
	{
		this.sharedConnection = sharedConnection;
		callbackManager.AddFrameTask(FrameTaskFunc);
	}

	public void AddConnection(SharedConnection sharedConnection)
	{
		lock (instanceLock)
		{
			sharedConnections.Add(sharedConnection);
		}
	}

	public void RemoveConnection(SharedConnection sharedConnection)
	{
		lock (instanceLock)
		{
			sharedConnections.Remove(sharedConnection);
		}
	}

	private CUtlBuffer buffer = new(1024, 1024);
	private void FrameTaskFunc()
	{
		lock (instanceLock)
		{
			foreach (var item in sharedConnections)
			{
				while (sharedConnection.BPopReceivedMessage(item.Handle, in buffer, out uint hCall))
				{
					item.OnMsgReceived(buffer.ToManaged(), hCall);
					buffer.SeekToBeginning();
				}
			}
		}
	}
}