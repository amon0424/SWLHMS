using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Office.Interop.Excel;

namespace Mong.Report
{
    class SingleSheetReporter : Reporter
    {
        Worksheet _sheet;
        WorksheetAdapter _sheetAdapter = new WorksheetAdapter();

        protected Worksheet Sheet
        {
            get { return _sheet; }
            set
            {
                _sheet = value;
                _sheetAdapter.Worksheet = _sheet;
            }
        }
        protected WorksheetAdapter SheetAdapter
        {
            get { return _sheetAdapter; }
            set { _sheetAdapter = value; }
        }


        protected override void BeforeExport()
        {
            Sheet = this.Workbook.Sheets[1] as Worksheet;

            base.BeforeExport();
        }
    }
}
