using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Gazette.Network;
using System.Net;
using Gazette.NetworkMessages;
using Gazette.Sanitization;
using System.Threading;
using Gazette.Database;

namespace Gazette.CustomControls
{
	public partial class ServerTab : UserControl
	{
		private MySqlConnection sqlConnection;
		private NetworkServer networkServer;
		private CancellationTokenSource tokenSource = new CancellationTokenSource();

		private const string ClosedText = "Host";
		private const string OpenText = "Stop";
		private const string ConnectingText = "Connecting...";

		private Dictionary<NetworkClient, string> clients = new Dictionary<NetworkClient, string>();

		public ServerTab()
		{
			InitializeComponent();
		}

		#region HostButton
		private async void HostButton_Click(object sender, EventArgs e)
		{
			if (sqlConnection != null && sqlConnection.State == ConnectionState.Open)
			{
				await Disconnect();
				HostButton.Text = ClosedText;
			}
			else if (sqlConnection == null || sqlConnection.State == ConnectionState.Closed)
			{
				HostButton.Enabled = false;
				HostButton.Text = ConnectingText;
				if (await Connect())
					HostButton.Text = OpenText;
				else
					HostButton.Text = ClosedText;
				HostButton.Enabled = true;
			}
		}

		#endregion

		#region Server Connection
		async Task<bool> Connect()
		{
			if (sqlConnection?.State == ConnectionState.Open)
			{
				Log("Server already started, close previous connections first.");
				return false;
			}
			if (!int.TryParse(ServerPortTextBox.Text, out int port))
			{
				Log("Invalid port.");
				return false;
			}

			DatabaseIPTextBox.Enabled = false;
			DatabaseNameTextBox.Enabled = false;
			DatabaseUserIDTextBox.Enabled = false;
			DatabasePasswordTextBox.Enabled = false;
			ServerPortTextBox.Enabled = false;

			MySqlConnectionStringBuilder connectionStringBuilder = new MySqlConnectionStringBuilder()
			{
				Server = DatabaseIPTextBox.Text,
				Database = DatabaseNameTextBox.Text,
				UserID = DatabaseUserIDTextBox.Text,
				Password = DatabasePasswordTextBox.Text
			};

			sqlConnection = new MySqlConnection(connectionStringBuilder.ConnectionString);
			try
			{
				Log("Connecting to database.");

				// MySQL hasn't implimented this correctly, so you have to create a task.
				await Task.Run(() => sqlConnection.OpenAsync());

				Log("Connected to database.");

				networkServer = new NetworkServer();
				networkServer.Start(new IPEndPoint(IPAddress.Loopback, port), CredentialCache.DefaultNetworkCredentials);
				networkServer.ReceivedMessage += (client, message) => Invoke((Action)(() => NetworkServer_ReceivedMessage(client, message)));

				return true;
			}
			catch (Exception exception)
			{
				DatabaseIPTextBox.Enabled = true;
				DatabaseNameTextBox.Enabled = true;
				DatabaseUserIDTextBox.Enabled = true;
				DatabasePasswordTextBox.Enabled = true;
				ServerPortTextBox.Enabled = true;
				Log(exception.Message);
				return false;
			}
		}

