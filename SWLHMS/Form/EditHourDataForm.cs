using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;

using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using Mong.DatabaseSetTableAdapters;

namespace Mong
{
    public partial class EditHourDataForm : Form
    {
        decimal _remainHours;
        bool _suspendLaborChangedEvent = false;
        bool _suspendLineChangedEvent = false;

        DatabaseSet.員工Row _editLaborRow;
        DatabaseSet.假日DataTable _holidayTable;
        bool _allowDeleteOldData;
        bool _todayIsHoliday;
        Dictionary<DataRow, DateTime> _finishDateList = new Dictionary<DataRow,DateTime>();
        LaborWageHelper _lwHelper;
		DataTable _ngTable;

        int _remainAmount = 0;

        public bool AllowDeleteOldData
        {
            get { return _allowDeleteOldData; }
            set { _allowDeleteOldData = value; }
        }
        public bool TodayIsHoliday
        {
            get { return _todayIsHoliday; }
            set
            {
                _todayIsHoliday = value;

				//For 1.08.14 below
                //btnAddList.Enabled = !_todayIsHoliday;

                //btnSend.Enabled = !_todayIsHoliday;
                //btnStore.Enabled = !_todayIsHoliday;
            }
        }
        string SelectedLine
        {
            get
            {
                if (cbbLine.SelectedIndex == -1)
                    return null;
                return (string)cbbLine.SelectedValue;
            }
        }
        string SelectedBorrowedLine
        {
            get
            {
                if (cbbBorrowLine.SelectedIndex == -1)
                    return null;
                return (string)cbbBorrowLine.SelectedValue;
            }
        }
        public string SelectedLaborNumber
        {
            get
            {
                if (cbxLaborNumber.SelectedIndex == -1)
                    return null;
                return (string)cbxLaborNumber.SelectedValue;
            }
        }
		DataTable NGTable
		{
			get { return _ngTable; }
			set 
			{ 
				_ngTable = value;
				bool ng = _ngTable != null && _ngTable.Rows.Count > 0;
				llbNGTip.Visible = ng;

				if (ng)
				{
					llbNGTip.Text = "共有" + _ngTable.Rows.Count + "筆退驗資料，欲檢視並重新送驗請按此";
				}
			}
		}

        DatabaseSet.工時DataTable _dataTable;

        public EditHourDataForm()
        {
            InitializeComponent();

            _lwHelper = new LaborWageHelper();

            _holidayTable = 假日TableAdapter.Instance.GetByRange(Settings.UnfilledDate, DateTime.Today);

            rbProduce.Checked = true;

            // Load the lines
            _suspendLineChangedEvent = true;
            bsLine.DataSource = DatabaseSet.產線Table;
            
            // Load the nonproduce items
            bsNonProduce.DataSource = DatabaseSet.非生產Table;

            // Create a table for input
			bsHourData.DataSource = _dataTable = CreateDataTable();

            cbbLine.ValueMember = cbbLine.DisplayMember = "產線";
            cbbNonProduce.ValueMember = "編號";
            cbbNonProduce.DisplayMember = "名稱";
            

            dtpDate.Value = dateFinishDate.Value = DateTime.Today;

            cbbLine.SelectedIndex = -1;

            _suspendLineChangedEvent = false;
        }

        private void rbProduce_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Enabled = rbProduce.Checked;
            panel2.Enabled = rbNonProduce.Checked;

			cbxHourType.Enabled = rbProduce.Checked;

			if (rbNonProduce.Checked)
				cbxHourType.SelectedIndex = 0;
        }

