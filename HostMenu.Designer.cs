namespace Gazette
{
	partial class HostMenu
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.HostButton = new System.Windows.Forms.Button();
			this.ReturnButton = new System.Windows.Forms.Button();
			this.LogBox = new System.Windows.Forms.ListBox();
			this.UserBox = new System.Windows.Forms.ListBox();
			this.PortTextBox = new Gazette.WatermarkedRichTextBox();
			this.DatabasePasswordTextBox = new Gazette.WatermarkedRichTextBox();
			this.DatabaseUserIDTextBox = new Gazette.WatermarkedRichTextBox();
			this.DatabaseNameTextBox = new Gazette.WatermarkedRichTextBox();
			this.DatabaseIPTextBox = new Gazette.WatermarkedRichTextBox();
			this.SuspendLayout();
			// 
			// HostButton
			// 
			this.HostButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.HostButton.Location = new System.Drawing.Point(93, 215);
			this.HostButton.Name = "HostButton";
			this.HostButton.Size = new System.Drawing.Size(75, 23);
			this.HostButton.TabIndex = 8;
			this.HostButton.Text = "Host";
			this.HostButton.UseVisualStyleBackColor = true;
			this.HostButton.Click += new System.EventHandler(this.HostButton_Click);
			// 
			// ReturnButton
			// 
			this.ReturnButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ReturnButton.Location = new System.Drawing.Point(12, 215);
			this.ReturnButton.Name = "ReturnButton";
			this.ReturnButton.Size = new System.Drawing.Size(75, 23);
			this.ReturnButton.TabIndex = 9;
			this.ReturnButton.Text = "Return";
			this.ReturnButton.UseVisualStyleBackColor = true;
			this.ReturnButton.Click += new System.EventHandler(this.ReturnButton_Click);
			// 
			// LogBox
			// 
			this.LogBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.LogBox.FormattingEnabled = true;
			this.LogBox.Location = new System.Drawing.Point(174, 13);
			this.LogBox.Name = "LogBox";
			this.LogBox.Size = new System.Drawing.Size(282, 212);
			this.LogBox.TabIndex = 10;
			this.LogBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LogBox_MouseDoubleClick);
			// 
			// UserBox
			// 
			this.UserBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.UserBox.FormattingEnabled = true;
			this.UserBox.Location = new System.Drawing.Point(462, 13);
			this.UserBox.Name = "UserBox";
			this.UserBox.Size = new System.Drawing.Size(90, 212);
			this.UserBox.TabIndex = 16;
			// 
			// PortTextBox
			// 
			this.PortTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
			this.PortTextBox.Location = new System.Drawing.Point(12, 116);
			this.PortTextBox.Multiline = false;
			this.PortTextBox.Name = "PortTextBox";
			this.PortTextBox.Size = new System.Drawing.Size(156, 20);
			this.PortTextBox.TabIndex = 15;
			this.PortTextBox.Text = "Port";
			this.PortTextBox.TextWrapper = "";
			this.PortTextBox.WatermarkedText = "Port";
			// 
			// DatabasePasswordTextBox
			// 
			this.DatabasePasswordTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
			this.DatabasePasswordTextBox.Location = new System.Drawing.Point(12, 90);
			this.DatabasePasswordTextBox.Multiline = false;
			this.DatabasePasswordTextBox.Name = "DatabasePasswordTextBox";
			this.DatabasePasswordTextBox.Size = new System.Drawing.Size(156, 20);
			this.DatabasePasswordTextBox.TabIndex = 14;
			this.DatabasePasswordTextBox.Text = "Database Password";
			this.DatabasePasswordTextBox.TextWrapper = "";
			this.DatabasePasswordTextBox.WatermarkedText = "Database Password";
			// 
			// DatabaseUserIDTextBox
			// 
			this.DatabaseUserIDTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
			this.DatabaseUserIDTextBox.Location = new System.Drawing.Point(12, 64);
			this.DatabaseUserIDTextBox.Multiline = false;
			this.DatabaseUserIDTextBox.Name = "DatabaseUserIDTextBox";
			this.DatabaseUserIDTextBox.Size = new System.Drawing.Size(156, 20);
			this.DatabaseUserIDTextBox.TabIndex = 13;
			this.DatabaseUserIDTextBox.Text = "Database User ID";
			this.DatabaseUserIDTextBox.TextWrapper = "";
			this.DatabaseUserIDTextBox.WatermarkedText = "Database User ID";
			// 
			// DatabaseNameTextBox
			// 
			this.DatabaseNameTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
			this.DatabaseNameTextBox.Location = new System.Drawing.Point(12, 38);
			this.DatabaseNameTextBox.Multiline = false;
			this.DatabaseNameTextBox.Name = "DatabaseNameTextBox";
			this.DatabaseNameTextBox.Size = new System.Drawing.Size(156, 20);
			this.DatabaseNameTextBox.TabIndex = 12;
			this.DatabaseNameTextBox.Text = "Database Name";
			this.DatabaseNameTextBox.TextWrapper = "";
			this.DatabaseNameTextBox.WatermarkedText = "Database Name";
			// 
			// DatabaseIPTextBox
			// 
			this.DatabaseIPTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
			this.DatabaseIPTextBox.Location = new System.Drawing.Point(12, 12);
			this.DatabaseIPTextBox.Multiline = false;
			this.DatabaseIPTextBox.Name = "DatabaseIPTextBox";
			this.DatabaseIPTextBox.Size = new System.Drawing.Size(156, 20);
			this.DatabaseIPTextBox.TabIndex = 11;
			this.DatabaseIPTextBox.Text = "Database IP";
			this.DatabaseIPTextBox.TextWrapper = "";
			this.DatabaseIPTextBox.WatermarkedText = "Database IP";
			// 
			// HostMenu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
			this.ClientSize = new System.Drawing.Size(564, 250);
			this.Controls.Add(this.UserBox);
			this.Controls.Add(this.PortTextBox);
			this.Controls.Add(this.DatabasePasswordTextBox);
			this.Controls.Add(this.DatabaseUserIDTextBox);
			this.Controls.Add(this.DatabaseNameTextBox);
			this.Controls.Add(this.DatabaseIPTextBox);
			this.Controls.Add(this.LogBox);
			this.Controls.Add(this.ReturnButton);
			this.Controls.Add(this.HostButton);
			this.MinimumSize = new System.Drawing.Size(388, 216);
			this.Name = "HostMenu";
			this.Text = "Host Menu";
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button HostButton;
		private System.Windows.Forms.Button ReturnButton;
		private System.Windows.Forms.ListBox LogBox;
		private WatermarkedRichTextBox DatabaseIPTextBox;
		private WatermarkedRichTextBox DatabaseNameTextBox;
		private WatermarkedRichTextBox DatabaseUserIDTextBox;
		private WatermarkedRichTextBox DatabasePasswordTextBox;
		private WatermarkedRichTextBox PortTextBox;
		private System.Windows.Forms.ListBox UserBox;
	}
}