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

            bsLine.DataSource = DatabaseSet.產線Table;
            bsNonProduce.DataSource = DatabaseSet.非生產Table;
            //bsLabor.DataSource = DatabaseSet.員工Table;

            cbxLine.DisplayMember = "產線";
            cbxLine.ValueMember = "產線";

            cbxNonProduce.DisplayMember = "名稱";
            cbxNonProduce.ValueMember = "編號";

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

            DatabaseSet.工時DataTable table = new DatabaseSet.工時DataTable();
            int count = 0;
            if (cbxProduceOrNot.SelectedIndex == 0)
            {
                count = 工時TableAdapter.Instance.Fill(table, laborNumber, ckbDate.Checked, from, to);
            }
            else if (cbxProduceOrNot.SelectedIndex == 1)
            {
                string worksheetNumber = tbxWorksheetNumber.Text;
                string partNumber = tbxPartNumber.Text;
                count = 工時TableAdapter.Instance.Fill(table, laborNumber, worksheetNumber, partNumber, ckbDate.Checked, from, to);
            }
            else
            {
                int nonProduce = (int)cbxNonProduce.SelectedValue;
                count = 工時TableAdapter.Instance.Fill(table, laborNumber,nonProduce, ckbDate.Checked, from, to);
            }

			table.Columns.Add("工時類型名稱");
			foreach (DataRow row in table)
			{
				row["工時類型名稱"] = ((HourType)row["工時類型"]).ToString();
			}

            bsHourData.DataSource = table;
            dgvHourData.AutoResizeColumns();
            lbSearchResult.Text = "找到 " + count + " 筆資料";
        }

        private void cbxLine_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbxLine.SelectedIndex != -1 && cbxLine.DataSource != null)
            {
                _raiseCbxLaborSelectedValueChangedEvent = false;
                bsLabor.DataSource = 員工TableAdapter.Instance.GetBy產線(cbxLine.SelectedValue.ToString());
                _raiseCbxLaborSelectedValueChangedEvent = true;

                cbxLaborNumber.DisplayMember = "編號";
                cbxLaborNumber.ValueMember = "編號";
                cbxLaborName.DisplayMember = "姓名";
                cbxLaborName.ValueMember = "姓名";
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
                    DatabaseSet.工時Row row = (dgvHourData.CurrentRow.DataBoundItem as DataRowView).Row as DatabaseSet.工時Row;
                    form.EditHourdata(row.員工編號, row.日期);
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
                    DatabaseSet.工時Row row = (dgvHourData.CurrentRow.DataBoundItem as DataRowView).Row as DatabaseSet.工時Row;
					int count = 0;
                    if (MessageBox.Show("確定刪除" + row.編號 + "此筆資料?", "刪除提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
						if (row["工作單號"] != DBNull.Value)
						{
							string worksheet = row.工作單號;
							int wpid = row.工品編號;

							/*
							row.Delete();
							int count = 工時TableAdapter.Instance.Update(row);
							*/

							count = 工時TableAdapter.Instance.DeleteEx(row.編號);

							DatabaseSet.UpdateWorksheetItemFinishDate(worksheet, wpid, true);
						}
						else
						{
							count = 工時TableAdapter.Instance.DeleteEx(row.編號);
						}
						MessageBox.Show("刪除了 " + count + " 筆資料");
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
                bsLabor.DataSource = DatabaseSet.員工Table;
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
            bsHourData.DataSource = 工時TableAdapter.Instance.GetUnfilledData();
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