namespace Mong
{
    partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.tsmiManage = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiProductManage = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiLineMangage = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiLaborManage = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiNonProduceForm = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiQualityItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiWorkingHourManage = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiWorksheetManage = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiHourDataManage = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiUser = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiQuality = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiInspectList = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiInspect = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiInspectDel = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiWorksheet = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiNewWorksheet = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiWorksheetSearch = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiDataFill = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiReport = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiSettings = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiLogout = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiManage,
            this.tsmiQuality,
            this.tsmiWorksheet,
            this.tsmiDataFill,
            this.tsmiReport,
            this.tsmiSettings,
            this.tsmiLogout});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(488, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			this.menuStrip1.Visible = false;
			// 
			// tsmiManage
			// 
			this.tsmiManage.BackColor = System.Drawing.SystemColors.Control;
			this.tsmiManage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiProductManage,
            this.tsmiLineMangage,
            this.tsmiLaborManage,
            this.tsmiNonProduceForm,
            this.tsmiQualityItem,
            this.tsmiWorkingHourManage,
            this.tsmiWorksheetManage,
            this.tsmiHourDataManage,
            this.tsmiUser});
			this.tsmiManage.Name = "tsmiManage";
			this.tsmiManage.Size = new System.Drawing.Size(41, 20);
			this.tsmiManage.Text = "管理";
			this.tsmiManage.Visible = false;
			// 
			// tsmiProductManage
			// 
			this.tsmiProductManage.BackColor = System.Drawing.SystemColors.Control;
			this.tsmiProductManage.Name = "tsmiProductManage";
			this.tsmiProductManage.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
			this.tsmiProductManage.Size = new System.Drawing.Size(206, 22);
			this.tsmiProductManage.Text = "產品管理";
			this.tsmiProductManage.Click += new System.EventHandler(this.tsmiProductManage_Click);
			// 
			// tsmiLineMangage
			// 
			this.tsmiLineMangage.Name = "tsmiLineMangage";
			this.tsmiLineMangage.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
			this.tsmiLineMangage.Size = new System.Drawing.Size(206, 22);
			this.tsmiLineMangage.Text = "產線管理";
			this.tsmiLineMangage.Click += new System.EventHandler(this.tsmiLineMangage_Click);
			// 
			// tsmiLaborManage
			// 
			this.tsmiLaborManage.Name = "tsmiLaborManage";
			this.tsmiLaborManage.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.tsmiLaborManage.Size = new System.Drawing.Size(206, 22);
			this.tsmiLaborManage.Text = "員工管理";
			this.tsmiLaborManage.Click += new System.EventHandler(this.tsmiLaborManage_Click);
			// 
			// tsmiNonProduceForm
			// 
			this.tsmiNonProduceForm.Name = "tsmiNonProduceForm";
			this.tsmiNonProduceForm.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.tsmiNonProduceForm.Size = new System.Drawing.Size(206, 22);
			this.tsmiNonProduceForm.Text = "非生產項目管理";
			this.tsmiNonProduceForm.Click += new System.EventHandler(this.tsmiNonProduceForm_Click);
			// 
			// tsmiQualityItem
			// 
			this.tsmiQualityItem.Name = "tsmiQualityItem";
			this.tsmiQualityItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
			this.tsmiQualityItem.Size = new System.Drawing.Size(206, 22);
			this.tsmiQualityItem.Text = "品質原因管理";
			this.tsmiQualityItem.Visible = false;
			this.tsmiQualityItem.Click += new System.EventHandler(this.tsmiQualityItem_Click);
			// 
			// tsmiWorkingHourManage
			// 
			this.tsmiWorkingHourManage.Name = "tsmiWorkingHourManage";
			this.tsmiWorkingHourManage.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
			this.tsmiWorkingHourManage.Size = new System.Drawing.Size(206, 22);
			this.tsmiWorkingHourManage.Text = "每月工作時數管理";
			this.tsmiWorkingHourManage.Click += new System.EventHandler(this.tsmiWorkingHourManage_Click);
			// 
			// tsmiWorksheetManage
			// 
			this.tsmiWorksheetManage.Name = "tsmiWorksheetManage";
			this.tsmiWorksheetManage.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.tsmiWorksheetManage.Size = new System.Drawing.Size(206, 22);
			this.tsmiWorksheetManage.Text = "工作單管理";
			this.tsmiWorksheetManage.Click += new System.EventHandler(this.tsmiWorksheetManage_Click);
			// 
			// tsmiHourDataManage
			// 
			this.tsmiHourDataManage.Name = "tsmiHourDataManage";
			this.tsmiHourDataManage.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
			this.tsmiHourDataManage.Size = new System.Drawing.Size(206, 22);
			this.tsmiHourDataManage.Text = "工時資料管理";
			this.tsmiHourDataManage.Click += new System.EventHandler(this.tsmiHourDataManage_Click);
			// 
			// tsmiUser
			// 
			this.tsmiUser.Name = "tsmiUser";
			this.tsmiUser.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
			this.tsmiUser.Size = new System.Drawing.Size(206, 22);
			this.tsmiUser.Text = "使用者管理";
			this.tsmiUser.Click += new System.EventHandler(this.tsmiUser_Click);
			// 
			// tsmiQuality
			// 
			this.tsmiQuality.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiInspectList,
            this.tsmiInspect,
            this.tsmiInspectDel});
			this.tsmiQuality.Name = "tsmiQuality";
			this.tsmiQuality.Size = new System.Drawing.Size(65, 20);
			this.tsmiQuality.Text = "產品檢驗";
			// 
			// tsmiInspectList
			// 
			this.tsmiInspectList.Name = "tsmiInspectList";
			this.tsmiInspectList.Size = new System.Drawing.Size(166, 22);
			this.tsmiInspectList.Text = "待驗品清單";
			this.tsmiInspectList.Visible = false;
			this.tsmiInspectList.Click += new System.EventHandler(this.tsmiInspectList_Click);
			// 
			// tsmiInspect
			// 
			this.tsmiInspect.Name = "tsmiInspect";
			this.tsmiInspect.Size = new System.Drawing.Size(166, 22);
			this.tsmiInspect.Text = "產品待驗登記";
			this.tsmiInspect.Click += new System.EventHandler(this.tsmiInspect_Click);
			// 
			// tsmiInspectDel
			// 
			this.tsmiInspectDel.Name = "tsmiInspectDel";
			this.tsmiInspectDel.Size = new System.Drawing.Size(166, 22);
			this.tsmiInspectDel.Text = "已完成品再驗登記";
			this.tsmiInspectDel.Click += new System.EventHandler(this.tsmiInspectDel_Click);
			// 
			// tsmiWorksheet
			// 
			this.tsmiWorksheet.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNewWorksheet,
            this.tsmiWorksheetSearch});
			this.tsmiWorksheet.Name = "tsmiWorksheet";
			this.tsmiWorksheet.Size = new System.Drawing.Size(53, 20);
			this.tsmiWorksheet.Text = "工作單";
			// 
			// tsmiNewWorksheet
			// 
			this.tsmiNewWorksheet.Name = "tsmiNewWorksheet";
			this.tsmiNewWorksheet.Size = new System.Drawing.Size(94, 22);
			this.tsmiNewWorksheet.Text = "新增";
			this.tsmiNewWorksheet.Click += new System.EventHandler(this.tsmiNewWorksheet_Click);
			// 
			// tsmiWorksheetSearch
			// 
			this.tsmiWorksheetSearch.Name = "tsmiWorksheetSearch";
			this.tsmiWorksheetSearch.Size = new System.Drawing.Size(94, 22);
			this.tsmiWorksheetSearch.Text = "查詢";
			this.tsmiWorksheetSearch.Click += new System.EventHandler(this.tsmiWorksheetSearch_Click);
			// 
			// tsmiDataFill
			// 
			this.tsmiDataFill.Name = "tsmiDataFill";
			this.tsmiDataFill.Size = new System.Drawing.Size(89, 20);
			this.tsmiDataFill.Text = "工時資料登記";
			this.tsmiDataFill.Click += new System.EventHandler(this.tsmiHourDataFill_Click);
			// 
			// tsmiReport
			// 
			this.tsmiReport.Name = "tsmiReport";
			this.tsmiReport.Size = new System.Drawing.Size(65, 20);
			this.tsmiReport.Text = "輸出報表";
			this.tsmiReport.Click += new System.EventHandler(this.tsmiReport_Click);
			// 
			// tsmiSettings
			// 
			this.tsmiSettings.Name = "tsmiSettings";
			this.tsmiSettings.Size = new System.Drawing.Size(41, 20);
			this.tsmiSettings.Text = "設定";
			this.tsmiSettings.Visible = false;
			this.tsmiSettings.Click += new System.EventHandler(this.tsmiSettings_Click);
			// 
			// tsmiLogout
			// 
			this.tsmiLogout.Name = "tsmiLogout";
			this.tsmiLogout.Size = new System.Drawing.Size(41, 20);
			this.tsmiLogout.Text = "登出";
			this.tsmiLogout.Click += new System.EventHandler(this.tsmiLogout_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(488, 381);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "SW生產工時管理系統";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.Shown += new System.EventHandler(this.MainForm_Shown);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiManage;
        private System.Windows.Forms.ToolStripMenuItem tsmiProductManage;
        private System.Windows.Forms.ToolStripMenuItem tsmiLineMangage;
        private System.Windows.Forms.ToolStripMenuItem tsmiLaborManage;
        private System.Windows.Forms.ToolStripMenuItem tsmiNonProduceForm;
        private System.Windows.Forms.ToolStripMenuItem tsmiWorkingHourManage;
        private System.Windows.Forms.ToolStripMenuItem tsmiWorksheet;
        private System.Windows.Forms.ToolStripMenuItem tsmiWorksheetManage;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewWorksheet;
        private System.Windows.Forms.ToolStripMenuItem tsmiWorksheetSearch;
        private System.Windows.Forms.ToolStripMenuItem tsmiDataFill;
        private System.Windows.Forms.ToolStripMenuItem tsmiHourDataManage;
        private System.Windows.Forms.ToolStripMenuItem tsmiSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmiLogout;
        private System.Windows.Forms.ToolStripMenuItem tsmiReport;
		private System.Windows.Forms.ToolStripMenuItem tsmiQualityItem;
		private System.Windows.Forms.ToolStripMenuItem tsmiUser;
		private System.Windows.Forms.ToolStripMenuItem tsmiQuality;
		private System.Windows.Forms.ToolStripMenuItem tsmiInspectList;
		private System.Windows.Forms.ToolStripMenuItem tsmiInspectDel;
		private System.Windows.Forms.ToolStripMenuItem tsmiInspect;
    }
}

