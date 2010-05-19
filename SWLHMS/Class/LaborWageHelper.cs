using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace Mong
{
    class LaborWageHelper
    {
        OleDbConnection _connection;
        OleDbDataAdapter _adapter;
        OleDbCommand _selectBy工作單號Cmd;

        public OleDbDataAdapter Adapter
        {
            get 
            {
                if (_adapter == null)
                    _adapter = new OleDbDataAdapter();
                return _adapter;
            }
            set { _adapter = value; }
        }
        public OleDbCommand SelectBy工作單號Cmd
        {
            get
            {
                if (_selectBy工作單號Cmd == null)
                {
                    _selectBy工作單號Cmd = new OleDbCommand();
                    _selectBy工作單號Cmd.CommandText = 
                                "SELECT D.工作單號, D.品號 AS 品號,D.工品編號, Sum(val(Format(D.QTY * P.UnitPrice,'#'))) AS 外包工資, " +
                                "P.UnitPrice AS 單位外包工資, Sum(D.QTY * 1000) as 數量 " +
                                "FROM (Data as D INNER JOIN Product as P ON D.產品編號 = P.編號 AND D.外包品名編號 = P.外包品名編號) " +
                                "WHERE 工作單號 = ? " +
								"GROUP BY D.工作單號, D.品號, P.UnitPrice, D.工品編號";
                    _selectBy工作單號Cmd.Connection = _connection;

                    _selectBy工作單號Cmd.Parameters.Add(new OleDbParameter("工作單號", OleDbType.VarWChar, 100));
                }
                return _selectBy工作單號Cmd;
            }
            set { _selectBy工作單號Cmd = value; }
        }

        public LaborWageHelper()
        {
            if (Settings.LaborWageDatabaseFile == string.Empty)
				throw new SWLHMSException("尚未設定LaborWage程式目錄，請至 功能表>設定 進行設定或聯絡系統管理員");

            string connStr = string.Format(
                "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Persist Security Info=True;OLE DB Services=-13;Jet OLEDB:Database Password=1234",
                Settings.LaborWageDatabaseFile);

            _connection = new OleDbConnection(connStr);
			try
			{
				_connection.Open();
			}
			catch (OleDbException ex) 
			{
				throw new SWLHMSException("LaborWage程式目錄設定有誤，請至 \"功能表>設定\" 重新設定或聯絡系統管理員");
			}
            _connection.Close();
        }

        public LaborWage工作單品號Table GetData(string worksheetNumber)
        {
            SelectBy工作單號Cmd.Parameters["工作單號"].Value = worksheetNumber;

            LaborWage工作單品號Table table = new LaborWage工作單品號Table();
            Adapter.SelectCommand = SelectBy工作單號Cmd;
            Adapter.Fill(table);
            return table;
        }

        public LaborWage員工工時Table GetDataGroupByLabor(List<string> worksheetNumberList)
        {
            LaborWage員工工時Table table = new LaborWage員工工時Table();

            if (worksheetNumberList.Count > 0)
            {
                string inQuery = " IN ( '" + string.Join("','", worksheetNumberList.ToArray()) + "' )";
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "SELECT L.姓名 AS 員工姓名,  Sum(val(Format(D.QTY*P.UnitPrice,'#')))/" + Settings.HourlyPay + " AS 工時 " +
                                "FROM (Data as D INNER JOIN Product as P ON D.產品編號 = P.編號 AND D.外包品名編號 = P.外包品名編號) INNER JOIN Labor as L ON L.編號 = D.人員編號 " +
                                "WHERE 工作單號 " + inQuery +
                                "GROUP BY L.姓名";
                cmd.Connection = _connection;

                Adapter.SelectCommand = cmd;
                Adapter.Fill(table);
            }
            return table;
        }

        public LaborWage員工工時Table GetDataGroupByDate(DateTime from, DateTime to)
        {
            LaborWage員工工時Table table = new LaborWage員工工時Table();

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = _connection;
			cmd.CommandText = "SELECT L.姓名 AS 員工姓名, Sum(val(Format(D.QTY * P.UnitPrice,'#')))/" + Settings.HourlyPay + " AS 工時 " +
                            "FROM (Data as D INNER JOIN Product as P ON D.產品編號 = P.編號 AND D.外包品名編號 = P.外包品名編號) INNER JOIN Labor  as L ON L.編號 = D.人員編號 " +
                            "WHERE 日期 >= ? AND 日期 <= ? " +
                            "GROUP BY L.姓名";

            cmd.Parameters.Add(new OleDbParameter("日期1", from));
            cmd.Parameters.Add(new OleDbParameter("日期2", to));

            Adapter.SelectCommand = cmd;
            Adapter.Fill(table);

            return table;
        }

        public LaborWage員工工時Table GetDataByDate(DateTime from, DateTime to)
        {
            LaborWage員工工時Table table = new LaborWage員工工時Table();

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = _connection;
			cmd.CommandText = "SELECT 日期, L.姓名 AS 員工姓名,  Sum(val(Format(D.QTY*P.UnitPrice,'#')))/" + Settings.HourlyPay + " AS 工時 " +
                            "FROM (Data as D INNER JOIN Product as P ON D.產品編號 = P.編號 AND D.外包品名編號 = P.外包品名編號) INNER JOIN Labor as L ON L.編號 = D.人員編號 " +
                            "WHERE 日期 >= ? AND 日期 <= ? " +
                            "GROUP BY 日期, L.姓名 ";
            
            cmd.Parameters.Add(new OleDbParameter("日期1", from));
            cmd.Parameters.Add(new OleDbParameter("日期2", to));

            Adapter.SelectCommand = cmd;
            Adapter.Fill(table);

            return table;
        }

        public LaborWage工作單品號Table GetDataGroupByPartNumber(List<string> worksheetNumberList)
        {
            LaborWage工作單品號Table table = new LaborWage工作單品號Table();

            if (worksheetNumberList.Count > 0)
            {
                string inQuery = " IN ( '" + string.Join("','", worksheetNumberList.ToArray()) + "' )";

                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "SELECT D.品號 AS 品號, Sum(val(Format(D.QTY*P.UnitPrice,'#'))) AS 外包工資 " +
                                "FROM (Data as D INNER JOIN Product as P ON D.產品編號 = P.編號 AND D.外包品名編號 = P.外包品名編號) " +
                                "WHERE 工作單號 " + inQuery +
                                "GROUP BY D.品號";
                cmd.Connection = _connection;


                Adapter.SelectCommand = cmd;
                Adapter.Fill(table);
            }

            return table;
        }

		// Not used
        public int GetAmount(string worksheet, string partnumber)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT Sum(QTY) as Amount FROM Data " +
                              " WHERE 工作單號 = ? AND 品號 = ? " +
                              " GROUP BY 工作單號,品號";

            cmd.Parameters.Add(new OleDbParameter("工作單號",worksheet));
            cmd.Parameters.Add(new OleDbParameter("品號", partnumber));

            cmd.Connection = _connection;

            _connection.Open();
            object result = cmd.ExecuteScalar();
            int amount = 0;

            if (result != null)
                amount = (int)(((decimal)result) * 1000);

            _connection.Close();

            return amount;
        }
    }

    class LaborWage工作單品號Table : DataTable
    {
        public LaborWage工作單品號Table()
        {
            this.Columns.Add(new DataColumn("工作單號", typeof(string)));
            this.Columns.Add(new DataColumn("品號", typeof(string)));
            this.Columns.Add(new DataColumn("外包工資", typeof(decimal)));
            this.Columns.Add(new DataColumn("單位外包工資", typeof(decimal)));
            this.Columns.Add(new DataColumn("數量", typeof(decimal)));
        }
    }

    class LaborWage員工工時Table : DataTable
    {
        public LaborWage員工工時Table()
        {
            this.Columns.Add(new DataColumn("日期", typeof(DateTime)));
            this.Columns.Add(new DataColumn("員工姓名", typeof(string)));
            this.Columns.Add(new DataColumn("工時", typeof(decimal)));
        }
    }
}
