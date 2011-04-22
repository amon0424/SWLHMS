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

            bindingSource.DataSource = DatabaseSet.�D�Ͳ�Table;

            tbxNPNumber.DataBindings.Add("Text", bindingSource, "�s��", true, DataSourceUpdateMode.Never);
            tbxNPName.DataBindings.Add("Text", bindingSource, "�W��", true, DataSourceUpdateMode.Never);
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
							DatabaseSet.�D�Ͳ�Row row = (bindingSource.Current as DataRowView).Row as DatabaseSet.�D�Ͳ�Row;

							if ((int)row["�s��", DataRowVersion.Original] == Global.NonProduct_Other)
							{
								if (!newName.Contains("��L"))
									throw new SWLHMSException("��� ��L ���ؽЦܤ֥]�t\"��L\"��r�H�i��ϧO");
								row.�W�� = newName;

								if (newNumber != 100)
									throw new SWLHMSException("��L ���ؤ��o���s��");
							}
							else
								row.FillRow(newNumber, newName);

							�D�Ͳ�TableAdapter.Instance.Update(row); ;
						}
					}
					else if (this.EditState == EditStateType.New)
					{
						DatabaseSet.�D�Ͳ�Row newRow = DatabaseSet.�D�Ͳ�Table.New�D�Ͳ�Row();

						newRow.FillRow(newNumber, newName);
						DatabaseSet.�D�Ͳ�Table.Rows.Add(newRow);

						�D�Ͳ�TableAdapter.Instance.Update(newRow);
					}
				}
				catch (ConstraintException)
				{
					MessageBox.Show("�w�s�b�D�Ͳ����� " + newNumber + "�@(" + newName + ")�A�Ы��w��L�s��");

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
                    DatabaseSet.�D�Ͳ�Row row = (bindingSource.Current as DataRowView).Row as DatabaseSet.�D�Ͳ�Row;

                    int newNumber = row.�s��;
                    string newName = row.�W��;

                    if (row.�s�� == Global.NonProduct_Other)
						throw new SWLHMSException("�D�Ͳ����� " + row.�W�� + " ����R��");

                    if (MessageBox.Show("�T�w�R�� " + newNumber + " (" + newName + ") �Ψ�Ҧ��������?", "�R������", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        row.Delete();
                        �D�Ͳ�TableAdapter.Instance.Update(row);
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