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

            bsLine.DataSource = DatabaseSet.���uTable;

            tbxLine.DataBindings.Add("Text", bsLine, "���u", true, DataSourceUpdateMode.Never);
            tbxLineName.DataBindings.Add("Text", bsLine, "�N��", true, DataSourceUpdateMode.Never);
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
                        DatabaseSet.���uRow row = (bsLine.Current as DataRowView).Row as DatabaseSet.���uRow;
                        row.FillRow(newLine, newLineName);

                        ���uTableAdapter.Instance.Update(row); ;
                    }
                }
                else if (this.EditState == EditStateType.New)
                {
                    DatabaseSet.���uRow newRow = DatabaseSet.���uTable.New���uRow();
                    newRow.FillRow(newLine, newLineName);
                    DatabaseSet.���uTable.Rows.Add(newRow);

                    ���uTableAdapter.Instance.Update(newRow);
                }

                this.EditState = EditStateType.None;
            }
            catch (ConstraintException)
            {
                MessageBox.Show("�w�s�b���u " + newLine + "�A�Ы��w��L���u");
                
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
                    DatabaseSet.���uRow row = (bsLine.Current as DataRowView).Row as DatabaseSet.���uRow;

                    string newLine = row.���u;
                    string newLineName = row.�N��;

                    if (MessageBox.Show("�T�w�R�� ���u" + newLine + "(" + newLineName + ") �Ψ�Ҧ������~��?", "�R������", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        row.Delete();
                        ���uTableAdapter.Instance.Update(row);
						
                    }
                }
            }
            catch (Exception ex)
            {
				���uTableAdapter.Instance.Fill(DatabaseSet.���uTable);
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