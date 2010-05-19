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
    public partial class QualityItemForm : Form
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

		public QualityItemForm()
        {
            InitializeComponent();

            bindingSource.DataSource = DatabaseSet.品質原因Table;
			bindingSource.Filter = "編號 <> -1";

			tbxNumber.DataBindings.Add("Text", bindingSource, "編號", true, DataSourceUpdateMode.Never);
			tbxName.DataBindings.Add("Text", bindingSource, "名稱", true, DataSourceUpdateMode.Never);
        }

        private void QualityItemForm_Load(object sender, EventArgs e)
        {
            this.EditState = EditStateType.None;
        }

        private void tbxNumber_Validating(object sender, CancelEventArgs e)
        {
            try
            {
				if (tbxNumber.Text.Trim() == string.Empty)
					return;

                if (int.Parse(tbxNumber.Text) <= 0)
					throw new SWLHMSException();
            }
            catch (Exception)
            {
                MessageBox.Show("編號必須為一個正數");
                e.Cancel = true;
                tbxNumber.DataBindings[0].ReadValue();
                tbxNumber.SelectAll();
            }
        }

        private void btnStoreNP_Click(object sender, EventArgs e)
        {
            try
            {
				int newNumber = int.Parse(tbxNumber.Text);
				string newName = tbxName.Text;

				try
				{
					if (this.EditState == EditStateType.Edit)
					{
						if (bindingSource.Current != null)
						{
							DatabaseSet.品質原因Row row = (bindingSource.Current as DataRowView).Row as DatabaseSet.品質原因Row;

							row.FillRow(newNumber, newName);

							品質原因TableAdapter.Instance.Update(row); ;
						}
					}
					else if (this.EditState == EditStateType.New)
					{
						DatabaseSet.品質原因Row newRow = DatabaseSet.品質原因Table.New品質原因Row();

						newRow.FillRow(newNumber, newName);
						DatabaseSet.品質原因Table.Rows.Add(newRow);

						品質原因TableAdapter.Instance.Update(newRow);
					}

					this.EditState = EditStateType.None;
				}
				catch (ConstraintException)
				{
					MessageBox.Show("已存在品質原因 " + newNumber + "　(" + newName + ")，請指定其他編號");

				}
            }
           
            catch (Exception ex)
            {
                Global.ShowError(ex);
            }
            finally
            {
                if (this.EditState == EditStateType.Edit)
                {
                    tbxNumber.DataBindings[0].ReadValue();
                    tbxName.DataBindings[0].ReadValue();
                }
            }
        }

        private void btnAddNP_Click(object sender, EventArgs e)
        {
            this.EditState = EditStateType.New;
        }

        private void btnDelNP_Click(object sender, EventArgs e)
        {
            try
            {
                if (bindingSource.Current != null)
                {
					DatabaseSet.品質原因Row row = (bindingSource.Current as DataRowView).Row as DatabaseSet.品質原因Row;

                    int newNumber = row.編號;
                    string newName = row.名稱;

                    if (MessageBox.Show("確定刪除 " + newNumber + " (" + newName + ") 及其所有相關資料?", "刪除提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        row.Delete();
						品質原因TableAdapter.Instance.Update(row);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditNP_Click(object sender, EventArgs e)
        {
            this.EditState = EditStateType.Edit;
        }

        private void btnCancelNP_Click(object sender, EventArgs e)
        {
            this.EditState = EditStateType.None;
        }


        private void tbxName_Validated(object sender, EventArgs e)
        {
            tbxName.Text = tbxName.Text.Trim();
        }

        private void tbxNumber_Validated(object sender, EventArgs e)
        {
            tbxNumber.Text = tbxNumber.Text.Trim();
        }

      
        void UpdateUI()
        {
            bool editing = (this.EditState == EditStateType.Edit || this.EditState == EditStateType.New);
            tbxName.ReadOnly = tbxNumber.ReadOnly = !editing;
            dgvNP.Enabled = !editing;

            btnStore.Visible = btnCancel.Visible = editing;
            btnDel.Visible = btnEdit.Visible = btnAdd.Visible = !editing;


            if (this.EditState == EditStateType.New)
            {
                tbxNumber.Clear();
                tbxName.Clear();
            }
            else
            {
                tbxNumber.DataBindings[0].ReadValue();
                tbxName.DataBindings[0].ReadValue();
            }
        }
    }
}