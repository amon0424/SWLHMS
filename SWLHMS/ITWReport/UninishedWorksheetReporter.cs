using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Microsoft.Office.Interop.Excel;
using Mong.ReportDataSetTableAdapters;

using DataTable = System.Data.DataTable;

namespace Mong.Report
{
    class UninishedWorksheetReporter : SingleSheetReporter, IFormSettable
    {
        protected DataTable _table;

        bool _allTime;
		DateLineForm _form;
        DateTime _startDate = DateTime.MinValue;
        DateTime _endDate = DateTime.MaxValue;

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

        public UninishedWorksheetReporter()
        {
            //this.Name = "未完成工作單明細表";
			this.Name = "在製工單明細表";
        }

        protected override void BeforeExport()
        {
			string lineFilter = string.Empty;
			if (!string.IsNullOrEmpty(_form.Line))
				lineFilter = "產線 = '" + _form.Line + "'";

            UnfinishedWorksheetReportSourceTableAdapter adapter = new UnfinishedWorksheetReportSourceTableAdapter();

            //取得基本報表資料
			ReportDataSet.UnfinishedWorksheetReportSourceDataTable srcTable = adapter.GetData(this.StartDate, this.EndDate,
				this.StartDate == DateTime.MinValue && this.EndDate == DateTime.MaxValue);
			srcTable.Columns.Add("退驗數量", typeof(decimal));
			srcTable.Columns.Add("待驗數量", typeof(decimal));

            //取得日期範圍
            int minYear, minMonth, maxYear, maxMonth;
            DateTime from, to;
            object o;

            o = srcTable.Compute("MIN(年份)", string.Empty);
            minYear = Convert.IsDBNull(o) ? DateTime.MinValue.Year : (int)o;

            o = srcTable.Compute("MIN(月份)", string.Empty);
            minMonth = Convert.IsDBNull(o) ? DateTime.MinValue.Month : (int)o;

            o = srcTable.Compute("MAX(年份)", string.Empty);
            maxYear = Convert.IsDBNull(o) ? DateTime.MinValue.Year : (int)o;

            o = srcTable.Compute("MAX(月份)", string.Empty);
            maxMonth = Convert.IsDBNull(o) ? DateTime.MinValue.Month : (int)o;

            from = new DateTime(minYear, minMonth, 1);
            to = new DateTime(maxYear, maxMonth, 1);

            //取得每月工作時數
            Dictionary<DateTime, decimal> workHoursDic = new Dictionary<DateTime, decimal>();
            for (DateTime date = new DateTime(from.Year, from.Month, 1); date <= to; date = date.AddMonths(1))
            {
                decimal hours = Global.GetWorkingHours(date.Year, date.Month);
                workHoursDic.Add(date, hours);
            }

            //重新運算內部工資
            DateTime curRowMonth = DateTime.MinValue;
            foreach (ReportDataSet.UnfinishedWorksheetReportSourceRow row in srcTable)
            {
                if (!Convert.IsDBNull(row["年份"]))
                {
                    if (row.年份 != curRowMonth.Year || row.月份 != curRowMonth.Month)
                        curRowMonth = new DateTime(row.年份, row.月份, 1);

                    row.內部工資 = Math.Round(row.內部工資 / workHoursDic[curRowMonth], MidpointRounding.AwayFromZero);
                }
            }

            //重新Group資料
            DataTableHelper dtHelper = new DataTableHelper();
            _table = dtHelper.SelectGroupByInto("ReportTable", srcTable,
				"產線,單據日期,預計完成日,工作單號,序號,品號,品名,退驗數量,待驗數量,數量,單位" + 
				",標準工時,單位人工成本, 總標準工時,Sum(內部工時) 內部工時, Sum(內部工資) 內部工資"+
				",外包工時,外包工資,Sum(已生產數量) 已生產數量,完成%,生產效率,尚需工時,工品編號", lineFilter, "產線,單據日期,預計完成日,工作單號,品號,品名,數量,標準工時,單位人工成本,工品編號");

            //設定欄位
            _table.Columns["單位"].DefaultValue = "KPCS";
			_table.Columns.Add("未完成數量", typeof(decimal), "數量-已生產數量").SetOrdinal(9);

            //取得LaborWage資料庫
            LaborWageHelper lwHelper = new LaborWageHelper();
            LaborWage工作單品號Table lwTable = null;

            //運算序號並填入外包工資與工時
            string curWorksheetNumber = string.Empty;
            //int seriesNumber = 1;
            foreach (DataRow row in _table.Rows)
            {
                string wsNumber = row["工作單號"].ToString();
				string pn = row["品號"].ToString();
				int wpid = (int)row["工品編號"];

                if (curWorksheetNumber != wsNumber)
                {
                    curWorksheetNumber = wsNumber;
                    //seriesNumber = 1;
                    lwTable = lwHelper.GetData(curWorksheetNumber);
                }

				//取得退驗
				row["退驗數量"] = DatabaseSet.GetNGAmount(wsNumber, wpid) / 1000.0f;
				row["待驗數量"] = DatabaseSet.GetInspectedAmount(wsNumber, wpid) / 1000.0f;

				//計算未完成數量
				//row["未完成數量"] = (decimal)row["數量"] - (decimal)row["已生產數量"];

                //DataRow[] lwRows = lwTable.Select(string.Format("品號 = '{0}'", row["品號"].ToString()));
				//DataRow[] lwRows = lwTable.Select(string.Format("工品編號 = {0}", row["工品編號"].ToString()));
				object result = lwTable.Compute("SUM(外包工資)", string.Format("工品編號 = {0}", row["工品編號"].ToString())); 
                //if (lwRows.Length > 0)
				if(result != null && result != DBNull.Value)
                {
                    //decimal laborWage = (decimal)lwRows[0]["外包工資"];
					decimal laborWage = Convert.ToDecimal(result);

                    //decimal number = (decimal)lwRows[0]["數量"];
                    row["外包工資"] = laborWage;
					row["外包工時"] = laborWage / Settings.HourlyPay;
                    //row["已生產數量"] = (decimal)row["已生產數量"] + number;
                }
				if ((decimal)row["總標準工時"] != 0)
					//row["生產效率"] = ((decimal)row["內部工時"] + (decimal)row["外包工時"]) / ((decimal)row["總標準工時"] * (decimal)row["完成%"]);
					//row["尚需工時"] = (decimal)row["總標準工時"] * (1 - (decimal)row["完成%"]);
					row["尚需工時"] = (decimal)row["總標準工時"] - (decimal)row["內部工時"] - (decimal)row["外包工時"];
				else
					row["尚需工時"] = 0;

                //row["序號"] = seriesNumber++;
				row["序號"] = wpid;
            }

            base.BeforeExport();
        }

