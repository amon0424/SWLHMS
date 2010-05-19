//Excel Libraray 1.02.090408

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Data;

using Microsoft.Office.Interop.Excel;

using DataTable = System.Data.DataTable;

namespace Mong
{
    public class BookLib
    {
        public static object Missing = System.Reflection.Missing.Value;

        /// <summary>
        /// �}�ҫ��w�ɦW��Excel�u�@ï
        /// </summary>
        public static Workbook OpenWorkbook(Application app, string filename)
        {
            try
            {
                return app.Workbooks.Open(filename, Missing, Missing, Missing, Missing, Missing,
                                    Missing, Missing, Missing, Missing, Missing, Missing,
                                    Missing, Missing, Missing);
            }
            catch { return null; }
        }

        /// <summary>
        /// �}�ҫ��w�ɦW��Excel�u�@ï�A�ë��w��Ū���A
        /// </summary>
        public static Workbook OpenWorkbook(Application app, string filename,bool readOnly)
        {
            try
            {
                return app.Workbooks.Open(filename, Missing, readOnly, Missing, Missing, Missing,
                                    Missing, Missing, Missing, Missing, Missing, Missing,
                                    Missing, Missing, Missing);
            }
            catch { return null; }
        }

        /// <summary>
        /// �q���w���ɮפ��^���u�@���W��
        /// </summary>
        public static string[] GetWorksheetsName(Application app, string filename)
        {
           Workbook book = OpenWorkbook(app, filename, true);
           string[] names = new string[book.Worksheets.Count];
           for (int i = 0; i < names.Length; i++)
           {
               names[i] = (book.Worksheets[i+1] as Worksheet).Name;
           }
           book.Close(Missing,Missing,Missing);
           return names;
        }

        /// <summary>
        /// �x�s�u�@ï
        /// </summary>
        /// <param name="toSave">�n�x�s���u�@ï</param>
        /// <param name="filename">�ɦW</param>
        public static void SaveAs(Workbook toSave, string filename)
        {
            if (File.Exists(filename))
                File.Delete(filename);
            toSave.SaveAs(filename, Missing, Missing, Missing, Missing, Missing, XlSaveAsAccessMode.xlNoChange, Missing, Missing, Missing, Missing,Missing);
        }
        
        /// <summary>
        /// �إߤ@�ӼȦs��Excel�ɮװƥ�
        /// </summary>
        /// <returns>�Ȧs�ɪ����|</returns>
        public static string CreateTempBook(string srcFile)
        {
            try
            {
                File.Copy(srcFile, srcFile + ".tmp", true);
                srcFile += ".tmp";
                return srcFile;
            }
            catch
            {
				throw new SWLHMSException("�إ��ɮ� " + srcFile + ".tmp �ɵo�Ϳ��~\n���ˬd���ɮ׬O�_�}�Ҥ��A�p�G�O�������A�դ@��");
            }
        }

        /// <summary>
        /// ���o�x�s�椺�e
        /// </summary>
        public static object GetValue(Worksheet sheet, int row, int col)
        {
            return ((Range)sheet.Cells[row, col]).get_Value(Missing);
        }

        /// <summary>
        /// ���o�j���O�x�s�椺�e
        /// </summary>
        public static T GetValue<T>(Worksheet sheet, int row, int col)
        {
            return GetValue<T>(sheet, row, col, true);
        }

