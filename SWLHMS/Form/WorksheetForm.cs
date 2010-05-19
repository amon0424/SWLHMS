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

            DatabaseSet.�u�@��Table.Clear();
            bsWorksheet.DataSource = DatabaseSet.�u�@��Table;

            splitContainer1.Panel2MinSize = 255;

            cbxBeginOrEnd.SelectedIndex = 0;
            cbxDoneOrNot.SelectedIndex = 0;

            tbxWorksheetNumber.DataBindings.Add("Text", bsWorksheet, "�渹", true, DataSourceUpdateMode.Never);
            //tbxCustomerName.DataBindings.Add("Text", bsWorksheet, "�Ȥ�W��", true, DataSourceUpdateMode.Never);
            dtpBegin.DataBindings.Add("Value", bsWorksheet, "��ڤ��", true, DataSourceUpdateMode.Never, DateTime.Today);
            dtpEnd.DataBindings.Add("Value", bsWorksheet, "��ڧ�����", true, DataSourceUpdateMode.Never,  DateTime.Today);

            // For 1.02
            //dtpCustomerNeed.DataBindings.Add("Value", bsWorksheet, "�Ȥ�ݳf��", true, DataSourceUpdateMode.Never);
            //dtpEstimate.DataBindings.Add("Value", bsWorksheet, "�w�p������", true, DataSourceUpdateMode.Never);

            dtpEnd.DataBindings[0].Format += new ConvertEventHandler(dtpEndDataBindings_Format);

            dgvWorksheet.AutoResizeColumns();

            
            //col������.DefaultCellStyle.NullValue = DBNull.Value;

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
            bsWorksheet.DataSource = Global.Get�u�@��Table(tbxWorksheetNumberS.Text, cbxBeginOrEnd.SelectedIndex, dtpFrom.Value, dtpTo.Value,cbxDoneOrNot.SelectedIndex);
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
                    DatabaseSet.�u�@��Row row = (bsWorksheet.Current as DataRowView).Row as DatabaseSet.�u�@��Row;
                    bsPart.DataSource = �u�@��~��TableAdapter.Instance.GetBy�渹(row.�渹);
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
                    DatabaseSet.�u�@��Row row = (bsWorksheet.Current as DataRowView).Row as DatabaseSet.�u�@��Row;

                    string worksheet = row.�渹;

                    OleDbConnection conn = DbConnection.Instance;
                    conn.Open();

                    string cmdText = "SELECT COUNT(*) FROM �u�� WHERE �u�@�渹 = ? ";

                    OleDbParameter paramWs = new OleDbParameter("�u�@�渹", worksheet);

                    OleDbCommand cmd = new OleDbCommand(cmdText, conn);
                    cmd.Parameters.Add(paramWs);

                    int result = (int)cmd.ExecuteScalar();

                    if (result != 0)
                    {
                        MessageBox.Show("�u�@�� '" + worksheet + "' �w���u�ɸ�Ƶn�O�A�L�k�R���C");
                    }
                    else if (MessageBox.Show("�T�w�R���u�@�� " + worksheet + " �Ψ�Ҧ��������?\n(LaborWage�{���̪�������ƨä��|�Q�R��)", "�R������", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        row.Delete();
                        MessageBox.Show("�R���F" + �u�@��TableAdapter.Instance.Update(row) + "�����");
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