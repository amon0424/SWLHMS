using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mong
{
	public partial class InspectedDeleteForm : Form
	{
		public InspectedDeleteForm()
		{
			InitializeComponent();

			dtpDate.Value = DateTime.Today;
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			SearchList();
		}

		void SearchList()
		{
			string qcn = txtQCN.Text.Trim();
			string partnubmer = txtPartNumber.Text.Trim();

			DateTime date = DateTime.MinValue;
			if (ckbDate.Checked)
				date = dtpDate.Value;

			DatabaseSet.待驗清單DataTable table = DatabaseSet.GetInspectCompleteList(qcn, partnubmer, date);
			table.Columns.Add("刪除", typeof(bool));
			bindingSource.DataSource = table;
			btnSend.Enabled = table.Rows.Count > 0;

			dgv.AutoResizeColumns();
			dgv.Columns[0].Width = 40;
			dgv.Columns[1].Width = 50;
		}

		private void ckbDate_CheckedChanged(object sender, EventArgs e)
		{
			dtpDate.Enabled = ckbDate.Checked;
		}

		private void btnSend_Click(object sender, EventArgs e)
		{
			DatabaseSet.待驗清單DataTable table = (DatabaseSet.待驗清單DataTable)bindingSource.DataSource;

			if (MessageBox.Show("資料經送出後不可再修改，請確認後繼續", "送出確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
			{
				int delete;
				int update = DatabaseSet.UpdateInspectDeleteList(table, out delete);

				MessageBox.Show("更新了 " + update + " 筆檢驗資料\n共刪除 " + delete + " 筆檢驗資料");
				SearchList();
			}
		}

		private void dgv_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.C)
			{
				if (dgv.CurrentCell != null && dgv.CurrentCell.Value != DBNull.Value)
				{
					try
					{
						Clipboard.SetText(dgv.CurrentCell.Value.ToString());
					}
					catch (Exception) { }
				}
			}
		}

	}
}
