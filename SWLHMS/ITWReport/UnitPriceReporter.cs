using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

using Microsoft.Office.Interop.Excel;
using Mong.ReportDataSetTableAdapters;

using DataTable = System.Data.DataTable;

namespace Mong.Report
{
    class UnitPriceReporter : SingleSheetReporter, IFormSettable
    {

        ReportDataSet.UnitPriceReportDataTable _table;
        DateTime _startDate = DateTime.MinValue;
        DateTime _endDate = DateTime.MaxValue;
        Dictionary<int, string> _npDic;

        public Dictionary<int, string> NpDic
        {
            get
            {
                if (_npDic == null)
                {
                    _npDic = new Dictionary<int, string>();
                    foreach (DatabaseSet.非生產Row row in DatabaseSet.非生產Table)
                    {
                        if (row.編號 != -1)
                            _npDic.Add(row.編號, row.名稱);
                    }
                }

                return _npDic;
            }
            set { _npDic = value; }
        }
        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }
        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }

        public UnitPriceReporter()
        {
            this.Name = "單位工資成本表";
			this.AllowUser |= UserType.Manager;
        }

        protected override void BeforeExport()
        {
            //建立報表table
            InitReportTable();

            base.BeforeExport();
        }

        protected override void WriteHeader()
        {
            this.Sheet.Cells[1, 1] = this.Name;
            this.Sheet.Cells[2, 1] = "完成期間: " + _startDate.ToString("yyyy/MM/dd") + " 至 " + _endDate.ToString("yyyy/MM/dd");

            base.WriteHeader();
        }

        protected override void WriteColumnHeader()
        {
            ReportSourceProfile profile = new ReportSourceProfile(_table);
			//foreach (DataColumn column in _table.Columns)
			//    profile.AddExportColumn(column);

			profile.AddExportColumn("品號");
			profile.AddExportColumn("品名");
			profile.AddExportColumn("數量");
			profile.AddExportColumn("單位");
			profile.AddExportColumn("標準工時").Name = "標準總工時";
			profile.AddExportColumn("標準單位工資").Name = "標準總工資";
			profile.AddExportColumn("實際工時(內+外)").Name = "實際總工時(內+外)";
			profile.AddExportColumn("實際工資(內+外)").Name = "實際總工資(內+外)";
			profile.AddExportColumn("系統時薪").Name = "系統時薪\n(NT$/Hour)";
			profile.AddExportColumn("單位標準工資").Name = "標準單位工資\n(NT$/Kpcs)";
			profile.AddExportColumn("實際單位工資(NT$/Kpcs)").Name = "實際單位工資\n(NT$/Kpcs)";

            this.SheetAdapter.ReportProfile = profile;

            this.SheetAdapter.PasteColumns(_table, 3, 1);

            base.WriteColumnHeader();
        }

        protected override void WriteContent()
        {
            //建立寫入前置作業
            int writeRow = 4;
            PasteDataRowsOptions options = new PasteDataRowsOptions();
            options.IncludeSummary = false;
            options.Row = writeRow;

            DataRow[] rows = _table.Select();

            //寫入內容
            writeRow = this.SheetAdapter.PasteDataRows(rows, options);

            //寫入總計
            string[] sumCols = new string[] { "數量", "標準工時", "實際工時(內+外)", "實際工資(內+外)" };
            DataRow totalRow = _table.NewRow();
            totalRow[0] = "總計";
            foreach (string sumCol in sumCols)
            {
                object o;
                o = _table.Compute("SUM([" + sumCol + "])", string.Empty);
                totalRow[sumCol] = Convert.IsDBNull(o) ? 0 : (decimal)o;
            }
            _table.Rows.Add(totalRow);

            writeRow = this.SheetAdapter.PasteDataRow(totalRow, writeRow, 1);

            
            base.WriteContent();
        }

        protected override void AfterContentWritten()
        {
			ReportSourceProfile profile = this.SheetAdapter.ReportProfile;

			//設定顯示格式

			//設定小數位數
			int[] formatCols = new int[]
			{
				profile.IndexOf("標準工時") + 1,
				profile.IndexOf("標準單位工資") + 1,
				profile.IndexOf("實際工時(內+外)") + 1,
				profile.IndexOf("實際工資(內+外)") + 1,
				profile.IndexOf("實際單位工資(NT$/Kpcs)") + 1,
			};

			foreach (int col in formatCols)
				this.SheetAdapter.SetFormat(4, col, "[=0]* \"-\"_-;G/通用格式");

			this.SheetAdapter.RoundValues(formatCols, 4, 2);

            //設定外觀樣式
            Range reportBodyRange = this.SheetAdapter.GetUsedRange(3);
            reportBodyRange.Columns.AutoFit();

			this.SheetAdapter.GetRange(1, profile.IndexOf("系統時薪") + 1).ColumnWidth = 12.5;
			this.SheetAdapter.GetRange(1, profile.IndexOf("單位標準工資") + 1).ColumnWidth = 15;
			this.SheetAdapter.GetRange(1, profile.IndexOf("實際單位工資(NT$/Kpcs)") + 1).ColumnWidth = 15;

            this.SheetAdapter.SetBorder(reportBodyRange, XlLineStyle.xlContinuous, XlBorderWeight.xlThin, true, true, true, true);

            base.AfterContentWritten();
        }

        void InitReportTable()
        {
            ReportDataSetTableAdapters.UnitPriceReportTableAdapter adapter = new Mong.ReportDataSetTableAdapters.UnitPriceReportTableAdapter();

            //取得基本報表資料
            _table = adapter.GetData(_startDate, _endDate);
            

            //取得工作單號,品號,實際工資表
            System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
			cmd.CommandText = "SELECT 工作單.單號 AS 單號, 產品品號.品號, Year(工時.日期) AS 年份, Month(工時.日期) AS 月份, " + 
                                "IIF(SUM(工時.工時) IS NULL , 0, SUM(工時.工時)) AS 實際工時," + 
                                "IIF(SUM(工時.工時) IS NULL , 0, SUM(員工.薪水 * 工時.工時)) AS 實際工資 " +
                                "FROM ((((工作單 INNER JOIN 工作單品號 ON 工作單品號.單號 = 工作單.單號) " +
                                "INNER JOIN 產品品號 ON 工作單品號.品號 = 產品品號.品號) " +
                                "LEFT JOIN 工時 ON 工時.工作單號 =  工作單品號.單號 AND 工作單品號.編號 = 工時.工品編號) " +
                                "LEFT JOIN 員工 ON 工時.員工編號 = 員工.編號) " +
                                "WHERE 工作單.實際完成日 > #" + _startDate.ToString("yyyy/MM/dd") + "# AND 工作單.實際完成日 < #" + _endDate.ToString("yyyy/MM/dd") + "# " +
								"GROUP BY  工作單.單號, 產品品號.品號, Year(工時.日期), Month(工時.日期)" +
								"ORDER BY  工作單.單號, 產品品號.品號, Year(工時.日期), Month(工時.日期)";

            cmd.Connection = adapter.Connection;
            System.Data.DataTable baseTable = new System.Data.DataTable();
            baseTable.Columns.Add(new DataColumn("單號", typeof(string)));
            baseTable.Columns.Add(new DataColumn("品號", typeof(string)));
            baseTable.Columns.Add(new DataColumn("實際工時", typeof(decimal)));
            baseTable.Columns.Add(new DataColumn("實際工資", typeof(decimal)));
            baseTable.Columns.Add(new DataColumn("年份", typeof(int)));
            baseTable.Columns.Add(new DataColumn("月份", typeof(int)));
            System.Data.OleDb.OleDbDataAdapter baseAdapter = new System.Data.OleDb.OleDbDataAdapter();
            baseAdapter.SelectCommand = cmd;
            baseAdapter.Fill(baseTable);

            //取得日期範圍
            int minYear, minMonth, maxYear, maxMonth;
            DateTime minDate, maxDate;
            object o;

            o = baseTable.Compute("MIN(年份)", string.Empty);
            minYear = Convert.IsDBNull(o) ? DateTime.MinValue.Year : (int)o;

            o = baseTable.Compute("MIN(月份)", string.Empty);
            minMonth = Convert.IsDBNull(o) ? DateTime.MinValue.Month : (int)o;

            o = baseTable.Compute("MAX(年份)", string.Empty);
            maxYear = Convert.IsDBNull(o) ? DateTime.MinValue.Year : (int)o;

            o = baseTable.Compute("MAX(月份)", string.Empty);
            maxMonth = Convert.IsDBNull(o) ? DateTime.MinValue.Month : (int)o;

            minDate = new DateTime(minYear, minMonth, 1);
            maxDate = new DateTime(maxYear, maxMonth, 1);
            
            //取得每月工作時數
            Dictionary<DateTime, decimal> workHoursDic = new Dictionary<DateTime, decimal>();
            for (DateTime date = new DateTime(minDate.Year, minDate.Month, 1); date <= maxDate; date = date.AddMonths(1))
            {
                decimal hours = Global.GetWorkingHours(date.Year, date.Month);
                workHoursDic.Add(date, hours);
            }

            //重新計算baseTable的實際工資
            DateTime curRowMonth = DateTime.MinValue;
            foreach (DataRow row in baseTable.Rows)
            {
                if (!Convert.IsDBNull(row["年份"]))
                {
                    int year = (int)row["年份"];
                    int month = (int)row["月份"];

                    if (year != curRowMonth.Year || month != curRowMonth.Month)
                        curRowMonth = new DateTime(year, month, 1);

                    row["實際工資"] = Math.Round(((decimal)row["實際工資"]) / workHoursDic[curRowMonth], MidpointRounding.AwayFromZero);
                }
            }

            //重新Group
            DataTableHelper dtHelper = new DataTableHelper();
            System.Data.DataTable groupTable = dtHelper.SelectGroupByInto("GroupTable", baseTable, "品號,SUM(實際工時) 實際工時, SUM(實際工資) 實際工資", null, "品號");

            //取得指定日期範圍內的工作單號
            cmd = new System.Data.OleDb.OleDbCommand();
            cmd.CommandText = "SELECT DISTINCT(單號) FROM 工作單 WHERE 實際完成日 > #" + _startDate.ToString("yyyy/MM/dd") + "# AND 實際完成日 < #" + _endDate.ToString("yyyy/MM/dd") + "#";
            cmd.Connection = adapter.Connection;
            System.Data.DataTable wsNumTable = new System.Data.DataTable();
            wsNumTable.Columns.Add(new DataColumn("單號", typeof(string)));
            System.Data.OleDb.OleDbDataAdapter wsNumAdapter = new System.Data.OleDb.OleDbDataAdapter();
            wsNumAdapter.SelectCommand = cmd;
            wsNumAdapter.Fill(wsNumTable);

            List<string> wsNumList = new List<string>();
            foreach (DataRow row in wsNumTable.Rows)
                wsNumList.Add(row["單號"].ToString());

            //取得LaborWage資料庫
            LaborWageHelper lwHelper = new LaborWageHelper();
            LaborWage工作單品號Table lwTable = lwHelper.GetDataGroupByPartNumber(wsNumList);

            //填入工資與工時
            foreach (ReportDataSet.UnitPriceReportRow row in _table)
            {
                DataRow[] partRows = groupTable.Select(string.Format("品號 = '{0}'", row.品號));
                if (partRows.Length > 0)
                {

                    row._實際工時_內_外_ = (decimal)partRows[0]["實際工時"];
                    row._實際工資_內_外_ = (decimal)partRows[0]["實際工資"];
                   
                }

                //填入LaborWage資料
                DataRow[] lwRows = lwTable.Select(string.Format("品號 = '{0}'", row.品號));
                if (lwRows.Length > 0)
                {
                    decimal wage = (decimal)lwRows[0]["外包工資"];
                    row._實際工資_內_外_ += wage;
					row._實際工時_內_外_ += wage / Settings.HourlyPay;
                }
            }
        }

        #region IFormSettable 成員

        public void OpenForm()
        {
            DateForm form = new DateForm();
            form.Text = this.Name;
            form.DateTypeName = "工作單實際完成日";
            form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            form.ExportClick += new EventHandler(form_ExportClick);
            form.ShowDialog();
        }

        void form_ExportClick(object sender, EventArgs e)
        {
            DateForm form = (DateForm)sender;
            this.StartDate = form.StartDate;
            this.EndDate = form.EndDate;
            this.Export();
        }

        #endregion
    }
}
