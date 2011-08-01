using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Mong.DatabaseSetTableAdapters;
namespace Mong
{
    public partial class HourDataForm : Form
    {

        bool _raiseCbxLaborSelectedValueChangedEvent = true;

        public HourDataForm()
        {
            InitializeComponent();

            bsLine.DataSource = DatabaseSet.���uTable;
            bsNonProduce.DataSource = DatabaseSet.�D�Ͳ�Table;
            //bsLabor.DataSource = DatabaseSet.���uTable;

            cbxLine.DisplayMember = "���u";
            cbxLine.ValueMember = "���u";

            cbxNonProduce.DisplayMember = "�W��";
            cbxNonProduce.ValueMember = "�s��";

            dtpFrom.Value = DateTime.Today;
            dtpTo.Value = DateTime.Today;

            cbxLine.SelectedIndex = -1;
            ckbLine.Checked = false;

            dtpTip.DataBindings.Add("Value", Settings.UnfilledDate, "", true, DataSourceUpdateMode.OnPropertyChanged);

            cbxProduceOrNot.SelectedIndex = 0;
        }

        private void cbxProduceOrNot_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlProduce.Visible = cbxProduceOrNot.SelectedIndex == 1;
            pnlNonProduce.Visible = cbxProduceOrNot.SelectedIndex == 2;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnDelHourData.Enabled = true;
            string laborNumber = string.Empty;
            if(ckbLabor.Checked && cbxLaborNumber.SelectedIndex != -1)
                laborNumber = cbxLaborNumber.SelectedValue.ToString();

            DateTime from = dtpFrom.Value;
            DateTime to = dtpTo.Value;

            DatabaseSet.�u��DataTable table = new DatabaseSet.�u��DataTable();
            int count = 0;
            if (cbxProduceOrNot.SelectedIndex == 0)
            {
                count = �u��TableAdapter.Instance.Fill(table, laborNumber, ckbDate.Checked, from, to);
            }
            else if (cbxProduceOrNot.SelectedIndex == 1)
            {
                string worksheetNumber = tbxWorksheetNumber.Text;
                string partNumber = tbxPartNumber.Text;
                count = �u��TableAdapter.Instance.Fill(table, laborNumber, worksheetNumber, partNumber, ckbDate.Checked, from, to);
            }
            else
            {
                int nonProduce = (int)cbxNonProduce.SelectedValue;
                count = �u��TableAdapter.Instance.Fill(table, laborNumber,nonProduce, ckbDate.Checked, from, to);
            }

			table.Columns.Add("�u�������W��");
			foreach (DataRow row in table)
			{
				row["�u�������W��"] = ((HourType)row["�u������"]).ToString();
			}

            bsHourData.DataSource = table;
            dgvHourData.AutoResizeColumns();
            lbSearchResult.Text = "��� " + count + " �����";
        }

