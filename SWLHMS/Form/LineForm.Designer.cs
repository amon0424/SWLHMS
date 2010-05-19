namespace Mong
{
    partial class LineForm
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
            this.dgvLine = new System.Windows.Forms.DataGridView();
            this.col產線 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col代號 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsLine = new System.Windows.Forms.BindingSource(this.components);
            this.btnDelLine = new System.Windows.Forms.Button();
            this.btnAddLine = new System.Windows.Forms.Button();
            this.btnStoreLine = new System.Windows.Forms.Button();
            this.tbxLineName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxLine = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnEditLine = new System.Windows.Forms.Button();
            this.btnCancelLine = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLine)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLine
            // 
            this.dgvLine.AllowUserToAddRows = false;
            this.dgvLine.AllowUserToDeleteRows = false;
            this.dgvLine.AllowUserToResizeRows = false;
            this.dgvLine.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLine.AutoGenerateColumns = false;
            this.dgvLine.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLine.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvLine.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLine.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLine.ColumnHeadersHeight = 20;
            this.dgvLine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col產線,
            this.col代號});
            this.dgvLine.DataSource = this.bsLine;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLine.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLine.EnableHeadersVisualStyles = false;
            this.dgvLine.GridColor = System.Drawing.Color.LightGray;
            this.dgvLine.Location = new System.Drawing.Point(3, 71);
            this.dgvLine.Name = "dgvLine";
            this.dgvLine.ReadOnly = true;
            this.dgvLine.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLine.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLine.RowHeadersVisible = false;
            this.dgvLine.RowHeadersWidth = 20;
            this.dgvLine.RowTemplate.Height = 20;
            this.dgvLine.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLine.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLine.Size = new System.Drawing.Size(296, 208);
            this.dgvLine.TabIndex = 1;
            // 
            // col產線
            // 
            this.col產線.DataPropertyName = "產線";
            this.col產線.FillWeight = 50F;
            this.col產線.HeaderText = "產線";
            this.col產線.Name = "col產線";
            this.col產線.ReadOnly = true;
            // 
            // col代號
            // 
            this.col代號.DataPropertyName = "代號";
            this.col代號.HeaderText = "代號";
            this.col代號.Name = "col代號";
            this.col代號.ReadOnly = true;
            // 
            // btnDelLine
            // 
            this.btnDelLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelLine.Location = new System.Drawing.Point(115, 3);
            this.btnDelLine.Name = "btnDelLine";
            this.btnDelLine.Size = new System.Drawing.Size(50, 25);
            this.btnDelLine.TabIndex = 10;
            this.btnDelLine.Text = "刪除";
            this.btnDelLine.UseVisualStyleBackColor = true;
            this.btnDelLine.Click += new System.EventHandler(this.btnDelLine_Click);
            // 
            // btnAddLine
            // 
            this.btnAddLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddLine.Location = new System.Drawing.Point(59, 3);
            this.btnAddLine.Name = "btnAddLine";
            this.btnAddLine.Size = new System.Drawing.Size(50, 25);
            this.btnAddLine.TabIndex = 9;
            this.btnAddLine.Text = "新增";
            this.btnAddLine.UseVisualStyleBackColor = true;
            this.btnAddLine.Click += new System.EventHandler(this.btnAddLine_Click);
            // 
            // btnStoreLine
            // 
            this.btnStoreLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStoreLine.Location = new System.Drawing.Point(171, 3);
            this.btnStoreLine.Name = "btnStoreLine";
            this.btnStoreLine.Size = new System.Drawing.Size(50, 25);
            this.btnStoreLine.TabIndex = 8;
            this.btnStoreLine.Text = "儲存";
            this.btnStoreLine.UseVisualStyleBackColor = true;
            this.btnStoreLine.Click += new System.EventHandler(this.btnStoreLine_Click);
            // 
            // tbxLineName
            // 
            this.tbxLineName.Location = new System.Drawing.Point(147, 43);
            this.tbxLineName.Name = "tbxLineName";
            this.tbxLineName.Size = new System.Drawing.Size(151, 22);
            this.tbxLineName.TabIndex = 7;
            this.tbxLineName.Validated += new System.EventHandler(this.tbxLineName_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "代號";
            // 
            // tbxLine
            // 
            this.tbxLine.Location = new System.Drawing.Point(39, 43);
            this.tbxLine.Name = "tbxLine";
            this.tbxLine.Size = new System.Drawing.Size(62, 22);
            this.tbxLine.TabIndex = 5;
            this.tbxLine.Validated += new System.EventHandler(this.tbxLine_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "產線";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnEditLine);
            this.flowLayoutPanel1.Controls.Add(this.btnAddLine);
            this.flowLayoutPanel1.Controls.Add(this.btnDelLine);
            this.flowLayoutPanel1.Controls.Add(this.btnStoreLine);
            this.flowLayoutPanel1.Controls.Add(this.btnCancelLine);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(282, 31);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // btnEditLine
            // 
            this.btnEditLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditLine.Location = new System.Drawing.Point(3, 3);
            this.btnEditLine.Name = "btnEditLine";
            this.btnEditLine.Size = new System.Drawing.Size(50, 25);
            this.btnEditLine.TabIndex = 11;
            this.btnEditLine.Text = "編輯";
            this.btnEditLine.UseVisualStyleBackColor = true;
            this.btnEditLine.Click += new System.EventHandler(this.btnEditLine_Click);
            // 
            // btnCancelLine
            // 
            this.btnCancelLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelLine.Location = new System.Drawing.Point(227, 3);
            this.btnCancelLine.Name = "btnCancelLine";
            this.btnCancelLine.Size = new System.Drawing.Size(50, 25);
            this.btnCancelLine.TabIndex = 12;
            this.btnCancelLine.Text = "取消";
            this.btnCancelLine.UseVisualStyleBackColor = true;
            this.btnCancelLine.Click += new System.EventHandler(this.btnCancelLine_Click);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label15.Location = new System.Drawing.Point(3, 36);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(296, 2);
            this.label15.TabIndex = 43;
            // 
            // LineForm
            // 
            this.ClientSize = new System.Drawing.Size(302, 281);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxLineName);
            this.Controls.Add(this.tbxLine);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvLine);
            this.MinimumSize = new System.Drawing.Size(310, 200);
            this.Name = "LineForm";
            this.ShowIcon = false;
            this.Text = "產線管理";
            this.Load += new System.EventHandler(this.LineForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLine)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn col產線;
        private System.Windows.Forms.DataGridViewTextBoxColumn col代號;
        private System.Windows.Forms.BindingSource bsLine;
        private System.Windows.Forms.TextBox tbxLineName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxLine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelLine;
        private System.Windows.Forms.Button btnAddLine;
        private System.Windows.Forms.Button btnStoreLine;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnEditLine;
        private System.Windows.Forms.Button btnCancelLine;
        private System.Windows.Forms.Label label15;
    }
}