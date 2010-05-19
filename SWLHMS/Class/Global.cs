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

        //public static DatabaseSet.���uDataTable DatabaseSet.���uTable
        //{
        //    get
        //    {
        //        if (!_���uTableLoad)
        //        {
        //            Adapter���u.Fill(DatabaseSet.Instance.���u);
        //            _���uTableLoad = true;
        //        }

        //        return DatabaseSet.Instance.���u;
        //    }
        //}

        //public static DatabaseSet.���~�t�CDataTable DatabaseSet.���~�t�CTable
        //{
        //    get
        //    {
        //        if (!_���~�t�CTableLoad)
        //        {
        //            Adapter���~�t�C.Fill(DatabaseSet.Instance.���~�t�C);
        //            _���~�t�CTableLoad = true;
        //        }

        //        return DatabaseSet.Instance.���~�t�C;
        //    }
        //}

        //public static DatabaseSet.���~�~��DataTable DatabaseSet.���~�~��Table
        //{
        //    get
        //    {
        //        if (!_���~�~��TableLoad)
        //        {
        //            Adapter���~�~��.Fill(DatabaseSet.Instance.���~�~��);
        //            _���~�~��TableLoad = true;
        //        }

        //        return DatabaseSet.Instance.���~�~��;
        //    }
        //}

        //public static DatabaseSet.���uDataTable DatabaseSet.���uTable
        //{
        //    get
        //    {
        //        if (!_���uTableLoad)
        //        {
        //            Adapter���u.Fill(DatabaseSet.Instance.���u);
        //            _���uTableLoad = true;
        //        }

        //        return DatabaseSet.Instance.���u;
        //    }
        //}

        //public static DatabaseSet.�D�Ͳ�DataTable DatabaseSet.�D�Ͳ�Table
        //{
        //    get
        //    {
        //        if (!_�D�Ͳ�TableLoad)
        //        {
        //            Adapter�D�Ͳ�.Fill(DatabaseSet.Instance.�D�Ͳ�);
        //            _�D�Ͳ�TableLoad = true;
        //        }

        //        return DatabaseSet.Instance.�D�Ͳ�;
        //    }
        //}

        //public static DatabaseSet.����ViewDataTable DatabaseSet.����ViewTable
        //{
        //    get
        //    {
        //        return DatabaseSet.Instance.����View;
        //    }
        //}

        //public static DatabaseSet.�u�@��DataTable DatabaseSet.�u�@��Table
        //{
        //    get
        //    {
        //        return DatabaseSet.Instance.�u�@��;
        //    }
        //}

        static Global()
        {
            
        }

        public static DatabaseSet.���~�~��ViewDataTable Get���~�~��ViewTable(int �t�C�s��)
        {
            ���~�~��ViewTableAdapter.Instance.FillBy�t�C�s��(DatabaseSet.Instance.���~�~��View, �t�C�s��);
            
            return DatabaseSet.Instance.���~�~��View;
        }

        public static DatabaseSet.���~�~��ViewDataTable Get���~�~��ViewTable()
        {
            ���~�~��ViewTableAdapter.Instance.FillAll(DatabaseSet.Instance.���~�~��View);
            
            return DatabaseSet.Instance.���~�~��View;
        }

        public static DatabaseSet.����DataTable Get����Table(int year, int month)
        {
            ����TableAdapter.Instance.FillBy���(DatabaseSet.Instance.����, year, month);
            return DatabaseSet.Instance.����;
        }

        public static DatabaseSet.����ViewDataTable Get����ViewTable(int year, int month)
        {
            //���o��Ʈw����Table
            DatabaseSet.����DataTable holidayTable = new DatabaseSet.����DataTable();
            ����TableAdapter.Instance.FillBy���(holidayTable, year, month);

            //�إߦ^��Table
            DatabaseSet.Instance.����View.Clear();

            //�إߨ����g����M��
            List<DateTime> cancelHolidays = new List<DateTime>();
            //�P�_�O�W�[�٬O����
            foreach (DatabaseSet.����Row row in holidayTable)
            {
                if (row.�W�[)
                {
                    DatabaseSet.����ViewRow newRow = DatabaseSet.Instance.����View.New����ViewRow();
                    newRow.FillRow(row.���, false);
                    DatabaseSet.Instance.����View.Rows.Add(newRow);
                }
                else
                    cancelHolidays.Add(row.���);
            }

            //�N�g����[�J
            int days = DateTime.DaysInMonth(year, month);
            for (int i = 1; i <= days; i++)
            {
                DateTime date = new DateTime(year, month, i);
                DayOfWeek dayofWeek = date.DayOfWeek;

                if (dayofWeek == DayOfWeek.Saturday || dayofWeek == DayOfWeek.Sunday)
                {
                    if (!cancelHolidays.Contains(date))
                    {
                        DatabaseSet.����ViewRow newRow = DatabaseSet.Instance.����View.New����ViewRow();
                        newRow.FillRow(date, true);
                        DatabaseSet.Instance.����View.Rows.Add(newRow);
                    }
                }
            }

            DatabaseSet.Instance.����View.AcceptChanges();

            return DatabaseSet.Instance.����View;
        }

        public static DatabaseSet.�u�@��DataTable Get�u�@��Table(string �渹, int dateType, DateTime from, DateTime to, int doneOrNot)
        {
            DatabaseSet.Instance.�u�@��.Clear();

            �u�@��TableAdapter.Instance.Fill(DatabaseSet.Instance.�u�@��, �渹, dateType, from, to, doneOrNot);

            return DatabaseSet.Instance.�u�@��;
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

            DatabaseSet.����DataTable table = new DatabaseSet.����DataTable();
            ����TableAdapter.Instance.FillBy���(table, year, month);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                DateTime date = (DateTime)table[i]["���"];
                if ((bool)table[i]["�W�["])
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
            System.Windows.Forms.MessageBox.Show(message, "�o�Ϳ��~", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
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
