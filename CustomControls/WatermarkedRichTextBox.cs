using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Gazette
{
	class WatermarkedRichTextBox : RichTextBox
	{
		bool watermarked = false;							// If the watermark is currently showing
		Color originalColor = SystemColors.WindowText;		// The color we display when the watermark is not displaying
		Color watermarkedColor = SystemColors.GrayText;		// The color we display when the watermark is displaying
		string watermarkedText = "Watermark";               // The text of the watermark

		#region Hidden
		[Browsable(false)]
		public override string Text { get => base.Text; set { base.Text = value; } }
		[Browsable(false)]
		public override Color ForeColor { get => base.ForeColor; set => base.ForeColor = value; }
		#endregion

		#region Wrappers & Properties

		[Browsable(true), Category("Appearance"), DisplayName("Text"), Description("The text associated with the control.")]
		public string TextWrapper {
			get => watermarked ? "" : Text;
			set {
				Text = value;
				if (string.IsNullOrEmpty(Text))
					SetWatermarked();
				else
					UnsetWatermarked();
				Invalidate();
			}
		}

		[Browsable(true), Category("Appearance"), DisplayName("WatermarkedText"), Description("The text used when the watermark is displayed."), DefaultValue("Watermark")]
		public string WatermarkedText {
			get => watermarkedText;
			set {
				watermarkedText = value;
				if (watermarked)
					Text = value;
				Invalidate();
			}
		}

		[Browsable(true), Category("Appearance"), DisplayName("ForeColor"), Description("The foreground color of this component, which is used to display text."), DefaultValue(typeof(Color), "WindowText")]
		public Color ForeColorWrapper {
			get => originalColor;
			set {
				originalColor = value;
				if (!watermarked)
					ForeColor = value;
				Invalidate();
			}
		}

		[Browsable(true), Category("Appearance"), DisplayName("WatermarkedColor"), Description("The color of the foreground used when the watermark is displayed."), DefaultValue(typeof(Color), "GrayText")]
		public Color WatermarkedColor {
			get => watermarkedColor;
			set {
				watermarkedColor = value;
				if (watermarked)
					ForeColor = value;
				Invalidate();
			}
		}
		#endregion
		public WatermarkedRichTextBox()
		{
			Multiline = false;
			Height = 20;
			SetWatermarked();
			HandleCreated += (s, e) =>
			{
				SelectionChanged += WatermarkedRichTextBox_SelectionChanged;
				TextChanged += WatermarkedRichTextBox_TextChanged;
			};
		}

		private void WatermarkedRichTextBox_TextChanged(object sender, EventArgs e)
		{
			TextChanged -= WatermarkedRichTextBox_TextChanged;
			SelectionChanged -= WatermarkedRichTextBox_SelectionChanged;
			if (Text.Length == 0)
				SetWatermarked();
			else if (watermarked)
			{
				Text = Text.Replace(watermarkedText, "");
				UnsetWatermarked();
				SelectionStart = Text.Length;
			}
			TextChanged += WatermarkedRichTextBox_TextChanged;
			SelectionChanged += WatermarkedRichTextBox_SelectionChanged;
		}

		private void WatermarkedRichTextBox_SelectionChanged(object sender, EventArgs e)
		{
			if (watermarked)
				SelectionStart = 0;
		}

		private void SetWatermarked()
		{
			ForeColor = watermarkedColor;
			Text = watermarkedText;
			watermarked = true;
		}

		private void UnsetWatermarked()
		{
			ForeColor = originalColor;
			watermarked = false;
		}
	}
}
