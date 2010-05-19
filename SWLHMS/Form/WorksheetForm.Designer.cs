namespace Mong
{
    partial class WorksheetForm
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.btnDelWorksheet = new System.Windows.Forms.Button();
			this.btnEditWorksheet = new System.Windows.Forms.Button();
			this.ckbEnd = new System.Windows.Forms.CheckBox();
			this.dtpEnd = new System.Windows.Forms.DateTimePicker();
			this.dtpBegin = new System.Windows.Forms.DateTimePicker();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.bsPart = new System.Windows.Forms.BindingSource(this.components);
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tbxWorksheetNumber = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.dgvWorksheet = new System.Windows.Forms.DataGridView();
			this.col單號 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col單據日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col實際完成日 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.bsWorksheet = new System.Windows.Forms.BindingSource(this.components);
			this.cbxDoneOrNot = new System.Windows.Forms.ComboBox();
			this.btnSearch = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			this.tbxCustomerNameS = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.tbxWorksheetNumberS = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.cbxBeginOrEnd = new System.Windows.Forms.ComboBox();
			this.dtpTo = new System.Windows.Forms.DateTimePicker();
			this.dtpFrom = new System.Windows.Forms.DateTimePicker();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.colWpId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col品號 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col數量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col客戶 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col客戶需貨日 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col預計完成日 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col完成日 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.groupBox1.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bsPart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvWorksheet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bsWorksheet)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.flowLayoutPanel1);
			this.groupBox1.Controls.Add(this.ckbEnd);
			this.groupBox1.Controls.Add(this.dtpEnd);
			this.groupBox1.Controls.Add(this.dtpBegin);
			this.groupBox1.Controls.Add(this.dataGridView1);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.tbxWorksheetNumber);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(3, 5);
			this.groupBox1.MinimumSize = new System.Drawing.Size(247, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(419, 264);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "工作單內容";
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.flowLayoutPanel1.Controls.Add(this.btnDelWorksheet);
			this.flowLayoutPanel1.Controls.Add(this.btnEditWorksheet);
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(299, 233);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(115, 28);
			this.flowLayoutPanel1.TabIndex = 19;
			// 
			// btnDelWorksheet
			// 
			this.btnDelWorksheet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDelWorksheet.Location = new System.Drawing.Point(65, 3);
			this.btnDelWorksheet.Name = "btnDelWorksheet";
			this.btnDelWorksheet.Size = new System.Drawing.Size(47, 23);
			this.btnDelWorksheet.TabIndex = 10;
			this.btnDelWorksheet.Text = "刪除";
			this.toolTip1.SetToolTip(this.btnDelWorksheet, "刪除此筆工作單");
			this.btnDelWorksheet.UseVisualStyleBackColor = true;
			this.btnDelWorksheet.Visible = false;
			this.btnDelWorksheet.Click += new System.EventHandler(this.btnDelWorksheet_Click);
			// 
			// btnEditWorksheet
			// 
			this.btnEditWorksheet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEditWorksheet.Location = new System.Drawing.Point(12, 3);
			this.btnEditWorksheet.Name = "btnEditWorksheet";
			this.btnEditWorksheet.Size = new System.Drawing.Size(47, 23);
			this.btnEditWorksheet.TabIndex = 8;
			this.btnEditWorksheet.Text = "編輯";
			this.toolTip1.SetToolTip(this.btnEditWorksheet, "編輯此筆工作單");
			this.btnEditWorksheet.UseVisualStyleBackColor = true;
			this.btnEditWorksheet.Click += new System.EventHandler(this.btnEditWorksheet_Click);
			// 
			// ckbEnd
			// 
			this.ckbEnd.AutoSize = true;
			this.ckbEnd.Enabled = false;
			this.ckbEnd.Location = new System.Drawing.Point(275, 49);
			this.ckbEnd.Name = "ckbEnd";
			this.ckbEnd.Size = new System.Drawing.Size(15, 14);
			this.ckbEnd.TabIndex = 18;
			this.toolTip1.SetToolTip(this.ckbEnd, "勾選代表已設定實際完成日");
			this.ckbEnd.UseVisualStyleBackColor = true;
			// 
			// dtpEnd
			// 
			this.dtpEnd.Enabled = false;
			this.dtpEnd.Location = new System.Drawing.Point(293, 45);
			this.dtpEnd.Name = "dtpEnd";
			this.dtpEnd.Size = new System.Drawing.Size(117, 22);
			this.dtpEnd.TabIndex = 17;
			// 
			// dtpBegin
			// 
			this.dtpBegin.Enabled = false;
			this.dtpBegin.Location = new System.Drawing.Point(68, 45);
			this.dtpBegin.Name = "dtpBegin";
			this.dtpBegin.Size = new System.Drawing.Size(128, 22);
			this.dtpBegin.TabIndex = 16;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToResizeRows = false;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.AutoGenerateColumns = false;
			this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridView1.ColumnHeadersHeight = 20;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colWpId,
            this.col品號,
            this.col數量,
            this.col客戶,
            this.col客戶需貨日,
            this.col預計完成日,
            this.col完成日});
			this.dataGridView1.DataSource = this.bsPart;
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
			dataGridViewCellStyle5.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
			this.dataGridView1.EnableHeadersVisualStyles = false;
			this.dataGridView1.GridColor = System.Drawing.Color.LightGray;
			this.dataGridView1.Location = new System.Drawing.Point(8, 73);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.BackColor = System.Drawing.Color.CornflowerBlue;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowHeadersWidth = 20;
			this.dataGridView1.RowTemplate.Height = 20;
			this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(402, 156);
			this.dataGridView1.TabIndex = 15;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(204, 49);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(65, 12);
			this.label4.TabIndex = 13;
			this.label4.Text = "實際完成日";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 50);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 12);
			this.label3.TabIndex = 12;
			this.label3.Text = "單據日期";
			// 
			// tbxWorksheetNumber
			// 
			this.tbxWorksheetNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tbxWorksheetNumber.Location = new System.Drawing.Point(68, 17);
			this.tbxWorksheetNumber.Name = "tbxWorksheetNumber";
			this.tbxWorksheetNumber.ReadOnly = true;
			this.tbxWorksheetNumber.Size = new System.Drawing.Size(343, 22);
			this.tbxWorksheetNumber.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 12);
			this.label1.TabIndex = 4;
			this.label1.Text = "工作單號";
			// 
			// dgvWorksheet
			// 
			this.dgvWorksheet.AllowUserToAddRows = false;
			this.dgvWorksheet.AllowUserToDeleteRows = false;
			this.dgvWorksheet.AllowUserToResizeRows = false;
			this.dgvWorksheet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvWorksheet.AutoGenerateColumns = false;
			this.dgvWorksheet.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.dgvWorksheet.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle7.BackColor = System.Drawing.Color.SteelBlue;
			dataGridViewCellStyle7.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvWorksheet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
			this.dgvWorksheet.ColumnHeadersHeight = 20;
			this.dgvWorksheet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dgvWorksheet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col單號,
            this.col單據日期,
            this.col實際完成日});
			this.dgvWorksheet.DataSource = this.bsWorksheet;
			dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
			dataGridViewCellStyle10.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvWorksheet.DefaultCellStyle = dataGridViewCellStyle10;
			this.dgvWorksheet.EnableHeadersVisualStyles = false;
			this.dgvWorksheet.GridColor = System.Drawing.Color.LightGray;
			this.dgvWorksheet.Location = new System.Drawing.Point(3, 3);
			this.dgvWorksheet.Name = "dgvWorksheet";
			this.dgvWorksheet.ReadOnly = true;
			this.dgvWorksheet.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle11.BackColor = System.Drawing.Color.CornflowerBlue;
			dataGridViewCellStyle11.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvWorksheet.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
			this.dgvWorksheet.RowHeadersVisible = false;
			this.dgvWorksheet.RowHeadersWidth = 20;
			this.dgvWorksheet.RowTemplate.Height = 20;
			this.dgvWorksheet.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvWorksheet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvWorksheet.Size = new System.Drawing.Size(243, 266);
			this.dgvWorksheet.TabIndex = 5;
			this.dgvWorksheet.SelectionChanged += new System.EventHandler(this.dgvWorksheet_SelectionChanged);
			// 
			// col單號
			// 
			this.col單號.DataPropertyName = "單號";
			this.col單號.HeaderText = "單號";
			this.col單號.Name = "col單號";
			this.col單號.ReadOnly = true;
			this.col單號.Width = 80;
			// 
			// col單據日期
			// 
			this.col單據日期.DataPropertyName = "單據日期";
			dataGridViewCellStyle8.Format = "yyyy/MM/dd";
			this.col單據日期.DefaultCellStyle = dataGridViewCellStyle8;
			this.col單據日期.HeaderText = "單據日期";
			this.col單據日期.Name = "col單據日期";
			this.col單據日期.ReadOnly = true;
			this.col單據日期.Width = 80;
			// 
			// col實際完成日
			// 
			this.col實際完成日.DataPropertyName = "實際完成日";
			dataGridViewCellStyle9.Format = "yyyy/MM/dd";
			this.col實際完成日.DefaultCellStyle = dataGridViewCellStyle9;
			this.col實際完成日.HeaderText = "實際完成日";
			this.col實際完成日.Name = "col實際完成日";
			this.col實際完成日.ReadOnly = true;
			this.col實際完成日.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.col實際完成日.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.col實際完成日.Width = 80;
			// 
			// cbxDoneOrNot
			// 
			this.cbxDoneOrNot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxDoneOrNot.FormattingEnabled = true;
			this.cbxDoneOrNot.Items.AddRange(new object[] {
            "完成及未完成",
            "已完成",
            "未完成"});
			this.cbxDoneOrNot.Location = new System.Drawing.Point(471, 61);
			this.cbxDoneOrNot.Name = "cbxDoneOrNot";
			this.cbxDoneOrNot.Size = new System.Drawing.Size(106, 20);
			this.cbxDoneOrNot.TabIndex = 12;
			this.toolTip1.SetToolTip(this.cbxDoneOrNot, "選擇是否只查詢已完成或未完成的資料");
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(583, 60);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(82, 23);
			this.btnSearch.TabIndex = 5;
			this.btnSearch.Text = "查詢";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(31, 64);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(29, 12);
			this.label9.TabIndex = 11;
			this.label9.Text = "日期";
			// 
			// tbxCustomerNameS
			// 
			this.tbxCustomerNameS.Location = new System.Drawing.Point(604, 12);
			this.tbxCustomerNameS.Name = "tbxCustomerNameS";
			this.tbxCustomerNameS.Size = new System.Drawing.Size(61, 22);
			this.tbxCustomerNameS.TabIndex = 1;
			this.tbxCustomerNameS.Visible = false;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(548, 17);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(53, 12);
			this.label8.TabIndex = 9;
			this.label8.Text = "客戶名稱";
			this.label8.Visible = false;
			// 
			// tbxWorksheetNumberS
			// 
			this.tbxWorksheetNumberS.Location = new System.Drawing.Point(63, 32);
			this.tbxWorksheetNumberS.Name = "tbxWorksheetNumberS";
			this.tbxWorksheetNumberS.Size = new System.Drawing.Size(329, 22);
			this.tbxWorksheetNumberS.TabIndex = 0;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(7, 37);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(53, 12);
			this.label7.TabIndex = 7;
			this.label7.Text = "工作單號";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(326, 65);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(17, 12);
			this.label6.TabIndex = 6;
			this.label6.Text = "到";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(183, 65);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(17, 12);
			this.label5.TabIndex = 5;
			this.label5.Text = "從";
			this.label5.Click += new System.EventHandler(this.label5_Click);
			// 
			// cbxBeginOrEnd
			// 
			this.cbxBeginOrEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxBeginOrEnd.FormattingEnabled = true;
			this.cbxBeginOrEnd.Items.AddRange(new object[] {
            "所有期間",
            "單據日期",
            "實際完成日"});
			this.cbxBeginOrEnd.Location = new System.Drawing.Point(63, 60);
			this.cbxBeginOrEnd.Name = "cbxBeginOrEnd";
			this.cbxBeginOrEnd.Size = new System.Drawing.Size(110, 20);
			this.cbxBeginOrEnd.TabIndex = 2;
			this.toolTip1.SetToolTip(this.cbxBeginOrEnd, "選擇是否依照日期來篩選查詢資料");
			this.cbxBeginOrEnd.SelectedIndexChanged += new System.EventHandler(this.cbxBeginOrEnd_SelectedIndexChanged);
			// 
			// dtpTo
			// 
			this.dtpTo.Location = new System.Drawing.Point(351, 60);
			this.dtpTo.Name = "dtpTo";
			this.dtpTo.Size = new System.Drawing.Size(114, 22);
			this.dtpTo.TabIndex = 4;
			// 
			// dtpFrom
			// 
			this.dtpFrom.Location = new System.Drawing.Point(208, 60);
			this.dtpFrom.Name = "dtpFrom";
			this.dtpFrom.Size = new System.Drawing.Size(114, 22);
			this.dtpFrom.TabIndex = 3;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.Location = new System.Drawing.Point(4, 91);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.dgvWorksheet);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
			this.splitContainer1.Size = new System.Drawing.Size(678, 272);
			this.splitContainer1.SplitterDistance = 249;
			this.splitContainer1.TabIndex = 7;
			// 
			// label12
			// 
			this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label12.Location = new System.Drawing.Point(1, 86);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(678, 2);
			this.label12.TabIndex = 8;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold);
			this.label13.Location = new System.Drawing.Point(6, 9);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(76, 16);
			this.label13.TabIndex = 13;
			this.label13.Text = "查詢條件";
			// 
			// colWpId
			// 
			this.colWpId.DataPropertyName = "編號";
			this.colWpId.HeaderText = "序號";
			this.colWpId.Name = "colWpId";
			this.colWpId.ReadOnly = true;
			this.colWpId.Width = 52;
			// 
			// col品號
			// 
			this.col品號.DataPropertyName = "品號";
			this.col品號.FillWeight = 3F;
			this.col品號.HeaderText = "品號";
			this.col品號.Name = "col品號";
			this.col品號.ReadOnly = true;
			this.col品號.Width = 52;
			// 
			// col數量
			// 
			this.col數量.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.col數量.DataPropertyName = "數量";
			dataGridViewCellStyle2.Format = "0.#";
			this.col數量.DefaultCellStyle = dataGridViewCellStyle2;
			this.col數量.FillWeight = 1F;
			this.col數量.HeaderText = "數量(PCS)";
			this.col數量.Name = "col數量";
			this.col數量.ReadOnly = true;
			this.col數量.Width = 70;
			// 
			// col客戶
			// 
			this.col客戶.DataPropertyName = "客戶";
			this.col客戶.FillWeight = 2F;
			this.col客戶.HeaderText = "客戶";
			this.col客戶.Name = "col客戶";
			this.col客戶.ReadOnly = true;
			this.col客戶.Width = 52;
			// 
			// col客戶需貨日
			// 
			this.col客戶需貨日.DataPropertyName = "客戶需貨日";
			dataGridViewCellStyle3.Format = "d";
			this.col客戶需貨日.DefaultCellStyle = dataGridViewCellStyle3;
			this.col客戶需貨日.FillWeight = 2F;
			this.col客戶需貨日.HeaderText = "客戶需貨日";
			this.col客戶需貨日.Name = "col客戶需貨日";
			this.col客戶需貨日.ReadOnly = true;
			this.col客戶需貨日.Width = 88;
			// 
			// col預計完成日
			// 
			this.col預計完成日.DataPropertyName = "預計完成日";
			dataGridViewCellStyle4.Format = "d";
			this.col預計完成日.DefaultCellStyle = dataGridViewCellStyle4;
			this.col預計完成日.FillWeight = 2F;
			this.col預計完成日.HeaderText = "預計完成日";
			this.col預計完成日.Name = "col預計完成日";
			this.col預計完成日.ReadOnly = true;
			this.col預計完成日.Width = 88;
			// 
			// col完成日
			// 
			this.col完成日.DataPropertyName = "實際完成日";
			this.col完成日.FillWeight = 1.5F;
			this.col完成日.HeaderText = "完成日";
			this.col完成日.Name = "col完成日";
			this.col完成日.ReadOnly = true;
			this.col完成日.Width = 64;
			// 
			// WorksheetForm
			// 
			this.AcceptButton = this.btnSearch;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(687, 366);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.cbxDoneOrNot);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.btnSearch);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.tbxCustomerNameS);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.dtpFrom);
			this.Controls.Add(this.tbxWorksheetNumberS);
			this.Controls.Add(this.dtpTo);
			this.Controls.Add(this.cbxBeginOrEnd);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.MinimumSize = new System.Drawing.Size(695, 400);
			this.Name = "WorksheetForm";
			this.ShowIcon = false;
			this.Text = "工作單管理";
			this.Load += new System.EventHandler(this.WorksheetForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bsPart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvWorksheet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bsWorksheet)).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDelWorksheet;
		private System.Windows.Forms.Button btnEditWorksheet;
        private System.Windows.Forms.TextBox tbxWorksheetNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvWorksheet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxBeginOrEnd;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbxCustomerNameS;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbxWorksheetNumberS;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpBegin;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox ckbEnd;
        private System.Windows.Forms.BindingSource bsWorksheet;
        private System.Windows.Forms.ComboBox cbxDoneOrNot;
		private System.Windows.Forms.BindingSource bsPart;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.DataGridViewTextBoxColumn col單號;
		private System.Windows.Forms.DataGridViewTextBoxColumn col單據日期;
		private System.Windows.Forms.DataGridViewTextBoxColumn col實際完成日;
		private System.Windows.Forms.DataGridViewTextBoxColumn colWpId;
		private System.Windows.Forms.DataGridViewTextBoxColumn col品號;
		private System.Windows.Forms.DataGridViewTextBoxColumn col數量;
		private System.Windows.Forms.DataGridViewTextBoxColumn col客戶;
		private System.Windows.Forms.DataGridViewTextBoxColumn col客戶需貨日;
		private System.Windows.Forms.DataGridViewTextBoxColumn col預計完成日;
		private System.Windows.Forms.DataGridViewTextBoxColumn col完成日;
    }
}