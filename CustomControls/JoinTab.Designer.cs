namespace Gazette.CustomControls
{
	partial class JoinTab
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
			this.LogListBox = new System.Windows.Forms.ListBox();
			this.JoinTabConnectButton = new System.Windows.Forms.Button();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.UsernameTextBox = new Gazette.WatermarkedRichTextBox();
			this.IPAddressTextBox = new Gazette.WatermarkedRichTextBox();
			this.PortTextBox = new Gazette.WatermarkedRichTextBox();
			this.PasswordTextBox = new Gazette.WatermarkedRichTextBox();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// LogListBox
			// 
			this.LogListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.LogListBox.FormattingEnabled = true;
			this.LogListBox.Location = new System.Drawing.Point(3, 3);
			this.LogListBox.Name = "LogListBox";
			this.LogListBox.Size = new System.Drawing.Size(494, 212);
			this.LogListBox.TabIndex = 0;
			// 
			// JoinTabConnectButton
			// 
			this.JoinTabConnectButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.JoinTabConnectButton.Location = new System.Drawing.Point(3, 277);
			this.JoinTabConnectButton.Name = "JoinTabConnectButton";
			this.JoinTabConnectButton.Size = new System.Drawing.Size(494, 20);
			this.JoinTabConnectButton.TabIndex = 2;
			this.JoinTabConnectButton.Text = "Connect To Server";
			this.JoinTabConnectButton.UseVisualStyleBackColor = true;
			this.JoinTabConnectButton.Click += new System.EventHandler(this.JoinTabConnectButton_Click);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.Location = new System.Drawing.Point(3, 221);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.UsernameTextBox);
			this.splitContainer1.Panel1.Controls.Add(this.IPAddressTextBox);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.PortTextBox);
			this.splitContainer1.Panel2.Controls.Add(this.PasswordTextBox);
			this.splitContainer1.Size = new System.Drawing.Size(494, 50);
			this.splitContainer1.SplitterDistance = 247;
			this.splitContainer1.TabIndex = 6;
			this.splitContainer1.Resize += new System.EventHandler(this.splitContainer1_Resize);
			// 
			// UsernameTextBox
			// 
			this.UsernameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.UsernameTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
			this.UsernameTextBox.Location = new System.Drawing.Point(0, 3);
			this.UsernameTextBox.Multiline = false;
			this.UsernameTextBox.Name = "UsernameTextBox";
			this.UsernameTextBox.Size = new System.Drawing.Size(244, 20);
			this.UsernameTextBox.TabIndex = 4;
			this.UsernameTextBox.Text = "User Name";
			this.UsernameTextBox.TextWrapper = "";
			this.UsernameTextBox.WatermarkedText = "User Name";
			// 
			// IPAddressTextBox
			// 
			this.IPAddressTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.IPAddressTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
			this.IPAddressTextBox.Location = new System.Drawing.Point(0, 29);
			this.IPAddressTextBox.Multiline = false;
			this.IPAddressTextBox.Name = "IPAddressTextBox";
			this.IPAddressTextBox.Size = new System.Drawing.Size(244, 20);
			this.IPAddressTextBox.TabIndex = 1;
			this.IPAddressTextBox.Text = "IP Address";
			this.IPAddressTextBox.TextWrapper = "";
			this.IPAddressTextBox.WatermarkedText = "IP Address";
			// 
			// PortTextBox
			// 
			this.PortTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.PortTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
			this.PortTextBox.Location = new System.Drawing.Point(-1, 29);
			this.PortTextBox.Multiline = false;
			this.PortTextBox.Name = "PortTextBox";
			this.PortTextBox.Size = new System.Drawing.Size(244, 20);
			this.PortTextBox.TabIndex = 3;
			this.PortTextBox.Text = "Port";
			this.PortTextBox.TextWrapper = "";
			this.PortTextBox.WatermarkedText = "Port";
			// 
			// PasswordTextBox
			// 
			this.PasswordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.PasswordTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
			this.PasswordTextBox.Location = new System.Drawing.Point(-1, 3);
			this.PasswordTextBox.Multiline = false;
			this.PasswordTextBox.Name = "PasswordTextBox";
			this.PasswordTextBox.Size = new System.Drawing.Size(244, 20);
			this.PasswordTextBox.TabIndex = 5;
			this.PasswordTextBox.Text = "Password";
			this.PasswordTextBox.TextWrapper = "";
			this.PasswordTextBox.WatermarkedText = "Password";
			// 
			// JoinTab
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.JoinTabConnectButton);
			this.Controls.Add(this.LogListBox);
			this.Name = "JoinTab";
			this.Size = new System.Drawing.Size(500, 300);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox LogListBox;
		private WatermarkedRichTextBox IPAddressTextBox;
		private System.Windows.Forms.Button JoinTabConnectButton;
		private WatermarkedRichTextBox PortTextBox;
		private WatermarkedRichTextBox UsernameTextBox;
		private WatermarkedRichTextBox PasswordTextBox;
		private System.Windows.Forms.SplitContainer splitContainer1;
	}
}
