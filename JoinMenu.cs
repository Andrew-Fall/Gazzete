﻿using System;
using System.Net;
using System.Windows.Forms;

namespace Gazette
{
	public partial class JoinMenu : Form
	{
		public JoinMenu()
		{
			InitializeComponent();
		}

		private async void JoinServer_Click(object sender, EventArgs e)
		{
			if (!IPAddress.TryParse(IPTextBox.Text, out IPAddress address))
			{
				Log("Invalid IP Address");
				return;
			}

			if (!int.TryParse(PortTextBox.Text, out int port))
			{
				Log("Invalid Port.");
				return;
			}
			
			if(port < IPEndPoint.MinPort || port > IPEndPoint.MaxPort)
			{
				Log($"Port must be between {IPEndPoint.MinPort} and {IPEndPoint.MaxPort}");
				return;
			}
			
			await (Program.forms[Gazette.Menu.ChatMenu] as ChatMenu).ConnectAsync(new IPEndPoint(IPAddress.Loopback, port), NameTextBox.Text);
			Program.SwitchMenu(Gazette.Menu.ChatMenu);
		}

		void Log(string text)
		{
			LogBox.Items.Add(text);
		}
	}
}
