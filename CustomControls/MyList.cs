using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Gazette.Extensions;

namespace Gazette.CustomControls
{
	public partial class MyList : UserControl
	{
		public SortedList<int, ChatItem> data = new SortedList<int, ChatItem>();

		public event Action<(int newValue, int minScroll, int maxScroll)> AfterSroll;

		public int MinIndex => data.Keys[0];
		public int MaxIndex => data.Keys[data.Keys.Count - 1];

		private const int MaxCapacity = 200;
		private const int TruncatedCapacity = 75;

		private void EditScrollBar(Action action)
		{
			if (ListScrollBar.InvokeRequired)
				ListScrollBar.Invoke(action);
			else
				action.Invoke();
		}

		public MyList()
		{
			InitializeComponent();
			ListScrollBar.ValueChanged += OnScroll;
			Margin = new Padding(3, 3, ListScrollBar.Width + 3, 3);
		}

		private void OnScroll(object sender, EventArgs e)
		{
			Invalidate();

			if (!ListScrollBar.IsUsingThumbtrack)
				AfterSroll.Invoke((ListScrollBar.Value, ListScrollBar.Minimum, ListScrollBar.Maximum));
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.PageDown:
					EditScrollBar(() =>ListScrollBar.Value += 5);
					break;
				case Keys.PageUp:
					EditScrollBar(() => ListScrollBar.Value -= 5);
					break;
				default:
					break;
			}
		}

		// Add/Sub 1 based on Delta inverted (Makes scrolling go the correct way)
		protected override void OnMouseWheel(MouseEventArgs e) => EditScrollBar(() => ListScrollBar.Value = MathExtension.Clamp(ListScrollBar.Value + (e.Delta > 0 ? -15 : 15), ListScrollBar.Minimum, ListScrollBar.Maximum));

		protected override void OnPaint(PaintEventArgs e)
		{
			foreach (ChatItem item in data.Values)
				item.Draw(e);

			if (ListScrollBar.IsUsingThumbtrack)
				TextRenderer.DrawText(e.Graphics, "Release scrollbar to Refresh.", Font, new Point(Width / 2, Height / 2), Color.Red);

			base.OnPaint(e);
		}

		protected override void OnInvalidated(InvalidateEventArgs e)
		{
			if (data.Count < 1)
				return;

			int height = 0;
			foreach (ChatItem item in data.Values)
			{
				item.Location = new Point(0, height - ListScrollBar.Value);
				height += item.Height;
			}
			EditScrollBar(() =>ListScrollBar.Maximum = height - Height);
			base.OnInvalidated(e);
		}

		public void AddRange(params (int Key, string Value)[] items)
		{
			int heightChange = 0;
			foreach (var item in items)
				if (!data.ContainsKey(item.Key))
				{
					ChatItem chatItem = new ChatItem();
					chatItem.Text = item.Value;
					chatItem.Font = Font;
					chatItem.Update(this);
					data.Add(item.Key, chatItem);
					heightChange += chatItem.Height;
				}

			if (data.Count > MaxCapacity)
			{
				if (items[0].Key == data.Keys[0])
				{
					while (data.Count > TruncatedCapacity)
						data.RemoveAt(data.Count - 1);
				}
				else
				{
					while (data.Count > TruncatedCapacity)
						data.RemoveAt(0);
				}
			}
			Invalidate();
			EditScrollBar(() => ListScrollBar.Value = MathExtension.Clamp(ListScrollBar.Value + heightChange, ListScrollBar.Minimum, ListScrollBar.Maximum));
		}

		private void MyList_Resize(object sender, EventArgs e)
		{
			Margin = new Padding(3, 3, ListScrollBar.Width + 3, 3);
		}

		public class ChatItem
		{
			public Font Font;
			public string Text { get; set; }
			public Size Size { get; set; }
			public int Width { get => Size.Width; set => Size = new Size(value, Height); }
			public int Height { get => Size.Height; set => Size = new Size(Width, value); }
			public Point Location { get; set; }
			public Color ForeColor { get; set; }
			public Color BackColor { get; set; }
			public Color HighlightColor { get; set; } = SystemColors.ControlDark;
			private Color currentColor;

			public bool IsHovering { get; set; }


			public void Draw(PaintEventArgs e)
			{
				using (Pen pen = new Pen(currentColor))
					e.Graphics.FillRectangle(pen.Brush, new Rectangle(Location, Size));
				TextRenderer.DrawText(e.Graphics, Text, Font, new Rectangle(Location, Size), ForeColor, TextFormatFlags.Left | TextFormatFlags.WordBreak);
			}

			public void Update(Control parent)
			{
				Width = parent.Width - parent.Margin.Right;
				Height = TextRenderer.MeasureText(Text, Font, new Size(Width, 0), TextFormatFlags.WordBreak).Height;
			}

			public void MouseEnter()
			{
				if (IsHovering)
					return;
				else
					IsHovering = true;

				currentColor = HighlightColor;
			}
			public void MouseLeave()
			{
				if (!IsHovering)
					return;
				else
					IsHovering = false;

				currentColor = BackColor;
			}
		}

		private void MyList_MouseMove(object sender, MouseEventArgs e)
		{
			foreach (ChatItem item in data.Values)
			{
				Point localM = PointToClient(MousePosition);
				if (new Rectangle(item.Location, item.Size).Contains(localM))
					item.MouseEnter();
				else
					item.MouseLeave();
			}
			Invalidate();
		}
	}
}