        protected override void WriteHeader()
        {
            this.Sheet.Cells[1, 1] = this.Name;
            if (!_allTime)
                this.Sheet.Cells[2, 1] = "期間: " + _startDate.ToString("yyyy/MM/dd") + " 至 " + _endDate.ToString("yyyy/MM/dd");

            base.WriteHeader();
        }

        protected override void WriteColumnHeader()
        {
            ReportSourceProfile profile = new ReportSourceProfile(_table);
			//profile.ExcludeExportColumn(new List<DataColumn>(new DataColumn[]{_table.Columns["工品編號"]}));
			
			profile.AddExportColumn("產線");
			profile.AddExportColumn("單據日期");
			profile.AddExportColumn("預計完成日");
			profile.AddExportColumn("工作單號");
			profile.AddExportColumn("序號");
			profile.AddExportColumn("品號");
			profile.AddExportColumn("品名");
			profile.AddExportColumn("數量");
			profile.AddExportColumn("已生產數量").Name = "完成數量";
			profile.AddExportColumn("未完成數量").Name = "待製數量";
			profile.AddExportColumn("待驗數量");
			profile.AddExportColumn("退驗數量");

			profile.AddExportColumn("單位");
			profile.AddExportColumn("標準工時").Name = "標準工時\n(Hour/Kpcs)";
			profile.AddExportColumn("單位人工成本").Name = "報價時薪\n(NT$/Hour)";
			profile.AddExportColumn("總標準工時");
			profile.AddExportColumn("內部工時");
			profile.AddExportColumn("內部工資");
			profile.AddExportColumn("外包工時");
			profile.AddExportColumn("外包工資");
			
			profile.AddExportColumn("完成%");
			profile.AddExportColumn("生產效率").Name = "標準總工時/\n實際總工時";
			profile.AddExportColumn("尚需工時").Name = "尚需標準工時";

			//profile.ColumnMap[_table.Columns["數量"]].Name = "數量";
			//profile.ColumnMap[_table.Columns["標準工時"]].Name = "標準工時\n(Hour/Kpcs)";
			//profile.ColumnMap[_table.Columns["單位人工成本"]].Name = "系統時薪\n(NT$/Hour)";
			//profile.ColumnMap[_table.Columns["生產效率"]].Name = "實際總工時/\n標準總工時";
			//profile.ColumnMap[_table.Columns["尚需工時"]].Name = "尚需標準工時";

            //profile.ColumnMap[_table.Columns["內部工時"]].Name = "內部工時\n(Hour/Kpcs)";
            //profile.ColumnMap[_table.Columns["內部工資"]].Name = "內部工資\n(NT$/Kpcs)";
            //profile.ColumnMap[_table.Columns["外包工資"]].Name = "外包工資\n(NT$/Kpcs)";
            //profile.ColumnMap[_table.Columns["外包工時"]].Name = "外包工時\n(Hour/Kpcs)";

            this.SheetAdapter.ReportProfile = profile;

            this.SheetAdapter.PasteColumns(_table, 3, 1);

			Application.ErrorCheckingOptions.NumberAsText = false;
			this.SheetAdapter.GetRange(4, profile.IndexOf("工作單號") + 1).EntireColumn.NumberFormat = "@";


            base.WriteColumnHeader();
        }

