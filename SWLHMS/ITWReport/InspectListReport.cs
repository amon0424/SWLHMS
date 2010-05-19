using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Microsoft.Office.Interop.Excel;
using Mong.ReportDataSetTableAdapters;

using DataTable = System.Data.DataTable;

namespace Mong.Report
{
    class InspectListReport : MultiSheetReporter, IFormSettable
    {
        protected DataTable _table;

		DataTable _groupTable;

		DataTable _statisticTable;

		InspectListReportForm _form;

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

		int _columnHdrRow = 2;

		public InspectListReport()
        {
            this.Name = "產品檢驗報表";
			this.AllowUser |= UserType.Manager | UserType.QA;
        }

        protected override void BeforeExport()
        {
			//InspectListReportTableAdapter adapter = new InspectListReportTableAdapter();

            //取得基本報表資料
			string qcn = _form.QCN;
			string worksheetFrom = _form.WorksheetFrom;
			string worksheetTo = _form.WorksheetTo;
			string partNumber = _form.PartNumber;
			DateTime from = _form.From;
			DateTime to = _form.To;


			_table = ReportDataSet.InspectListReportDataTable.GetData(from, to, partNumber, qcn, worksheetFrom, worksheetTo, 
				_form.InspeceMode == InspeceMode.ByPn ? true : _form.Group, _form.Line);

			//_table.Columns.Add("Remark");
			if (_form.InspeceMode == InspeceMode.ByPn)
			{
				_table.Columns.Add("OK", typeof(int), "IIF(檢驗狀態='OK' AND 送檢次數=1, 1, 0)");
				_table.Columns.Add("ReOK", typeof(int), "IIF(檢驗狀態='OK' AND 送檢次數>1, 1, 0)");
				_table.Columns.Add("Concession", typeof(int), "IIF(檢驗狀態='Concession', 1, 0)");
				_table.Columns.Add("NG", typeof(int), "IIF(檢驗狀態='NG', 1, 0)");
				_table.Columns.Add("OkNum", typeof(int), "IIF(檢驗狀態='OK' or 檢驗狀態='Concession', 檢驗數量, 0)");

				DataTableHelper helper = new DataTableHelper();
				string field = "MAX(檢驗日期) 檢驗日期, 產線, 品號, SUM(檢驗數量) 檢驗數量, 工作單號, 客戶名稱, 總數量, 工品編號, QCN, " +
								"Count(工時資料編號) Total, SUM(OkNum) OkNum, SUM(OK) OK, SUM(Concession) Concession, SUM(ReOK) ReOK, SUM(NG) NG";
				_groupTable = helper.CreateGroupByTable("GroupByPn", _table, field);

				_groupTable.Columns.Add("品質履歷");
				_groupTable.Columns.Add("Remark");

				
				helper.InsertGroupByInto(_groupTable, _table, field, null, "產線, 工作單號, 工品編號, 客戶名稱");

				//填入QC#彙總與品質履歷彙總
				foreach (DataRow grpRow in _groupTable.Rows)
				{
					string worksheet = (string)grpRow["工作單號"];
					int wpid = (int)grpRow["工品編號"];

					DataRow[] rows = _table.Select("工作單號 = '" + worksheet + "' AND 工品編號=" + wpid);
					List<string> qcnList = new List<string>();
					List<string> reasonList = new List<string>();
					foreach (DataRow row in rows)
					{
						string q = row["QCN"] as string;
						if (!string.IsNullOrEmpty(q) && !qcnList.Contains(q))
							qcnList.Add(q);

						string ngreason = row["品質履歷"] as string;
						if (!string.IsNullOrEmpty(ngreason))
						{
							string[] reasons = ngreason.Split('\n');
							foreach (string reason in reasons)
							{
								if(!reasonList.Contains(reason))
									reasonList.Add(reason);
							}
						}
					}

					grpRow["QCN"] = string.Join("\n", qcnList.ToArray());
					grpRow["品質履歷"] = string.Join("\n", reasonList.ToArray());
				}
			}

			if (_form.OutputStatistic)
			{
				_statisticTable = new DataTable();
				_statisticTable.Columns.Add("產線", typeof(string));
				_statisticTable.Columns.Add("入庫總批數", typeof(int));
				_statisticTable.Columns.Add("送檢總次數", typeof(int));
				_statisticTable.Columns.Add("合格率", typeof(double), "IIF(送檢總次數=0, 0, 入庫總批數 / 送檢總次數)");
			}

            base.BeforeExport();
        }

