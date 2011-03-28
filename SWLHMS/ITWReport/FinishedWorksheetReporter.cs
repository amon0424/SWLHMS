using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Microsoft.Office.Interop.Excel;
using Mong.ReportDataSetTableAdapters;

using DataTable = System.Data.DataTable;

namespace Mong.Report
{
    class FinishedWorksheetReporter : SingleSheetReporter, IFormSettable
    {
        protected DataTable _table;
		protected ReportDataSet.FinishedWorksheetReportSourceDataTable _srcTable;
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

        public FinishedWorksheetReporter()
        {
            this.Name = "已完成工作單分析表";
			
        }

        protected override void BeforeExport()
        {
			string lineFilter = string.Empty;
			if(!string.IsNullOrEmpty(_form.Line))
				lineFilter = "產線 = '" + _form.Line + "'";

            FinishedWorksheetReportSourceTableAdapter adapter = new FinishedWorksheetReportSourceTableAdapter();

            //取得基本報表資料
            _srcTable = adapter.GetData(_startDate, _endDate);
			//_srcTable.Columns.Add("退驗數量", typeof(decimal));

            //取得每月工作時數
            Dictionary<DateTime, decimal> workHoursDic = new Dictionary<DateTime, decimal>();
            DateTime minDate = _startDate;
            DateTime maxDate = _endDate;

            object tmpObj = _srcTable.Compute("MIN(日期)",string.Empty);
            if (tmpObj != DBNull.Value)
                minDate = (DateTime)tmpObj;

            tmpObj = _srcTable.Compute("MAX(日期)", string.Empty);
			if (tmpObj != DBNull.Value)
			{
				maxDate = (DateTime)tmpObj;
				maxDate = new DateTime(maxDate.Year, maxDate.Month, DateTime.DaysInMonth(maxDate.Year, maxDate.Month));
			}

            for (DateTime date = minDate; date <= maxDate; date = date.AddMonths(1))
            {
                decimal hours = Global.GetWorkingHours(date.Year, date.Month);
                DateTime key = new DateTime(date.Year, date.Month, 1);
                workHoursDic.Add(key, hours);
            }
            
            //重新運算實際工資
            DateTime curRowMonth = DateTime.MinValue;
            foreach (ReportDataSet.FinishedWorksheetReportSourceRow row in _srcTable)
            {
                if (!row.IsNull("年份"))
                {
                    if (row.年份 != curRowMonth.Year || row.月份 != curRowMonth.Month)
                        curRowMonth = new DateTime(row.年份, row.月份, 1);

                    row.內部工資 = Math.Round(row.內部工資 / workHoursDic[curRowMonth], MidpointRounding.AwayFromZero);
                }
            }

            //重新Group資料
            DataTableHelper dtHelper = new DataTableHelper();
            _table = dtHelper.SelectGroupByInto("ReportTable", _srcTable,
				"產線,實際完成日,工作單號,序號,品號,品名,數量,單位," +
				"Sum(內部工時) 內部工時, Sum(內部工資) 內部工資,外包工時,外包工資,標準工時,單位人工成本,實際總工時,實際總工資," +
				"標準總工時,標準總工資,生產效率,單位標準工資,實際工時,實際工資,工品編號",
				lineFilter, "產線,實際完成日,工作單號,品號,品名,數量,標準工時,單位人工成本,單位標準工資,工品編號");

            //設定欄位
            _table.Columns["單位"].DefaultValue = "KPCS";

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
                    lwTable = lwHelper.GetData(curWorksheetNumber);
                    //seriesNumber = 1;
                }

				//取得退驗
				//row["退驗數量"] = DatabaseSet.GetNGAmount(wsNumber, wpid) / 1000.0f;

				//DataRow[] lwRows = lwTable.Select("工品編號 = " + row["工品編號"]);
				object result = lwTable.Compute("SUM(外包工資)", string.Format("工品編號 = {0}", row["工品編號"].ToString())); 

