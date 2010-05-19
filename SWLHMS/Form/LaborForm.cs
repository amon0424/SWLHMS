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
    public partial class LaborForm : Form
    {
        EditStateType _editState;
        EditStateType EditState
        {
            get { return _editState; }
            set
            {
                _editState = value;
                UpdateUI();
            }
        }
        
        public LaborForm()
        {
            InitializeComponent();

            bsLineCbx.DataSource = DatabaseSet.產線Table;
            bsLabor.DataSource = DatabaseSet.員工Table;
            

            cbxLaborLine.DisplayMember = "產線";
            cbxLaborLine.ValueMember = "產線";

            tbxLaborNumber.DataBindings.Add("Text", bsLabor, "編號", true, DataSourceUpdateMode.Never);
            tbxLaborName.DataBindings.Add("Text", bsLabor, "姓名", true, DataSourceUpdateMode.Never);
            tbxLaborWage.DataBindings.Add("Text", bsLabor, "薪水", true, DataSourceUpdateMode.Never,0,"0.#");
            cbxLaborLine.DataBindings.Add("SelectedValue", bsLabor, "產線", true, DataSourceUpdateMode.Never);


        }
        
        private void LaborForm_Load(object sender, EventArgs e)
        {
            this.EditState = EditStateType.None;
        }
        
        private void btnStoreLabor_Click(object sender, EventArgs e)
        {
            string newLaborNumber = tbxLaborNumber.Text;
            string newLaborName = tbxLaborName.Text;
            decimal newLaborWage = decimal.Parse(tbxLaborWage.Text);
            string newLaborLine = cbxLaborLine.SelectedValue.ToString();

            try
            {
                if (this.EditState == EditStateType.Edit)
                {
                    if (bsLabor.Current != null)
                    {
                        DatabaseSet.員工Row row = (bsLabor.Current as DataRowView).Row as DatabaseSet.員工Row;
                        row.FillRow(newLaborNumber, newLaborName, newLaborWage, newLaborLine);

                        員工TableAdapter.Instance.Update(row); ;
                    }
                }
                else if (this.EditState == EditStateType.New)
                {
                    DatabaseSet.員工Row newRow = DatabaseSet.員工Table.New員工Row();
                    newRow.FillRow(newLaborNumber, newLaborName, newLaborWage, newLaborLine);
                    DatabaseSet.員工Table.Rows.Add(newRow);

                    員工TableAdapter.Instance.Update(newRow);
                }

                this.EditState = EditStateType.None;
            }
            catch (ConstraintException)
            {
                MessageBox.Show("已存在員工 (" + newLaborNumber + ")" + newLaborName + "，請指定其他編號");

            }
            catch (Exception ex)
            {
                Global.ShowError(ex);
            }
            finally
            {
                if (this.EditState == EditStateType.Edit)
                {
                    tbxLaborNumber.DataBindings[0].ReadValue();
                    tbxLaborName.DataBindings[0].ReadValue();
                    tbxLaborWage.DataBindings[0].ReadValue();
                    cbxLaborLine.DataBindings[0].ReadValue();
                }
            }
        }

        private void btnAddLabor_Click(object sender, EventArgs e)
        {
            this.EditState = EditStateType.New;
        }

        private void btnEditLabor_Click(object sender, EventArgs e)
        {
            this.EditState = EditStateType.Edit;
        }

        private void btnCancelLabor_Click(object sender, EventArgs e)
        {
            this.EditState = EditStateType.None;
        }

        private void btnDelLabor_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsLabor.Current != null)
                {
                    DatabaseSet.員工Row row = (bsLabor.Current as DataRowView).Row as DatabaseSet.員工Row;

                    string newLaborNumber = row.編號;
                    string newLaborName = row.姓名;

                    if (MessageBox.Show("確定刪除 員工 (" + newLaborNumber + ") " + newLaborName + " 及其所有相關資料?", "刪除提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        row.Delete();
                        員工TableAdapter.Instance.Update(row);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbxLaborWage_Validating(object sender, CancelEventArgs e)
        {
            decimal i;
            if ((e.Cancel = !decimal.TryParse(tbxLaborWage.Text, out i)) == true)
            {
                MessageBox.Show("薪水必須為一個數字");
                tbxLaborWage.DataBindings[0].ReadValue();
                tbxLaborWage.SelectAll();
            }
        }

        private void tbxLaborNumber_Validated(object sender, EventArgs e)
        {
            tbxLaborNumber.Text = tbxLaborNumber.Text.Trim();
        }

        private void tbxLaborName_Validated(object sender, EventArgs e)
        {
            tbxLaborName.Text = tbxLaborName.Text.Trim();
        }

        void UpdateUI()
        {
            bool editing = (this.EditState == EditStateType.Edit || this.EditState == EditStateType.New);
            tbxLaborNumber.ReadOnly = tbxLaborName.ReadOnly = tbxLaborWage.ReadOnly =!editing;
            cbxLaborLine.Enabled = editing;
            dgvLabor.Enabled = !editing;

            btnStoreLabor.Visible = btnCancelLabor.Visible = editing;
            btnDelLabor.Visible = btnEditLabor.Visible = btnAddLabor.Visible = !editing;

            if (this.EditState == EditStateType.New)
            {
                tbxLaborNumber.Clear();
                tbxLaborName.Clear();
                tbxLaborWage.Clear();
                cbxLaborLine.SelectedIndex = -1;
            }
            else
            {
                tbxLaborNumber.DataBindings[0].ReadValue();
                tbxLaborName.DataBindings[0].ReadValue();
                tbxLaborWage.DataBindings[0].ReadValue();
                cbxLaborLine.DataBindings[0].ReadValue();
            }
        }
    }
}