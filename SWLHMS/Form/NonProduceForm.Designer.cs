namespace Mong
{
    partial class NonProduceForm
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
			this.btnDel = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnStore = new System.Windows.Forms.Button();
			this.tbxNPName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbxNPNumber = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.dgvNP = new System.Windows.Forms.DataGridView();
			this.col編號 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col名稱 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label15 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dgvNP)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnDel
			// 
			this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDel.Location = new System.Drawing.Point(115, 3);
			this.btnDel.Name = "btnDel";
			this.btnDel.Size = new System.Drawing.Size(50, 25);
			this.btnDel.TabIndex = 10;
			this.btnDel.Text = "刪除";
			this.btnDel.UseVisualStyleBackColor = true;
			this.btnDel.Click += new System.EventHandler(this.btnDelNP_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAdd.Location = new System.Drawing.Point(59, 3);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(50, 25);
			this.btnAdd.TabIndex = 9;
			this.btnAdd.Text = "新增";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAddNP_Click);
			// 
			// btnStore
			// 
			this.btnStore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnStore.Location = new System.Drawing.Point(171, 3);
			this.btnStore.Name = "btnStore";
			this.btnStore.Size = new System.Drawing.Size(50, 25);
			this.btnStore.TabIndex = 8;
			this.btnStore.Text = "儲存";
			this.btnStore.UseVisualStyleBackColor = true;
			this.btnStore.Click += new System.EventHandler(this.btnStoreNP_Click);
			// 
			// tbxNPName
			// 
			this.tbxNPName.Location = new System.Drawing.Point(157, 43);
			this.tbxNPName.Name = "tbxNPName";
			this.tbxNPName.Size = new System.Drawing.Size(181, 22);
			this.tbxNPName.TabIndex = 7;
			this.tbxNPName.Validated += new System.EventHandler(this.tbxNPName_Validated);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(122, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 12);
			this.label2.TabIndex = 6;
			this.label2.Text = "名稱";
			// 
			// tbxNPNumber
			// 
			this.tbxNPNumber.Location = new System.Drawing.Point(39, 43);
			this.tbxNPNumber.Name = "tbxNPNumber";
			this.tbxNPNumber.Size = new System.Drawing.Size(75, 22);
			this.tbxNPNumber.TabIndex = 5;
			this.tbxNPNumber.Validated += new System.EventHandler(this.tbxNPNumber_Validated);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 12);
			this.label1.TabIndex = 4;
			this.label1.Text = "編號";
			// 
			// dgvNP
			// 
			this.dgvNP.AllowUserToAddRows = false;
			this.dgvNP.AllowUserToDeleteRows = false;
			this.dgvNP.AllowUserToResizeRows = false;
			this.dgvNP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvNP.AutoGenerateColumns = false;
			this.dgvNP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvNP.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.dgvNP.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvNP.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvNP.ColumnHeadersHeight = 20;
			this.dgvNP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dgvNP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col編號,
            this.col名稱});
			this.dgvNP.DataSource = this.bindingSource;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
			dataGridViewCellStyle2.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvNP.DefaultCellStyle = dataGridViewCellStyle2;
			this.dgvNP.EnableHeadersVisualStyles = false;
			this.dgvNP.GridColor = System.Drawing.Color.LightGray;
			this.dgvNP.Location = new System.Drawing.Point(3, 71);
			this.dgvNP.Name = "dgvNP";
			this.dgvNP.ReadOnly = true;
			this.dgvNP.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.CornflowerBlue;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvNP.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dgvNP.RowHeadersVisible = false;
			this.dgvNP.RowHeadersWidth = 20;
			this.dgvNP.RowTemplate.Height = 20;
			this.dgvNP.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvNP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvNP.Size = new System.Drawing.Size(336, 180);
			this.dgvNP.TabIndex = 3;
			// 
			// col編號
			// 
			this.col編號.DataPropertyName = "編號";
			this.col編號.FillWeight = 50F;
			this.col編號.HeaderText = "編號";
			this.col編號.Name = "col編號";
			this.col編號.ReadOnly = true;
			// 
			// col名稱
			// 
			this.col名稱.DataPropertyName = "名稱";
			this.col名稱.HeaderText = "名稱";
			this.col名稱.Name = "col名稱";
			this.col名稱.ReadOnly = true;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.btnEdit);
			this.flowLayoutPanel1.Controls.Add(this.btnAdd);
			this.flowLayoutPanel1.Controls.Add(this.btnDel);
			this.flowLayoutPanel1.Controls.Add(this.btnStore);
			this.flowLayoutPanel1.Controls.Add(this.btnCancel);
			this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 4);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(284, 30);
			this.flowLayoutPanel1.TabIndex = 5;
			// 
			// btnEdit
			// 
			this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEdit.Location = new System.Drawing.Point(3, 3);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(50, 25);
			this.btnEdit.TabIndex = 11;
			this.btnEdit.Text = "編輯";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEditNP_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(227, 3);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(50, 25);
			this.btnCancel.TabIndex = 12;
			this.btnCancel.Text = "取消";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancelNP_Click);
			// 
			// label15
			// 
			this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label15.Location = new System.Drawing.Point(3, 37);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(337, 2);
			this.label15.TabIndex = 44;
			// 
			// NonProduceForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(342, 254);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.tbxNPName);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbxNPNumber);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dgvNP);
			this.MinimumSize = new System.Drawing.Size(350, 250);
			this.Name = "NonProduceForm";
			this.ShowIcon = false;
			this.Text = "非生產項目管理";
			this.Load += new System.EventHandler(this.NonProduceForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvNP)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnStore;
        private System.Windows.Forms.TextBox tbxNPName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxNPNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvNP;
        private System.Windows.Forms.DataGridViewTextBoxColumn col編號;
        private System.Windows.Forms.DataGridViewTextBoxColumn col名稱;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label15;
    }
}