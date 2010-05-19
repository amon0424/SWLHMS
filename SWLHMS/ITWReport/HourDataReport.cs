using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

using Mong.Report;
using Microsoft.Office.Interop.Excel;
using Mong.ReportDataSetTableAdapters;

using DataTable = System.Data.DataTable;

namespace Mong
{
    class HourDataReport : SingleSheetReporter , IFormSettable
    {
        string _worksheetNo;
        DateTime _startDate;
        bool _useDate;
        DateTime _endDate;
		DataTable _table;
		int _columnHeaderRow;

		public HourDataReport(DataTable table)
        {
			_table = table;

			this.UseIndependentApp = true;
			this.HideApp = true;

            this.Name = "工時資料查詢";
			this.AllowUser |= UserType.Manager;
        }

        protected override void WriteHeader()
        {
			

            this.Sheet.Cells[1, 1] = this.Name;
            //if(_useDate)
            //    this.Sheet.Cells[2, 1] = "期間: " + _startDate.ToString("yyyy/MM/dd") + " 至 " + _endDate.ToString("yyyy/MM/dd");

			_columnHeaderRow = 2;

            base.WriteHeader();
        }

		protected override void WriteColumnHeader()
		{
			ReportSourceProfile profile = new ReportSourceProfile(_table);

			profile.AddExportColumn("編號");
			profile.AddExportColumn("借入產線");
			profile.AddExportColumn("員工編號");
			profile.AddExportColumn("員工姓名");
			profile.AddExportColumn("日期");
			profile.AddExportColumn("工作單號");
			if(_table.Columns.Contains("品號"))
				profile.AddExportColumn("品號");
			profile.AddExportColumn("非生產名稱").Name = "非生產";
			profile.AddExportColumn("工時");
			profile.AddExportColumn("數量").Name = "完成";
			if (_table.Columns.Contains("待驗數量"))
				profile.AddExportColumn("待驗數量");
			profile.AddExportColumn("備註");

			this.SheetAdapter.GetRange(1, profile.IndexOf("工作單號") + 1).EntireColumn.NumberFormat = "@";

			this.SheetAdapter.ReportProfile = profile;
			this.SheetAdapter.PasteColumns(_table, _columnHeaderRow, 1);
			base.WriteColumnHeader();
		}

        protected override void WriteContent()
        {
			this.SheetAdapter.PasteDataRows(_table.Select(null, _table.DefaultView.Sort), _columnHeaderRow + 1, 1);
            base.WriteContent();
        }

        protected override void AfterContentWritten()
        {
			ReportSourceProfile profile = this.SheetAdapter.ReportProfile;
			this.SheetAdapter.SetFormat(_columnHeaderRow + 1, profile.IndexOf("編號") + 1, "0");
			

			Range range = this.SheetAdapter.GetUsedRange(_columnHeaderRow + 1);

			this.SheetAdapter.SetBorder(range, XlBordersIndex.xlInsideHorizontal, XlLineStyle.xlDot, XlBorderWeight.xlThin);
			range.Borders[XlBordersIndex.xlInsideHorizontal].Color = -2565928;

			//設定列印格式
			this.Sheet.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape;
			this.Sheet.PageSetup.CenterFooter = "第 &P 頁，共 &N 頁";
			this.Sheet.PageSetup.PrintTitleRows = this.SheetAdapter.GetRange(_columnHeaderRow, 1).EntireRow.get_Address(Missing, Missing, XlReferenceStyle.xlA1, Missing, Missing);
			this.Sheet.PageSetup.Zoom = false;
			this.Sheet.PageSetup.FitToPagesWide = 1;
			this.Sheet.PageSetup.FitToPagesTall = false;

			//調整欄寬
			this.SheetAdapter.GetUsedRange(_columnHeaderRow).Columns.AutoFit();
			this.SheetAdapter.GetRange(1, profile.IndexOf("備註") + 1).ColumnWidth = 24;
			this.SheetAdapter.GetRange(1, profile.IndexOf("備註") + 1).EntireColumn.WrapText = true;
			

			//顯示列印對話框
			PrintDialog printDialog = new PrintDialog();
			if (printDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					this.Workbook.PrintOut(Missing, Missing, printDialog.PrinterSettings.Copies, Missing, printDialog.PrinterSettings.PrinterName, Missing, Missing, Missing);
				}
				catch (Exception) { }
			}

            base.AfterContentWritten();

			this.Application.DisplayAlerts = false;
			this.Workbook.Close(Missing, Missing, Missing);
			//this.Application.Quit();
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
