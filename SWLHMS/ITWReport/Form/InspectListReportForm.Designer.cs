namespace Mong
{
	partial class InspectListReportForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.txtQCN = new System.Windows.Forms.TextBox();
			this.txtPartNumber = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtWorksheetFrom = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.pnlDate = new System.Windows.Forms.FlowLayoutPanel();
			this.label5 = new System.Windows.Forms.Label();
			this.dtpFrom = new System.Windows.Forms.DateTimePicker();
			this.label6 = new System.Windows.Forms.Label();
			this.dtpTo = new System.Windows.Forms.DateTimePicker();
			this.ckbDate = new System.Windows.Forms.CheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnExport = new System.Windows.Forms.Button();
			this.txtWorksheetTo = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.cbxLine = new System.Windows.Forms.ComboBox();
			this.ckbStatistic = new System.Windows.Forms.CheckBox();
			this.ckbGroup = new System.Windows.Forms.CheckBox();
			this.btnSort = new System.Windows.Forms.Button();
			this.rbInspectByQcN = new System.Windows.Forms.RadioButton();
			this.rbInspectByPn = new System.Windows.Forms.RadioButton();
			this.rbOnlyNg = new System.Windows.Forms.RadioButton();
			this.pnlDate.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(36, 43);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(27, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "QC#";
			// 
			// txtQCN
			// 
			this.txtQCN.Enabled = false;
			this.txtQCN.Location = new System.Drawing.Point(69, 40);
			this.txtQCN.Name = "txtQCN";
			this.txtQCN.Size = new System.Drawing.Size(133, 22);
			this.txtQCN.TabIndex = 1;
			// 
			// txtPartNumber
			// 
			this.txtPartNumber.Location = new System.Drawing.Point(69, 68);
			this.txtPartNumber.Name = "txtPartNumber";
			this.txtPartNumber.Size = new System.Drawing.Size(133, 22);
			this.txtPartNumber.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(34, 73);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 12);
			this.label2.TabIndex = 2;
			this.label2.Text = "料號";
			// 
			// txtWorksheetFrom
			// 
			this.txtWorksheetFrom.Location = new System.Drawing.Point(69, 96);
			this.txtWorksheetFrom.Name = "txtWorksheetFrom";
			this.txtWorksheetFrom.Size = new System.Drawing.Size(133, 22);
			this.txtWorksheetFrom.TabIndex = 4;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(10, 101);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(53, 12);
			this.label7.TabIndex = 5;
			this.label7.Text = "工作單號";
			// 
			// pnlDate
			// 
			this.pnlDate.Controls.Add(this.label5);
			this.pnlDate.Controls.Add(this.dtpFrom);
			this.pnlDate.Controls.Add(this.label6);
			this.pnlDate.Controls.Add(this.dtpTo);
			this.pnlDate.Enabled = false;
			this.pnlDate.Location = new System.Drawing.Point(87, 123);
			this.pnlDate.Name = "pnlDate";
			this.pnlDate.Size = new System.Drawing.Size(286, 25);
			this.pnlDate.TabIndex = 42;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(3, 6);
			this.label5.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(17, 12);
			this.label5.TabIndex = 37;
			this.label5.Text = "從";
			// 
			// dtpFrom
			// 
			this.dtpFrom.Location = new System.Drawing.Point(26, 0);
			this.dtpFrom.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.dtpFrom.Name = "dtpFrom";
			this.dtpFrom.Size = new System.Drawing.Size(114, 22);
			this.dtpFrom.TabIndex = 35;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(146, 6);
			this.label6.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(17, 12);
			this.label6.TabIndex = 38;
			this.label6.Text = "到";
			// 
			// dtpTo
			// 
			this.dtpTo.Location = new System.Drawing.Point(169, 0);
			this.dtpTo.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.dtpTo.Name = "dtpTo";
			this.dtpTo.Size = new System.Drawing.Size(114, 22);
			this.dtpTo.TabIndex = 36;
			// 
			// ckbDate
			// 
			this.ckbDate.AutoSize = true;
			this.ckbDate.Location = new System.Drawing.Point(69, 129);
			this.ckbDate.Name = "ckbDate";
			this.ckbDate.Size = new System.Drawing.Size(15, 14);
			this.ckbDate.TabIndex = 41;
			this.ckbDate.UseVisualStyleBackColor = true;
			this.ckbDate.CheckedChanged += new System.EventHandler(this.ckbDate_CheckedChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(10, 129);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 12);
			this.label3.TabIndex = 43;
			this.label3.Text = "檢驗日期";
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(299, 268);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 55;
			this.btnCancel.Text = "取消";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnExport
			// 
			this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExport.Location = new System.Drawing.Point(218, 268);
			this.btnExport.Name = "btnExport";
			this.btnExport.Size = new System.Drawing.Size(75, 23);
			this.btnExport.TabIndex = 54;
			this.btnExport.Text = "輸出";
			this.btnExport.UseVisualStyleBackColor = true;
			this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
			// 
			// txtWorksheetTo
			// 
			this.txtWorksheetTo.Location = new System.Drawing.Point(225, 96);
			this.txtWorksheetTo.Name = "txtWorksheetTo";
			this.txtWorksheetTo.Size = new System.Drawing.Size(133, 22);
			this.txtWorksheetTo.TabIndex = 56;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(208, 101);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(11, 12);
			this.label4.TabIndex = 57;
			this.label4.Text = "~";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(34, 17);
			this.label8.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(29, 12);
			this.label8.TabIndex = 63;
			this.label8.Text = "產線";
			// 
			// cbxLine
			// 
			this.cbxLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxLine.FormattingEnabled = true;
			this.cbxLine.Location = new System.Drawing.Point(69, 14);
			this.cbxLine.Name = "cbxLine";
			this.cbxLine.Size = new System.Drawing.Size(133, 20);
			this.cbxLine.TabIndex = 62;
			// 
			// ckbStatistic
			// 
			this.ckbStatistic.AutoSize = true;
			this.ckbStatistic.Location = new System.Drawing.Point(12, 218);
			this.ckbStatistic.Name = "ckbStatistic";
			this.ckbStatistic.Size = new System.Drawing.Size(96, 16);
			this.ckbStatistic.TabIndex = 64;
			this.ckbStatistic.Text = "品質統計報表";
			this.ckbStatistic.UseVisualStyleBackColor = true;
			// 
			// ckbGroup
			// 
			this.ckbGroup.AutoSize = true;
			this.ckbGroup.Enabled = false;
			this.ckbGroup.Location = new System.Drawing.Point(12, 236);
			this.ckbGroup.Name = "ckbGroup";
			this.ckbGroup.Size = new System.Drawing.Size(244, 16);
			this.ckbGroup.TabIndex = 65;
			this.ckbGroup.Text = "同一 QC# 多次送檢時僅列出最後檢驗記錄";
			this.ckbGroup.UseVisualStyleBackColor = true;
			// 
			// btnSort
			// 
			this.btnSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSort.Location = new System.Drawing.Point(137, 268);
			this.btnSort.Name = "btnSort";
			this.btnSort.Size = new System.Drawing.Size(75, 23);
			this.btnSort.TabIndex = 66;
			this.btnSort.Text = "設定排序";
			this.btnSort.UseVisualStyleBackColor = true;
			this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
			// 
			// rbInspectByQcN
			// 
			this.rbInspectByQcN.AutoSize = true;
			this.rbInspectByQcN.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.rbInspectByQcN.Location = new System.Drawing.Point(12, 179);
			this.rbInspectByQcN.Name = "rbInspectByQcN";
			this.rbInspectByQcN.Size = new System.Drawing.Size(105, 16);
			this.rbInspectByQcN.TabIndex = 68;
			this.rbInspectByQcN.Text = "依QC#個別顯示";
			this.rbInspectByQcN.UseVisualStyleBackColor = true;
			this.rbInspectByQcN.CheckedChanged += new System.EventHandler(this.rbInspectByQcN_CheckedChanged);
			// 
			// rbInspectByPn
			// 
			this.rbInspectByPn.AutoSize = true;
			this.rbInspectByPn.Checked = true;
			this.rbInspectByPn.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.rbInspectByPn.Location = new System.Drawing.Point(12, 163);
			this.rbInspectByPn.Name = "rbInspectByPn";
			this.rbInspectByPn.Size = new System.Drawing.Size(251, 16);
			this.rbInspectByPn.TabIndex = 67;
			this.rbInspectByPn.TabStop = true;
			this.rbInspectByPn.Text = "依工作單號及料號顯示累計總檢驗數及結果";
			this.rbInspectByPn.UseVisualStyleBackColor = true;
			this.rbInspectByPn.CheckedChanged += new System.EventHandler(this.rbInspectByPn_CheckedChanged);
			// 
			// rbOnlyNg
			// 
			this.rbOnlyNg.AutoSize = true;
			this.rbOnlyNg.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.rbOnlyNg.Location = new System.Drawing.Point(12, 196);
			this.rbOnlyNg.Name = "rbOnlyNg";
			this.rbOnlyNg.Size = new System.Drawing.Size(168, 16);
			this.rbOnlyNg.TabIndex = 69;
			this.rbOnlyNg.Text = "僅列出 有 NG 紀錄之檢驗批";
			this.rbOnlyNg.UseVisualStyleBackColor = true;
			this.rbOnlyNg.CheckedChanged += new System.EventHandler(this.rbOnlyNg_CheckedChanged);
			// 
			// InspectListReportForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(386, 303);
			this.Controls.Add(this.rbOnlyNg);
			this.Controls.Add(this.rbInspectByQcN);
			this.Controls.Add(this.rbInspectByPn);
			this.Controls.Add(this.btnSort);
			this.Controls.Add(this.ckbGroup);
			this.Controls.Add(this.ckbStatistic);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.cbxLine);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtWorksheetTo);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnExport);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.pnlDate);
			this.Controls.Add(this.ckbDate);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.txtWorksheetFrom);
			this.Controls.Add(this.txtPartNumber);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtQCN);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "InspectListReportForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "產品檢驗報表";
			this.Load += new System.EventHandler(this.InspectListReportForm_Load);
			this.pnlDate.ResumeLayout(false);
			this.pnlDate.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtQCN;
		private System.Windows.Forms.TextBox txtPartNumber;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtWorksheetFrom;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.FlowLayoutPanel pnlDate;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DateTimePicker dtpFrom;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.DateTimePicker dtpTo;
		private System.Windows.Forms.CheckBox ckbDate;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnExport;
		private System.Windows.Forms.TextBox txtWorksheetTo;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox cbxLine;
		private System.Windows.Forms.CheckBox ckbStatistic;
		private System.Windows.Forms.CheckBox ckbGroup;
		private System.Windows.Forms.Button btnSort;
		private System.Windows.Forms.RadioButton rbInspectByQcN;
		private System.Windows.Forms.RadioButton rbInspectByPn;
		private System.Windows.Forms.RadioButton rbOnlyNg;
	}
}