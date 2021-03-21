using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gazette.Network;
using System.Threading;
using Gazette.NetworkMessages;
using System.Net;
using System.Diagnostics;

namespace Gazette.CustomControls
{
	public partial class ChatTab : UserControl
	{
		public JoinTab JoinTab;

		private TabPage Page => JoinTab.Page;
		private bool waitingForHistory;
		private NetworkClient client;
		private CancellationTokenSource tokenSource = new CancellationTokenSource();

		TaskCompletionSource<(bool succeeded, string errorMsg)> connectionTask;

		public ChatTab()
		{
			InitializeComponent();
			myList1.AfterSroll += (e) => MyList1_AfterSroll(e.newValue, e.minScroll, e.maxScroll);
		}

		private void ReceivedMessage(NetworkMessage message)
		{
			if (message is AcceptedMessage acceptedMessage)
			{
				connectionTask.SetResult((true, ""));
			}
			else if (message is RejectMessage rejectMessage)
			{
				connectionTask.SetResult((false, rejectMessage.Reason));
			}
			else if (message is UsersMessage usersMessage)
			{
				Invoke((Action)(() =>
			   {
				   ClientsListBox.Items.Clear();
				   ClientsListBox.Items.AddRange(usersMessage.Users);
			   }));
			}
			else if (message is ChatHistoryMesssage chatMessage)
			{
				waitingForHistory = false;
				if (chatMessage.messages?.Count > 0)
					if (myList1.InvokeRequired)
						myList1.Invoke((Action)(() =>
						{
							myList1.AddRange(chatMessage.messages.Select(kvp => (kvp.Key, $"{kvp.Value.Name} says, \"{kvp.Value.Message}\"")).ToArray());
						}));
					else
						myList1.AddRange(chatMessage.messages.Select(kvp => (kvp.Key, $"{kvp.Value.Name} says, \"{kvp.Value.Message}\"")).ToArray());
			}
		}

		private async void SendButton_Click(object sender, EventArgs e)
		{
			client.Timeout = TimeSpan.FromSeconds(1);
			ChatTextBox.Enabled = false;
			var sentTask = client.SendMessageAsync(new ChatMessage() { Text = ChatTextBox.Text }, tokenSource.Token);
			if (!await sentTask)
				MessageBox.Show("Message failed to send!");
			else
				ChatTextBox.Text = "";
			ChatTextBox.Enabled = true;
		}

		private void ChatTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				SendButton.PerformClick();
				e.Handled = true;
			}
		}

		private void DisconnectButton_Click(object sender, EventArgs e)
		{
			Page.Controls.Remove(this);
			Page.Controls.Add(JoinTab);
			JoinTab.Dock = DockStyle.Fill;
			Page.Name = "New Connection";
			client.Dispose();
		}
		public async Task<(bool succeeded, string errorMsg)> ConnectAsync(IPEndPoint address, string name, string password)
		{
			try { client = await NetworkClient.ConnectAsync(address, tokenSource.Token); }
			catch (Exception e) { return (false, e.Message); }

			client.ReceivedMessage += (message) => ReceivedMessage(message);
			connectionTask = new TaskCompletionSource<(bool, string)>();

			if (!await client.SendMessageAsync(new JoinMessage() { Name = name, Password = password }, tokenSource.Token))
				return (false, "Connected Timed Out.");

			var result = await connectionTask.Task;
			if (result.succeeded)
			{
				JoinTab.Page.Text = $"{address}";
				return (true, "");
			}
			else
				return result;
		}
		private void MyList1_AfterSroll(int newValue, int minIndex, int maxIndex)
		{
			if(newValue <= maxIndex / 4 && !waitingForHistory && !myList1.data.ContainsKey(0))
			{
				waitingForHistory = true;
				_ = client.SendMessageAsync(new ChatRequestMessage() { index = myList1.MinIndex }, tokenSource.Token);
			}
			if(newValue >= maxIndex * 3 / 4  && !waitingForHistory)
			{
				waitingForHistory = true;
				_ = client.SendMessageAsync(new ChatRequestMessage() { index = myList1.MaxIndex + 50 }, tokenSource.Token);
			}
		}
	}
}
