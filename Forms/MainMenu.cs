using Gazette.CustomControls;
using Gazette.Network;
using Gazette.NetworkMessages;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gazette
{
	public partial class MainMenu : Form
	{
		public MainMenu()
		{
			InitializeComponent();
			ConnectionControl.TabPages.RemoveAt(0);
		}

		private void NewConnectionButton_Click(object sender, EventArgs e)
		{
			NewConnectionForm newConnectionForm = new NewConnectionForm();
			newConnectionForm.ShowDialog();
			var result = newConnectionForm.result;
			switch (result)
			{
				case NewConnectionForm.ConnectionType.Server:
					CreateTab("New Server", new ServerTab());
					break;
				case NewConnectionForm.ConnectionType.Join:
					JoinTab joinTab = new JoinTab();
					joinTab.Page = CreateTab("New Connection", joinTab);
					break;
				default:
					break;
			}
		}

		public TabPage CreateTab(string name, UserControl tabControl)
		{
			TabPage page = new TabPage(name);
			page.Controls.Add(tabControl);
			ConnectionControl.TabPages.Add(page);
			ConnectionControl.SelectedIndex = ConnectionControl.TabCount - 1;

			// Preserves resizing
			tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			return page;
		}

		public void RemoveTab(TabPage tab)
		{
			ConnectionControl.TabPages.Remove(tab);
		}

		#region Vertical Tab rotation
		private void ConnectionControl_DrawItem(object sender, DrawItemEventArgs e)
		{
			Graphics g = e.Graphics;
			Brush _textBrush;

			// Get the item from the collection.
			TabPage _tabPage = ConnectionControl.TabPages[e.Index];

			// Get the real bounds for the tab rectangle.
			Rectangle _tabBounds = ConnectionControl.GetTabRect(e.Index);

			if (e.State == DrawItemState.Selected)
			{

				// Draw a different background color, and don't paint a focus rectangle.
				_textBrush = new SolidBrush(e.ForeColor);
				g.FillRectangle(new SolidBrush(e.BackColor), e.Bounds);
			}
			else
			{
				_textBrush = new SolidBrush(e.ForeColor);
				e.DrawBackground();
			}

			// Use our own font.
			Font _tabFont = ConnectionControl.Font;

			// Draw string. Center the text.
			StringFormat _stringFlags = new StringFormat
			{
				Alignment = StringAlignment.Center,
				LineAlignment = StringAlignment.Center
			};
			g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
		}

		#endregion

		private void CloseTabButton_Click(object sender, EventArgs e)
		{
			if (ConnectionControl.SelectedTab is null)
				return;

			if (MessageBox.Show("Close current tab?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				RemoveTab(ConnectionControl.SelectedTab);
		}
	}
}
