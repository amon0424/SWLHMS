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

        DatabaseSet.���~�t�CRow SelectedSerialRow
        {
            get
            {
                return (bsSeries.Current as DataRowView).Row as DatabaseSet.���~�t�CRow;
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

            bsSeries.DataSource = DatabaseSet.���~�t�CTable;
            bsSeriesCbx.DataSource = DatabaseSet.���~�t�CTable;
            bsLineCbx.DataSource = DatabaseSet.���uTable;

            tbxSeries.DataBindings.Add("Text", bsSeries, "�s��",true,DataSourceUpdateMode.Never);
            tbxSeriesName.DataBindings.Add("Text", bsSeries, "�N��", true, DataSourceUpdateMode.Never);

            col�t�C�s��.DataSource = bsSeriesCbx;
            col�t�C�s��.DisplayMember = "�s��";
            col�t�C�s��.ValueMember = "�s��";

            col���u.DataSource = bsLineCbx;
            col���u.DisplayMember = "���u";
            col���u.ValueMember = "���u";

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
                if (dgvPart.CurrentCell.ColumnIndex == dgvPart.Columns["col�t�C�s��"].Index)
                {
                    dgvPart.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
        }

        private void dgvPart_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvPart.CurrentCell.ColumnIndex == dgvPart.Columns["col�t�C�s��"].Index)
            {
                if (dgvPart.CurrentCell.Value == DBNull.Value)
                {
                    dgvPart.CurrentCell.Value = dgvSeries.CurrentRow.Cells["col�s��"].Value;
                }
            }
            else if (dgvPart.CurrentCell.ColumnIndex == dgvPart.Columns["col���u"].Index)
            {
                if (dgvPart.CurrentCell.Value == DBNull.Value && DatabaseSet.���uTable.Count > 0)
                {
                    dgvPart.CurrentCell.Value = DatabaseSet.���uTable[0].���u;
                }
            }
        }

        private void dgvPart_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvPart.Rows[e.RowIndex].IsNewRow) 
                return;

            if (e.ColumnIndex == dgvPart.Columns["col�~��"].Index)
            {
                string newPartNumber = e.FormattedValue as string;
                string oriPartNumber = dgvPart[e.ColumnIndex, e.RowIndex].Value as string;

                if (newPartNumber == null || newPartNumber == string.Empty)
                {
                    MessageBox.Show("�~���椣�o����");
                    e.Cancel = true;
                }
                else if (newPartNumber != oriPartNumber)
                {
                    int? count = ���~�~��ViewTableAdapter.Instance.GetCountBy�~��(newPartNumber);

                    //DatabaseSet.���~�~��Table
                    if (count != null && count > 0)
                    {
                        MessageBox.Show("�~�� " + newPartNumber + " ���ơA�Ы��w��L�~��");
                        e.Cancel = true;
                    }
                }
            }
        }

        private void dgvPart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!_initializing)
            {
                if (e.ColumnIndex == dgvPart.Columns["col�t�C�s��"].Index)
                {
                    int series = (int)dgvPart[e.ColumnIndex, e.RowIndex].Value;
                    DataRow[] rows = DatabaseSet.���~�t�CTable.Select("�s�� = " + series.ToString());
                    if (rows.Length > 0)
                    {
                        dgvPart["col�t�C�N��", e.RowIndex].Value = rows[0]["�N��"].ToString();
                    }
                }

                NeedSave = true;
            }
        }

        private void dgvPart_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (dgvPart.CurrentRow.Cells["col�t�C�s��"].Value == DBNull.Value)
            {
                dgvPart.CurrentRow.Cells["col�t�C�s��"].Value = dgvSeries.CurrentRow.Cells["col�s��"].Value;
            }

            if (dgvPart.CurrentRow.Cells["col���u"].Value == DBNull.Value && DatabaseSet.���uTable.Count > 0)
            {
                dgvPart.CurrentRow.Cells["col���u"].Value = DatabaseSet.���uTable[0].���u;
            }
        }

        private void dgvPart_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            // Check whether the PartNo already in any worksheet
            try
            {
                OleDbConnection conn = DbConnection.Instance;
                conn.Open();

                string cmdStr = "SELECT �渹 FROM �u�@��~�� WHERE �~�� = ? ";
                string partNo = GetPartNoRow(e.Row).�~��;

                OleDbParameter paramPartNo = new OleDbParameter("�~��", OleDbType.WChar, 255, ParameterDirection.Input, 0, 0, "�~��", DataRowVersion.Current, false, null);
                paramPartNo.Value = partNo;

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                cmd.CommandText = cmdStr;
                cmd.Parameters.Add(paramPartNo);

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    e.Cancel = true;
                    MessageBox.Show("�~�� '" + partNo + "' �w�b�u�@�� '" + result.ToString() + "' ��");
                }
                else
                {
                    if (MessageBox.Show("�T�w�R���~�� '" + partNo + "' ?", "�T�{", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
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
                MessageBox.Show("�s���������@�ӼƦr");
                tbxSeries.Text = ((int)dgvSeries.CurrentRow.Cells["col�s��"].Value).ToString();
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
                        DatabaseSet.���~�t�CRow row = this.SelectedSerialRow;
                        row.FillRow(newSeries, newSeriesName);

                        ���~�t�CTableAdapter.Instance.Update(row);
                        LoadPart(false);
                       
                    }
                }
                else if (this.SerialState == EditStateType.New)
                {
                    DatabaseSet.���~�t�CRow newRow = DatabaseSet.���~�t�CTable.New���~�t�CRow();
                    newRow.FillRow(newSeries, newSeriesName);
                    DatabaseSet.���~�t�CTable.Rows.Add(newRow);

                    ���~�t�CTableAdapter.Instance.Update(newRow);
                }

                this.SerialState = EditStateType.None;

            }
            catch (ConstraintException)
            {
                MessageBox.Show("�w�s�b�t�C�� " + newSeries + "�A�Ы��w��L�t�C��");
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
                    DatabaseSet.���~�t�CRow row = (bsSeries.Current as DataRowView).Row as DatabaseSet.���~�t�CRow;
                    int series = row.�s��;
                    string seriesName = row.�N��;


                    // Check whether all partnubmer are not in any worksheet
                    OleDbConnection conn = �u�@��~��TableAdapter.Instance.Connection;

                    string cmdTxt = "SELECT COUNT(*) FROM �u�@��~�� INNER JOIN ���~�~�� ON �u�@��~��.�~�� = ���~�~��.�~�� WHERE �t�C�s�� = " + series;
                    OleDbCommand cmd = new OleDbCommand(cmdTxt, conn);

                    conn.Open();
                    object o = cmd.ExecuteScalar();
                    conn.Close();

                    if (o != null && (int)o != 0)
                    {
                        if (MessageBox.Show("�t�C" + series + "(" + seriesName + ")�����~���w�إߤu�@��L�k�R���A�T�w�R����L�~��?", "�R������", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            conn.Open();

                            cmd = new OleDbCommand(
                            "SELECT ���~�~��.�~�� FROM ���~�~�� LEFT JOIN �u�@��~�� ON �u�@��~��.�~�� = ���~�~��.�~�� WHERE �t�C�s�� = " + series + " AND �渹 IS NULL"
                            , conn);

                            OleDbDataReader dr = cmd.ExecuteReader();
                            string delCmdTxt = "DELETE FROM ���~�~�� WHERE �~�� = ?";
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

                            MessageBox.Show("�R���F " + delCount + " ���~��");
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("�T�w�R�� �t�C" + series + "(" + seriesName + ") �Ψ�Ҧ��~��?", "�R������", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            // delete all series
                            row.Delete();
                            ���~�t�CTableAdapter.Instance.Update(row);
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
                    DatabaseSet.���~�~��ViewDataTable table = bsPart.DataSource as DatabaseSet.���~�~��ViewDataTable;

                    MessageBox.Show("��s�F " + ���~�~��ViewTableAdapter.Instance.Update(table) + " �����");

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
                if (MessageBox.Show("�T�w�_��Ҧ��ܧ�?", "�_�촣��", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
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
                bsPart.DataSource = Global.Get���~�~��ViewTable();
            }
            else
            {
                if (dgvSeries.CurrentRow != null)
                {
                    int series = (int)dgvSeries.CurrentRow.Cells["col�s��"].Value;
                    string seriesName = (string)dgvSeries.CurrentRow.Cells["col�N��"].Value;

                    bsPart.DataSource = Global.Get���~�~��ViewTable(series);
                }
            }
        }

        /// <summary>
        /// �^��false�N��ϥΪ̫��U�F����
        /// </summary>
        bool AlertSave()
        {
            if (NeedSave)
            {
                DialogResult result = MessageBox.Show("�A���ܧ�|���x�s�A�O�_�x�s���~��?", "�O�_�x�s", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
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

        DatabaseSet.���~�~��ViewRow GetPartNoRow(DataGridViewRow row)
        {
            return (DatabaseSet.���~�~��ViewRow)((DataRowView)row.DataBoundItem).Row;
        }

		private void dgvPart_CellValidated(object sender, DataGridViewCellEventArgs e)
		{
			if (dgvPart.Columns[e.ColumnIndex] == col�u�� || dgvPart.Columns[e.ColumnIndex] == col�t�ή��~)
			{
				decimal hour = (decimal)dgvPart["col�u��", e.RowIndex].Value;
				decimal wage = (decimal)dgvPart["col�t�ή��~", e.RowIndex].Value;

				decimal unitprice = hour * wage;
				dgvPart["col�зǤu��", e.RowIndex].Value = unitprice;
			}
		}

        
    }
}