namespace Mong
{
    partial class SettingForm
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
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.dtpTip = new System.Windows.Forms.DateTimePicker();
			this.tbxDayWH = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.tbxLaborWageDir = new System.Windows.Forms.TextBox();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.label5 = new System.Windows.Forms.Label();
			this.txtHourlyPay = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.dtpTip);
			this.groupBox2.Location = new System.Drawing.Point(3, 4);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(442, 96);
			this.groupBox2.TabIndex = 39;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "未補足資料提示";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(7, 61);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(434, 30);
			this.label2.TabIndex = 10;
			this.label2.Text = "例: 如設定 2008.1.1 ，員工在輸入資料時系統便會判斷在2008.1.1到今天這段期間是否有時數未補足的日期";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(197, 12);
			this.label1.TabIndex = 9;
			this.label1.Text = "提示指定日期之後未補足時數的資料\r\n";
			// 
			// dtpTip
			// 
			this.dtpTip.Location = new System.Drawing.Point(9, 34);
			this.dtpTip.Name = "dtpTip";
			this.dtpTip.Size = new System.Drawing.Size(124, 22);
			this.dtpTip.TabIndex = 8;
			this.dtpTip.ValueChanged += new System.EventHandler(this.dtpTip_ValueChanged);
			// 
			// tbxDayWH
			// 
			this.tbxDayWH.Location = new System.Drawing.Point(65, 17);
			this.tbxDayWH.Name = "tbxDayWH";
			this.tbxDayWH.Size = new System.Drawing.Size(47, 22);
			this.tbxDayWH.TabIndex = 40;
			this.tbxDayWH.Validated += new System.EventHandler(this.tbxDayWH_Validated);
			this.tbxDayWH.Validating += new System.ComponentModel.CancelEventHandler(this.tbxDayWH_Validating);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 22);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 12);
			this.label3.TabIndex = 41;
			this.label3.Text = "每日工時";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.txtHourlyPay);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.tbxDayWH);
			this.groupBox1.Location = new System.Drawing.Point(3, 106);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(441, 119);
			this.groupBox1.TabIndex = 42;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "每日基本工時與時薪";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 45);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(341, 12);
			this.label4.TabIndex = 42;
			this.label4.Text = "每日的工作時數，在輸出報表時會用來計算每個月的總工作時數";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(288, 302);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 44;
			this.btnOK.Text = "確定";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(369, 302);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 45;
			this.btnCancel.Text = "取消";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.btnBrowse);
			this.groupBox4.Controls.Add(this.label9);
			this.groupBox4.Controls.Add(this.label10);
			this.groupBox4.Controls.Add(this.tbxLaborWageDir);
			this.groupBox4.Location = new System.Drawing.Point(4, 231);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(441, 65);
			this.groupBox4.TabIndex = 46;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "LaborWage程式目錄 (v1.16)";
			// 
			// btnBrowse
			// 
			this.btnBrowse.Location = new System.Drawing.Point(357, 17);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(75, 23);
			this.btnBrowse.TabIndex = 43;
			this.btnBrowse.Text = "瀏覽";
			this.btnBrowse.UseVisualStyleBackColor = true;
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(6, 45);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(415, 12);
			this.label9.TabIndex = 42;
			this.label9.Text = "輸出報表時會讀取LaborWage資料庫的資料，請選取正確的LaborWage程式目錄\r\n";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(6, 22);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(53, 12);
			this.label10.TabIndex = 41;
			this.label10.Text = "目錄路徑";
			// 
			// tbxLaborWageDir
			// 
			this.tbxLaborWageDir.Location = new System.Drawing.Point(64, 17);
			this.tbxLaborWageDir.Name = "tbxLaborWageDir";
			this.tbxLaborWageDir.Size = new System.Drawing.Size(287, 22);
			this.tbxLaborWageDir.TabIndex = 40;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 72);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(29, 12);
			this.label5.TabIndex = 44;
			this.label5.Text = "時薪";
			// 
			// txtHourlyPay
			// 
			this.txtHourlyPay.Location = new System.Drawing.Point(65, 67);
			this.txtHourlyPay.Name = "txtHourlyPay";
			this.txtHourlyPay.Size = new System.Drawing.Size(47, 22);
			this.txtHourlyPay.TabIndex = 43;
			this.txtHourlyPay.TextChanged += new System.EventHandler(this.txtHourlyPay_TextChanged);
			this.txtHourlyPay.Validating += new System.ComponentModel.CancelEventHandler(this.txtHourlyPay_Validating);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 95);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(221, 12);
			this.label6.TabIndex = 45;
			this.label6.Text = "每小時薪資，用來計算外包工資對應工時";
			// 
			// SettingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(448, 331);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "SettingForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "設定";
			this.Load += new System.EventHandler(this.SettingForm_Load);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpTip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxDayWH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbxLaborWageDir;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtHourlyPay;
    }
}