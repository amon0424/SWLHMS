using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Data;

using Microsoft.Office.Interop.Excel;

using Mong.Report;

using DataTable = System.Data.DataTable;

namespace Mong
{
    class WorksheetAdapter
    {
        object Missing = System.Reflection.Missing.Value;

        Worksheet _sheet;
        ReportSourceProfile _reportProfile = new ReportSourceProfile();

        Application Application
        {
            get
            {
                return Worksheet.Application;
            }
        }
        public Worksheet Worksheet
        {
            get
            {
                if (_sheet == null)
					throw new SWLHMSException("尚未設置Worksheet");
                return _sheet;
            }
            set { _sheet = value; }
        }
        public ReportSourceProfile ReportProfile
        {
            get 
            {
                return _reportProfile; 
            }
            set { _reportProfile = value; }
        }

        public object this[int row,int col]
        {
            get
            {
                return _sheet.Cells[row, col];
            }
            set
            {
                _sheet.Cells[row, col] = value;
            }
        }
        public object this[Range range]
        {
            get
            {
                return range.get_Value(XlRangeValueDataType.xlRangeValueDefault);
            }
            set
            {
                range.set_Value(XlRangeValueDataType.xlRangeValueDefault, value);
            }
        }

        public int UsedRowsCount
        {
            get
            {
                return _sheet.UsedRange.Rows.Count;
            }
        }
        public int UsedColumnsCount
        {
            get
            {
                return _sheet.UsedRange.Columns.Count;
            }
        }

        public WorksheetAdapter()
        {
        }

        public WorksheetAdapter(Worksheet sheet)
        {
            _sheet = sheet;
        }

        /// <summary>
        /// 取得儲存格內容
        /// </summary>
        public object GetValue(int row, int col)
        {
            return ((Range)_sheet.Cells[row, col]).get_Value(Missing);
        }

        /// <summary>
        /// 取得強型別儲存格內容
        /// </summary>
        public T GetValue<T>(int row, int col)
        {
            return GetValue<T>(row, col, true);
        }

        /// <summary>
        /// 取得強型別儲存格內容，並指定當型別不符合時是否擲出例外
        /// </summary>
        public T GetValue<T>(int row, int col, bool throwException)
        {
            try
            {
                object o = GetValue(row, col);

                if (typeof(T) == typeof(string))
                {
                    if (o is string)
                        return (T)o;
                    else
                    {
                        if (o == null && !throwException)
                            return default(T);

                        return (T)((object)o.ToString());
                    }
                }
                if (typeof(T) == typeof(int))
                {
                    if (o is double)
                        return (T)(object)Convert.ToInt32(o);
                }

                return (T)o;
            }
            catch (Exception ex)
            {
                if (throwException)
                    throw ex;
                else
                    return default(T);
            }
        }