                //if (lwRows.Length > 0)
				if (result != null && result != DBNull.Value)
                {
                    //decimal laborWage = (decimal)lwRows[0]["外包工資"];
					decimal laborWage = Convert.ToDecimal(result);

                    row["外包工資"] = laborWage;
					row["外包工時"] = laborWage / Settings.HourlyPay;
                }

                //row["序號"] = seriesNumber++;
				row["序號"] = wpid;
            }

            base.BeforeExport();
        }

        protected override void WriteHeader()
        {
            this.Sheet.Cells[1, 1] = this.Name;
            this.Sheet.Cells[2, 1] = "期間: " + _startDate.ToString("yyyy/MM/dd") + " 至 " + _endDate.ToString("yyyy/MM/dd");

            base.WriteHeader();
        }

        protected override void WriteColumnHeader()
        {
            ReportSourceProfile profile = new ReportSourceProfile(_table);
			//profile.ExcludeExportColumn(new List<DataColumn>(new DataColumn[] { _table.Columns["工品編號"] }));
			//foreach (DataColumn column in _table.Columns)
			
			profile.AddExportColumn("產線");
			profile.AddExportColumn("實際完成日");
			profile.AddExportColumn("工作單號");
			profile.AddExportColumn("序號");
			profile.AddExportColumn("品號");
			profile.AddExportColumn("品名");
			//profile.AddExportColumn("退驗數量");
			profile.AddExportColumn("數量");
			profile.AddExportColumn("單位");
			profile.AddExportColumn("內部工時");
			profile.AddExportColumn("內部工資");
			profile.AddExportColumn("外包工時");
			profile.AddExportColumn("外包工資");
			profile.AddExportColumn("實際總工時");
			profile.AddExportColumn("標準總工時");
			profile.AddExportColumn("實際總工資");
			profile.AddExportColumn("標準總工資");
			profile.AddExportColumn("生產效率");
			profile.AddExportColumn("標準工時");
			profile.AddExportColumn("單位人工成本");
			profile.AddExportColumn("單位標準工資");
			profile.AddExportColumn("實際工時");
			profile.AddExportColumn("實際工資");

			profile.ColumnMap[_table.Columns["內部工時"]].Name = "內部實際總工時";
			profile.ColumnMap[_table.Columns["內部工資"]].Name = "內部實際總工資";
			profile.ColumnMap[_table.Columns["外包工資"]].Name = "外包實際總工資";
			profile.ColumnMap[_table.Columns["外包工時"]].Name = "外包實際總工時";
            profile.ColumnMap[_table.Columns["標準工時"]].Name = "單位標準工時\n(Hour/Kpcs)";
            profile.ColumnMap[_table.Columns["單位人工成本"]].Name = "報價時薪\n(NT$/Hour)";
			profile.ColumnMap[_table.Columns["單位標準工資"]].Name = "單位標準工資\n(NT$/Kpcs)";
			profile.ColumnMap[_table.Columns["生產效率"]].Name = "標準總工時/\n實際總工時";
            profile.ColumnMap[_table.Columns["實際總工時"]].Name = "實際總工時\n(內+外)";
            profile.ColumnMap[_table.Columns["實際總工資"]].Name = "實際總工資\n(內+外)";
			profile.ColumnMap[_table.Columns["標準總工資"]].Name = "報價總工資";
			profile.ColumnMap[_table.Columns["實際工時"]].Name = "單位實際工時\n(Hour/Kpcs)";
			profile.ColumnMap[_table.Columns["實際工資"]].Name = "單位實際工資\n(NT$/Kpcs)";

            this.SheetAdapter.ReportProfile = profile;
            this.SheetAdapter.PasteColumns(_table, 3, 1);

			Application.ErrorCheckingOptions.NumberAsText = false;
			this.SheetAdapter.GetRange(4, profile.IndexOf("工作單號") + 1).EntireColumn.NumberFormat = "@";

            base.WriteColumnHeader();
        }

        protected override void WriteContent()
        {
            System.Data.DataTable linesTable = DataTableHelper.SelectDistinct(_table, "產線");

            //建立寫入前置作業
            int writeRow = 4;
            PasteDataRowsOptions options = new PasteDataRowsOptions();
            options.IncludeSummary = false;	//手動控制Summary Row
			options.SummaryColumns.AddRange(new string[] { /*"退驗數量", */"數量"/*, "標準工時", "單位人工成本"*/, "內部工時", "內部工資", "外包工資", "外包工時", "標準總工資", "標準總工時", /*"單位標準工資", "實際工時", "實際工資"*/ });
			options.NoSummaryColumns.AddRange(new string[] { "標準工時", "單位人工成本", "單位標準工資", "實際工時", "實際工資" });

			PasteDataRowEventHandler beforeSummary = new PasteDataRowEventHandler(BeforePasteDataRowSummary);
			//this.SheetAdapter.BeforePasteDataRowSummary += beforeSummary;

			DataTableHelper dtHelper = new DataTableHelper();
			DataTable nonNormalHourTable = dtHelper.SelectGroupByInto("ReportTable", _srcTable,
					"產線, Sum(內部工時) 內部工時, 工時類型",
					null, "產線,實際完成日,工作單號,品號,品名,數量,標準工時,單位人工成本,單位標準工資,工品編號,工時類型");

			//對每個產線
            foreach (DataRow lineRow in linesTable.Rows)
            {
				//NOTICE: 當Select條件修改時也必須修改BeforePasteDataRowSummary內容
                DataRow[] rows = _table.Select("產線 = '" + lineRow["產線"] + "'", "工作單號,序號");

                //寫入內容
				options.IncludeSummary = false;
                options.Row = writeRow;
                options.SummaryPrefix = lineRow["產線"] + "產線小計";
                writeRow = this.SheetAdapter.PasteDataRows(rows, options);

				//寫入異常生產工時,包裝工時
				decimal unusual = 0;
				decimal package = 0;

				// 取得異常生產工時
				object result = nonNormalHourTable.Compute("SUM(內部工時)", "產線 = '" + lineRow["產線"] + "' AND 工時類型=" + (int)HourType.異常生產工時);
				if (result != null && result != DBNull.Value)
					unusual = (decimal)result;

				// 取得包裝工時
				result = nonNormalHourTable.Compute("SUM(內部工時)", "產線 = '" + lineRow["產線"] + "' AND 工時類型=" + (int)HourType.包裝);
				if (result != null && result != DBNull.Value)
					package = (decimal)result;

				DataRow tmpRow = _table.NewRow();
				tmpRow["單位"] = null;
				tmpRow[0] = "異常生產工時";
				tmpRow["實際總工時"] = unusual;
				writeRow = this.SheetAdapter.PasteDataRow(tmpRow, writeRow, options.Column);

				tmpRow[0] = "包裝";
				tmpRow["實際總工時"] = package;
				writeRow = this.SheetAdapter.PasteDataRow(tmpRow, writeRow, options.Column);

				//寫入小計
				options.Row = writeRow;
				writeRow = this.SheetAdapter.PasteSummaryRow(rows, options);

            }
			//this.SheetAdapter.BeforePasteDataRowSummary -= beforeSummary;

			decimal ttlUnusual = 0;
			decimal ttlPackage = 0;

			// 取得異常生產工時
			object tmpResult = nonNormalHourTable.Compute("SUM(內部工時)", "工時類型=" + (int)HourType.異常生產工時);
			if (tmpResult != null && tmpResult != DBNull.Value)
				ttlUnusual = (decimal)tmpResult;

			// 取得包裝工時
			tmpResult = nonNormalHourTable.Compute("SUM(內部工時)", "工時類型=" + (int)HourType.包裝);
			if (tmpResult != null && tmpResult != DBNull.Value)
				ttlPackage = (decimal)tmpResult;

			//寫入總計(不包括異常,包裝)
			DataTable tmpTable = _table.Clone();
			tmpTable.Columns["實際總工時"].Expression = string.Empty;	//實際總工時自己計算

			DataRow totalRow = tmpTable.NewRow();

			foreach (string sumCol in options.SummaryColumns)
			{
				if (!string.IsNullOrEmpty(tmpTable.Columns[sumCol].Expression))
					tmpTable.Columns[sumCol].Expression = string.Empty;

				object o;
				o = _table.Compute("SUM(" + sumCol + ")", string.Empty);
				totalRow[sumCol] = Convert.IsDBNull(o) ? 0 : (decimal)o;
			}
			foreach (string noSumCol in options.NoSummaryColumns)
			{
				tmpTable.Columns[noSumCol].Expression = string.Empty;
				totalRow[noSumCol] = DBNull.Value;
			}

			//實際總工時 - (異常生產工時+包裝)
			object ttlHourObj = _table.Compute("SUM(實際總工時)", string.Empty);
			decimal ttlHour = Convert.IsDBNull(ttlHourObj) ? 0 : (decimal)ttlHourObj;
			totalRow["實際總工時"] = ttlHour - (ttlUnusual + ttlPackage);

			totalRow[0] = "總計";
			tmpTable.Rows.Add(totalRow);
            writeRow = this.SheetAdapter.PasteDataRow(totalRow, writeRow, 1);

			tmpTable = _table.Clone();
			//寫入異常,包裝總計
			tmpTable.Columns[tmpTable.Columns["外包工資"].Ordinal].DataType = typeof(object);

			DataRow abnormalTotalRow = tmpTable.NewRow();
			abnormalTotalRow["單位"] = null;
			abnormalTotalRow[tmpTable.Columns["外包工資"].Ordinal] = "異常生產工時";
			abnormalTotalRow["實際總工時"] = ttlUnusual;
			writeRow = this.SheetAdapter.PasteDataRow(abnormalTotalRow, writeRow, options.Column);

			abnormalTotalRow[tmpTable.Columns["外包工資"].Ordinal] = "包裝";
			abnormalTotalRow["實際總工時"] = ttlPackage;
			writeRow = this.SheetAdapter.PasteDataRow(abnormalTotalRow, writeRow, options.Column);

			//寫入總計(+異常,包裝)
			totalRow = tmpTable.NewRow();
			options.SummaryColumns = new List<string>(new string[] { "實際總工時", "標準總工時" });
			options.NoSummaryColumns = new List<string>(new string[] { "數量", "內部工時", "內部工資", "外包工資", "外包工時", "標準工時", "單位人工成本", "單位標準工資", "實際工時", "實際工資", "標準總工資" });

			foreach (string sumCol in options.SummaryColumns)
			{
				if (!string.IsNullOrEmpty(tmpTable.Columns[sumCol].Expression))
					tmpTable.Columns[sumCol].Expression = string.Empty;

				object o;
				o = _table.Compute("SUM(" + sumCol + ")", string.Empty);
				totalRow[sumCol] = Convert.IsDBNull(o) ? 0 : (decimal)o;
			}
			foreach (string noSumCol in options.NoSummaryColumns)
			{
				tmpTable.Columns[noSumCol].Expression = string.Empty;
				totalRow[noSumCol] = DBNull.Value;
			}

			totalRow[tmpTable.Columns["外包工資"].Ordinal] = "Total";
			totalRow["單位"] = null;
			tmpTable.Rows.Add(totalRow);

			writeRow = this.SheetAdapter.PasteDataRow(totalRow, writeRow, 1);

            base.WriteContent();
        }

        protected override void AfterContentWritten()
        {
			ReportSourceProfile profile = this.SheetAdapter.ReportProfile;

            //設定顯示格式
			//this.SheetAdapter.SetFormat(4, profile.IndexOf("退驗數量") + 1, "[紅色]G/通用格式;G/通用格式;* \"-\"_-");
			//string format = "#,##0.00;#,##0.00;* \"-\"_-";
			//string format = "G/通用格式;G/通用格式;* \"-\"_-";
			
			this.SheetAdapter.SetFormat(4, profile.IndexOf("生產效率") + 1, "0.00%");

			//設定小數位數
			int[] formatCols = new int[]
			{
				profile.IndexOf("標準工時") + 1,
				profile.IndexOf("單位人工成本") + 1,
				profile.IndexOf("標準總工時") + 1,
				profile.IndexOf("標準總工資") + 1,
				profile.IndexOf("單位標準工資") + 1,
				profile.IndexOf("內部工時") + 1,
				profile.IndexOf("內部工資") + 1,
				profile.IndexOf("外包工資") + 1,
				profile.IndexOf("外包工時") + 1,
				profile.IndexOf("實際工時") + 1,
				profile.IndexOf("實際工資") + 1,
				profile.IndexOf("實際總工時") + 1,
				profile.IndexOf("實際總工資") + 1
			};

			foreach (int col in formatCols)
				this.SheetAdapter.SetFormat(4, col, "[=0]* \"-\"_-;G/通用格式");

			this.SheetAdapter.RoundValues(formatCols, 4, 2);

            //移動欄位
			//this.SheetAdapter.GetRange(1, 14, 1, 15).EntireColumn.Cut(Missing);
			//this.SheetAdapter.GetRange(1, 21).EntireColumn.Insert(XlInsertShiftDirection.xlShiftToRight, Missing);

            //設定外觀樣式
            Range range;
            for (int i = 0; i < 4; i++)
				this.SheetAdapter.GetRange(1, profile.IndexOf("內部工時") + 1 + i).ColumnWidth = 15.5;
            for (int i = 0; i < 10; i++)
				this.SheetAdapter.GetRange(1, profile.IndexOf("實際總工時") + 1 + i).ColumnWidth = 13.5;

            //this.SheetAdapter.GetRange(1, _table.Columns.IndexOf("單位人工成本") + 1).ColumnWidth = 15;
			range = this.SheetAdapter.GetRange(3, 1, this.SheetAdapter.UsedRowsCount, profile.IndexOf("單位") + 1);
            range.Columns.AutoFit();

            range = this.SheetAdapter.GetUsedRange(3);
            this.SheetAdapter.SetBorder(range, true, true, true, true);

            base.AfterContentWritten();
        }

		void BeforePasteDataRowSummary(object sender, DataRow[] rows, PasteDataRowsOptions options, ref int writeRow, int col, object args)
		{
			decimal unusual = 0;
			decimal package = 0;
			if (rows.Length > 0)
			{
				DataTable table = rows[0].Table;
				string line = rows[0]["產線"].ToString();

				// 取得異常生產工時
				object result = table.Compute("SUM(內部工時)", "產線 = '" + line + "' AND 工時類型=" + (int)HourType.異常生產工時);
				if (result != null && result != DBNull.Value)
					unusual = (decimal)result;
				
				// 取得包裝工時
				result = table.Compute("SUM(內部工時)", "產線 = '" + line + "' AND 工時類型=" + (int)HourType.包裝);
				if (result != null && result != DBNull.Value)
					package = (decimal)result;

				DataRow tmpRow = table.NewRow();
				tmpRow["單位"] = null;
				tmpRow[0] = "異常生產工時";
				tmpRow["實際總工時"] = unusual;
				writeRow = ((WorksheetAdapter)sender).PasteDataRow(tmpRow, writeRow, col);

				tmpRow[0] = "包裝";
				tmpRow["實際總工時"] = package;
				writeRow = ((WorksheetAdapter)sender).PasteDataRow(tmpRow, writeRow, col);
			}
		}

        #region IFormSettable 成員

        public void OpenForm()
        {
			_form = new DateLineForm();
			_form.Text = this.Name;
			_form.DateTypeName = "實際完成日";
			_form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			_form.ExportClick += new EventHandler(form_ExportClick);
			_form.ShowDialog();
        }

        void form_ExportClick(object sender, EventArgs e)
        {
			DateLineForm form = (DateLineForm)sender;
            this.StartDate = form.StartDate;
            this.EndDate = form.EndDate;
            this.Export();
        }

        #endregion
    }
}
