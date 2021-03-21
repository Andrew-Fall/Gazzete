namespace Gazette.CustomControls
{
	partial class MyList
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
			this.ListScrollBar = new Gazette.CustomControls.MyVScrollBar();
			this.SuspendLayout();
			// 
			// ListScrollBar
			// 
			this.ListScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ListScrollBar.LargeChange = 1;
			this.ListScrollBar.Location = new System.Drawing.Point(330, 0);
			this.ListScrollBar.Maximum = 0;
			this.ListScrollBar.Name = "ListScrollBar";
			this.ListScrollBar.Size = new System.Drawing.Size(17, 301);
			this.ListScrollBar.TabIndex = 0;
			// 
			// MyList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.ListScrollBar);
			this.DoubleBuffered = true;
			this.Name = "MyList";
			this.Size = new System.Drawing.Size(347, 301);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MyList_MouseMove);
			this.Resize += new System.EventHandler(this.MyList_Resize);
			this.ResumeLayout(false);

		}

		#endregion

		private MyVScrollBar ListScrollBar;
	}
}