        protected override void WriteHeader()
        {
            this.Sheets[0].Cells[1, 1] = this.Name;

			_columnHdrRow = 2;
			int condNum = 0;

			if (_form.Line != null)
				this.Sheets[0].Cells[_columnHdrRow + condNum++, 1] = "產線: " + _form.Line;

			if (_form.QCN != string.Empty)
				this.Sheets[0].Cells[_columnHdrRow + condNum++, 1] = "QC#: " + _form.QCN;

			if (_form.PartNumber != string.Empty)
				this.Sheets[0].Cells[_columnHdrRow + condNum++, 1] = "料號: " + _form.PartNumber;

			if (_form.WorksheetFrom != string.Empty || _form.WorksheetTo != string.Empty)
				this.Sheets[0].Cells[_columnHdrRow + condNum++, 1] = "工作單號: " + _form.WorksheetFrom + " ~ " + _form.WorksheetTo;
			
			if(_startDate != DateTime.MinValue)
				this.Sheets[0].Cells[_columnHdrRow + condNum++, 1] = "期間: " + _startDate.ToString("yyyy/MM/dd") + " 至 " + _endDate.ToString("yyyy/MM/dd");

			if (condNum > 0)
				this.SheetAdapters[0].GetRange(_columnHdrRow, 1, _columnHdrRow + condNum - 1, 1).Copy(Missing);

			if (_form.OutputStatistic)
			{
				this.Sheets[1].Cells[1, 1] = "品質統計報表";
				if (condNum > 0)
				{
					this.SheetAdapters[1].Worksheet.Select(Missing);
					this.SheetAdapters[1].GetRange(2, 1).Select();
					this.Sheets[1].Paste(Missing, Missing);
				}
			}
			this.Application.CutCopyMode = (XlCutCopyMode)0;
			this.SheetAdapters[0].Worksheet.Select(Missing);
			_columnHdrRow += condNum;
            base.WriteHeader();
        }

        protected override void WriteColumnHeader()
        {
            ReportSourceProfile profile = new ReportSourceProfile();
			profile.VerticalGrid = true;
			profile.ColumnHeaderVGrid = true;
			profile.HorizontalGrid = true;
			this.SheetAdapters[0].ReportProfile = profile;

			if (_form.InspeceMode == InspeceMode.ByPn)
			{
				_columnHdrRow++;

				profile.Table = _groupTable;

				profile.AddExportColumn("檢驗日期").Name = "最後檢驗\n完成日期";
				profile.AddExportColumn("產線");
				profile.AddExportColumn("工作單號");
				profile.AddExportColumn("品號").Name = "料號";
				profile.AddExportColumn("客戶名稱");
				profile.AddExportColumn("總數量").Name = "工作單\n總數量";
				//profile.AddExportColumn("送檢次數");
				profile.AddExportColumn("OkNum").Name = "檢驗OK\n總數量";
				profile.AddExportColumn("Total").Name = "總筆數";
				profile.ColumnMap[_groupTable.Columns["Total"]].MergeSpan = 5;
				profile.ColumnMap[_groupTable.Columns["Total"]].MergeTitle = "QC# 檢驗狀態";

				profile.AddExportColumn("OK").Name = "OK筆數";
				profile.AddExportColumn("ReOK").Name = "重檢OK\n筆數";
				profile.AddExportColumn("Concession").Name = "特採OK\n筆數";
				profile.AddExportColumn("NG").Name = "NG筆數";
				profile.AddExportColumn("QCN").Name = "QC#彙整";
				//profile.AddExportColumn("檢驗狀態");
				profile.AddExportColumn("品質履歷").Name = "品質履歷\n彙整";
				profile.AddExportColumn("Remark");

				this.SheetAdapters[0].PasteColumns(_groupTable, _columnHdrRow, 1);
			}
			else
			{
				profile.Table = _table;

				//profile.ExcludeExportColumn(new List<DataColumn>(
				//    new DataColumn[] { _table.Columns["工時資料編號"], _table.Columns["最後送檢編號"], _table.Columns["最後檢驗紀錄"], _table.Columns["工品編號"] }));
				//profile.ColumnMap[_table.Columns["品號"]].Name = "料號";
				//profile.ColumnMap[_table.Columns["QCN"]].Name = "QC#";

				profile.AddExportColumn("檢驗日期");
				profile.AddExportColumn("產線");
				profile.AddExportColumn("工作單號");
				profile.AddExportColumn("品號").Name = "料號";
				profile.AddExportColumn("客戶名稱");
				profile.AddExportColumn("檢驗數量");
				profile.AddExportColumn("送檢次數");
				profile.AddExportColumn("QCN").Name = "QC#";
				profile.AddExportColumn("檢驗狀態");
				profile.AddExportColumn("品質履歷");
				profile.AddExportColumn("Remark");

				this.SheetAdapters[0].PasteColumns(_table, _columnHdrRow, 1);
			}

			if (_form.OutputStatistic)
			{
				profile = new ReportSourceProfile(_statisticTable);

				profile.AddExportColumn("產線");
				profile.AddExportColumn("入庫總批數").Name = "入庫總批數\n(by QC#)";
				profile.AddExportColumn("送檢總次數");
				profile.AddExportColumn("合格率");

				profile.VerticalGrid = true;
				profile.ColumnHeaderVGrid = true;
				profile.HorizontalGrid = true;

				this.SheetAdapters[1].ReportProfile = profile;
				this.SheetAdapters[1].PasteColumns(_statisticTable, _columnHdrRow, 1);
			}
			
            base.WriteColumnHeader();
        }

