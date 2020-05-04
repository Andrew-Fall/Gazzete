using Gazette.Database;
using Gazette.NetworkMessages;
using Gazette.Sanitization;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Gazette.Network
{
	public class NetworkServer
	{
		public event Action<string[]> ClientsChanged;
		public event Action<string> OutputLog;

		private bool running;
		private TcpListener listener;
		private MySqlConnection sqlConnection;
		private CancellationTokenSource tokenSource = new CancellationTokenSource();
		private List<NetworkClient> clients = new List<NetworkClient>();

		public NetworkServer(IPEndPoint address, MySqlConnection sqlConnection)
		{
			listener = new TcpListener(address);
			this.sqlConnection = sqlConnection;
		}

		public bool Start()
		{
			if (running)
			{
				Log("Server is already running!");
				return false;
			}

			Log("Starting server.");
			listener.Start();
			running = true;
			Task.Run(() => NewConnectionLoop());
			Task.Run(() => ClientLoop());
			Log("Server started.");
			return true;
		}

		public void Stop()
		{
			running = false;
			listener.Stop();
			tokenSource.Cancel();
		}

		private async void NewConnectionLoop()
		{
			while (running)
			{
				try
				{
					NetworkClient client = new NetworkClient(await listener.AcceptTcpClientAsync());
					_ = Task.Run(() => HandleClient(client));
				}
				catch (ObjectDisposedException) { }
			}
		}

		private async void ClientLoop()
		{
			while (running)
			{
				// We scan every second.
				await Task.Delay(TimeSpan.FromSeconds(1));
				bool shouldUpdate = false;

				foreach (NetworkClient client in clients.ToList())  // ToList() creates a copy so we can edit it
				{
					// If the clients are connected, do nothing
					if (client.IsConnected())
						continue;

					// Otherwise remove them and tell listeners about the change
					clients.Remove(client);
					Log($"{client.Name} disconnected from the server.");
					MessageClients(new DisconnectMessage() { Name = client.Name });
					shouldUpdate = true;
				}

				if (shouldUpdate)
					UpdateClients();
			}
		}

		private async Task HandleClient(NetworkClient client)
		{
			try
			{
				while (running)
					HandleMessage(await client.GetMessageAsync(tokenSource.Token), client);
			}
			catch (Exception e)
			{
				Log($"{e}: {e.Message}");
			}
		}

		void HandleMessage(NetworkMessage message, NetworkClient client)
		{
			lock (this)
			{
				if (message is ChatMessage chatMessage)
				{
					// They haven't sent a JoinMessage yet, reject them
					if (string.IsNullOrEmpty(client.Name))
					{
						client.SendMessage(new RejectMessage() { Reason = "Connection not validated." });
						return;
					}

					MySqlCommand command = CommandBuilder.CreateCommand("InsertMessage", sqlConnection, ("@messageIn", chatMessage.Text, MySqlDbType.Text), ("@nameIn", client.Name, MySqlDbType.VarChar));
					command.CommandType = System.Data.CommandType.StoredProcedure;
					command.ExecuteNonQuery();

					Log($"{client.Name} says, \"{chatMessage.Text}\"");
					MessageClients(chatMessage);
				}
				else if (message is JoinMessage joinMessage)
				{
					if (!Sanitizer.NameIsValid(joinMessage.Name))
					{
						client.SendMessage(new RejectMessage() { Reason = "Invalid Name" });
						return;
					}

					if (!Sanitizer.PasswordIsValid(joinMessage.Password))
					{
						client.SendMessage(new RejectMessage() { Reason = "Invalid Password" });
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
								client.SendMessage(new RejectMessage() { Reason = "Wrong Username or Password" });
								Log($"{joinMessage.Name} to join with wrong password.");
								return;
							}
						}
					}

					Dictionary<int, (string, string)> data = new Dictionary<int, (string, string)>(50);

					using (MySqlCommand historyCommand = CommandBuilder.CreateCommand("GetHistory", sqlConnection, ("@indexIn", -1, MySqlDbType.Int32)))
					{
						historyCommand.CommandType = System.Data.CommandType.StoredProcedure;
						using (MySqlDataReader reader = historyCommand.ExecuteReader())
						{
							while(reader.Read())
							{
								data.Add(reader.GetInt32("id"), (reader.GetString("name"), reader.GetString("message")));
							}
						}
					}


					client.SendMessage(new ChatHistoryMesssage() { messages = data });
					client.Name = joinMessage.Name;
					clients.Add(client);

					
					UpdateClients();
					MessageClients(new JoinMessage() { Name = client.Name });

					Log($"{client.Name} joined the server.");
				}
			}
		}

		private void UpdateClients()
		{
			string[] clientNames = clients.Select((c) => c.Name).ToArray();
			ClientsChanged.Invoke(clientNames);

			MessageClients(new UsersMessage() { Users = clientNames });
		}

		private void MessageClients(NetworkMessage message)
		{
			foreach (NetworkClient client in clients)
				client.SendMessage(message);
		}

		void Log(string text) => OutputLog.Invoke($"{DateTime.Now.ToLongTimeString()}: {text}");
	}
}