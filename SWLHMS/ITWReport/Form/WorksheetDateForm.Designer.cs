namespace Mong
{
    partial class WorksheetDateForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該公開 Managed 資源則為 true，否則為 false。</param>
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
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnExport = new System.Windows.Forms.Button();
			this.label13 = new System.Windows.Forms.Label();
			this.txtDate = new System.Windows.Forms.MaskedTextBox();
			this.cbbWorksheetNubmerS = new System.Windows.Forms.ComboBox();
			this.btnSrchWorksheet = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.ckbDate = new System.Windows.Forms.CheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.dtpFrom = new System.Windows.Forms.DateTimePicker();
			this.dtpTo = new System.Windows.Forms.DateTimePicker();
			this.label6 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(345, 69);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 53;
			this.btnCancel.Text = "取消";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnExport
			// 
			this.btnExport.Location = new System.Drawing.Point(345, 40);
			this.btnExport.Name = "btnExport";
			this.btnExport.Size = new System.Drawing.Size(75, 23);
			this.btnExport.TabIndex = 52;
			this.btnExport.Text = "輸出";
			this.btnExport.UseVisualStyleBackColor = true;
			this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(5, 16);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(53, 12);
			this.label13.TabIndex = 51;
			this.label13.Text = "工作單號";
			// 
			// txtDate
			// 
			this.txtDate.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
			this.txtDate.Location = new System.Drawing.Point(221, 11);
			this.txtDate.Mask = "0000-00-00";
			this.txtDate.Name = "txtDate";
			this.txtDate.Size = new System.Drawing.Size(66, 22);
			this.txtDate.TabIndex = 49;
			// 
			// cbbWorksheetNubmerS
			// 
			this.cbbWorksheetNubmerS.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.cbbWorksheetNubmerS.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbbWorksheetNubmerS.FormattingEnabled = true;
			this.cbbWorksheetNubmerS.Location = new System.Drawing.Point(63, 12);
			this.cbbWorksheetNubmerS.Name = "cbbWorksheetNubmerS";
			this.cbbWorksheetNubmerS.Size = new System.Drawing.Size(152, 20);
			this.cbbWorksheetNubmerS.TabIndex = 48;
			// 
			// btnSrchWorksheet
			// 
			this.btnSrchWorksheet.Location = new System.Drawing.Point(293, 11);
			this.btnSrchWorksheet.Name = "btnSrchWorksheet";
			this.btnSrchWorksheet.Size = new System.Drawing.Size(127, 23);
			this.btnSrchWorksheet.TabIndex = 50;
			this.btnSrchWorksheet.Text = "使用日期查詢";
			this.btnSrchWorksheet.UseVisualStyleBackColor = true;
			this.btnSrchWorksheet.Click += new System.EventHandler(this.btnSrchWorksheet_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.ckbDate);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.dtpFrom);
			this.groupBox1.Controls.Add(this.dtpTo);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Location = new System.Drawing.Point(7, 38);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(324, 47);
			this.groupBox1.TabIndex = 56;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "單據日期";
			// 
			// ckbDate
			// 
			this.ckbDate.AutoSize = true;
			this.ckbDate.Location = new System.Drawing.Point(10, 22);
			this.ckbDate.Name = "ckbDate";
			this.ckbDate.Size = new System.Drawing.Size(15, 14);
			this.ckbDate.TabIndex = 11;
			this.ckbDate.UseVisualStyleBackColor = true;
			this.ckbDate.CheckedChanged += new System.EventHandler(this.ckbDate_CheckedChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(32, 23);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(17, 12);
			this.label5.TabIndex = 9;
			this.label5.Text = "從";
			// 
			// dtpFrom
			// 
			this.dtpFrom.Enabled = false;
			this.dtpFrom.Location = new System.Drawing.Point(55, 18);
			this.dtpFrom.Name = "dtpFrom";
			this.dtpFrom.Size = new System.Drawing.Size(114, 22);
			this.dtpFrom.TabIndex = 7;
			// 
			// dtpTo
			// 
			this.dtpTo.Enabled = false;
			this.dtpTo.Location = new System.Drawing.Point(198, 18);
			this.dtpTo.Name = "dtpTo";
			this.dtpTo.Size = new System.Drawing.Size(114, 22);
			this.dtpTo.TabIndex = 8;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(175, 23);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(17, 12);
			this.label6.TabIndex = 10;
			this.label6.Text = "到";
			// 
			// WorksheetDateForm
			// 
			this.AcceptButton = this.btnExport;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(433, 99);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnExport);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.txtDate);
			this.Controls.Add(this.cbbWorksheetNubmerS);
			this.Controls.Add(this.btnSrchWorksheet);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "WorksheetDateForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "WorksheetNoDateForm";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.MaskedTextBox txtDate;
        private System.Windows.Forms.ComboBox cbbWorksheetNubmerS;
        private System.Windows.Forms.Button btnSrchWorksheet;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox ckbDate;
    }
}