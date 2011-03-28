using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Microsoft.Office.Interop.Excel;
using Mong.ReportDataSetTableAdapters;

using DataTable = System.Data.DataTable;

namespace Mong.Report
{
    class FinishedWorksheetReporter : SingleSheetReporter, IFormSettable
    {
        protected DataTable _table;
		protected ReportDataSet.FinishedWorksheetReportSourceDataTable _srcTable;
		DateLineForm _form;
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

        public FinishedWorksheetReporter()
        {
            this.Name = "�w�����u�@����R��";
			
        }

        protected override void BeforeExport()
        {
			string lineFilter = string.Empty;
			if(!string.IsNullOrEmpty(_form.Line))
				lineFilter = "���u = '" + _form.Line + "'";

            FinishedWorksheetReportSourceTableAdapter adapter = new FinishedWorksheetReportSourceTableAdapter();

            //���o�򥻳�����
            _srcTable = adapter.GetData(_startDate, _endDate);
			//_srcTable.Columns.Add("�h��ƶq", typeof(decimal));

            //���o�C��u�@�ɼ�
            Dictionary<DateTime, decimal> workHoursDic = new Dictionary<DateTime, decimal>();
            DateTime minDate = _startDate;
            DateTime maxDate = _endDate;

            object tmpObj = _srcTable.Compute("MIN(���)",string.Empty);
            if (tmpObj != DBNull.Value)
                minDate = (DateTime)tmpObj;

            tmpObj = _srcTable.Compute("MAX(���)", string.Empty);
			if (tmpObj != DBNull.Value)
			{
				maxDate = (DateTime)tmpObj;
				maxDate = new DateTime(maxDate.Year, maxDate.Month, DateTime.DaysInMonth(maxDate.Year, maxDate.Month));
			}

            for (DateTime date = minDate; date <= maxDate; date = date.AddMonths(1))
            {
                decimal hours = Global.GetWorkingHours(date.Year, date.Month);
                DateTime key = new DateTime(date.Year, date.Month, 1);
                workHoursDic.Add(key, hours);
            }
            
            //���s�B���ڤu��
            DateTime curRowMonth = DateTime.MinValue;
            foreach (ReportDataSet.FinishedWorksheetReportSourceRow row in _srcTable)
            {
                if (!row.IsNull("�~��"))
                {
                    if (row.�~�� != curRowMonth.Year || row.��� != curRowMonth.Month)
                        curRowMonth = new DateTime(row.�~��, row.���, 1);

                    row.�����u�� = Math.Round(row.�����u�� / workHoursDic[curRowMonth], MidpointRounding.AwayFromZero);
                }
            }

            //���sGroup���
            DataTableHelper dtHelper = new DataTableHelper();
            _table = dtHelper.SelectGroupByInto("ReportTable", _srcTable,
				"���u,��ڧ�����,�u�@�渹,�Ǹ�,�~��,�~�W,�ƶq,���," +
				"Sum(�����u��) �����u��, Sum(�����u��) �����u��,�~�]�u��,�~�]�u��,�зǤu��,���H�u����,����`�u��,����`�u��," +
				"�з��`�u��,�з��`�u��,�Ͳ��Ĳv,���зǤu��,��ڤu��,��ڤu��,�u�~�s��",
				lineFilter, "���u,��ڧ�����,�u�@�渹,�~��,�~�W,�ƶq,�зǤu��,���H�u����,���зǤu��,�u�~�s��");

            //�]�w���
            _table.Columns["���"].DefaultValue = "KPCS";

            //���oLaborWage��Ʈw
            LaborWageHelper lwHelper = new LaborWageHelper();
            LaborWage�u�@��~��Table lwTable = null;

            //�B��Ǹ��ö�J�~�]�u��P�u��
            string curWorksheetNumber = string.Empty;
            //int seriesNumber = 1;
            foreach (DataRow row in _table.Rows)
            {
                string wsNumber = row["�u�@�渹"].ToString();
				string pn = row["�~��"].ToString();
				int wpid = (int)row["�u�~�s��"];

                if (curWorksheetNumber != wsNumber)
                {
                    curWorksheetNumber = wsNumber;
                    lwTable = lwHelper.GetData(curWorksheetNumber);
                    //seriesNumber = 1;
                }

				//���o�h��
				//row["�h��ƶq"] = DatabaseSet.GetNGAmount(wsNumber, wpid) / 1000.0f;

				//DataRow[] lwRows = lwTable.Select("�u�~�s�� = " + row["�u�~�s��"]);
				object result = lwTable.Compute("SUM(�~�]�u��)", string.Format("�u�~�s�� = {0}", row["�u�~�s��"].ToString())); 

                //if (lwRows.Length > 0)
				if (result != null && result != DBNull.Value)
                {
                    //decimal laborWage = (decimal)lwRows[0]["�~�]�u��"];
					decimal laborWage = Convert.ToDecimal(result);

                    row["�~�]�u��"] = laborWage;
					row["�~�]�u��"] = laborWage / Settings.HourlyPay;
                }

                //row["�Ǹ�"] = seriesNumber++;
				row["�Ǹ�"] = wpid;
            }

            base.BeforeExport();
        }