        protected override void WriteContent()
        {
			//this.SheetAdapter.PasteDataTable(_table, 3, 1);

			int write = _columnHdrRow + 1;
			

			//List<string> sortElements = new List<string>();

			//if (!string.IsNullOrEmpty(_form.QCN))
			//    sortElements.Add("QCN");
			//if (!string.IsNullOrEmpty(_form.PartNumber))
			//    sortElements.Add("品號");
			//if (!string.IsNullOrEmpty(_form.WorksheetFrom) || !string.IsNullOrEmpty(_form.WorksheetTo))
			//    sortElements.Add("工作單號");

			//sortElements.Add("檢驗日期");

			//DataRow[] rows = _table.Select(null, string.Join(",", sortElements.ToArray()));

			DataRow[] rows;
			int resultCol;

			if (_form.InspeceMode == InspeceMode.ByPn)
			{
				rows = _groupTable.Select(null, _form.SortString);

				foreach (DataRow row in rows)
					write = this.SheetAdapters[0].PasteDataRow(row, write, 1);

			}
			else
			{
				rows = _table.Select(null, _form.SortString);
				resultCol = this.SheetAdapters[0].ReportProfile.IndexOf("檢驗狀態") + 1;
				foreach (DataRow row in rows)
				{
					write = this.SheetAdapters[0].PasteDataRow(row, write, 1);

					string result = row["檢驗狀態"].ToString();
					int color = 65280;
					int fontColor = -16777216;
					if (result == "NG")
					{
						color = 255;
						fontColor = 16316664;
						//fontColor = -1;
					}
					else if (result == "Concession")
					{
						color = 65535;
					}

					Range range = this.SheetAdapters[0].GetRange(write - 1, resultCol);
					range.Interior.Color = color;
					range.Font.Color = fontColor;
					range.Font.Bold = true;
					range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
				}
			}

			//統計資料
			if (_form.OutputStatistic)
			{
				

				DataView view = _table.DefaultView;
				view.Sort = "產線 ASC";
				DataTable disLineTable = view.ToTable(true, "產線");

				foreach (DataRow lineRow in disLineTable.Rows)
				{
					DataRow newRow = _statisticTable.NewRow();

					string line = lineRow[0].ToString();
					int count, num;

					count = (int)_table.Compute("COUNT(產線)", "產線 = '" + line + "' AND 最後檢驗紀錄=True AND 檢驗狀態 <> 'NG'");
					num = Convert.ToInt32(_table.Compute("SUM(送檢次數)", "產線 = '" + line + "'  AND 最後檢驗紀錄=True"));

					newRow["產線"] = line;
					newRow["入庫總批數"] = count;
					newRow["送檢總次數"] = num;

					_statisticTable.Rows.Add(newRow);
				}

				write = _columnHdrRow + 1;

				PasteDataRowsOptions option = new PasteDataRowsOptions();
				option.IncludeSummary = true;
				option.SummaryPrefix = "Total";
				option.SummaryColumns.AddRange(new string[] { "入庫總批數", "送檢總次數" });
				option.Row = write;
				
				this.SheetAdapters[1].PasteDataRows(_statisticTable.Select(), option);
			}

            base.WriteContent();
        }

