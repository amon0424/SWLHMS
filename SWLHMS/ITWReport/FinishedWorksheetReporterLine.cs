using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Microsoft.Office.Interop.Excel;
using Mong.ReportDataSetTableAdapters;

using DataTable = System.Data.DataTable;

namespace Mong.Report
{
    class FinishedWorksheetReporterLine : FinishedWorksheetReporter
    {
        public FinishedWorksheetReporterLine()
        {
            this.Name = "已完成工作單分析表-生產線用";

			this.AllowUser |= UserType.Manager | UserType.Ganger;
        }

		protected override void WriteColumnHeader()
		{
			ReportSourceProfile profile = new ReportSourceProfile(_table);

			profile.AddExportColumn("產線");
			profile.AddExportColumn("實際完成日");
			profile.AddExportColumn("工作單號");
			profile.AddExportColumn("序號");
			profile.AddExportColumn("品號");
			profile.AddExportColumn("品名");
			//profile.AddExportColumn("退驗數量");
			profile.AddExportColumn("數量");
			profile.AddExportColumn("單位");
			profile.AddExportColumn("內部工時").Name = "內部實際總工時";
			profile.AddExportColumn("實際總工時").Name = "實際總工時\n(內+外)";
			profile.AddExportColumn("標準總工時");
			profile.AddExportColumn("標準總工資");
			profile.AddExportColumn("生產效率").Name = "標準總工時/\n實際總工時";
			profile.AddExportColumn("標準工時").Name = "單位標準工時\n(Hour/Kpcs)";
			profile.AddExportColumn("實際工時").Name = "單位實際工時\n(Hour/Kpcs)";

			this.SheetAdapter.ReportProfile = profile;
			this.SheetAdapter.PasteColumns(_table, 3, 1);

			Application.ErrorCheckingOptions.NumberAsText = false;
			this.SheetAdapter.GetRange(4, profile.IndexOf("工作單號") + 1).EntireColumn.NumberFormat = "@";
		}

        protected override void AfterContentWritten()
        {
			//base.AfterContentWritten();

			ReportSourceProfile profile = this.SheetAdapter.ReportProfile;

			//this.SheetAdapter.SetFormat(4, profile.IndexOf("退驗數量") + 1, "[紅色]G/通用格式;G/通用格式;* \"-\"_-");
			//this.SheetAdapter.SetFormat(4, profile.IndexOf("工作單號") + 1, "0");
			this.SheetAdapter.SetFormat(4, profile.IndexOf("生產效率") + 1, "0.00%");


			//設定小數位數
			int[] formatCols = new int[]
			{
				profile.IndexOf("標準工時") + 1,
				profile.IndexOf("內部工時") + 1,
				profile.IndexOf("實際工時") + 1,
				profile.IndexOf("實際總工時") + 1,
				profile.IndexOf("標準總工時") + 1,
				profile.IndexOf("標準總工資") + 1
			};

			foreach (int col in formatCols)
				this.SheetAdapter.SetFormat(4, col, "[=0]* \"-\"_-;G/通用格式");

			this.SheetAdapter.RoundValues(formatCols, 4, 2);

			Range range;

			range = this.SheetAdapter.GetRange(3, 1, this.SheetAdapter.UsedRowsCount, _table.Columns.IndexOf("內部工時") + 1);
			range.Columns.AutoFit();

			for (int i = 0; i < 6; i++)
				this.SheetAdapter.GetRange(1, profile.IndexOf("實際總工時") + i + 1).ColumnWidth = 13.5;

			range = this.SheetAdapter.GetUsedRange(3);
			this.SheetAdapter.SetBorder(range, true, true, true, true);
		}
    }
}
