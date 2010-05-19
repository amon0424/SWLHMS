namespace Mong
{
	partial class NGTipForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.col日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col檢驗日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col工作單號 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col品號 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col客戶 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.QCN = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.待驗數量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col送檢次數 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.SuspendLayout();
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
			this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgv.ColumnHeadersHeight = 20;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col日期,
            this.col檢驗日期,
            this.col工作單號,
            this.col品號,
            this.col客戶,
            this.QCN,
            this.待驗數量,
            this.col送檢次數});
			this.dgv.DataSource = this.bindingSource;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
			dataGridViewCellStyle2.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
			this.dgv.EnableHeadersVisualStyles = false;
			this.dgv.GridColor = System.Drawing.Color.Gainsboro;
			this.dgv.Location = new System.Drawing.Point(12, 12);
			this.dgv.Name = "dgv";
			this.dgv.ReadOnly = true;
			this.dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.CornflowerBlue;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dgv.RowHeadersVisible = false;
			this.dgv.RowHeadersWidth = 20;
			this.dgv.RowTemplate.Height = 20;
			this.dgv.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgv.Size = new System.Drawing.Size(566, 182);
			this.dgv.TabIndex = 33;
			// 
			// col日期
			// 
			this.col日期.DataPropertyName = "日期";
			this.col日期.HeaderText = "送驗日期";
			this.col日期.Name = "col日期";
			this.col日期.ReadOnly = true;
			this.col日期.Width = 65;
			// 
			// col檢驗日期
			// 
			this.col檢驗日期.DataPropertyName = "檢驗日期";
			this.col檢驗日期.HeaderText = "檢驗日期";
			this.col檢驗日期.Name = "col檢驗日期";
			this.col檢驗日期.ReadOnly = true;
			this.col檢驗日期.Width = 65;
			// 
			// col工作單號
			// 
			this.col工作單號.DataPropertyName = "工作單號";
			this.col工作單號.HeaderText = "工作單號";
			this.col工作單號.Name = "col工作單號";
			this.col工作單號.ReadOnly = true;
			this.col工作單號.Width = 65;
			// 
			// col品號
			// 
			this.col品號.DataPropertyName = "品號";
			this.col品號.HeaderText = "生產品號";
			this.col品號.Name = "col品號";
			this.col品號.ReadOnly = true;
			this.col品號.Width = 65;
			// 
			// col客戶
			// 
			this.col客戶.DataPropertyName = "客戶";
			this.col客戶.HeaderText = "客戶";
			this.col客戶.Name = "col客戶";
			this.col客戶.ReadOnly = true;
			this.col客戶.Width = 50;
			// 
			// QCN
			// 
			this.QCN.DataPropertyName = "QCN";
			this.QCN.HeaderText = "QC#";
			this.QCN.Name = "QCN";
			this.QCN.ReadOnly = true;
			this.QCN.Width = 50;
			// 
			// 待驗數量
			// 
			this.待驗數量.DataPropertyName = "待驗數量";
			this.待驗數量.HeaderText = "送驗數量";
			this.待驗數量.Name = "待驗數量";
			this.待驗數量.ReadOnly = true;
			this.待驗數量.Width = 65;
			// 
			// col送檢次數
			// 
			this.col送檢次數.DataPropertyName = "送檢次數";
			this.col送檢次數.HeaderText = "送檢次數";
			this.col送檢次數.Name = "col送檢次數";
			this.col送檢次數.ReadOnly = true;
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Enabled = false;
			this.btnOK.Location = new System.Drawing.Point(422, 205);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 34;
			this.btnOK.Text = "確定";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(503, 205);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 35;
			this.btnCancel.Text = "取消";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// NGTipForm
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(590, 240);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.dgv);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NGTipForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "請選擇欲重新送驗的資料";
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.BindingSource bindingSource;
		private System.Windows.Forms.DataGridViewTextBoxColumn col日期;
		private System.Windows.Forms.DataGridViewTextBoxColumn col檢驗日期;
		private System.Windows.Forms.DataGridViewTextBoxColumn col工作單號;
		private System.Windows.Forms.DataGridViewTextBoxColumn col品號;
		private System.Windows.Forms.DataGridViewTextBoxColumn col客戶;
		private System.Windows.Forms.DataGridViewTextBoxColumn QCN;
		private System.Windows.Forms.DataGridViewTextBoxColumn 待驗數量;
		private System.Windows.Forms.DataGridViewTextBoxColumn col送檢次數;
	}
}