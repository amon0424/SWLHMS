namespace Mong
{
	partial class DateLineForm
	{
		/// <summary>
		/// 設計工具所需的變數。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清除任何使用中的資源。
		/// </summary>
		/// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 設計工具產生的程式碼

		/// <summary>
		/// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
		///
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.ckbAllTime = new System.Windows.Forms.CheckBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnExport = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.dtpFrom = new System.Windows.Forms.DateTimePicker();
			this.dtpTo = new System.Windows.Forms.DateTimePicker();
			this.label6 = new System.Windows.Forms.Label();
			this.cbbLine = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.bsLine = new System.Windows.Forms.BindingSource(this.components);
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsLine)).BeginInit();
			this.SuspendLayout();
			// 
			// ckbAllTime
			// 
			this.ckbAllTime.AutoSize = true;
			this.ckbAllTime.Location = new System.Drawing.Point(12, 93);
			this.ckbAllTime.Name = "ckbAllTime";
			this.ckbAllTime.Size = new System.Drawing.Size(72, 16);
			this.ckbAllTime.TabIndex = 1;
			this.ckbAllTime.Text = "所有期間";
			this.ckbAllTime.UseVisualStyleBackColor = true;
			this.ckbAllTime.Visible = false;
			this.ckbAllTime.Click += new System.EventHandler(this.ckbAllTime_CheckedChanged);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(228, 93);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "取消";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnExport
			// 
			this.btnExport.Location = new System.Drawing.Point(147, 93);
			this.btnExport.Name = "btnExport";
			this.btnExport.Size = new System.Drawing.Size(75, 23);
			this.btnExport.TabIndex = 2;
			this.btnExport.Text = "輸出";
			this.btnExport.UseVisualStyleBackColor = true;
			this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.dtpFrom);
			this.groupBox1.Controls.Add(this.dtpTo);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Location = new System.Drawing.Point(10, 38);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(293, 49);
			this.groupBox1.TabIndex = 48;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "輸出報表期間";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 23);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(17, 12);
			this.label5.TabIndex = 9;
			this.label5.Text = "從";
			// 
			// dtpFrom
			// 
			this.dtpFrom.Location = new System.Drawing.Point(29, 18);
			this.dtpFrom.Name = "dtpFrom";
			this.dtpFrom.Size = new System.Drawing.Size(114, 22);
			this.dtpFrom.TabIndex = 0;
			// 
			// dtpTo
			// 
			this.dtpTo.Location = new System.Drawing.Point(172, 18);
			this.dtpTo.Name = "dtpTo";
			this.dtpTo.Size = new System.Drawing.Size(114, 22);
			this.dtpTo.TabIndex = 1;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(149, 23);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(17, 12);
			this.label6.TabIndex = 10;
			this.label6.Text = "到";
			// 
			// cbbLine
			// 
			this.cbbLine.DataSource = this.bsLine;
			this.cbbLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbbLine.FormattingEnabled = true;
			this.cbbLine.Location = new System.Drawing.Point(49, 12);
			this.cbbLine.Name = "cbbLine";
			this.cbbLine.Size = new System.Drawing.Size(121, 20);
			this.cbbLine.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(14, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 12);
			this.label1.TabIndex = 53;
			this.label1.Text = "產線";
			// 
			// DateLineForm
			// 
			this.AcceptButton = this.btnExport;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(315, 127);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cbbLine);
			this.Controls.Add(this.ckbAllTime);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnExport);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DateLineForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsLine)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox ckbAllTime;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnExport;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DateTimePicker dtpFrom;
		private System.Windows.Forms.DateTimePicker dtpTo;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox cbbLine;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.BindingSource bsLine;
	}
}
