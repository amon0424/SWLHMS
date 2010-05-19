using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mong
{
	public partial class InspectListForm : Form
	{
		public InspectListForm()
		{
			InitializeComponent();

			DataTable lineTable = DatabaseSet.產線Table.Copy();
			lineTable.Columns.Add("Display", typeof(string));
			foreach (DataRow row in lineTable.Rows)
				row["Display"] = row["產線"];

			DataRow allRow = lineTable.NewRow();
			allRow["產線"] = string.Empty;
			allRow["Display"] = "全部";
			lineTable.Rows.Add(allRow);

			lineTable.DefaultView.Sort = "產線";
			cbxLine.DataSource = lineTable;
			cbxLine.DisplayMember = "Display";
			cbxLine.ValueMember = "產線";
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{

		}
	}
}
