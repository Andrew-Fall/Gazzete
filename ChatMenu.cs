using Gazette.Network;
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

		public void Connect(IPEndPoint address, string userID, string password)
		{
			TcpClient tcpClient = new TcpClient();
			tcpClient.Connect(address);

			client = new NetworkClient(tcpClient);
			client.Name = userID;
			client.SendMessage(new JoinMessage() { Name = client.Name, Password = password });
			_ = Task.Run(() => ClientLoop(tokenSource.Token));
			UpdateUsersLog();
		}

		private async Task ClientLoop(CancellationToken token)
		{
			while (!token.IsCancellationRequested)
			{
				NetworkMessage message = await client.GetMessageAsync(tokenSource.Token);
				BeginInvoke((Action)(() => HandleMessage(message)));
			}
		}

		private void HandleMessage(NetworkMessage message)
		{
			if (message is UsersMessage usersMessage)
			{
				ChatLog.Items.AddRange(usersMessage.Users);
			}
		}

		private void SendButton_Click(object sender, EventArgs e)
		{
			client.SendMessage(new ChatMessage() { Text = ChatBox.Text });
			ChatBox.Text = "";
		}

		private void ChatBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				SendButton.PerformClick();
			}
		}

		private void UpdateUsersLog()
		{
			UsersLog.Items.Add(client.Name);
		}
	}
}