		private void NetworkServer_ReceivedMessage(NetworkClient client, NetworkMessage message)
		{
			if (message is JoinMessage joinMessage)
			{
				#region Joining
				if (!Sanitizer.NameIsValid(joinMessage.Name))
				{
					_ = client.SendMessageAsync(new RejectMessage() { Reason = "Invalid Name" }, tokenSource.Token);
					return;
				}

				if (!Sanitizer.PasswordIsValid(joinMessage.Password))
				{
					_ = client.SendMessageAsync(new RejectMessage() { Reason = "Invalid Password" }, tokenSource.Token);
					return;
				}

				using (MySqlCommand userCommand = CommandBuilder.CreateCommand("VerifyUser", sqlConnection, ("@nameIn", joinMessage.Name, MySqlDbType.VarChar), ("@passwordIn", joinMessage.Password, MySqlDbType.VarChar)))
				{
					userCommand.CommandType = System.Data.CommandType.StoredProcedure;
					if (Convert.ToInt32(userCommand.ExecuteScalar()) == 0)
					{
						userCommand.CommandText = "HasUser";
						if (Convert.ToInt32(userCommand.ExecuteScalar()) == 0)
						{
							userCommand.CommandText = "InsertUser";
							userCommand.ExecuteNonQuery();
						}
						else
						{
							_ = client.SendMessageAsync(new RejectMessage() { Reason = "Wrong Username or Password" }, tokenSource.Token);
							Log($"{joinMessage.Name} tried to join with a wrong password.");
							return;
						}
					}
				}

				Dictionary<int, InternalMessage> data = new Dictionary<int, InternalMessage>(50);

				using (MySqlCommand historyCommand = CommandBuilder.CreateCommand("GetHistory", sqlConnection, ("@indexIn", -1, MySqlDbType.Int32)))
				{
					historyCommand.CommandType = System.Data.CommandType.StoredProcedure;
					using (MySqlDataReader reader = historyCommand.ExecuteReader())
					{
						while (reader.Read())
						{
							data.Add(reader.GetInt32("id"), new InternalMessage() { Name = reader.GetString("name"), Message = reader.GetString("message") });
						}
					}
				}

				_ = client.SendMessageAsync(new AcceptedMessage(), tokenSource.Token);
				_ = client.SendMessageAsync(new ChatHistoryMesssage() { messages = data }, tokenSource.Token);
				clients.Add(client, joinMessage.Name);
				ClientListBox.Items.Clear();
				ClientListBox.Items.AddRange(clients.Values.ToArray());
				MessageClients(new JoinMessage() { Name = clients[client], Password = "" });
				
				Log($"{clients[client]} joined the server.");
				#endregion
			}
			else if (message is ChatMessage chatMessage)
			{
				#region New Chat Message
				// They haven't sent a JoinMessage yet, reject them
				if (!clients.ContainsKey(client))
				{
					_ = client.SendMessageAsync(new RejectMessage() { Reason = "Connection not validated." }, tokenSource.Token);
					return;
				}

				if (string.IsNullOrWhiteSpace(chatMessage.Text))
					return;

				MySqlCommand command = CommandBuilder.CreateCommand("InsertMessage", sqlConnection, ("@messageIn", chatMessage.Text, MySqlDbType.Text), ("@nameIn", clients[client], MySqlDbType.VarChar));
				command.CommandType = System.Data.CommandType.StoredProcedure;
				int index = Convert.ToInt32(command.ExecuteScalar());

				Log($"{clients[client]} says, \"{chatMessage.Text}\"");
				MessageClients(new ChatHistoryMesssage() { messages = new Dictionary<int, InternalMessage>() { [index] = new InternalMessage() { Name = clients[client], Message = chatMessage.Text } } });
				#endregion
			}
			else if(message is ChatRequestMessage chatRequestMessage)
			{
				#region Chat Request Message
				Dictionary<int, InternalMessage> data = new Dictionary<int, InternalMessage>(50);

				using (MySqlCommand historyCommand = CommandBuilder.CreateCommand("GetHistory", sqlConnection, ("@indexIn", chatRequestMessage.index, MySqlDbType.Int32)))
				{
					historyCommand.CommandType = CommandType.StoredProcedure;
					using (MySqlDataReader reader = historyCommand.ExecuteReader())
					{
						while (reader.Read())
						{
							data.Add(reader.GetInt32("id"), new InternalMessage() { Name = reader.GetString("name"), Message = reader.GetString("message") });
						}
					}
				}

				_ = client.SendMessageAsync(new ChatHistoryMesssage() { messages = data }, tokenSource.Token);
				#endregion
			}
		}

		private void MessageClients<T>(T message) where T : NetworkMessage, IClientMessage
		{
			foreach (NetworkClient client in clients.Keys)
				_ = client.SendMessageAsync(message, tokenSource.Token);
		}

		async Task Disconnect()
		{
			Log("Stopping Server.");
			Task stopTask = sqlConnection.CloseAsync();
			networkServer.Stop();
			await stopTask;
			Log("Server stopped.");

			DatabaseIPTextBox.Enabled = true;
			DatabaseNameTextBox.Enabled = true;
			DatabaseUserIDTextBox.Enabled = true;
			DatabasePasswordTextBox.Enabled = true;
			ServerPortTextBox.Enabled = true;
		}
		#endregion

		void Log(string message, bool displayTime = true)
		{
			if (displayTime)
				ServerLogListBox.Items.Add($"{DateTime.Now.ToLongTimeString()}: {message}");
			else
				ServerLogListBox.Items.Add(message);
		}

		public void Connect(string databaseIP, string databaseName, string databaseUserID, string databasePassword, string serverPort)
		{
			DatabaseIPTextBox.Text = databaseIP;
			DatabaseNameTextBox.Text = databaseName;
			DatabaseUserIDTextBox.Text = databaseUserID;
			DatabasePasswordTextBox.Text = databasePassword;
			ServerPortTextBox.Text = serverPort;

			HostButton_Click(null, null);
		}

		private void ServerLogListBox_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			int index = ServerLogListBox.IndexFromPoint(e.Location);
			if (index != ListBox.NoMatches)
			{
				MessageBox.Show(ServerLogListBox.Items[index].ToString());
			}
		}
	}
}
