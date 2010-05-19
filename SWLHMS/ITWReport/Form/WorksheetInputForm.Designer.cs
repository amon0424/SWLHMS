namespace Mong
{
    partial class WorksheetInputForm
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
			this.label13 = new System.Windows.Forms.Label();
			this.txtDate = new System.Windows.Forms.MaskedTextBox();
			this.cbbWorksheetNubmerS = new System.Windows.Forms.ComboBox();
			this.btnSrchWorksheet = new System.Windows.Forms.Button();
			this.btnExport = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtContact = new System.Windows.Forms.TextBox();
			this.txtName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(7, 18);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(53, 12);
			this.label13.TabIndex = 43;
			this.label13.Text = "工作單號";
			// 
			// txtDate
			// 
			this.txtDate.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
			this.txtDate.Location = new System.Drawing.Point(223, 13);
			this.txtDate.Mask = "0000-00-00";
			this.txtDate.Name = "txtDate";
			this.txtDate.Size = new System.Drawing.Size(66, 22);
			this.txtDate.TabIndex = 41;
			// 
			// cbbWorksheetNubmerS
			// 
			this.cbbWorksheetNubmerS.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.cbbWorksheetNubmerS.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbbWorksheetNubmerS.FormattingEnabled = true;
			this.cbbWorksheetNubmerS.Location = new System.Drawing.Point(65, 14);
			this.cbbWorksheetNubmerS.Name = "cbbWorksheetNubmerS";
			this.cbbWorksheetNubmerS.Size = new System.Drawing.Size(152, 20);
			this.cbbWorksheetNubmerS.TabIndex = 40;
			// 
			// btnSrchWorksheet
			// 
			this.btnSrchWorksheet.Location = new System.Drawing.Point(295, 13);
			this.btnSrchWorksheet.Name = "btnSrchWorksheet";
			this.btnSrchWorksheet.Size = new System.Drawing.Size(127, 23);
			this.btnSrchWorksheet.TabIndex = 42;
			this.btnSrchWorksheet.Text = "使用日期查詢";
			this.btnSrchWorksheet.UseVisualStyleBackColor = true;
			this.btnSrchWorksheet.Click += new System.EventHandler(this.btnSrchWorksheet_Click_1);
			// 
			// btnExport
			// 
			this.btnExport.Location = new System.Drawing.Point(266, 96);
			this.btnExport.Name = "btnExport";
			this.btnExport.Size = new System.Drawing.Size(75, 23);
			this.btnExport.TabIndex = 44;
			this.btnExport.Text = "輸出";
			this.btnExport.UseVisualStyleBackColor = true;
			this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(347, 96);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 45;
			this.btnCancel.Text = "取消";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(19, 73);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 12);
			this.label1.TabIndex = 46;
			this.label1.Text = "連絡人";
			// 
			// txtContact
			// 
			this.txtContact.Location = new System.Drawing.Point(65, 68);
			this.txtContact.Name = "txtContact";
			this.txtContact.Size = new System.Drawing.Size(357, 22);
			this.txtContact.TabIndex = 47;
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(65, 40);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(357, 22);
			this.txtName.TabIndex = 49;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(7, 45);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 12);
			this.label2.TabIndex = 48;
			this.label2.Text = "領班姓名";
			// 
			// WorksheetInputForm
			// 
			this.AcceptButton = this.btnExport;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(435, 127);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtContact);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnExport);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.txtDate);
			this.Controls.Add(this.cbbWorksheetNubmerS);
			this.Controls.Add(this.btnSrchWorksheet);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "WorksheetInputForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "WorksheetInputForm";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.MaskedTextBox txtDate;
        private System.Windows.Forms.ComboBox cbbWorksheetNubmerS;
        private System.Windows.Forms.Button btnSrchWorksheet;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtContact;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label label2;
    }
}