using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Microsoft.Office.Interop.Excel;
using Mong.ReportDataSetTableAdapters;

using DataTable = System.Data.DataTable;

namespace Mong.Report
{
    class UninishedWorksheetReporterLine : UninishedWorksheetReporter
    {
        public UninishedWorksheetReporterLine()
        {
            //this.Name = "未完成工作單明細表-生產線用";
			this.Name = "在製工單明細表-生產線用";
			this.AllowUser |= UserType.Manager | UserType.Ganger;
        }

		protected override void WriteColumnHeader()
		{
			ReportSourceProfile profile = new ReportSourceProfile(_table);

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
			//profile.AddExportColumn("單位人工成本").Name = "系統時薪\n(NT$/Hour)";
			profile.AddExportColumn("總標準工時");
			profile.AddExportColumn("內部工時");
			//profile.AddExportColumn("內部工資");
			profile.AddExportColumn("外包工時");
			//profile.AddExportColumn("外包工資");
			
			profile.AddExportColumn("完成%");
			profile.AddExportColumn("生產效率").Name = "標準總工時/\n實際總工時";
			profile.AddExportColumn("尚需工時").Name = "尚需標準工時";

			this.SheetAdapter.ReportProfile = profile;
			this.SheetAdapter.PasteColumns(_table, 3, 1);

			Application.ErrorCheckingOptions.NumberAsText = false;
			this.SheetAdapter.GetRange(4, profile.IndexOf("工作單號") + 1).EntireColumn.NumberFormat = "@";

		}

        protected override void AfterContentWritten()
        {
            //base.AfterContentWritten();
			
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
				profile.IndexOf("標準工時") + 1,
				profile.IndexOf("內部工時") + 1,
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

			this.SheetAdapter.GetRange(1, profile.IndexOf("標準工時") + 1).ColumnWidth = 12;
			this.SheetAdapter.GetRange(1, profile.IndexOf("生產效率") + 1).ColumnWidth = 12;

			range = this.SheetAdapter.GetUsedRange(3);
			this.SheetAdapter.SetBorder(range, true, true, true, true);
        }
    }
}
