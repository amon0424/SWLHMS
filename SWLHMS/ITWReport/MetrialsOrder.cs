using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

using Microsoft.Office.Interop.Excel;
using Mong.DatabaseSetTableAdapters;

using DataTable = System.Data.DataTable;

namespace Mong.Report
{
    class MaterialsOrder : SingleSheetReporter, IFormSettable
    {
        string _worksheetNo;
        string _contact;
		string _gangerName;

        DataTable _table;
        
        public MaterialsOrder()
        {
            this.Name = "製造部訂料通知單";
			this.AllowUser |= UserType.Manager;
        }

        protected override void BeforeExport()
        {
            // Create table
            CreateReportTable();

            // Set the profile
            ReportSourceProfile profile = new ReportSourceProfile(_table);
            profile.ColumnHeaderHAlign = XlHAlign.xlHAlignCenter;
            profile.ColumnHeaderBold = false;
            profile.ColumnHeaderHGrid = true;
            profile.ColumnHeaderVGrid = true;
            profile.HorizontalGrid = true;
            profile.VerticalGrid = true;

            profile.AddExportColumn("品號", "品　號");
            profile.AddExportColumn("內容", "內　容");
            profile.AddExportColumn("數量", "數　量");
            profile.AddExportColumn("預計完成日");
            profile.AddExportColumn("備註", "備　註");

            this.SheetAdapter.ReportProfile = profile;
            // *****

            // Get data from db
            OleDbConnection conn = DbConnection.Instance;
            ConnectionState oriConnState = conn.State;
            if ((conn.State & ConnectionState.Open) != ConnectionState.Open)
                conn.Open();

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT 品號, 客戶 AS 內容, 數量, 預計完成日 "+
                                "FROM 工作單 AS A INNER JOIN 工作單品號 AS B ON A.單號 = B.單號 WHERE A.單號 = '" + _worksheetNo + "'";
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(_table);

            if (oriConnState == ConnectionState.Closed)
                conn.Close();
            // *****

            base.BeforeExport();
        }

        protected override void WriteHeader()
        {
            int rptWidth = _table.Columns.Count;
            int row = 1;

            DatabaseSet.工作單DataTable wsTable = 工作單TableAdapter.Instance.GetBy單號(_worksheetNo);
            DatabaseSet.工作單Row wsRow = (DatabaseSet.工作單Row)wsTable.Rows[0];

            Range range;
            range = this.SheetAdapter.GetRange(row, 1, row, rptWidth);
            range.MergeCells = true;
            range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            this.SheetAdapter[range] = "安天德百電股份有限公司(ITW Electronic Business Asia Co.,Ltd.)";
            row++;

            range = this.SheetAdapter.GetRange(row, 1, row, rptWidth);
            range.MergeCells = true;
            range.Font.Size = 15;
            range.Font.Bold = true;
            range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            this.SheetAdapter[range] = "製 造 部 訂 料 通 知 單";
            row++;

            range = this.SheetAdapter.GetRange(row, 1, row, rptWidth);
            range.MergeCells = true;
            range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            this.SheetAdapter[range] = "* * * * * * * * * * * * * * * *";
            row++;

			//string line = DatabaseSet.GetLineByWorksheetNo(_worksheetNo);
			//DatabaseSet.產線DataTable lineTable = 產線TableAdapter.Instance.GetDataByLine(line);
			//DatabaseSet.產線Row lineRow = (DatabaseSet.產線Row)lineTable.Rows[0];

            //this.SheetAdapter[row, 1] = "協 力 廠: " + lineRow.代號;
			this.SheetAdapter[row, 1] = "協 力 廠: " + _gangerName;

            range = this.SheetAdapter.GetRange(row, rptWidth - 1);
            range.HorizontalAlignment = XlHAlign.xlHAlignRight;
            this.SheetAdapter[range] = "日期: ";

            range = this.SheetAdapter.GetRange(row, rptWidth);
            range.HorizontalAlignment = XlHAlign.xlHAlignLeft;
            this.SheetAdapter[range] = wsRow.單據日期.ToString("yyyy/MM/dd");
            row++;

            range = this.SheetAdapter.GetRange(row, rptWidth - 1);
            range.HorizontalAlignment = XlHAlign.xlHAlignRight;
            this.SheetAdapter[range] = "編號: ";

            range = this.SheetAdapter.GetRange(row, rptWidth);
            range.NumberFormat = "0";
            range.HorizontalAlignment = XlHAlign.xlHAlignLeft;
            this.SheetAdapter[range] = wsRow.單號;
            row++;

            base.WriteHeader();
        }

