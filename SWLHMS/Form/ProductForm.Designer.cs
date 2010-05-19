namespace Mong
{
    partial class ProductForm
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dgvSeries = new System.Windows.Forms.DataGridView();
			this.col編號 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col代號 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.bsSeries = new System.Windows.Forms.BindingSource(this.components);
			this.dgvPart = new System.Windows.Forms.DataGridView();
			this.bsPart = new System.Windows.Forms.BindingSource(this.components);
			this.btnDisplayAllPart = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.btnEditSeries = new System.Windows.Forms.Button();
			this.btnAddSeries = new System.Windows.Forms.Button();
			this.btnDelSeries = new System.Windows.Forms.Button();
			this.btnStoreSeries = new System.Windows.Forms.Button();
			this.btnCancelSerials = new System.Windows.Forms.Button();
			this.tbxSeriesName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbxSeries = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnStorePart = new System.Windows.Forms.Button();
			this.btnImportLH = new System.Windows.Forms.Button();
			this.bsSeriesCbx = new System.Windows.Forms.BindingSource(this.components);
			this.btnUndo = new System.Windows.Forms.Button();
			this.bsLineCbx = new System.Windows.Forms.BindingSource(this.components);
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.col系列編號 = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.col系列代號 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col品號 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col系列名稱 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col品名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col產線 = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.col工時 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col系統時薪 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col標準工資 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dgvSeries)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bsSeries)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvPart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bsPart)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsSeriesCbx)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bsLineCbx)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvSeries
			// 
			this.dgvSeries.AllowUserToAddRows = false;
			this.dgvSeries.AllowUserToDeleteRows = false;
			this.dgvSeries.AllowUserToResizeRows = false;
			this.dgvSeries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.dgvSeries.AutoGenerateColumns = false;
			this.dgvSeries.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvSeries.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.dgvSeries.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvSeries.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvSeries.ColumnHeadersHeight = 20;
			this.dgvSeries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dgvSeries.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col編號,
            this.col代號});
			this.dgvSeries.DataSource = this.bsSeries;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
			dataGridViewCellStyle2.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvSeries.DefaultCellStyle = dataGridViewCellStyle2;
			this.dgvSeries.EnableHeadersVisualStyles = false;
			this.dgvSeries.GridColor = System.Drawing.Color.LightGray;
			this.dgvSeries.Location = new System.Drawing.Point(5, 6);
			this.dgvSeries.Name = "dgvSeries";
			this.dgvSeries.ReadOnly = true;
			this.dgvSeries.RowHeadersVisible = false;
			this.dgvSeries.RowHeadersWidth = 40;
			this.dgvSeries.RowTemplate.Height = 17;
			this.dgvSeries.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvSeries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvSeries.Size = new System.Drawing.Size(172, 587);
			this.dgvSeries.TabIndex = 0;
			this.dgvSeries.SelectionChanged += new System.EventHandler(this.dgvSeries_SelectionChanged);
			// 
			// col編號
			// 
			this.col編號.DataPropertyName = "編號";
			this.col編號.FillWeight = 50F;
			this.col編號.HeaderText = "編號";
			this.col編號.Name = "col編號";
			this.col編號.ReadOnly = true;
			// 
			// col代號
			// 
			this.col代號.DataPropertyName = "代號";
			this.col代號.HeaderText = "代號";
			this.col代號.Name = "col代號";
			this.col代號.ReadOnly = true;
			// 
			// bsSeries
			// 
			this.bsSeries.Sort = "編號 ASC";
			// 
			// dgvPart
			// 
			this.dgvPart.AllowUserToResizeRows = false;
			this.dgvPart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvPart.AutoGenerateColumns = false;
			this.dgvPart.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.dgvPart.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
			this.dgvPart.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.SteelBlue;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvPart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dgvPart.ColumnHeadersHeight = 20;
			this.dgvPart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dgvPart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col系列編號,
            this.col系列代號,
            this.col品號,
            this.col系列名稱,
            this.col品名,
            this.col產線,
            this.col工時,
            this.col系統時薪,
            this.col標準工資});
			this.dgvPart.DataSource = this.bsPart;
			this.dgvPart.EnableHeadersVisualStyles = false;
			this.dgvPart.GridColor = System.Drawing.Color.LightGray;
			this.dgvPart.Location = new System.Drawing.Point(185, 127);
			this.dgvPart.Name = "dgvPart";
			this.dgvPart.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle8.BackColor = System.Drawing.Color.SteelBlue;
			dataGridViewCellStyle8.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvPart.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
			this.dgvPart.RowHeadersWidth = 20;
			this.dgvPart.RowTemplate.Height = 20;
			this.dgvPart.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvPart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvPart.Size = new System.Drawing.Size(688, 466);
			this.dgvPart.TabIndex = 1;
			this.dgvPart.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPart_CellValueChanged);
			this.dgvPart.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvPart_UserDeletingRow);
			this.dgvPart.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvPart_CellBeginEdit);
			this.dgvPart.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvPart_UserAddedRow);
			this.dgvPart.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPart_CellValidated);
			this.dgvPart.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvPart_UserDeletedRow);
			this.dgvPart.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvPart_CellValidating);
			this.dgvPart.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvPart_CurrentCellDirtyStateChanged);
			this.dgvPart.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvPart_DataError);
			// 
			// bsPart
			// 
			this.bsPart.Sort = "";
			this.bsPart.DataSourceChanged += new System.EventHandler(this.bsPart_DataSourceChanged);
			// 
			// btnDisplayAllPart
			// 
			this.btnDisplayAllPart.Location = new System.Drawing.Point(183, 98);
			this.btnDisplayAllPart.Name = "btnDisplayAllPart";
			this.btnDisplayAllPart.Size = new System.Drawing.Size(109, 23);
			this.btnDisplayAllPart.TabIndex = 2;
			this.btnDisplayAllPart.Text = "顯示全部品號";
			this.toolTip1.SetToolTip(this.btnDisplayAllPart, "顯示所有系列的所有品號資料");
			this.btnDisplayAllPart.UseVisualStyleBackColor = true;
			this.btnDisplayAllPart.Click += new System.EventHandler(this.btnDisplayAllPart_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.flowLayoutPanel1);
			this.groupBox1.Controls.Add(this.tbxSeriesName);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.tbxSeries);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(183, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(465, 43);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "系列";
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.btnEditSeries);
			this.flowLayoutPanel1.Controls.Add(this.btnAddSeries);
			this.flowLayoutPanel1.Controls.Add(this.btnDelSeries);
			this.flowLayoutPanel1.Controls.Add(this.btnStoreSeries);
			this.flowLayoutPanel1.Controls.Add(this.btnCancelSerials);
			this.flowLayoutPanel1.Location = new System.Drawing.Point(300, 11);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(161, 28);
			this.flowLayoutPanel1.TabIndex = 7;
			// 
			// btnEditSeries
			// 
			this.btnEditSeries.Location = new System.Drawing.Point(3, 3);
			this.btnEditSeries.Name = "btnEditSeries";
			this.btnEditSeries.Size = new System.Drawing.Size(47, 23);
			this.btnEditSeries.TabIndex = 7;
			this.btnEditSeries.Text = "編輯";
			this.btnEditSeries.UseVisualStyleBackColor = true;
			this.btnEditSeries.Click += new System.EventHandler(this.btnEditSeries_Click);
			// 
			// btnAddSeries
			// 
			this.btnAddSeries.Location = new System.Drawing.Point(56, 3);
			this.btnAddSeries.Name = "btnAddSeries";
			this.btnAddSeries.Size = new System.Drawing.Size(47, 23);
			this.btnAddSeries.TabIndex = 5;
			this.btnAddSeries.Text = "新增";
			this.btnAddSeries.UseVisualStyleBackColor = true;
			this.btnAddSeries.Click += new System.EventHandler(this.btnAddSeries_Click);
			// 
			// btnDelSeries
			// 
			this.btnDelSeries.Location = new System.Drawing.Point(109, 3);
			this.btnDelSeries.Name = "btnDelSeries";
			this.btnDelSeries.Size = new System.Drawing.Size(47, 23);
			this.btnDelSeries.TabIndex = 6;
			this.btnDelSeries.Text = "刪除";
			this.btnDelSeries.UseVisualStyleBackColor = true;
			this.btnDelSeries.Click += new System.EventHandler(this.btnDelSeries_Click);
			// 
			// btnStoreSeries
			// 
			this.btnStoreSeries.Location = new System.Drawing.Point(3, 32);
			this.btnStoreSeries.Name = "btnStoreSeries";
			this.btnStoreSeries.Size = new System.Drawing.Size(47, 23);
			this.btnStoreSeries.TabIndex = 4;
			this.btnStoreSeries.Text = "儲存";
			this.btnStoreSeries.UseVisualStyleBackColor = true;
			this.btnStoreSeries.Click += new System.EventHandler(this.btnStoreSeries_Click);
			// 
			// btnCancelSerials
			// 
			this.btnCancelSerials.Location = new System.Drawing.Point(56, 32);
			this.btnCancelSerials.Name = "btnCancelSerials";
			this.btnCancelSerials.Size = new System.Drawing.Size(47, 23);
			this.btnCancelSerials.TabIndex = 8;
			this.btnCancelSerials.Text = "取消";
			this.btnCancelSerials.UseVisualStyleBackColor = true;
			this.btnCancelSerials.Click += new System.EventHandler(this.btnCancelSerials_Click);
			// 
			// tbxSeriesName
			// 
			this.tbxSeriesName.Location = new System.Drawing.Point(131, 14);
			this.tbxSeriesName.Name = "tbxSeriesName";
			this.tbxSeriesName.Size = new System.Drawing.Size(163, 22);
			this.tbxSeriesName.TabIndex = 3;
			this.tbxSeriesName.Validated += new System.EventHandler(this.tbxSeriesName_Validated);
			this.tbxSeriesName.Validating += new System.ComponentModel.CancelEventHandler(this.tbxSeriesName_Validating);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(96, 19);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 12);
			this.label2.TabIndex = 2;
			this.label2.Text = "代號";
			// 
			// tbxSeries
			// 
			this.tbxSeries.Location = new System.Drawing.Point(41, 14);
			this.tbxSeries.Name = "tbxSeries";
			this.tbxSeries.Size = new System.Drawing.Size(43, 22);
			this.tbxSeries.TabIndex = 1;
			this.tbxSeries.Validating += new System.ComponentModel.CancelEventHandler(this.tbxSeries_Validating);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "編號";
			// 
			// btnStorePart
			// 
			this.btnStorePart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnStorePart.Location = new System.Drawing.Point(762, 98);
			this.btnStorePart.Name = "btnStorePart";
			this.btnStorePart.Size = new System.Drawing.Size(109, 23);
			this.btnStorePart.TabIndex = 4;
			this.btnStorePart.Text = "儲存";
			this.btnStorePart.UseVisualStyleBackColor = true;
			this.btnStorePart.Click += new System.EventHandler(this.btnStorePart_Click);
			// 
			// btnImportLH
			// 
			this.btnImportLH.Location = new System.Drawing.Point(298, 98);
			this.btnImportLH.Name = "btnImportLH";
			this.btnImportLH.Size = new System.Drawing.Size(109, 23);
			this.btnImportLH.TabIndex = 5;
			this.btnImportLH.Text = "匯入產品資料";
			this.toolTip1.SetToolTip(this.btnImportLH, "從包含有工時資料的Excel檔擷取工時資料匯入");
			this.btnImportLH.UseVisualStyleBackColor = true;
			this.btnImportLH.Click += new System.EventHandler(this.btnImportLH_Click);
			// 
			// bsSeriesCbx
			// 
			this.bsSeriesCbx.Sort = "編號";
			// 
			// btnUndo
			// 
			this.btnUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnUndo.Location = new System.Drawing.Point(647, 98);
			this.btnUndo.Name = "btnUndo";
			this.btnUndo.Size = new System.Drawing.Size(109, 23);
			this.btnUndo.TabIndex = 6;
			this.btnUndo.Text = "復原變更";
			this.toolTip1.SetToolTip(this.btnUndo, "復原上次儲存以來的所有變更");
			this.btnUndo.UseVisualStyleBackColor = true;
			this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
			// 
			// bsLineCbx
			// 
			this.bsLineCbx.Sort = "產線";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(183, 50);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(230, 12);
			this.label3.TabIndex = 7;
			this.label3.Text = "新增品號資料:  直接輸入在最下面的空白列";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(183, 79);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(271, 12);
			this.label4.TabIndex = 8;
			this.label4.Text = "刪除品號資料:  選取要刪除的品號，按Delete鍵刪除";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(183, 64);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(230, 12);
			this.label5.TabIndex = 9;
			this.label5.Text = "編輯品號資料:  直接在下方視窗中進行編輯";
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(746, 79);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(125, 12);
			this.label6.TabIndex = 10;
			this.label6.Text = "更改完畢後請點選儲存";
			// 
			// col系列編號
			// 
			this.col系列編號.DataPropertyName = "系列編號";
			this.col系列編號.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
			this.col系列編號.HeaderText = "系列編號";
			this.col系列編號.Name = "col系列編號";
			this.col系列編號.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.col系列編號.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.col系列編號.Width = 60;
			// 
			// col系列代號
			// 
			this.col系列代號.DataPropertyName = "系列代號";
			dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
			this.col系列代號.DefaultCellStyle = dataGridViewCellStyle4;
			this.col系列代號.HeaderText = "系列代號";
			this.col系列代號.Name = "col系列代號";
			this.col系列代號.ReadOnly = true;
			this.col系列代號.Width = 60;
			// 
			// col品號
			// 
			this.col品號.DataPropertyName = "品號";
			this.col品號.HeaderText = "品號";
			this.col品號.Name = "col品號";
			this.col品號.Width = 60;
			// 
			// col系列名稱
			// 
			this.col系列名稱.DataPropertyName = "系列名稱";
			this.col系列名稱.HeaderText = "系列名稱";
			this.col系列名稱.Name = "col系列名稱";
			this.col系列名稱.Visible = false;
			this.col系列名稱.Width = 60;
			// 
			// col品名
			// 
			this.col品名.DataPropertyName = "品名";
			this.col品名.HeaderText = "品名";
			this.col品名.Name = "col品名";
			this.col品名.Width = 60;
			// 
			// col產線
			// 
			this.col產線.DataPropertyName = "產線";
			this.col產線.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
			this.col產線.HeaderText = "產線";
			this.col產線.Name = "col產線";
			this.col產線.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.col產線.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.col產線.Width = 60;
			// 
			// col工時
			// 
			this.col工時.DataPropertyName = "工時";
			dataGridViewCellStyle5.Format = "0.##";
			dataGridViewCellStyle5.NullValue = null;
			this.col工時.DefaultCellStyle = dataGridViewCellStyle5;
			this.col工時.HeaderText = "工時";
			this.col工時.Name = "col工時";
			this.col工時.Width = 60;
			// 
			// col系統時薪
			// 
			this.col系統時薪.DataPropertyName = "單位標準工資";
			dataGridViewCellStyle6.Format = "0.##";
			this.col系統時薪.DefaultCellStyle = dataGridViewCellStyle6;
			this.col系統時薪.HeaderText = "系統時薪";
			this.col系統時薪.Name = "col系統時薪";
			this.col系統時薪.Width = 60;
			// 
			// col標準工資
			// 
			this.col標準工資.DataPropertyName = "標準工資";
			dataGridViewCellStyle7.Format = "0.##";
			this.col標準工資.DefaultCellStyle = dataGridViewCellStyle7;
			this.col標準工資.HeaderText = "標準工資";
			this.col標準工資.Name = "col標準工資";
			this.col標準工資.Width = 60;
			// 
			// ProductForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(877, 598);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnUndo);
			this.Controls.Add(this.btnImportLH);
			this.Controls.Add(this.btnStorePart);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnDisplayAllPart);
			this.Controls.Add(this.dgvPart);
			this.Controls.Add(this.dgvSeries);
			this.MinimumSize = new System.Drawing.Size(660, 495);
			this.Name = "ProductForm";
			this.ShowIcon = false;
			this.Text = "產品管理";
			this.Load += new System.EventHandler(this.ProductForm_Load);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProductForm_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.dgvSeries)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bsSeries)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvPart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bsPart)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.bsSeriesCbx)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bsLineCbx)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSeries;
        private System.Windows.Forms.BindingSource bsSeries;
        private System.Windows.Forms.DataGridView dgvPart;
        private System.Windows.Forms.BindingSource bsPart;
        private System.Windows.Forms.Button btnDisplayAllPart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbxSeriesName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxSeries;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddSeries;
        private System.Windows.Forms.Button btnStoreSeries;
        private System.Windows.Forms.BindingSource bsSeriesCbx;
        private System.Windows.Forms.Button btnStorePart;
        private System.Windows.Forms.Button btnImportLH;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnDelSeries;
        private System.Windows.Forms.BindingSource bsLineCbx;
        private System.Windows.Forms.DataGridViewTextBoxColumn col編號;
        private System.Windows.Forms.DataGridViewTextBoxColumn col代號;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnEditSeries;
		private System.Windows.Forms.Button btnCancelSerials;
		private System.Windows.Forms.DataGridViewComboBoxColumn col系列編號;
		private System.Windows.Forms.DataGridViewTextBoxColumn col系列代號;
		private System.Windows.Forms.DataGridViewTextBoxColumn col品號;
		private System.Windows.Forms.DataGridViewTextBoxColumn col系列名稱;
		private System.Windows.Forms.DataGridViewTextBoxColumn col品名;
		private System.Windows.Forms.DataGridViewComboBoxColumn col產線;
		private System.Windows.Forms.DataGridViewTextBoxColumn col工時;
		private System.Windows.Forms.DataGridViewTextBoxColumn col系統時薪;
		private System.Windows.Forms.DataGridViewTextBoxColumn col標準工資;


    }
}