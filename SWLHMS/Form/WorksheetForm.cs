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
    public partial class WorksheetForm : Form
    {
        bool _raiseDgvWorksheetSelectionChangedEvent = true;

        public bool OnlySearch
        {
            set
            {
                btnDelWorksheet.Visible = !value;
//#if !DEBUG
//                btnDelWorksheet.Visible = false;
//#endif
            }
        }

        public WorksheetForm()
        {
            InitializeComponent();

            DatabaseSet.工作單Table.Clear();
            bsWorksheet.DataSource = DatabaseSet.工作單Table;

            splitContainer1.Panel2MinSize = 255;

            cbxBeginOrEnd.SelectedIndex = 0;
            cbxDoneOrNot.SelectedIndex = 0;

            tbxWorksheetNumber.DataBindings.Add("Text", bsWorksheet, "單號", true, DataSourceUpdateMode.Never);
            //tbxCustomerName.DataBindings.Add("Text", bsWorksheet, "客戶名稱", true, DataSourceUpdateMode.Never);
            dtpBegin.DataBindings.Add("Value", bsWorksheet, "單據日期", true, DataSourceUpdateMode.Never, DateTime.Today);
            dtpEnd.DataBindings.Add("Value", bsWorksheet, "實際完成日", true, DataSourceUpdateMode.Never,  DateTime.Today);

            // For 1.02
            //dtpCustomerNeed.DataBindings.Add("Value", bsWorksheet, "客戶需貨日", true, DataSourceUpdateMode.Never);
            //dtpEstimate.DataBindings.Add("Value", bsWorksheet, "預計完成日", true, DataSourceUpdateMode.Never);

            dtpEnd.DataBindings[0].Format += new ConvertEventHandler(dtpEndDataBindings_Format);

            dgvWorksheet.AutoResizeColumns();

            
            //col完成日.DefaultCellStyle.NullValue = DBNull.Value;

#if !DEBUG
            btnDelWorksheet.Visible = false;
#endif
        }

        void dtpEndDataBindings_Format(object sender, ConvertEventArgs e)
        {
            ckbEnd.Checked = !Convert.IsDBNull(e.Value);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _raiseDgvWorksheetSelectionChangedEvent = false;
            bsWorksheet.DataSource = Global.Get工作單Table(tbxWorksheetNumberS.Text, cbxBeginOrEnd.SelectedIndex, dtpFrom.Value, dtpTo.Value,cbxDoneOrNot.SelectedIndex);
            dgvWorksheet.AutoResizeColumns();
            _raiseDgvWorksheetSelectionChangedEvent = true;
            dgvWorksheet_SelectionChanged(null, null);
        }

        private void WorksheetForm_Load(object sender, EventArgs e)
        {
            this.btnDelWorksheet.Visible = User.CurrentUser.IsAdministrator;
#if !DEBUG
            btnDelWorksheet.Visible = false;
#endif
        }

        private void cbxBeginOrEnd_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtpFrom.Enabled = cbxBeginOrEnd.SelectedIndex != 0;
            dtpTo.Enabled = cbxBeginOrEnd.SelectedIndex != 0;
        }

        private void dgvWorksheet_SelectionChanged(object sender, EventArgs e)
        {
            if (_raiseDgvWorksheetSelectionChangedEvent)
            {
                if (bsWorksheet.Current != null)
                {
                    DatabaseSet.工作單Row row = (bsWorksheet.Current as DataRowView).Row as DatabaseSet.工作單Row;
                    bsPart.DataSource = 工作單品號TableAdapter.Instance.GetBy單號(row.單號);
                }
                else
                    bsPart.DataSource = null;

            }
        }

        private void btnEditWorksheet_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxWorksheetNumber.Text != string.Empty)
                {
                    EditWorksheetForm form = new EditWorksheetForm();
                    form.EditWorksheet(tbxWorksheetNumber.Text);
                    form.MdiParent = this.MdiParent;
                    form.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelWorksheet_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsWorksheet.Current != null)
                {
                    DatabaseSet.工作單Row row = (bsWorksheet.Current as DataRowView).Row as DatabaseSet.工作單Row;

                    string worksheet = row.單號;

                    OleDbConnection conn = DbConnection.Instance;
                    conn.Open();

                    string cmdText = "SELECT COUNT(*) FROM 工時 WHERE 工作單號 = ? ";

                    OleDbParameter paramWs = new OleDbParameter("工作單號", worksheet);

                    OleDbCommand cmd = new OleDbCommand(cmdText, conn);
                    cmd.Parameters.Add(paramWs);

                    int result = (int)cmd.ExecuteScalar();

                    if (result != 0)
                    {
                        MessageBox.Show("工作單 '" + worksheet + "' 已有工時資料登記，無法刪除。");
                    }
                    else if (MessageBox.Show("確定刪除工作單 " + worksheet + " 及其所有相關資料?\n(LaborWage程式裡的相關資料並不會被刪除)", "刪除提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        row.Delete();
                        MessageBox.Show("刪除了" + 工作單TableAdapter.Instance.Update(row) + "筆資料");
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Global.ShowError(ex);
            } 
        }

        private void btnAddWorksheet_Click(object sender, EventArgs e)
        {
            try
            {
                EditWorksheetForm form = new EditWorksheetForm();
                form.NewWorksheet();
                form.MdiParent = this.MdiParent;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}