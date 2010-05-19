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
    public partial class ProductForm : Form
    {
        

        bool _initializing;
        bool _raiseSelectionChangedEvent;
        bool _needSave;
        DataGridViewRow _lastSelRow;
        EditStateType _serialState;

        DatabaseSet.產品系列Row SelectedSerialRow
        {
            get
            {
                return (bsSeries.Current as DataRowView).Row as DatabaseSet.產品系列Row;
            }
        }
        EditStateType SerialState
        {
            get { return _serialState; }
            set 
            { 
                _serialState = value;
                UpdateSerialUI();
            }
        }

        bool NeedSave
        {
            get { return _needSave; }
            set 
            {
                _needSave = value;
                btnStorePart.Enabled = _needSave;
                btnUndo.Enabled = _needSave;
            }
        }

        public ProductForm()
        {
            _initializing = true;

            InitializeComponent();

            bsSeries.DataSource = DatabaseSet.產品系列Table;
            bsSeriesCbx.DataSource = DatabaseSet.產品系列Table;
            bsLineCbx.DataSource = DatabaseSet.產線Table;

            tbxSeries.DataBindings.Add("Text", bsSeries, "編號",true,DataSourceUpdateMode.Never);
            tbxSeriesName.DataBindings.Add("Text", bsSeries, "代號", true, DataSourceUpdateMode.Never);

            col系列編號.DataSource = bsSeriesCbx;
            col系列編號.DisplayMember = "編號";
            col系列編號.ValueMember = "編號";

            col產線.DataSource = bsLineCbx;
            col產線.DisplayMember = "產線";
            col產線.ValueMember = "產線";

            LoadPart(false);

            _initializing = false;
            _raiseSelectionChangedEvent = true;

            NeedSave = false;
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            this.SerialState = EditStateType.None;
        }

        private void ProductForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !AlertSave();
        }

        private void dgvSeries_SelectionChanged(object sender, EventArgs e)
        {
            if (!_initializing && _raiseSelectionChangedEvent)
            {
                if (_lastSelRow != dgvSeries.CurrentRow && AlertSave())
                {
                    LoadPart(false);
                    NeedSave = false;
                    _lastSelRow = dgvSeries.CurrentRow;
                }
                else
                {
                    _raiseSelectionChangedEvent = false;
                    dgvSeries.CurrentCell = _lastSelRow.Cells[0];
                    _raiseSelectionChangedEvent = true;
                }
            }
        }

        private void dgvPart_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvPart.CurrentCell != null)
            {
                if (dgvPart.CurrentCell.ColumnIndex == dgvPart.Columns["col系列編號"].Index)
                {
                    dgvPart.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
        }

        private void dgvPart_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvPart.CurrentCell.ColumnIndex == dgvPart.Columns["col系列編號"].Index)
            {
                if (dgvPart.CurrentCell.Value == DBNull.Value)
                {
                    dgvPart.CurrentCell.Value = dgvSeries.CurrentRow.Cells["col編號"].Value;
                }
            }
            else if (dgvPart.CurrentCell.ColumnIndex == dgvPart.Columns["col產線"].Index)
            {
                if (dgvPart.CurrentCell.Value == DBNull.Value && DatabaseSet.產線Table.Count > 0)
                {
                    dgvPart.CurrentCell.Value = DatabaseSet.產線Table[0].產線;
                }
            }
        }

        private void dgvPart_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvPart.Rows[e.RowIndex].IsNewRow) 
                return;

            if (e.ColumnIndex == dgvPart.Columns["col品號"].Index)
            {
                string newPartNumber = e.FormattedValue as string;
                string oriPartNumber = dgvPart[e.ColumnIndex, e.RowIndex].Value as string;

                if (newPartNumber == null || newPartNumber == string.Empty)
                {
                    MessageBox.Show("品號欄不得為空");
                    e.Cancel = true;
                }
                else if (newPartNumber != oriPartNumber)
                {
                    int? count = 產品品號ViewTableAdapter.Instance.GetCountBy品號(newPartNumber);

                    //DatabaseSet.產品品號Table
                    if (count != null && count > 0)
                    {
                        MessageBox.Show("品號 " + newPartNumber + " 重複，請指定其他品號");
                        e.Cancel = true;
                    }
                }
            }
        }

        private void dgvPart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!_initializing)
            {
                if (e.ColumnIndex == dgvPart.Columns["col系列編號"].Index)
                {
                    int series = (int)dgvPart[e.ColumnIndex, e.RowIndex].Value;
                    DataRow[] rows = DatabaseSet.產品系列Table.Select("編號 = " + series.ToString());
                    if (rows.Length > 0)
                    {
                        dgvPart["col系列代號", e.RowIndex].Value = rows[0]["代號"].ToString();
                    }
                }

                NeedSave = true;
            }
        }

        private void dgvPart_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (dgvPart.CurrentRow.Cells["col系列編號"].Value == DBNull.Value)
            {
                dgvPart.CurrentRow.Cells["col系列編號"].Value = dgvSeries.CurrentRow.Cells["col編號"].Value;
            }

            if (dgvPart.CurrentRow.Cells["col產線"].Value == DBNull.Value && DatabaseSet.產線Table.Count > 0)
            {
                dgvPart.CurrentRow.Cells["col產線"].Value = DatabaseSet.產線Table[0].產線;
            }
        }

        private void dgvPart_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            // Check whether the PartNo already in any worksheet
            try
            {
                OleDbConnection conn = DbConnection.Instance;
                conn.Open();

                string cmdStr = "SELECT 單號 FROM 工作單品號 WHERE 品號 = ? ";
                string partNo = GetPartNoRow(e.Row).品號;

                OleDbParameter paramPartNo = new OleDbParameter("品號", OleDbType.WChar, 255, ParameterDirection.Input, 0, 0, "品號", DataRowVersion.Current, false, null);
                paramPartNo.Value = partNo;

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                cmd.CommandText = cmdStr;
                cmd.Parameters.Add(paramPartNo);

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    e.Cancel = true;
                    MessageBox.Show("品號 '" + partNo + "' 已在工作單 '" + result.ToString() + "' 中");
                }
                else
                {
                    if (MessageBox.Show("確定刪除品號 '" + partNo + "' ?", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                        e.Cancel = true;
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                Global.ShowError(ex);
            }
        }

        private void dgvPart_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            NeedSave = true;
        }

        private void dgvPart_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if ((e.Context & DataGridViewDataErrorContexts.Commit) == DataGridViewDataErrorContexts.Commit)
                MessageBox.Show(e.Exception.Message);
        }

        private void bsPart_DataSourceChanged(object sender, EventArgs e)
        {
            dgvPart.AutoResizeColumns();
        }

        private void tbxSeriesName_Validated(object sender, EventArgs e)
        {
            tbxSeriesName.Text = tbxSeriesName.Text.Trim();
        }

        private void tbxSeries_Validating(object sender, CancelEventArgs e)
        {
            int i;
            if ((e.Cancel = !int.TryParse(tbxSeries.Text, out i)) == true)
            {
                MessageBox.Show("編號必須為一個數字");
                tbxSeries.Text = ((int)dgvSeries.CurrentRow.Cells["col編號"].Value).ToString();
                tbxSeries.SelectAll();
            }
        }

        private void tbxSeriesName_Validating(object sender, CancelEventArgs e)
        {
        }

        private void btnStoreSeries_Click(object sender, EventArgs e)
        {
            int newSeries = int.Parse(tbxSeries.Text);
            string newSeriesName = tbxSeriesName.Text;

            try
            {
                if (this.SerialState == EditStateType.Edit)
                {
                    if (bsSeries.Current != null)
                    {
                        DatabaseSet.產品系列Row row = this.SelectedSerialRow;
                        row.FillRow(newSeries, newSeriesName);

                        產品系列TableAdapter.Instance.Update(row);
                        LoadPart(false);
                       
                    }
                }
                else if (this.SerialState == EditStateType.New)
                {
                    DatabaseSet.產品系列Row newRow = DatabaseSet.產品系列Table.New產品系列Row();
                    newRow.FillRow(newSeries, newSeriesName);
                    DatabaseSet.產品系列Table.Rows.Add(newRow);

                    產品系列TableAdapter.Instance.Update(newRow);
                }

                this.SerialState = EditStateType.None;

            }
            catch (ConstraintException)
            {
                MessageBox.Show("已存在系列號 " + newSeries + "，請指定其他系列號");
                tbxSeries.SelectAll();
            }
            catch (Exception ex)
            {
                Global.ShowError(ex);
            }
            finally
            {
                if (this.SerialState == EditStateType.Edit)
                {
                    tbxSeries.DataBindings[0].ReadValue();
                    tbxSeriesName.DataBindings[0].ReadValue();
                }
            }
        }

        private void btnEditSeries_Click(object sender, EventArgs e)
        {
            this.SerialState = EditStateType.Edit;
        }

        private void btnAddSeries_Click(object sender, EventArgs e)
        {
            this.SerialState = EditStateType.New;
        }

        private void btnCancelSerials_Click(object sender, EventArgs e)
        {
            this.SerialState = EditStateType.None;
        }

        private void btnDelSeries_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsSeries.Current != null)
                {
                    DatabaseSet.產品系列Row row = (bsSeries.Current as DataRowView).Row as DatabaseSet.產品系列Row;
                    int series = row.編號;
                    string seriesName = row.代號;


                    // Check whether all partnubmer are not in any worksheet
                    OleDbConnection conn = 工作單品號TableAdapter.Instance.Connection;

                    string cmdTxt = "SELECT COUNT(*) FROM 工作單品號 INNER JOIN 產品品號 ON 工作單品號.品號 = 產品品號.品號 WHERE 系列編號 = " + series;
                    OleDbCommand cmd = new OleDbCommand(cmdTxt, conn);

                    conn.Open();
                    object o = cmd.ExecuteScalar();
                    conn.Close();

                    if (o != null && (int)o != 0)
                    {
                        if (MessageBox.Show("系列" + series + "(" + seriesName + ")部分品號已建立工作單無法刪除，確定刪除其他品號?", "刪除提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            conn.Open();

                            cmd = new OleDbCommand(
                            "SELECT 產品品號.品號 FROM 產品品號 LEFT JOIN 工作單品號 ON 工作單品號.品號 = 產品品號.品號 WHERE 系列編號 = " + series + " AND 單號 IS NULL"
                            , conn);

                            OleDbDataReader dr = cmd.ExecuteReader();
                            string delCmdTxt = "DELETE FROM 產品品號 WHERE 品號 = ?";
                            OleDbCommand delCmd = new OleDbCommand(delCmdTxt, conn);
                            OleDbParameter param = new OleDbParameter();
                            delCmd.Parameters.Add(param);
                            int delCount = 0;

                            while (dr.Read())
                            {
                                string pn = (string)dr.GetValue(0);
                                param.Value = pn;
                                delCount += delCmd.ExecuteNonQuery();
                            }
                            conn.Close();

                            MessageBox.Show("刪除了 " + delCount + " 筆品號");
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("確定刪除 系列" + series + "(" + seriesName + ") 及其所有品號?", "刪除提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            // delete all series
                            row.Delete();
                            產品系列TableAdapter.Instance.Update(row);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStorePart_Click(object sender, EventArgs e)
        {
            StorePart();
        }

        private void btnDisplayAllPart_Click(object sender, EventArgs e)
        {
            LoadPart(true);
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            UndoPart();
        }

        private void btnImportLH_Click(object sender, EventArgs e)
        {
            ImportProductForm form = new ImportProductForm();
            if (form.ShowDialog(this) == DialogResult.OK)
                LoadPart(false);
        }

        void UpdateSerialUI()
        {
            bool editing = (this.SerialState == EditStateType.Edit || this.SerialState == EditStateType.New);
            tbxSeries.ReadOnly = tbxSeriesName.ReadOnly = !editing;
            dgvSeries.Enabled = !editing;
            btnStoreSeries.Visible = btnCancelSerials.Visible = editing;
            btnDelSeries.Visible = btnEditSeries.Visible = btnAddSeries.Visible = !editing;

            if (this.SerialState == EditStateType.New)
            {
                tbxSeries.Clear();
                tbxSeriesName.Clear();
            }
            else
            {
                tbxSeries.DataBindings[0].ReadValue();
                tbxSeriesName.DataBindings[0].ReadValue();
            }
        }

        void StorePart()
        {
            try
            {
                if (bsPart.DataSource != null)
                {
                    DatabaseSet.產品品號ViewDataTable table = bsPart.DataSource as DatabaseSet.產品品號ViewDataTable;

                    MessageBox.Show("更新了 " + 產品品號ViewTableAdapter.Instance.Update(table) + " 筆資料");

                    LoadPart(false);

                    NeedSave = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void UndoPart()
        {
            DataTable table = bsPart.DataSource as DataTable;

            if (table!= null)
            {
                if (MessageBox.Show("確定復原所有變更?", "復原提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    table.RejectChanges();
                    NeedSave = false;
                }
            }
        }

        public void LoadPart(bool isAll)
        {
            if (isAll)
            {
                bsPart.DataSource = Global.Get產品品號ViewTable();
            }
            else
            {
                if (dgvSeries.CurrentRow != null)
                {
                    int series = (int)dgvSeries.CurrentRow.Cells["col編號"].Value;
                    string seriesName = (string)dgvSeries.CurrentRow.Cells["col代號"].Value;

                    bsPart.DataSource = Global.Get產品品號ViewTable(series);
                }
            }
        }

        /// <summary>
        /// 回傳false代表使用者按下了取消
        /// </summary>
        bool AlertSave()
        {
            if (NeedSave)
            {
                DialogResult result = MessageBox.Show("你有變更尚未儲存，是否儲存後繼續?", "是否儲存", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                switch (result)
                {
                    case DialogResult.Yes:
                        StorePart();
                        return true;
                    case DialogResult.No:
                        return true;
                    case DialogResult.Cancel:
                        return false;
                }
            }
            return true;
        }

        DatabaseSet.產品品號ViewRow GetPartNoRow(DataGridViewRow row)
        {
            return (DatabaseSet.產品品號ViewRow)((DataRowView)row.DataBoundItem).Row;
        }

		private void dgvPart_CellValidated(object sender, DataGridViewCellEventArgs e)
		{
			if (dgvPart.Columns[e.ColumnIndex] == col工時 || dgvPart.Columns[e.ColumnIndex] == col系統時薪)
			{
				decimal hour = (decimal)dgvPart["col工時", e.RowIndex].Value;
				decimal wage = (decimal)dgvPart["col系統時薪", e.RowIndex].Value;

				decimal unitprice = hour * wage;
				dgvPart["col標準工資", e.RowIndex].Value = unitprice;
			}
		}

        
    }
}