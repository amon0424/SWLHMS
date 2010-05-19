namespace Mong
{
    partial class UserForm
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
			this.label15 = new System.Windows.Forms.Label();
			this.txtUsername = new System.Windows.Forms.TextBox();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnDel = new System.Windows.Forms.Button();
			this.btnStore = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.col帳號 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col身分 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col密碼 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col權限 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.label3 = new System.Windows.Forms.Label();
			this.cbxAuthority = new System.Windows.Forms.ComboBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.flowLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// label15
			// 
			this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label15.Location = new System.Drawing.Point(2, 36);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(442, 2);
			this.label15.TabIndex = 51;
			// 
			// txtUsername
			// 
			this.txtUsername.Location = new System.Drawing.Point(64, 42);
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.Size = new System.Drawing.Size(89, 22);
			this.txtUsername.TabIndex = 1;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.btnEdit);
			this.flowLayoutPanel1.Controls.Add(this.btnAdd);
			this.flowLayoutPanel1.Controls.Add(this.btnDel);
			this.flowLayoutPanel1.Controls.Add(this.btnStore);
			this.flowLayoutPanel1.Controls.Add(this.btnCancel);
			this.flowLayoutPanel1.Location = new System.Drawing.Point(2, 3);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(284, 30);
			this.flowLayoutPanel1.TabIndex = 0;
			// 
			// btnEdit
			// 
			this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEdit.Location = new System.Drawing.Point(3, 3);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(50, 25);
			this.btnEdit.TabIndex = 0;
			this.btnEdit.Text = "編輯";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAdd.Location = new System.Drawing.Point(59, 3);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(50, 25);
			this.btnAdd.TabIndex = 1;
			this.btnAdd.Text = "新增";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Visible = false;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnDel
			// 
			this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDel.Location = new System.Drawing.Point(115, 3);
			this.btnDel.Name = "btnDel";
			this.btnDel.Size = new System.Drawing.Size(50, 25);
			this.btnDel.TabIndex = 2;
			this.btnDel.Text = "刪除";
			this.btnDel.UseVisualStyleBackColor = true;
			this.btnDel.Visible = false;
			this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
			// 
			// btnStore
			// 
			this.btnStore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnStore.Location = new System.Drawing.Point(171, 3);
			this.btnStore.Name = "btnStore";
			this.btnStore.Size = new System.Drawing.Size(50, 25);
			this.btnStore.TabIndex = 3;
			this.btnStore.Text = "儲存";
			this.btnStore.UseVisualStyleBackColor = true;
			this.btnStore.Click += new System.EventHandler(this.btnStore_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(227, 3);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(50, 25);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "取消";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(5, 47);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 12);
			this.label2.TabIndex = 49;
			this.label2.Text = "登入名稱";
			// 
			// dgv
			// 
			this.dgv.AllowUserToAddRows = false;
			this.dgv.AllowUserToDeleteRows = false;
			this.dgv.AllowUserToResizeRows = false;
			this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dgv.AutoGenerateColumns = false;
			this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle10.BackColor = System.Drawing.Color.SteelBlue;
			dataGridViewCellStyle10.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
			this.dgv.ColumnHeadersHeight = 20;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col帳號,
            this.col身分,
            this.col密碼,
            this.col權限});
			this.dgv.DataSource = this.bindingSource;
			dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
			dataGridViewCellStyle11.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgv.DefaultCellStyle = dataGridViewCellStyle11;
			this.dgv.EnableHeadersVisualStyles = false;
			this.dgv.GridColor = System.Drawing.Color.LightGray;
			this.dgv.Location = new System.Drawing.Point(5, 70);
			this.dgv.Name = "dgv";
			this.dgv.ReadOnly = true;
			this.dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle12.BackColor = System.Drawing.Color.CornflowerBlue;
			dataGridViewCellStyle12.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			dataGridViewCellStyle12.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
			this.dgv.RowHeadersVisible = false;
			this.dgv.RowHeadersWidth = 20;
			this.dgv.RowTemplate.Height = 20;
			this.dgv.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgv.Size = new System.Drawing.Size(437, 176);
			this.dgv.TabIndex = 45;
			this.dgv.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_CellFormatting);
			// 
			// col帳號
			// 
			this.col帳號.DataPropertyName = "帳號";
			this.col帳號.FillWeight = 50F;
			this.col帳號.HeaderText = "登入名稱";
			this.col帳號.Name = "col帳號";
			this.col帳號.ReadOnly = true;
			// 
			// col身分
			// 
			this.col身分.DataPropertyName = "身分";
			this.col身分.HeaderText = "身分";
			this.col身分.Name = "col身分";
			this.col身分.ReadOnly = true;
			// 
			// col密碼
			// 
			this.col密碼.DataPropertyName = "密碼";
			this.col密碼.HeaderText = "密碼";
			this.col密碼.Name = "col密碼";
			this.col密碼.ReadOnly = true;
			this.col密碼.Visible = false;
			// 
			// col權限
			// 
			this.col權限.DataPropertyName = "權限";
			this.col權限.HeaderText = "權限";
			this.col權限.Name = "col權限";
			this.col權限.ReadOnly = true;
			this.col權限.Visible = false;
			// 
			// bindingSource
			// 
			this.bindingSource.CurrentChanged += new System.EventHandler(this.bindingSource_CurrentChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(300, 47);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(29, 12);
			this.label3.TabIndex = 52;
			this.label3.Text = "身份";
			// 
			// cbxAuthority
			// 
			this.cbxAuthority.FormattingEnabled = true;
			this.cbxAuthority.Items.AddRange(new object[] {
            "系統管理員",
            "一般管理員",
            "領班",
            "QA"});
			this.cbxAuthority.Location = new System.Drawing.Point(335, 43);
			this.cbxAuthority.Name = "cbxAuthority";
			this.cbxAuthority.Size = new System.Drawing.Size(107, 20);
			this.cbxAuthority.TabIndex = 3;
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(199, 42);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(89, 22);
			this.txtPassword.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(164, 47);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 12);
			this.label1.TabIndex = 54;
			this.label1.Text = "密碼";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(5, 70);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(293, 12);
			this.label4.TabIndex = 55;
			this.label4.Text = "深色項目為預設登入項目，無法變更其登入名稱或刪除";
			this.label4.Visible = false;
			// 
			// UserForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(446, 251);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cbxAuthority);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.txtUsername);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dgv);
			this.Name = "UserForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "使用者管理";
			this.Load += new System.EventHandler(this.UserForm_Load);
			this.flowLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox txtUsername;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnDel;
		private System.Windows.Forms.Button btnStore;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbxAuthority;
		private System.Windows.Forms.BindingSource bindingSource;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridViewTextBoxColumn col帳號;
		private System.Windows.Forms.DataGridViewTextBoxColumn col身分;
		private System.Windows.Forms.DataGridViewTextBoxColumn col密碼;
		private System.Windows.Forms.DataGridViewTextBoxColumn col權限;
		private System.Windows.Forms.Label label4;
    }
}