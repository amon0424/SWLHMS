using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

using Microsoft.Office.Interop.Excel;
using Mong.ReportDataSetTableAdapters;

using DataTable = System.Data.DataTable;

namespace Mong.Report
{
    class UnitPriceReporter : SingleSheetReporter, IFormSettable
    {

        ReportDataSet.UnitPriceReportDataTable _table;
        DateTime _startDate = DateTime.MinValue;
        DateTime _endDate = DateTime.MaxValue;
        Dictionary<int, string> _npDic;

        public Dictionary<int, string> NpDic
        {
            get
            {
                if (_npDic == null)
                {
                    _npDic = new Dictionary<int, string>();
                    foreach (DatabaseSet.�D�Ͳ�Row row in DatabaseSet.�D�Ͳ�Table)
                    {
                        if (row.�s�� != -1)
                            _npDic.Add(row.�s��, row.�W��);
                    }
                }

                return _npDic;
            }
            set { _npDic = value; }
        }
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

        public UnitPriceReporter()
        {
            this.Name = "���u�ꦨ����";
			this.AllowUser |= UserType.Manager;
        }

        protected override void BeforeExport()
        {
            //�إ߳���table
            InitReportTable();

            base.BeforeExport();
        }

        protected override void WriteHeader()
        {
            this.Sheet.Cells[1, 1] = this.Name;
            this.Sheet.Cells[2, 1] = "��������: " + _startDate.ToString("yyyy/MM/dd") + " �� " + _endDate.ToString("yyyy/MM/dd");

            base.WriteHeader();
        }

        protected override void WriteColumnHeader()
        {
            ReportSourceProfile profile = new ReportSourceProfile(_table);
			//foreach (DataColumn column in _table.Columns)
			//    profile.AddExportColumn(column);

			profile.AddExportColumn("�~��");
			profile.AddExportColumn("�~�W");
			profile.AddExportColumn("�ƶq");
			profile.AddExportColumn("���");
			profile.AddExportColumn("�зǤu��").Name = "�з��`�u��";
			profile.AddExportColumn("�зǳ��u��").Name = "�з��`�u��";
			profile.AddExportColumn("��ڤu��(��+�~)").Name = "����`�u��(��+�~)";
			profile.AddExportColumn("��ڤu��(��+�~)").Name = "����`�u��(��+�~)";
			profile.AddExportColumn("�t�ή��~").Name = "�t�ή��~\n(NT$/Hour)";
			profile.AddExportColumn("���зǤu��").Name = "�зǳ��u��\n(NT$/Kpcs)";
			profile.AddExportColumn("��ڳ��u��(NT$/Kpcs)").Name = "��ڳ��u��\n(NT$/Kpcs)";

            this.SheetAdapter.ReportProfile = profile;

            this.SheetAdapter.PasteColumns(_table, 3, 1);

            base.WriteColumnHeader();
        }

        protected override void WriteContent()
        {
            //�إ߼g�J�e�m�@�~
            int writeRow = 4;
            PasteDataRowsOptions options = new PasteDataRowsOptions();
            options.IncludeSummary = false;
            options.Row = writeRow;

            DataRow[] rows = _table.Select();

            //�g�J���e
            writeRow = this.SheetAdapter.PasteDataRows(rows, options);

            //�g�J�`�p
            string[] sumCols = new string[] { "�ƶq", "�зǤu��", "��ڤu��(��+�~)", "��ڤu��(��+�~)" };
            DataRow totalRow = _table.NewRow();
            totalRow[0] = "�`�p";
            foreach (string sumCol in sumCols)
            {
                object o;
                o = _table.Compute("SUM([" + sumCol + "])", string.Empty);
                totalRow[sumCol] = Convert.IsDBNull(o) ? 0 : (decimal)o;
            }
            _table.Rows.Add(totalRow);

            writeRow = this.SheetAdapter.PasteDataRow(totalRow, writeRow, 1);

            
            base.WriteContent();
        }