        private void cbxLine_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbxLine.SelectedIndex != -1 && cbxLine.DataSource != null)
            {
                _raiseCbxLaborSelectedValueChangedEvent = false;
                bsLabor.DataSource = ���uTableAdapter.Instance.GetBy���u(cbxLine.SelectedValue.ToString());
                _raiseCbxLaborSelectedValueChangedEvent = true;

                cbxLaborNumber.DisplayMember = "�s��";
                cbxLaborNumber.ValueMember = "�s��";
                cbxLaborName.DisplayMember = "�m�W";
                cbxLaborName.ValueMember = "�m�W";
            }
            else
                bsLabor.DataSource = null;

            cbxLaborNumber.SelectedIndex = -1;
            cbxLaborName.SelectedIndex = -1;
        }

        private void ckbDate_CheckedChanged(object sender, EventArgs e)
        {
            pnlDate.Enabled = ckbDate.Checked;
        }

        private void tbxWorksheetNumber_Validated(object sender, EventArgs e)
        {
            tbxWorksheetNumber.Text = tbxWorksheetNumber.Text.Trim();
        }

        private void tbxPartNumber_Validated(object sender, EventArgs e)
        {
            tbxPartNumber.Text = tbxPartNumber.Text.Trim();
        }

        private void ckbLabor_CheckedChanged(object sender, EventArgs e)
        {
            pnlLabor.Enabled = ckbLabor.Checked;

            if (!ckbLabor.Checked)
                cbxLine.SelectedIndex = -1;
        }

        private void cbxLaborNumber_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_raiseCbxLaborSelectedValueChangedEvent)
            {
                if ((sender as ComboBox).SelectedIndex != -1)
                {
                    ComboBox another = (sender == cbxLaborNumber) ? cbxLaborName : cbxLaborNumber;
                    if (another.Items.Count > (sender as ComboBox).SelectedIndex)
                        another.SelectedIndex = (sender as ComboBox).SelectedIndex;
                }
            }
        }

        private void HourDataForm_Load(object sender, EventArgs e)
        {

        }

        private void btnEditHourData_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsHourData.DataSource != null && dgvHourData.CurrentRow != null)
                {
                    EditHourDataForm form = new EditHourDataForm();
                    DatabaseSet.�u��Row row = (dgvHourData.CurrentRow.DataBoundItem as DataRowView).Row as DatabaseSet.�u��Row;
                    form.EditHourdata(row.���u�s��, row.���);
                    form.MdiParent = this.MdiParent;
                    form.AllowDeleteOldData = true;
                    form.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelHourData_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsHourData.DataSource != null && dgvHourData.CurrentRow != null)
                {
                    DatabaseSet.�u��Row row = (dgvHourData.CurrentRow.DataBoundItem as DataRowView).Row as DatabaseSet.�u��Row;
					int count = 0;
                    if (MessageBox.Show("�T�w�R��" + row.�s�� + "�������?", "�R������", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
						if (row["�u�@�渹"] != DBNull.Value)
						{
							string worksheet = row.�u�@�渹;
							int wpid = row.�u�~�s��;

							/*
							row.Delete();
							int count = �u��TableAdapter.Instance.Update(row);
							*/

							count = �u��TableAdapter.Instance.DeleteEx(row.�s��);

							DatabaseSet.UpdateWorksheetItemFinishDate(worksheet, wpid, true);
						}
						else
						{
							count = �u��TableAdapter.Instance.DeleteEx(row.�s��);
						}
						MessageBox.Show("�R���F " + count + " �����");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ckbLine_CheckedChanged(object sender, EventArgs e)
        {
            cbxLine.Enabled = ckbLine.Checked;
            if (!ckbLine.Checked)
            {
                _raiseCbxLaborSelectedValueChangedEvent = false;
                bsLabor.DataSource = DatabaseSet.���uTable;
                _raiseCbxLaborSelectedValueChangedEvent = true;

                cbxLaborNumber.SelectedIndex = -1;
                cbxLaborName.SelectedIndex = -1;
            }
        }

        private void tsmiCopyValue_Click(object sender, EventArgs e)
        {
            DataGridView dgv = dgvHourData;
            if (dgv.CurrentCell != null)
            {
                Clipboard.SetText((dgv.CurrentCell.Value != null ? dgv.CurrentCell.Value.ToString() : string.Empty));
            }
        }

        private void dgvHourData_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView dgv = sender as DataGridView;
                DataGridView.HitTestInfo hit = dgv.HitTest(e.X, e.Y);
                if (hit.Type == DataGridViewHitTestType.Cell)
                    dgv.CurrentCell = dgv[hit.ColumnIndex, hit.RowIndex];
                else
                    dgv.CurrentCell = null;
            }
        }

        private void cmsDgv_Opening(object sender, CancelEventArgs e)
        {
            DataGridView dgv = dgvHourData;
            tsmiCopyValue.Enabled = dgv.CurrentCell != null;
        }

        private void dtpTip_Validated(object sender, EventArgs e)
        {
            Settings.UnfilledDate = dtpTip.Value;
        }

        private void btnSearchUnfilled_Click(object sender, EventArgs e)
        {
            btnDelHourData.Enabled = false;
            bsHourData.DataSource = �u��TableAdapter.Instance.GetUnfilledData();
            dgvHourData.AutoResizeColumns();
        }

        private void dtpTip_Enter(object sender, EventArgs e)
        {
            dtpTip.Value = Settings.UnfilledDate;
        }

		private void btnPrint_Click(object sender, EventArgs e)
		{
			if (bsHourData.DataSource != null)
			{
				HourDataReport report = new HourDataReport((DataTable)bsHourData.DataSource);
				report.Export();
			}
		}

    }
}