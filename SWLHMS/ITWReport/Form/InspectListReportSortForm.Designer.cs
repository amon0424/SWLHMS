namespace Mong
{
	partial class InspectListReportSortForm
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
			this.dgv = new System.Windows.Forms.DataGridView();
			this.col順位 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col排序欄位 = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.col排序方式 = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// dgv
			// 
			this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dgv.AutoGenerateColumns = false;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col順位,
            this.col排序欄位,
            this.col排序方式});
			this.dgv.DataSource = this.bindingSource;
			this.dgv.Location = new System.Drawing.Point(12, 12);
			this.dgv.Name = "dgv";
			this.dgv.RowHeadersWidth = 25;
			this.dgv.RowTemplate.Height = 24;
			this.dgv.Size = new System.Drawing.Size(273, 149);
			this.dgv.TabIndex = 0;
			this.dgv.VirtualMode = true;
			this.dgv.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgv_UserDeletingRow);
			this.dgv.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgv_UserDeletedRow);
			this.dgv.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgv_DefaultValuesNeeded);
			// 
			// col順位
			// 
			this.col順位.DataPropertyName = "順位";
			this.col順位.HeaderText = "順位";
			this.col順位.Name = "col順位";
			this.col順位.ReadOnly = true;
			this.col順位.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.col順位.Width = 40;
			// 
			// col排序欄位
			// 
			this.col排序欄位.DataPropertyName = "欄位";
			this.col排序欄位.HeaderText = "排序欄位";
			this.col排序欄位.Name = "col排序欄位";
			this.col排序欄位.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			// 
			// col排序方式
			// 
			this.col排序方式.DataPropertyName = "方式";
			this.col排序方式.HeaderText = "排序方式";
			this.col排序方式.Name = "col排序方式";
			this.col排序方式.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.col排序方式.Width = 80;
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(129, 167);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "確定";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(210, 167);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "取消";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.DataPropertyName = "順位";
			this.dataGridViewTextBoxColumn1.HeaderText = "順位";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn1.Width = 40;
			// 
			// InspectListReportSortForm
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(297, 198);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.dgv);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "InspectListReportSortForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "排序方式";
			this.Load += new System.EventHandler(this.InspectListReportSortForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.BindingSource bindingSource;
		private System.Windows.Forms.DataGridViewTextBoxColumn col順位;
		private System.Windows.Forms.DataGridViewComboBoxColumn col排序欄位;
		private System.Windows.Forms.DataGridViewComboBoxColumn col排序方式;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
	}
}