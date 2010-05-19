namespace Mong
{
    partial class EditWorksheetForm
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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
			this.bsWorksheetPart = new System.Windows.Forms.BindingSource(this.components);
			this.dgvPart = new System.Windows.Forms.DataGridView();
			this.col系列編號 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col系列代號 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col品號2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col產線 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.bsPart = new System.Windows.Forms.BindingSource(this.components);
			this.cbxSeries = new System.Windows.Forms.ComboBox();
			this.bsSeriesCbx = new System.Windows.Forms.BindingSource(this.components);
			this.cbxSeriesName = new System.Windows.Forms.ComboBox();
			this.btnAddPart = new System.Windows.Forms.Button();
			this.tbxPartNumber = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.btnDelWorksheet = new System.Windows.Forms.Button();
			this.btnAddWorksheet = new System.Windows.Forms.Button();
			this.btnStoreWorksheet = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.ckbEnd = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.dtpEnd = new System.Windows.Forms.DateTimePicker();
			this.tbxWorksheetNumber = new System.Windows.Forms.TextBox();
			this.dgvWorksheetPart = new System.Windows.Forms.DataGridView();
			this.dtpBegin = new System.Windows.Forms.DateTimePicker();
			this.bsWorksheet = new System.Windows.Forms.BindingSource(this.components);
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.lbStroeTip = new System.Windows.Forms.Label();
			this.col編號 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col品號 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col數量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col客戶 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col客戶需貨日 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col預計完成日 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col實際完成日 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.bsWorksheetPart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvPart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bsPart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bsSeriesCbx)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvWorksheetPart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bsWorksheet)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvPart
			// 
			this.dgvPart.AllowUserToAddRows = false;
			this.dgvPart.AllowUserToDeleteRows = false;
			this.dgvPart.AllowUserToResizeRows = false;
			this.dgvPart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvPart.AutoGenerateColumns = false;
			this.dgvPart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvPart.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.dgvPart.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
			this.dgvPart.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvPart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvPart.ColumnHeadersHeight = 20;
			this.dgvPart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dgvPart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col系列編號,
            this.col系列代號,
            this.col品號2,
            this.col產線});
			this.dgvPart.DataSource = this.bsPart;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
			dataGridViewCellStyle2.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvPart.DefaultCellStyle = dataGridViewCellStyle2;
			this.dgvPart.EnableHeadersVisualStyles = false;
			this.dgvPart.GridColor = System.Drawing.Color.LightGray;
			this.dgvPart.Location = new System.Drawing.Point(5, 47);
			this.dgvPart.Name = "dgvPart";
			this.dgvPart.ReadOnly = true;
			this.dgvPart.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.SteelBlue;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvPart.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dgvPart.RowHeadersVisible = false;
			this.dgvPart.RowHeadersWidth = 20;
			this.dgvPart.RowTemplate.Height = 20;
			this.dgvPart.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvPart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvPart.Size = new System.Drawing.Size(242, 282);
			this.dgvPart.TabIndex = 19;
			this.dgvPart.SelectionChanged += new System.EventHandler(this.dgvPart_SelectionChanged);
			// 
			// col系列編號
			// 
			this.col系列編號.DataPropertyName = "系列編號";
			this.col系列編號.HeaderText = "編號";
			this.col系列編號.Name = "col系列編號";
			this.col系列編號.ReadOnly = true;
			this.col系列編號.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.col系列編號.Width = 60;
			// 
			// col系列代號
			// 
			this.col系列代號.DataPropertyName = "系列代號";
			this.col系列代號.HeaderText = "系列";
			this.col系列代號.Name = "col系列代號";
			this.col系列代號.ReadOnly = true;
			this.col系列代號.Width = 60;
			// 
			// col品號2
			// 
			this.col品號2.DataPropertyName = "品號";
			this.col品號2.HeaderText = "品號";
			this.col品號2.Name = "col品號2";
			this.col品號2.ReadOnly = true;
			this.col品號2.Width = 60;
			// 
			// col產線
			// 
			this.col產線.DataPropertyName = "產線";
			this.col產線.HeaderText = "產線";
			this.col產線.Name = "col產線";
			this.col產線.ReadOnly = true;
			this.col產線.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.col產線.Width = 60;
			// 
			// cbxSeries
			// 
			this.cbxSeries.DataSource = this.bsSeriesCbx;
			this.cbxSeries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxSeries.FormattingEnabled = true;
			this.cbxSeries.Location = new System.Drawing.Point(5, 21);
			this.cbxSeries.Name = "cbxSeries";
			this.cbxSeries.Size = new System.Drawing.Size(86, 20);
			this.cbxSeries.TabIndex = 20;
			this.cbxSeries.SelectedIndexChanged += new System.EventHandler(this.cbxSeries_SelectedIndexChanged);
			// 
			// cbxSeriesName
			// 
			this.cbxSeriesName.DataSource = this.bsSeriesCbx;
			this.cbxSeriesName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxSeriesName.FormattingEnabled = true;
			this.cbxSeriesName.Location = new System.Drawing.Point(97, 21);
			this.cbxSeriesName.Name = "cbxSeriesName";
			this.cbxSeriesName.Size = new System.Drawing.Size(150, 20);
			this.cbxSeriesName.TabIndex = 21;
			this.cbxSeriesName.SelectedIndexChanged += new System.EventHandler(this.cbxSeries_SelectedIndexChanged);
			// 
			// btnAddPart
			// 
			this.btnAddPart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddPart.Location = new System.Drawing.Point(160, 349);
			this.btnAddPart.Name = "btnAddPart";
			this.btnAddPart.Size = new System.Drawing.Size(87, 25);
			this.btnAddPart.TabIndex = 22;
			this.btnAddPart.Text = "新增至工作單";
			this.toolTip1.SetToolTip(this.btnAddPart, "將選擇品號加入工作單");
			this.btnAddPart.UseVisualStyleBackColor = true;
			this.btnAddPart.Click += new System.EventHandler(this.btnAddPart_Click);
			// 
			// tbxPartNumber
			// 
			this.tbxPartNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tbxPartNumber.Location = new System.Drawing.Point(6, 350);
			this.tbxPartNumber.Name = "tbxPartNumber";
			this.tbxPartNumber.Size = new System.Drawing.Size(149, 22);
			this.tbxPartNumber.TabIndex = 23;
			this.tbxPartNumber.Validated += new System.EventHandler(this.tbxPartNumber_Validated);
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.dgvPart);
			this.groupBox2.Controls.Add(this.cbxSeriesName);
			this.groupBox2.Controls.Add(this.tbxPartNumber);
			this.groupBox2.Controls.Add(this.cbxSeries);
			this.groupBox2.Controls.Add(this.btnAddPart);
			this.groupBox2.Location = new System.Drawing.Point(3, 3);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(254, 382);
			this.groupBox2.TabIndex = 25;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "產品品號";
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 334);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(197, 12);
			this.label6.TabIndex = 27;
			this.label6.Text = "從上方清單選取品號或自行輸入品號";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(5, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(185, 12);
			this.label5.TabIndex = 26;
			this.label5.Text = "從左邊選擇產品品號加入至工作單";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.Location = new System.Drawing.Point(4, 22);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
			this.splitContainer1.Size = new System.Drawing.Size(787, 390);
			this.splitContainer1.SplitterDistance = 259;
			this.splitContainer1.TabIndex = 27;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.flowLayoutPanel1);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.ckbEnd);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.dtpEnd);
			this.groupBox1.Controls.Add(this.tbxWorksheetNumber);
			this.groupBox1.Controls.Add(this.dgvWorksheetPart);
			this.groupBox1.Controls.Add(this.dtpBegin);
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(515, 382);
			this.groupBox1.TabIndex = 24;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "工作單內容";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(6, 70);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(261, 12);
			this.label7.TabIndex = 41;
			this.label7.Text = "新增品號: 從左方選取品號，點選\"新增至工作單\"";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(6, 85);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(259, 12);
			this.label10.TabIndex = 40;
			this.label10.Text = "刪除品號:  選取要刪除的品號列，按Delete鍵刪除";
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.flowLayoutPanel1.Controls.Add(this.btnDelWorksheet);
			this.flowLayoutPanel1.Controls.Add(this.btnAddWorksheet);
			this.flowLayoutPanel1.Controls.Add(this.btnStoreWorksheet);
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(348, 349);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(162, 30);
			this.flowLayoutPanel1.TabIndex = 19;
			// 
			// btnDelWorksheet
			// 
			this.btnDelWorksheet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDelWorksheet.Location = new System.Drawing.Point(112, 3);
			this.btnDelWorksheet.Name = "btnDelWorksheet";
			this.btnDelWorksheet.Size = new System.Drawing.Size(47, 23);
			this.btnDelWorksheet.TabIndex = 2;
			this.btnDelWorksheet.Text = "刪除";
			this.toolTip1.SetToolTip(this.btnDelWorksheet, "刪除此筆工作單");
			this.btnDelWorksheet.UseVisualStyleBackColor = true;
			this.btnDelWorksheet.Click += new System.EventHandler(this.btnDelWorksheet_Click);
			// 
			// btnAddWorksheet
			// 
			this.btnAddWorksheet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddWorksheet.Location = new System.Drawing.Point(59, 3);
			this.btnAddWorksheet.Name = "btnAddWorksheet";
			this.btnAddWorksheet.Size = new System.Drawing.Size(47, 23);
			this.btnAddWorksheet.TabIndex = 1;
			this.btnAddWorksheet.Text = "新增";
			this.toolTip1.SetToolTip(this.btnAddWorksheet, "新增工作單");
			this.btnAddWorksheet.UseVisualStyleBackColor = true;
			this.btnAddWorksheet.Click += new System.EventHandler(this.btnAddWorksheet_Click);
			// 
			// btnStoreWorksheet
			// 
			this.btnStoreWorksheet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnStoreWorksheet.Location = new System.Drawing.Point(6, 3);
			this.btnStoreWorksheet.Name = "btnStoreWorksheet";
			this.btnStoreWorksheet.Size = new System.Drawing.Size(47, 23);
			this.btnStoreWorksheet.TabIndex = 0;
			this.btnStoreWorksheet.Text = "儲存";
			this.toolTip1.SetToolTip(this.btnStoreWorksheet, "儲存工作單");
			this.btnStoreWorksheet.UseVisualStyleBackColor = true;
			this.btnStoreWorksheet.Click += new System.EventHandler(this.btnStoreWorksheet_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(18, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 12);
			this.label1.TabIndex = 4;
			this.label1.Text = "工作單號";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(18, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 12);
			this.label3.TabIndex = 12;
			this.label3.Text = "單據日期";
			// 
			// ckbEnd
			// 
			this.ckbEnd.AutoSize = true;
			this.ckbEnd.Enabled = false;
			this.ckbEnd.Location = new System.Drawing.Point(289, 47);
			this.ckbEnd.Name = "ckbEnd";
			this.ckbEnd.Size = new System.Drawing.Size(15, 14);
			this.ckbEnd.TabIndex = 18;
			this.toolTip1.SetToolTip(this.ckbEnd, "勾選以設定實際完成日");
			this.ckbEnd.UseVisualStyleBackColor = true;
			this.ckbEnd.CheckedChanged += new System.EventHandler(this.ckbEnd_CheckedChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(218, 48);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(65, 12);
			this.label4.TabIndex = 13;
			this.label4.Text = "實際完成日";
			// 
			// dtpEnd
			// 
			this.dtpEnd.Enabled = false;
			this.dtpEnd.Location = new System.Drawing.Point(307, 43);
			this.dtpEnd.Name = "dtpEnd";
			this.dtpEnd.Size = new System.Drawing.Size(117, 22);
			this.dtpEnd.TabIndex = 17;
			// 
			// tbxWorksheetNumber
			// 
			this.tbxWorksheetNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tbxWorksheetNumber.Location = new System.Drawing.Point(77, 15);
			this.tbxWorksheetNumber.Name = "tbxWorksheetNumber";
			this.tbxWorksheetNumber.Size = new System.Drawing.Size(432, 22);
			this.tbxWorksheetNumber.TabIndex = 0;
			this.tbxWorksheetNumber.Validated += new System.EventHandler(this.tbxWorksheetNumber_Validated);
			// 
			// dgvWorksheetPart
			// 
			this.dgvWorksheetPart.AllowUserToAddRows = false;
			this.dgvWorksheetPart.AllowUserToResizeRows = false;
			this.dgvWorksheetPart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvWorksheetPart.AutoGenerateColumns = false;
			this.dgvWorksheetPart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvWorksheetPart.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
			this.dgvWorksheetPart.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.Color.SteelBlue;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvWorksheetPart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.dgvWorksheetPart.ColumnHeadersHeight = 20;
			this.dgvWorksheetPart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dgvWorksheetPart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col編號,
            this.col品號,
            this.col數量,
            this.col客戶,
            this.col客戶需貨日,
            this.col預計完成日,
            this.col實際完成日});
			this.dgvWorksheetPart.DataSource = this.bsWorksheetPart;
			dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle11.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvWorksheetPart.DefaultCellStyle = dataGridViewCellStyle11;
			this.dgvWorksheetPart.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.dgvWorksheetPart.EnableHeadersVisualStyles = false;
			this.dgvWorksheetPart.GridColor = System.Drawing.Color.Gainsboro;
			this.dgvWorksheetPart.Location = new System.Drawing.Point(8, 100);
			this.dgvWorksheetPart.Name = "dgvWorksheetPart";
			this.dgvWorksheetPart.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle12.BackColor = System.Drawing.Color.CornflowerBlue;
			dataGridViewCellStyle12.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			dataGridViewCellStyle12.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvWorksheetPart.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
			this.dgvWorksheetPart.RowHeadersVisible = false;
			this.dgvWorksheetPart.RowHeadersWidth = 20;
			this.dgvWorksheetPart.RowTemplate.Height = 20;
			this.dgvWorksheetPart.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvWorksheetPart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvWorksheetPart.Size = new System.Drawing.Size(501, 247);
			this.dgvWorksheetPart.TabIndex = 15;
			this.dgvWorksheetPart.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvWorksheetPart_UserDeletingRow);
			this.dgvWorksheetPart.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvWorksheetPart_CellBeginEdit);
			this.dgvWorksheetPart.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvWorksheetPart_DataError);
			// 
			// dtpBegin
			// 
			this.dtpBegin.Location = new System.Drawing.Point(77, 43);
			this.dtpBegin.Name = "dtpBegin";
			this.dtpBegin.Size = new System.Drawing.Size(128, 22);
			this.dtpBegin.TabIndex = 2;
			// 
			// lbStroeTip
			// 
			this.lbStroeTip.AutoSize = true;
			this.lbStroeTip.Location = new System.Drawing.Point(268, 7);
			this.lbStroeTip.Name = "lbStroeTip";
			this.lbStroeTip.Size = new System.Drawing.Size(113, 12);
			this.lbStroeTip.TabIndex = 27;
			this.lbStroeTip.Text = "修改完畢請點選儲存";
			// 
			// col編號
			// 
			this.col編號.DataPropertyName = "編號";
			dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
			this.col編號.DefaultCellStyle = dataGridViewCellStyle5;
			this.col編號.HeaderText = "序號";
			this.col編號.Name = "col編號";
			this.col編號.ReadOnly = true;
			this.col編號.Width = 50;
			// 
			// col品號
			// 
			this.col品號.DataPropertyName = "品號";
			dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
			dataGridViewCellStyle6.NullValue = " ";
			this.col品號.DefaultCellStyle = dataGridViewCellStyle6;
			this.col品號.FillWeight = 1F;
			this.col品號.HeaderText = "品號";
			this.col品號.Name = "col品號";
			this.col品號.ReadOnly = true;
			// 
			// col數量
			// 
			this.col數量.DataPropertyName = "數量";
			dataGridViewCellStyle7.Format = "0.#";
			this.col數量.DefaultCellStyle = dataGridViewCellStyle7;
			this.col數量.FillWeight = 1F;
			this.col數量.HeaderText = "數量(PCS)";
			this.col數量.Name = "col數量";
			this.col數量.Width = 70;
			// 
			// col客戶
			// 
			this.col客戶.DataPropertyName = "客戶";
			this.col客戶.HeaderText = "客戶";
			this.col客戶.Name = "col客戶";
			// 
			// col客戶需貨日
			// 
			this.col客戶需貨日.DataPropertyName = "客戶需貨日";
			dataGridViewCellStyle8.Format = "d";
			dataGridViewCellStyle8.NullValue = null;
			this.col客戶需貨日.DefaultCellStyle = dataGridViewCellStyle8;
			this.col客戶需貨日.FillWeight = 1F;
			this.col客戶需貨日.HeaderText = "客戶需貨日";
			this.col客戶需貨日.Name = "col客戶需貨日";
			this.col客戶需貨日.Width = 80;
			// 
			// col預計完成日
			// 
			this.col預計完成日.DataPropertyName = "預計完成日";
			dataGridViewCellStyle9.Format = "d";
			this.col預計完成日.DefaultCellStyle = dataGridViewCellStyle9;
			this.col預計完成日.FillWeight = 1F;
			this.col預計完成日.HeaderText = "預計完成日";
			this.col預計完成日.Name = "col預計完成日";
			this.col預計完成日.Width = 80;
			// 
			// col實際完成日
			// 
			this.col實際完成日.DataPropertyName = "實際完成日";
			dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
			dataGridViewCellStyle10.Format = "d";
			this.col實際完成日.DefaultCellStyle = dataGridViewCellStyle10;
			this.col實際完成日.FillWeight = 1F;
			this.col實際完成日.HeaderText = "實際完成日";
			this.col實際完成日.Name = "col實際完成日";
			this.col實際完成日.ReadOnly = true;
			this.col實際完成日.Width = 80;
			// 
			// EditWorksheetForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(791, 411);
			this.Controls.Add(this.lbStroeTip);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.label5);
			this.MinimumSize = new System.Drawing.Size(716, 445);
			this.Name = "EditWorksheetForm";
			this.ShowIcon = false;
			this.Text = "工作單編輯";
			this.Load += new System.EventHandler(this.EditWorksheetForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.bsWorksheetPart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvPart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bsPart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bsSeriesCbx)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvWorksheetPart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bsWorksheet)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPart;
        private System.Windows.Forms.ComboBox cbxSeries;
        private System.Windows.Forms.BindingSource bsSeriesCbx;
        private System.Windows.Forms.ComboBox cbxSeriesName;
        private System.Windows.Forms.BindingSource bsPart;
        private System.Windows.Forms.Button btnAddPart;
        private System.Windows.Forms.BindingSource bsWorksheetPart;
        private System.Windows.Forms.DataGridViewTextBoxColumn col系列編號;
        private System.Windows.Forms.DataGridViewTextBoxColumn col系列代號;
        private System.Windows.Forms.DataGridViewTextBoxColumn col品號2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col產線;
        private System.Windows.Forms.TextBox tbxPartNumber;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource bsWorksheet;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lbStroeTip;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnDelWorksheet;
        private System.Windows.Forms.Button btnAddWorksheet;
        private System.Windows.Forms.Button btnStoreWorksheet;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ckbEnd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpEnd;
		private System.Windows.Forms.TextBox tbxWorksheetNumber;
        private System.Windows.Forms.DataGridView dgvWorksheetPart;
		private System.Windows.Forms.DateTimePicker dtpBegin;
		private System.Windows.Forms.DataGridViewTextBoxColumn col編號;
		private System.Windows.Forms.DataGridViewTextBoxColumn col品號;
		private System.Windows.Forms.DataGridViewTextBoxColumn col數量;
		private System.Windows.Forms.DataGridViewTextBoxColumn col客戶;
		private System.Windows.Forms.DataGridViewTextBoxColumn col客戶需貨日;
		private System.Windows.Forms.DataGridViewTextBoxColumn col預計完成日;
		private System.Windows.Forms.DataGridViewTextBoxColumn col實際完成日;
    }
}