using Gazette.Extensions;
using Gazette.NetworkMessages;
using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Gazette.Network
{
	public sealed class NetworkClient : IDisposable
	{
		public readonly AuthenticatedStream Stream;
		public TimeSpan Timeout;

		public event Action<NetworkMessage> ReceivedMessage;

		private readonly TcpClient client;
		private readonly CancellationTokenSource tokenSource = new CancellationTokenSource();
		private readonly BufferBlock<NetworkMessage> messageBuffer = new BufferBlock<NetworkMessage>();
		private ConcurrentDictionary<Guid, TaskCompletionSource<bool>> callbacks = new ConcurrentDictionary<Guid, TaskCompletionSource<bool>>();
		private NetworkClient(TcpClient client, AuthenticatedStream stream)
		{
			this.client = client;
			Stream = stream;
			_ = Task.Run(ReceiveMessageLoop);
			_ = Task.Run(SendMessageLoop);
		}

		public static async Task<NetworkClient> ConnectAsync(IPEndPoint address, CancellationToken token)
		{
			TcpClient tcpClient = new TcpClient();
			await tcpClient.ConnectAsync(address.Address, address.Port).Cancellable(token);
			NegotiateStream stream = new NegotiateStream(tcpClient.GetStream(), false);
			await stream.AuthenticateAsClientAsync();
			return new NetworkClient(tcpClient, stream);
		}

		public static async Task<NetworkClient> AcceptClientAsync(TcpListener listener, NetworkCredential credentials, CancellationToken token)
		{
			TcpClient tcpClient = await listener.AcceptTcpClientAsync().Cancellable(token);
			NegotiateStream stream = new NegotiateStream(tcpClient.GetStream(), false);
			try
			{
				await stream.AuthenticateAsServerAsync(credentials, ProtectionLevel.EncryptAndSign, System.Security.Principal.TokenImpersonationLevel.Identification).Cancellable(token);
			}
			catch(Exception e)
			{
				throw e;
			}
			return new NetworkClient(tcpClient, stream);
		}

		/// <summary>
		/// Sends a <see cref="NetworkMessage"/> to the connected Address.
		/// Returns True if message delivery was confirmed.
		/// </summary>
		/// <param name="message">The NetworkMessage to send.</param>
		/// <param name="token">A token to cancel the task early.</param>
		/// <returns>True if delivery was confirmed. Otherwise False.</returns>
		public async Task<bool> SendMessageAsync(NetworkMessage message, CancellationToken token)
		{
			if (!callbacks.TryAdd(message.MessageGuid, new TaskCompletionSource<bool>()))
				// This should statistically never happen, so it would indicate an issue with our code.
				throw new ArgumentException($"{callbacks.GetType()} {nameof(callbacks)} already contains {message.MessageGuid.GetType()} {nameof(message.MessageGuid)} ({message.MessageGuid})");
			if (!messageBuffer.Post(message))
				// This should never happen as it's size is not limited, but just in case to avoid a silent error.
				throw new InvalidOperationException($"{messageBuffer.GetType()} {nameof(messageBuffer)} is full.");

			// If Timeout is greater than zero, enable timing out. Otherwise, wait for a 
			// return message or cancellation.
			if (Timeout.CompareTo(TimeSpan.Zero) == 1)
			{
				Task callbackTask = callbacks[message.MessageGuid].Task.Cancellable(token);
				Task result = await Task.WhenAny(callbackTask, Task.Delay(Timeout));
				// If the task that returned first isn't the callback, we timed out.
				return result == callbackTask;
			}
			else
			{
				await callbacks[message.MessageGuid].Task.Cancellable(token);
				return true;
			}
		}

		private async Task SendMessageLoop()
		{
			while (!tokenSource.IsCancellationRequested)
			{
				try
				{
					NetworkMessage message = await messageBuffer.ReceiveAsync(tokenSource.Token);
					await message.Serialize(Stream);
				}
				catch (TaskCanceledException) { }
			}
		}

		private async Task ReceiveMessageLoop()
		{
			while(!tokenSource.IsCancellationRequested)
			{
				NetworkMessage message = await NetworkMessage.Deserialize(Stream, tokenSource.Token);
				if (message is ReceivedMessage received)
				{
					callbacks[received.MessageGuid].SetResult(true);
				}
				else
				{
					messageBuffer.Post(new ReceivedMessage() { MessageGuid = message.MessageGuid });
					ReceivedMessage?.Invoke(message);
				}
			}
		}

		public void Dispose()
		{
			tokenSource.Cancel();
			Stream.Dispose();
			client.Dispose();
		}
	}
}
