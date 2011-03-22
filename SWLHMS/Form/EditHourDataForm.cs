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

        DatabaseSet.���uRow _editLaborRow;
        DatabaseSet.����DataTable _holidayTable;
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
					llbNGTip.Text = "�@��" + _ngTable.Rows.Count + "���h���ơA���˵��í��s�e��Ы���";
				}
			}
		}

        DatabaseSet.�u��DataTable _dataTable;

        public EditHourDataForm()
        {
            InitializeComponent();

            _lwHelper = new LaborWageHelper();

            _holidayTable = ����TableAdapter.Instance.GetByRange(Settings.UnfilledDate, DateTime.Today);

            rbProduce.Checked = true;

            // Load the lines
            _suspendLineChangedEvent = true;
            bsLine.DataSource = DatabaseSet.���uTable;
            
            // Load the nonproduce items
            bsNonProduce.DataSource = DatabaseSet.�D�Ͳ�Table;

            // Create a table for input
			bsHourData.DataSource = _dataTable = CreateDataTable();

            cbbLine.ValueMember = cbbLine.DisplayMember = "���u";
            cbbNonProduce.ValueMember = "�s��";
            cbbNonProduce.DisplayMember = "�W��";
            

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
                    DatabaseSet.�u�@��DataTable wsTable = �u�@��TableAdapter.Instance.GetBy�渹(cbbWorksheetNubmerS.Text);
                    if(wsTable.Count == 0)
						throw new SWLHMSException("�u�@�渹 " + cbbWorksheetNubmerS.Text + " ���s�b");

                    if (dtpDate.Value < wsTable[0].��ڤ�� || (!Convert.IsDBNull(wsTable[0]["��ڧ�����"]) && dtpDate.Value > wsTable[0].��ڧ�����))
						throw new SWLHMSException("�u�@��b " + dtpDate.Value.ToString("yyyy/MM/dd") + " ���}�l�Τw����");

                    DataTable table = �u�@��~��TableAdapter.Instance.GetBy�渹(cbbWorksheetNubmerS.Text);
                    bsPart.DataSource = table;
                    cbbPart.DisplayMember = "�~��";
                    lbPartCount.Text = "�@ " + table.Rows.Count + " ���~�����";
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
                    DatabaseSet.�u�@��DataTable wsTable = �u�@��TableAdapter.Instance.GetBy�渹(cbbWorksheetNubmerS.Text);
                    if (wsTable.Count == 0)
						throw new SWLHMSException("�u�@�渹 " + cbbWorksheetNubmerS.Text + " ���s�b");

                    if (dtpDate.Value < wsTable[0].��ڤ�� || (!Convert.IsDBNull(wsTable[0]["��ڧ�����"]) && dtpDate.Value >= wsTable[0].��ڧ�����))
						throw new SWLHMSException("�u�@��b " + dtpDate.Value.ToString("yyyy/MM/dd") + " ���}�l�Τw����");

                    DataTable table = �u�@��~��TableAdapter.Instance.GetBy�渹(cbbWorksheetNubmerS.Text);
					table.Columns.Add(new DataColumn("Display", typeof(string), "'#'+�s��+'-'+�~��"));
                    bsPart.DataSource = table;
					cbbPart.DisplayMember = "Display";
                    lbPartCount.Text = "�@ " + table.Rows.Count + " ���~�����";
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
                    DatabaseSet.�u��Row newRow = _dataTable.New�u��Row();

                    if (rbProduce.Checked)
                    {
                        //if (dgvPart.CurrentRow != null)
                        if (cbbPart.SelectedIndex != -1)
                        {
                            //string worksheetNumber = dgvPart.CurrentRow.Cells["col�渹"].Value.ToString();
                            //string partNumber = dgvPart.CurrentRow.Cells["col�~��"].Value.ToString();

                            DataRowView selectedRow = (DataRowView)cbbPart.SelectedItem;
                            string worksheetNumber = selectedRow["�渹"].ToString();
                            string partNumber = selectedRow["�~��"].ToString();
							int wpID = (int)selectedRow["�s��"];

                            // Check whether finish date is set
                            if (selectedRow["��ڧ�����"] != DBNull.Value && dtpDate.Value >= (DateTime)selectedRow["��ڧ�����"])
								throw new SWLHMSException("��g�ɶ� " + dtpDate.Value.ToString("yyyy/MM/dd") + " �w�b�~�� '" + partNumber + "' �����餧��");

							string borrower = null;

							// Check the borrow line
							if (ckbBorrowLine.Checked)
							{
								if (cbbBorrowLine.SelectedIndex == -1)
									throw new SWLHMSException("�п�ܭɤJ���u");

								borrower = (string)this.cbbBorrowLine.SelectedItem;
							}

                            // Check the number of done
                            if (txtNum.Text.Trim() == string.Empty)
								throw new SWLHMSException("����J�����ƶq");
                            int num = int.Parse(txtNum.Text);


							/* Only for 1.08.15 below
							 * 
                            // Check whether part number is duplicated
							string checkExpr = "�u�~�s�� = '" + wpID + "' AND �u�@�渹 ='" + worksheetNumber + "'";
							if(borrower != null)
								checkExpr += " AND �ɤJ���u = '" + borrower + "'";
							else
								checkExpr += " AND �ɤJ���u IS NULL ";
							if ((int)_dataTable.Compute("Count(�~��)", checkExpr) > 0)
								throw new SWLHMSException("�~�� '" + partNumber + "' �w�s�b");
							*/

                            // Check the remain amount
                            if (_remainAmount < num)
								throw new SWLHMSException("��J�ƶq�W�L�Ѿl�ƶq");

							// hour type
							HourType hourType = (HourType)cbxHourType.SelectedIndex;
                            
							string QCN = txtQCN.Text;

							newRow.FillRow(this.SelectedLaborNumber, dtpDate.Value, worksheetNumber, hour, num, borrower, QCN, wpID, hourType);
                            newRow.�s�� = "*";
							newRow["�~��"] = partNumber;
							newRow["�u�������W��"] = hourType.ToString();

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
                            if(cbbNonProduce.Text == "��L" && tbxRemark.Text == string.Empty)
								throw new SWLHMSException("�D�Ͳ����ج� ��L �ɡA�Ƶ��椣�o����");

                            newRow.FillRow(cbxLaborNumber.SelectedValue.ToString(), dtpDate.Value, hour, (int)cbbNonProduce.SelectedValue, cbbNonProduce.Text, tbxRemark.Text);
                            newRow.�s�� = "*";
							newRow["�u�������W��"] = HourType.�@��u��.ToString();
                            _dataTable.Rows.Add(newRow);
                        }
                    }

                    dgvHoursData.AutoResizeColumns();
                    UpdateRemainHour();
                    UpdateRemainAmount();
                }
                else
					throw new SWLHMSException("��g�ɼƶW�L�Ѿl�ɼ�");
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
                MessageBox.Show("�u�ɥ������@�ӥ���");
                e.Cancel = true;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (_remainHours > 0 && !this.TodayIsHoliday)
					throw new SWLHMSException("�|���ɼƥ���g����");

                if (MessageBox.Show("��Ƹg�e�X�ᤣ�i�A�ק�A�нT�{���~��", "�e�X�T�{", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    //SetFinishDate();
					

					int update = �u��TableAdapter.Instance.Update((DatabaseSet.�u��DataTable)_dataTable.Copy());
					UpdateFinishDate();

					int reinspect;
					int qa = UpdateQATable(out reinspect);

					string msg = "�s�W�F " + update + " �����";
					if (qa > 0)
						msg += "\n�s�W�F " + qa + " ��������";
					if (reinspect > 0)
						msg += "\n���s�e��F " + reinspect + "�����";

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
					if (MessageBox.Show("�|���ɼƥ���g�����A�T�w�n�x�s��?", "�x�s����", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
						return;
				}

				//SetFinishDate();

				//����᪺�u�ɸ�ƧR���ɶi��_��u�@
				int update = 0;

				DatabaseSet.�u��DataTable table = (DatabaseSet.�u��DataTable)_dataTable.Copy();
				foreach (DataRow row in _dataTable)
				{
				    if (row.RowState == DataRowState.Deleted)
				    {
				        string id = (string)row["�s��", DataRowVersion.Original];
						update += �u��TableAdapter.Instance.DeleteEx(id);
				    }
				}
				foreach(DataRow row in table.Select(null, null, DataViewRowState.Deleted))
					row.AcceptChanges();

				update += �u��TableAdapter.Instance.Update(table);
				UpdateFinishDate();

				int reinspect;
				int qa = UpdateQATable(out reinspect);

				string msg = "��s�F " + update + " �����";
				if (qa > 0)
					msg += "\n�s�W�F " + qa + " ��������";
				if (reinspect > 0)
					msg += "\n���s�e��F " + reinspect + "�����";

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

                    lbRemain.Text = "����|�l" + Settings.WorkingHoursPerDay + "�p��";
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

                if (selectedRow["��ڧ�����"] != DBNull.Value)
                {
                    DateTime date = (DateTime)selectedRow["��ڧ�����"];
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
                string worksheet = (string)selectedRow["�渹"];
                string partnumber = (string)selectedRow["�~��"];
				int wpid = (int)selectedRow["�s��"];

				int finishCount = �u��TableAdapter.Instance.GetFinishProductAmount(worksheet, wpid);
                //finishCount += _lwHelper.GetAmount(worksheet, partnumber);

                decimal allCount = (decimal)selectedRow["�ƶq"];
                _remainAmount = (int)(allCount - finishCount);

                lbRemainCount.Text = "�Ѿl " + _remainAmount + "/" + allCount.ToString("0.#");
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
                    MessageBox.Show("����R���¸��");
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
					//cmd.CommandText = "SELECT �渹 FROM �u�@�� WHERE �渹 LIKE '" + dateTxt + "%'";
					cmd.CommandText = "SELECT �渹 FROM �u�@��";

					//���ͤ������
					List<string> dateFilter = new List<string>();

					string[] dateFunc = new string[] { "YEAR", "MONTH", "DAY" };

					string[] dateTxtArr = dateTxt.Split('-');
					for (int i = 0; i < 3; i++)
					{
						if (!string.IsNullOrEmpty(dateTxtArr[i].Trim()))
						{
							int val = int.Parse(dateTxtArr[i]);
							dateFilter.Add(dateFunc[i] + "(��ڤ��)=" + val);
						}
					}

					if (dateFilter.Count > 0)
						cmd.CommandText += " WHERE " + string.Join(" AND ", dateFilter.ToArray());
				}
				else
					cmd.CommandText = "SELECT �渹 FROM �u�@��";

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
            this.Text = "�u�ɸ�Ƶn�O";
            btnStore.Visible = false;
        }

        public void EditHourdata(string ���u�s��, DateTime ���)
        {
            this.Text = "�u�ɸ�ƽs��";
            btnSend.Visible = false;
            ���u�s�� = ���u�s��.Replace("'", "''");
            DataRow[] rows = DatabaseSet.���uTable.Select("�s�� = '" + ���u�s�� + "'");
            if (rows.Length > 0)
                _editLaborRow = rows[0] as DatabaseSet.���uRow;
            else
				throw new SWLHMSException("�䤣����u�s�� " + ���u�s�� + " �����");

            cbbLine.SelectedValue = _editLaborRow.���u;

            cbxLaborNumber.DisplayMember = "�s��";
            cbxLaborNumber.ValueMember = "�s��";
            cbxLaborName.DisplayMember = "�m�W";
            cbxLaborName.ValueMember = "�m�W";

            bsLabor.DataSource = _editLaborRow;

            dtpDate.Value = ���;

            LoadOldHourData();
            UpdateRemainHour();
        }

        void LoadOldHourData()
        {
            if (cbxLaborNumber.SelectedIndex != -1)
            {
                _dataTable.Clear();
                �u��TableAdapter.Instance.Fill(_dataTable, cbxLaborNumber.SelectedValue.ToString(), true, dtpDate.Value, dtpDate.Value);
				foreach (DataRow row in _dataTable)
				{
					row["�u�������W��"] = ((HourType)row["�u������"]).ToString();
				}

                dgvHoursData.AutoResizeColumns();
            }
        }

        void LoadUnfilledData()
        {
            if (cbxLaborNumber.SelectedIndex != -1)
            {
                DatabaseSet.�u��DataTable table = �u��TableAdapter.Instance.GetFilledDataBy���u�s��(cbxLaborNumber.SelectedValue.ToString());
                DateTime from = Settings.UnfilledDate;
                DateTime to = DateTime.Today;
                
                for (DateTime date = from; date <= to; date = date.AddDays(1))
                {
                    if (!����TableAdapter.Instance.IsHoliday(_holidayTable, date))
                    {
                        if (date != dtpDate.Value)
                        {
                            DataRow[] rows = table.Select("��� = #" + date.ToString("yyyy/MM/dd") + "#");
                            if (rows.Length == 0)
                            {
								llbUnfilledTip.Text = date.ToString("yyyy/MM/dd") + "����Ʃ|����g����";
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
            if (!����TableAdapter.Instance.IsHoliday(_holidayTable, dtpDate.Value))
            {
                object o;
                decimal hour;
                o = _dataTable.Compute("SUM(�u��)", "");

                hour = Convert.IsDBNull(o) ? 0 : (decimal)o;

                decimal oldHour = 0;

                //if (cbxLaborNumber.SelectedIndex != -1)
                //{
                //    o = �u��TableAdapter.Instance.GetCountBy���u�s��_���(cbxLaborNumber.SelectedValue.ToString(), dtpDate.Value);
                //    oldHour = (o == null) ? 0 : (decimal)o;
                //}

                _remainHours = Settings.WorkingHoursPerDay - hour - oldHour;

                lbRemain.Text = "����|�l" + _remainHours.ToString("0.##") + "�p��";

                TodayIsHoliday = false;
            }
            else
            {
                TodayIsHoliday = true;

                lbRemain.Text = "���鬰����";
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
                    string line = (string)row["���u"];

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
                bsLabor.DataSource = ���uTableAdapter.Instance.GetBy���u(line);
                cbxLaborNumber.DisplayMember = cbxLaborNumber.ValueMember = "�s��";
                cbxLaborName.DisplayMember = cbxLaborName.ValueMember = "�m�W";
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
                string worksheetNumber = kv.Key["�u�@�渹"].ToString();
                string partNumber = kv.Key["�~��"].ToString();
				int wpid = (int)kv.Key["�u�~�s��"];

				if (�u�@��~��TableAdapter.Instance.SetFinishDate(kv.Value, worksheetNumber, wpid) == 0)
					throw new SWLHMSException("�~�� '" + partNumber + "' �]�w��������ɵo�Ϳ��~");

                // Check the finish date
                DatabaseSet.�u�@��~��DataTable table = �u�@��~��TableAdapter.Instance.GetBy�渹(worksheetNumber);
                bool allFinished = true;
                DateTime maxDate = DateTime.MinValue;
                foreach (DatabaseSet.�u�@��~��Row row in table)
                {
                    if (row["��ڧ�����"] == DBNull.Value)
                    {
                        allFinished = false;
                        break;
                    }
                    DateTime date = row.��ڧ�����;
                    if (date > maxDate)
                        maxDate = date;
                }
                if (allFinished)
                    �u�@��TableAdapter.Instance.SetFinishDate(maxDate, worksheetNumber);
            }
        }

		void UpdateFinishDate()
		{
			foreach (DataRow row in _dataTable)
			{
				if (row.RowState == DataRowState.Deleted)
				{
					string worksheet = row["�u�@�渹", DataRowVersion.Original] as string;

					if (!string.IsNullOrEmpty(worksheet))
					{
						int wpid = (int)row["�u�~�s��", DataRowVersion.Original];
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

		public DatabaseSet.�u��DataTable CreateDataTable()
		{
			DatabaseSet.�u��DataTable table = new DatabaseSet.�u��DataTable();
			//table.Columns.Add(new DataColumn("QCN", typeof(string)));
			table.Columns.Add(new DataColumn("����ƶq", typeof(Int32)));
			table.Columns.Add(new DataColumn("�~��", typeof(string)));
			table.Columns.Add(new DataColumn("���N�s��", typeof(string)));
			table.Columns.Add(new DataColumn("�u�������W��", typeof(string)));
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

			DatabaseSet.���~����DataTable qaTable = new DatabaseSet.���~����DataTable();
			foreach (DataRow row in _dataTable.Rows)
			{
				if (row.RowState != DataRowState.Added)
					continue;

				if (row["����ƶq"] == DBNull.Value || row["����ƶq"] == null)
					continue;
				
				int amount = (int)row["����ƶq"];
				if (amount == 0)
					continue;

				if (row["���N�s��"] != DBNull.Value)
				{
					reinspect += ���~����TableAdapter.Instance.Reinspect(row["���N�s��"].ToString(), row["�s��"].ToString(), row["QCN"].ToString(), (int)row["����ƶq"]);
				}
				else
				{
					DatabaseSet.���~����Row qaRow = qaTable.New���~����Row();
					qaRow["�u�ɸ�ƽs��"] = row["�s��"];
					qaRow["����ƶq"] = amount;
					qaRow["QCN"] = row["QCN"];
					qaRow["�e�˦���"] = 1;
					qaRow["�̫�e�˽s��"] = row["�s��"];
					qaRow["�̫��������"] = false;
					qaRow["����"] = false;
					qaRow["����"] = false;
					qaRow["�e�ˤ��"] = DateTime.Now;
					qaTable.Add���~����Row(qaRow);
				}
			}

			return ���~����TableAdapter.Instance.Update(qaTable);
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
						DatabaseSet.�u��Row row = form.DataRow;

						string replace = row["���N�s��"].ToString();

						if (_dataTable.Select("���N�s�� = '" + replace + "'").Length > 0)
							throw new SWLHMSException("���������Ƥw�s�b");

						DatabaseSet.�u��Row newRow = _dataTable.New�u��Row();

						//MessageBox.Show("�u�ɸ�ƽs�� " + form.SelectedHourDataID);

						// Check the borrow line
						string borrower = null;
						if (ckbBorrowLine.Checked)
						{
							if (cbbBorrowLine.SelectedIndex == -1)
								throw new SWLHMSException("�п�ܭɤJ���u");

							borrower = (string)this.cbbBorrowLine.SelectedItem;
						}

						// hour type
						HourType hourType = (HourType)cbxHourType.SelectedIndex;

						newRow["�~��"] = row["�~��"];
						newRow["���N�s��"] = row["���N�s��"];
						newRow.FillRow(this.SelectedLaborNumber, dtpDate.Value, row["�u�@�渹"].ToString(), (decimal)row["�u��"], (int)row["����ƶq"], borrower, row["QCN"].ToString(), (int)row["�u�~�s��"], hourType);
						newRow.�s�� = "*";
						newRow["�u�������W��"] = hourType.ToString();
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