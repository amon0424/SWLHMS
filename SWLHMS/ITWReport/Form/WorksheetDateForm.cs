using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mong
{
    public partial class WorksheetDateForm : Form
    {
        public event EventHandler ExportClick;

        string _dateTypeName;

        public string Worksheet
        {
            get
            {
                if (!ckbDate.Checked)
                {
                    string val = cbbWorksheetNubmerS.SelectedValue as string;
                    if (val != null && val.Trim() != string.Empty)
                        return val;
                }
                return null;
            }
        }
        public DateTime StartDate
        {
            get
            {
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
                return dtpTo.Value;
            }
            set
            {
                dtpTo.Value = value;
            }
        }
        public bool UseDate
        {
            get
            {
                return ckbDate.Checked;
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

        public WorksheetDateForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            DateTime now = DateTime.Now;
            this.StartDate = new DateTime(now.Year, now.Month, 1);
            this.EndDate = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month));
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportClick(this, e);
        }

        private void btnSrchWorksheet_Click(object sender, EventArgs e)
        {
            try
            {
                string dateTxt = txtDate.Text;

                OleDbConnection conn = DbConnection.Instance;
                ConnectionState oriConnState = conn.State;
                if ((conn.State & ConnectionState.Open) != ConnectionState.Open)
                    conn.Open();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
				if (dateTxt != string.Empty)
				{
					//cmd.CommandText = "SELECT 單號 FROM 工作單 WHERE 單號 LIKE '" + dateTxt + "%'";
					cmd.CommandText = "SELECT 單號 FROM 工作單";

					//產生日期條件
					List<string> dateFilter = new List<string>();

					string[] dateFunc = new string[] { "YEAR", "MONTH", "DAY" };

					string[] dateTxtArr = dateTxt.Split('-');
					for (int i = 0; i < 3; i++)
					{
						if (!string.IsNullOrEmpty(dateTxtArr[i].Trim()))
						{
							int val = int.Parse(dateTxtArr[i]);
							dateFilter.Add(dateFunc[i] + "(單據日期)=" + val);
						}
					}

					if (dateFilter.Count > 0)
						cmd.CommandText += " WHERE " + string.Join(" AND ", dateFilter.ToArray());
				}
				else
					cmd.CommandText = "SELECT 單號 FROM 工作單";

                OleDbDataReader reader = cmd.ExecuteReader();
                List<string> worksheetNumbers = new List<string>();
                while (reader.Read())
                    worksheetNumbers.Add(reader.GetString(0));
                reader.Close();

                if (oriConnState == ConnectionState.Closed)
                    conn.Close();

                cbbWorksheetNubmerS.SelectedIndex = -1;
                cbbWorksheetNubmerS.DataSource = worksheetNumbers;

            }
            catch (Exception ex)
            {
                Global.ShowError(ex);
            }
        }

        private void ckbDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpFrom.Enabled = dtpTo.Enabled = ckbDate.Checked;
            cbbWorksheetNubmerS.Enabled = !ckbDate.Checked;
        }
    }
}