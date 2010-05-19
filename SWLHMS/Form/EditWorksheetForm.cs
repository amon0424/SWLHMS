using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Mong.DatabaseSetTableAdapters;
namespace Mong
{
    public partial class EditWorksheetForm : Form
    {
        //DatabaseSet _editDataSet;
        DatabaseSet.工作單DataTable _worksheetTable;
        DatabaseSet.工作單品號DataTable _worksheetPartTable;

        public EditWorksheetForm()
        {
            InitializeComponent();

            bsSeriesCbx.DataSource = DatabaseSet.產品系列Table;

            cbxSeries.DisplayMember = "編號";
            cbxSeries.ValueMember = "編號";

            cbxSeriesName.DisplayMember = "代號";
            cbxSeriesName.ValueMember = "代號";

            cbxSeries_SelectedIndexChanged(null, null);

            dtpBegin.Value = DateTime.Today;
            dtpEnd.Value = DateTime.Today;
            //dtpCustomerNeed.Value = DateTime.Today;
            //dtpEstimate.Value = DateTime.Today;

//#if !DEBUG
//            btnDelWorksheet.Visible = false;
//#endif
        }

        private void cbxSeries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSeries.SelectedIndex != -1 && bsSeriesCbx.DataSource != null)
            {
                int series = (int)cbxSeries.SelectedValue;

                DatabaseSet.產品品號ViewDataTable table = new DatabaseSet.產品品號ViewDataTable();
                產品品號ViewTableAdapter.Instance.FillBy系列編號(table, series);

                bsPart.DataSource = table;
                dgvPart.AutoResizeColumns();
            }
        }

        private void dgvPart_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPart.CurrentRow != null)
            {
                tbxPartNumber.Text = dgvPart.CurrentRow.Cells["col品號2"].Value.ToString();
            }
        }
        
        string _curWorkshhetLine;

        private void btnAddPart_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxWorksheetNumber.Text == string.Empty)
					throw new SWLHMSException("請先填寫工作單號");

                if (dgvPart.CurrentRow != null && bsWorksheetPart.DataSource != null)
                {
                    string partNumber = tbxPartNumber.Text;
                    string line;
                    if (partNumber != dgvPart.CurrentRow.Cells["col品號2"].Value.ToString())
                    {
                        DatabaseSet.產品品號DataTable tmpTable = 產品品號TableAdapter.Instance.GetBy品號(partNumber);
                        if (tmpTable.Rows.Count == 0)
							throw new SWLHMSException("品號 " + partNumber + " 不存在");
                        line = tmpTable[0].產線;
                    }
                    else
                        line = dgvPart.CurrentRow.Cells["col產線"].Value.ToString();

                    DatabaseSet.工作單品號DataTable table = bsWorksheetPart.DataSource as DatabaseSet.工作單品號DataTable;

                    //檢查產線一致性
                    if (table.Count > 0)
                    {
                        if (line != _curWorkshhetLine)
							throw new SWLHMSException("目前工作單產線為 " + _curWorkshhetLine + "，品號 " + partNumber + " 產線為 " + line + "，請選擇同一產線品號");
                    }
                    else
                        _curWorkshhetLine = line;

                    DatabaseSet.工作單品號Row row = table.New工作單品號Row();

                    row.FillRow(tbxWorksheetNumber.Text, partNumber, 0);

					// For tmp value
					int id = 0;
					object tmp = table.Compute("MAX(編號)", null);
					if (tmp != DBNull.Value)
						id = Convert.ToInt32(tmp);
					row.編號 = id+1;

                    table.Rows.Add(row);
                }
            }
            catch (ConstraintException)
            {
                MessageBox.Show("品號 " + dgvPart.CurrentRow.Cells["col品號2"].Value.ToString() + " 已經存在");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnAddWorksheet_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxWorksheetNumber.Text == string.Empty)
					throw new SWLHMSException("單號不得為空值");

                if ((int)工作單TableAdapter.Instance.GetCountBy單號(tbxWorksheetNumber.Text) > 0)
					throw new SWLHMSException("已存在工作單號 " + tbxWorksheetNumber.Text + "，請指定其他工作單號");

				//if (tbxCustomerName.Text == string.Empty)
				//    throw new Exception("客戶名稱不得為空值");

				CheckField();

                if (MessageBox.Show("工作單號欄位送出後即不可修改，請確認", "新增確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {

                    FillWorksheetNumber();
                    DateTime? end = ckbEnd.Checked ? (DateTime?)dtpEnd.Value : (DateTime?)null;

                    // For 1.02
                    //int count = 工作單TableAdapter.Instance.Insert(tbxWorksheetNumber.Text, tbxCustomerName.Text, dtpBegin.Value, end, dtpEstimate.Value, dtpCustomerNeed.Value);
                    int count = 工作單TableAdapter.Instance.Insert(tbxWorksheetNumber.Text, dtpBegin.Value, end);
                    int partCount = 工作單品號TableAdapter.Instance.UpdateEx(bsWorksheetPart.DataSource as DatabaseSet.工作單品號DataTable);

                    if (count > 0)
                    {
                        MessageBox.Show("新增 " + count + " 筆工作單\n" + partCount + " 筆品號");

						EditWorksheetForm form = new EditWorksheetForm();
						form.NewWorksheet();
						form.MdiParent = this.MdiParent;
						form.Show();

                        this.Close();
                    }
                    else
						throw new SWLHMSException("新增工作單失敗");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

		void CheckField()
		{
			DatabaseSet.工作單品號DataTable table = bsWorksheetPart.DataSource as DatabaseSet.工作單品號DataTable;
			foreach (DataRow row in table.Rows)
			{
				if (row.RowState == DataRowState.Deleted)
					continue;

				if (string.IsNullOrEmpty(row["客戶"] as string))
					throw new SWLHMSException("品號 " + row["品號"] + " 客戶欄不得為空");
			}
		}

        private void tbxWorksheetNumber_Validated(object sender, EventArgs e)
        {
            tbxWorksheetNumber.Text = tbxWorksheetNumber.Text.Trim();
        }

        private void tbxPartNumber_Validated(object sender, EventArgs e)
        {
            tbxPartNumber.Text = tbxPartNumber.Text.Trim();
        }

        public void NewWorksheet()
        {
            bsWorksheetPart.DataSource = new DatabaseSet.工作單品號DataTable();
            btnStoreWorksheet.Visible = false;
            btnDelWorksheet.Visible = false;
            lbStroeTip.Visible = false;

            // Generate the serial number
            OleDbConnection conn = DbConnection.Instance;
            ConnectionState oriConnState = conn.State;
            if ((conn.State & ConnectionState.Open) != ConnectionState.Open)
                conn.Open();

            OleDbParameter param = new OleDbParameter("單據日期", OleDbType.Date);
            param.SourceColumn = "單據日期";
            param.Value = DateTime.Today;

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT MAX(單號) FROM 工作單 WHERE 單據日期 = ? ";
            cmd.Parameters.Add(param);

			object result = cmd.ExecuteScalar();
			int sn = 1;
			if (!string.IsNullOrEmpty(result as string))
			{
				string max = result.ToString();
				sn = int.Parse(max.Substring(8, 4)) + 1;
			}

            if (oriConnState == ConnectionState.Closed)
                conn.Close();

			tbxWorksheetNumber.Text = DateTime.Today.ToString("yyyyMMdd") + sn.ToString("0000");
        }

        public void EditWorksheet(string WorksheetNumber)
        {
            if ((_worksheetTable = 工作單TableAdapter.Instance.GetBy單號(WorksheetNumber)).Count > 0)
            {
                bsWorksheet.DataSource = _worksheetTable[0];

                tbxWorksheetNumber.ReadOnly = true;
                tbxWorksheetNumber.DataBindings.Add("Text", bsWorksheet, "單號", true, DataSourceUpdateMode.Never);
                //tbxCustomerName.DataBindings.Add("Text", bsWorksheet, "客戶名稱", true, DataSourceUpdateMode.OnPropertyChanged);
                dtpBegin.DataBindings.Add("Value", bsWorksheet, "單據日期", true, DataSourceUpdateMode.OnPropertyChanged);
                dtpEnd.DataBindings.Add("Value", bsWorksheet, "實際完成日", true, DataSourceUpdateMode.Never, DateTime.Today);
                //dtpCustomerNeed.DataBindings.Add("Value", bsWorksheet, "客戶需貨日", true, DataSourceUpdateMode.OnPropertyChanged);
                //dtpEstimate.DataBindings.Add("Value", bsWorksheet, "預計完成日", true, DataSourceUpdateMode.OnPropertyChanged);

                if (_worksheetTable[0]["實際完成日"] != DBNull.Value)
                    ckbEnd.Checked = true;

                _worksheetPartTable = 工作單品號TableAdapter.Instance.GetBy單號(_worksheetTable[0].單號);
                bsWorksheetPart.DataSource = _worksheetPartTable;

                //判斷目前工作單所屬產線
                if (_worksheetPartTable.Count > 0)
                {
                    DatabaseSet.產品品號DataTable tmpTable = 產品品號TableAdapter.Instance.GetBy品號(_worksheetPartTable[0].品號);
                    if (tmpTable.Count > 0)
                        _curWorkshhetLine = tmpTable[0].產線;
                    else
						throw new SWLHMSException("找不到品號 " + _worksheetPartTable[0].品號 + " 的資料");
                }

                btnAddWorksheet.Visible = false;
            }
            else
            {
				throw new SWLHMSException("找不到單號 " + WorksheetNumber + " 的資料");
            }
        }

        void FillWorksheetNumber()
        {
            if (bsWorksheetPart.DataSource != null)
            {
                DatabaseSet.工作單品號DataTable table = bsWorksheetPart.DataSource as DatabaseSet.工作單品號DataTable;
                foreach (DatabaseSet.工作單品號Row row in table)
                {
                    row.單號 = tbxWorksheetNumber.Text;
                }
            }
        }

        private void EditWorksheetForm_Load(object sender, EventArgs e)
        {

        }

        private void btnStoreWorksheet_Click(object sender, EventArgs e)
        {
            StoreWorksheet();
        }

        void StoreWorksheet()
        {
			try
			{
				CheckField();

				// Check the finish date
				//bool allFinished = true;
				//DateTime maxDate = DateTime.MinValue;
				//foreach (DatabaseSet.工作單品號Row row in _worksheetPartTable)
				//{
				//    if (row.RowState == DataRowState.Deleted)
				//        continue;

				//    if (row["實際完成日"] == DBNull.Value)
				//    {
				//        allFinished = false;
				//        break;
				//    }
				//    DateTime date = row.實際完成日;
				//    if (date > maxDate)
				//        maxDate = date;
				//}

				//if (allFinished && maxDate != DateTime.MinValue)
				//    _worksheetTable[0].實際完成日 = maxDate;
				//else
				//    _worksheetTable[0]["實際完成日"] = DBNull.Value;

				// Begin update
				int count = 工作單TableAdapter.Instance.Update(_worksheetTable);
				int partCount = 工作單品號TableAdapter.Instance.UpdateEx(_worksheetPartTable);

				//進行數量檢查
				DatabaseSet.UpdateWorksheetFinishStatus(((DatabaseSet.工作單Row)bsWorksheet.DataSource).單號);

				MessageBox.Show("更新 " + count + " 筆工作單資料\n更新 " + partCount + " 筆品號");
			}
			catch (Exception ex)
			{
				Global.ShowError(ex);
			}
        }

        private void ckbEnd_CheckedChanged(object sender, EventArgs e)
        {
            //dtpEnd.Enabled = ckbEnd.Checked;
        }

        private void btnDelWorksheet_Click(object sender, EventArgs e)
        {
            try
            {
                string worksheet = tbxWorksheetNumber.Text;

				//OleDbConnection conn = DbConnection.Instance;
				//conn.Open();

				//string cmdText = "SELECT COUNT(*) FROM 工時 WHERE 工作單號 = ? ";

				//OleDbParameter paramWs = new OleDbParameter("工作單號", worksheet);

				//OleDbCommand cmd = new OleDbCommand(cmdText, conn);
				//cmd.Parameters.Add(paramWs);

				//int result = (int)cmd.ExecuteScalar();

				//if (result != 0)
				//{
				//    MessageBox.Show("工作單 '" + worksheet + "' 已有工時資料登記，無法刪除。");
				//}
				//else 
					
				if (MessageBox.Show("確定刪除工作單 " + worksheet + " 及其所有相關資料?\n(LaborWage程式裡的相關資料並不會被刪除)", "刪除提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    _worksheetTable[0].Delete();
                    MessageBox.Show("刪除了" + 工作單TableAdapter.Instance.Update(_worksheetTable) + "筆資料");
                    this.Close();
                }

                //conn.Close();
            }
            catch (Exception ex)
            {
                Global.ShowError(ex);
            }
        }

        private void dgvWorksheetPart_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex == col預計完成日.Index ||
                e.ColumnIndex == col實際完成日.Index ||
                e.ColumnIndex == col客戶需貨日.Index)
            {
                Global.ShowError("輸入日期格式錯誤\n回復舊值或取消編輯請按ESC鍵");
            }
            else if (e.ColumnIndex == col數量.Index)
            {
                Global.ShowError("輸入數量格式錯誤\n回復舊值或取消編輯請按ESC鍵");
            }
            else
            {
                e.ThrowException = true;
            }
        }

        private void dgvWorksheetPart_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (e.Row == null)
                    return;

                string worksheet = tbxWorksheetNumber.Text;
				string partnumber = (string)e.Row.Cells["col品號"].Value;
				int wpid = (int)e.Row.Cells["col編號"].Value;

                OleDbConnection conn = DbConnection.Instance;
                conn.Open();

                string cmdText = "SELECT COUNT(*) FROM 工時 WHERE 工作單號 = ? AND 工品編號 = ? ";

                OleDbParameter paramWs = new OleDbParameter("工作單號", worksheet);
				OleDbParameter paramPart = new OleDbParameter("工品編號", wpid);

                OleDbCommand cmd = new OleDbCommand(cmdText, conn);
                cmd.Parameters.Add(paramWs);
                cmd.Parameters.Add(paramPart);

                int result = (int)cmd.ExecuteScalar();

                if (result != 0)
                {
                    MessageBox.Show("品號 '" + partnumber + "' 已有工時資料登記，無法刪除。");
                    e.Cancel = true;
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                Global.ShowError(ex);
                e.Cancel = true;
            }
        }

		private void dgvWorksheetPart_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
			//if (col實際完成日.Index == e.ColumnIndex)
			//{
			//    if (dgvWorksheetPart[e.ColumnIndex, e.RowIndex].Value == DBNull.Value)
			//    {
			//        //dgvWorksheetPart[e.ColumnIndex, e.RowIndex].
			//        dgvWorksheetPart[e.ColumnIndex, e.RowIndex].Value = "//";
			//    }
					
			//}

		}
        
    }
}