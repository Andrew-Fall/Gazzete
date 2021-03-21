using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Gazette.Network;
using Gazette.NetworkMessages;
using System.Threading;

namespace Gazette.CustomControls
{
	public partial class JoinTab : UserControl
	{
		private CancellationTokenSource tokenSource = new CancellationTokenSource();
		private ChatTab ChatTab = new ChatTab();
		public TabPage Page;
		public JoinTab()
		{
			InitializeComponent();
			ChatTab.JoinTab = this;
		}

		private async void JoinTabConnectButton_Click(object sender, EventArgs e)
		{
			if (!IPAddress.TryParse(IPAddressTextBox.Text, out IPAddress address))
			{
				Log("Invalid IP Address");
				return;
			}

			if (!int.TryParse(PortTextBox.Text, out int port))
			{
				Log("Invalid Port.");
				return;
			}

			if (port < IPEndPoint.MinPort || port > IPEndPoint.MaxPort)
			{
				Log($"Port must be between {IPEndPoint.MinPort} and {IPEndPoint.MaxPort}");
				return;
			}

			var (succeeded, _) = await ChatTab.ConnectAsync(new IPEndPoint(address, port), UsernameTextBox.Text, PasswordTextBox.Text);
			if (succeeded)
			{
				Page.Controls.Remove(this);
				Page.Controls.Add(ChatTab);
				ChatTab.Dock = DockStyle.Fill;
			}
		}

		public void Log(string text) => LogListBox.Items.Add(text);

		public void Connect(string address, string port, string name, string password)
		{
			IPAddressTextBox.Text = address;
			PortTextBox.Text = port;
			UsernameTextBox.Text = name;
			PasswordTextBox.Text = password;

			JoinTabConnectButton_Click(null, null);
		}

		private void splitContainer1_Resize(object sender, EventArgs e)
		{
			splitContainer1.SplitterDistance = splitContainer1.Width / 2;
		}
	}
}
