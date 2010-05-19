using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Office.Interop.Excel;

namespace Mong.Report
{
	class MultiSheetReporter : Reporter
	{
		Worksheet[] _sheets;
		WorksheetAdapter[] _sheetAdapters;

		protected Worksheet[] Sheets
		{
			get { return _sheets; }
			set
			{
				_sheets = value;
				//_sheetAdapter.Worksheet = _sheet;
			}
		}
		protected WorksheetAdapter[] SheetAdapters
		{
			get { return _sheetAdapters; }
			set { _sheetAdapters = value; }
		}

		protected override void BeforeExport()
		{
			Sheets = new Worksheet[this.Workbook.Sheets.Count];
			SheetAdapters = new WorksheetAdapter[Sheets.Length];

			for (int i = 0; i < Sheets.Length; i++)
			{
				this.Sheets[i] = this.Workbook.Worksheets[i+1] as Worksheet;

				this.SheetAdapters[i] = new WorksheetAdapter();
				this.SheetAdapters[i].Worksheet = Sheets[i];
			}

			base.BeforeExport();
		}
	}
}
