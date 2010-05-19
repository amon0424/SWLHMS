namespace Mong
{
	partial class ButtonTextboxEditingControl
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
			this.textBox = new System.Windows.Forms.TextBox();
			this.browseButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBox
			// 
			this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox.Location = new System.Drawing.Point(0, 3);
			this.textBox.Name = "textBox";
			this.textBox.Size = new System.Drawing.Size(88, 15);
			this.textBox.TabIndex = 0;
			// 
			// browseButton
			// 
			this.browseButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.browseButton.Location = new System.Drawing.Point(88, 1);
			this.browseButton.Name = "browseButton";
			this.browseButton.Size = new System.Drawing.Size(20, 19);
			this.browseButton.TabIndex = 1;
			this.browseButton.Text = "...";
			this.browseButton.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
			// 
			// ButtonTextboxEditingControl
			// 
			this.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.Controls.Add(this.browseButton);
			this.Controls.Add(this.textBox);
			this.Name = "ButtonTextboxEditingControl";
			this.Size = new System.Drawing.Size(108, 20);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button browseButton;
		private System.Windows.Forms.TextBox textBox;
	}
}
