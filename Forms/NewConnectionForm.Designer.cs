namespace Gazette
{
	partial class NewConnectionForm
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
			this.ServerButton = new System.Windows.Forms.Button();
			this.JoinButton = new System.Windows.Forms.Button();
			this.ReturnButton = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// ServerButton
			// 
			this.ServerButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.ServerButton.Location = new System.Drawing.Point(12, 99);
			this.ServerButton.Name = "ServerButton";
			this.ServerButton.Size = new System.Drawing.Size(75, 23);
			this.ServerButton.TabIndex = 0;
			this.ServerButton.Text = "Server";
			this.ServerButton.UseVisualStyleBackColor = true;
			this.ServerButton.Click += new System.EventHandler(this.ServerButton_Click);
			// 
			// JoinButton
			// 
			this.JoinButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.JoinButton.Location = new System.Drawing.Point(93, 99);
			this.JoinButton.Name = "JoinButton";
			this.JoinButton.Size = new System.Drawing.Size(75, 23);
			this.JoinButton.TabIndex = 1;
			this.JoinButton.Text = "Join";
			this.JoinButton.UseVisualStyleBackColor = true;
			this.JoinButton.Click += new System.EventHandler(this.JoinButton_Click);
			// 
			// ReturnButton
			// 
			this.ReturnButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.ReturnButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.ReturnButton.Location = new System.Drawing.Point(174, 99);
			this.ReturnButton.Name = "ReturnButton";
			this.ReturnButton.Size = new System.Drawing.Size(75, 23);
			this.ReturnButton.TabIndex = 2;
			this.ReturnButton.Text = "Cancel";
			this.ReturnButton.UseVisualStyleBackColor = true;
			this.ReturnButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
			this.panel1.Location = new System.Drawing.Point(-9, 85);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(281, 58);
			this.panel1.TabIndex = 0;
			// 
			// NewConnectionForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.ReturnButton;
			this.ClientSize = new System.Drawing.Size(264, 134);
			this.Controls.Add(this.ReturnButton);
			this.Controls.Add(this.JoinButton);
			this.Controls.Add(this.ServerButton);
			this.Controls.Add(this.panel1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NewConnectionForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Select";
			this.TopMost = true;
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button ServerButton;
		private System.Windows.Forms.Button JoinButton;
		private System.Windows.Forms.Button ReturnButton;
		private System.Windows.Forms.Panel panel1;
	}
}