        /// <summary>
        /// 判斷儲存格是否為空
        /// </summary>
        public bool IsEmpty(int row, int col)
        {
            try
            {
                object val = GetValue(row, col);
                if (val == null)
                {
                    return true;
                }
                else
                {
                    if (((string)val).Trim() == string.Empty)
                        return true;
                    else
                        return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 取得指定儲存格的非空字串，否則傳回null
        /// </summary>
        public string GetNotEmptyString(int row, int col)
        {
            try
            {
                string retVal = GetValue<string>(row, col);
                if (retVal == null || retVal.Trim().Equals(string.Empty))
                    return null;
                return retVal;
            }
            catch { return null; }
        }

        /// <summary>
        /// 將DataTable貼到指定的Worksheet
        /// </summary>
        public int PasteDataTable(DataTable table, int row, int col)
        {
            int writeRow = row;

            PasteColumns(table, writeRow++, col);

            if (_reportProfile.IncludeFormula)
            {
                char prefix = '=';
                foreach (DataRow dr in table.Rows)
                {
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        if (dr[i].ToString()[0] == prefix)
                            ((Range)_sheet.Cells[writeRow, col + i]).Formula = dr[i];
                        else
                            _sheet.Cells[writeRow, col + i] = dr[i];
                    }
                    writeRow++;
                }
            }
            else
            {
                foreach (DataRow dr in table.Rows)
                {
                    writeRow = PasteDataRow(dr, writeRow, col);
                }
            }

            //設定外觀樣式
			int colNum = _reportProfile.Columns.Count;
			if (colNum == 0)
				colNum = table.Columns.Count;

			Range writeRange = GetRange(row, col, row + table.Rows.Count, col + colNum - 1);

            SetBorder(writeRange, XlLineStyle.xlContinuous, XlBorderWeight.xlThin, true, true, true, true);

            if (_reportProfile.ReportName != null)
            {
                _sheet.Name = _reportProfile.ReportName;
            }

            return writeRow;
        }

        /// <summary>
        /// 將資料列陣列貼到指定的Worksheet
        /// </summary>
        public int PasteDataRows(IEnumerable<DataRow> rows, int row, int col)
        {
            int writeRow = row;

            foreach (DataRow dr in rows)
            {
                writeRow = PasteDataRow(dr, writeRow, col);
            }

            return writeRow;
        }

        /// <summary>
        /// 將資料列陣列貼到指定的Worksheet
        /// </summary>
        public int PasteDataRows(DataRow[] rows, PasteDataRowsOptions options)
        {
            int writeRow = options.Row;
            int col = options.Column;

            //建立總和查詢Dictionary
            Dictionary<string, decimal> sumDic = null;
            if (options.IncludeSummary)
            {
                sumDic = new Dictionary<string, decimal>();
                foreach (string sumCol in options.SummaryColumns)
                    sumDic.Add(sumCol, 0);
            }

            //逐一將資料列貼上
            foreach (DataRow dr in rows)
            {
                //object[] objects = dr.ItemArray;
                //for (int i = 0; i < objects.Length; i++)
                //{
                //    _sheet.Cells[writeRow, col + i] = objects[i];
                //}

                writeRow = PasteDataRow(dr, writeRow, col, options);

                if (options.IncludeSummary)
                {
                    foreach (string sumCol in options.SummaryColumns)
                        sumDic[sumCol] += (Convert.IsDBNull(dr[sumCol]) ? 0 : Convert.ToDecimal(dr[sumCol]));
                }

                //writeRow++;
            }

            //產生總和列
            if (options.IncludeSummary && rows.Length > 0)
            {
                DataTable table = rows[0].Table.Clone();
                DataRow sumRow = table.NewRow();
                sumRow[0] = options.SummaryPrefix;

				foreach (string sumCol in options.SummaryColumns)
				{
					if (!string.IsNullOrEmpty(table.Columns[sumCol].Expression))
						table.Columns[sumCol].Expression = string.Empty;
					sumRow[sumCol] = sumDic[sumCol];
				}

				foreach (string noSumCol in options.NoSummaryColumns)
				{
					//if (!string.IsNullOrEmpty(table.Columns[sumCol].Expression))
					table.Columns[noSumCol].Expression = string.Empty;
					sumRow[noSumCol] = DBNull.Value;
				}

                table.Rows.Add(sumRow);
                writeRow = PasteDataRow(sumRow, writeRow, col);
                writeRow++;
                sumRow.Delete();
            }


            return writeRow;
        }

        /// <summary>
        /// 將資料列貼到指定的Worksheet
        /// </summary>
        public int PasteDataRow(DataRow dataRow, int row, int col)
        {
            return PasteDataRow(dataRow, row, col, null);
        }

        /// <summary>
        /// 將資料列貼到指定的Worksheet
        /// </summary>
        public int PasteDataRow(DataRow dataRow, int row, int col, PasteDataRowsOptions options)
        {
            object[] objects;

            if (_reportProfile.Table == null)
                objects = dataRow.ItemArray;
            else
            {
                List<object> objs = new List<object>();

				//for (int i = 0; i < dataRow.Table.Columns.Count; i++)
				//{
				//    DataColumn column = dataRow.Table.Columns[i];
				//    if (_reportProfile.Contains(column))
				//        objs.Add(dataRow[column]);
				//}

				foreach(ReportColumn rptCol in _reportProfile.Columns)
				{
					objs.Add(dataRow[rptCol.Column.ColumnName]);
				}

                objects = objs.ToArray();
            }

            Range writeRange = GetRange(row, col, row, col + objects.Length - 1);
            if (_reportProfile != null)
            {
                bool hoz = _reportProfile.HorizontalGrid;
                bool ver = _reportProfile.VerticalGrid;

                SetBorder(writeRange, hoz, hoz, ver, ver);
                if (ver)
                    SetBorder(writeRange, XlBordersIndex.xlInsideVertical);
            }

            this[writeRange] = objects;

            return row + 1;
        }

        /// <summary>
        /// 將DataTable中的欄位名稱貼到Worksheet
        /// </summary>
        public void PasteColumns(DataTable table, int row, int col)
        {
            List<string> columns = new List<string>();

			if (_reportProfile.Table == null)
			{
				foreach (DataColumn column in table.Columns)
					columns.Add(column.Caption);
			}
			else
			{
				foreach (ReportColumn rptCol in _reportProfile.Columns)
					columns.Add(rptCol.Name);
			}

            PasteColumns(columns.ToArray(), row, col);
        }

        /// <summary>
        /// 將DataTable中的欄位名稱貼到Worksheet
        /// </summary>
        public void PasteColumns(string[] columnsName, int row, int col)
        {
            Range headerRange = GetRange(row, col, row, col + columnsName.Length - 1);
            headerRange.Font.Bold = true;
            this[headerRange] = columnsName;

            bool hoz = _reportProfile.ColumnHeaderHGrid;
            bool ver = _reportProfile.ColumnHeaderVGrid;

            SetBorder(headerRange, hoz, hoz, ver, ver);
            if (ver)
                SetBorder(headerRange, XlBordersIndex.xlInsideVertical);

            headerRange.HorizontalAlignment = _reportProfile.ColumnHeaderHAlign;
        }

        public Range GetRange(int startRow, int startCol, int endRow, int endCol)
        {
            return _sheet.get_Range(_sheet.Cells[startRow, startCol], _sheet.Cells[endRow, endCol]);
        }

        public Range GetRange(int row, int col)
        {
            return (Range)_sheet.Cells[row, col];
        }

        public Range GetUsedRange(int startRow)
        {
            Range range = GetRange(startRow, 1, _sheet.UsedRange.Rows.Count, _sheet.UsedRange.Columns.Count);
            return range;
        }

        public void SetFormat(int startRow, int column, string format)
        {
            Range range = GetRange(startRow, column, _sheet.UsedRange.Rows.Count, column);
            range.NumberFormat = format;
        }

        /// <summary>
        /// 將欄位號碼轉成A1格式用的字串
        /// </summary>
        /// <param name="col">欄位編號</param>
        public string GetColumnLetter(int col)
        {
            StringBuilder sb = new StringBuilder();
            if (col > 26)
            {
                sb.Append((char)(64 + (int)((col - 1) / 26)));
            }
            sb.Append((char)(65 + (col - 1) % 26));

            return sb.ToString();
        }

        public void SetBorder(Range range, XlBordersIndex index)
        {
            SetBorder(range, index, XlLineStyle.xlContinuous, XlBorderWeight.xlThin);
        }

        public void SetBorder(Range range, XlBordersIndex index, XlBorderWeight weight)
        {
            SetBorder(range, index, XlLineStyle.xlContinuous, weight);
        }

        public void SetBorder(Range range, XlBordersIndex index, XlLineStyle lineStyle, XlBorderWeight weight)
        {
            range.Borders[index].LineStyle = lineStyle;
            range.Borders[index].Weight = weight;
        }

        public void SetBorder(Range range, bool top, bool bottom, bool left, bool right)
        {
            SetBorder(range, XlLineStyle.xlContinuous, XlBorderWeight.xlThin, top, bottom, left, right);
        }

        public void SetBorder(Range range, XlBorderWeight weight, bool top, bool bottom, bool left, bool right)
        {
            SetBorder(range, XlLineStyle.xlContinuous, weight, top, bottom, left, right);
        }

        public void SetBorder(Range range, XlLineStyle lineStyle, XlBorderWeight weight, bool top, bool bottom, bool left, bool right)
        {
            if (top)
                SetBorder(range, XlBordersIndex.xlEdgeTop, lineStyle, weight);
            if (bottom)
                SetBorder(range, XlBordersIndex.xlEdgeBottom, lineStyle, weight);
            if (left)
                SetBorder(range, XlBordersIndex.xlEdgeLeft, lineStyle, weight);
            if (right)
                SetBorder(range, XlBordersIndex.xlEdgeRight, lineStyle, weight);
        }

		public void RoundValues(int[] cols, int startRow, int decimals)
		{
			for (int i = startRow; i <= this.Worksheet.UsedRange.Rows.Count; i++)
			{
				Range rowRange = this.GetRange(i, 1, i, this.Worksheet.UsedRange.Columns.Count);
				object[,] vals = (object[,])rowRange.Value2;

				object val;
				foreach (int col in cols)
				{
					val = vals[1, col];
					try
					{
						double dVal = (double)val;
						dVal = Math.Round(dVal, decimals, MidpointRounding.AwayFromZero);
						vals[1, col] = dVal;
					}
					catch (Exception) { }
				}

				rowRange.Value2 = vals;
			}
		}
        
		public object RunMacro(string name, params object[] args)
        {
            object[] args30 = new object[30];
            for (int i = 0; i < 30; i++)
                args30[i] = Missing;
            args.CopyTo(args30, 0);

            return this.Application.Run(name, 
                args30[0], args30[1], args30[2], args30[3], args30[4], args30[5], args30[6], args30[7], args30[8], args30[9],
                args30[10], args30[11],args30[12], args30[13], args30[14], args30[15], args30[16], args30[17], args30[18], args30[19],
                args30[20], args30[21], args30[22], args30[23], args30[24], args30[25], args30[26], args30[27], args30[28], args30[29]);
        }

		public Range UnionRange(Range range1, Range range2, params object[] args)
		{
			object[] args30 = new object[28];

			for (int i = 0; i < 28; i++)
				args30[i] = Missing;
			args.CopyTo(args30, 0);

			return this.Application.Union(range1, range2, args30[0], args30[1], args30[2], args30[3], args30[4], args30[5], args30[6], args30[7], args30[8], args30[9],
				args30[10], args30[11], args30[12], args30[13], args30[14], args30[15], args30[16], args30[17], args30[18], args30[19],
				args30[20], args30[21], args30[22], args30[23], args30[24], args30[25], args30[26], args30[27]);
		}

    }

    public class PasteDataTableOptions
    {
        int _row;
        int _column;
        bool _columnHeaderBold;
        bool _columnHeaderButtomBorder;
        bool _includeFormula;
        string _sheetName;

        public int Row
        {
            get { return _row; }
            set { _row = value; }
        }
        public int Column
        {
            get { return _column; }
            set { _column = value; }
        }
        public bool ColumnHeaderBold
        {
            get { return _columnHeaderBold; }
            set { _columnHeaderBold = value; }
        }
        public bool ColumnHeaderButtomBorder
        {
            get { return _columnHeaderButtomBorder; }
            set { _columnHeaderButtomBorder = value; }
        }
        public bool IncludeFormula
        {
            get { return _includeFormula; }
            set { _includeFormula = value; }
        }
        public string SheetName
        {
            get { return _sheetName; }
            set { _sheetName = value; }
        }
    }

    public class PasteDataRowsOptions
    {
        int _row = 1;
        int _column = 1;
        bool _includeSummary;
        string _summaryPrefix;
        List<string> _summaryColumns;
		List<string> _noSummaryColumns;
        List<string> _excludeColumns;

        public int Row
        {
            get { return _row; }
            set { _row = value; }
        }
        public int Column
        {
            get { return _column; }
            set { _column = value; }
        }
        public List<string> SummaryColumns
        {
            get
            {
                if (_summaryColumns == null)
                {
                    _summaryColumns = new List<string>();
                    _includeSummary = true;
                }

                return _summaryColumns;
            }
            set { _summaryColumns = value; }
        }
		public List<string> NoSummaryColumns
		{
			get
			{
				if (_noSummaryColumns == null)
				{
					_noSummaryColumns = new List<string>();
				}
				return _noSummaryColumns;
			}
			set { _noSummaryColumns = value; }
		}
        public List<string> ExcludeColumns
        {
            get
            {
                if (_excludeColumns == null)
                    _excludeColumns = new List<string>();

                return _excludeColumns;
            }
            set { _excludeColumns = value; }
        }
        public string SummaryPrefix
        {
            get
            {
                if (_summaryPrefix == null)
                    return "小計";
                else
                    return _summaryPrefix;
            }
            set { _summaryPrefix = value; }
        }
        public bool IncludeSummary
        {
            get { return _includeSummary; }
            set { _includeSummary = value; }
        }
    }
}
