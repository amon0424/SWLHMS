using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

using Mong.Report;

namespace Mong
{
    class WorksheetDetail : SingleSheetReporter , IFormSettable
    {
        string _worksheetNo;
        DateTime _startDate;
        bool _useDate;
        DateTime _endDate;
        DataTable _table;

        public WorksheetDetail()
        {
            this.Name = "工作單明細表";
			this.AllowUser |= UserType.Manager;
        }

        protected override void BeforeExport()
        {
            // Create table
            CreateReportTable();

            // Get data form db
            OleDbConnection conn = DbConnection.Instance;
            ConnectionState oriConnState = conn.State;
            if ((conn.State & ConnectionState.Open) != ConnectionState.Open)
                conn.Open();

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
			cmd.CommandText = "SELECT 單據日期, A.單號 as 工作單號, 客戶, 品號, 數量, 預計完成日, B.實際完成日, B.編號 as 序號 " +
                                "FROM 工作單 as A INNER JOIN 工作單品號 as B on A.單號 = B.單號";

            string whereTxt = null;
            if(_worksheetNo != null)
            {
                whereTxt = "A.單號 = ?";
                cmd.Parameters.Add(new OleDbParameter("單號", _worksheetNo));
            }
            else if (_useDate)
            {
                whereTxt = "A.單據日期 >= #" + _startDate.ToString("yyyy/MM/dd") + "# AND A.單據日期 <= #" + _endDate.ToString("yyyy/MM/dd") + "#";
            }

            if (whereTxt != null)
                cmd.CommandText += " WHERE " + whereTxt;

			cmd.CommandText += " ORDER by A.單號, B.編號, B.品號";

            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(_table);
            
            // Fill the serial number ( 1.08.6 below only)
			/*
            string currentSheet = null;
            int sn = 1;
            foreach (DataRow row in _table.Rows)
            {
                string sheet = (string)row["工作單號"];
                if (sheet != currentSheet)
                {
                    currentSheet = sheet;
                    sn = 1;
                }
                row["序號"] = sn++;
            }
			*/

            if (oriConnState == ConnectionState.Closed)
                conn.Close();
            // *****

            // Create profile
            ReportSourceProfile profile = new ReportSourceProfile();
            profile.ColumnHeaderHGrid = true;

            base.BeforeExport();
        }

        protected override void WriteHeader()
        {
            this.Sheet.Cells[1, 1] = this.Name;
            if(_useDate)
                this.Sheet.Cells[2, 1] = "期間: " + _startDate.ToString("yyyy/MM/dd") + " 至 " + _endDate.ToString("yyyy/MM/dd");

            base.WriteHeader();
        }

        protected override void WriteContent()
        {
            this.SheetAdapter.PasteDataTable(_table, 3, 1);
            base.WriteContent();
        }

        protected override void AfterContentWritten()
        {
            this.SheetAdapter.SetFormat(3, _table.Columns.IndexOf("工作單號") + 1, "0");
            this.SheetAdapter.GetUsedRange(3).Columns.AutoFit();
            base.AfterContentWritten();
        }

        void CreateReportTable()
        {
            _table = new DataTable();
            _table.Columns.Add(new DataColumn("單據日期", typeof(DateTime)));
            _table.Columns.Add(new DataColumn("工作單號", typeof(string)));
            _table.Columns.Add(new DataColumn("序號", typeof(int)));
            _table.Columns.Add(new DataColumn("客戶", typeof(string)));
            _table.Columns.Add(new DataColumn("品號", typeof(string)));
            _table.Columns.Add(new DataColumn("數量", typeof(decimal)));
            _table.Columns.Add(new DataColumn("預計完成日", typeof(DateTime)));
            _table.Columns.Add(new DataColumn("實際完成日", typeof(DateTime)));
        }

        #region IFormSettable 成員

        public void OpenForm()
        {
            WorksheetDateForm form = new WorksheetDateForm();
            form.DateTypeName = "工作單單據日期";
            form.Text = this.Name;
            form.ExportClick += new EventHandler(form_ExportClick);
            form.ShowDialog();
        }

        void form_ExportClick(object sender, EventArgs e)
        {
            WorksheetDateForm form = (WorksheetDateForm)sender;
            _worksheetNo = form.Worksheet;
            _useDate = form.UseDate;
            if (_useDate)
            {
                _startDate = form.StartDate;
                _endDate = form.EndDate;
            }

            this.Export();
        }

        #endregion
    }
}
