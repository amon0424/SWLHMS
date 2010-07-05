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
    class LaborHourDetailReporter : SingleSheetReporter, IFormSettable
    {
        DataTable _table;

        DateTime _startDate = DateTime.MinValue;
        DateTime _endDate = DateTime.MaxValue;

        Dictionary<int, string> _npDic;

        public Dictionary<int, string> NpDic
        {
            get
            {
				LoadNP();

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

        public LaborHourDetailReporter()
        {
            this.Name = "產線工時明細表";
        }

		void LoadNP()
		{
			if (_npDic == null)
				_npDic = new Dictionary<int, string>();

			_npDic.Clear();
			DatabaseSet.非生產Row[] rows = (DatabaseSet.非生產Row[])DatabaseSet.非生產Table.Select(null, "編號");
			foreach (DatabaseSet.非生產Row row in rows)
			{
				if (row.編號 != -1)
					_npDic.Add(row.編號, "np" + row.名稱);
			}
		}

        protected override void BeforeExport()
        {
			LoadNP();

            LineLaborHourReportSourceTableAdapter adapter = new LineLaborHourReportSourceTableAdapter();

            //取得基本報表資料
            ReportDataSet.LineLaborHourReportSourceDataTable srcTable = adapter.GetData(_startDate, _endDate);

            //建立報表_table
            CreateReportTable();

            //取得指定日期範圍內的工作單號
            //OleDbCommand cmd = new OleDbCommand();
            //cmd.CommandText = "SELECT DISTINCT(單號) FROM 工作單 WHERE 單據日期 > #" + _startDate.ToString("yyyy/MM/dd") + "# AND 單據日期 < #" + _endDate.ToString("yyyy/MM/dd") + "#";
            //cmd.Connection = adapter.Connection;
            
            //DataTable wsNumTable = new DataTable();
            //wsNumTable.Columns.Add(new DataColumn("單號", typeof(string)));
            
            //OleDbDataAdapter wsNumAdapter = new OleDbDataAdapter();
            //wsNumAdapter.SelectCommand = cmd;
            //wsNumAdapter.Fill(wsNumTable);

            //List<string> wsNumList = new List<string>();
            //foreach (DataRow row in wsNumTable.Rows)
            //    wsNumList.Add(row["單號"].ToString());

            

            //建立分組table(產線,員工)
            DataTable groupTable = DataTableHelper.SelectDistinct(srcTable, "產線", "借入產線", "員工姓名", "日期");


			/* 1.08.4 
			//取得LaborWage資料
			LaborWageHelper lwHelper = new LaborWageHelper();
			LaborWage員工工時Table lwTable = lwHelper.GetDataByDate(_startDate, _endDate);
			DataColumn col = new DataColumn("已處理", typeof(bool));
			col.DefaultValue = false;
			lwTable.Columns.Add(col);

            //Union lw table
            foreach (DataRow r in lwTable.Rows)
            {
                DateTime date = (DateTime)r["日期"];
                string name = r["員工姓名"].ToString();

                DataRow[] rs = groupTable.Select("借入產線 IS NULL AND 員工姓名 = '" + name + "' AND 日期 = #" + date.ToString("yyyy/MM/dd") + "#");
                if (rs.Length == 0)
                {

                    DataRow[] laborRow = DatabaseSet.員工Table.Select("姓名 ='" + name + "'");
                    if (laborRow.Length != 0)
                    {
                        DataRow nr = groupTable.NewRow();
                        nr["產線"] = laborRow[0]["產線"];
                        nr["員工姓名"] = name;
                        nr["日期"] = date;
                        groupTable.Rows.Add(nr);
                    }
                }
            }
			*/

            //Re order
            groupTable.DefaultView.Sort = "產線, 借入產線, 員工姓名, 日期";
            groupTable = groupTable.DefaultView.ToTable();

            //對每個分組進行數據填入
            foreach (DataRow groupRow in groupTable.Rows)
            {
                string selFilter = "產線='" + groupRow["產線"] + "' AND " + 
                                   "員工姓名 = '" + groupRow["員工姓名"] + "' AND " +
                                   "日期 = #" + ((DateTime)groupRow["日期"]).ToString("yyyy/MM/dd") + "#";
                
                DataRow newRow = _table.NewRow();

                if (groupRow.IsNull("借入產線"))
                {
                    newRow["產線"] = groupRow["產線"];
                    selFilter += " AND 借入產線 IS NULL ";
                }
                else
                {
                    newRow["產線"] = groupRow["借入產線"];
                    newRow["借入"] = groupRow["產線"];
                    selFilter += " AND 借入產線 = '" + groupRow["借入產線"] + "'";
                }

                decimal pHour = 0, npHour = 0;
                DataRow[] rows = srcTable.Select(selFilter);

                //對屬於該分組的Row進行填入
                foreach (DataRow srcRow in rows)
                {
                    int np = (int)srcRow["非生產編號"];
                    decimal hour = (decimal)srcRow["工時"];

                    //為生產工時
                    if (np == -1)
                    {
                        pHour += hour;
                    }
                    else
                    {
                        npHour += hour;
                        newRow[NpDic[np]] = (decimal)newRow[NpDic[np]] + hour;
                    }
                }
                decimal ttlHour = pHour + npHour;

                newRow["日期"] = groupRow["日期"];
                newRow["生產工時"] = pHour;
                newRow["員工名稱"] = groupRow["員工姓名"];

                // Process labor wage data
                DateTime date = ((DateTime)newRow["日期"]);

                //// Check whether each data which date lower than current processed are processed
                //DataRow[] unprocessedRows = lwTable.Select("員工姓名 = '" + groupRow["員工姓名"].ToString() + "' AND " +
                //    "日期 < #" + date.ToString("yyyy/MM/dd") + "# AND " +
                //    "已處理 = FALSE");
                //// Process those have not be processed
                //if (unprocessedRows.Length > 0)
                //{
                //    foreach (DataRow row in unprocessedRows)
                //    {
                //        DataRow r = _table.NewRow();
                //        foreach (DataColumn c in _table.Columns)
                //            r[c] = newRow[c];
                //        r["外包工時"] = row["工時"];
                //    }
                //}
                //// *****

				/* 1.08.4
                DataRow[] lwRows = lwTable.Select(
                    "員工姓名 = '" + groupRow["員工姓名"].ToString() + "' AND " +
                    "日期 = #" + date.ToString("yyyy/MM/dd") + "#");

                if (lwRows.Length > 0)
                {
                    newRow["外包工時"] = lwRows[0]["工時"];
                    lwRows[0]["已處理"] = true;
                }
				*/

                // *****
                _table.Rows.Add(newRow);
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
            // Create profile
            ReportSourceProfile profile = new ReportSourceProfile(_table);
            List<DataColumn> exclude = new List<DataColumn>();
            exclude.Add(_table.Columns["借入"]);
            profile.ExcludeExportColumn(exclude);
            this.SheetAdapter.ReportProfile = profile;
            // *****

            this.SheetAdapter.PasteColumns(_table, 3, 1);

            base.WriteColumnHeader();
        }

        protected override void WriteContent()
        {
            DataTable linesTable = DataTableHelper.SelectDistinct(_table, "產線");

            //建立寫入前置作業
            int writeRow = 4;
            PasteDataRowsOptions options = new PasteDataRowsOptions();
            options.IncludeSummary = true;
			/* 1.08.4
            options.SummaryColumns.AddRange(new string[] { "生產工時", "外包工時" }); */
			options.SummaryColumns.AddRange(new string[] { "生產工時"});
            options.ExcludeColumns.Add("借入");

			//string[] npCols = new string[NpDic.Count];
			//NpDic.Values.CopyTo(npCols, 0);
			List<string> npColList = new List<string>(NpDic.Values);
			//npColList.Remove("np請假");
			options.SummaryColumns.AddRange(npColList);

            //對每個產線
            foreach (DataRow lineRow in linesTable.Rows)
            {
                DataRow[] rows = _table.Select("產線 = '" + lineRow["產線"] + "'", "員工名稱");

                //寫入內容
                options.Row = writeRow;
                options.SummaryPrefix = lineRow["產線"] + "產線小計";

                foreach (DataRow row in rows)
                {
                    if (!row.IsNull("借入"))
                        row["產線"] = "由" + row["借入"] + "借入";
                }

                writeRow = this.SheetAdapter.PasteDataRows(rows, options);
            }

            //寫入總計
            DataRow totalRow = _table.NewRow();
            totalRow[0] = "總計";
            foreach (string sumCol in options.SummaryColumns)
            {
                object o;
                o = _table.Compute("SUM([" + sumCol + "])", string.Empty);
                totalRow[sumCol] = Convert.IsDBNull(o) ? 0 : (decimal)o;
            }
            _table.Rows.Add(totalRow);

            writeRow = this.SheetAdapter.PasteDataRow(totalRow, writeRow, 1);

            //設定顯示格式
			foreach (string npCol in NpDic.Values)
                this.SheetAdapter.SetFormat(4, _table.Columns.IndexOf(npCol) + 1, "G/通用格式;G/通用格式;* \"-\"_-");

            this.SheetAdapter.SetFormat(4, _table.Columns.IndexOf("生產工時") + 1, "G/通用格式;G/通用格式;* \"-\"_-");
            this.SheetAdapter.SetFormat(4, _table.Columns.IndexOf("非生產TTL") + 1, "G/通用格式;G/通用格式;* \"-\"_-");
            this.SheetAdapter.SetFormat(4, _table.Columns.IndexOf("生產%") + 1, "0.00%");
            this.SheetAdapter.SetFormat(4, _table.Columns.IndexOf("非生產%") + 1, "0.00%");
            //this.SheetAdapter.SetFormat(4, _table.Columns.IndexOf("外包工時") + 1, "#,##0.00;#,##0.00;* \"-\"_-");

            base.WriteContent();
        }

        protected override void AfterContentWritten()
        {
            //設定外觀樣式
            Range reportBodyRange = this.SheetAdapter.GetUsedRange(3);
            reportBodyRange.Columns.AutoFit();
            this.SheetAdapter.SetBorder(reportBodyRange, XlLineStyle.xlContinuous, XlBorderWeight.xlThin, true, true, true, true);

            base.AfterContentWritten();
        }

        void CreateReportTable()
        {
            _table = new DataTable();

            _table.Columns.Add(new DataColumn("產線", typeof(string)));
            _table.Columns.Add(new DataColumn("員工名稱", typeof(string)));
            _table.Columns.Add(new DataColumn("日期", typeof(DateTime)));


            DataColumn col生產工時 = new DataColumn("生產工時", typeof(decimal));
            col生產工時.DefaultValue = 0;
            _table.Columns.Add(col生產工時);

            DataColumn col生產 = new DataColumn("生產%", typeof(double));
            _table.Columns.Add(col生產);

            //取得非生產項目
            foreach (string npCol in NpDic.Values)
            {
				//if (npCol == "np請假")
				//	continue;

                DataColumn col = new DataColumn(npCol, typeof(decimal));
				col.Caption = npCol.Substring(2);
                col.DefaultValue = 0;
                _table.Columns.Add(col);
            }

			List<string> npColList = new List<string>(NpDic.Values);
			npColList.Remove("np請假");
			for (int i = 0; i < npColList.Count; i++)
				npColList[i] = "[" + npColList[i] + "]";

			_table.Columns.Add(new DataColumn("非生產TTL", typeof(decimal), string.Join("+", npColList.ToArray())));

            col生產.Expression = "IIF(生產工時 + 非生產TTL = 0,0,生產工時/(生產工時 + 非生產TTL))";

            _table.Columns.Add(new DataColumn("非生產%", typeof(double), "IIF(生產工時 + 非生產TTL = 0,0,非生產TTL/(生產工時 + 非生產TTL))"));

			if(_table.Columns.Contains("np請假"))
				_table.Columns["np請假"].SetOrdinal(_table.Columns.Count - 1);

			/* 1.08.4
            DataColumn col外包工時 = new DataColumn("外包工時", typeof(decimal));
            col外包工時.DefaultValue = 0;
            _table.Columns.Add(col外包工時); 
			 */

            _table.Columns.Add(new DataColumn("借入", typeof(string)));
        }

        #region IFormSettable 成員

        public void OpenForm()
        {
            DateForm form = new DateForm();
            form.Text = this.Name;
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
