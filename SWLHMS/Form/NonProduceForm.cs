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
    public partial class NonProduceForm : Form
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

        public NonProduceForm()
        {
            InitializeComponent();

            bindingSource.DataSource = DatabaseSet.非生產Table;

            tbxNPNumber.DataBindings.Add("Text", bindingSource, "編號", true, DataSourceUpdateMode.Never);
            tbxNPName.DataBindings.Add("Text", bindingSource, "名稱", true, DataSourceUpdateMode.Never);
        }

        private void NonProduceForm_Load(object sender, EventArgs e)
        {
            this.EditState = EditStateType.None;
        }

        private void tbxNPNumber_Validating(object sender, CancelEventArgs e)
		{

		}

        private void btnStoreNP_Click(object sender, EventArgs e)
        {
            

            try
            {
				int newNumber = int.Parse(tbxNPNumber.Text);
				string newName = tbxNPName.Text;

				try
				{
					if (this.EditState == EditStateType.Edit)
					{
						if (bindingSource.Current != null)
						{
							DatabaseSet.非生產Row row = (bindingSource.Current as DataRowView).Row as DatabaseSet.非生產Row;

							if ((int)row["編號", DataRowVersion.Original] == Global.NonProduct_Other)
							{
								if (!newName.Contains("其他"))
									throw new SWLHMSException("更改 其他 項目請至少包含\"其他\"兩字以進行區別");
								row.名稱 = newName;

								if (newNumber != 100)
									throw new SWLHMSException("其他 項目不得更改編號");
							}
							else
								row.FillRow(newNumber, newName);

							非生產TableAdapter.Instance.Update(row); ;
						}
					}
					else if (this.EditState == EditStateType.New)
					{
						DatabaseSet.非生產Row newRow = DatabaseSet.非生產Table.New非生產Row();

						newRow.FillRow(newNumber, newName);
						DatabaseSet.非生產Table.Rows.Add(newRow);

						非生產TableAdapter.Instance.Update(newRow);
					}
				}
				catch (ConstraintException)
				{
					MessageBox.Show("已存在非生產項目 " + newNumber + "　(" + newName + ")，請指定其他編號");

				}

                this.EditState = EditStateType.None;
            }
            catch (Exception ex)
            {
                Global.ShowError(ex);
            }
            finally
            {
                if (this.EditState == EditStateType.Edit)
                {
                    tbxNPNumber.DataBindings[0].ReadValue();
                    tbxNPName.DataBindings[0].ReadValue();
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
                    DatabaseSet.非生產Row row = (bindingSource.Current as DataRowView).Row as DatabaseSet.非生產Row;

                    int newNumber = row.編號;
                    string newName = row.名稱;

                    if (row.編號 == Global.NonProduct_Other)
						throw new SWLHMSException("非生產項目 " + row.名稱 + " 不能刪除");

                    if (MessageBox.Show("確定刪除 " + newNumber + " (" + newName + ") 及其所有相關資料?", "刪除提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        row.Delete();
                        非生產TableAdapter.Instance.Update(row);
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


        private void tbxNPName_Validated(object sender, EventArgs e)
        {
            tbxNPName.Text = tbxNPName.Text.Trim();
        }

        private void tbxNPNumber_Validated(object sender, EventArgs e)
        {
            tbxNPNumber.Text = tbxNPNumber.Text.Trim();
        }

      
        void UpdateUI()
        {
            bool editing = (this.EditState == EditStateType.Edit || this.EditState == EditStateType.New);
            tbxNPName.ReadOnly = tbxNPNumber.ReadOnly = !editing;
            dgvNP.Enabled = !editing;

            btnStore.Visible = btnCancel.Visible = editing;
            btnDel.Visible = btnEdit.Visible = btnAdd.Visible = !editing;


            if (this.EditState == EditStateType.New)
            {
                tbxNPNumber.Clear();
                tbxNPName.Clear();
            }
            else
            {
                tbxNPNumber.DataBindings[0].ReadValue();
                tbxNPName.DataBindings[0].ReadValue();
            }
        }
    }
}