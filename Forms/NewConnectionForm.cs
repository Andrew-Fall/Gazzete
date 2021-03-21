using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gazette
{
	public partial class NewConnectionForm : Form
	{
		public enum ConnectionType
		{
			Server,
			Join,
			Cancel
		}

		public ConnectionType result = ConnectionType.Cancel;

		public NewConnectionForm()
		{
			InitializeComponent();
		}

		private void ServerButton_Click(object sender, EventArgs e)
		{
			result = ConnectionType.Server;
			Close();
		}

		private void JoinButton_Click(object sender, EventArgs e)
		{
			result = ConnectionType.Join;
			Close();
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