        protected override void WriteHeader()
        {
            this.Sheet.Cells[1, 1] = this.Name;
            this.Sheet.Cells[2, 1] = "����: " + _startDate.ToString("yyyy/MM/dd") + " �� " + _endDate.ToString("yyyy/MM/dd");

            base.WriteHeader();
        }

        protected override void WriteColumnHeader()
        {
            ReportSourceProfile profile = new ReportSourceProfile(_table);
			//profile.ExcludeExportColumn(new List<DataColumn>(new DataColumn[] { _table.Columns["�u�~�s��"] }));
			//foreach (DataColumn column in _table.Columns)
			
			profile.AddExportColumn("���u");
			profile.AddExportColumn("��ڧ�����");
			profile.AddExportColumn("�u�@�渹");
			profile.AddExportColumn("�Ǹ�");
			profile.AddExportColumn("�~��");
			profile.AddExportColumn("�~�W");
			//profile.AddExportColumn("�h��ƶq");
			profile.AddExportColumn("�ƶq");
			profile.AddExportColumn("���");
			profile.AddExportColumn("�����u��");
			profile.AddExportColumn("�����u��");
			profile.AddExportColumn("�~�]�u��");
			profile.AddExportColumn("�~�]�u��");
			profile.AddExportColumn("����`�u��");
			profile.AddExportColumn("�з��`�u��");
			profile.AddExportColumn("����`�u��");
			profile.AddExportColumn("�з��`�u��");
			profile.AddExportColumn("�Ͳ��Ĳv");
			profile.AddExportColumn("�зǤu��");
			profile.AddExportColumn("���H�u����");
			profile.AddExportColumn("���зǤu��");
			profile.AddExportColumn("��ڤu��");
			profile.AddExportColumn("��ڤu��");

			profile.ColumnMap[_table.Columns["�����u��"]].Name = "��������`�u��";
			profile.ColumnMap[_table.Columns["�����u��"]].Name = "��������`�u��";
			profile.ColumnMap[_table.Columns["�~�]�u��"]].Name = "�~�]����`�u��";
			profile.ColumnMap[_table.Columns["�~�]�u��"]].Name = "�~�]����`�u��";
            profile.ColumnMap[_table.Columns["�зǤu��"]].Name = "���зǤu��\n(Hour/Kpcs)";
            profile.ColumnMap[_table.Columns["���H�u����"]].Name = "�������~\n(NT$/Hour)";
			profile.ColumnMap[_table.Columns["���зǤu��"]].Name = "���зǤu��\n(NT$/Kpcs)";
			profile.ColumnMap[_table.Columns["�Ͳ��Ĳv"]].Name = "�з��`�u��/\n����`�u��";
            profile.ColumnMap[_table.Columns["����`�u��"]].Name = "����`�u��\n(��+�~)";
            profile.ColumnMap[_table.Columns["����`�u��"]].Name = "����`�u��\n(��+�~)";
			profile.ColumnMap[_table.Columns["�з��`�u��"]].Name = "�����`�u��";
			profile.ColumnMap[_table.Columns["��ڤu��"]].Name = "����ڤu��\n(Hour/Kpcs)";
			profile.ColumnMap[_table.Columns["��ڤu��"]].Name = "����ڤu��\n(NT$/Kpcs)";

            this.SheetAdapter.ReportProfile = profile;
            this.SheetAdapter.PasteColumns(_table, 3, 1);

			Application.ErrorCheckingOptions.NumberAsText = false;
			this.SheetAdapter.GetRange(4, profile.IndexOf("�u�@�渹") + 1).EntireColumn.NumberFormat = "@";

            base.WriteColumnHeader();
        }

