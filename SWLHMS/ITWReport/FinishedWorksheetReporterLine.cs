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
            this.Name = "�w�����u�@����R��-�Ͳ��u��";

			this.AllowUser |= UserType.Manager | UserType.Ganger;
        }

		protected override void WriteColumnHeader()
		{
			ReportSourceProfile profile = new ReportSourceProfile(_table);

			profile.AddExportColumn("���u");
			profile.AddExportColumn("��ڧ�����");
			profile.AddExportColumn("�u�@�渹");
			profile.AddExportColumn("�Ǹ�");
			profile.AddExportColumn("�~��");
			profile.AddExportColumn("�~�W");
			//profile.AddExportColumn("�h��ƶq");
			profile.AddExportColumn("�ƶq");
			profile.AddExportColumn("���");
			profile.AddExportColumn("�����u��").Name = "��������`�u��";
			profile.AddExportColumn("����`�u��").Name = "����`�u��\n(��+�~)";
			profile.AddExportColumn("�з��`�u��");
			profile.AddExportColumn("�з��`�u��");
			profile.AddExportColumn("�Ͳ��Ĳv").Name = "�з��`�u��/\n����`�u��";
			profile.AddExportColumn("�зǤu��").Name = "���зǤu��\n(Hour/Kpcs)";
			profile.AddExportColumn("��ڤu��").Name = "����ڤu��\n(Hour/Kpcs)";

			this.SheetAdapter.ReportProfile = profile;
			this.SheetAdapter.PasteColumns(_table, 3, 1);

			Application.ErrorCheckingOptions.NumberAsText = false;
			this.SheetAdapter.GetRange(4, profile.IndexOf("�u�@�渹") + 1).EntireColumn.NumberFormat = "@";
		}

        protected override void AfterContentWritten()
        {
			//base.AfterContentWritten();

			ReportSourceProfile profile = this.SheetAdapter.ReportProfile;

			//this.SheetAdapter.SetFormat(4, profile.IndexOf("�h��ƶq") + 1, "[����]G/�q�ή榡;G/�q�ή榡;* \"-\"_-");
			//this.SheetAdapter.SetFormat(4, profile.IndexOf("�u�@�渹") + 1, "0");
			this.SheetAdapter.SetFormat(4, profile.IndexOf("�Ͳ��Ĳv") + 1, "0.00%");


			//�]�w�p�Ʀ��
			int[] formatCols = new int[]
			{
				profile.IndexOf("�зǤu��") + 1,
				profile.IndexOf("�����u��") + 1,
				profile.IndexOf("��ڤu��") + 1,
				profile.IndexOf("����`�u��") + 1,
				profile.IndexOf("�з��`�u��") + 1,
				profile.IndexOf("�з��`�u��") + 1
			};

			foreach (int col in formatCols)
				this.SheetAdapter.SetFormat(4, col, "[=0]* \"-\"_-;G/�q�ή榡");

			this.SheetAdapter.RoundValues(formatCols, 4, 2);

			Range range;

			range = this.SheetAdapter.GetRange(3, 1, this.SheetAdapter.UsedRowsCount, _table.Columns.IndexOf("�����u��") + 1);
			range.Columns.AutoFit();

			for (int i = 0; i < 6; i++)
				this.SheetAdapter.GetRange(1, profile.IndexOf("����`�u��") + i + 1).ColumnWidth = 13.5;

			range = this.SheetAdapter.GetUsedRange(3);
			this.SheetAdapter.SetBorder(range, true, true, true, true);
		}
    }
}
