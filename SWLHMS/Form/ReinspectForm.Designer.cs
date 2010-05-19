namespace Mong
{
	partial class ReinspectForm
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
			this.components = new System.ComponentModel.Container();
			this.label1 = new System.Windows.Forms.Label();
			this.txtWorksheet = new System.Windows.Forms.TextBox();
			this.txtPartNumber = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtQCN = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtAmount = new System.Windows.Forms.TextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.txtHour = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.lbRemain = new System.Windows.Forms.Label();
			this.ckbOvertime = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "工作單號";
			// 
			// txtWorksheet
			// 
			this.txtWorksheet.Location = new System.Drawing.Point(72, 12);
			this.txtWorksheet.Name = "txtWorksheet";
			this.txtWorksheet.ReadOnly = true;
			this.txtWorksheet.Size = new System.Drawing.Size(220, 22);
			this.txtWorksheet.TabIndex = 1;
			// 
			// txtPartNumber
			// 
			this.txtPartNumber.Location = new System.Drawing.Point(72, 40);
			this.txtPartNumber.Name = "txtPartNumber";
			this.txtPartNumber.ReadOnly = true;
			this.txtPartNumber.Size = new System.Drawing.Size(220, 22);
			this.txtPartNumber.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(37, 45);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 12);
			this.label2.TabIndex = 2;
			this.label2.Text = "品號";
			// 
			// txtQCN
			// 
			this.txtQCN.Location = new System.Drawing.Point(72, 68);
			this.txtQCN.Name = "txtQCN";
			this.txtQCN.Size = new System.Drawing.Size(220, 22);
			this.txtQCN.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(37, 73);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(27, 12);
			this.label3.TabIndex = 5;
			this.label3.Text = "QC#";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(13, 101);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 12);
			this.label4.TabIndex = 6;
			this.label4.Text = "送檢數量";
			// 
			// txtAmount
			// 
			this.txtAmount.Location = new System.Drawing.Point(72, 96);
			this.txtAmount.Name = "txtAmount";
			this.txtAmount.Size = new System.Drawing.Size(220, 22);
			this.txtAmount.TabIndex = 7;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(217, 156);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 37;
			this.btnCancel.Text = "取消";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(114, 156);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(97, 23);
			this.btnOK.TabIndex = 36;
			this.btnOK.Text = "新增至清單";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// txtHour
			// 
			this.txtHour.Location = new System.Drawing.Point(72, 124);
			this.txtHour.Name = "txtHour";
			this.txtHour.Size = new System.Drawing.Size(67, 22);
			this.txtHour.TabIndex = 39;
			this.txtHour.Text = "0";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(37, 129);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(29, 12);
			this.label5.TabIndex = 38;
			this.label5.Text = "工時";
			// 
			// lbRemain
			// 
			this.lbRemain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lbRemain.AutoSize = true;
			this.lbRemain.ForeColor = System.Drawing.Color.Red;
			this.lbRemain.Location = new System.Drawing.Point(201, 128);
			this.lbRemain.Name = "lbRemain";
			this.lbRemain.Size = new System.Drawing.Size(83, 12);
			this.lbRemain.TabIndex = 40;
			this.lbRemain.Text = "本日尚餘8小時";
			// 
			// ckbOvertime
			// 
			this.ckbOvertime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ckbOvertime.AutoSize = true;
			this.ckbOvertime.Location = new System.Drawing.Point(147, 127);
			this.ckbOvertime.Name = "ckbOvertime";
			this.ckbOvertime.Size = new System.Drawing.Size(48, 16);
			this.ckbOvertime.TabIndex = 41;
			this.ckbOvertime.Text = "加班";
			this.ckbOvertime.UseVisualStyleBackColor = true;
			this.ckbOvertime.CheckedChanged += new System.EventHandler(this.ckbOvertime_CheckedChanged);
			// 
			// ReinspectForm
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(304, 191);
			this.Controls.Add(this.ckbOvertime);
			this.Controls.Add(this.lbRemain);
			this.Controls.Add(this.txtHour);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.txtAmount);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtQCN);
			this.Controls.Add(this.txtPartNumber);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtWorksheet);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ReinspectForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "從新送驗";
			this.Load += new System.EventHandler(this.ReinspectForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtWorksheet;
		private System.Windows.Forms.TextBox txtPartNumber;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtQCN;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtAmount;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.BindingSource bindingSource;
		private System.Windows.Forms.TextBox txtHour;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lbRemain;
		private System.Windows.Forms.CheckBox ckbOvertime;
	}
}