using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mong
{
	
	public partial class InspectListReportSortForm : Form
	{
		SortColumn[] _columns;
		string _sortString;
		DataTable _table;

		public SortColumn[] Columns
		{
			get { return _columns; }
			set 
			{ 
				_columns = value;
				col排序欄位.DataSource = _columns;
			}
		}
		public string SortString
		{
			get { return _sortString; }
		}

		public InspectListReportSortForm()
		{
			InitializeComponent();

			col排序方式.DataSource = new string[] { "遞增", "遞減" };

			
			col排序欄位.DisplayMember = "Display";
			col排序欄位.ValueMember = "Name";

			_table = new DataTable();
			_table.Columns.Add("順位", typeof(int));
			_table.Columns.Add("欄位");
			_table.Columns.Add("方式");

			//bindingSource.DataSource = _table;
			dgv.DataSource = _table;
		}

		private void InspectListReportSortForm_Load(object sender, EventArgs e)
		{
			
		}

		void GenerateSortString()
		{
			List<string> sortCols = new List<string>();

			foreach (DataRow row in _table.Select(null, "順位"))
			{
				string col = row["欄位"].ToString();
				string sort = row["方式"].ToString() == "遞增" ? "ASC" : "DESC";
				sortCols.Add(col + " " + sort); 
			}

			_sortString = string.Join(",", sortCols.ToArray());
			_table.AcceptChanges();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			GenerateSortString();
			this.DialogResult = DialogResult.OK;
			this.Hide();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			_table.RejectChanges();
		}

		private void dgv_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
		{
			int index = 1;
			if (_table != null)
			{
				object o = _table.Compute("MAX(順位)", null);
				if (o != DBNull.Value)
					index = Convert.ToInt32(o) + 1;
			}

			e.Row.Cells[col順位.Index].Value = index;
			e.Row.Cells[col排序方式.Index].Value = "遞增";
		}

		private void dgv_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
		{
			int index = 1;
			foreach (DataGridViewRow row in dgv.Rows)
			{
				row.Cells[col順位.Index].Value = index++;
			}
			dgv.AllowUserToAddRows = true;
		}

		private void dgv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
		{
			dgv.AllowUserToAddRows = false;
		}

		
	}

	public class SortColumn
	{
		string _name;
		string _display;

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}
		public string Display
		{
			get { return _display; }
			set { _display = value; }
		}

		public SortColumn(string name, string display)
		{
			Display = display;
			Name = name;
		}

		public SortColumn(string name)
		{
			Display = name;
			Name = name;
		}
	}
}
