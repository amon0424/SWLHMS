using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using Mong.DatabaseSetTableAdapters;
namespace Mong
{
	[global::System.Serializable]
	public class SWLHMSException : Exception
	{
		public SWLHMSException() { }
		public SWLHMSException(string message) : base(message) { }
		public SWLHMSException(string message, Exception inner) : base(message, inner) { }
		protected SWLHMSException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context)
			: base(info, context) { }
	}

    static class Global
    {

        //public static DatabaseSet.產線DataTable DatabaseSet.產線Table
        //{
        //    get
        //    {
        //        if (!_產線TableLoad)
        //        {
        //            Adapter產線.Fill(DatabaseSet.Instance.產線);
        //            _產線TableLoad = true;
        //        }

        //        return DatabaseSet.Instance.產線;
        //    }
        //}

        //public static DatabaseSet.產品系列DataTable DatabaseSet.產品系列Table
        //{
        //    get
        //    {
        //        if (!_產品系列TableLoad)
        //        {
        //            Adapter產品系列.Fill(DatabaseSet.Instance.產品系列);
        //            _產品系列TableLoad = true;
        //        }

        //        return DatabaseSet.Instance.產品系列;
        //    }
        //}

        //public static DatabaseSet.產品品號DataTable DatabaseSet.產品品號Table
        //{
        //    get
        //    {
        //        if (!_產品品號TableLoad)
        //        {
        //            Adapter產品品號.Fill(DatabaseSet.Instance.產品品號);
        //            _產品品號TableLoad = true;
        //        }

        //        return DatabaseSet.Instance.產品品號;
        //    }
        //}

        //public static DatabaseSet.員工DataTable DatabaseSet.員工Table
        //{
        //    get
        //    {
        //        if (!_員工TableLoad)
        //        {
        //            Adapter員工.Fill(DatabaseSet.Instance.員工);
        //            _員工TableLoad = true;
        //        }

        //        return DatabaseSet.Instance.員工;
        //    }
        //}

        //public static DatabaseSet.非生產DataTable DatabaseSet.非生產Table
        //{
        //    get
        //    {
        //        if (!_非生產TableLoad)
        //        {
        //            Adapter非生產.Fill(DatabaseSet.Instance.非生產);
        //            _非生產TableLoad = true;
        //        }

        //        return DatabaseSet.Instance.非生產;
        //    }
        //}

        //public static DatabaseSet.假日ViewDataTable DatabaseSet.假日ViewTable
        //{
        //    get
        //    {
        //        return DatabaseSet.Instance.假日View;
        //    }
        //}

        //public static DatabaseSet.工作單DataTable DatabaseSet.工作單Table
        //{
        //    get
        //    {
        //        return DatabaseSet.Instance.工作單;
        //    }
        //}

        static Global()
        {
            
        }

        public static DatabaseSet.產品品號ViewDataTable Get產品品號ViewTable(int 系列編號)
        {
            產品品號ViewTableAdapter.Instance.FillBy系列編號(DatabaseSet.Instance.產品品號View, 系列編號);
            
            return DatabaseSet.Instance.產品品號View;
        }

        public static DatabaseSet.產品品號ViewDataTable Get產品品號ViewTable()
        {
            產品品號ViewTableAdapter.Instance.FillAll(DatabaseSet.Instance.產品品號View);
            
            return DatabaseSet.Instance.產品品號View;
        }

        public static DatabaseSet.假日DataTable Get假日Table(int year, int month)
        {
            假日TableAdapter.Instance.FillBy月份(DatabaseSet.Instance.假日, year, month);
            return DatabaseSet.Instance.假日;
        }

        public static DatabaseSet.假日ViewDataTable Get假日ViewTable(int year, int month)
        {
            //取得資料庫假日Table
            DatabaseSet.假日DataTable holidayTable = new DatabaseSet.假日DataTable();
            假日TableAdapter.Instance.FillBy月份(holidayTable, year, month);

            //建立回傳Table
            DatabaseSet.Instance.假日View.Clear();

            //建立取消週六日清單
            List<DateTime> cancelHolidays = new List<DateTime>();
            //判斷是增加還是取消
            foreach (DatabaseSet.假日Row row in holidayTable)
            {
                if (row.增加)
                {
                    DatabaseSet.假日ViewRow newRow = DatabaseSet.Instance.假日View.New假日ViewRow();
                    newRow.FillRow(row.日期, false);
                    DatabaseSet.Instance.假日View.Rows.Add(newRow);
                }
                else
                    cancelHolidays.Add(row.日期);
            }

            //將週六日加入
            int days = DateTime.DaysInMonth(year, month);
            for (int i = 1; i <= days; i++)
            {
                DateTime date = new DateTime(year, month, i);
                DayOfWeek dayofWeek = date.DayOfWeek;

                if (dayofWeek == DayOfWeek.Saturday || dayofWeek == DayOfWeek.Sunday)
                {
                    if (!cancelHolidays.Contains(date))
                    {
                        DatabaseSet.假日ViewRow newRow = DatabaseSet.Instance.假日View.New假日ViewRow();
                        newRow.FillRow(date, true);
                        DatabaseSet.Instance.假日View.Rows.Add(newRow);
                    }
                }
            }

            DatabaseSet.Instance.假日View.AcceptChanges();

            return DatabaseSet.Instance.假日View;
        }

        public static DatabaseSet.工作單DataTable Get工作單Table(string 單號, int dateType, DateTime from, DateTime to, int doneOrNot)
        {
            DatabaseSet.Instance.工作單.Clear();

            工作單TableAdapter.Instance.Fill(DatabaseSet.Instance.工作單, 單號, dateType, from, to, doneOrNot);

            return DatabaseSet.Instance.工作單;
        }

        public static decimal GetWorkingHours(int year, int month)
        {
            int holidays = 0;
            int days = DateTime.DaysInMonth(year, month);

            for (int i = 1; i <= days; i++)
            {
                DateTime date = new DateTime(year, month, i);
                DayOfWeek dayofWeek = date.DayOfWeek;

                if (dayofWeek == DayOfWeek.Saturday || dayofWeek == DayOfWeek.Sunday)
                {
                    holidays += 1;
                }
            }

            DatabaseSet.假日DataTable table = new DatabaseSet.假日DataTable();
            假日TableAdapter.Instance.FillBy月份(table, year, month);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                DateTime date = (DateTime)table[i]["日期"];
                if ((bool)table[i]["增加"])
                {
                    holidays += 1;
                }
                else
                {
                    holidays -= 1;
                }
            }

            int workDays = days - holidays;

            return workDays * Settings.WorkingHoursPerDay;
        }

        public static void ShowError(string message)
        {
            System.Windows.Forms.MessageBox.Show(message, "發生錯誤", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }

		public static void ShowError(Exception ex)
		{
			ShowError(ex.Message);
			Debug.WriteLine(ex.ToString());

			if (!(ex is SWLHMSException))
			{
				try
				{
					StreamWriter sw = new StreamWriter(new FileStream("err.log", FileMode.Append));
					//StreamWriter sw = File.CreateText("err.log");

					sw.WriteLine(DateTime.Now.ToString("------------------yyyy/MM/dd HH:mm:ss"));
					sw.WriteLine(ex.ToString());
					sw.WriteLine();
					sw.Close();
				}
				catch (Exception) { }
			}
		}

		public static string GenerateUniqueNumber()
		{
			DateTime date = DateTime.Now;
			string result = date.ToString("yyyyMMdd") + (date.TimeOfDay.TotalMilliseconds / 100).ToString("000000");
			return result;
		}

		public static bool ValidateString(string str)
		{
			return !System.Text.RegularExpressions.Regex.IsMatch(str, @"[\n\t\r~()#\\/=><+\-*%&|^'""\[\]]+");
		}
    }
}