        protected override void AfterContentWritten()
        {
			ReportSourceProfile profile = this.SheetAdapter.ReportProfile;

			//�]�w��ܮ榡

			//�]�w�p�Ʀ��
			int[] formatCols = new int[]
			{
				profile.IndexOf("�зǤu��") + 1,
				profile.IndexOf("�зǳ��u��") + 1,
				profile.IndexOf("��ڤu��(��+�~)") + 1,
				profile.IndexOf("��ڤu��(��+�~)") + 1,
				profile.IndexOf("��ڳ��u��(NT$/Kpcs)") + 1,
			};

			foreach (int col in formatCols)
				this.SheetAdapter.SetFormat(4, col, "[=0]* \"-\"_-;G/�q�ή榡");

			this.SheetAdapter.RoundValues(formatCols, 4, 2);

            //�]�w�~�[�˦�
            Range reportBodyRange = this.SheetAdapter.GetUsedRange(3);
            reportBodyRange.Columns.AutoFit();

			this.SheetAdapter.GetRange(1, profile.IndexOf("�t�ή��~") + 1).ColumnWidth = 12.5;
			this.SheetAdapter.GetRange(1, profile.IndexOf("���зǤu��") + 1).ColumnWidth = 15;
			this.SheetAdapter.GetRange(1, profile.IndexOf("��ڳ��u��(NT$/Kpcs)") + 1).ColumnWidth = 15;

            this.SheetAdapter.SetBorder(reportBodyRange, XlLineStyle.xlContinuous, XlBorderWeight.xlThin, true, true, true, true);

            base.AfterContentWritten();
        }

