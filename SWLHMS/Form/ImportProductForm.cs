using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Mong;
using Mong.DatabaseSetTableAdapters;
using Microsoft.Office.Interop.Excel;

using DataTable = System.Data.DataTable;

namespace Mong
{
    public partial class ImportProductForm : Form
    {
        Microsoft.Office.Interop.Excel.Application _app;
        Workbook _book;
        Worksheet _sheet;
        string _report;
        System.Threading.Thread _thread;

        public Microsoft.Office.Interop.Excel.Application App
        {
            get
            {
                if (_app == null)
                    _app = new Microsoft.Office.Interop.Excel.Application();
                return _app;
            }
            set { _app = value; }
        }

        public ImportProductForm()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbxSrcFile.Text = openFileDialog1.FileName;
            }
        }

        private void wizard1_Load(object sender, EventArgs e)
        {
            wizard1.NextEnabled = false;
        }

        private void wizard1_CloseFromCancel(object sender, CancelEventArgs e)
        {
            StopThread();
        }

        private void wizardPage2_ShowFromNext(object sender, EventArgs e)
        {
            wizard1.NextEnabled = false;

            string[] names = BookLib.GetWorksheetsName(App, tbxSrcFile.Text);

            cbxWorksheets.Items.Clear();
            foreach (string name in names)
            {
                cbxWorksheets.Items.Add(name);
            }
        }

        private void wizardPage3_ShowFromNext(object sender, EventArgs e)
        {
            try
            {
                wizard1.NextEnabled = false;

                dgvDstCol.DataSource = InitDstDataTable();

                _book = BookLib.OpenWorkbook(App, tbxSrcFile.Text,true);
                _sheet = _book.Sheets[cbxWorksheets.SelectedItem] as Worksheet;

                if (_sheet != null)
                {
                    DataTable table = AnalyzeSrcColumn(_sheet);
                    dgvSrcCol.DataSource = table;
                    AutoFill(table);
                    wizard1.NextEnabled = CheckColumnFillDone();
                }
                else
					throw new SWLHMSException("�䤣�� " + cbxWorksheets.SelectedText + " �u�@��");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void wizardPage4_ShowFromNext(object sender, EventArgs e)
        {
            wizard1.BackEnabled = false;
            wizard1.NextEnabled = false;

            _thread = new System.Threading.Thread(new System.Threading.ThreadStart(ImportProductsData));
            _thread.Start();
        }

        private void wizardPage5_ShowFromNext(object sender, EventArgs e)
        {
            wizard1.BackEnabled = false;
            tbxImportReport.Text = _report;
        }

        private void tbxSrcFile_TextChanged(object sender, EventArgs e)
        {
            wizard1.NextEnabled = System.IO.File.Exists(tbxSrcFile.Text);

        }

        private void ImportLHForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopThread();
            if (_app != null)
            {
                _app.DisplayAlerts = false;
                _app.Quit();
                _app = null;
            }
        }

        private void cbxWorksheets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxWorksheets.SelectedIndex != -1)
                wizard1.NextEnabled = true;
        }

        private void dgvSrcCol_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dgvSrcCol.DoDragDrop(dgvSrcCol.CurrentRow, DragDropEffects.Move);
            }
        }

        private void dgvDstCol_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void dgvDstCol_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Effect == DragDropEffects.Move)
            {
                if (e.Data.GetDataPresent(typeof(DataGridViewRow)))
                {
                    DataGridViewRow row = e.Data.GetData(typeof(DataGridViewRow)) as DataGridViewRow;
                    System.Drawing.Point p = dgvDstCol.PointToClient(new System.Drawing.Point(e.X, e.Y));
                    DataGridView.HitTestInfo hit = dgvDstCol.HitTest(p.X, p.Y);
                    if (hit.Type == DataGridViewHitTestType.Cell)
                    {
                        try
                        {
                            DataGridViewRow dstRow = dgvDstCol.Rows[hit.RowIndex];
                            MoveSrcColumnToDst(row, dstRow);
                        }
                        catch (Exception) { }
                    }
                }
            }
        }

        private void dgvDstCol_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            wizard1.NextEnabled = CheckColumnFillDone();
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            MoveSrcColumnToDst(dgvSrcCol.CurrentRow, dgvDstCol.CurrentRow);
        }

        DataTable AnalyzeSrcColumn(Worksheet sheet)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add(new DataColumn("�W��", typeof(string)));
            table.Columns.Add(new DataColumn("����", typeof(int)));

            string[] columns = CaseLib.GetHeaders(_sheet, 1);
            for (int i = 0; i < columns.Length; i++)
            {
                if (columns[i] == null || columns[i].Trim() == string.Empty)
                    continue;
                DataRow row = table.NewRow();
                row["�W��"] = columns[i];
                row["����"] = i + 1;
                table.Rows.Add(row);
            }

            return table;
        }

        void AutoFill(DataTable sourceTable)
        {
            foreach(DataRow row in sourceTable.Rows)
            {
                string srcName = (string)row["�W��"];
                foreach (KeyValuePair<string,string> kv in _dstRowKeywordList)
                {
                    if (srcName.Contains(kv.Value))
                        MoveSrcColumnToDst(row, _dstRowList[kv.Key]);
                }
            }
        }

        Dictionary<string, DataRow> _dstRowList = new Dictionary<string, DataRow>();
        Dictionary<string, string> _dstRowKeywordList = new Dictionary<string, string>();

        DataTable InitDstDataTable()
        {
            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add(new DataColumn("�W��", typeof(string)));
            table.Columns.Add(new DataColumn("�ӷ�", typeof(string)));
            table.Columns.Add(new DataColumn("����", typeof(int)));
            table.Columns["����"].DefaultValue = 0;

            string[] cols = new string[] { "�t�C�s��","�t�C�N��", "�~��", "�~�W", "���u", "�u��", "�t�ή��~" };
            string[] keys = new string[] { "�s��", "�N��", "�~��", "�~�W", "���u", "�u��", "���зǤu��" };

            _dstRowList.Clear();
            _dstRowKeywordList.Clear();
            for(int i=0;i<cols.Length;i++)
            {
                string col = cols[i];

                DataRow row = table.NewRow();
                row["�W��"] = col;
                table.Rows.Add(row);
                _dstRowList.Add(col, row);
                _dstRowKeywordList.Add(col, keys[i]);
            }

            return table;
        }

        void MoveSrcColumnToDst(DataGridViewRow srcRow, DataGridViewRow dstRow)
        {
            if (srcRow != null && dstRow != null)
            {
                dstRow.Cells["col�ӷ��W��"].Value = srcRow.Cells["colSrcColName"].Value;
                dstRow.Cells["col�ӷ�����"].Value = srcRow.Cells["colSrcColIndex"].Value;
            }
        }

        void MoveSrcColumnToDst(DataRow srcRow, DataRow dstRow)
        {
            if (srcRow != null && dstRow != null)
            {
                dstRow["�ӷ�"] = srcRow["�W��"];
                dstRow["����"] = srcRow["����"];
            }
        }

        void InitProgressBar(int max)
        {
            progressBar1.Maximum = max;
            progressBar1.Value = 0;
        }
        
        void ImportProductsData()
        {
            WorksheetAdapter sheetAdapter = new WorksheetAdapter(_sheet);

            Dictionary<string, DataRow> dic = new Dictionary<string, DataRow>();
            
            DataTable dstTable = (DataTable)dgvDstCol.DataSource;

            int serialNoCol = (int)_dstRowList["�t�C�s��"]["����"];
            int serialCodeNameCol = (int)_dstRowList["�t�C�N��"]["����"];
            //int serialNameCol = (int)_dstRowList["�t�C�W��"]["����"];
            int partNoCol = (int)_dstRowList["�~��"]["����"];
            int partNameCol = (int)_dstRowList["�~�W"]["����"];
            int lineCol = (int)_dstRowList["���u"]["����"];
            int laborHoursCol = (int)_dstRowList["�u��"]["����"];
			int laborCostCol = (int)_dstRowList["�t�ή��~"]["����"];
            //int wageCol = (int)_dstRowList["�зǤu��"]["����"];
            

            this.BeginInvoke(new Action<string>(UpdateImportMessage),"�q�u�@���^�����~���...");
            this.BeginInvoke(new Action<int>(InitProgressBar), _sheet.UsedRange.Rows.Count - 1);

            StringBuilder sbEx = new StringBuilder();

            DatabaseSet.���~�~��DataTable updateTable = new DatabaseSet.���~�~��DataTable();
            DatabaseSet.���~�~��DataTable insertTable = new DatabaseSet.���~�~��DataTable();
			List<string> lineList = new List<string>();
			List<int> newSerial = new List<int>();

            bool errorBreak = false ;
            int errorCount = 0;
            int errorMax = 50;

            for (int i = 2; i <= _sheet.UsedRange.Rows.Count; i++)
            {
                try
                {
                    string partNubmer = sheetAdapter.GetNotEmptyString(i, partNoCol);

                    if (partNubmer != null)
                    {
                        int serialNo;
                        try { serialNo = sheetAdapter.GetValue<int>(i, serialNoCol); }
						catch (Exception) { throw new SWLHMSException("�t�C�s�����榡���~"); }

                        string serialCodeName;
                        try { serialCodeName = sheetAdapter.GetValue<string>(i, serialCodeNameCol); }
						catch (Exception) { throw new SWLHMSException("�t�C�N�����榡���~"); }

                        //string serialName = sheetAdapter.GetValue<string>(i, serialNameCol, false);
                        string partName = sheetAdapter.GetValue<string>(i, partNameCol, false);

                        string line;
                        try{ line = sheetAdapter.GetValue<string>(i, lineCol); }
						catch (Exception) { throw new SWLHMSException("���u���榡���~"); }

						if (!lineList.Contains(line))
							lineList.Add(line);

                        decimal laborHours;
                        try { laborHours = Convert.ToDecimal(sheetAdapter.GetValue<double>(i, laborHoursCol)); }
						catch (Exception) { throw new SWLHMSException("�u�����榡���~"); }

						//decimal wage;
						//try { wage = Convert.ToDecimal(sheetAdapter.GetValue<double>(i, wageCol)); }
						//catch (Exception) { throw new Exception("�зǤu�����榡���~"); }

                        decimal laborCost;
                        try { laborCost = Convert.ToDecimal(sheetAdapter.GetValue<double>(i, laborCostCol)); }
						catch (Exception) { throw new SWLHMSException("���зǤu�����榡���~"); }

                        DatabaseSet.���~�~��Row row;

                        // Make sure the serial exists
                        if (DatabaseSet.���~�t�CTable.Select("�s�� = " + serialNo).Length == 0)
                        {
                            DatabaseSet.���~�t�CRow serialRow = DatabaseSet.���~�t�CTable.New���~�t�CRow();
                            serialRow.FillRow(serialNo,serialCodeName);
                            DatabaseSet.���~�t�CTable.Add���~�t�CRow(serialRow);

                            ���~�t�CTableAdapter.Instance.Update(serialRow);

							newSerial.Add(serialNo);
                        }

                        // Get the conut of the part number from database
                        int? num = ���~�~��TableAdapter.Instance.GetCountBy�~��(partNubmer);

                        // Exists same part number
                        if (num != null && num > 0)
                        {
                            row = updateTable.New���~�~��Row();
                            row.�~�� = partNubmer;

                            updateTable.Add���~�~��Row(row);
                            row.AcceptChanges();
                        }
                        else
                        {
                            row = insertTable.New���~�~��Row();
                            row.�~�� = partNubmer;

                            insertTable.Add���~�~��Row(row);
                        }

                        row.�t�C�s�� = serialNo;
                        row.�~�W = partName;
                        row.���u = line;
                        row.�u�� = laborHours;
                        //row.�зǤu�� = wage;
						row.�зǤu�� = laborHours * laborCost;
                        row.���зǤu�� = laborCost;

                        // If part number is duplicated, use the latter
                        if (dic.ContainsKey(partNubmer))
                        {
                            sbEx.AppendLine("�� " + i + ": �~�� '" + partNubmer + "' ���ơA�ĥΫ�̸���x�s");
                            dic[partNubmer] = row;
                        }
                        else
                            dic.Add(partNubmer, row);
                    }
                }
                catch (Exception ex)
                {
                    if (errorCount++ > errorMax)
                        errorBreak = true;
                    sbEx.AppendLine("�� " + i + ": �o�Ϳ��~ " + ex.Message);
                }

                this.BeginInvoke(new MethodInvoker(progressBar1.PerformStep));

                if (errorBreak)
                    break;
            }

            StringBuilder sb = new StringBuilder();
            if (!errorBreak)
            {
                this.BeginInvoke(new Action<string>(UpdateImportMessage), "��s��Ʈw...");

				//�ˬd���L�s�W���u
				List<string> newLine = new List<string>();
				foreach (string l in lineList)
				{
					if (���uTableAdapter.Instance.CheckLineAndCreate(l))
						newLine.Add(l);
				}

                int updateCount = ���~�~��TableAdapter.Instance.UpdateEx(updateTable);
                int insertCount = ���~�~��TableAdapter.Instance.UpdateEx(insertTable);

                //���ͳ��i
                sb.AppendLine("�ӷ��ɮ�: " + dic.Count + " ���~�����");
                sb.AppendLine("��Ʈw  : " + ���~�~��TableAdapter.Instance.GetCount() + " ���~�����");
                sb.AppendLine("�w��s  : " + updateCount + " �����");
                sb.AppendLine("�w�s�W  : " + insertCount + " �����");

				if (newSerial.Count > 0)
				{
					List<string> list = new List<string>();
					foreach (int serial in newSerial)
						list.Add(serial.ToString());

					sb.AppendLine("�إߤF�s�t�C  : " + string.Join(",", list.ToArray()));
				}
				if (newLine.Count > 0)
					sb.AppendLine("�إߤF�s���u  : " + string.Join(",", newLine.ToArray()));
            }
            else
            {
                sb.AppendLine("�o�Ϳ��~�Ӧh�A����פJ");
            }

            if (sbEx.Length > 0)
            {
                sb.AppendLine("===���~===");
                sb.AppendLine(sbEx.ToString());
            }

            _report = sb.ToString();

            if (!errorBreak)
                this.BeginInvoke(new MethodInvoker(ImportDone));
            else
                this.BeginInvoke(new MethodInvoker(ImportError));
        }

        void UpdateImportMessage(string text)
        {
            lbUpdateMsg.Text = text;
        }

        void ImportDone()
        {
            wizard1.NextEnabled = true;
            lbUpdateMsg.Text = "�פJ�����A���I��U�@�B�˵��פJ���i";
        }

        void ImportError()
        {
            wizard1.NextEnabled = true;
            lbUpdateMsg.Text = "�פJ�����o�ͤӦh���~�A���I��U�@�B�˵��פJ���i";
        }

        void StopThread()
        {
            if (_thread != null && _thread.IsAlive)
            {
                _thread.Abort();
                _thread.Join();
            }
        }

        bool CheckColumnFillDone()
        {
            bool fillDone = true;
            foreach (DataGridViewRow row in dgvDstCol.Rows)
            {
                if ((int)row.Cells["col�ӷ�����"].Value == 0)
                {
                    fillDone = false;
                    break;
                }
            }

            return fillDone;
        }

        private void ImportProductForm_Load(object sender, EventArgs e)
        {
            DatabaseSetTableAdapters.���~�t�CTableAdapter.Instance.Fill(DatabaseSet.���~�t�CTable);
        }
    }
}