namespace Gazette.CustomControls
{
	partial class ChatTab
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
			this.ChatTextBox = new System.Windows.Forms.TextBox();
			this.SendButton = new System.Windows.Forms.Button();
			this.ClientsListBox = new System.Windows.Forms.ListBox();
			this.DisconnectButton = new System.Windows.Forms.Button();
			this.myList1 = new Gazette.CustomControls.MyList();
			this.SuspendLayout();
			// 
			// ChatTextBox
			// 
			this.ChatTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ChatTextBox.Location = new System.Drawing.Point(3, 277);
			this.ChatTextBox.Name = "ChatTextBox";
			this.ChatTextBox.Size = new System.Drawing.Size(388, 20);
			this.ChatTextBox.TabIndex = 0;
			this.ChatTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChatTextBox_KeyDown);
			// 
			// SendButton
			// 
			this.SendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.SendButton.Location = new System.Drawing.Point(397, 277);
			this.SendButton.Name = "SendButton";
			this.SendButton.Size = new System.Drawing.Size(100, 20);
			this.SendButton.TabIndex = 1;
			this.SendButton.Text = "Send";
			this.SendButton.UseVisualStyleBackColor = true;
			this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
			// 
			// ClientsListBox
			// 
			this.ClientsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ClientsListBox.FormattingEnabled = true;
			this.ClientsListBox.Location = new System.Drawing.Point(397, 29);
			this.ClientsListBox.Name = "ClientsListBox";
			this.ClientsListBox.Size = new System.Drawing.Size(100, 238);
			this.ClientsListBox.TabIndex = 5;
			this.ClientsListBox.TabStop = false;
			// 
			// DisconnectButton
			// 
			this.DisconnectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.DisconnectButton.Location = new System.Drawing.Point(397, 3);
			this.DisconnectButton.Name = "DisconnectButton";
			this.DisconnectButton.Size = new System.Drawing.Size(100, 20);
			this.DisconnectButton.TabIndex = 6;
			this.DisconnectButton.Text = "Disconnect";
			this.DisconnectButton.UseVisualStyleBackColor = true;
			this.DisconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
			// 
			// myList1
			// 
			this.myList1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.myList1.Location = new System.Drawing.Point(3, 3);
			this.myList1.Name = "myList1";
			this.myList1.Size = new System.Drawing.Size(388, 268);
			this.myList1.TabIndex = 8;
			// 
			// ChatTab
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.myList1);
			this.Controls.Add(this.DisconnectButton);
			this.Controls.Add(this.ClientsListBox);
			this.Controls.Add(this.SendButton);
			this.Controls.Add(this.ChatTextBox);
			this.Name = "ChatTab";
			this.Size = new System.Drawing.Size(500, 300);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox ChatTextBox;
		private System.Windows.Forms.Button SendButton;
		private System.Windows.Forms.ListBox ClientsListBox;
		private System.Windows.Forms.Button DisconnectButton;
		private MyList myList1;
	}
}
