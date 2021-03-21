namespace Gazette
{
	partial class MainMenu
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
			this.ConnectionControl = new System.Windows.Forms.TabControl();
			this.DefaultPage = new System.Windows.Forms.TabPage();
			this.NewConnectionButton = new System.Windows.Forms.Button();
			this.CloseTabButton = new System.Windows.Forms.Button();
			this.ConnectionControl.SuspendLayout();
			this.SuspendLayout();
			// 
			// ConnectionControl
			// 
			this.ConnectionControl.Alignment = System.Windows.Forms.TabAlignment.Left;
			this.ConnectionControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ConnectionControl.Controls.Add(this.DefaultPage);
			this.ConnectionControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
			this.ConnectionControl.HotTrack = true;
			this.ConnectionControl.ItemSize = new System.Drawing.Size(25, 100);
			this.ConnectionControl.Location = new System.Drawing.Point(12, 12);
			this.ConnectionControl.Multiline = true;
			this.ConnectionControl.Name = "ConnectionControl";
			this.ConnectionControl.SelectedIndex = 0;
			this.ConnectionControl.Size = new System.Drawing.Size(608, 308);
			this.ConnectionControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			this.ConnectionControl.TabIndex = 3;
			this.ConnectionControl.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ConnectionControl_DrawItem);
			// 
			// DefaultPage
			// 
			this.DefaultPage.Location = new System.Drawing.Point(104, 4);
			this.DefaultPage.Name = "DefaultPage";
			this.DefaultPage.Padding = new System.Windows.Forms.Padding(3);
			this.DefaultPage.Size = new System.Drawing.Size(500, 300);
			this.DefaultPage.TabIndex = 2;
			this.DefaultPage.Text = "Default Page";
			this.DefaultPage.UseVisualStyleBackColor = true;
			// 
			// NewConnectionButton
			// 
			this.NewConnectionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.NewConnectionButton.Location = new System.Drawing.Point(12, 298);
			this.NewConnectionButton.Name = "NewConnectionButton";
			this.NewConnectionButton.Size = new System.Drawing.Size(98, 23);
			this.NewConnectionButton.TabIndex = 4;
			this.NewConnectionButton.Text = "New Connection";
			this.NewConnectionButton.UseVisualStyleBackColor = true;
			this.NewConnectionButton.Click += new System.EventHandler(this.NewConnectionButton_Click);
			// 
			// CloseTabButton
			// 
			this.CloseTabButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.CloseTabButton.Location = new System.Drawing.Point(592, 12);
			this.CloseTabButton.Name = "CloseTabButton";
			this.CloseTabButton.Size = new System.Drawing.Size(28, 23);
			this.CloseTabButton.TabIndex = 5;
			this.CloseTabButton.Text = "X";
			this.CloseTabButton.UseVisualStyleBackColor = true;
			this.CloseTabButton.Click += new System.EventHandler(this.CloseTabButton_Click);
			// 
			// MainMenu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(627, 326);
			this.Controls.Add(this.CloseTabButton);
			this.Controls.Add(this.NewConnectionButton);
			this.Controls.Add(this.ConnectionControl);
			this.Name = "MainMenu";
			this.Text = "Main Menu";
			this.ConnectionControl.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.TabControl ConnectionControl;
		private System.Windows.Forms.Button NewConnectionButton;
		private System.Windows.Forms.TabPage DefaultPage;
		private System.Windows.Forms.Button CloseTabButton;
	}
}