        protected override void WriteContent()
        {
            int rptWidth = _table.Columns.Count;
            int writeRow;
            writeRow = this.SheetAdapter.PasteDataTable(_table, 6, 1);

            this.SheetAdapter[writeRow, 1] = "  連 絡 人 : " + _contact;
            this.SheetAdapter[writeRow, rptWidth - 1] = "□管制文件(C)／■非管制文件(U)";
            writeRow++;
            this.SheetAdapter[writeRow, 2] = "產品需符合SS-00259管制";
            this.SheetAdapter[writeRow, rptWidth - 1] = "表單編號 : PD-03-A-00-26";
            base.WriteContent();
        }

        protected override void AfterContentWritten()
        {
            int useRow = this.Sheet.UsedRange.Rows.Count - 3;

            int startRow = 6;
            Range range;
            range = this.SheetAdapter.GetRange(startRow, 1, useRow, 2);
            range.Columns.AutoFit();

            range = this.SheetAdapter.GetRange(startRow, 2);
            if ((double)range.ColumnWidth < 11)
                range.ColumnWidth = 11;

            this.SheetAdapter.GetRange(startRow, 3).ColumnWidth = 12;
            this.SheetAdapter.GetRange(startRow, 4).ColumnWidth = 11;
            this.SheetAdapter.GetRange(startRow, 5).ColumnWidth = 20;

            range = this.SheetAdapter.GetRange(2, 1, this.Sheet.UsedRange.Rows.Count, this.Sheet.UsedRange.Columns.Count);
            this.SheetAdapter.SetBorder(range, XlBorderWeight.xlMedium, true, true, true, true);

			//複製一份
			int writeRow = this.Sheet.UsedRange.Rows.Count + 2;
			range = this.SheetAdapter.GetRange(1, 1, this.Sheet.UsedRange.Rows.Count, this.Sheet.UsedRange.Columns.Count);
			range.Copy(Missing);
			this.SheetAdapter.GetRange(writeRow, 1).Select();
			this.SheetAdapter.Worksheet.Paste(Missing, Missing);

			//設定列印區域
            string s = this.Sheet.Columns.get_Address(true, true, XlReferenceStyle.xlA1, Missing, Missing);
            this.Sheet.PageSetup.PrintArea = this.Sheet.UsedRange.EntireColumn.get_Address(true, true, XlReferenceStyle.xlA1, Missing, Missing);
            this.Sheet.PageSetup.CenterHorizontally = true;

			//插入分頁符號
			//this.SheetAdapter.Worksheet.HPageBreaks.Add(this.SheetAdapter.GetRange(writeRow, 1));
			//this.Application.SendKeys("{ESC}", true);
			this.Application.CutCopyMode = (XlCutCopyMode)0;
            base.AfterContentWritten();
        }

        void CreateReportTable()
        {
            DataColumn column;

            _table = new DataTable();
            _table.Columns.Add(new DataColumn("品號", typeof(string)));
            _table.Columns.Add(new DataColumn("內容", typeof(string)));
            _table.Columns.Add(new DataColumn("數量", typeof(decimal)));
            _table.Columns.Add(new DataColumn("預計完成日", typeof(DateTime)));
            _table.Columns.Add(new DataColumn("備註", typeof(string)));

        }

        #region IFormSettable 成員

        public void OpenForm()
        {
            WorksheetInputForm form = new WorksheetInputForm();
            form.Text = this.Name;
            form.ExportClick += new EventHandler(form_ExportClick);
            form.ShowDialog();
        }

        void form_ExportClick(object sender, EventArgs e)
        {
            WorksheetInputForm form = (WorksheetInputForm)sender;
            if (form.Worksheet == null)
            {
                MessageBox.Show("請選取工作單號");
                return;
            }
            _contact = form.Contact;
			_gangerName = form.GangerName;
            _worksheetNo = form.Worksheet;
            this.Export();
        }

        #endregion
    }
}
