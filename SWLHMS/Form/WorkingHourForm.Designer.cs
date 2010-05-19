namespace Mong
{
    partial class WorkingHourForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxDayWH = new System.Windows.Forms.TextBox();
            this.dgvHolidays = new System.Windows.Forms.DataGridView();
            this.col日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col類別 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col週六日 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsHolidays = new System.Windows.Forms.BindingSource(this.components);
            this.btnStoreHoliday = new System.Windows.Forms.Button();
            this.btnAddHoliday = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxWorkingDays = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxWorkingHours = new System.Windows.Forms.TextBox();
            this.btnDelHoliday = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHolidays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsHolidays)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(10, 35);
            this.monthCalendar1.MaxSelectionCount = 1;
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.ShowToday = false;
            this.monthCalendar1.ShowTodayCircle = false;
            this.monthCalendar1.TabIndex = 0;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "每日工時";
            // 
            // tbxDayWH
            // 
            this.tbxDayWH.Location = new System.Drawing.Point(249, 255);
            this.tbxDayWH.Name = "tbxDayWH";
            this.tbxDayWH.Size = new System.Drawing.Size(73, 22);
            this.tbxDayWH.TabIndex = 1;
            this.tbxDayWH.Validated += new System.EventHandler(this.tbxDayWH_Validated);
            this.tbxDayWH.Enter += new System.EventHandler(this.tbxDayWH_Enter);
            this.tbxDayWH.Validating += new System.ComponentModel.CancelEventHandler(this.tbxDayWH_Validating);
            // 
            // dgvHolidays
            // 
            this.dgvHolidays.AllowUserToAddRows = false;
            this.dgvHolidays.AllowUserToResizeRows = false;
            this.dgvHolidays.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvHolidays.AutoGenerateColumns = false;
            this.dgvHolidays.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHolidays.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvHolidays.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHolidays.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvHolidays.ColumnHeadersHeight = 20;
            this.dgvHolidays.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvHolidays.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col日期,
            this.col類別,
            this.col週六日});
            this.dgvHolidays.DataSource = this.bsHolidays;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHolidays.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvHolidays.EnableHeadersVisualStyles = false;
            this.dgvHolidays.GridColor = System.Drawing.Color.LightGray;
            this.dgvHolidays.Location = new System.Drawing.Point(4, 24);
            this.dgvHolidays.Name = "dgvHolidays";
            this.dgvHolidays.ReadOnly = true;
            this.dgvHolidays.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHolidays.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvHolidays.RowHeadersVisible = false;
            this.dgvHolidays.RowHeadersWidth = 20;
            this.dgvHolidays.RowTemplate.Height = 20;
            this.dgvHolidays.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHolidays.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHolidays.Size = new System.Drawing.Size(156, 252);
            this.dgvHolidays.TabIndex = 5;
            this.dgvHolidays.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHolidays_CellValueChanged);
            this.dgvHolidays.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvHolidays_UserDeletedRow);
            this.dgvHolidays.CurrentCellChanged += new System.EventHandler(this.dgvHolidays_CurrentCellChanged);
            // 
            // col日期
            // 
            this.col日期.DataPropertyName = "日期";
            this.col日期.HeaderText = "日期";
            this.col日期.Name = "col日期";
            this.col日期.ReadOnly = true;
            // 
            // col類別
            // 
            this.col類別.DataPropertyName = "類別";
            this.col類別.HeaderText = "類別";
            this.col類別.Name = "col類別";
            this.col類別.ReadOnly = true;
            // 
            // col週六日
            // 
            this.col週六日.DataPropertyName = "週六日";
            this.col週六日.HeaderText = "週六日";
            this.col週六日.Name = "col週六日";
            this.col週六日.ReadOnly = true;
            this.col週六日.Visible = false;
            // 
            // btnStoreHoliday
            // 
            this.btnStoreHoliday.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStoreHoliday.Location = new System.Drawing.Point(4, 282);
            this.btnStoreHoliday.Name = "btnStoreHoliday";
            this.btnStoreHoliday.Size = new System.Drawing.Size(75, 23);
            this.btnStoreHoliday.TabIndex = 3;
            this.btnStoreHoliday.Text = "儲存";
            this.btnStoreHoliday.UseVisualStyleBackColor = true;
            this.btnStoreHoliday.Click += new System.EventHandler(this.btnStoreHoliday_Click);
            // 
            // btnAddHoliday
            // 
            this.btnAddHoliday.Location = new System.Drawing.Point(158, 186);
            this.btnAddHoliday.Name = "btnAddHoliday";
            this.btnAddHoliday.Size = new System.Drawing.Size(123, 23);
            this.btnAddHoliday.TabIndex = 0;
            this.btnAddHoliday.Text = "新增";
            this.toolTip1.SetToolTip(this.btnAddHoliday, "將指定日期新增到假日清單中");
            this.btnAddHoliday.UseVisualStyleBackColor = true;
            this.btnAddHoliday.Click += new System.EventHandler(this.btnAddHoliday_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(166, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "本月工作天數";
            // 
            // tbxWorkingDays
            // 
            this.tbxWorkingDays.Location = new System.Drawing.Point(249, 227);
            this.tbxWorkingDays.Name = "tbxWorkingDays";
            this.tbxWorkingDays.ReadOnly = true;
            this.tbxWorkingDays.Size = new System.Drawing.Size(73, 22);
            this.tbxWorkingDays.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(166, 288);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "本月工作時數";
            // 
            // tbxWorkingHours
            // 
            this.tbxWorkingHours.Location = new System.Drawing.Point(249, 283);
            this.tbxWorkingHours.Name = "tbxWorkingHours";
            this.tbxWorkingHours.ReadOnly = true;
            this.tbxWorkingHours.Size = new System.Drawing.Size(73, 22);
            this.tbxWorkingHours.TabIndex = 2;
            this.toolTip1.SetToolTip(this.tbxWorkingHours, "本月工作天數*每日工時");
            // 
            // btnDelHoliday
            // 
            this.btnDelHoliday.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelHoliday.Location = new System.Drawing.Point(85, 282);
            this.btnDelHoliday.Name = "btnDelHoliday";
            this.btnDelHoliday.Size = new System.Drawing.Size(75, 23);
            this.btnDelHoliday.TabIndex = 4;
            this.btnDelHoliday.Text = "刪除";
            this.btnDelHoliday.UseVisualStyleBackColor = true;
            this.btnDelHoliday.Click += new System.EventHandler(this.btnDelHoliday_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnAddHoliday);
            this.groupBox1.Controls.Add(this.monthCalendar1);
            this.groupBox1.Location = new System.Drawing.Point(166, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 215);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "休假日";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "粗體日期為休假日";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "更改完畢後請點選儲存";
            // 
            // WorkingHourForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 311);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDelHoliday);
            this.Controls.Add(this.tbxWorkingHours);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxWorkingDays);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnStoreHoliday);
            this.Controls.Add(this.dgvHolidays);
            this.Controls.Add(this.tbxDayWH);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(470, 345);
            this.Name = "WorkingHourForm";
            this.ShowIcon = false;
            this.Text = "每月工作時數管理";
            this.Load += new System.EventHandler(this.WorkingHourForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WorkingHourForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHolidays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsHolidays)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxDayWH;
        private System.Windows.Forms.DataGridView dgvHolidays;
        private System.Windows.Forms.BindingSource bsHolidays;
        private System.Windows.Forms.Button btnStoreHoliday;
        private System.Windows.Forms.Button btnAddHoliday;
        private System.Windows.Forms.DataGridViewTextBoxColumn col日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn col類別;
        private System.Windows.Forms.DataGridViewTextBoxColumn col週六日;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxWorkingDays;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxWorkingHours;
        private System.Windows.Forms.Button btnDelHoliday;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label5;
    }
}