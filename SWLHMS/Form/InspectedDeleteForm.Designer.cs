namespace Mong
{
	partial class InspectedDeleteForm
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.col刪除 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.col項次 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col檢驗日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col待驗工作單 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col料號 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col客戶 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col序號 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col總數量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col已完成 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.待驗數量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colQCN = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.btnSearch = new System.Windows.Forms.Button();
			this.btnSend = new System.Windows.Forms.Button();
			this.dtpDate = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.txtQCN = new System.Windows.Forms.TextBox();
			this.txtPartNumber = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.ckbDate = new System.Windows.Forms.CheckBox();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
			this.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
			this.dgv.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
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
            this.col刪除,
            this.col項次,
            this.col日期,
            this.col檢驗日期,
            this.col待驗工作單,
            this.col料號,
            this.col客戶,
            this.col序號,
            this.col總數量,
            this.col已完成,
            this.待驗數量,
            this.colQCN});
			this.dgv.DataSource = this.bindingSource;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
			dataGridViewCellStyle4.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgv.DefaultCellStyle = dataGridViewCellStyle4;
			this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.dgv.EnableHeadersVisualStyles = false;
			this.dgv.GridColor = System.Drawing.Color.LightGray;
			this.dgv.Location = new System.Drawing.Point(12, 133);
			this.dgv.Name = "dgv";
			this.dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle5.BackColor = System.Drawing.Color.CornflowerBlue;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
			this.dgv.RowHeadersVisible = false;
			this.dgv.RowHeadersWidth = 20;
			this.dgv.RowTemplate.Height = 20;
			this.dgv.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgv.Size = new System.Drawing.Size(808, 223);
			this.dgv.TabIndex = 35;
			this.dgv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_KeyDown);
			// 
			// col刪除
			// 
			this.col刪除.DataPropertyName = "刪除";
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle2.NullValue = false;
			this.col刪除.DefaultCellStyle = dataGridViewCellStyle2;
			this.col刪除.Frozen = true;
			this.col刪除.HeaderText = "刪除";
			this.col刪除.Name = "col刪除";
			this.col刪除.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.col刪除.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.col刪除.Width = 40;
			// 
			// col項次
			// 
			this.col項次.DataPropertyName = "項次";
			this.col項次.HeaderText = "項次";
			this.col項次.Name = "col項次";
			this.col項次.ReadOnly = true;
			this.col項次.Width = 40;
			// 
			// col日期
			// 
			this.col日期.DataPropertyName = "單據日期";
			this.col日期.HeaderText = "單據日期";
			this.col日期.Name = "col日期";
			this.col日期.ReadOnly = true;
			this.col日期.Width = 60;
			// 
			// col檢驗日期
			// 
			this.col檢驗日期.DataPropertyName = "檢驗日期";
			this.col檢驗日期.HeaderText = "檢驗日期";
			this.col檢驗日期.Name = "col檢驗日期";
			this.col檢驗日期.ReadOnly = true;
			// 
			// col待驗工作單
			// 
			this.col待驗工作單.DataPropertyName = "工作單號";
			this.col待驗工作單.HeaderText = "工作單號";
			this.col待驗工作單.Name = "col待驗工作單";
			this.col待驗工作單.ReadOnly = true;
			this.col待驗工作單.Width = 60;
			// 
			// col料號
			// 
			this.col料號.DataPropertyName = "品號";
			this.col料號.HeaderText = "料號";
			this.col料號.Name = "col料號";
			this.col料號.ReadOnly = true;
			this.col料號.Width = 50;
			// 
			// col客戶
			// 
			this.col客戶.DataPropertyName = "客戶";
			this.col客戶.HeaderText = "客戶";
			this.col客戶.Name = "col客戶";
			this.col客戶.ReadOnly = true;
			this.col客戶.Width = 50;
			// 
			// col序號
			// 
			this.col序號.DataPropertyName = "序號";
			this.col序號.HeaderText = "序號";
			this.col序號.Name = "col序號";
			this.col序號.ReadOnly = true;
			this.col序號.Width = 50;
			// 
			// col總數量
			// 
			this.col總數量.DataPropertyName = "總數量";
			dataGridViewCellStyle3.Format = "0.#";
			this.col總數量.DefaultCellStyle = dataGridViewCellStyle3;
			this.col總數量.HeaderText = "總數量";
			this.col總數量.Name = "col總數量";
			this.col總數量.ReadOnly = true;
			this.col總數量.Width = 50;
			// 
			// col已完成
			// 
			this.col已完成.DataPropertyName = "已完成";
			this.col已完成.HeaderText = "已完成";
			this.col已完成.Name = "col已完成";
			this.col已完成.ReadOnly = true;
			this.col已完成.Width = 50;
			// 
			// 待驗數量
			// 
			this.待驗數量.DataPropertyName = "待驗數量";
			this.待驗數量.HeaderText = "送驗數量";
			this.待驗數量.Name = "待驗數量";
			this.待驗數量.ReadOnly = true;
			this.待驗數量.Width = 65;
			// 
			// colQCN
			// 
			this.colQCN.DataPropertyName = "QCN";
			this.colQCN.HeaderText = "QC#";
			this.colQCN.Name = "colQCN";
			this.colQCN.ReadOnly = true;
			this.colQCN.Width = 50;
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(244, 90);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(82, 23);
			this.btnSearch.TabIndex = 49;
			this.btnSearch.Text = "查詢";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// btnSend
			// 
			this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSend.Location = new System.Drawing.Point(738, 364);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(82, 23);
			this.btnSend.TabIndex = 50;
			this.btnSend.Text = "儲存";
			this.btnSend.UseVisualStyleBackColor = true;
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			// 
			// dtpDate
			// 
			this.dtpDate.Enabled = false;
			this.dtpDate.Location = new System.Drawing.Point(101, 91);
			this.dtpDate.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.dtpDate.Name = "dtpDate";
			this.dtpDate.Size = new System.Drawing.Size(123, 22);
			this.dtpDate.TabIndex = 51;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(46, 40);
			this.label1.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(27, 12);
			this.label1.TabIndex = 53;
			this.label1.Text = "QC#";
			// 
			// txtQCN
			// 
			this.txtQCN.Location = new System.Drawing.Point(80, 35);
			this.txtQCN.Name = "txtQCN";
			this.txtQCN.Size = new System.Drawing.Size(144, 22);
			this.txtQCN.TabIndex = 52;
			// 
			// txtPartNumber
			// 
			this.txtPartNumber.Location = new System.Drawing.Point(80, 63);
			this.txtPartNumber.Name = "txtPartNumber";
			this.txtPartNumber.Size = new System.Drawing.Size(144, 22);
			this.txtPartNumber.TabIndex = 54;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(44, 68);
			this.label2.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 12);
			this.label2.TabIndex = 55;
			this.label2.Text = "料號";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(20, 96);
			this.label3.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 12);
			this.label3.TabIndex = 56;
			this.label3.Text = "檢驗日期";
			// 
			// ckbDate
			// 
			this.ckbDate.AutoSize = true;
			this.ckbDate.Location = new System.Drawing.Point(80, 95);
			this.ckbDate.Name = "ckbDate";
			this.ckbDate.Size = new System.Drawing.Size(15, 14);
			this.ckbDate.TabIndex = 57;
			this.ckbDate.UseVisualStyleBackColor = true;
			this.ckbDate.CheckedChanged += new System.EventHandler(this.ckbDate_CheckedChanged);
			// 
			// label12
			// 
			this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label12.Location = new System.Drawing.Point(12, 122);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(808, 2);
			this.label12.TabIndex = 58;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold);
			this.label13.Location = new System.Drawing.Point(9, 9);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(76, 16);
			this.label13.TabIndex = 59;
			this.label13.Text = "查詢條件";
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.DataPropertyName = "項次";
			this.dataGridViewTextBoxColumn1.HeaderText = "項次";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Width = 40;
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.DataPropertyName = "單據日期";
			this.dataGridViewTextBoxColumn2.HeaderText = "單據日期";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.dataGridViewTextBoxColumn2.Width = 60;
			// 
			// dataGridViewTextBoxColumn3
			// 
			this.dataGridViewTextBoxColumn3.DataPropertyName = "檢驗日期";
			this.dataGridViewTextBoxColumn3.HeaderText = "檢驗日期";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn4
			// 
			this.dataGridViewTextBoxColumn4.DataPropertyName = "工作單號";
			this.dataGridViewTextBoxColumn4.HeaderText = "工作單號";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.ReadOnly = true;
			this.dataGridViewTextBoxColumn4.Width = 60;
			// 
			// dataGridViewTextBoxColumn5
			// 
			this.dataGridViewTextBoxColumn5.DataPropertyName = "品號";
			this.dataGridViewTextBoxColumn5.HeaderText = "料號";
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.ReadOnly = true;
			this.dataGridViewTextBoxColumn5.Width = 50;
			// 
			// dataGridViewTextBoxColumn6
			// 
			this.dataGridViewTextBoxColumn6.DataPropertyName = "客戶";
			this.dataGridViewTextBoxColumn6.HeaderText = "客戶";
			this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewTextBoxColumn6.ReadOnly = true;
			this.dataGridViewTextBoxColumn6.Width = 50;
			// 
			// dataGridViewTextBoxColumn7
			// 
			this.dataGridViewTextBoxColumn7.DataPropertyName = "序號";
			this.dataGridViewTextBoxColumn7.HeaderText = "序號";
			this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
			this.dataGridViewTextBoxColumn7.ReadOnly = true;
			this.dataGridViewTextBoxColumn7.Width = 50;
			// 
			// dataGridViewTextBoxColumn8
			// 
			this.dataGridViewTextBoxColumn8.DataPropertyName = "總數量";
			dataGridViewCellStyle6.Format = "0.#";
			this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle6;
			this.dataGridViewTextBoxColumn8.HeaderText = "總數量";
			this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
			this.dataGridViewTextBoxColumn8.ReadOnly = true;
			this.dataGridViewTextBoxColumn8.Width = 50;
			// 
			// dataGridViewTextBoxColumn9
			// 
			this.dataGridViewTextBoxColumn9.DataPropertyName = "已完成";
			this.dataGridViewTextBoxColumn9.HeaderText = "已完成";
			this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
			this.dataGridViewTextBoxColumn9.ReadOnly = true;
			this.dataGridViewTextBoxColumn9.Width = 50;
			// 
			// dataGridViewTextBoxColumn10
			// 
			this.dataGridViewTextBoxColumn10.DataPropertyName = "待驗數量";
			this.dataGridViewTextBoxColumn10.HeaderText = "送驗數量";
			this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
			this.dataGridViewTextBoxColumn10.ReadOnly = true;
			this.dataGridViewTextBoxColumn10.Width = 65;
			// 
			// dataGridViewTextBoxColumn11
			// 
			this.dataGridViewTextBoxColumn11.DataPropertyName = "QCN";
			this.dataGridViewTextBoxColumn11.HeaderText = "QC#";
			this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
			this.dataGridViewTextBoxColumn11.ReadOnly = true;
			this.dataGridViewTextBoxColumn11.Width = 50;
			// 
			// InspectedDeleteForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(832, 399);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.ckbDate);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtPartNumber);
			this.Controls.Add(this.dtpDate);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtQCN);
			this.Controls.Add(this.btnSend);
			this.Controls.Add(this.btnSearch);
			this.Controls.Add(this.dgv);
			this.Name = "InspectedDeleteForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "已完成品再驗登記";
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.Button btnSend;
		private System.Windows.Forms.DateTimePicker dtpDate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtQCN;
		private System.Windows.Forms.TextBox txtPartNumber;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox ckbDate;
		private System.Windows.Forms.BindingSource bindingSource;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.DataGridViewCheckBoxColumn col刪除;
		private System.Windows.Forms.DataGridViewTextBoxColumn col項次;
		private System.Windows.Forms.DataGridViewTextBoxColumn col日期;
		private System.Windows.Forms.DataGridViewTextBoxColumn col檢驗日期;
		private System.Windows.Forms.DataGridViewTextBoxColumn col待驗工作單;
		private System.Windows.Forms.DataGridViewTextBoxColumn col料號;
		private System.Windows.Forms.DataGridViewTextBoxColumn col客戶;
		private System.Windows.Forms.DataGridViewTextBoxColumn col序號;
		private System.Windows.Forms.DataGridViewTextBoxColumn col總數量;
		private System.Windows.Forms.DataGridViewTextBoxColumn col已完成;
		private System.Windows.Forms.DataGridViewTextBoxColumn 待驗數量;
		private System.Windows.Forms.DataGridViewTextBoxColumn colQCN;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
	}
}