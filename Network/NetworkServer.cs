using Gazette.NetworkMessages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Gazette.Network
{
	public class NetworkServer : IDisposable
	{
		public event Action<NetworkClient, NetworkMessage> ReceivedMessage;
		public ReadOnlyCollection<NetworkClient> Clients => clients.AsReadOnly();
		
		private TcpListener tcpListener;
		private CancellationTokenSource tokenSource;
		private NetworkCredential NetworkCredential;

		private List<NetworkClient> clients = new List<NetworkClient>();

		public void Start(IPEndPoint address, NetworkCredential credentials)
		{
			if (tcpListener is null)
			{
				tcpListener = new TcpListener(address);
				tcpListener.Start();
			}
			else
			{
				tcpListener.Stop();
				tcpListener = new TcpListener(address);
				tcpListener.Start();
			}

			NetworkCredential = credentials;
			tokenSource = new CancellationTokenSource();
			_ = Task.Run(AcceptConnectionLoop);
		}

		public void Stop()
		{
			tokenSource.Cancel();
			tcpListener.Stop();
			foreach (NetworkClient client in clients)
				client.Dispose();
		}

		private async Task AcceptConnectionLoop()
		{
			while(!tokenSource.IsCancellationRequested)
			{
				NetworkClient client = await NetworkClient.AcceptClientAsync(tcpListener, NetworkCredential, tokenSource.Token);
				clients.Add(client);
				client.ReceivedMessage += (message) => ReceivedMessage?.Invoke(client, message);
			}
		}

		public void Dispose()
		{
			Stop();
		}
	}
}
