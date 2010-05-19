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
        /// �q���w��Worksheet�����R�X���W�ٰ}�C
        /// </summary>
        public static string[] GetHeaders(Worksheet sheet, out int headerRow)
        {
            headerRow = 0;
            try
            {
                int colCount = sheet.UsedRange.Columns.Count;
                int rowCount = sheet.UsedRange.Rows.Count;
                string[] headers = null;
                //�v�C
                for (int i = 1; i <= rowCount; i++)
                {
                    int j;
                    //�v��
                    for (j = 1; j <= colCount; j++)
                    {
                        //��o�{�@��null�K���A�ˬd
                        if (BookLib.GetValue(sheet, i, j) == null)
                            break;
                    }
                    //�p�G���F
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
                Debug.WriteLine("GetHeaders�o�ͨҥ~: " + ex.Message);
				throw new SWLHMSException("�^�����W�ٮɵo�Ϳ��~�A���ˬd�u�@���O�t�����T������T");
            }
        }

        /// <summary>
        /// �q���w��Worksheet�����X���W�ٰ}�C
        /// </summary>
        /// <param name="headerRow">���w�^�����C��</param>
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
                Debug.WriteLine("GetHeaders�o�ͨҥ~: " + ex.Message);
				throw new SWLHMSException("�^�����W�ٮɵo�Ϳ��~�A���ˬd�u�@���O�t�����T������T");
            }
        }

        /// <summary>
        /// �q���w��Worksheet���R���̾���(basisCol)���Ȭ����ƪ��C
        /// </summary>
        /// <param name="basisCol">�̾���A�]�t�ΨӧP�_�O�_���ƪ��r��</param>
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
                    //���ˬd�O�_���P�˪��ȦbList��
                    if (!list.Contains(basisVal))
                    {
                        //�p�G�S�� �إ߷s���[�J
                        list.Add(basisVal);
                    }
                    else
                    {
                        //�p�G�� �R���ӦC
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
                //�q�u�@�����
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
        /// �q���w��Worksheet���R���]�t����r���C
        /// </summary>
        /// <param name="keyword">����r</param>
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
