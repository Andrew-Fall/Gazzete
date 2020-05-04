using Gazette.Network;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gazette
{
	public partial class HostMenu : Form
	{
		public HostMenu()
		{
			InitializeComponent();
		}

		const string ClosedText = "Host";
		const string OpenText = "Stop";
		const string ConnectingText = "Connecting...";

		MySqlConnection myConnection;
		NetworkServer server;

		#region HostButton
		private async void HostButton_Click(object sender, EventArgs e)
		{
			if (myConnection != null && myConnection.State == ConnectionState.Open)
			{
				await Disconnect();
				HostButton.Text = ClosedText;
			}
			else if (myConnection == null || myConnection.State == ConnectionState.Closed)
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

		#region ReturnButton
		private void ReturnButton_Click(object sender, EventArgs e)
		{
			if (HostButton.Text == "Stop")
				HostButton.PerformClick();
			Program.SwitchMenu(Gazette.Menu.MainMenu);
		}
		#endregion

		#region Server Connection
		async Task<bool> Connect()
		{
			if (myConnection?.State == ConnectionState.Open)
			{
				Log("Server already started, close previous connections first.");
				return false;
			}
			if (!int.TryParse(PortTextBox.Text, out int port))
			{
				Log("Invalid port.");
				return false;
			}

			DatabaseIPTextBox.Enabled = false;
			DatabaseNameTextBox.Enabled = false;
			DatabaseUserIDTextBox.Enabled = false;
			DatabasePasswordTextBox.Enabled = false;
			PortTextBox.Enabled = false;

			MySqlConnectionStringBuilder connectionStringBuilder = new MySqlConnectionStringBuilder()
			{
				Server = DatabaseIPTextBox.Text,
				Database = DatabaseNameTextBox.Text,
				UserID = DatabaseUserIDTextBox.Text,
				Password = DatabasePasswordTextBox.Text
			};

			myConnection = new MySqlConnection(connectionStringBuilder.ConnectionString);
			try
			{
				Log("Connecting to database.");

				// MySQL hasn't implimented this correctly, so you have to create a task.
				await Task.Run(() => myConnection.OpenAsync());

				Log("Connected to database.");

				server = new NetworkServer(new IPEndPoint(IPAddress.Loopback, port), myConnection);
				server.OutputLog += (s) => BeginInvoke((Action)(() => Log(s, false)));
				server.ClientsChanged += (s) => BeginInvoke((Action)(() => { UserBox.Items.Clear(); UserBox.Items.AddRange(s); }));

				return server.Start();
			}
			catch (Exception exception)
			{
				Log(exception.Message);
				return false;
			}
		}

		async Task Disconnect()
		{
			Log("Stopping Server.");
			Task stopTask = myConnection.CloseAsync();
			server.Stop();
			await stopTask;
			Log("Server stopped.");

			DatabaseIPTextBox.Enabled = true;
			DatabaseNameTextBox.Enabled = true;
			DatabaseUserIDTextBox.Enabled = true;
			DatabasePasswordTextBox.Enabled = true;
			PortTextBox.Enabled = true;
		}
		#endregion

		void Log(string message, bool displayTime = true)
		{
			if (displayTime)
				LogBox.Items.Add($"{DateTime.Now.ToLongTimeString()}: {message}");
			else
				LogBox.Items.Add(message);
		}

		public void Connect(string databaseIP, string databaseName, string databaseUserID, string databasePassword, string serverPort)
		{
			DatabaseIPTextBox.Text = databaseIP;
			DatabaseNameTextBox.Text = databaseName;
			DatabaseUserIDTextBox.Text = databaseUserID;
			DatabasePasswordTextBox.Text = databasePassword;
			PortTextBox.Text = serverPort;

			HostButton_Click(null, null);
		}

		private void LogBox_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			int index = LogBox.IndexFromPoint(e.Location);
			if (index != ListBox.NoMatches)
			{
				MessageBox.Show(LogBox.Items[index].ToString());
			}
		}
	}
}
