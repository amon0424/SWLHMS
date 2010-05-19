//Case Libraray 1.01

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.Collections;
using System.Data;
using System.Diagnostics;

namespace Mong
{
    public class CaseLib
    {
        public static object Missing = System.Reflection.Missing.Value;

        /// <summary>
        /// 從指定的Worksheet中分析出欄位名稱陣列
        /// </summary>
        public static string[] GetHeaders(Worksheet sheet, out int headerRow)
        {
            headerRow = 0;
            try
            {
                int colCount = sheet.UsedRange.Columns.Count;
                int rowCount = sheet.UsedRange.Rows.Count;
                string[] headers = null;
                //逐列
                for (int i = 1; i <= rowCount; i++)
                {
                    int j;
                    //逐欄
                    for (j = 1; j <= colCount; j++)
                    {
                        //當發現一個null便不再檢查
                        if (BookLib.GetValue(sheet, i, j) == null)
                            break;
                    }
                    //如果找到了
                    if (j == colCount + 1)
                    {
                        headerRow = i;
                        headers = GetHeaders(sheet, headerRow);
                        break;
                    }
                }

                return headers;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetHeaders發生例外: " + ex.Message);
				throw new SWLHMSException("擷取欄位名稱時發生錯誤，請檢查工作表中是含有正確的欄位資訊");
            }
        }

        /// <summary>
        /// 從指定的Worksheet中取出欄位名稱陣列
        /// </summary>
        /// <param name="headerRow">指定擷取的列號</param>
        public static string[] GetHeaders(Worksheet sheet, int headerRow)
        {
            try
            {
                int colCount = sheet.UsedRange.Columns.Count;
                string[] headers = new string[colCount];
                for (int j = 1; j <= colCount; j++)
                    headers[j - 1] = (string)BookLib.GetValue(sheet, headerRow, j);
                return headers;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetHeaders發生例外: " + ex.Message);
				throw new SWLHMSException("擷取欄位名稱時發生錯誤，請檢查工作表中是含有正確的欄位資訊");
            }
        }

        /// <summary>
        /// 從指定的Worksheet中刪除依據欄(basisCol)的值為重複的列
        /// </summary>
        /// <param name="basisCol">依據欄，包含用來判斷是否重複的字串</param>
        public static void RemoveRepeatItem(Worksheet sheet, int basisCol)
        {
            string basisVal = string.Empty;
            List<string> list = new List<string>();

            for (int i = 1; i <= sheet.UsedRange.Rows.Count; i++)
            {
                string tmp = BookLib.GetNotEmptyString(sheet, i, basisCol);
                if (tmp != null && tmp != basisVal)
                {
                    basisVal = tmp;
                    //先檢查是否有同樣的值在List裡
                    if (!list.Contains(basisVal))
                    {
                        //如果沒有 建立新的加入
                        list.Add(basisVal);
                    }
                    else
                    {
                        //如果有 刪除該列
                        ((Range)sheet.Rows[i, Missing]).EntireRow.Delete(XlDeleteShiftDirection.xlShiftUp);
                        i--;
                    }
                }
                else if (tmp != null)
                {
                    ((Range)sheet.Rows[i, Missing]).EntireRow.Delete(XlDeleteShiftDirection.xlShiftUp);
                    i--;
                }
            }

            list.Clear();
        }

        public static void RemoveRepeatItem(Worksheet sheet, Dictionary<int, Type> indexTypePairDic)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            foreach (KeyValuePair<int, Type> kv in indexTypePairDic)
                table.Columns.Add("C" + kv.Key.ToString(), kv.Value);

            for (int i = 1; i <= sheet.UsedRange.Rows.Count; i++)
            {
                //從工作表取值
                StringBuilder filterBudr = new StringBuilder(100);
                DataRow dr = table.NewRow();
                bool invaildRow = false;
                foreach (KeyValuePair<int, Type> kv in indexTypePairDic)
                {
                    if (BookLib.IsEmpty(sheet, i, kv.Key))
                    {
                        invaildRow = true;
                        break;
                    }
                    else
                    {
                        filterBudr.Append("C" + kv.Key.ToString() + "=");
                        if (kv.Value == typeof(string))
                        {
                            string val = BookLib.GetValue<string>(sheet, i, kv.Key);
                            filterBudr.Append("'" + val + "'");
                            dr["C" + kv.Key.ToString()] = val;
                        }
                        else
                        {
                            double val = BookLib.GetValue<double>(sheet, i, kv.Key);
                            filterBudr.Append(val.ToString());
                            dr["C" + kv.Key.ToString()] = val;
                        }
                        filterBudr.Append(" AND ");
                    }
                }
                if (!invaildRow)
                {
                    string filter = filterBudr.ToString();
                    if (filter.EndsWith("AND "))
                        filter = filter.Remove(filter.Length - 4, 4);

                    if (table.Select(filter).GetLength(0) == 0)
                    {
                        table.Rows.Add(dr);
                    }
                    else
                    {
                        ((Range)sheet.Rows[i, Missing]).EntireRow.Delete(XlDeleteShiftDirection.xlShiftUp);
                        i--;
                    }

                }
            }
        }

        /// <summary>
        /// 從指定的Worksheet中刪除包含關鍵字的列
        /// </summary>
        /// <param name="keyword">關鍵字</param>
        public static void RemoveRowIncludeKeyword(Worksheet sheet, string keyword)
        {
            Range find;
            find = sheet.Cells.Find(keyword, (Range)sheet.Cells[1, 1], Missing, Missing,
                                         Missing, XlSearchDirection.xlNext, Missing, Missing, Missing);
            while (find != null)
            {
                find.EntireRow.Delete(XlDeleteShiftDirection.xlShiftUp);
                find = sheet.Cells.FindNext(((Range)sheet.Cells[1, 1]));
            }
        }
    }
}