        void InitReportTable()
        {
            ReportDataSetTableAdapters.UnitPriceReportTableAdapter adapter = new Mong.ReportDataSetTableAdapters.UnitPriceReportTableAdapter();

            //���o�򥻳�����
            _table = adapter.GetData(_startDate, _endDate);
            

            //���o�u�@�渹,�~��,��ڤu���
            System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
			cmd.CommandText = "SELECT �u�@��.�渹 AS �渹, ���~�~��.�~��, Year(�u��.���) AS �~��, Month(�u��.���) AS ���, " + 
                                "IIF(SUM(�u��.�u��) IS NULL , 0, SUM(�u��.�u��)) AS ��ڤu��," + 
                                "IIF(SUM(�u��.�u��) IS NULL , 0, SUM(���u.�~�� * �u��.�u��)) AS ��ڤu�� " +
                                "FROM ((((�u�@�� INNER JOIN �u�@��~�� ON �u�@��~��.�渹 = �u�@��.�渹) " +
                                "INNER JOIN ���~�~�� ON �u�@��~��.�~�� = ���~�~��.�~��) " +
                                "LEFT JOIN �u�� ON �u��.�u�@�渹 =  �u�@��~��.�渹 AND �u�@��~��.�s�� = �u��.�u�~�s��) " +
                                "LEFT JOIN ���u ON �u��.���u�s�� = ���u.�s��) " +
                                "WHERE �u�@��.��ڧ����� > #" + _startDate.ToString("yyyy/MM/dd") + "# AND �u�@��.��ڧ����� < #" + _endDate.ToString("yyyy/MM/dd") + "# " +
								"GROUP BY  �u�@��.�渹, ���~�~��.�~��, Year(�u��.���), Month(�u��.���)" +
								"ORDER BY  �u�@��.�渹, ���~�~��.�~��, Year(�u��.���), Month(�u��.���)";

            cmd.Connection = adapter.Connection;
            System.Data.DataTable baseTable = new System.Data.DataTable();
            baseTable.Columns.Add(new DataColumn("�渹", typeof(string)));
            baseTable.Columns.Add(new DataColumn("�~��", typeof(string)));
            baseTable.Columns.Add(new DataColumn("��ڤu��", typeof(decimal)));
            baseTable.Columns.Add(new DataColumn("��ڤu��", typeof(decimal)));
            baseTable.Columns.Add(new DataColumn("�~��", typeof(int)));
            baseTable.Columns.Add(new DataColumn("���", typeof(int)));
            System.Data.OleDb.OleDbDataAdapter baseAdapter = new System.Data.OleDb.OleDbDataAdapter();
            baseAdapter.SelectCommand = cmd;
            baseAdapter.Fill(baseTable);

            //���o����d��
            int minYear, minMonth, maxYear, maxMonth;
            DateTime minDate, maxDate;
            object o;

            o = baseTable.Compute("MIN(�~��)", string.Empty);
            minYear = Convert.IsDBNull(o) ? DateTime.MinValue.Year : (int)o;

            o = baseTable.Compute("MIN(���)", string.Empty);
            minMonth = Convert.IsDBNull(o) ? DateTime.MinValue.Month : (int)o;

            o = baseTable.Compute("MAX(�~��)", string.Empty);
            maxYear = Convert.IsDBNull(o) ? DateTime.MinValue.Year : (int)o;

            o = baseTable.Compute("MAX(���)", string.Empty);
            maxMonth = Convert.IsDBNull(o) ? DateTime.MinValue.Month : (int)o;

            minDate = new DateTime(minYear, minMonth, 1);
            maxDate = new DateTime(maxYear, maxMonth, 1);
            
            //���o�C��u�@�ɼ�
            Dictionary<DateTime, decimal> workHoursDic = new Dictionary<DateTime, decimal>();
            for (DateTime date = new DateTime(minDate.Year, minDate.Month, 1); date <= maxDate; date = date.AddMonths(1))
            {
                decimal hours = Global.GetWorkingHours(date.Year, date.Month);
                workHoursDic.Add(date, hours);
            }

            //���s�p��baseTable����ڤu��
            DateTime curRowMonth = DateTime.MinValue;
            foreach (DataRow row in baseTable.Rows)
            {
                if (!Convert.IsDBNull(row["�~��"]))
                {
                    int year = (int)row["�~��"];
                    int month = (int)row["���"];

                    if (year != curRowMonth.Year || month != curRowMonth.Month)
                        curRowMonth = new DateTime(year, month, 1);

                    row["��ڤu��"] = Math.Round(((decimal)row["��ڤu��"]) / workHoursDic[curRowMonth], MidpointRounding.AwayFromZero);
                }
            }

            //���sGroup
            DataTableHelper dtHelper = new DataTableHelper();
            System.Data.DataTable groupTable = dtHelper.SelectGroupByInto("GroupTable", baseTable, "�~��,SUM(��ڤu��) ��ڤu��, SUM(��ڤu��) ��ڤu��", null, "�~��");

            //���o���w����d�򤺪��u�@�渹
            cmd = new System.Data.OleDb.OleDbCommand();
            cmd.CommandText = "SELECT DISTINCT(�渹) FROM �u�@�� WHERE ��ڧ����� > #" + _startDate.ToString("yyyy/MM/dd") + "# AND ��ڧ����� < #" + _endDate.ToString("yyyy/MM/dd") + "#";
            cmd.Connection = adapter.Connection;
            System.Data.DataTable wsNumTable = new System.Data.DataTable();
            wsNumTable.Columns.Add(new DataColumn("�渹", typeof(string)));
            System.Data.OleDb.OleDbDataAdapter wsNumAdapter = new System.Data.OleDb.OleDbDataAdapter();
            wsNumAdapter.SelectCommand = cmd;
            wsNumAdapter.Fill(wsNumTable);

            List<string> wsNumList = new List<string>();
            foreach (DataRow row in wsNumTable.Rows)
                wsNumList.Add(row["�渹"].ToString());

            //���oLaborWage��Ʈw
            LaborWageHelper lwHelper = new LaborWageHelper();
            LaborWage�u�@��~��Table lwTable = lwHelper.GetDataGroupByPartNumber(wsNumList);

            //��J�u��P�u��
            foreach (ReportDataSet.UnitPriceReportRow row in _table)
            {
                DataRow[] partRows = groupTable.Select(string.Format("�~�� = '{0}'", row.�~��));
                if (partRows.Length > 0)
                {

                    row._��ڤu��_��_�~_ = (decimal)partRows[0]["��ڤu��"];
                    row._��ڤu��_��_�~_ = (decimal)partRows[0]["��ڤu��"];
                   
                }

                //��JLaborWage���
                DataRow[] lwRows = lwTable.Select(string.Format("�~�� = '{0}'", row.�~��));
                if (lwRows.Length > 0)
                {
                    decimal wage = (decimal)lwRows[0]["�~�]�u��"];
                    row._��ڤu��_��_�~_ += wage;
					row._��ڤu��_��_�~_ += wage / Settings.HourlyPay;
                }
            }
        }

        #region IFormSettable ����

        public void OpenForm()
        {
            DateForm form = new DateForm();
            form.Text = this.Name;
            form.DateTypeName = "�u�@���ڧ�����";
            form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            form.ExportClick += new EventHandler(form_ExportClick);
            form.ShowDialog();
        }

        void form_ExportClick(object sender, EventArgs e)
        {
            DateForm form = (DateForm)sender;
            this.StartDate = form.StartDate;
            this.EndDate = form.EndDate;
            this.Export();
        }

        #endregion
    }
}
