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
    public partial class WorksheetInputForm : Form
    {
        public event EventHandler ExportClick;

        public string Worksheet
        {
            get
            {
                return cbbWorksheetNubmerS.SelectedValue as string;
            }
        }
        public string Contact
        {
            get
            {
                return txtContact.Text;
            }
        }

		public string GangerName
		{
			get
			{
				return txtName.Text;
			}
		}

        public WorksheetInputForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportClick(this, e);
        }

        private void btnSrchWorksheet_Click_1(object sender, EventArgs e)
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
    }
}