        protected override void WriteContent()
        {
            System.Data.DataTable linesTable = DataTableHelper.SelectDistinct(_table, "���u");

            //�إ߼g�J�e�m�@�~
            int writeRow = 4;
            PasteDataRowsOptions options = new PasteDataRowsOptions();
            options.IncludeSummary = false;	//��ʱ���Summary Row
			options.SummaryColumns.AddRange(new string[] { /*"�h��ƶq", */"�ƶq"/*, "�зǤu��", "���H�u����"*/, "�����u��", "�����u��", "�~�]�u��", "�~�]�u��", "�з��`�u��", "�з��`�u��", /*"���зǤu��", "��ڤu��", "��ڤu��"*/ });
			options.NoSummaryColumns.AddRange(new string[] { "�зǤu��", "���H�u����", "���зǤu��", "��ڤu��", "��ڤu��" });

			PasteDataRowEventHandler beforeSummary = new PasteDataRowEventHandler(BeforePasteDataRowSummary);
			//this.SheetAdapter.BeforePasteDataRowSummary += beforeSummary;

			DataTableHelper dtHelper = new DataTableHelper();
			DataTable nonNormalHourTable = dtHelper.SelectGroupByInto("ReportTable", _srcTable,
					"���u, Sum(�����u��) �����u��, �u������",
					null, "���u,��ڧ�����,�u�@�渹,�~��,�~�W,�ƶq,�зǤu��,���H�u����,���зǤu��,�u�~�s��,�u������");

			//��C�Ӳ��u
            foreach (DataRow lineRow in linesTable.Rows)
            {
				//NOTICE: ��Select����ק�ɤ]�����ק�BeforePasteDataRowSummary���e
                DataRow[] rows = _table.Select("���u = '" + lineRow["���u"] + "'", "�u�@�渹,�Ǹ�");

                //�g�J���e
				options.IncludeSummary = false;
                options.Row = writeRow;
                options.SummaryPrefix = lineRow["���u"] + "���u�p�p";
                writeRow = this.SheetAdapter.PasteDataRows(rows, options);

				//�g�J���`�Ͳ��u��,�]�ˤu��
				decimal unusual = 0;
				decimal package = 0;

				// ���o���`�Ͳ��u��
				object result = nonNormalHourTable.Compute("SUM(�����u��)", "���u = '" + lineRow["���u"] + "' AND �u������=" + (int)HourType.���`�Ͳ��u��);
				if (result != null && result != DBNull.Value)
					unusual = (decimal)result;

				// ���o�]�ˤu��
				result = nonNormalHourTable.Compute("SUM(�����u��)", "���u = '" + lineRow["���u"] + "' AND �u������=" + (int)HourType.�]��);
				if (result != null && result != DBNull.Value)
					package = (decimal)result;

				DataRow tmpRow = _table.NewRow();
				tmpRow["���"] = null;
				tmpRow[0] = "���`�Ͳ��u��";
				tmpRow["����`�u��"] = unusual;
				writeRow = this.SheetAdapter.PasteDataRow(tmpRow, writeRow, options.Column);

				tmpRow[0] = "�]��";
				tmpRow["����`�u��"] = package;
				writeRow = this.SheetAdapter.PasteDataRow(tmpRow, writeRow, options.Column);

				//�g�J�p�p
				options.Row = writeRow;
				writeRow = this.SheetAdapter.PasteSummaryRow(rows, options);

            }
			//this.SheetAdapter.BeforePasteDataRowSummary -= beforeSummary;

			decimal ttlUnusual = 0;
			decimal ttlPackage = 0;

			// ���o���`�Ͳ��u��
			object tmpResult = nonNormalHourTable.Compute("SUM(�����u��)", "�u������=" + (int)HourType.���`�Ͳ��u��);
			if (tmpResult != null && tmpResult != DBNull.Value)
				ttlUnusual = (decimal)tmpResult;

			// ���o�]�ˤu��
			tmpResult = nonNormalHourTable.Compute("SUM(�����u��)", "�u������=" + (int)HourType.�]��);
			if (tmpResult != null && tmpResult != DBNull.Value)
				ttlPackage = (decimal)tmpResult;

			//�g�J�`�p(���]�A���`,�]��)
			DataTable tmpTable = _table.Clone();
			tmpTable.Columns["����`�u��"].Expression = string.Empty;	//����`�u�ɦۤv�p��

			DataRow totalRow = tmpTable.NewRow();

			foreach (string sumCol in options.SummaryColumns)
			{
				if (!string.IsNullOrEmpty(tmpTable.Columns[sumCol].Expression))
					tmpTable.Columns[sumCol].Expression = string.Empty;

				object o;
				o = _table.Compute("SUM(" + sumCol + ")", string.Empty);
				totalRow[sumCol] = Convert.IsDBNull(o) ? 0 : (decimal)o;
			}
			foreach (string noSumCol in options.NoSummaryColumns)
			{
				tmpTable.Columns[noSumCol].Expression = string.Empty;
				totalRow[noSumCol] = DBNull.Value;
			}

			//����`�u�� - (���`�Ͳ��u��+�]��)
			object ttlHourObj = _table.Compute("SUM(����`�u��)", string.Empty);
			decimal ttlHour = Convert.IsDBNull(ttlHourObj) ? 0 : (decimal)ttlHourObj;
			totalRow["����`�u��"] = ttlHour - (ttlUnusual + ttlPackage);

			totalRow[0] = "�`�p";
			tmpTable.Rows.Add(totalRow);
            writeRow = this.SheetAdapter.PasteDataRow(totalRow, writeRow, 1);

			tmpTable = _table.Clone();
			//�g�J���`,�]���`�p
			tmpTable.Columns[tmpTable.Columns["�~�]�u��"].Ordinal].DataType = typeof(object);

			DataRow abnormalTotalRow = tmpTable.NewRow();
			abnormalTotalRow["���"] = null;
			abnormalTotalRow[tmpTable.Columns["�~�]�u��"].Ordinal] = "���`�Ͳ��u��";
			abnormalTotalRow["����`�u��"] = ttlUnusual;
			writeRow = this.SheetAdapter.PasteDataRow(abnormalTotalRow, writeRow, options.Column);

			abnormalTotalRow[tmpTable.Columns["�~�]�u��"].Ordinal] = "�]��";
			abnormalTotalRow["����`�u��"] = ttlPackage;
			writeRow = this.SheetAdapter.PasteDataRow(abnormalTotalRow, writeRow, options.Column);

			//�g�J�`�p(+���`,�]��)
			totalRow = tmpTable.NewRow();
			options.SummaryColumns = new List<string>(new string[] { "����`�u��", "�з��`�u��" });
			options.NoSummaryColumns = new List<string>(new string[] { "�ƶq", "�����u��", "�����u��", "�~�]�u��", "�~�]�u��", "�зǤu��", "���H�u����", "���зǤu��", "��ڤu��", "��ڤu��", "�з��`�u��" });

			foreach (string sumCol in options.SummaryColumns)
			{
				if (!string.IsNullOrEmpty(tmpTable.Columns[sumCol].Expression))
					tmpTable.Columns[sumCol].Expression = string.Empty;

				object o;
				o = _table.Compute("SUM(" + sumCol + ")", string.Empty);
				totalRow[sumCol] = Convert.IsDBNull(o) ? 0 : (decimal)o;
			}
			foreach (string noSumCol in options.NoSummaryColumns)
			{
				tmpTable.Columns[noSumCol].Expression = string.Empty;
				totalRow[noSumCol] = DBNull.Value;
			}

			totalRow[tmpTable.Columns["�~�]�u��"].Ordinal] = "Total";
			totalRow["���"] = null;
			tmpTable.Rows.Add(totalRow);

			writeRow = this.SheetAdapter.PasteDataRow(totalRow, writeRow, 1);

            base.WriteContent();
        }

        protected override void AfterContentWritten()
        {
			ReportSourceProfile profile = this.SheetAdapter.ReportProfile;

            //�]�w��ܮ榡
			//this.SheetAdapter.SetFormat(4, profile.IndexOf("�h��ƶq") + 1, "[����]G/�q�ή榡;G/�q�ή榡;* \"-\"_-");
			//string format = "#,##0.00;#,##0.00;* \"-\"_-";
			//string format = "G/�q�ή榡;G/�q�ή榡;* \"-\"_-";
			
			this.SheetAdapter.SetFormat(4, profile.IndexOf("�Ͳ��Ĳv") + 1, "0.00%");

			//�]�w�p�Ʀ��
			int[] formatCols = new int[]
			{
				profile.IndexOf("�зǤu��") + 1,
				profile.IndexOf("���H�u����") + 1,
				profile.IndexOf("�з��`�u��") + 1,
				profile.IndexOf("�з��`�u��") + 1,
				profile.IndexOf("���зǤu��") + 1,
				profile.IndexOf("�����u��") + 1,
				profile.IndexOf("�����u��") + 1,
				profile.IndexOf("�~�]�u��") + 1,
				profile.IndexOf("�~�]�u��") + 1,
				profile.IndexOf("��ڤu��") + 1,
				profile.IndexOf("��ڤu��") + 1,
				profile.IndexOf("����`�u��") + 1,
				profile.IndexOf("����`�u��") + 1
			};

			foreach (int col in formatCols)
				this.SheetAdapter.SetFormat(4, col, "[=0]* \"-\"_-;G/�q�ή榡");

			this.SheetAdapter.RoundValues(formatCols, 4, 2);

            //�������
			//this.SheetAdapter.GetRange(1, 14, 1, 15).EntireColumn.Cut(Missing);
			//this.SheetAdapter.GetRange(1, 21).EntireColumn.Insert(XlInsertShiftDirection.xlShiftToRight, Missing);

            //�]�w�~�[�˦�
            Range range;
            for (int i = 0; i < 4; i++)
				this.SheetAdapter.GetRange(1, profile.IndexOf("�����u��") + 1 + i).ColumnWidth = 15.5;
            for (int i = 0; i < 10; i++)
				this.SheetAdapter.GetRange(1, profile.IndexOf("����`�u��") + 1 + i).ColumnWidth = 13.5;

            //this.SheetAdapter.GetRange(1, _table.Columns.IndexOf("���H�u����") + 1).ColumnWidth = 15;
			range = this.SheetAdapter.GetRange(3, 1, this.SheetAdapter.UsedRowsCount, profile.IndexOf("���") + 1);
            range.Columns.AutoFit();

            range = this.SheetAdapter.GetUsedRange(3);
            this.SheetAdapter.SetBorder(range, true, true, true, true);

            base.AfterContentWritten();
        }

		void BeforePasteDataRowSummary(object sender, DataRow[] rows, PasteDataRowsOptions options, ref int writeRow, int col, object args)
		{
			decimal unusual = 0;
			decimal package = 0;
			if (rows.Length > 0)
			{
				DataTable table = rows[0].Table;
				string line = rows[0]["���u"].ToString();

				// ���o���`�Ͳ��u��
				object result = table.Compute("SUM(�����u��)", "���u = '" + line + "' AND �u������=" + (int)HourType.���`�Ͳ��u��);
				if (result != null && result != DBNull.Value)
					unusual = (decimal)result;
				
				// ���o�]�ˤu��
				result = table.Compute("SUM(�����u��)", "���u = '" + line + "' AND �u������=" + (int)HourType.�]��);
				if (result != null && result != DBNull.Value)
					package = (decimal)result;

				DataRow tmpRow = table.NewRow();
				tmpRow["���"] = null;
				tmpRow[0] = "���`�Ͳ��u��";
				tmpRow["����`�u��"] = unusual;
				writeRow = ((WorksheetAdapter)sender).PasteDataRow(tmpRow, writeRow, col);

				tmpRow[0] = "�]��";
				tmpRow["����`�u��"] = package;
				writeRow = ((WorksheetAdapter)sender).PasteDataRow(tmpRow, writeRow, col);
			}
		}

        #region IFormSettable ����

        public void OpenForm()
        {
			_form = new DateLineForm();
			_form.Text = this.Name;
			_form.DateTypeName = "��ڧ�����";
			_form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			_form.ExportClick += new EventHandler(form_ExportClick);
			_form.ShowDialog();
        }

        void form_ExportClick(object sender, EventArgs e)
        {
			DateLineForm form = (DateLineForm)sender;
            this.StartDate = form.StartDate;
            this.EndDate = form.EndDate;
            this.Export();
        }

        #endregion
    }
}
