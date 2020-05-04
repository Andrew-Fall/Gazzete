namespace Gazette
{
	partial class JoinMenu
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
			this.JoinServer = new System.Windows.Forms.Button();
			this.LogBox = new System.Windows.Forms.ListBox();
			this.NameTextBox = new Gazette.WatermarkedRichTextBox();
			this.PortTextBox = new Gazette.WatermarkedRichTextBox();
			this.IPTextBox = new Gazette.WatermarkedRichTextBox();
			this.PasswordTextBox = new Gazette.WatermarkedRichTextBox();
			this.SuspendLayout();
			// 
			// JoinServer
			// 
			this.JoinServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.JoinServer.Location = new System.Drawing.Point(12, 176);
			this.JoinServer.Name = "JoinServer";
			this.JoinServer.Size = new System.Drawing.Size(135, 23);
			this.JoinServer.TabIndex = 4;
			this.JoinServer.Text = "Join";
			this.JoinServer.UseVisualStyleBackColor = true;
			this.JoinServer.Click += new System.EventHandler(this.JoinServer_Click);
			// 
			// LogBox
			// 
			this.LogBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.LogBox.FormattingEnabled = true;
			this.LogBox.Location = new System.Drawing.Point(12, 12);
			this.LogBox.Name = "LogBox";
			this.LogBox.Size = new System.Drawing.Size(135, 56);
			this.LogBox.TabIndex = 0;
			this.LogBox.TabStop = false;
			// 
			// NameTextBox
			// 
			this.NameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.NameTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
			this.NameTextBox.Location = new System.Drawing.Point(12, 124);
			this.NameTextBox.Multiline = false;
			this.NameTextBox.Name = "NameTextBox";
			this.NameTextBox.Size = new System.Drawing.Size(135, 20);
			this.NameTextBox.TabIndex = 2;
			this.NameTextBox.Text = "John";
			this.NameTextBox.TextWrapper = "John";
			this.NameTextBox.WatermarkedText = "Username";
			// 
			// PortTextBox
			// 
			this.PortTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.PortTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
			this.PortTextBox.Location = new System.Drawing.Point(12, 98);
			this.PortTextBox.Multiline = false;
			this.PortTextBox.Name = "PortTextBox";
			this.PortTextBox.Size = new System.Drawing.Size(135, 20);
			this.PortTextBox.TabIndex = 1;
			this.PortTextBox.Text = "25565";
			this.PortTextBox.TextWrapper = "25565";
			this.PortTextBox.WatermarkedText = "Port";
			// 
			// IPTextBox
			// 
			this.IPTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.IPTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
			this.IPTextBox.Location = new System.Drawing.Point(12, 72);
			this.IPTextBox.Multiline = false;
			this.IPTextBox.Name = "IPTextBox";
			this.IPTextBox.Size = new System.Drawing.Size(135, 20);
			this.IPTextBox.TabIndex = 0;
			this.IPTextBox.Text = "1";
			this.IPTextBox.TextWrapper = "1";
			this.IPTextBox.WatermarkedText = "IP Address";
			// 
			// PasswordTextBox
			// 
			this.PasswordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.PasswordTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
			this.PasswordTextBox.Location = new System.Drawing.Point(12, 150);
			this.PasswordTextBox.Multiline = false;
			this.PasswordTextBox.Name = "PasswordTextBox";
			this.PasswordTextBox.Size = new System.Drawing.Size(135, 20);
			this.PasswordTextBox.TabIndex = 3;
			this.PasswordTextBox.Text = "mypassword";
			this.PasswordTextBox.TextWrapper = "mypassword";
			this.PasswordTextBox.WatermarkedText = "Password";
			// 
			// JoinMenu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(159, 211);
			this.Controls.Add(this.PasswordTextBox);
			this.Controls.Add(this.LogBox);
			this.Controls.Add(this.NameTextBox);
			this.Controls.Add(this.JoinServer);
			this.Controls.Add(this.PortTextBox);
			this.Controls.Add(this.IPTextBox);
			this.Name = "JoinMenu";
			this.Text = "JoinMenu";
			this.ResumeLayout(false);

		}

		#endregion

		private WatermarkedRichTextBox IPTextBox;
		private WatermarkedRichTextBox PortTextBox;
		private System.Windows.Forms.Button JoinServer;
		private WatermarkedRichTextBox NameTextBox;
		private System.Windows.Forms.ListBox LogBox;
		private WatermarkedRichTextBox PasswordTextBox;
	}
}