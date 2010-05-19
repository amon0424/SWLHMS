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
        DatabaseSet.�u�@��DataTable _worksheetTable;
        DatabaseSet.�u�@��~��DataTable _worksheetPartTable;

        public EditWorksheetForm()
        {
            InitializeComponent();

            bsSeriesCbx.DataSource = DatabaseSet.���~�t�CTable;

            cbxSeries.DisplayMember = "�s��";
            cbxSeries.ValueMember = "�s��";

            cbxSeriesName.DisplayMember = "�N��";
            cbxSeriesName.ValueMember = "�N��";

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

                DatabaseSet.���~�~��ViewDataTable table = new DatabaseSet.���~�~��ViewDataTable();
                ���~�~��ViewTableAdapter.Instance.FillBy�t�C�s��(table, series);

                bsPart.DataSource = table;
                dgvPart.AutoResizeColumns();
            }
        }

        private void dgvPart_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPart.CurrentRow != null)
            {
                tbxPartNumber.Text = dgvPart.CurrentRow.Cells["col�~��2"].Value.ToString();
            }
        }
        
        string _curWorkshhetLine;

        private void btnAddPart_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxWorksheetNumber.Text == string.Empty)
					throw new SWLHMSException("�Х���g�u�@�渹");

                if (dgvPart.CurrentRow != null && bsWorksheetPart.DataSource != null)
                {
                    string partNumber = tbxPartNumber.Text;
                    string line;
                    if (partNumber != dgvPart.CurrentRow.Cells["col�~��2"].Value.ToString())
                    {
                        DatabaseSet.���~�~��DataTable tmpTable = ���~�~��TableAdapter.Instance.GetBy�~��(partNumber);
                        if (tmpTable.Rows.Count == 0)
							throw new SWLHMSException("�~�� " + partNumber + " ���s�b");
                        line = tmpTable[0].���u;
                    }
                    else
                        line = dgvPart.CurrentRow.Cells["col���u"].Value.ToString();

                    DatabaseSet.�u�@��~��DataTable table = bsWorksheetPart.DataSource as DatabaseSet.�u�@��~��DataTable;

                    //�ˬd���u�@�P��
                    if (table.Count > 0)
                    {
                        if (line != _curWorkshhetLine)
							throw new SWLHMSException("�ثe�u�@�沣�u�� " + _curWorkshhetLine + "�A�~�� " + partNumber + " ���u�� " + line + "�A�п�ܦP�@���u�~��");
                    }
                    else
                        _curWorkshhetLine = line;

                    DatabaseSet.�u�@��~��Row row = table.New�u�@��~��Row();

                    row.FillRow(tbxWorksheetNumber.Text, partNumber, 0);

					// For tmp value
					int id = 0;
					object tmp = table.Compute("MAX(�s��)", null);
					if (tmp != DBNull.Value)
						id = Convert.ToInt32(tmp);
					row.�s�� = id+1;

                    table.Rows.Add(row);
                }
            }
            catch (ConstraintException)
            {
                MessageBox.Show("�~�� " + dgvPart.CurrentRow.Cells["col�~��2"].Value.ToString() + " �w�g�s�b");
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
					throw new SWLHMSException("�渹���o���ŭ�");

                if ((int)�u�@��TableAdapter.Instance.GetCountBy�渹(tbxWorksheetNumber.Text) > 0)
					throw new SWLHMSException("�w�s�b�u�@�渹 " + tbxWorksheetNumber.Text + "�A�Ы��w��L�u�@�渹");

				//if (tbxCustomerName.Text == string.Empty)
				//    throw new Exception("�Ȥ�W�٤��o���ŭ�");

				CheckField();

                if (MessageBox.Show("�u�@�渹���e�X��Y���i�ק�A�нT�{", "�s�W�T�{", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {

                    FillWorksheetNumber();
                    DateTime? end = ckbEnd.Checked ? (DateTime?)dtpEnd.Value : (DateTime?)null;

                    // For 1.02
                    //int count = �u�@��TableAdapter.Instance.Insert(tbxWorksheetNumber.Text, tbxCustomerName.Text, dtpBegin.Value, end, dtpEstimate.Value, dtpCustomerNeed.Value);
                    int count = �u�@��TableAdapter.Instance.Insert(tbxWorksheetNumber.Text, dtpBegin.Value, end);
                    int partCount = �u�@��~��TableAdapter.Instance.UpdateEx(bsWorksheetPart.DataSource as DatabaseSet.�u�@��~��DataTable);

                    if (count > 0)
                    {
                        MessageBox.Show("�s�W " + count + " ���u�@��\n" + partCount + " ���~��");

						EditWorksheetForm form = new EditWorksheetForm();
						form.NewWorksheet();
						form.MdiParent = this.MdiParent;
						form.Show();

                        this.Close();
                    }
                    else
						throw new SWLHMSException("�s�W�u�@�楢��");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

		void CheckField()
		{
			DatabaseSet.�u�@��~��DataTable table = bsWorksheetPart.DataSource as DatabaseSet.�u�@��~��DataTable;
			foreach (DataRow row in table.Rows)
			{
				if (row.RowState == DataRowState.Deleted)
					continue;

				if (string.IsNullOrEmpty(row["�Ȥ�"] as string))
					throw new SWLHMSException("�~�� " + row["�~��"] + " �Ȥ��椣�o����");
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
            bsWorksheetPart.DataSource = new DatabaseSet.�u�@��~��DataTable();
            btnStoreWorksheet.Visible = false;
            btnDelWorksheet.Visible = false;
            lbStroeTip.Visible = false;

            // Generate the serial number
            OleDbConnection conn = DbConnection.Instance;
            ConnectionState oriConnState = conn.State;
            if ((conn.State & ConnectionState.Open) != ConnectionState.Open)
                conn.Open();

            OleDbParameter param = new OleDbParameter("��ڤ��", OleDbType.Date);
            param.SourceColumn = "��ڤ��";
            param.Value = DateTime.Today;

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT MAX(�渹) FROM �u�@�� WHERE ��ڤ�� = ? ";
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
            if ((_worksheetTable = �u�@��TableAdapter.Instance.GetBy�渹(WorksheetNumber)).Count > 0)
            {
                bsWorksheet.DataSource = _worksheetTable[0];

                tbxWorksheetNumber.ReadOnly = true;
                tbxWorksheetNumber.DataBindings.Add("Text", bsWorksheet, "�渹", true, DataSourceUpdateMode.Never);
                //tbxCustomerName.DataBindings.Add("Text", bsWorksheet, "�Ȥ�W��", true, DataSourceUpdateMode.OnPropertyChanged);
                dtpBegin.DataBindings.Add("Value", bsWorksheet, "��ڤ��", true, DataSourceUpdateMode.OnPropertyChanged);
                dtpEnd.DataBindings.Add("Value", bsWorksheet, "��ڧ�����", true, DataSourceUpdateMode.Never, DateTime.Today);
                //dtpCustomerNeed.DataBindings.Add("Value", bsWorksheet, "�Ȥ�ݳf��", true, DataSourceUpdateMode.OnPropertyChanged);
                //dtpEstimate.DataBindings.Add("Value", bsWorksheet, "�w�p������", true, DataSourceUpdateMode.OnPropertyChanged);

                if (_worksheetTable[0]["��ڧ�����"] != DBNull.Value)
                    ckbEnd.Checked = true;

                _worksheetPartTable = �u�@��~��TableAdapter.Instance.GetBy�渹(_worksheetTable[0].�渹);
                bsWorksheetPart.DataSource = _worksheetPartTable;

                //�P�_�ثe�u�@����ݲ��u
                if (_worksheetPartTable.Count > 0)
                {
                    DatabaseSet.���~�~��DataTable tmpTable = ���~�~��TableAdapter.Instance.GetBy�~��(_worksheetPartTable[0].�~��);
                    if (tmpTable.Count > 0)
                        _curWorkshhetLine = tmpTable[0].���u;
                    else
						throw new SWLHMSException("�䤣��~�� " + _worksheetPartTable[0].�~�� + " �����");
                }

                btnAddWorksheet.Visible = false;
            }
            else
            {
				throw new SWLHMSException("�䤣��渹 " + WorksheetNumber + " �����");
            }
        }

        void FillWorksheetNumber()
        {
            if (bsWorksheetPart.DataSource != null)
            {
                DatabaseSet.�u�@��~��DataTable table = bsWorksheetPart.DataSource as DatabaseSet.�u�@��~��DataTable;
                foreach (DatabaseSet.�u�@��~��Row row in table)
                {
                    row.�渹 = tbxWorksheetNumber.Text;
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
				//foreach (DatabaseSet.�u�@��~��Row row in _worksheetPartTable)
				//{
				//    if (row.RowState == DataRowState.Deleted)
				//        continue;

				//    if (row["��ڧ�����"] == DBNull.Value)
				//    {
				//        allFinished = false;
				//        break;
				//    }
				//    DateTime date = row.��ڧ�����;
				//    if (date > maxDate)
				//        maxDate = date;
				//}

				//if (allFinished && maxDate != DateTime.MinValue)
				//    _worksheetTable[0].��ڧ����� = maxDate;
				//else
				//    _worksheetTable[0]["��ڧ�����"] = DBNull.Value;

				// Begin update
				int count = �u�@��TableAdapter.Instance.Update(_worksheetTable);
				int partCount = �u�@��~��TableAdapter.Instance.UpdateEx(_worksheetPartTable);

				//�i��ƶq�ˬd
				DatabaseSet.UpdateWorksheetFinishStatus(((DatabaseSet.�u�@��Row)bsWorksheet.DataSource).�渹);

				MessageBox.Show("��s " + count + " ���u�@����\n��s " + partCount + " ���~��");
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

				//string cmdText = "SELECT COUNT(*) FROM �u�� WHERE �u�@�渹 = ? ";

				//OleDbParameter paramWs = new OleDbParameter("�u�@�渹", worksheet);

				//OleDbCommand cmd = new OleDbCommand(cmdText, conn);
				//cmd.Parameters.Add(paramWs);

				//int result = (int)cmd.ExecuteScalar();

				//if (result != 0)
				//{
				//    MessageBox.Show("�u�@�� '" + worksheet + "' �w���u�ɸ�Ƶn�O�A�L�k�R���C");
				//}
				//else 
					
				if (MessageBox.Show("�T�w�R���u�@�� " + worksheet + " �Ψ�Ҧ��������?\n(LaborWage�{���̪�������ƨä��|�Q�R��)", "�R������", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    _worksheetTable[0].Delete();
                    MessageBox.Show("�R���F" + �u�@��TableAdapter.Instance.Update(_worksheetTable) + "�����");
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
            if (e.ColumnIndex == col�w�p������.Index ||
                e.ColumnIndex == col��ڧ�����.Index ||
                e.ColumnIndex == col�Ȥ�ݳf��.Index)
            {
                Global.ShowError("��J����榡���~\n�^�_�­ȩΨ����s��Ы�ESC��");
            }
            else if (e.ColumnIndex == col�ƶq.Index)
            {
                Global.ShowError("��J�ƶq�榡���~\n�^�_�­ȩΨ����s��Ы�ESC��");
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
				string partnumber = (string)e.Row.Cells["col�~��"].Value;
				int wpid = (int)e.Row.Cells["col�s��"].Value;

                OleDbConnection conn = DbConnection.Instance;
                conn.Open();

                string cmdText = "SELECT COUNT(*) FROM �u�� WHERE �u�@�渹 = ? AND �u�~�s�� = ? ";

                OleDbParameter paramWs = new OleDbParameter("�u�@�渹", worksheet);
				OleDbParameter paramPart = new OleDbParameter("�u�~�s��", wpid);

                OleDbCommand cmd = new OleDbCommand(cmdText, conn);
                cmd.Parameters.Add(paramWs);
                cmd.Parameters.Add(paramPart);

                int result = (int)cmd.ExecuteScalar();

                if (result != 0)
                {
                    MessageBox.Show("�~�� '" + partnumber + "' �w���u�ɸ�Ƶn�O�A�L�k�R���C");
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
			//if (col��ڧ�����.Index == e.ColumnIndex)
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