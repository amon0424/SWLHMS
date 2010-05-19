using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mong
{
	public partial class DateLineForm : Form
	{
		public event EventHandler ExportClick;

        string _dateTypeName;
       
        public DateTime StartDate
        {
            get
            {
                if (AllTime)
                    return DateTime.MinValue;
                return dtpFrom.Value;
            }
            set
            {
               
                dtpFrom.Value = value;
            }
        }
        public DateTime EndDate
        {
            get
            {
                if (AllTime)
                    return DateTime.MaxValue;
                return dtpTo.Value;
            }
            set
            {
                dtpTo.Value = value;
            }
        }
        public bool AllowAllTime
        {
            get
            {
                return ckbAllTime.Visible;
            }
            set
            {
                ckbAllTime.Visible = value;
            }
        }
        public bool AllTime
        {
            get
            {
                return ckbAllTime.Checked;
            }
        }
        public string DateTypeName
        {
            get { return _dateTypeName; }
            set 
            {
                _dateTypeName = value;
                groupBox1.Text = _dateTypeName;
            }
        }
		public string Line
		{
			get 
			{ 
				return cbbLine.SelectedValue as string; 
			}
		}

		public DateLineForm()
		{
			InitializeComponent();

			DateTime today = DateTime.Today;

			StartDate = new DateTime(today.Year, today.Month, 1);
			EndDate = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));

			DataTable lineTable = DatabaseSet.產線Table.Copy();
			lineTable.Columns.Add("Display", typeof(string));
			foreach (DataRow row in lineTable.Rows)
				row["Display"] = row["產線"];

			DataRow allRow = lineTable.NewRow();
			allRow["產線"] = string.Empty;
			allRow["Display"] = "全部";
			lineTable.Rows.Add(allRow);

			bsLine.DataSource = lineTable;
			bsLine.Sort = "產線";
			cbbLine.DisplayMember = "Display";
			cbbLine.ValueMember = "產線";
		}

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportClick(this, e);
        }

        private void ckbAllTime_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = !ckbAllTime.Checked;
        }
	}
}
