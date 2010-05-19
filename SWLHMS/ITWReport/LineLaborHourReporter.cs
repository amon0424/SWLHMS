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
    class LineLaborHourReporter : SingleSheetReporter, IFormSettable
    {
        DataTable _table;

        DateTime _startDate = DateTime.MinValue;
        DateTime _endDate = DateTime.MaxValue;

        Dictionary<int, string> _npDic;

        public Dictionary<int, string> NpDic
        {
            get
            {
				LoadNP();

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

        public LineLaborHourReporter()
        {
            this.Name = "���u�u�ɤ��R��";
        }

		void LoadNP()
		{
			if (_npDic == null)
				_npDic = new Dictionary<int, string>();
			
			_npDic.Clear();
			DatabaseSet.�D�Ͳ�Row[] rows = (DatabaseSet.�D�Ͳ�Row[])DatabaseSet.�D�Ͳ�Table.Select(null, "�s��");
			foreach (DatabaseSet.�D�Ͳ�Row row in rows)
			{
				if (row.�s�� != -1 /*&& row.�W�� != "�а�"*/)
					_npDic.Add(row.�s��, "np" + row.�W��);
			}
		}

        protected override void BeforeExport()
        {
			LoadNP();

            LineLaborHourReportSourceTableAdapter adapter = new LineLaborHourReportSourceTableAdapter();

            //���o�򥻳�����
            ReportDataSet.LineLaborHourReportSourceDataTable srcTable = adapter.GetData(_startDate, _endDate);

            //�إ߳���_table
            CreateReportTable();

            ////���o���w����d�򤺪��u�@�渹
            //OleDbCommand cmd = new OleDbCommand();
            //cmd.CommandText = "SELECT DISTINCT(�渹) FROM �u�@�� WHERE ��ڤ�� > #" + _startDate.ToString("yyyy/MM/dd") + "# AND ��ڤ�� < #" + _endDate.ToString("yyyy/MM/dd") + "#";
            //cmd.Connection = adapter.Connection;
            
            //DataTable wsNumTable = new DataTable();
            //wsNumTable.Columns.Add(new DataColumn("�渹", typeof(string)));
            
            //OleDbDataAdapter wsNumAdapter = new OleDbDataAdapter();
            //wsNumAdapter.SelectCommand = cmd;
            //wsNumAdapter.Fill(wsNumTable);

            //List<string> wsNumList = new List<string>();
            //foreach (DataRow row in wsNumTable.Rows)
            //    wsNumList.Add(row["�渹"].ToString());

			//Ū���D�Ͳ����

            
            //�إߤ���table(���u,���u)
            DataTable groupTable = DataTableHelper.SelectDistinct(srcTable, "���u", "�ɤJ���u", "���u�m�W");

			/* 1.08.4
			//���oLaborWage���
            LaborWageHelper lwHelper = new LaborWageHelper();
            //LaborWage���u�u��Table lwTable = lwHelper.GetDataGroupByLabor(wsNumList);
            LaborWage���u�u��Table lwTable = lwHelper.GetDataGroupByDate(_startDate, _endDate);

            //Union lw table
            foreach (DataRow r in lwTable.Rows)
            {
                string name = r["���u�m�W"].ToString();

                DataRow[] rs = groupTable.Select("�ɤJ���u IS NULL AND ���u�m�W = '" + name + "'");
                if (rs.Length == 0)
                {
                    DataRow[] laborRow = DatabaseSet.���uTable.Select("�m�W ='" + name + "'");
                    if (laborRow.Length != 0)
                    {
                        DataRow nr = groupTable.NewRow();
                        nr["���u"] = laborRow[0]["���u"];
                        nr["���u�m�W"] = name;
                        groupTable.Rows.Add(nr);
                    }
                }
            }
			*/

			//Re order
            groupTable.DefaultView.Sort = "���u, �ɤJ���u, ���u�m�W";
            groupTable = groupTable.DefaultView.ToTable();

            //��C�Ӥ��նi��ƾڶ�J
            foreach (DataRow groupRow in groupTable.Rows)
            {
                string selFilter = "���u='" + groupRow["���u"] + "' AND ���u�m�W = '" + groupRow["���u�m�W"] + "'";
                
                DataRow newRow = _table.NewRow();

                if (groupRow.IsNull("�ɤJ���u"))
                {
                    newRow["���u"] = groupRow["���u"];
                    selFilter += " AND �ɤJ���u IS NULL ";
                }
                else
                {
                    newRow["���u"] = groupRow["�ɤJ���u"];
                    newRow["�ɤJ"] = groupRow["���u"];
                    selFilter += " AND �ɤJ���u = '" + groupRow["�ɤJ���u"] + "'";
                }

                DataRow[] rows = srcTable.Select(selFilter);

                newRow["���u�W��"] = groupRow["���u�m�W"].ToString();

                decimal pHour = 0, npHour = 0;

                //���ݩ�Ӥ��ժ�Row�i���J
                foreach (DataRow srcRow in rows)
                {
                    int np = (int)srcRow["�D�Ͳ��s��"];
                    decimal hour = (decimal)srcRow["�u��"];

                    //���Ͳ��u��
                    if (np == -1)
                    {
                        pHour += hour;
                    }
                    else
                    {
						//�D�Ͳ��u��
						if (NpDic.ContainsKey(np) )
						{
							if(NpDic[np] != "np�а�")
								npHour += hour;

							newRow[NpDic[np]] = (decimal)newRow[NpDic[np]] + hour;
						}
                    }
                }
                decimal ttlHour = pHour + npHour;

                newRow["�Ͳ��u��"] = pHour;

				/* 1.08.4
                DataRow[] lwRows = lwTable.Select("���u�m�W = '" + groupRow["���u�m�W"].ToString() + "'");
                if (lwRows.Length > 0)
                    newRow["�~�]�u��"] = (decimal)lwRows[0]["�u��"];
				*/

                _table.Rows.Add(newRow);
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
            // Create profile
            ReportSourceProfile profile = new ReportSourceProfile(_table);
            List<DataColumn> exclude = new List<DataColumn>();
            exclude.Add(_table.Columns["�ɤJ"]);
            profile.ExcludeExportColumn(exclude);
            this.SheetAdapter.ReportProfile = profile;
            // *****

            this.SheetAdapter.PasteColumns(_table, 3, 1);

            base.WriteColumnHeader();
        }

        protected override void WriteContent()
        {
            DataTable linesTable = DataTableHelper.SelectDistinct(_table, "���u");

            //�إ߼g�J�e�m�@�~
            int writeRow = 4;
            PasteDataRowsOptions options = new PasteDataRowsOptions();
            options.IncludeSummary = true;
			/* 1.08.4
            options.SummaryColumns.AddRange(new string[] { "�Ͳ��u��", "�~�]�u��" });*/
			options.SummaryColumns.AddRange(new string[] { "�Ͳ��u��"});
            options.ExcludeColumns.Add("�ɤJ");

            string[] npCols = new string[NpDic.Count];
            NpDic.Values.CopyTo(npCols, 0);
            options.SummaryColumns.AddRange(npCols);

            //��C�Ӳ��u
            foreach (DataRow lineRow in linesTable.Rows)
            {
                DataRow[] rows = _table.Select("���u = '" + lineRow["���u"] + "'", "���u�W��");

                //�g�J���e
                options.Row = writeRow;
                options.SummaryPrefix = lineRow["���u"] + "���u�p�p";

                foreach (DataRow row in rows)
                {
                    if (!row.IsNull("�ɤJ"))
                        row["���u"] = "�ɤJ" + row["�ɤJ"];
                }

                writeRow = this.SheetAdapter.PasteDataRows(rows, options);
            }

            //�g�J�`�p
            DataRow totalRow = _table.NewRow();
            totalRow[0] = "�`�p";
            foreach (string sumCol in options.SummaryColumns)
            {
                object o;
                o = _table.Compute("SUM([" + sumCol + "])", string.Empty);
                totalRow[sumCol] = Convert.IsDBNull(o) ? 0 : (decimal)o;
            }
            _table.Rows.Add(totalRow);

            writeRow = this.SheetAdapter.PasteDataRow(totalRow, writeRow, 1);

            //�]�w��ܮ榡
            foreach (string npCol in npCols)
                this.SheetAdapter.SetFormat(4, _table.Columns.IndexOf(npCol) + 1, "G/�q�ή榡;G/�q�ή榡;* \"-\"_-");

            this.SheetAdapter.SetFormat(4, _table.Columns.IndexOf("�Ͳ��u��") + 1, "G/�q�ή榡;G/�q�ή榡;* \"-\"_-");
            this.SheetAdapter.SetFormat(4, _table.Columns.IndexOf("�D�Ͳ�TTL") + 1, "G/�q�ή榡;G/�q�ή榡;* \"-\"_-");
            this.SheetAdapter.SetFormat(4, _table.Columns.IndexOf("�Ͳ�%") + 1, "0.00%");
            this.SheetAdapter.SetFormat(4, _table.Columns.IndexOf("�D�Ͳ�%") + 1, "0.00%");
            //this.SheetAdapter.SetFormat(4, _table.Columns.IndexOf("�~�]�u��") + 1, "#,##0.00;#,##0.00;* \"-\"_-");

            base.WriteContent();
        }

        protected override void AfterContentWritten()
        {
            //�]�w�~�[�˦�
            Range reportBodyRange = this.SheetAdapter.GetUsedRange(3);
            reportBodyRange.Columns.AutoFit();
            this.SheetAdapter.SetBorder(reportBodyRange, XlLineStyle.xlContinuous, XlBorderWeight.xlThin, true, true, true, true);

            base.AfterContentWritten();
        }

        void CreateReportTable()
        {
            _table = new DataTable();

            _table.Columns.Add(new DataColumn("���u", typeof(string)));
            _table.Columns.Add(new DataColumn("���u�W��", typeof(string)));

            DataColumn col�Ͳ��u�� = new DataColumn("�Ͳ��u��", typeof(decimal));
            col�Ͳ��u��.DefaultValue = 0;
            _table.Columns.Add(col�Ͳ��u��);

            DataColumn col�Ͳ� = new DataColumn("�Ͳ�%", typeof(double));
            _table.Columns.Add(col�Ͳ�);

			_table.Columns.Add(new DataColumn("�D�Ͳ�TTL", typeof(decimal)));
			_table.Columns.Add(new DataColumn("�D�Ͳ�%", typeof(double)));

            //���o�D�Ͳ�����
            foreach (string npCol in NpDic.Values)
            {
				DataColumn col = new DataColumn(npCol, typeof(decimal));
				col.Caption = npCol.Substring(2);
                col.DefaultValue = 0;
                _table.Columns.Add(col);
            }

			List<string> npColList = new List<string>(NpDic.Values);
			npColList.Remove("np�а�");
			for (int i = 0; i < npColList.Count; i++)
				npColList[i] = "[" + npColList[i] + "]";

			_table.Columns["�D�Ͳ�TTL"].Expression = string.Join("+", npColList.ToArray());

            col�Ͳ�.Expression = "IIF(�Ͳ��u�� + �D�Ͳ�TTL = 0,0,�Ͳ��u��/(�Ͳ��u�� + �D�Ͳ�TTL))";

            _table.Columns["�D�Ͳ�%"].Expression = "IIF(�Ͳ��u�� + �D�Ͳ�TTL = 0,0,�D�Ͳ�TTL/(�Ͳ��u�� + �D�Ͳ�TTL))";

			if (_table.Columns.Contains("np�а�"))
				_table.Columns["np�а�"].SetOrdinal(_table.Columns.Count - 1);

			/* 1.08.4
            DataColumn col�~�]�u�� = new DataColumn("�~�]�u��", typeof(decimal));
            col�~�]�u��.DefaultValue = 0;
            _table.Columns.Add(col�~�]�u��);
			*/

            _table.Columns.Add(new DataColumn("�ɤJ", typeof(string)));
        }

        #region IFormSettable ����

        public void OpenForm()
        {
            DateForm form = new DateForm();
            form.Text = this.Name;
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
