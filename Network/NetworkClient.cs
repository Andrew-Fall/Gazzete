using Gazette.NetworkMessages;
using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Threading.Tasks;

namespace Gazette.Network
{
	public class NetworkClient
	{
		public string Name = "";

		private readonly TcpClient tcpClient;
		private readonly BinaryFormatter binaryFormatter = new BinaryFormatter();

		public NetworkClient(TcpClient tcpClient)
		{
			this.tcpClient = tcpClient;
		}

		public async Task<NetworkMessage> GetMessageAsync(CancellationToken token)
		{
			try
			{
				return await Task.Run(() => binaryFormatter.Deserialize(tcpClient.GetStream()), token) as NetworkMessage;
			}
			catch (Exception e)
			{
				if (e is System.IO.IOException || e is InvalidOperationException)
					return new DisconnectMessage() { Name = Name };
				throw;
			}
		}

		public void SendMessage(NetworkMessage message)
		{
			Task.Run(() =>
			{
				byte[] messageBytes = message.Serialize();
				tcpClient.GetStream().WriteAsync(messageBytes, 0, messageBytes.Length);
			});
		}

		public bool IsConnected()
		{
			return IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpConnections().SingleOrDefault(x => x.RemoteEndPoint.Equals(tcpClient.Client.RemoteEndPoint))?.State == TcpState.Established;
		}
	}
}
