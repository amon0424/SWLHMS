namespace Mong
{
    partial class ImportProductForm
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.wizard1 = new Gui.Wizard.Wizard();
			this.wizardPage3 = new Gui.Wizard.WizardPage();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.btnMove = new System.Windows.Forms.Button();
			this.dgvDstCol = new System.Windows.Forms.DataGridView();
			this.col目的名稱 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col來源名稱 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col來源索引 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgvSrcCol = new System.Windows.Forms.DataGridView();
			this.colSrcColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colSrcColIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.header3 = new Gui.Wizard.Header();
			this.wizardPage2 = new Gui.Wizard.WizardPage();
			this.cbxWorksheets = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.header2 = new Gui.Wizard.Header();
			this.wizardPage1 = new Gui.Wizard.WizardPage();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.tbxSrcFile = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.header1 = new Gui.Wizard.Header();
			this.wizardPage5 = new Gui.Wizard.WizardPage();
			this.tbxImportReport = new System.Windows.Forms.TextBox();
			this.header5 = new Gui.Wizard.Header();
			this.wizardPage4 = new Gui.Wizard.WizardPage();
			this.lbUpdateMsg = new System.Windows.Forms.Label();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.header4 = new Gui.Wizard.Header();
			this.wizard1.SuspendLayout();
			this.wizardPage3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvDstCol)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvSrcCol)).BeginInit();
			this.wizardPage2.SuspendLayout();
			this.wizardPage1.SuspendLayout();
			this.wizardPage5.SuspendLayout();
			this.wizardPage4.SuspendLayout();
			this.SuspendLayout();
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.Filter = "Excel檔(*.xls)|*.xls";
			// 
			// wizard1
			// 
			this.wizard1.Controls.Add(this.wizardPage3);
			this.wizard1.Controls.Add(this.wizardPage4);
			this.wizard1.Controls.Add(this.wizardPage2);
			this.wizard1.Controls.Add(this.wizardPage1);
			this.wizard1.Controls.Add(this.wizardPage5);
			this.wizard1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.wizard1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.wizard1.Location = new System.Drawing.Point(0, 0);
			this.wizard1.Name = "wizard1";
			this.wizard1.Pages.AddRange(new Gui.Wizard.WizardPage[] {
            this.wizardPage1,
            this.wizardPage2,
            this.wizardPage3,
            this.wizardPage4,
            this.wizardPage5});
			this.wizard1.Size = new System.Drawing.Size(458, 329);
			this.wizard1.TabIndex = 0;
			this.wizard1.Load += new System.EventHandler(this.wizard1_Load);
			this.wizard1.CloseFromCancel += new System.ComponentModel.CancelEventHandler(this.wizard1_CloseFromCancel);
			// 
			// wizardPage3
			// 
			this.wizardPage3.Controls.Add(this.label5);
			this.wizardPage3.Controls.Add(this.label4);
			this.wizardPage3.Controls.Add(this.btnMove);
			this.wizardPage3.Controls.Add(this.dgvDstCol);
			this.wizardPage3.Controls.Add(this.dgvSrcCol);
			this.wizardPage3.Controls.Add(this.header3);
			this.wizardPage3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.wizardPage3.IsFinishPage = false;
			this.wizardPage3.Location = new System.Drawing.Point(0, 0);
			this.wizardPage3.Name = "wizardPage3";
			this.wizardPage3.Size = new System.Drawing.Size(458, 281);
			this.wizardPage3.TabIndex = 3;
			this.wizardPage3.ShowFromNext += new System.EventHandler(this.wizardPage3_ShowFromNext);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(25, 69);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(411, 28);
			this.label5.TabIndex = 6;
			this.label5.Text = "若左邊並非該工作表中正確的欄位名稱時，請確認該工作表第一列是否包含了正確的欄位名稱";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(23, 265);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(413, 12);
			this.label4.TabIndex = 5;
			this.label4.Text = "點擊中央的按鈕可將左邊欄位移至右邊，也可以使用滑鼠將左邊欄位拉至右邊";
			// 
			// btnMove
			// 
			this.btnMove.Location = new System.Drawing.Point(213, 161);
			this.btnMove.Name = "btnMove";
			this.btnMove.Size = new System.Drawing.Size(32, 36);
			this.btnMove.TabIndex = 4;
			this.btnMove.Text = ">";
			this.btnMove.UseVisualStyleBackColor = true;
			this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
			// 
			// dgvDstCol
			// 
			this.dgvDstCol.AllowDrop = true;
			this.dgvDstCol.AllowUserToAddRows = false;
			this.dgvDstCol.AllowUserToDeleteRows = false;
			this.dgvDstCol.AllowUserToResizeRows = false;
			this.dgvDstCol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.dgvDstCol.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvDstCol.BackgroundColor = System.Drawing.Color.White;
			this.dgvDstCol.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvDstCol.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
			this.dgvDstCol.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvDstCol.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvDstCol.ColumnHeadersHeight = 17;
			this.dgvDstCol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dgvDstCol.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col目的名稱,
            this.col來源名稱,
            this.col來源索引});
			this.dgvDstCol.EnableHeadersVisualStyles = false;
			this.dgvDstCol.Location = new System.Drawing.Point(251, 98);
			this.dgvDstCol.Name = "dgvDstCol";
			this.dgvDstCol.ReadOnly = true;
			this.dgvDstCol.RowHeadersVisible = false;
			this.dgvDstCol.RowHeadersWidth = 40;
			this.dgvDstCol.RowTemplate.Height = 17;
			this.dgvDstCol.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvDstCol.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvDstCol.Size = new System.Drawing.Size(163, 162);
			this.dgvDstCol.TabIndex = 3;
			this.dgvDstCol.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDstCol_CellValueChanged);
			this.dgvDstCol.DragOver += new System.Windows.Forms.DragEventHandler(this.dgvDstCol_DragOver);
			this.dgvDstCol.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvDstCol_DragDrop);
			// 
			// col目的名稱
			// 
			this.col目的名稱.DataPropertyName = "名稱";
			this.col目的名稱.FillWeight = 70F;
			this.col目的名稱.HeaderText = "名稱";
			this.col目的名稱.Name = "col目的名稱";
			this.col目的名稱.ReadOnly = true;
			// 
			// col來源名稱
			// 
			this.col來源名稱.DataPropertyName = "來源";
			this.col來源名稱.HeaderText = "來源";
			this.col來源名稱.Name = "col來源名稱";
			this.col來源名稱.ReadOnly = true;
			// 
			// col來源索引
			// 
			this.col來源索引.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.col來源索引.DataPropertyName = "索引";
			this.col來源索引.FillWeight = 50F;
			this.col來源索引.HeaderText = "索引";
			this.col來源索引.Name = "col來源索引";
			this.col來源索引.ReadOnly = true;
			this.col來源索引.Visible = false;
			this.col來源索引.Width = 55;
			// 
			// dgvSrcCol
			// 
			this.dgvSrcCol.AllowUserToAddRows = false;
			this.dgvSrcCol.AllowUserToDeleteRows = false;
			this.dgvSrcCol.AllowUserToResizeRows = false;
			this.dgvSrcCol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.dgvSrcCol.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvSrcCol.BackgroundColor = System.Drawing.Color.White;
			this.dgvSrcCol.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvSrcCol.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
			this.dgvSrcCol.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvSrcCol.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dgvSrcCol.ColumnHeadersHeight = 17;
			this.dgvSrcCol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dgvSrcCol.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSrcColName,
            this.colSrcColIndex});
			this.dgvSrcCol.EnableHeadersVisualStyles = false;
			this.dgvSrcCol.Location = new System.Drawing.Point(44, 98);
			this.dgvSrcCol.Name = "dgvSrcCol";
			this.dgvSrcCol.ReadOnly = true;
			this.dgvSrcCol.RowHeadersVisible = false;
			this.dgvSrcCol.RowHeadersWidth = 40;
			this.dgvSrcCol.RowTemplate.Height = 17;
			this.dgvSrcCol.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvSrcCol.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvSrcCol.Size = new System.Drawing.Size(163, 162);
			this.dgvSrcCol.TabIndex = 2;
			this.dgvSrcCol.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgvSrcCol_MouseMove);
			// 
			// colSrcColName
			// 
			this.colSrcColName.DataPropertyName = "名稱";
			this.colSrcColName.HeaderText = "名稱";
			this.colSrcColName.Name = "colSrcColName";
			this.colSrcColName.ReadOnly = true;
			// 
			// colSrcColIndex
			// 
			this.colSrcColIndex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.colSrcColIndex.DataPropertyName = "索引";
			this.colSrcColIndex.FillWeight = 50F;
			this.colSrcColIndex.HeaderText = "索引";
			this.colSrcColIndex.Name = "colSrcColIndex";
			this.colSrcColIndex.ReadOnly = true;
			this.colSrcColIndex.Width = 55;
			// 
			// header3
			// 
			this.header3.BackColor = System.Drawing.SystemColors.Control;
			this.header3.CausesValidation = false;
			this.header3.Description = "右邊為匯入時所需的欄位，從右邊將對應的欄位選擇至左邊，並點選下一步開始進行匯入";
			this.header3.Dock = System.Windows.Forms.DockStyle.Top;
			this.header3.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.header3.Image = global::Mong.Properties.Resources._48;
			this.header3.Location = new System.Drawing.Point(0, 0);
			this.header3.Name = "header3";
			this.header3.Size = new System.Drawing.Size(458, 64);
			this.header3.TabIndex = 1;
			this.header3.Title = "設定欄位對應";
			// 
			// wizardPage2
			// 
			this.wizardPage2.Controls.Add(this.cbxWorksheets);
			this.wizardPage2.Controls.Add(this.label2);
			this.wizardPage2.Controls.Add(this.label3);
			this.wizardPage2.Controls.Add(this.header2);
			this.wizardPage2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.wizardPage2.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.wizardPage2.IsFinishPage = false;
			this.wizardPage2.Location = new System.Drawing.Point(0, 0);
			this.wizardPage2.Name = "wizardPage2";
			this.wizardPage2.Size = new System.Drawing.Size(458, 281);
			this.wizardPage2.TabIndex = 2;
			this.wizardPage2.ShowFromNext += new System.EventHandler(this.wizardPage2_ShowFromNext);
			// 
			// cbxWorksheets
			// 
			this.cbxWorksheets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxWorksheets.FormattingEnabled = true;
			this.cbxWorksheets.Location = new System.Drawing.Point(60, 109);
			this.cbxWorksheets.Name = "cbxWorksheets";
			this.cbxWorksheets.Size = new System.Drawing.Size(169, 20);
			this.cbxWorksheets.TabIndex = 2;
			this.cbxWorksheets.SelectedIndexChanged += new System.EventHandler(this.cbxWorksheets_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 113);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 12);
			this.label2.TabIndex = 1;
			this.label2.Text = "工作表:";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label3.Location = new System.Drawing.Point(12, 77);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(434, 36);
			this.label3.TabIndex = 3;
			this.label3.Text = "下方會列出你剛剛選取xls檔裡的工作表，請選取包含產品資料的工作表，並確定工作表中的第一列包含欄位名稱";
			// 
			// header2
			// 
			this.header2.BackColor = System.Drawing.SystemColors.Control;
			this.header2.CausesValidation = false;
			this.header2.Description = "選取包含產品資料的工作表(Worksheet)，並點選下一步繼續";
			this.header2.Dock = System.Windows.Forms.DockStyle.Top;
			this.header2.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.header2.Image = global::Mong.Properties.Resources._48;
			this.header2.Location = new System.Drawing.Point(0, 0);
			this.header2.Name = "header2";
			this.header2.Size = new System.Drawing.Size(458, 64);
			this.header2.TabIndex = 0;
			this.header2.Title = "選取工作表";
			// 
			// wizardPage1
			// 
			this.wizardPage1.Controls.Add(this.btnBrowse);
			this.wizardPage1.Controls.Add(this.tbxSrcFile);
			this.wizardPage1.Controls.Add(this.label1);
			this.wizardPage1.Controls.Add(this.header1);
			this.wizardPage1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.wizardPage1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.wizardPage1.IsFinishPage = false;
			this.wizardPage1.Location = new System.Drawing.Point(0, 0);
			this.wizardPage1.Name = "wizardPage1";
			this.wizardPage1.Size = new System.Drawing.Size(458, 281);
			this.wizardPage1.TabIndex = 1;
			// 
			// btnBrowse
			// 
			this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBrowse.Location = new System.Drawing.Point(368, 109);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(75, 23);
			this.btnBrowse.TabIndex = 3;
			this.btnBrowse.Text = "瀏覽";
			this.btnBrowse.UseVisualStyleBackColor = true;
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// tbxSrcFile
			// 
			this.tbxSrcFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tbxSrcFile.Location = new System.Drawing.Point(49, 82);
			this.tbxSrcFile.Name = "tbxSrcFile";
			this.tbxSrcFile.Size = new System.Drawing.Size(394, 22);
			this.tbxSrcFile.TabIndex = 2;
			this.tbxSrcFile.TextChanged += new System.EventHandler(this.tbxSrcFile_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 86);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 12);
			this.label1.TabIndex = 1;
			this.label1.Text = "檔案:";
			// 
			// header1
			// 
			this.header1.BackColor = System.Drawing.SystemColors.Control;
			this.header1.CausesValidation = false;
			this.header1.Description = "選取包含產品資料的xls檔";
			this.header1.Dock = System.Windows.Forms.DockStyle.Top;
			this.header1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.header1.Image = global::Mong.Properties.Resources._48;
			this.header1.Location = new System.Drawing.Point(0, 0);
			this.header1.Name = "header1";
			this.header1.Size = new System.Drawing.Size(458, 64);
			this.header1.TabIndex = 0;
			this.header1.Title = "選擇資料來源";
			// 
			// wizardPage5
			// 
			this.wizardPage5.Controls.Add(this.tbxImportReport);
			this.wizardPage5.Controls.Add(this.header5);
			this.wizardPage5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.wizardPage5.IsFinishPage = false;
			this.wizardPage5.Location = new System.Drawing.Point(0, 0);
			this.wizardPage5.Name = "wizardPage5";
			this.wizardPage5.Size = new System.Drawing.Size(458, 281);
			this.wizardPage5.TabIndex = 5;
			this.wizardPage5.ShowFromNext += new System.EventHandler(this.wizardPage5_ShowFromNext);
			// 
			// tbxImportReport
			// 
			this.tbxImportReport.Location = new System.Drawing.Point(12, 70);
			this.tbxImportReport.Multiline = true;
			this.tbxImportReport.Name = "tbxImportReport";
			this.tbxImportReport.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbxImportReport.Size = new System.Drawing.Size(434, 205);
			this.tbxImportReport.TabIndex = 4;
			// 
			// header5
			// 
			this.header5.BackColor = System.Drawing.SystemColors.Control;
			this.header5.CausesValidation = false;
			this.header5.Description = "";
			this.header5.Dock = System.Windows.Forms.DockStyle.Top;
			this.header5.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.header5.Image = global::Mong.Properties.Resources._48;
			this.header5.Location = new System.Drawing.Point(0, 0);
			this.header5.Name = "header5";
			this.header5.Size = new System.Drawing.Size(458, 64);
			this.header5.TabIndex = 3;
			this.header5.Title = "匯入報告";
			// 
			// wizardPage4
			// 
			this.wizardPage4.Controls.Add(this.lbUpdateMsg);
			this.wizardPage4.Controls.Add(this.progressBar1);
			this.wizardPage4.Controls.Add(this.header4);
			this.wizardPage4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.wizardPage4.IsFinishPage = false;
			this.wizardPage4.Location = new System.Drawing.Point(0, 0);
			this.wizardPage4.Name = "wizardPage4";
			this.wizardPage4.Size = new System.Drawing.Size(458, 281);
			this.wizardPage4.TabIndex = 4;
			this.wizardPage4.ShowFromNext += new System.EventHandler(this.wizardPage4_ShowFromNext);
			// 
			// lbUpdateMsg
			// 
			this.lbUpdateMsg.AutoSize = true;
			this.lbUpdateMsg.Location = new System.Drawing.Point(13, 100);
			this.lbUpdateMsg.Name = "lbUpdateMsg";
			this.lbUpdateMsg.Size = new System.Drawing.Size(0, 12);
			this.lbUpdateMsg.TabIndex = 4;
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(12, 70);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(434, 23);
			this.progressBar1.Step = 1;
			this.progressBar1.TabIndex = 3;
			// 
			// header4
			// 
			this.header4.BackColor = System.Drawing.SystemColors.Control;
			this.header4.CausesValidation = false;
			this.header4.Description = "執行匯入中，請稍候";
			this.header4.Dock = System.Windows.Forms.DockStyle.Top;
			this.header4.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.header4.Image = global::Mong.Properties.Resources._48;
			this.header4.Location = new System.Drawing.Point(0, 0);
			this.header4.Name = "header4";
			this.header4.Size = new System.Drawing.Size(458, 64);
			this.header4.TabIndex = 2;
			this.header4.Title = "開始匯入";
			// 
			// ImportProductForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(458, 329);
			this.Controls.Add(this.wizard1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ImportProductForm";
			this.ShowInTaskbar = false;
			this.Text = "匯入產品資料";
			this.Load += new System.EventHandler(this.ImportProductForm_Load);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImportLHForm_FormClosing);
			this.wizard1.ResumeLayout(false);
			this.wizardPage3.ResumeLayout(false);
			this.wizardPage3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvDstCol)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvSrcCol)).EndInit();
			this.wizardPage2.ResumeLayout(false);
			this.wizardPage2.PerformLayout();
			this.wizardPage1.ResumeLayout(false);
			this.wizardPage1.PerformLayout();
			this.wizardPage5.ResumeLayout(false);
			this.wizardPage5.PerformLayout();
			this.wizardPage4.ResumeLayout(false);
			this.wizardPage4.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private Gui.Wizard.Wizard wizard1;
        private Gui.Wizard.WizardPage wizardPage1;
        private Gui.Wizard.Header header1;
        private System.Windows.Forms.TextBox tbxSrcFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Gui.Wizard.WizardPage wizardPage2;
        private Gui.Wizard.Header header2;
        private System.Windows.Forms.ComboBox cbxWorksheets;
        private System.Windows.Forms.Label label2;
        private Gui.Wizard.WizardPage wizardPage3;
        private Gui.Wizard.Header header3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvSrcCol;
        private System.Windows.Forms.DataGridView dgvDstCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSrcColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSrcColIndex;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.Label label4;
        private Gui.Wizard.WizardPage wizardPage4;
        private Gui.Wizard.Header header4;
        private System.Windows.Forms.ProgressBar progressBar1;
        private Gui.Wizard.WizardPage wizardPage5;
        private System.Windows.Forms.Label lbUpdateMsg;
        private System.Windows.Forms.TextBox tbxImportReport;
        private Gui.Wizard.Header header5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn col目的名稱;
        private System.Windows.Forms.DataGridViewTextBoxColumn col來源名稱;
        private System.Windows.Forms.DataGridViewTextBoxColumn col來源索引;

    }
}