        protected override void WriteContent()
        {
            DataTable linesTable = DataTableHelper.SelectDistinct(_table, "產線");

            //建立寫入前置作業
            int writeRow = 4;
            PasteDataRowsOptions options = new PasteDataRowsOptions();
            options.IncludeSummary = true;
            options.SummaryColumns.AddRange(new string[] {"退驗數量","待驗數量", "數量", "標準工時", "單位人工成本", "總標準工時", "內部工時", "內部工資", "外包工資", "外包工時", "已生產數量", "尚需工時" });

            //對每個產線
            foreach (DataRow lineRow in linesTable.Rows)
            {
                DataRow[] rows = _table.Select("產線 = '" + lineRow["產線"] + "'", "工作單號,序號");

                //寫入內容
                options.Row = writeRow;
                options.SummaryPrefix = lineRow["產線"] + "產線小計";

                writeRow = this.SheetAdapter.PasteDataRows(rows, options);
            }

            //寫入總計
			DataTable tmpTable = _table.Clone();
			DataRow totalRow = tmpTable.NewRow();
			totalRow[0] = "總計";

			foreach (string sumCol in options.SummaryColumns)
			{
				if (!string.IsNullOrEmpty(tmpTable.Columns[sumCol].Expression))
					tmpTable.Columns[sumCol].Expression = string.Empty;

				object o;
				o = _table.Compute("SUM(" + sumCol + ")", string.Empty);
				totalRow[sumCol] = Convert.IsDBNull(o) ? 0 : (decimal)o;
			}

			tmpTable.Rows.Add(totalRow);

			writeRow = this.SheetAdapter.PasteDataRow(totalRow, writeRow, 1);
            
            base.WriteContent();
        }

        protected override void AfterContentWritten()
        {
			ReportSourceProfile profile = this.SheetAdapter.ReportProfile;

            //設定顯示格式
			this.SheetAdapter.SetFormat(4, profile.IndexOf("退驗數量") + 1, "[紅色]G/通用格式;G/通用格式;* \"-\"_-");

			this.SheetAdapter.SetFormat(3, profile.IndexOf("待驗數量") + 1, "[=0]* \"-\"_-;G/通用格式");
			this.SheetAdapter.SetFormat(3, profile.IndexOf("已生產數量") + 1, "[=0]* \"-\"_-;G/通用格式");

			this.SheetAdapter.SetFormat(3, profile.IndexOf("完成%") + 1, "0.00%");
			this.SheetAdapter.SetFormat(3, profile.IndexOf("生產效率") + 1, "0.00%");

			//設定小數位數
			int[] formatCols = new int[]
			{
				profile.IndexOf("總標準工時") + 1,	
				profile.IndexOf("標準工時") + 1,
				profile.IndexOf("單位人工成本") + 1,
				profile.IndexOf("內部工時") + 1,
				profile.IndexOf("內部工資") + 1,
				profile.IndexOf("外包工資") + 1,
				profile.IndexOf("外包工時") + 1,
				profile.IndexOf("尚需工時") + 1
			};

			foreach (int col in formatCols)
				this.SheetAdapter.SetFormat(3, col, "[=0]* \"-\"_-;G/通用格式");

			this.SheetAdapter.RoundValues(formatCols, 3, 2);

            //設定外觀樣式
            Range range;
            range = this.SheetAdapter.GetUsedRange(3);
            range.Columns.AutoFit();

			this.SheetAdapter.GetRange(1, profile.IndexOf("單位人工成本") + 1).EntireColumn.ColumnWidth = 15;
			this.SheetAdapter.GetRange(1, profile.IndexOf("標準工時") + 1).EntireColumn.ColumnWidth = 12;
			this.SheetAdapter.GetRange(1, profile.IndexOf("生產效率") + 1).EntireColumn.ColumnWidth = 12;

            range = this.SheetAdapter.GetUsedRange(3);
            this.SheetAdapter.SetBorder(range, true, true, true, true);

            base.AfterContentWritten();
        }

        #region IFormSettable 成員

        public void OpenForm()
        {
			_form = new DateLineForm();
			_form.Text = this.Name;
			_form.DateTypeName = "預計完成日";
			_form.AllowAllTime = true;
			_form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			_form.ExportClick += new EventHandler(form_ExportClick);
			_form.ShowDialog();
        }

        void form_ExportClick(object sender, EventArgs e)
        {
			_allTime = _form.AllTime;
			this.StartDate = _form.StartDate;
			this.EndDate = _form.EndDate;
            this.Export();
        }

        #endregion
    }
}