        private void btnSearchWorksheet_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbbWorksheetNubmerS.Text != string.Empty)
                {
                    DatabaseSet.工作單DataTable wsTable = 工作單TableAdapter.Instance.GetBy單號(cbbWorksheetNubmerS.Text);
                    if(wsTable.Count == 0)
						throw new SWLHMSException("工作單號 " + cbbWorksheetNubmerS.Text + " 不存在");

                    if (dtpDate.Value < wsTable[0].單據日期 || (!Convert.IsDBNull(wsTable[0]["實際完成日"]) && dtpDate.Value > wsTable[0].實際完成日))
						throw new SWLHMSException("工作單在 " + dtpDate.Value.ToString("yyyy/MM/dd") + " 未開始或已結束");

                    DataTable table = 工作單品號TableAdapter.Instance.GetBy單號(cbbWorksheetNubmerS.Text);
                    bsPart.DataSource = table;
                    cbbPart.DisplayMember = "品號";
                    lbPartCount.Text = "共 " + table.Rows.Count + " 筆品號資料";
                }
            }
            catch(Exception ex)
            {
                bsPart.DataSource = null;
                lbPartCount.Text = ex.Message;
            }
        }

        private void cbbWorksheetNubmerS_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbbWorksheetNubmerS.Text != string.Empty)
                {
                    DatabaseSet.工作單DataTable wsTable = 工作單TableAdapter.Instance.GetBy單號(cbbWorksheetNubmerS.Text);
                    if (wsTable.Count == 0)
						throw new SWLHMSException("工作單號 " + cbbWorksheetNubmerS.Text + " 不存在");

                    if (dtpDate.Value < wsTable[0].單據日期 || (!Convert.IsDBNull(wsTable[0]["實際完成日"]) && dtpDate.Value >= wsTable[0].實際完成日))
						throw new SWLHMSException("工作單在 " + dtpDate.Value.ToString("yyyy/MM/dd") + " 未開始或已結束");

                    DataTable table = 工作單品號TableAdapter.Instance.GetBy單號(cbbWorksheetNubmerS.Text);
					table.Columns.Add(new DataColumn("Display", typeof(string), "'#'+編號+'-'+品號"));
                    bsPart.DataSource = table;
					cbbPart.DisplayMember = "Display";
                    lbPartCount.Text = "共 " + table.Rows.Count + " 筆品號資料";
                }
            }
            catch (Exception ex)
            {
                bsPart.DataSource = null;
                lbPartCount.Text = ex.Message;
            }
        }

        private void btnAddList_Click(object sender, EventArgs e)
        {
            try
            {
                decimal hour = decimal.Parse(tbxHour.Text);
                if (_remainHours >= hour || ckbOvertime.Checked || this.TodayIsHoliday)
                {
                    DatabaseSet.工時Row newRow = _dataTable.New工時Row();

                    if (rbProduce.Checked)
                    {
                        //if (dgvPart.CurrentRow != null)
                        if (cbbPart.SelectedIndex != -1)
                        {
                            //string worksheetNumber = dgvPart.CurrentRow.Cells["col單號"].Value.ToString();
                            //string partNumber = dgvPart.CurrentRow.Cells["col品號"].Value.ToString();

                            DataRowView selectedRow = (DataRowView)cbbPart.SelectedItem;
                            string worksheetNumber = selectedRow["單號"].ToString();
                            string partNumber = selectedRow["品號"].ToString();
							int wpID = (int)selectedRow["編號"];

                            // Check whether finish date is set
                            if (selectedRow["實際完成日"] != DBNull.Value && dtpDate.Value >= (DateTime)selectedRow["實際完成日"])
								throw new SWLHMSException("填寫時間 " + dtpDate.Value.ToString("yyyy/MM/dd") + " 已在品號 '" + partNumber + "' 完成日之後");

							string borrower = null;

							// Check the borrow line
							if (ckbBorrowLine.Checked)
							{
								if (cbbBorrowLine.SelectedIndex == -1)
									throw new SWLHMSException("請選擇借入產線");

								borrower = (string)this.cbbBorrowLine.SelectedItem;
							}

                            // Check the number of done
                            if (txtNum.Text.Trim() == string.Empty)
								throw new SWLHMSException("未輸入完成數量");
                            int num = int.Parse(txtNum.Text);


							/* Only for 1.08.15 below
							 * 
                            // Check whether part number is duplicated
							string checkExpr = "工品編號 = '" + wpID + "' AND 工作單號 ='" + worksheetNumber + "'";
							if(borrower != null)
								checkExpr += " AND 借入產線 = '" + borrower + "'";
							else
								checkExpr += " AND 借入產線 IS NULL ";
							if ((int)_dataTable.Compute("Count(品號)", checkExpr) > 0)
								throw new SWLHMSException("品號 '" + partNumber + "' 已存在");
							*/

                            // Check the remain amount
                            if (_remainAmount < num)
								throw new SWLHMSException("輸入數量超過剩餘數量");

							// hour type
							HourType hourType = (HourType)cbxHourType.SelectedIndex;
                            
							string QCN = txtQCN.Text;

							newRow.FillRow(this.SelectedLaborNumber, dtpDate.Value, worksheetNumber, hour, num, borrower, QCN, wpID, hourType);
                            newRow.新舊 = "*";
							newRow["品號"] = partNumber;
							newRow["工時類型名稱"] = hourType.ToString();

                            _dataTable.Rows.Add(newRow);

							//if (ckbFinishDate.Checked)
							//{
							//    DateTime date = dateFinishDate.Value;
							//    _finishDateList.Add(newRow, date); 
							//}

                            txtNum.Text = "0";
							txtQCN.Text = null;
                        }
                    }
                    else
                    {
                        if (cbbNonProduce.SelectedIndex != -1)
                        {
                            if(cbbNonProduce.Text == "其他" && tbxRemark.Text == string.Empty)
								throw new SWLHMSException("非生產項目為 其他 時，備註欄不得為空");

                            newRow.FillRow(cbxLaborNumber.SelectedValue.ToString(), dtpDate.Value, hour, (int)cbbNonProduce.SelectedValue, cbbNonProduce.Text, tbxRemark.Text);
                            newRow.新舊 = "*";
							newRow["工時類型名稱"] = HourType.一般工時.ToString();
                            _dataTable.Rows.Add(newRow);
                        }
                    }

                    dgvHoursData.AutoResizeColumns();
                    UpdateRemainHour();
                    UpdateRemainAmount();
                }
                else
					throw new SWLHMSException("填寫時數超過剩餘時數");
            }
            catch (Exception ex)
            {
                Global.ShowError(ex);
            }
        }

        private void tbxHour_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (decimal.Parse(tbxHour.Text) < 0)
					throw new SWLHMSException();
            }
            catch (Exception)
            {
                MessageBox.Show("工時必須為一個正數");
                e.Cancel = true;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (_remainHours > 0 && !this.TodayIsHoliday)
					throw new SWLHMSException("尚有時數未填寫完畢");

                if (MessageBox.Show("資料經送出後不可再修改，請確認後繼續", "送出確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    //SetFinishDate();
					

					int update = 工時TableAdapter.Instance.Update((DatabaseSet.工時DataTable)_dataTable.Copy());
					UpdateFinishDate();

					int reinspect;
					int qa = UpdateQATable(out reinspect);

					string msg = "新增了 " + update + " 筆資料";
					if (qa > 0)
						msg += "\n新增了 " + qa + " 筆待驗資料";
					if (reinspect > 0)
						msg += "\n重新送驗了 " + reinspect + "筆資料";

					MessageBox.Show(msg);
                    UpdateRemainAmount();
                    LoadOldHourData();
					LoadNGData();
                }
            }
            catch (Exception ex)
            {
				Global.ShowError(ex);
				Debug.WriteLine(ex.ToString());
            }
        }

		private void btnStore_Click(object sender, EventArgs e)
		{
			try
			{
				if (_remainHours > 0 && !this.TodayIsHoliday)
				{
					if (MessageBox.Show("尚有時數未填寫完畢，確定要儲存嗎?", "儲存提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
						return;
				}

				//SetFinishDate();

				//重驗後的工時資料刪除時進行復原工作
				int update = 0;

				DatabaseSet.工時DataTable table = (DatabaseSet.工時DataTable)_dataTable.Copy();
				foreach (DataRow row in _dataTable)
				{
				    if (row.RowState == DataRowState.Deleted)
				    {
				        string id = (string)row["編號", DataRowVersion.Original];
						update += 工時TableAdapter.Instance.DeleteEx(id);
				    }
				}
				foreach(DataRow row in table.Select(null, null, DataViewRowState.Deleted))
					row.AcceptChanges();

				update += 工時TableAdapter.Instance.Update(table);
				UpdateFinishDate();

				int reinspect;
				int qa = UpdateQATable(out reinspect);

				string msg = "更新了 " + update + " 筆資料";
				if (qa > 0)
					msg += "\n新增了 " + qa + " 筆待驗資料";
				if (reinspect > 0)
					msg += "\n重新送驗了 " + reinspect + "筆資料";

				MessageBox.Show(msg);

				UpdateRemainAmount();
				LoadOldHourData();
				LoadNGData();
			}
			catch (Exception ex)
			{
				//MessageBox.Show(ex.Message);
				Global.ShowError(ex);
			}
		}

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            btnSearchWorksheet.PerformClick();
            LoadOldHourData();
            UpdateRemainHour();
            LoadUnfilledData();
        }

        private void cbbLaborNumber_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!_suspendLaborChangedEvent)
            {
                if ((sender as ComboBox).SelectedIndex != -1)
                {
                    ComboBox another = (sender == cbxLaborNumber) ? cbxLaborName : cbxLaborNumber;
                    if (another.Items.Count > (sender as ComboBox).SelectedIndex)
                        another.SelectedIndex = (sender as ComboBox).SelectedIndex;

                    mainContainer.Enabled = true;
                    LoadUnfilledData();
                    LoadOldHourData();
                    UpdateRemainHour();
					LoadNGData();
                }
                else
                {
                    mainContainer.Enabled = false;
                    if(_dataTable != null)
                        _dataTable.Clear();

                    llbUnfilledTip.Visible = false;

                    lbRemain.Text = "本日尚餘" + Settings.WorkingHoursPerDay + "小時";
                }
            }
        }

        private void cbbLine_SelectedValueChanged(object sender, EventArgs e)
        {
			if (!_suspendLineChangedEvent)
			{
				string line = this.SelectedLine;
				//if (ckbBorrowLine.Checked)
				//    line = this.SelectedBorrowedLine;

				if (line != null && cbbLine.DataSource != null)
				{
					UpdateLaborList();


				}
				else
				{
					bsLabor.DataSource = null;
				}

				cbxLaborNumber.SelectedIndex = -1;
				cbxLaborName.SelectedIndex = -1;

				if (sender == cbbLine && ckbBorrowLine.Checked)
					UpdateBorrowList();
			}
        }

        private void cbbPart_SelectedValueChanged(object sender, EventArgs e)
        {
            // Check the finish date
            if (cbbPart.SelectedIndex != -1)
            {
                
                DataRowView selectedRow = (DataRowView)cbbPart.SelectedItem;

                UpdateRemainAmount();
                bool finished = false;

                if (selectedRow["實際完成日"] != DBNull.Value)
                {
                    DateTime date = (DateTime)selectedRow["實際完成日"];
                    finished = true;

                    dateFinishDate.Value = date;
                }

                ckbFinishDate.Checked = finished;
                ckbFinishDate.Enabled = !finished;
                dateFinishDate.Enabled = false;
                txtNum.Enabled = txtQCN.Enabled = !ckbFinishDate.Checked;
            }

        }

        void UpdateRemainAmount()
        {
            DataRowView selectedRow = cbbPart.SelectedItem as DataRowView;
            lbRemainCount.Text = "0/0";

            if (selectedRow != null)
            {
                string worksheet = (string)selectedRow["單號"];
                string partnumber = (string)selectedRow["品號"];
				int wpid = (int)selectedRow["編號"];

				int finishCount = 工時TableAdapter.Instance.GetFinishProductAmount(worksheet, wpid);
                //finishCount += _lwHelper.GetAmount(worksheet, partnumber);

                decimal allCount = (decimal)selectedRow["數量"];
                _remainAmount = (int)(allCount - finishCount);

                lbRemainCount.Text = "剩餘 " + _remainAmount + "/" + allCount.ToString("0.#");
            }
        }

        private void ckbBorrowLine_CheckedChanged(object sender, EventArgs e)
        {
            if ((cbbBorrowLine.Enabled = ckbBorrowLine.Checked) == true)
            {
                UpdateBorrowList();
            }
            //UpdateLaborList();
        }

        private void ckbOvertime_CheckedChanged(object sender, EventArgs e)
        {
            lbRemain.Visible = !ckbOvertime.Checked;
        }

        private void ckbFinishDate_CheckedChanged(object sender, EventArgs e)
        {
            dateFinishDate.Enabled = ckbFinishDate.Checked;
        }

        private void EditHourDataForm_Load(object sender, EventArgs e)
        {
            txtDate.Text = DateTime.Today.ToString("yyyyMM");
            lbRemainCount.Text = string.Empty;

			foreach (string hourType in Enum.GetNames(typeof(HourType)))
				cbxHourType.Items.Add(hourType);
			cbxHourType.SelectedIndex = 0;
        }

        private void dgvHoursData_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (dgvHoursData.CurrentRow != null)
            {
                DataRow row = (dgvHoursData.CurrentRow.DataBoundItem as DataRowView).Row;
                if (row.RowState == DataRowState.Unchanged && !AllowDeleteOldData)
                {
                    e.Cancel = true;
                    MessageBox.Show("不能刪除舊資料");
                }

                if (_finishDateList.ContainsKey(row))
                    _finishDateList.Remove(row);
            }
        }

        private void dgvHoursData_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            UpdateRemainHour();
        }

        private void tbxRemark_Validated(object sender, EventArgs e)
        {
            tbxRemark.Text = tbxRemark.Text.Trim();
        }

        private void btnSrchWorksheet_Click(object sender, EventArgs e)
        {
            try
            {
                //string dateTxt = string.Empty;
                string dateTxt = txtDate.Text;

                //if (txtYear.Text != string.Empty)
                //{
                //    year = int.Parse(txtYear.Text);
                //    dateTxt += year.ToString();

                //    if (txtMonth.Text != string.Empty)
                //    {
                //        month = int.Parse(txtMonth.Text);
                //        dateTxt += month.ToString("00");

                //        if (txtDay.Text != string.Empty)
                //        {
                //            day = int.Parse(txtDay.Text);
                //            dateTxt += day.ToString("00");
                //        }
                //    }
                //}

				

                // Get the worksheet number by the dateTxt
                OleDbConnection conn = DbConnection.Instance;
                ConnectionState oriConnState = conn.State;
                if ((conn.State & ConnectionState.Open) != ConnectionState.Open)
                    conn.Open();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
				if (dateTxt != string.Empty)
				{
					//cmd.CommandText = "SELECT 單號 FROM 工作單 WHERE 單號 LIKE '" + dateTxt + "%'";
					cmd.CommandText = "SELECT 單號 FROM 工作單";

					//產生日期條件
					List<string> dateFilter = new List<string>();

					string[] dateFunc = new string[] { "YEAR", "MONTH", "DAY" };

					string[] dateTxtArr = dateTxt.Split('-');
					for (int i = 0; i < 3; i++)
					{
						if (!string.IsNullOrEmpty(dateTxtArr[i].Trim()))
						{
							int val = int.Parse(dateTxtArr[i]);
							dateFilter.Add(dateFunc[i] + "(單據日期)=" + val);
						}
					}

					if (dateFilter.Count > 0)
						cmd.CommandText += " WHERE " + string.Join(" AND ", dateFilter.ToArray());
				}
				else
					cmd.CommandText = "SELECT 單號 FROM 工作單";

                OleDbDataReader reader = cmd.ExecuteReader();
                List<string> worksheetNumbers = new List<string>();
                while (reader.Read())
                    worksheetNumbers.Add(reader.GetString(0));
                reader.Close();

                if (oriConnState == ConnectionState.Closed)
                    conn.Close();

                cbbWorksheetNubmerS.SelectedIndex = -1;
                cbbWorksheetNubmerS.DataSource = worksheetNumbers;

            }
            catch (Exception ex)
            {
                Global.ShowError(ex);
            }
        }

        private void txtDate_Validated(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = textBox.Text.Trim();
        }

        public void NewHourData()
        {
            this.Text = "工時資料登記";
            btnStore.Visible = false;
        }

        public void EditHourdata(string 員工編號, DateTime 日期)
        {
            this.Text = "工時資料編輯";
            btnSend.Visible = false;
            員工編號 = 員工編號.Replace("'", "''");
            DataRow[] rows = DatabaseSet.員工Table.Select("編號 = '" + 員工編號 + "'");
            if (rows.Length > 0)
                _editLaborRow = rows[0] as DatabaseSet.員工Row;
            else
				throw new SWLHMSException("找不到員工編號 " + 員工編號 + " 的資料");

            cbbLine.SelectedValue = _editLaborRow.產線;

            cbxLaborNumber.DisplayMember = "編號";
            cbxLaborNumber.ValueMember = "編號";
            cbxLaborName.DisplayMember = "姓名";
            cbxLaborName.ValueMember = "姓名";

            bsLabor.DataSource = _editLaborRow;

            dtpDate.Value = 日期;

            LoadOldHourData();
            UpdateRemainHour();
        }

        void LoadOldHourData()
        {
            if (cbxLaborNumber.SelectedIndex != -1)
            {
                _dataTable.Clear();
                工時TableAdapter.Instance.Fill(_dataTable, cbxLaborNumber.SelectedValue.ToString(), true, dtpDate.Value, dtpDate.Value);
				foreach (DataRow row in _dataTable)
				{
					row["工時類型名稱"] = ((HourType)row["工時類型"]).ToString();
				}

                dgvHoursData.AutoResizeColumns();
            }
        }

        void LoadUnfilledData()
        {
            if (cbxLaborNumber.SelectedIndex != -1)
            {
                DatabaseSet.工時DataTable table = 工時TableAdapter.Instance.GetFilledDataBy員工編號(cbxLaborNumber.SelectedValue.ToString());
                DateTime from = Settings.UnfilledDate;
                DateTime to = DateTime.Today;
                
                for (DateTime date = from; date <= to; date = date.AddDays(1))
                {
                    if (!假日TableAdapter.Instance.IsHoliday(_holidayTable, date))
                    {
                        if (date != dtpDate.Value)
                        {
                            DataRow[] rows = table.Select("日期 = #" + date.ToString("yyyy/MM/dd") + "#");
                            if (rows.Length == 0)
                            {
								llbUnfilledTip.Text = date.ToString("yyyy/MM/dd") + "的資料尚未填寫完畢";
								llbUnfilledTip.Tag = date;
                                llbUnfilledTip.Visible = true;
                                return;
                            }
                        }
                    }
                }
				llbUnfilledTip.Visible = false;
            }
        }
        
        void UpdateRemainHour()
        {
            if (!假日TableAdapter.Instance.IsHoliday(_holidayTable, dtpDate.Value))
            {
                object o;
                decimal hour;
                o = _dataTable.Compute("SUM(工時)", "");

                hour = Convert.IsDBNull(o) ? 0 : (decimal)o;

                decimal oldHour = 0;

                //if (cbxLaborNumber.SelectedIndex != -1)
                //{
                //    o = 工時TableAdapter.Instance.GetCountBy員工編號_日期(cbxLaborNumber.SelectedValue.ToString(), dtpDate.Value);
                //    oldHour = (o == null) ? 0 : (decimal)o;
                //}

                _remainHours = Settings.WorkingHoursPerDay - hour - oldHour;

                lbRemain.Text = "本日尚餘" + _remainHours.ToString("0.##") + "小時";

                TodayIsHoliday = false;
            }
            else
            {
                TodayIsHoliday = true;

                lbRemain.Text = "本日為假日";
            }
        }

        void UpdateBorrowList()
        {
            _suspendLineChangedEvent = true;

            List<string> borrowList = new List<string>();
            if(cbbLine.SelectedIndex != -1)
            {
                string borrower = (string)cbbLine.SelectedValue;

                foreach (DataRowView row in bsLine.List)
                {
                    string line = (string)row["產線"];

                    if (line != borrower)
                        borrowList.Add(line);
                }
            }
            cbbBorrowLine.DataSource = borrowList;
            cbbBorrowLine.SelectedIndex = -1;

            _suspendLineChangedEvent = false;
        }

        void UpdateLaborList()
        {
            _suspendLaborChangedEvent = true;

            string line = this.SelectedLine;
			//if (ckbBorrowLine.Checked)
			//    line = this.SelectedBorrowedLine;

            if (line != null)
            {
                // Get all labors belong to selected line
                bsLabor.DataSource = 員工TableAdapter.Instance.GetBy產線(line);
                cbxLaborNumber.DisplayMember = cbxLaborNumber.ValueMember = "編號";
                cbxLaborName.DisplayMember = cbxLaborName.ValueMember = "姓名";
            }
            _suspendLaborChangedEvent = false;

            cbxLaborNumber.SelectedIndex = -1;
            cbxLaborName.SelectedIndex = -1;
        }

		// Not used
        void SetFinishDate()
        {
            foreach (KeyValuePair<DataRow, DateTime> kv in _finishDateList)
            {
                string worksheetNumber = kv.Key["工作單號"].ToString();
                string partNumber = kv.Key["品號"].ToString();
				int wpid = (int)kv.Key["工品編號"];

				if (工作單品號TableAdapter.Instance.SetFinishDate(kv.Value, worksheetNumber, wpid) == 0)
					throw new SWLHMSException("品號 '" + partNumber + "' 設定完成日期時發生錯誤");

                // Check the finish date
                DatabaseSet.工作單品號DataTable table = 工作單品號TableAdapter.Instance.GetBy單號(worksheetNumber);
                bool allFinished = true;
                DateTime maxDate = DateTime.MinValue;
                foreach (DatabaseSet.工作單品號Row row in table)
                {
                    if (row["實際完成日"] == DBNull.Value)
                    {
                        allFinished = false;
                        break;
                    }
                    DateTime date = row.實際完成日;
                    if (date > maxDate)
                        maxDate = date;
                }
                if (allFinished)
                    工作單TableAdapter.Instance.SetFinishDate(maxDate, worksheetNumber);
            }
        }

		void UpdateFinishDate()
		{
			foreach (DataRow row in _dataTable)
			{
				if (row.RowState == DataRowState.Deleted)
				{
					string worksheet = row["工作單號", DataRowVersion.Original] as string;

					if (!string.IsNullOrEmpty(worksheet))
					{
						int wpid = (int)row["工品編號", DataRowVersion.Original];
						DatabaseSet.UpdateWorksheetItemFinishDate(worksheet, wpid, true);
					}
				}
			}
		}

		void LoadNGData()
		{
			string labor = this.SelectedLaborNumber;
			if(labor != null)
			{
				this.NGTable = DatabaseSet.GetNGData(labor);
			}
		}

		public DatabaseSet.工時DataTable CreateDataTable()
		{
			DatabaseSet.工時DataTable table = new DatabaseSet.工時DataTable();
			//table.Columns.Add(new DataColumn("QCN", typeof(string)));
			table.Columns.Add(new DataColumn("待驗數量", typeof(Int32)));
			table.Columns.Add(new DataColumn("品號", typeof(string)));
			table.Columns.Add(new DataColumn("取代編號", typeof(string)));
			table.Columns.Add(new DataColumn("工時類型名稱", typeof(string)));
			return table;
		}

        private void pnlData_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtDate_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = btnSrchWorksheet;
        }

        private void txtDate_Leave(object sender, EventArgs e)
        {
            this.AcceptButton = btnAddList;
        }

		int UpdateQATable(out int reinspect)
		{
			reinspect = 0;

			DatabaseSet.產品檢驗DataTable qaTable = new DatabaseSet.產品檢驗DataTable();
			foreach (DataRow row in _dataTable.Rows)
			{
				if (row.RowState != DataRowState.Added)
					continue;

				if (row["待驗數量"] == DBNull.Value || row["待驗數量"] == null)
					continue;
				
				int amount = (int)row["待驗數量"];
				if (amount == 0)
					continue;

				if (row["取代編號"] != DBNull.Value)
				{
					reinspect += 產品檢驗TableAdapter.Instance.Reinspect(row["取代編號"].ToString(), row["編號"].ToString(), row["QCN"].ToString(), (int)row["待驗數量"]);
				}
				else
				{
					DatabaseSet.產品檢驗Row qaRow = qaTable.New產品檢驗Row();
					qaRow["工時資料編號"] = row["編號"];
					qaRow["待驗數量"] = amount;
					qaRow["QCN"] = row["QCN"];
					qaRow["送檢次數"] = 1;
					qaRow["最後送檢編號"] = row["編號"];
					qaRow["最後檢驗紀錄"] = false;
					qaRow["檢驗"] = false;
					qaRow["重驗"] = false;
					qaRow["送檢日期"] = DateTime.Now;
					qaTable.Add產品檢驗Row(qaRow);
				}
			}

			return 產品檢驗TableAdapter.Instance.Update(qaTable);
		}

		private void llbNGTip_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				if (e.Button == MouseButtons.Left)
				{
					NGTipForm form = new NGTipForm();
					if (form.ShowDialog(this, this.NGTable, _remainHours, this.TodayIsHoliday) == DialogResult.OK)
					{
						DatabaseSet.工時Row row = form.DataRow;

						string replace = row["取代編號"].ToString();

						if (_dataTable.Select("取代編號 = '" + replace + "'").Length > 0)
							throw new SWLHMSException("此筆重驗資料已存在");

						DatabaseSet.工時Row newRow = _dataTable.New工時Row();

						//MessageBox.Show("工時資料編號 " + form.SelectedHourDataID);

						// Check the borrow line
						string borrower = null;
						if (ckbBorrowLine.Checked)
						{
							if (cbbBorrowLine.SelectedIndex == -1)
								throw new SWLHMSException("請選擇借入產線");

							borrower = (string)this.cbbBorrowLine.SelectedItem;
						}

						// hour type
						HourType hourType = (HourType)cbxHourType.SelectedIndex;

						newRow["品號"] = row["品號"];
						newRow["取代編號"] = row["取代編號"];
						newRow.FillRow(this.SelectedLaborNumber, dtpDate.Value, row["工作單號"].ToString(), (decimal)row["工時"], (int)row["待驗數量"], borrower, row["QCN"].ToString(), (int)row["工品編號"], hourType);
						newRow.新舊 = "*";
						newRow["工時類型名稱"] = hourType.ToString();
						_dataTable.Rows.Add(newRow);

						dgvHoursData.AutoResizeColumns();
						UpdateRemainHour();
						UpdateRemainAmount();
					}

				}
			}
			catch (Exception ex)
			{
				Global.ShowError(ex);
			}
		}

		private void llbUnfilledTip_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				dtpDate.Value = (DateTime)llbUnfilledTip.Tag;
				LoadUnfilledData();
			}
		}

		private void bsHourData_ListChanged(object sender, ListChangedEventArgs e)
		{
			if (bsHourData.Count > 0)
			{
				btnSend.Enabled = btnStore.Enabled = true;
			}
			else
			{
				btnSend.Enabled = false;
			}
		}
    }
}