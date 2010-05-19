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
    public partial class LineForm : Form
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

        public LineForm()
        {
            InitializeComponent();

            bsLine.DataSource = DatabaseSet.產線Table;

            tbxLine.DataBindings.Add("Text", bsLine, "產線", true, DataSourceUpdateMode.Never);
            tbxLineName.DataBindings.Add("Text", bsLine, "代號", true, DataSourceUpdateMode.Never);
        }

        private void LineForm_Load(object sender, EventArgs e)
        {
            this.EditState = EditStateType.None;
        }

        private void btnStoreLine_Click(object sender, EventArgs e)
        {
            string newLine = tbxLine.Text;
            string newLineName = tbxLineName.Text;

            try
            {
                if (this.EditState == EditStateType.Edit)
                {
                    if (bsLine.Current != null)
                    {
                        DatabaseSet.產線Row row = (bsLine.Current as DataRowView).Row as DatabaseSet.產線Row;
                        row.FillRow(newLine, newLineName);

                        產線TableAdapter.Instance.Update(row); ;
                    }
                }
                else if (this.EditState == EditStateType.New)
                {
                    DatabaseSet.產線Row newRow = DatabaseSet.產線Table.New產線Row();
                    newRow.FillRow(newLine, newLineName);
                    DatabaseSet.產線Table.Rows.Add(newRow);

                    產線TableAdapter.Instance.Update(newRow);
                }

                this.EditState = EditStateType.None;
            }
            catch (ConstraintException)
            {
                MessageBox.Show("已存在產線 " + newLine + "，請指定其他產線");
                
            }
            catch (Exception ex)
            {
                Global.ShowError(ex);
            }
            finally
            {
                if (this.EditState == EditStateType.Edit)
                {
                    tbxLine.DataBindings[0].ReadValue();
                    tbxLineName.DataBindings[0].ReadValue();
                }
            }
        }

        private void btnAddLine_Click(object sender, EventArgs e)
        {
            this.EditState = EditStateType.New;
        }

        private void btnCancelLine_Click(object sender, EventArgs e)
        {
            this.EditState = EditStateType.None;
        }

        private void btnEditLine_Click(object sender, EventArgs e)
        {
            this.EditState = EditStateType.Edit;
        }

        private void btnDelLine_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsLine.Current != null)
                {
                    DatabaseSet.產線Row row = (bsLine.Current as DataRowView).Row as DatabaseSet.產線Row;

                    string newLine = row.產線;
                    string newLineName = row.代號;

                    if (MessageBox.Show("確定刪除 產線" + newLine + "(" + newLineName + ") 及其所有相關品號?", "刪除提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        row.Delete();
                        產線TableAdapter.Instance.Update(row);
						
                    }
                }
            }
            catch (Exception ex)
            {
				產線TableAdapter.Instance.Fill(DatabaseSet.產線Table);
                MessageBox.Show(ex.Message);
            }
        }

        void UpdateProductForm()
        {
            (this.MdiParent as MainForm).ProductForm.LoadPart(false);
        }

        private void tbxLine_Validated(object sender, EventArgs e)
        {
            tbxLine.Text = tbxLine.Text.Trim();
        }

        private void tbxLineName_Validated(object sender, EventArgs e)
        {
            tbxLineName.Text = tbxLineName.Text.Trim();
        }


        void UpdateUI()
        {
            bool editing = (this.EditState == EditStateType.Edit || this.EditState == EditStateType.New);
            tbxLine.ReadOnly = tbxLineName.ReadOnly = !editing;
            dgvLine.Enabled = !editing;

            btnStoreLine.Visible = btnCancelLine.Visible = editing;
            btnDelLine.Visible = btnEditLine.Visible = btnAddLine.Visible = !editing;


            if (this.EditState == EditStateType.New)
            {
                tbxLine.Clear();
                tbxLineName.Clear();
            }
            else
            {
                tbxLine.DataBindings[0].ReadValue();
                tbxLineName.DataBindings[0].ReadValue();
            }
        }

       
    }
}