        /// <summary>
        /// ���o�j���O�x�s�椺�e�A�ë��w���O���ŦX�ɬO�_�Y�X�ҥ~
        /// </summary>
        public static T GetValue<T>(Worksheet sheet, int row, int col, bool throwException)
        {
            try
            {
                object o = GetValue(sheet, row, col);
                if (typeof(T) == typeof(string))
                {
                    if (o is string)
                        return (T)o;
                    else
                        return (T)((object)o.ToString());
                }
                if (typeof(T) == typeof(int))
                {
                    if(o is double)
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
        /// �P�_�x�s��O�_����
        /// </summary>
        public static bool IsEmpty(Worksheet sheet, int row, int col)
        {
            try
            {
                object val = ((Range)sheet.Cells[row, col]).get_Value(Missing);
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
        /// ���o���w�x�s�檺�D�Ŧr��A�_�h�Ǧ^null
        /// </summary>
        public static string GetNotEmptyString(Worksheet sheet, int row, int col)
        {
            try
            {
                string retVal = (string)((Range)sheet.Cells[row, col]).get_Value(Missing);
                if (retVal == null || retVal.Trim().Equals(string.Empty))
                    return null;
                return retVal;
            }
            catch { return null; }
        }

        /// <summary>
        /// �NDataTable�K����w��Worksheet
        /// </summary>
        public static void PasteDataTable(Worksheet sheet, System.Data.DataTable table, PasteDataTableOptions pasteOptions)
        {
            int row = pasteOptions.Row<1?1:pasteOptions.Row;
            int col = pasteOptions.Column<1?1:pasteOptions.Column;

            int writeRow = row;

            for (int i = 0; i < table.Columns.Count; i++)
            {
                DataColumn column = table.Columns[i];
                sheet.Cells[row, col + i] = column.ColumnName;
            }
            writeRow++;

            if (pasteOptions.IncludeFormula)
            {
                char prefix = '=';
                foreach (DataRow dr in table.Rows)
                {
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        if (dr[i].ToString()[0] == prefix)
                            ((Range)sheet.Cells[writeRow, col + i]).Formula = dr[i];
                        else
                            sheet.Cells[writeRow, col + i] = dr[i];
                    }
                    writeRow++;
                }
            }
            else
            {
                foreach (DataRow dr in table.Rows)
                {
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        sheet.Cells[writeRow, col + i] = dr[i];
                    }
                    writeRow++;
                }
            }

            //�]�w�~�[�˦�
            Range writeRange = sheet.get_Range(sheet.Cells[row, col], sheet.Cells[row + table.Rows.Count, col + table.Columns.Count - 1]);
            Range headerRange = sheet.get_Range(sheet.Cells[row, col], sheet.Cells[row, col + table.Columns.Count - 1]);

            SetBorder(writeRange, XlLineStyle.xlContinuous, XlBorderWeight.xlThin, true, true, true, true);

            headerRange.Font.Bold = pasteOptions.ColumnHeaderBold;

            if (pasteOptions.ColumnHeaderButtomBorder)
            {
                SetBorder(headerRange, XlBordersIndex.xlEdgeBottom, XlLineStyle.xlContinuous, XlBorderWeight.xlThin);
            }

            if (pasteOptions.SheetName != null)
            {
                sheet.Name = pasteOptions.SheetName;
            }

        }

        /// <summary>
        /// �N��ƦC�}�C�K����w��Worksheet
        /// </summary>
        public static int PasteDataRows(Worksheet sheet, System.Data.DataRow[] rows, int row, int col)
        {
            int writeRow = row;

            foreach (DataRow dr in rows)
            {
                writeRow = PasteDataRow(sheet, dr, writeRow, col);
                //object[] objects = dr.ItemArray;
                //for (int i = 0; i < objects.Length; i++)
                //{
                //    sheet.Cells[writeRow, col + i] = objects[i];
                //}
                //writeRow++;
            }

            return writeRow;
        }

        /// <summary>
        /// �N��ƦC�}�C�K����w��Worksheet
        /// </summary>
        public static int PasteDataRows(Worksheet sheet, System.Data.DataRow[] rows, PasteDataRowsOptions options)
        {
            int writeRow = options.Row;
            int col = options.Column;

            //�إ��`�M�d��Dictionary
            Dictionary<string, decimal> sumDic = null;
            if (options.IncludeSummary)
            {
                sumDic = new Dictionary<string, decimal>();
                foreach (string sumCol in options.SummaryColumns)
                    sumDic.Add(sumCol, 0);
            }
            
            //�v�@�N��ƦC�K�W
            foreach (DataRow dr in rows)
            {
                //object[] objects = dr.ItemArray;
                //for (int i = 0; i < objects.Length; i++)
                //{
                //    sheet.Cells[writeRow, col + i] = objects[i];
                //}

                writeRow = PasteDataRow(sheet, dr, writeRow, col);

                if (options.IncludeSummary)
                {
                    foreach (string sumCol in options.SummaryColumns)
                        sumDic[sumCol] += (Convert.IsDBNull(dr[sumCol]) ? 0 : (decimal)dr[sumCol]);
                }

                //writeRow++;
            }

            //�����`�M�C
            if (options.IncludeSummary && rows.Length > 0)
            {
                System.Data.DataTable table = rows[0].Table;
                DataRow sumRow = table.NewRow();
                sumRow[0] = options.SummaryPrefix;

                foreach (string sumCol in options.SummaryColumns)
                    sumRow[sumCol] = sumDic[sumCol];

                table.Rows.Add(sumRow);
                writeRow = PasteDataRow(sheet, sumRow, writeRow, col);
                writeRow++;
                sumRow.Delete();
            }


            return writeRow;
        }

        static Stopwatch sw = new Stopwatch();
        /// <summary>
        /// �N��ƦC�K����w��Worksheet
        /// </summary>
        public static int PasteDataRow(Worksheet sheet, DataRow dataRow, int row, int col)
        {
            object[] objects = dataRow.ItemArray;
            //for (int i = 0; i < objects.Length; i++)
            //{
            //    sheet.Cells[row, col + i] = objects[i];
            //}
            
            Range writeRange = ((Range)sheet.get_Range(sheet.Cells[row, col], sheet.Cells[row, col + objects.Length - 1]));
            writeRange.set_Value(XlRangeValueDataType.xlRangeValueDefault, objects);

            return row + 1;
        }

        /// <summary>
        /// �NDataTable�������W�ٶK��Worksheet
        /// </summary>
        public static void PasteColumns(Worksheet sheet, DataTable table, int row, int col)
        {
            string[] columns = new string[table.Columns.Count];

            for (int i = 0; i < table.Columns.Count; i++)
            {
                //sheet.Cells[row, col + i] = table.Columns[i].ColumnName;
                columns[i] = table.Columns[i].ColumnName;
            }

            Range headerRange = sheet.get_Range(sheet.Cells[row, col], sheet.Cells[row, col + table.Columns.Count - 1]);
            headerRange.set_Value(XlRangeValueDataType.xlRangeValueDefault, columns);
            headerRange.Font.Bold = true;
            SetBorder(headerRange, XlBordersIndex.xlEdgeBottom, XlLineStyle.xlContinuous, XlBorderWeight.xlThin);
        }

        /// <summary>
        /// �NDataTable�������W�ٶK��Worksheet
        /// </summary>
        public static void PasteColumns(Worksheet sheet, string[] columnsName, int row, int col)
        {
            for (int i = 0; i < columnsName.Length; i++)
            {
                sheet.Cells[row, col + i] = columnsName[i];
            }

            Range headerRange = sheet.get_Range(sheet.Cells[row, col], sheet.Cells[row, col + columnsName.Length - 1]);
            headerRange.Font.Bold = true;
            SetBorder(headerRange, XlBordersIndex.xlEdgeBottom, XlLineStyle.xlContinuous, XlBorderWeight.xlThin);
        }

        public static Range GetUsedRange(Worksheet sheet, int startRow)
        {
            Range range = sheet.get_Range(sheet.Cells[startRow, 1], sheet.Cells[sheet.UsedRange.Rows.Count, sheet.UsedRange.Columns.Count]);
            return range;
        }

        public static void SetFormat(Worksheet sheet, int startRow, int column, string format)
        {
            Range range = sheet.get_Range(sheet.Cells[startRow, column], sheet.Cells[sheet.UsedRange.Rows.Count, column]);
            range.NumberFormat = format;
        }

        /// <summary>
        /// �N��츹�X�নA1�榡�Ϊ��r��
        /// </summary>
        /// <param name="col">���s��</param>
        public static string GetColumnLetter(int col)
        {
            StringBuilder sb = new StringBuilder();
            if (col > 26)
            {
                sb.Append((char)(64 + (int)((col - 1) / 26)));
            }
            sb.Append((char)(65 + (col - 1) % 26));

            return sb.ToString();
        }

        public static void SetBorder(Range range, XlBordersIndex index, XlLineStyle lineStyle, XlBorderWeight weight)
        {
            range.Borders[index].LineStyle = lineStyle;
            range.Borders[index].Weight = weight;
        }

        public static void SetBorder(Range range, XlLineStyle lineStyle, XlBorderWeight weight, bool top, bool bottom, bool left, bool right)
        {
            if(top)
                SetBorder(range, XlBordersIndex.xlEdgeTop, lineStyle, weight);
            if(bottom)
                SetBorder(range, XlBordersIndex.xlEdgeBottom, lineStyle, weight);
            if(left)
                SetBorder(range, XlBordersIndex.xlEdgeLeft, lineStyle, weight);
            if(right)
                SetBorder(range, XlBordersIndex.xlEdgeRight, lineStyle, weight);
        }

        public static object RunMacro(ApplicationClass app, string name)
        {
            return app.Run(name, Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing,
                    Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing,
                    Missing, Missing, Missing, Missing, Missing, Missing);
        }

        public static object RunMacro1(ApplicationClass app, string name, object arg1)
        {
            return app.Run(name, arg1, Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing,
                    Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing,
                    Missing, Missing, Missing, Missing, Missing, Missing);
        }

        public static object RunMacro3(ApplicationClass app, string name, object arg1, object arg2, object arg3)
        {
            return app.Run(name, arg1, arg2, arg3, Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing,
                    Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing,
                    Missing, Missing, Missing, Missing, Missing, Missing);
        }

        public static object RunMacro10(ApplicationClass app, string name, object arg1, object arg2, object arg3,
                                        object arg4, object arg5, object arg6, object arg7, object arg8, object arg9, object arg10)
        {
            return app.Run(name, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, Missing, Missing,
                    Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing,
                    Missing, Missing, Missing, Missing, Missing, Missing);
        }

    }

 
}
