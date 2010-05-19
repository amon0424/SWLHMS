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
					throw new SWLHMSException("找不到 " + cbxWorksheets.SelectedText + " 工作表");
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
            table.Columns.Add(new DataColumn("名稱", typeof(string)));
            table.Columns.Add(new DataColumn("索引", typeof(int)));

            string[] columns = CaseLib.GetHeaders(_sheet, 1);
            for (int i = 0; i < columns.Length; i++)
            {
                if (columns[i] == null || columns[i].Trim() == string.Empty)
                    continue;
                DataRow row = table.NewRow();
                row["名稱"] = columns[i];
                row["索引"] = i + 1;
                table.Rows.Add(row);
            }

            return table;
        }

        void AutoFill(DataTable sourceTable)
        {
            foreach(DataRow row in sourceTable.Rows)
            {
                string srcName = (string)row["名稱"];
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
            table.Columns.Add(new DataColumn("名稱", typeof(string)));
            table.Columns.Add(new DataColumn("來源", typeof(string)));
            table.Columns.Add(new DataColumn("索引", typeof(int)));
            table.Columns["索引"].DefaultValue = 0;

            string[] cols = new string[] { "系列編號","系列代號", "品號", "品名", "產線", "工時", "系統時薪" };
            string[] keys = new string[] { "編號", "代號", "品號", "品名", "產線", "工時", "單位標準工資" };

            _dstRowList.Clear();
            _dstRowKeywordList.Clear();
            for(int i=0;i<cols.Length;i++)
            {
                string col = cols[i];

                DataRow row = table.NewRow();
                row["名稱"] = col;
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
                dstRow.Cells["col來源名稱"].Value = srcRow.Cells["colSrcColName"].Value;
                dstRow.Cells["col來源索引"].Value = srcRow.Cells["colSrcColIndex"].Value;
            }
        }

        void MoveSrcColumnToDst(DataRow srcRow, DataRow dstRow)
        {
            if (srcRow != null && dstRow != null)
            {
                dstRow["來源"] = srcRow["名稱"];
                dstRow["索引"] = srcRow["索引"];
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

            int serialNoCol = (int)_dstRowList["系列編號"]["索引"];
            int serialCodeNameCol = (int)_dstRowList["系列代號"]["索引"];
            //int serialNameCol = (int)_dstRowList["系列名稱"]["索引"];
            int partNoCol = (int)_dstRowList["品號"]["索引"];
            int partNameCol = (int)_dstRowList["品名"]["索引"];
            int lineCol = (int)_dstRowList["產線"]["索引"];
            int laborHoursCol = (int)_dstRowList["工時"]["索引"];
			int laborCostCol = (int)_dstRowList["系統時薪"]["索引"];
            //int wageCol = (int)_dstRowList["標準工資"]["索引"];
            

            this.BeginInvoke(new Action<string>(UpdateImportMessage),"從工作表擷取產品資料...");
            this.BeginInvoke(new Action<int>(InitProgressBar), _sheet.UsedRange.Rows.Count - 1);

            StringBuilder sbEx = new StringBuilder();

            DatabaseSet.產品品號DataTable updateTable = new DatabaseSet.產品品號DataTable();
            DatabaseSet.產品品號DataTable insertTable = new DatabaseSet.產品品號DataTable();
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
						catch (Exception) { throw new SWLHMSException("系列編號欄位格式錯誤"); }

                        string serialCodeName;
                        try { serialCodeName = sheetAdapter.GetValue<string>(i, serialCodeNameCol); }
						catch (Exception) { throw new SWLHMSException("系列代號欄位格式錯誤"); }

                        //string serialName = sheetAdapter.GetValue<string>(i, serialNameCol, false);
                        string partName = sheetAdapter.GetValue<string>(i, partNameCol, false);

                        string line;
                        try{ line = sheetAdapter.GetValue<string>(i, lineCol); }
						catch (Exception) { throw new SWLHMSException("產線欄位格式錯誤"); }

						if (!lineList.Contains(line))
							lineList.Add(line);

                        decimal laborHours;
                        try { laborHours = Convert.ToDecimal(sheetAdapter.GetValue<double>(i, laborHoursCol)); }
						catch (Exception) { throw new SWLHMSException("工時欄位格式錯誤"); }

						//decimal wage;
						//try { wage = Convert.ToDecimal(sheetAdapter.GetValue<double>(i, wageCol)); }
						//catch (Exception) { throw new Exception("標準工資欄位格式錯誤"); }

                        decimal laborCost;
                        try { laborCost = Convert.ToDecimal(sheetAdapter.GetValue<double>(i, laborCostCol)); }
						catch (Exception) { throw new SWLHMSException("單位標準工資欄位格式錯誤"); }

                        DatabaseSet.產品品號Row row;

                        // Make sure the serial exists
                        if (DatabaseSet.產品系列Table.Select("編號 = " + serialNo).Length == 0)
                        {
                            DatabaseSet.產品系列Row serialRow = DatabaseSet.產品系列Table.New產品系列Row();
                            serialRow.FillRow(serialNo,serialCodeName);
                            DatabaseSet.產品系列Table.Add產品系列Row(serialRow);

                            產品系列TableAdapter.Instance.Update(serialRow);

							newSerial.Add(serialNo);
                        }

                        // Get the conut of the part number from database
                        int? num = 產品品號TableAdapter.Instance.GetCountBy品號(partNubmer);

                        // Exists same part number
                        if (num != null && num > 0)
                        {
                            row = updateTable.New產品品號Row();
                            row.品號 = partNubmer;

                            updateTable.Add產品品號Row(row);
                            row.AcceptChanges();
                        }
                        else
                        {
                            row = insertTable.New產品品號Row();
                            row.品號 = partNubmer;

                            insertTable.Add產品品號Row(row);
                        }

                        row.系列編號 = serialNo;
                        row.品名 = partName;
                        row.產線 = line;
                        row.工時 = laborHours;
                        //row.標準工資 = wage;
						row.標準工資 = laborHours * laborCost;
                        row.單位標準工資 = laborCost;

                        // If part number is duplicated, use the latter
                        if (dic.ContainsKey(partNubmer))
                        {
                            sbEx.AppendLine("行 " + i + ": 品號 '" + partNubmer + "' 重複，採用後者資料儲存");
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
                    sbEx.AppendLine("行 " + i + ": 發生錯誤 " + ex.Message);
                }

                this.BeginInvoke(new MethodInvoker(progressBar1.PerformStep));

                if (errorBreak)
                    break;
            }

            StringBuilder sb = new StringBuilder();
            if (!errorBreak)
            {
                this.BeginInvoke(new Action<string>(UpdateImportMessage), "更新資料庫...");

				//檢查有無新增產線
				List<string> newLine = new List<string>();
				foreach (string l in lineList)
				{
					if (產線TableAdapter.Instance.CheckLineAndCreate(l))
						newLine.Add(l);
				}

                int updateCount = 產品品號TableAdapter.Instance.UpdateEx(updateTable);
                int insertCount = 產品品號TableAdapter.Instance.UpdateEx(insertTable);

                //產生報告
                sb.AppendLine("來源檔案: " + dic.Count + " 筆品號資料");
                sb.AppendLine("資料庫  : " + 產品品號TableAdapter.Instance.GetCount() + " 筆品號資料");
                sb.AppendLine("已更新  : " + updateCount + " 筆資料");
                sb.AppendLine("已新增  : " + insertCount + " 筆資料");

				if (newSerial.Count > 0)
				{
					List<string> list = new List<string>();
					foreach (int serial in newSerial)
						list.Add(serial.ToString());

					sb.AppendLine("建立了新系列  : " + string.Join(",", list.ToArray()));
				}
				if (newLine.Count > 0)
					sb.AppendLine("建立了新產線  : " + string.Join(",", newLine.ToArray()));
            }
            else
            {
                sb.AppendLine("發生錯誤太多，停止匯入");
            }

            if (sbEx.Length > 0)
            {
                sb.AppendLine("===錯誤===");
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
            lbUpdateMsg.Text = "匯入完畢，請點選下一步檢視匯入報告";
        }

        void ImportError()
        {
            wizard1.NextEnabled = true;
            lbUpdateMsg.Text = "匯入期間發生太多錯誤，請點選下一步檢視匯入報告";
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
                if ((int)row.Cells["col來源索引"].Value == 0)
                {
                    fillDone = false;
                    break;
                }
            }

            return fillDone;
        }

        private void ImportProductForm_Load(object sender, EventArgs e)
        {
            DatabaseSetTableAdapters.產品系列TableAdapter.Instance.Fill(DatabaseSet.產品系列Table);
        }
    }
}