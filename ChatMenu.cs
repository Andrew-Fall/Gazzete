﻿using Gazette.Network;
using Gazette.NetworkMessages;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gazette
{
	public partial class ChatMenu : Form
	{
		private NetworkClient client;
		private CancellationTokenSource tokenSource = new CancellationTokenSource();
		public ChatMenu()
		{
			InitializeComponent();
		}

		public async Task ConnectAsync(IPEndPoint address, string userID)
		{
			TcpClient tcpClient = new TcpClient();
			tcpClient.Connect(address);

			client = new NetworkClient(tcpClient);
			client.Name = userID;
			await client.SendMessageAsync(new JoinMessage() { Name = client.Name }, tokenSource.Token);
			_ = Task.Run(() => ClientLoop(tokenSource.Token));
			
		}

		private async Task ClientLoop(CancellationToken token)
		{
			while (!token.IsCancellationRequested)
			{
				HandleMessage(await client.GetMessageAsync(tokenSource.Token));
			}
		}

		private void HandleMessage(NetworkMessage message)
		{

		}

		private async void SendButton_Click(object sender, EventArgs e)
		{
			await client.SendMessageAsync(new ChatMessage() { Text = ChatBox.Text }, tokenSource.Token);
			ChatBox.Text = "";
		}

		private void ChatBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				SendButton.PerformClick();
			}
		}
	}
}
