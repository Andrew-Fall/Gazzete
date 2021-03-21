namespace Gazette.CustomControls
{
	partial class ServerTab
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.DatabaseIPTextBox = new Gazette.WatermarkedRichTextBox();
			this.DatabaseNameTextBox = new Gazette.WatermarkedRichTextBox();
			this.DatabaseUserIDTextBox = new Gazette.WatermarkedRichTextBox();
			this.ServerPortTextBox = new Gazette.WatermarkedRichTextBox();
			this.DatabasePasswordTextBox = new Gazette.WatermarkedRichTextBox();
			this.ServerLogListBox = new System.Windows.Forms.ListBox();
			this.ClientListBox = new System.Windows.Forms.ListBox();
			this.CommandTextBox = new System.Windows.Forms.TextBox();
			this.EnterButton = new System.Windows.Forms.Button();
			this.HostButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// DatabaseIPTextBox
			// 
			this.DatabaseIPTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
			this.DatabaseIPTextBox.Location = new System.Drawing.Point(3, 3);
			this.DatabaseIPTextBox.Multiline = false;
			this.DatabaseIPTextBox.Name = "DatabaseIPTextBox";
			this.DatabaseIPTextBox.Size = new System.Drawing.Size(113, 20);
			this.DatabaseIPTextBox.TabIndex = 0;
			this.DatabaseIPTextBox.Text = "Database IP";
			this.DatabaseIPTextBox.TextWrapper = "";
			this.DatabaseIPTextBox.WatermarkedText = "Database IP";
			// 
			// DatabaseNameTextBox
			// 
			this.DatabaseNameTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
			this.DatabaseNameTextBox.Location = new System.Drawing.Point(3, 29);
			this.DatabaseNameTextBox.Multiline = false;
			this.DatabaseNameTextBox.Name = "DatabaseNameTextBox";
			this.DatabaseNameTextBox.Size = new System.Drawing.Size(113, 20);
			this.DatabaseNameTextBox.TabIndex = 1;
			this.DatabaseNameTextBox.Text = "Database Name";
			this.DatabaseNameTextBox.TextWrapper = "";
			this.DatabaseNameTextBox.WatermarkedText = "Database Name";
			// 
			// DatabaseUserIDTextBox
			// 
			this.DatabaseUserIDTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
			this.DatabaseUserIDTextBox.Location = new System.Drawing.Point(3, 55);
			this.DatabaseUserIDTextBox.Multiline = false;
			this.DatabaseUserIDTextBox.Name = "DatabaseUserIDTextBox";
			this.DatabaseUserIDTextBox.Size = new System.Drawing.Size(113, 20);
			this.DatabaseUserIDTextBox.TabIndex = 2;
			this.DatabaseUserIDTextBox.Text = "Database UserID";
			this.DatabaseUserIDTextBox.TextWrapper = "";
			this.DatabaseUserIDTextBox.WatermarkedText = "Database UserID";
			// 
			// ServerPortTextBox
			// 
			this.ServerPortTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
			this.ServerPortTextBox.Location = new System.Drawing.Point(3, 107);
			this.ServerPortTextBox.Multiline = false;
			this.ServerPortTextBox.Name = "ServerPortTextBox";
			this.ServerPortTextBox.Size = new System.Drawing.Size(113, 20);
			this.ServerPortTextBox.TabIndex = 4;
			this.ServerPortTextBox.Text = "Server Port";
			this.ServerPortTextBox.TextWrapper = "";
			this.ServerPortTextBox.WatermarkedText = "Server Port";
			// 
			// DatabasePasswordTextBox
			// 
			this.DatabasePasswordTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
			this.DatabasePasswordTextBox.Location = new System.Drawing.Point(3, 81);
			this.DatabasePasswordTextBox.Multiline = false;
			this.DatabasePasswordTextBox.Name = "DatabasePasswordTextBox";
			this.DatabasePasswordTextBox.Size = new System.Drawing.Size(113, 20);
			this.DatabasePasswordTextBox.TabIndex = 3;
			this.DatabasePasswordTextBox.Text = "Database Password";
			this.DatabasePasswordTextBox.TextWrapper = "";
			this.DatabasePasswordTextBox.WatermarkedText = "Database Password";
			// 
			// ServerLogListBox
			// 
			this.ServerLogListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ServerLogListBox.FormattingEnabled = true;
			this.ServerLogListBox.Location = new System.Drawing.Point(122, 3);
			this.ServerLogListBox.Name = "ServerLogListBox";
			this.ServerLogListBox.Size = new System.Drawing.Size(269, 264);
			this.ServerLogListBox.TabIndex = 5;
			this.ServerLogListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ServerLogListBox_MouseDoubleClick);
			// 
			// ClientListBox
			// 
			this.ClientListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ClientListBox.FormattingEnabled = true;
			this.ClientListBox.Location = new System.Drawing.Point(397, 3);
			this.ClientListBox.Name = "ClientListBox";
			this.ClientListBox.Size = new System.Drawing.Size(100, 264);
			this.ClientListBox.TabIndex = 6;
			// 
			// CommandTextBox
			// 
			this.CommandTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CommandTextBox.Location = new System.Drawing.Point(3, 277);
			this.CommandTextBox.Name = "CommandTextBox";
			this.CommandTextBox.Size = new System.Drawing.Size(388, 20);
			this.CommandTextBox.TabIndex = 6;
			// 
			// EnterButton
			// 
			this.EnterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.EnterButton.Location = new System.Drawing.Point(397, 274);
			this.EnterButton.Name = "EnterButton";
			this.EnterButton.Size = new System.Drawing.Size(100, 23);
			this.EnterButton.TabIndex = 7;
			this.EnterButton.Text = "Enter";
			this.EnterButton.UseVisualStyleBackColor = true;
			// 
			// HostButton
			// 
			this.HostButton.Location = new System.Drawing.Point(3, 133);
			this.HostButton.Name = "HostButton";
			this.HostButton.Size = new System.Drawing.Size(113, 23);
			this.HostButton.TabIndex = 5;
			this.HostButton.Text = "Host";
			this.HostButton.UseVisualStyleBackColor = true;
			this.HostButton.Click += new System.EventHandler(this.HostButton_Click);
			// 
			// ServerTab
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.HostButton);
			this.Controls.Add(this.EnterButton);
			this.Controls.Add(this.CommandTextBox);
			this.Controls.Add(this.ClientListBox);
			this.Controls.Add(this.ServerLogListBox);
			this.Controls.Add(this.DatabasePasswordTextBox);
			this.Controls.Add(this.ServerPortTextBox);
			this.Controls.Add(this.DatabaseUserIDTextBox);
			this.Controls.Add(this.DatabaseNameTextBox);
			this.Controls.Add(this.DatabaseIPTextBox);
			this.Name = "ServerTab";
			this.Size = new System.Drawing.Size(500, 300);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private WatermarkedRichTextBox DatabaseIPTextBox;
		private WatermarkedRichTextBox DatabaseNameTextBox;
		private WatermarkedRichTextBox DatabaseUserIDTextBox;
		private WatermarkedRichTextBox ServerPortTextBox;
		private WatermarkedRichTextBox DatabasePasswordTextBox;
		private System.Windows.Forms.ListBox ServerLogListBox;
		private System.Windows.Forms.ListBox ClientListBox;
		private System.Windows.Forms.TextBox CommandTextBox;
		private System.Windows.Forms.Button EnterButton;
		private System.Windows.Forms.Button HostButton;
	}
}
