namespace Mong
{
    partial class LaborForm
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
            this.bsLabor = new System.Windows.Forms.BindingSource(this.components);
            this.dgvLabor = new System.Windows.Forms.DataGridView();
            this.col編號 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col姓名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col薪水 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col產線 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsLineCbx = new System.Windows.Forms.BindingSource(this.components);
            this.cbxLaborLine = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxLaborWage = new System.Windows.Forms.TextBox();
            this.btnDelLabor = new System.Windows.Forms.Button();
            this.btnAddLabor = new System.Windows.Forms.Button();
            this.btnStoreLabor = new System.Windows.Forms.Button();
            this.tbxLaborName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxLaborNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnEditLabor = new System.Windows.Forms.Button();
            this.btnCancelLabor = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsLabor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLabor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLineCbx)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLabor
            // 
            this.dgvLabor.AllowUserToAddRows = false;
            this.dgvLabor.AllowUserToDeleteRows = false;
            this.dgvLabor.AllowUserToResizeRows = false;
            this.dgvLabor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLabor.AutoGenerateColumns = false;
            this.dgvLabor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLabor.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvLabor.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLabor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLabor.ColumnHeadersHeight = 20;
            this.dgvLabor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLabor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col編號,
            this.col姓名,
            this.col薪水,
            this.col產線});
            this.dgvLabor.DataSource = this.bsLabor;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLabor.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLabor.EnableHeadersVisualStyles = false;
            this.dgvLabor.GridColor = System.Drawing.Color.LightGray;
            this.dgvLabor.Location = new System.Drawing.Point(3, 99);
            this.dgvLabor.Name = "dgvLabor";
            this.dgvLabor.ReadOnly = true;
            this.dgvLabor.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLabor.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvLabor.RowHeadersVisible = false;
            this.dgvLabor.RowHeadersWidth = 20;
            this.dgvLabor.RowTemplate.Height = 20;
            this.dgvLabor.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLabor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLabor.Size = new System.Drawing.Size(316, 202);
            this.dgvLabor.TabIndex = 2;
            // 
            // col編號
            // 
            this.col編號.DataPropertyName = "編號";
            this.col編號.HeaderText = "編號";
            this.col編號.Name = "col編號";
            this.col編號.ReadOnly = true;
            // 
            // col姓名
            // 
            this.col姓名.DataPropertyName = "姓名";
            this.col姓名.HeaderText = "姓名";
            this.col姓名.Name = "col姓名";
            this.col姓名.ReadOnly = true;
            // 
            // col薪水
            // 
            this.col薪水.DataPropertyName = "薪水";
            dataGridViewCellStyle2.Format = "0.#";
            this.col薪水.DefaultCellStyle = dataGridViewCellStyle2;
            this.col薪水.HeaderText = "薪水";
            this.col薪水.Name = "col薪水";
            this.col薪水.ReadOnly = true;
            // 
            // col產線
            // 
            this.col產線.DataPropertyName = "產線";
            this.col產線.FillWeight = 80F;
            this.col產線.HeaderText = "產線";
            this.col產線.Name = "col產線";
            this.col產線.ReadOnly = true;
            this.col產線.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col產線.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cbxLaborLine
            // 
            this.cbxLaborLine.DataSource = this.bsLineCbx;
            this.cbxLaborLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLaborLine.FormattingEnabled = true;
            this.cbxLaborLine.Location = new System.Drawing.Point(199, 73);
            this.cbxLaborLine.Name = "cbxLaborLine";
            this.cbxLaborLine.Size = new System.Drawing.Size(114, 20);
            this.cbxLaborLine.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(165, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "產線";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "薪水";
            // 
            // tbxLaborWage
            // 
            this.tbxLaborWage.Location = new System.Drawing.Point(41, 72);
            this.tbxLaborWage.Name = "tbxLaborWage";
            this.tbxLaborWage.Size = new System.Drawing.Size(114, 22);
            this.tbxLaborWage.TabIndex = 11;
            this.tbxLaborWage.Validating += new System.ComponentModel.CancelEventHandler(this.tbxLaborWage_Validating);
            // 
            // btnDelLabor
            // 
            this.btnDelLabor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelLabor.Location = new System.Drawing.Point(115, 3);
            this.btnDelLabor.Name = "btnDelLabor";
            this.btnDelLabor.Size = new System.Drawing.Size(50, 25);
            this.btnDelLabor.TabIndex = 10;
            this.btnDelLabor.Text = "刪除";
            this.btnDelLabor.UseVisualStyleBackColor = true;
            this.btnDelLabor.Click += new System.EventHandler(this.btnDelLabor_Click);
            // 
            // btnAddLabor
            // 
            this.btnAddLabor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddLabor.Location = new System.Drawing.Point(59, 3);
            this.btnAddLabor.Name = "btnAddLabor";
            this.btnAddLabor.Size = new System.Drawing.Size(50, 25);
            this.btnAddLabor.TabIndex = 9;
            this.btnAddLabor.Text = "新增";
            this.btnAddLabor.UseVisualStyleBackColor = true;
            this.btnAddLabor.Click += new System.EventHandler(this.btnAddLabor_Click);
            // 
            // btnStoreLabor
            // 
            this.btnStoreLabor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStoreLabor.Location = new System.Drawing.Point(171, 3);
            this.btnStoreLabor.Name = "btnStoreLabor";
            this.btnStoreLabor.Size = new System.Drawing.Size(50, 25);
            this.btnStoreLabor.TabIndex = 8;
            this.btnStoreLabor.Text = "儲存";
            this.btnStoreLabor.UseVisualStyleBackColor = true;
            this.btnStoreLabor.Click += new System.EventHandler(this.btnStoreLabor_Click);
            // 
            // tbxLaborName
            // 
            this.tbxLaborName.Location = new System.Drawing.Point(199, 42);
            this.tbxLaborName.Name = "tbxLaborName";
            this.tbxLaborName.Size = new System.Drawing.Size(114, 22);
            this.tbxLaborName.TabIndex = 7;
            this.tbxLaborName.Validated += new System.EventHandler(this.tbxLaborName_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "名稱";
            // 
            // tbxLaborNumber
            // 
            this.tbxLaborNumber.Location = new System.Drawing.Point(41, 42);
            this.tbxLaborNumber.Name = "tbxLaborNumber";
            this.tbxLaborNumber.Size = new System.Drawing.Size(114, 22);
            this.tbxLaborNumber.TabIndex = 5;
            this.tbxLaborNumber.Validated += new System.EventHandler(this.tbxLaborNumber_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "編號";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnEditLabor);
            this.flowLayoutPanel1.Controls.Add(this.btnAddLabor);
            this.flowLayoutPanel1.Controls.Add(this.btnDelLabor);
            this.flowLayoutPanel1.Controls.Add(this.btnStoreLabor);
            this.flowLayoutPanel1.Controls.Add(this.btnCancelLabor);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(286, 29);
            this.flowLayoutPanel1.TabIndex = 15;
            // 
            // btnEditLabor
            // 
            this.btnEditLabor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditLabor.Location = new System.Drawing.Point(3, 3);
            this.btnEditLabor.Name = "btnEditLabor";
            this.btnEditLabor.Size = new System.Drawing.Size(50, 25);
            this.btnEditLabor.TabIndex = 11;
            this.btnEditLabor.Text = "編輯";
            this.btnEditLabor.UseVisualStyleBackColor = true;
            this.btnEditLabor.Click += new System.EventHandler(this.btnEditLabor_Click);
            // 
            // btnCancelLabor
            // 
            this.btnCancelLabor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelLabor.Location = new System.Drawing.Point(227, 3);
            this.btnCancelLabor.Name = "btnCancelLabor";
            this.btnCancelLabor.Size = new System.Drawing.Size(50, 25);
            this.btnCancelLabor.TabIndex = 12;
            this.btnCancelLabor.Text = "取消";
            this.btnCancelLabor.UseVisualStyleBackColor = true;
            this.btnCancelLabor.Click += new System.EventHandler(this.btnCancelLabor_Click);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label15.Location = new System.Drawing.Point(3, 35);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(314, 2);
            this.label15.TabIndex = 42;
            // 
            // LaborForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 303);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.cbxLaborLine);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxLaborNumber);
            this.Controls.Add(this.tbxLaborWage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxLaborName);
            this.Controls.Add(this.dgvLabor);
            this.MinimumSize = new System.Drawing.Size(330, 200);
            this.Name = "LaborForm";
            this.ShowIcon = false;
            this.Text = "員工管理";
            this.Load += new System.EventHandler(this.LaborForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsLabor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLabor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLineCbx)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bsLabor;
        private System.Windows.Forms.DataGridView dgvLabor;
        private System.Windows.Forms.BindingSource bsLineCbx;
        private System.Windows.Forms.ComboBox cbxLaborLine;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxLaborWage;
        private System.Windows.Forms.Button btnDelLabor;
        private System.Windows.Forms.Button btnAddLabor;
        private System.Windows.Forms.Button btnStoreLabor;
        private System.Windows.Forms.TextBox tbxLaborName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxLaborNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col編號;
        private System.Windows.Forms.DataGridViewTextBoxColumn col姓名;
        private System.Windows.Forms.DataGridViewTextBoxColumn col薪水;
        private System.Windows.Forms.DataGridViewTextBoxColumn col產線;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnEditLabor;
        private System.Windows.Forms.Button btnCancelLabor;
        private System.Windows.Forms.Label label15;
    }
}