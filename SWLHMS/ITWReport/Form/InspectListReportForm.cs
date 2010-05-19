using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mong
{
	public partial class InspectListReportForm : Form
	{
		public event EventHandler ExportClick;
		InspectListReportSortForm _sortForm;

		public string QCN
		{
			get
			{
				if (txtQCN.Enabled)
					return txtQCN.Text.Trim();
				else
					return string.Empty;
			}
		}
		public string PartNumber
		{
			get
			{
				return txtPartNumber.Text.Trim();
			}
		}
		public string WorksheetFrom
		{
			get
			{
				return txtWorksheetFrom.Text.Trim();
			}
		}
		public string WorksheetTo
		{
			get
			{
				return txtWorksheetTo.Text.Trim();
			}
		}
		public DateTime From
		{
			get
			{
				if (!ckbDate.Checked)
					return DateTime.MinValue;
				return dtpFrom.Value;
			}
		}
		public DateTime To
		{
			get
			{
				if (!ckbDate.Checked)
					return DateTime.MaxValue;
				return dtpTo.Value;
			}
		}
		public bool OutputStatistic
		{
			get { return ckbStatistic.Checked; }
		}
		public bool Group
		{
			get { return ckbGroup.Checked; }
		}
		public bool AssignDate
		{
			get { return ckbDate.Checked; }
		}
		public string Line
		{
			get
			{
				if (cbxLine.SelectedIndex < 1)
					return null;
				return cbxLine.SelectedValue as string;
			}
		}
		public string SortString
		{
			get
			{
				return _sortForm.SortString;
			}
		}
		public InspeceMode InspeceMode
		{
			get
			{
				return rbInspectByPn.Checked ? InspeceMode.ByPn : InspeceMode.ByQcNo;
			}
		}

		public InspectListReportForm()
		{
			InitializeComponent();

			DateTime today = DateTime.Today;

			dtpFrom.Value = new DateTime(today.Year, today.Month, 1);
			dtpTo.Value = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));

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

			_sortForm = new InspectListReportSortForm();
			_sortForm.Columns = new SortColumn[] {
				new SortColumn("產線"),
				new SortColumn("QCN", "QC#"),
				new SortColumn("品號", "料號"),
				new SortColumn("工作單號"),
				new SortColumn("檢驗日期")
			};
		}

		private void btnExport_Click(object sender, EventArgs e)
		{
			ExportClick(this, e);
		}

		private void ckbDate_CheckedChanged(object sender, EventArgs e)
		{
			pnlDate.Enabled = ckbDate.Checked;
		}

		private void InspectListReportForm_Load(object sender, EventArgs e)
		{

		}

		private void btnSort_Click(object sender, EventArgs e)
		{
			//if (_sortForm.ShowDialog() == DialogResult.OK)
			//    MessageBox.Show(_sortForm.SortString);
			_sortForm.ShowDialog();
		}

		private void rbInspectByQcN_CheckedChanged(object sender, EventArgs e)
		{
			ckbGroup.Enabled = rbInspectByQcN.Checked;
			if (!ckbGroup.Enabled)
				ckbGroup.Checked = false;
			txtQCN.Enabled = rbInspectByQcN.Checked;
		}
	}
}
