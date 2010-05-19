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
            this.Name = "���~�������";
			this.AllowUser |= UserType.Manager | UserType.QA;
        }

        protected override void BeforeExport()
        {
			//InspectListReportTableAdapter adapter = new InspectListReportTableAdapter();

            //���o�򥻳�����
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
				_table.Columns.Add("OK", typeof(int), "IIF(���窬�A='OK' AND �e�˦���=1, 1, 0)");
				_table.Columns.Add("ReOK", typeof(int), "IIF(���窬�A='OK' AND �e�˦���>1, 1, 0)");
				_table.Columns.Add("Concession", typeof(int), "IIF(���窬�A='Concession', 1, 0)");
				_table.Columns.Add("NG", typeof(int), "IIF(���窬�A='NG', 1, 0)");
				_table.Columns.Add("OkNum", typeof(int), "IIF(���窬�A='OK' or ���窬�A='Concession', ����ƶq, 0)");

				DataTableHelper helper = new DataTableHelper();
				string field = "MAX(������) ������, ���u, �~��, SUM(����ƶq) ����ƶq, �u�@�渹, �Ȥ�W��, �`�ƶq, �u�~�s��, QCN, " +
								"Count(�u�ɸ�ƽs��) Total, SUM(OkNum) OkNum, SUM(OK) OK, SUM(Concession) Concession, SUM(ReOK) ReOK, SUM(NG) NG";
				_groupTable = helper.CreateGroupByTable("GroupByPn", _table, field);

				_groupTable.Columns.Add("�~��i��");
				_groupTable.Columns.Add("Remark");

				
				helper.InsertGroupByInto(_groupTable, _table, field, null, "���u, �u�@�渹, �u�~�s��, �Ȥ�W��");

				//��JQC#�J�`�P�~��i���J�`
				foreach (DataRow grpRow in _groupTable.Rows)
				{
					string worksheet = (string)grpRow["�u�@�渹"];
					int wpid = (int)grpRow["�u�~�s��"];

					DataRow[] rows = _table.Select("�u�@�渹 = '" + worksheet + "' AND �u�~�s��=" + wpid);
					List<string> qcnList = new List<string>();
					List<string> reasonList = new List<string>();
					foreach (DataRow row in rows)
					{
						string q = row["QCN"] as string;
						if (!string.IsNullOrEmpty(q) && !qcnList.Contains(q))
							qcnList.Add(q);

						string ngreason = row["�~��i��"] as string;
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
					grpRow["�~��i��"] = string.Join("\n", reasonList.ToArray());
				}
			}

			if (_form.OutputStatistic)
			{
				_statisticTable = new DataTable();
				_statisticTable.Columns.Add("���u", typeof(string));
				_statisticTable.Columns.Add("�J�w�`���", typeof(int));
				_statisticTable.Columns.Add("�e���`����", typeof(int));
				_statisticTable.Columns.Add("�X��v", typeof(double), "IIF(�e���`����=0, 0, �J�w�`��� / �e���`����)");
			}

            base.BeforeExport();
        }

        protected override void WriteHeader()
        {
            this.Sheets[0].Cells[1, 1] = this.Name;

			_columnHdrRow = 2;
			int condNum = 0;

			if (_form.Line != null)
				this.Sheets[0].Cells[_columnHdrRow + condNum++, 1] = "���u: " + _form.Line;

			if (_form.QCN != string.Empty)
				this.Sheets[0].Cells[_columnHdrRow + condNum++, 1] = "QC#: " + _form.QCN;

			if (_form.PartNumber != string.Empty)
				this.Sheets[0].Cells[_columnHdrRow + condNum++, 1] = "�Ƹ�: " + _form.PartNumber;

			if (_form.WorksheetFrom != string.Empty || _form.WorksheetTo != string.Empty)
				this.Sheets[0].Cells[_columnHdrRow + condNum++, 1] = "�u�@�渹: " + _form.WorksheetFrom + " ~ " + _form.WorksheetTo;
			
			if(_startDate != DateTime.MinValue)
				this.Sheets[0].Cells[_columnHdrRow + condNum++, 1] = "����: " + _startDate.ToString("yyyy/MM/dd") + " �� " + _endDate.ToString("yyyy/MM/dd");

			if (condNum > 0)
				this.SheetAdapters[0].GetRange(_columnHdrRow, 1, _columnHdrRow + condNum - 1, 1).Copy(Missing);

			if (_form.OutputStatistic)
			{
				this.Sheets[1].Cells[1, 1] = "�~��έp����";
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

				profile.AddExportColumn("������").Name = "�̫�����\n�������";
				profile.AddExportColumn("���u");
				profile.AddExportColumn("�u�@�渹");
				profile.AddExportColumn("�~��").Name = "�Ƹ�";
				profile.AddExportColumn("�Ȥ�W��");
				profile.AddExportColumn("�`�ƶq").Name = "�u�@��\n�`�ƶq";
				//profile.AddExportColumn("�e�˦���");
				profile.AddExportColumn("OkNum").Name = "����OK\n�`�ƶq";
				profile.AddExportColumn("Total").Name = "�`����";
				profile.ColumnMap[_groupTable.Columns["Total"]].MergeSpan = 5;
				profile.ColumnMap[_groupTable.Columns["Total"]].MergeTitle = "QC# ���窬�A";

				profile.AddExportColumn("OK").Name = "OK����";
				profile.AddExportColumn("ReOK").Name = "����OK\n����";
				profile.AddExportColumn("Concession").Name = "�S��OK\n����";
				profile.AddExportColumn("NG").Name = "NG����";
				profile.AddExportColumn("QCN").Name = "QC#�J��";
				//profile.AddExportColumn("���窬�A");
				profile.AddExportColumn("�~��i��").Name = "�~��i��\n�J��";
				profile.AddExportColumn("Remark");

				this.SheetAdapters[0].PasteColumns(_groupTable, _columnHdrRow, 1);
			}
			else
			{
				profile.Table = _table;

				//profile.ExcludeExportColumn(new List<DataColumn>(
				//    new DataColumn[] { _table.Columns["�u�ɸ�ƽs��"], _table.Columns["�̫�e�˽s��"], _table.Columns["�̫��������"], _table.Columns["�u�~�s��"] }));
				//profile.ColumnMap[_table.Columns["�~��"]].Name = "�Ƹ�";
				//profile.ColumnMap[_table.Columns["QCN"]].Name = "QC#";

				profile.AddExportColumn("������");
				profile.AddExportColumn("���u");
				profile.AddExportColumn("�u�@�渹");
				profile.AddExportColumn("�~��").Name = "�Ƹ�";
				profile.AddExportColumn("�Ȥ�W��");
				profile.AddExportColumn("����ƶq");
				profile.AddExportColumn("�e�˦���");
				profile.AddExportColumn("QCN").Name = "QC#";
				profile.AddExportColumn("���窬�A");
				profile.AddExportColumn("�~��i��");
				profile.AddExportColumn("Remark");

				this.SheetAdapters[0].PasteColumns(_table, _columnHdrRow, 1);
			}

			if (_form.OutputStatistic)
			{
				profile = new ReportSourceProfile(_statisticTable);

				profile.AddExportColumn("���u");
				profile.AddExportColumn("�J�w�`���").Name = "�J�w�`���\n(by QC#)";
				profile.AddExportColumn("�e���`����");
				profile.AddExportColumn("�X��v");

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
			//    sortElements.Add("�~��");
			//if (!string.IsNullOrEmpty(_form.WorksheetFrom) || !string.IsNullOrEmpty(_form.WorksheetTo))
			//    sortElements.Add("�u�@�渹");

			//sortElements.Add("������");

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
				resultCol = this.SheetAdapters[0].ReportProfile.IndexOf("���窬�A") + 1;
				foreach (DataRow row in rows)
				{
					write = this.SheetAdapters[0].PasteDataRow(row, write, 1);

					string result = row["���窬�A"].ToString();
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

			//�έp���
			if (_form.OutputStatistic)
			{
				

				DataView view = _table.DefaultView;
				view.Sort = "���u ASC";
				DataTable disLineTable = view.ToTable(true, "���u");

				foreach (DataRow lineRow in disLineTable.Rows)
				{
					DataRow newRow = _statisticTable.NewRow();

					string line = lineRow[0].ToString();
					int count, num;

					count = (int)_table.Compute("COUNT(���u)", "���u = '" + line + "' AND �̫��������=True AND ���窬�A <> 'NG'");
					num = Convert.ToInt32(_table.Compute("SUM(�e�˦���)", "���u = '" + line + "'  AND �̫��������=True"));

					newRow["���u"] = line;
					newRow["�J�w�`���"] = count;
					newRow["�e���`����"] = num;

					_statisticTable.Rows.Add(newRow);
				}

				write = _columnHdrRow + 1;

				PasteDataRowsOptions option = new PasteDataRowsOptions();
				option.IncludeSummary = true;
				option.SummaryPrefix = "Total";
				option.SummaryColumns.AddRange(new string[] { "�J�w�`���", "�e���`����" });
				option.Row = write;
				
				this.SheetAdapters[1].PasteDataRows(_statisticTable.Select(), option);
			}

            base.WriteContent();
        }

        protected override void AfterContentWritten()
        {
			ReportSourceProfile profile = this.SheetAdapters[0].ReportProfile;

            //�]�w��ܮ榡
			this.SheetAdapters[0].SetFormat(_columnHdrRow, profile.IndexOf("�u�@�渹") + 1, "0");
			if(_form.InspeceMode == InspeceMode.ByQcNo)
				this.SheetAdapters[0].SetFormat(_columnHdrRow, profile.IndexOf("QCN") + 1, "@");

			Range range;
			range = this.SheetAdapters[0].GetUsedRange(_columnHdrRow);
			this.SheetAdapters[0].SetBorder(range, true, true, true, true);

			range = this.SheetAdapters[0].GetRange(_columnHdrRow + 1, 1);
			range.Select();
			this.Application.ActiveWindow.FreezePanes = true;

			//���Y
			range = this.SheetAdapters[0].GetRange(1, 1, 1, this.SheetAdapters[0].UsedColumnsCount);
			this.SheetAdapters[0].SetBorder(range, false, true, false, false);

			range = this.SheetAdapters[0].GetRange(1, 1);
			range.Font.Size = 18;
			range.Font.Bold = true;

			//�����Y
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

			//���u��
			range = this.SheetAdapters[0].GetRange(_columnHdrRow + 1, profile.IndexOf("���u") + 1, this.SheetAdapters[0].UsedRowsCount, profile.IndexOf("���u") + 1);
			range.HorizontalAlignment = XlHAlign.xlHAlignCenter;

			//���î�u
			this.Application.ActiveWindow.DisplayGridlines = false;

			//����`����
			range = this.SheetAdapters[0].GetRange(this.SheetAdapters[0].UsedRowsCount + 2, 1);
			int count = _form.InspeceMode == InspeceMode.ByPn ? _groupTable.Rows.Count : _table.Rows.Count;
			range.Value2 = "�@ " + count + " ��";
			range.Font.Bold = true;

			this.Sheets[0].UsedRange.Font.Name = "Arial";

			//�~��i����
			if (_table.Rows.Count > 0)
			{
				range = this.SheetAdapters[0].GetRange(_columnHdrRow+1, profile.IndexOf("�~��i��") + 1, this.SheetAdapters[0].UsedRowsCount, profile.IndexOf("�~��i��") + 1);
				range.Font.Color = 255;
				//range.Font.Bold = true;
			}

			// Inser��k�|�bExcel2003���� �ҥH�Ĩ����j��k�F��(??)
			//this.SheetAdapters[0].Worksheet.UsedRange.Cut(Missing);
			//this.SheetAdapters[0].GetRange(1, this.SheetAdapters[0].Worksheet.UsedRange.Columns.Count + 2).Select();
			//this.SheetAdapters[0].Worksheet.Paste(Missing, Missing);

			//((Range)this.Application.Selection).Cut(Missing);
			//this.SheetAdapters[0].GetRange(1, 2).Select();
			//this.SheetAdapters[0].Worksheet.Paste(Missing, Missing);

			//�վ���e
			range = this.SheetAdapters[0].GetRange(_form.InspeceMode == InspeceMode.ByPn ? _columnHdrRow - 1 : _columnHdrRow, 1, this.SheetAdapters[0].UsedRowsCount, this.SheetAdapters[0].UsedColumnsCount);
			range.Columns.AutoFit();

			if (_form.InspeceMode == InspeceMode.ByPn)
			{
				for (int i = 0; i < 5; i++)
					this.SheetAdapters[0].GetRange(1, profile.IndexOf("Total") + 1 + i).ColumnWidth = 8.5;

				range = this.SheetAdapters[0].GetRange(1, profile.IndexOf("�~��i��") + 1);
				if ((double)range.ColumnWidth < 10)
					range.ColumnWidth = 10;
			}

			//���۰ʿz��
			//range = this.SheetAdapters[0].GetRange(_columnHdrRow, 2, _columnHdrRow, this.SheetAdapters[0].UsedColumnsCount).EntireRow;
			range = this.SheetAdapters[0].GetRange(_columnHdrRow, 1, this.SheetAdapters[0].UsedRowsCount - 2, this.SheetAdapters[0].UsedColumnsCount);
			range.AutoFilter(1, Missing, XlAutoFilterOperator.xlAnd, Missing, true);

			//���J�ťզ�
			this.SheetAdapters[0].GetRange(1, 1).EntireColumn.Insert(XlInsertShiftDirection.xlShiftToRight, XlInsertFormatOrigin.xlFormatFromLeftOrAbove);

			

			////�վ���e
			//range = this.SheetAdapters[0].GetRange(_form.InspeceMode == InspeceMode.ByPn ? _columnHdrRow - 1 : _columnHdrRow, 1, this.SheetAdapters[0].UsedRowsCount, this.SheetAdapters[0].UsedColumnsCount);
			//range.Columns.AutoFit();

			//if (_form.InspeceMode == InspeceMode.ByPn)
			//{
			//    for (int i = 0; i < 5; i++)
			//        this.SheetAdapters[0].GetRange(1, profile.IndexOf("Total") + 2 + i).ColumnWidth = 8.5;

			//    range = this.SheetAdapters[0].GetRange(1, profile.IndexOf("�~��i��") + 2);
			//    if ((double)range.ColumnWidth < 10)
			//        range.ColumnWidth = 10;
			//}

			////���۰ʿz��
			////range = this.SheetAdapters[0].GetRange(_columnHdrRow, 2, _columnHdrRow, this.SheetAdapters[0].UsedColumnsCount).EntireRow;
			//range = this.SheetAdapters[0].GetRange(_columnHdrRow, 1, this.SheetAdapters[0].UsedRowsCount - 2, this.SheetAdapters[0].UsedColumnsCount);
			//range.AutoFilter(1, Missing, XlAutoFilterOperator.xlAnd, Missing, true);

			this.SheetAdapters[0].GetRange(1, 1).EntireColumn.ColumnWidth = 4;
			this.SheetAdapters[0].GetRange(_columnHdrRow, 1).EntireRow.RowHeight = 40;

			if (_form.OutputStatistic)
			{
				profile = this.SheetAdapters[1].ReportProfile;

				//���Y
				range = this.SheetAdapters[1].GetRange(1, 1).EntireRow;
				range.Font.Size = 18;
				range.Font.Bold = true;

				//�����Y
				range = this.SheetAdapters[1].GetRange(_columnHdrRow, 1, _columnHdrRow, this.SheetAdapters[1].UsedColumnsCount);
				range.Interior.Color = 16777164;
				//range.AutoFilter(1, Missing, XlAutoFilterOperator.xlAnd, Missing, true);
				range.HorizontalAlignment = XlHAlign.xlHAlignCenter;

				//���u��
				range = this.SheetAdapters[1].GetRange(_columnHdrRow + 1, profile.IndexOf("���u") + 1, this.SheetAdapters[1].UsedRowsCount, profile.IndexOf("���u") + 1);
				range.HorizontalAlignment = XlHAlign.xlHAlignCenter;

				//�r���C��
				range = this.SheetAdapters[1].GetRange(_columnHdrRow, 1, this.SheetAdapters[1].UsedRowsCount - 1, this.SheetAdapters[1].UsedColumnsCount);
				range.Font.Color = 16711680;

				//�`�M��
				if (_table.Rows.Count > 0)
				{
					range = this.SheetAdapters[1].GetRange(this.SheetAdapters[1].UsedRowsCount, 1, this.SheetAdapters[1].UsedRowsCount, this.SheetAdapters[1].UsedColumnsCount);
					range.Font.Bold = true;
					range.Font.Color = 255;
					range.Interior.Color = 65535;
				}

				//��Ʈ榡
				this.SheetAdapters[1].SetFormat(_columnHdrRow, profile.IndexOf("�X��v") + 1, "0.00%");

				this.Sheets[1].UsedRange.Font.Name = "Arial";

				

				// Inser��k�|�bExcel2003���� �ҥH�Ĩ����j��k�F��
				//this.SheetAdapters[1].Worksheet.Select(Missing);
				//this.SheetAdapters[1].Worksheet.UsedRange.Cut(Missing);
				//this.SheetAdapters[1].GetRange(1, this.SheetAdapters[1].Worksheet.UsedRange.Columns.Count + 2).Select();
				//this.SheetAdapters[1].Worksheet.Paste(Missing, Missing);

				//((Range)this.Application.Selection).Cut(Missing);
				//this.SheetAdapters[1].GetRange(1, 2).Select();
				//this.SheetAdapters[1].Worksheet.Paste(Missing, Missing);

				

				//���۰ʿz��
				range = this.SheetAdapters[1].GetRange(_columnHdrRow, 1, this.SheetAdapters[1].UsedRowsCount - 1, this.SheetAdapters[1].UsedColumnsCount);
				//range = this.SheetAdapters[1].GetRange(_columnHdrRow, 2, _columnHdrRow, this.SheetAdapters[1].UsedColumnsCount);
				range.AutoFilter(1, Missing, XlAutoFilterOperator.xlAnd, Missing, true);

				//�վ���e
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

        #region IFormSettable ����

        public void OpenForm()
        {
			_form = new InspectListReportForm();
			//form.Text = this.Name;
			//form.DateTypeName = "���";
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
