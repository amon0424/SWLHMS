namespace Mong
{
    partial class HourDataForm
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.pnlLabor = new System.Windows.Forms.Panel();
			this.ckbLine = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cbxLaborNumber = new System.Windows.Forms.ComboBox();
			this.bsLabor = new System.Windows.Forms.BindingSource(this.components);
			this.label3 = new System.Windows.Forms.Label();
			this.cbxLaborName = new System.Windows.Forms.ComboBox();
			this.cbxLine = new System.Windows.Forms.ComboBox();
			this.bsLine = new System.Windows.Forms.BindingSource(this.components);
			this.pnlDate = new System.Windows.Forms.Panel();
			this.label5 = new System.Windows.Forms.Label();
			this.dtpFrom = new System.Windows.Forms.DateTimePicker();
			this.dtpTo = new System.Windows.Forms.DateTimePicker();
			this.label6 = new System.Windows.Forms.Label();
			this.ckbLabor = new System.Windows.Forms.CheckBox();
			this.btnSearch = new System.Windows.Forms.Button();
			this.cbxProduceOrNot = new System.Windows.Forms.ComboBox();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.pnlProduce = new System.Windows.Forms.Panel();
			this.tbxPartNumber = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.tbxWorksheetNumber = new System.Windows.Forms.TextBox();
			this.pnlNonProduce = new System.Windows.Forms.Panel();
			this.label9 = new System.Windows.Forms.Label();
			this.cbxNonProduce = new System.Windows.Forms.ComboBox();
			this.bsNonProduce = new System.Windows.Forms.BindingSource(this.components);
			this.ckbDate = new System.Windows.Forms.CheckBox();
			this.dgvHourData = new System.Windows.Forms.DataGridView();
			this.cmsDgv = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tsmiCopyValue = new System.Windows.Forms.ToolStripMenuItem();
			this.bsHourData = new System.Windows.Forms.BindingSource(this.components);
			this.lbSearchResult = new System.Windows.Forms.Label();
			this.btnEditHourData = new System.Windows.Forms.Button();
			this.btnDelHourData = new System.Windows.Forms.Button();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.dtpTip = new System.Windows.Forms.DateTimePicker();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnSearchUnfilled = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.btnPrint = new System.Windows.Forms.Button();
			this.col編號 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col借入產線 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col員工編號 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col員工姓名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col工作單號 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colWpId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col品號2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col非生產名稱 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col工時 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colHourType = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col數量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.待驗數量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col非生產編號 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col備註 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.pnlLabor.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsLabor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bsLine)).BeginInit();
			this.pnlDate.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.pnlProduce.SuspendLayout();
			this.pnlNonProduce.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsNonProduce)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvHourData)).BeginInit();
			this.cmsDgv.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsHourData)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlLabor
			// 
			this.pnlLabor.Controls.Add(this.ckbLine);
			this.pnlLabor.Controls.Add(this.label2);
			this.pnlLabor.Controls.Add(this.cbxLaborNumber);
			this.pnlLabor.Controls.Add(this.label3);
			this.pnlLabor.Controls.Add(this.cbxLaborName);
			this.pnlLabor.Controls.Add(this.cbxLine);
			this.pnlLabor.Enabled = false;
			this.pnlLabor.Location = new System.Drawing.Point(83, 60);
			this.pnlLabor.Name = "pnlLabor";
			this.pnlLabor.Size = new System.Drawing.Size(419, 27);
			this.pnlLabor.TabIndex = 35;
			// 
			// ckbLine
			// 
			this.ckbLine.AutoSize = true;
			this.ckbLine.Checked = true;
			this.ckbLine.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ckbLine.Location = new System.Drawing.Point(7, 6);
			this.ckbLine.Name = "ckbLine";
			this.ckbLine.Size = new System.Drawing.Size(48, 16);
			this.ckbLine.TabIndex = 17;
			this.ckbLine.Text = "產線";
			this.toolTip1.SetToolTip(this.ckbLine, "勾選此項以用產線篩選員工");
			this.ckbLine.UseVisualStyleBackColor = true;
			this.ckbLine.CheckedChanged += new System.EventHandler(this.ckbLine_CheckedChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(135, 7);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 12);
			this.label2.TabIndex = 14;
			this.label2.Text = "員工編號";
			// 
			// cbxLaborNumber
			// 
			this.cbxLaborNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.cbxLaborNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbxLaborNumber.DataSource = this.bsLabor;
			this.cbxLaborNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxLaborNumber.FormattingEnabled = true;
			this.cbxLaborNumber.Location = new System.Drawing.Point(194, 3);
			this.cbxLaborNumber.Name = "cbxLaborNumber";
			this.cbxLaborNumber.Size = new System.Drawing.Size(80, 20);
			this.cbxLaborNumber.TabIndex = 13;
			this.cbxLaborNumber.SelectedValueChanged += new System.EventHandler(this.cbxLaborNumber_SelectedValueChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(280, 7);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 12);
			this.label3.TabIndex = 16;
			this.label3.Text = "員工姓名";
			// 
			// cbxLaborName
			// 
			this.cbxLaborName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.cbxLaborName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbxLaborName.DataSource = this.bsLabor;
			this.cbxLaborName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxLaborName.FormattingEnabled = true;
			this.cbxLaborName.Location = new System.Drawing.Point(339, 3);
			this.cbxLaborName.Name = "cbxLaborName";
			this.cbxLaborName.Size = new System.Drawing.Size(80, 20);
			this.cbxLaborName.TabIndex = 15;
			this.cbxLaborName.SelectedValueChanged += new System.EventHandler(this.cbxLaborNumber_SelectedValueChanged);
			// 
			// cbxLine
			// 
			this.cbxLine.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.cbxLine.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbxLine.DataSource = this.bsLine;
			this.cbxLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxLine.Enabled = false;
			this.cbxLine.FormattingEnabled = true;
			this.cbxLine.Location = new System.Drawing.Point(55, 3);
			this.cbxLine.Name = "cbxLine";
			this.cbxLine.Size = new System.Drawing.Size(74, 20);
			this.cbxLine.TabIndex = 12;
			this.cbxLine.SelectedValueChanged += new System.EventHandler(this.cbxLine_SelectedValueChanged);
			// 
			// pnlDate
			// 
			this.pnlDate.Controls.Add(this.label5);
			this.pnlDate.Controls.Add(this.dtpFrom);
			this.pnlDate.Controls.Add(this.dtpTo);
			this.pnlDate.Controls.Add(this.label6);
			this.pnlDate.Enabled = false;
			this.pnlDate.Location = new System.Drawing.Point(83, 90);
			this.pnlDate.Name = "pnlDate";
			this.pnlDate.Size = new System.Drawing.Size(294, 27);
			this.pnlDate.TabIndex = 26;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(7, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(17, 12);
			this.label5.TabIndex = 9;
			this.label5.Text = "從";
			// 
			// dtpFrom
			// 
			this.dtpFrom.Location = new System.Drawing.Point(30, 3);
			this.dtpFrom.Name = "dtpFrom";
			this.dtpFrom.Size = new System.Drawing.Size(114, 22);
			this.dtpFrom.TabIndex = 7;
			// 
			// dtpTo
			// 
			this.dtpTo.Location = new System.Drawing.Point(173, 3);
			this.dtpTo.Name = "dtpTo";
			this.dtpTo.Size = new System.Drawing.Size(114, 22);
			this.dtpTo.TabIndex = 8;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(150, 8);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(17, 12);
			this.label6.TabIndex = 10;
			this.label6.Text = "到";
			// 
			// ckbLabor
			// 
			this.ckbLabor.AutoSize = true;
			this.ckbLabor.Location = new System.Drawing.Point(12, 66);
			this.ckbLabor.Name = "ckbLabor";
			this.ckbLabor.Size = new System.Drawing.Size(72, 16);
			this.ckbLabor.TabIndex = 28;
			this.ckbLabor.Text = "指定員工";
			this.toolTip1.SetToolTip(this.ckbLabor, "勾選此項以用員工篩選查詢結果");
			this.ckbLabor.UseVisualStyleBackColor = true;
			this.ckbLabor.CheckedChanged += new System.EventHandler(this.ckbLabor_CheckedChanged);
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(383, 94);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(119, 23);
			this.btnSearch.TabIndex = 25;
			this.btnSearch.Text = "查詢";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// cbxProduceOrNot
			// 
			this.cbxProduceOrNot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxProduceOrNot.FormattingEnabled = true;
			this.cbxProduceOrNot.Items.AddRange(new object[] {
            "",
            "生產",
            "非生產"});
			this.cbxProduceOrNot.Location = new System.Drawing.Point(10, 37);
			this.cbxProduceOrNot.Name = "cbxProduceOrNot";
			this.cbxProduceOrNot.Size = new System.Drawing.Size(67, 20);
			this.cbxProduceOrNot.TabIndex = 21;
			this.toolTip1.SetToolTip(this.cbxProduceOrNot, "選擇是否只查詢生產或非生產的資料");
			this.cbxProduceOrNot.SelectedIndexChanged += new System.EventHandler(this.cbxProduceOrNot_SelectedIndexChanged);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.pnlProduce);
			this.flowLayoutPanel1.Controls.Add(this.pnlNonProduce);
			this.flowLayoutPanel1.Location = new System.Drawing.Point(92, 31);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(412, 31);
			this.flowLayoutPanel1.TabIndex = 24;
			// 
			// pnlProduce
			// 
			this.pnlProduce.Controls.Add(this.tbxPartNumber);
			this.pnlProduce.Controls.Add(this.label8);
			this.pnlProduce.Controls.Add(this.label7);
			this.pnlProduce.Controls.Add(this.tbxWorksheetNumber);
			this.pnlProduce.Location = new System.Drawing.Point(0, 0);
			this.pnlProduce.Margin = new System.Windows.Forms.Padding(0);
			this.pnlProduce.Name = "pnlProduce";
			this.pnlProduce.Size = new System.Drawing.Size(410, 30);
			this.pnlProduce.TabIndex = 22;
			// 
			// tbxPartNumber
			// 
			this.tbxPartNumber.Location = new System.Drawing.Point(244, 5);
			this.tbxPartNumber.Name = "tbxPartNumber";
			this.tbxPartNumber.Size = new System.Drawing.Size(163, 22);
			this.tbxPartNumber.TabIndex = 21;
			this.tbxPartNumber.Validated += new System.EventHandler(this.tbxPartNumber_Validated);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(209, 10);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(29, 12);
			this.label8.TabIndex = 22;
			this.label8.Text = "品號";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(3, 9);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(53, 12);
			this.label7.TabIndex = 18;
			this.label7.Text = "工作單號";
			// 
			// tbxWorksheetNumber
			// 
			this.tbxWorksheetNumber.Location = new System.Drawing.Point(62, 4);
			this.tbxWorksheetNumber.Name = "tbxWorksheetNumber";
			this.tbxWorksheetNumber.Size = new System.Drawing.Size(141, 22);
			this.tbxWorksheetNumber.TabIndex = 17;
			this.tbxWorksheetNumber.Validated += new System.EventHandler(this.tbxWorksheetNumber_Validated);
			// 
			// pnlNonProduce
			// 
			this.pnlNonProduce.BackColor = System.Drawing.Color.Transparent;
			this.pnlNonProduce.Controls.Add(this.label9);
			this.pnlNonProduce.Controls.Add(this.cbxNonProduce);
			this.pnlNonProduce.Location = new System.Drawing.Point(0, 30);
			this.pnlNonProduce.Margin = new System.Windows.Forms.Padding(0);
			this.pnlNonProduce.Name = "pnlNonProduce";
			this.pnlNonProduce.Size = new System.Drawing.Size(218, 30);
			this.pnlNonProduce.TabIndex = 23;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(3, 9);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(41, 12);
			this.label9.TabIndex = 24;
			this.label9.Text = "非生產";
			// 
			// cbxNonProduce
			// 
			this.cbxNonProduce.DataSource = this.bsNonProduce;
			this.cbxNonProduce.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxNonProduce.FormattingEnabled = true;
			this.cbxNonProduce.Location = new System.Drawing.Point(50, 5);
			this.cbxNonProduce.Name = "cbxNonProduce";
			this.cbxNonProduce.Size = new System.Drawing.Size(161, 20);
			this.cbxNonProduce.TabIndex = 23;
			// 
			// ckbDate
			// 
			this.ckbDate.AutoSize = true;
			this.ckbDate.Location = new System.Drawing.Point(12, 97);
			this.ckbDate.Name = "ckbDate";
			this.ckbDate.Size = new System.Drawing.Size(72, 16);
			this.ckbDate.TabIndex = 27;
			this.ckbDate.Text = "指定日期";
			this.toolTip1.SetToolTip(this.ckbDate, "勾選此項以用日期篩選查詢結果");
			this.ckbDate.UseVisualStyleBackColor = true;
			this.ckbDate.CheckedChanged += new System.EventHandler(this.ckbDate_CheckedChanged);
			// 
			// dgvHourData
			// 
			this.dgvHourData.AllowUserToAddRows = false;
			this.dgvHourData.AllowUserToDeleteRows = false;
			this.dgvHourData.AllowUserToResizeRows = false;
			this.dgvHourData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvHourData.AutoGenerateColumns = false;
			this.dgvHourData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.dgvHourData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvHourData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvHourData.ColumnHeadersHeight = 20;
			this.dgvHourData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dgvHourData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col編號,
            this.col借入產線,
            this.col員工編號,
            this.col員工姓名,
            this.col日期,
            this.col工作單號,
            this.colWpId,
            this.col品號2,
            this.col非生產名稱,
            this.col工時,
            this.colHourType,
            this.col數量,
            this.待驗數量,
            this.col非生產編號,
            this.col備註});
			this.dgvHourData.ContextMenuStrip = this.cmsDgv;
			this.dgvHourData.DataSource = this.bsHourData;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
			dataGridViewCellStyle3.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvHourData.DefaultCellStyle = dataGridViewCellStyle3;
			this.dgvHourData.EnableHeadersVisualStyles = false;
			this.dgvHourData.GridColor = System.Drawing.Color.LightGray;
			this.dgvHourData.Location = new System.Drawing.Point(12, 151);
			this.dgvHourData.Name = "dgvHourData";
			this.dgvHourData.ReadOnly = true;
			this.dgvHourData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.Color.CornflowerBlue;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvHourData.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.dgvHourData.RowHeadersVisible = false;
			this.dgvHourData.RowHeadersWidth = 20;
			this.dgvHourData.RowTemplate.Height = 20;
			this.dgvHourData.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvHourData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvHourData.Size = new System.Drawing.Size(638, 269);
			this.dgvHourData.TabIndex = 33;
			this.dgvHourData.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvHourData_MouseDown);
			// 
			// cmsDgv
			// 
			this.cmsDgv.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCopyValue});
			this.cmsDgv.Name = "cmsDgv";
			this.cmsDgv.Size = new System.Drawing.Size(107, 26);
			this.cmsDgv.Opening += new System.ComponentModel.CancelEventHandler(this.cmsDgv_Opening);
			// 
			// tsmiCopyValue
			// 
			this.tsmiCopyValue.Name = "tsmiCopyValue";
			this.tsmiCopyValue.Size = new System.Drawing.Size(106, 22);
			this.tsmiCopyValue.Text = "複製值";
			this.tsmiCopyValue.Click += new System.EventHandler(this.tsmiCopyValue_Click);
			// 
			// lbSearchResult
			// 
			this.lbSearchResult.AutoSize = true;
			this.lbSearchResult.Location = new System.Drawing.Point(15, 133);
			this.lbSearchResult.Name = "lbSearchResult";
			this.lbSearchResult.Size = new System.Drawing.Size(0, 12);
			this.lbSearchResult.TabIndex = 34;
			// 
			// btnEditHourData
			// 
			this.btnEditHourData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEditHourData.Location = new System.Drawing.Point(494, 426);
			this.btnEditHourData.Name = "btnEditHourData";
			this.btnEditHourData.Size = new System.Drawing.Size(75, 23);
			this.btnEditHourData.TabIndex = 35;
			this.btnEditHourData.Text = "編輯";
			this.btnEditHourData.UseVisualStyleBackColor = true;
			this.btnEditHourData.Click += new System.EventHandler(this.btnEditHourData_Click);
			// 
			// btnDelHourData
			// 
			this.btnDelHourData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDelHourData.Location = new System.Drawing.Point(575, 426);
			this.btnDelHourData.Name = "btnDelHourData";
			this.btnDelHourData.Size = new System.Drawing.Size(75, 23);
			this.btnDelHourData.TabIndex = 36;
			this.btnDelHourData.Text = "刪除";
			this.btnDelHourData.UseVisualStyleBackColor = true;
			this.btnDelHourData.Click += new System.EventHandler(this.btnDelHourData_Click);
			// 
			// dtpTip
			// 
			this.dtpTip.Location = new System.Drawing.Point(8, 48);
			this.dtpTip.Name = "dtpTip";
			this.dtpTip.Size = new System.Drawing.Size(124, 22);
			this.dtpTip.TabIndex = 8;
			this.toolTip1.SetToolTip(this.dtpTip, "設定提醒日期，使用者輸入工時資料時也是提醒指定日期之後的未補足的資料");
			this.dtpTip.Enter += new System.EventHandler(this.dtpTip_Enter);
			this.dtpTip.Validated += new System.EventHandler(this.dtpTip_Validated);
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.btnSearchUnfilled);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.dtpTip);
			this.groupBox2.Location = new System.Drawing.Point(510, 9);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(141, 110);
			this.groupBox2.TabIndex = 38;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "未補足資料提示";
			// 
			// btnSearchUnfilled
			// 
			this.btnSearchUnfilled.Location = new System.Drawing.Point(8, 79);
			this.btnSearchUnfilled.Name = "btnSearchUnfilled";
			this.btnSearchUnfilled.Size = new System.Drawing.Size(124, 23);
			this.btnSearchUnfilled.TabIndex = 26;
			this.btnSearchUnfilled.Text = "查詢所有未補足資料";
			this.btnSearchUnfilled.UseVisualStyleBackColor = true;
			this.btnSearchUnfilled.Click += new System.EventHandler(this.btnSearchUnfilled_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(126, 29);
			this.label1.TabIndex = 9;
			this.label1.Text = "提示指定日期之後未補足時數的資料";
			// 
			// label12
			// 
			this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label12.Location = new System.Drawing.Point(12, 126);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(638, 2);
			this.label12.TabIndex = 39;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold);
			this.label13.Location = new System.Drawing.Point(7, 9);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(76, 16);
			this.label13.TabIndex = 40;
			this.label13.Text = "查詢條件";
			// 
			// btnPrint
			// 
			this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnPrint.Location = new System.Drawing.Point(12, 426);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(113, 23);
			this.btnPrint.TabIndex = 41;
			this.btnPrint.Text = "列印查詢資料";
			this.btnPrint.UseVisualStyleBackColor = true;
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			// 
			// col編號
			// 
			this.col編號.DataPropertyName = "編號";
			this.col編號.HeaderText = "編號";
			this.col編號.Name = "col編號";
			this.col編號.ReadOnly = true;
			this.col編號.Width = 80;
			// 
			// col借入產線
			// 
			this.col借入產線.DataPropertyName = "借入產線";
			this.col借入產線.HeaderText = "借入產線";
			this.col借入產線.Name = "col借入產線";
			this.col借入產線.ReadOnly = true;
			this.col借入產線.Width = 65;
			// 
			// col員工編號
			// 
			this.col員工編號.DataPropertyName = "員工編號";
			this.col員工編號.HeaderText = "員工編號";
			this.col員工編號.Name = "col員工編號";
			this.col員工編號.ReadOnly = true;
			this.col員工編號.Width = 80;
			// 
			// col員工姓名
			// 
			this.col員工姓名.DataPropertyName = "員工姓名";
			this.col員工姓名.HeaderText = "員工姓名";
			this.col員工姓名.Name = "col員工姓名";
			this.col員工姓名.ReadOnly = true;
			this.col員工姓名.Width = 80;
			// 
			// col日期
			// 
			this.col日期.DataPropertyName = "日期";
			this.col日期.HeaderText = "日期";
			this.col日期.Name = "col日期";
			this.col日期.ReadOnly = true;
			this.col日期.Width = 80;
			// 
			// col工作單號
			// 
			this.col工作單號.DataPropertyName = "工作單號";
			this.col工作單號.HeaderText = "工作單號";
			this.col工作單號.Name = "col工作單號";
			this.col工作單號.ReadOnly = true;
			this.col工作單號.Width = 80;
			// 
			// colWpId
			// 
			this.colWpId.DataPropertyName = "工品編號";
			this.colWpId.HeaderText = "序號";
			this.colWpId.Name = "colWpId";
			this.colWpId.ReadOnly = true;
			this.colWpId.Width = 50;
			// 
			// col品號2
			// 
			this.col品號2.DataPropertyName = "品號";
			this.col品號2.HeaderText = "品號";
			this.col品號2.Name = "col品號2";
			this.col品號2.ReadOnly = true;
			// 
			// col非生產名稱
			// 
			this.col非生產名稱.DataPropertyName = "非生產名稱";
			this.col非生產名稱.HeaderText = "非生產";
			this.col非生產名稱.Name = "col非生產名稱";
			this.col非生產名稱.ReadOnly = true;
			this.col非生產名稱.Width = 99;
			// 
			// col工時
			// 
			this.col工時.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.col工時.DataPropertyName = "工時";
			dataGridViewCellStyle2.Format = "0.##";
			this.col工時.DefaultCellStyle = dataGridViewCellStyle2;
			this.col工時.HeaderText = "工時";
			this.col工時.Name = "col工時";
			this.col工時.ReadOnly = true;
			this.col工時.Width = 65;
			// 
			// colHourType
			// 
			this.colHourType.DataPropertyName = "工時類型名稱";
			this.colHourType.HeaderText = "工時類型";
			this.colHourType.Name = "colHourType";
			this.colHourType.ReadOnly = true;
			// 
			// col數量
			// 
			this.col數量.DataPropertyName = "數量";
			this.col數量.HeaderText = "完成";
			this.col數量.Name = "col數量";
			this.col數量.ReadOnly = true;
			this.col數量.Width = 65;
			// 
			// 待驗數量
			// 
			this.待驗數量.DataPropertyName = "待驗數量";
			this.待驗數量.HeaderText = "送驗數量";
			this.待驗數量.Name = "待驗數量";
			this.待驗數量.ReadOnly = true;
			this.待驗數量.Width = 80;
			// 
			// col非生產編號
			// 
			this.col非生產編號.DataPropertyName = "非生產編號";
			this.col非生產編號.HeaderText = "非生產編號";
			this.col非生產編號.Name = "col非生產編號";
			this.col非生產編號.ReadOnly = true;
			this.col非生產編號.Visible = false;
			// 
			// col備註
			// 
			this.col備註.DataPropertyName = "備註";
			this.col備註.HeaderText = "備註";
			this.col備註.Name = "col備註";
			this.col備註.ReadOnly = true;
			// 
			// HourDataForm
			// 
			this.AcceptButton = this.btnSearch;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(662, 461);
			this.Controls.Add(this.pnlDate);
			this.Controls.Add(this.btnPrint);
			this.Controls.Add(this.pnlLabor);
			this.Controls.Add(this.btnSearch);
			this.Controls.Add(this.ckbDate);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.ckbLabor);
			this.Controls.Add(this.cbxProduceOrNot);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.lbSearchResult);
			this.Controls.Add(this.btnDelHourData);
			this.Controls.Add(this.btnEditHourData);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.dgvHourData);
			this.MinimumSize = new System.Drawing.Size(670, 495);
			this.Name = "HourDataForm";
			this.ShowIcon = false;
			this.Text = "工時資料管理";
			this.Load += new System.EventHandler(this.HourDataForm_Load);
			this.pnlLabor.ResumeLayout(false);
			this.pnlLabor.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsLabor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bsLine)).EndInit();
			this.pnlDate.ResumeLayout(false);
			this.pnlDate.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.pnlProduce.ResumeLayout(false);
			this.pnlProduce.PerformLayout();
			this.pnlNonProduce.ResumeLayout(false);
			this.pnlNonProduce.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsNonProduce)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvHourData)).EndInit();
			this.cmsDgv.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.bsHourData)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.ComboBox cbxLine;
        private System.Windows.Forms.ComboBox cbxLaborName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxLaborNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxWorksheetNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxProduceOrNot;
        private System.Windows.Forms.Panel pnlProduce;
        private System.Windows.Forms.TextBox tbxPartNumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel pnlNonProduce;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbxNonProduce;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvHourData;
        private System.Windows.Forms.BindingSource bsHourData;
        private System.Windows.Forms.BindingSource bsLabor;
        private System.Windows.Forms.BindingSource bsNonProduce;
        private System.Windows.Forms.BindingSource bsLine;
        private System.Windows.Forms.Panel pnlDate;
        private System.Windows.Forms.CheckBox ckbDate;
        private System.Windows.Forms.Label lbSearchResult;
        private System.Windows.Forms.Panel pnlLabor;
        private System.Windows.Forms.CheckBox ckbLabor;
        private System.Windows.Forms.Button btnEditHourData;
        private System.Windows.Forms.Button btnDelHourData;
        private System.Windows.Forms.CheckBox ckbLine;
        private System.Windows.Forms.ContextMenuStrip cmsDgv;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopyValue;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSearchUnfilled;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpTip;
        private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Button btnPrint;
		private System.Windows.Forms.DataGridViewTextBoxColumn col編號;
		private System.Windows.Forms.DataGridViewTextBoxColumn col借入產線;
		private System.Windows.Forms.DataGridViewTextBoxColumn col員工編號;
		private System.Windows.Forms.DataGridViewTextBoxColumn col員工姓名;
		private System.Windows.Forms.DataGridViewTextBoxColumn col日期;
		private System.Windows.Forms.DataGridViewTextBoxColumn col工作單號;
		private System.Windows.Forms.DataGridViewTextBoxColumn colWpId;
		private System.Windows.Forms.DataGridViewTextBoxColumn col品號2;
		private System.Windows.Forms.DataGridViewTextBoxColumn col非生產名稱;
		private System.Windows.Forms.DataGridViewTextBoxColumn col工時;
		private System.Windows.Forms.DataGridViewTextBoxColumn colHourType;
		private System.Windows.Forms.DataGridViewTextBoxColumn col數量;
		private System.Windows.Forms.DataGridViewTextBoxColumn 待驗數量;
		private System.Windows.Forms.DataGridViewTextBoxColumn col非生產編號;
		private System.Windows.Forms.DataGridViewTextBoxColumn col備註;
    }
}