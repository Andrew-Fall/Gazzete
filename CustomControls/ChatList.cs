using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace Gazette.CustomControls
{
	public partial class ChatList : UserControl
	{
		public int MinKey => chatHistory.Keys[0];
		public int MaxKey => chatHistory.Keys[chatHistory.Count - 1];
		public int MaxScroll => VerticalScroll.Maximum;

		public event Action<int> AfterScroll;

		private const int maxCapacity = 256;
		private const int truncatedCapacity = 128;
		private SortedList<int, Label> chatHistory = new SortedList<int, Label>();

		public ChatList()
		{
			InitializeComponent();
		}

		public void AddRange(params (int key, string value)[] items)
		{
			Array.Sort(items);
			foreach (var (key, value) in items)
			{
				Label label = new Label();
				label.Text = value;
				label.Height = label.Font.Height;
				label.Width = Width - 25;
				label.MouseEnter += (s, e) => label.BackColor = SystemColors.Highlight;
				label.MouseLeave += (s, e) => label.BackColor = SystemColors.Control;
				chatHistory.Add(key, label);
			}
				
			if (chatHistory.Count > maxCapacity)
			{
				if (items[0].key == chatHistory.Keys[0])
				{
					while (chatHistory.Count > truncatedCapacity)
						chatHistory.RemoveAt(chatHistory.Count - 1);
				}
				else
				{
					while (chatHistory.Count > truncatedCapacity)
						chatHistory.RemoveAt(0);
				}
			}
			
			flowLayoutPanel1.SuspendLayout();
			flowLayoutPanel1.Controls.Clear();
			flowLayoutPanel1.Controls.AddRange(chatHistory.Values.ToArray());
			flowLayoutPanel1.ResumeLayout(true);

			vScrollBar1.Maximum = flowLayoutPanel1.Controls.Count * Font.Height;
		}

		protected override void OnMouseWheel(MouseEventArgs e)
		{
			vScrollBar1.Value = Math.Max(0, Math.Min(vScrollBar1.Maximum - (vScrollBar1.LargeChange - 1), e.Delta > 1 ? vScrollBar1.Value - 1 : vScrollBar1.Value + 1));
			flowLayoutPanel1.Location = new Point(flowLayoutPanel1.Location.X, -vScrollBar1.Value);
			vScrollBar1_Scroll(this, null);
		}

		private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
		{
			AfterScroll?.Invoke(vScrollBar1.Value);
		}
	}
}