        protected override void AfterContentWritten()
        {
			ReportSourceProfile profile = this.SheetAdapters[0].ReportProfile;

            //設定顯示格式
			this.SheetAdapters[0].SetFormat(_columnHdrRow, profile.IndexOf("工作單號") + 1, "0");
			if(_form.InspeceMode == InspeceMode.ByQcNo)
				this.SheetAdapters[0].SetFormat(_columnHdrRow, profile.IndexOf("QCN") + 1, "@");

			Range range;
			range = this.SheetAdapters[0].GetUsedRange(_columnHdrRow);
			this.SheetAdapters[0].SetBorder(range, true, true, true, true);

			range = this.SheetAdapters[0].GetRange(_columnHdrRow + 1, 1);
			range.Select();
			this.Application.ActiveWindow.FreezePanes = true;

			//抬頭
			range = this.SheetAdapters[0].GetRange(1, 1, 1, this.SheetAdapters[0].UsedColumnsCount);
			this.SheetAdapters[0].SetBorder(range, false, true, false, false);

			range = this.SheetAdapters[0].GetRange(1, 1);
			range.Font.Size = 18;
			range.Font.Bold = true;

			//欄位抬頭
			if (_form.InspeceMode == InspeceMode.ByPn)
			{
				for (int i = 0; i < profile.Columns.Count; i++)
				{
					ReportColumn rptCol = profile.Columns[i];
					if (rptCol.MergeSpan == 0)
					{
						range = this.SheetAdapters[0].GetRange(_columnHdrRow - 1, rptCol.Index + 1, _columnHdrRow, rptCol.Index + 1);
						range.Merge(Missing);
					}
					else
					{

						range = this.SheetAdapters[0].GetRange(_columnHdrRow - 1, rptCol.Index + 1, _columnHdrRow - 1, rptCol.Index + rptCol.MergeSpan);
						range.Merge(Missing);

						range = this.SheetAdapters[0].GetRange(_columnHdrRow - 1, rptCol.Index + 1, _columnHdrRow - 1, rptCol.Index + 1);
						range.Value2 = rptCol.MergeTitle;
						range.Font.Bold = true;

						i += rptCol.MergeSpan - 1;
					}

				}
				range = this.SheetAdapters[0].GetRange(_columnHdrRow - 1, 1, _columnHdrRow, this.SheetAdapters[0].UsedColumnsCount);
				range.Interior.Color = 13434828;
				//range.AutoFilter(1, Missing, XlAutoFilterOperator.xlAnd, Missing, true);
				range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
				this.SheetAdapters[0].SetBorder(range, true, true, true, true);
				this.SheetAdapters[0].SetBorder(range, XlBordersIndex.xlInsideHorizontal);
				this.SheetAdapters[0].SetBorder(range, XlBordersIndex.xlInsideVertical);
			}
			else
			{
				range = this.SheetAdapters[0].GetRange(_columnHdrRow, 1, _columnHdrRow, this.SheetAdapters[0].UsedColumnsCount);
				range.Interior.Color = 13434828;
				range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
			}

			//產線欄
			range = this.SheetAdapters[0].GetRange(_columnHdrRow + 1, profile.IndexOf("產線") + 1, this.SheetAdapters[0].UsedRowsCount, profile.IndexOf("產線") + 1);
			range.HorizontalAlignment = XlHAlign.xlHAlignCenter;

			//隱藏格線
			this.Application.ActiveWindow.DisplayGridlines = false;

			//顯示總筆數
			range = this.SheetAdapters[0].GetRange(this.SheetAdapters[0].UsedRowsCount + 2, 1);
			int count = _form.InspeceMode == InspeceMode.ByPn ? _groupTable.Rows.Count : _table.Rows.Count;
			range.Value2 = "共 " + count + " 筆";
			range.Font.Bold = true;

			this.Sheets[0].UsedRange.Font.Name = "Arial";

			//品質履歷欄
			if (_table.Rows.Count > 0)
			{
				range = this.SheetAdapters[0].GetRange(_columnHdrRow+1, profile.IndexOf("品質履歷") + 1, this.SheetAdapters[0].UsedRowsCount, profile.IndexOf("品質履歷") + 1);
				range.Font.Color = 255;
				//range.Font.Bold = true;
			}

			// Inser方法會在Excel2003失敗 所以採取迂迴方法達成(??)
			//this.SheetAdapters[0].Worksheet.UsedRange.Cut(Missing);
			//this.SheetAdapters[0].GetRange(1, this.SheetAdapters[0].Worksheet.UsedRange.Columns.Count + 2).Select();
			//this.SheetAdapters[0].Worksheet.Paste(Missing, Missing);

			//((Range)this.Application.Selection).Cut(Missing);
			//this.SheetAdapters[0].GetRange(1, 2).Select();
			//this.SheetAdapters[0].Worksheet.Paste(Missing, Missing);

			//調整欄寬
			range = this.SheetAdapters[0].GetRange(_form.InspeceMode == InspeceMode.ByPn ? _columnHdrRow - 1 : _columnHdrRow, 1, this.SheetAdapters[0].UsedRowsCount, this.SheetAdapters[0].UsedColumnsCount);
			range.Columns.AutoFit();

			if (_form.InspeceMode == InspeceMode.ByPn)
			{
				for (int i = 0; i < 5; i++)
					this.SheetAdapters[0].GetRange(1, profile.IndexOf("Total") + 1 + i).ColumnWidth = 8.5;

				range = this.SheetAdapters[0].GetRange(1, profile.IndexOf("品質履歷") + 1);
				if ((double)range.ColumnWidth < 10)
					range.ColumnWidth = 10;
			}

			//欄位自動篩選
			//range = this.SheetAdapters[0].GetRange(_columnHdrRow, 2, _columnHdrRow, this.SheetAdapters[0].UsedColumnsCount).EntireRow;
			range = this.SheetAdapters[0].GetRange(_columnHdrRow, 1, this.SheetAdapters[0].UsedRowsCount - 2, this.SheetAdapters[0].UsedColumnsCount);
			range.AutoFilter(1, Missing, XlAutoFilterOperator.xlAnd, Missing, true);

			//插入空白行
			this.SheetAdapters[0].GetRange(1, 1).EntireColumn.Insert(XlInsertShiftDirection.xlShiftToRight, XlInsertFormatOrigin.xlFormatFromLeftOrAbove);

			

			////調整欄寬
			//range = this.SheetAdapters[0].GetRange(_form.InspeceMode == InspeceMode.ByPn ? _columnHdrRow - 1 : _columnHdrRow, 1, this.SheetAdapters[0].UsedRowsCount, this.SheetAdapters[0].UsedColumnsCount);
			//range.Columns.AutoFit();

			//if (_form.InspeceMode == InspeceMode.ByPn)
			//{
			//    for (int i = 0; i < 5; i++)
			//        this.SheetAdapters[0].GetRange(1, profile.IndexOf("Total") + 2 + i).ColumnWidth = 8.5;

			//    range = this.SheetAdapters[0].GetRange(1, profile.IndexOf("品質履歷") + 2);
			//    if ((double)range.ColumnWidth < 10)
			//        range.ColumnWidth = 10;
			//}

			////欄位自動篩選
			////range = this.SheetAdapters[0].GetRange(_columnHdrRow, 2, _columnHdrRow, this.SheetAdapters[0].UsedColumnsCount).EntireRow;
			//range = this.SheetAdapters[0].GetRange(_columnHdrRow, 1, this.SheetAdapters[0].UsedRowsCount - 2, this.SheetAdapters[0].UsedColumnsCount);
			//range.AutoFilter(1, Missing, XlAutoFilterOperator.xlAnd, Missing, true);

			this.SheetAdapters[0].GetRange(1, 1).EntireColumn.ColumnWidth = 4;
			this.SheetAdapters[0].GetRange(_columnHdrRow, 1).EntireRow.RowHeight = 40;

			if (_form.OutputStatistic)
			{
				profile = this.SheetAdapters[1].ReportProfile;

				//抬頭
				range = this.SheetAdapters[1].GetRange(1, 1).EntireRow;
				range.Font.Size = 18;
				range.Font.Bold = true;

				//欄位抬頭
				range = this.SheetAdapters[1].GetRange(_columnHdrRow, 1, _columnHdrRow, this.SheetAdapters[1].UsedColumnsCount);
				range.Interior.Color = 16777164;
				//range.AutoFilter(1, Missing, XlAutoFilterOperator.xlAnd, Missing, true);
				range.HorizontalAlignment = XlHAlign.xlHAlignCenter;

				//產線欄
				range = this.SheetAdapters[1].GetRange(_columnHdrRow + 1, profile.IndexOf("產線") + 1, this.SheetAdapters[1].UsedRowsCount, profile.IndexOf("產線") + 1);
				range.HorizontalAlignment = XlHAlign.xlHAlignCenter;

				//字體顏色
				range = this.SheetAdapters[1].GetRange(_columnHdrRow, 1, this.SheetAdapters[1].UsedRowsCount - 1, this.SheetAdapters[1].UsedColumnsCount);
				range.Font.Color = 16711680;

				//總和行
				if (_table.Rows.Count > 0)
				{
					range = this.SheetAdapters[1].GetRange(this.SheetAdapters[1].UsedRowsCount, 1, this.SheetAdapters[1].UsedRowsCount, this.SheetAdapters[1].UsedColumnsCount);
					range.Font.Bold = true;
					range.Font.Color = 255;
					range.Interior.Color = 65535;
				}

				//資料格式
				this.SheetAdapters[1].SetFormat(_columnHdrRow, profile.IndexOf("合格率") + 1, "0.00%");

				this.Sheets[1].UsedRange.Font.Name = "Arial";

				

				// Inser方法會在Excel2003失敗 所以採取迂迴方法達成
				//this.SheetAdapters[1].Worksheet.Select(Missing);
				//this.SheetAdapters[1].Worksheet.UsedRange.Cut(Missing);
				//this.SheetAdapters[1].GetRange(1, this.SheetAdapters[1].Worksheet.UsedRange.Columns.Count + 2).Select();
				//this.SheetAdapters[1].Worksheet.Paste(Missing, Missing);

				//((Range)this.Application.Selection).Cut(Missing);
				//this.SheetAdapters[1].GetRange(1, 2).Select();
				//this.SheetAdapters[1].Worksheet.Paste(Missing, Missing);

				

				//欄位自動篩選
				range = this.SheetAdapters[1].GetRange(_columnHdrRow, 1, this.SheetAdapters[1].UsedRowsCount - 1, this.SheetAdapters[1].UsedColumnsCount);
				//range = this.SheetAdapters[1].GetRange(_columnHdrRow, 2, _columnHdrRow, this.SheetAdapters[1].UsedColumnsCount);
				range.AutoFilter(1, Missing, XlAutoFilterOperator.xlAnd, Missing, true);

				//調整欄寬
				range = this.SheetAdapters[1].GetRange(_columnHdrRow, 1, this.SheetAdapters[1].UsedRowsCount, this.SheetAdapters[1].UsedColumnsCount);
				range.Columns.AutoFit();

				this.SheetAdapters[1].GetRange(1, 1).EntireColumn.Insert(XlInsertShiftDirection.xlShiftToRight, XlInsertFormatOrigin.xlFormatFromLeftOrAbove);
				this.SheetAdapters[1].GetRange(1, 1).EntireColumn.ColumnWidth = 4;

				this.SheetAdapters[1].Worksheet.Select(Missing);
				this.SheetAdapters[1].Worksheet.Name = "Statistic";

				this.Application.ActiveWindow.DisplayGridlines = false;
			}

			this.SheetAdapters[0].Worksheet.Select(Missing);
			this.SheetAdapters[0].Worksheet.Name = "Report";

            base.AfterContentWritten();
        }

        #region IFormSettable 成員

        public void OpenForm()
        {
			_form = new InspectListReportForm();
			//form.Text = this.Name;
			//form.DateTypeName = "日期";
			_form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			_form.ExportClick += new EventHandler(form_ExportClick);
			_form.ShowDialog();
        }

        void form_ExportClick(object sender, EventArgs e)
        {
			this.StartDate = _form.From;
			this.EndDate = _form.To;

			this.SheetsInNewWorkbook = _form.OutputStatistic ? 2 : 1;

            this.Export();
        }

        #endregion
    }
}
