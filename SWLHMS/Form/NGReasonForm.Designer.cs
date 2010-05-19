namespace Mong
{
	partial class NGReasonForm
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
			this.cbbType = new System.Windows.Forms.ComboBox();
			this.txtContent = new System.Windows.Forms.TextBox();
			this.lbPreview = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// cbbType
			// 
			this.cbbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbbType.FormattingEnabled = true;
			this.cbbType.Location = new System.Drawing.Point(48, 12);
			this.cbbType.Name = "cbbType";
			this.cbbType.Size = new System.Drawing.Size(90, 20);
			this.cbbType.TabIndex = 0;
			this.cbbType.SelectedIndexChanged += new System.EventHandler(this.cbbType_SelectedIndexChanged);
			// 
			// txtContent
			// 
			this.txtContent.Location = new System.Drawing.Point(48, 38);
			this.txtContent.Name = "txtContent";
			this.txtContent.Size = new System.Drawing.Size(232, 22);
			this.txtContent.TabIndex = 1;
			this.txtContent.TextChanged += new System.EventHandler(this.txtContent_TextChanged);
			// 
			// lbPreview
			// 
			this.lbPreview.AutoSize = true;
			this.lbPreview.Location = new System.Drawing.Point(13, 69);
			this.lbPreview.Name = "lbPreview";
			this.lbPreview.Size = new System.Drawing.Size(45, 12);
			this.lbPreview.TabIndex = 2;
			this.lbPreview.Text = "NG原因";
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Enabled = false;
			this.btnOK.Location = new System.Drawing.Point(124, 84);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 3;
			this.btnOK.Text = "確定";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(205, 84);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "取消";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 43);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 12);
			this.label1.TabIndex = 5;
			this.label1.Text = "內容";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 12);
			this.label2.TabIndex = 6;
			this.label2.Text = "類別";
			// 
			// NGReasonForm
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(292, 119);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.lbPreview);
			this.Controls.Add(this.txtContent);
			this.Controls.Add(this.cbbType);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NGReasonForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "NG原因";
			this.Load += new System.EventHandler(this.NGReasonForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cbbType;
		private System.Windows.Forms.TextBox txtContent;
		private System.Windows.Forms.Label lbPreview;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
	}
}