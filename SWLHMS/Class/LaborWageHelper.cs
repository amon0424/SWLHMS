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
        OleDbCommand _selectBy�u�@�渹Cmd;

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
        public OleDbCommand SelectBy�u�@�渹Cmd
        {
            get
            {
                if (_selectBy�u�@�渹Cmd == null)
                {
                    _selectBy�u�@�渹Cmd = new OleDbCommand();
                    _selectBy�u�@�渹Cmd.CommandText = 
                                "SELECT D.�u�@�渹, D.�~�� AS �~��,D.�u�~�s��, Sum(val(Format(D.QTY * P.UnitPrice,'#'))) AS �~�]�u��, " +
                                "P.UnitPrice AS ���~�]�u��, Sum(D.QTY * 1000) as �ƶq " +
                                "FROM (Data as D INNER JOIN Product as P ON D.���~�s�� = P.�s�� AND D.�~�]�~�W�s�� = P.�~�]�~�W�s��) " +
                                "WHERE �u�@�渹 = ? " +
								"GROUP BY D.�u�@�渹, D.�~��, P.UnitPrice, D.�u�~�s��";
                    _selectBy�u�@�渹Cmd.Connection = _connection;

                    _selectBy�u�@�渹Cmd.Parameters.Add(new OleDbParameter("�u�@�渹", OleDbType.VarWChar, 100));
                }
                return _selectBy�u�@�渹Cmd;
            }
            set { _selectBy�u�@�渹Cmd = value; }
        }

        public LaborWageHelper()
        {
            if (Settings.LaborWageDatabaseFile == string.Empty)
				throw new SWLHMSException("�|���]�wLaborWage�{���ؿ��A�Ц� �\���>�]�w �i��]�w���p���t�κ޲z��");

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
				throw new SWLHMSException("LaborWage�{���ؿ��]�w���~�A�Ц� \"�\���>�]�w\" ���s�]�w���p���t�κ޲z��");
			}
            _connection.Close();
        }

        public LaborWage�u�@��~��Table GetData(string worksheetNumber)
        {
            SelectBy�u�@�渹Cmd.Parameters["�u�@�渹"].Value = worksheetNumber;

            LaborWage�u�@��~��Table table = new LaborWage�u�@��~��Table();
            Adapter.SelectCommand = SelectBy�u�@�渹Cmd;
            Adapter.Fill(table);
            return table;
        }

        public LaborWage���u�u��Table GetDataGroupByLabor(List<string> worksheetNumberList)
        {
            LaborWage���u�u��Table table = new LaborWage���u�u��Table();

            if (worksheetNumberList.Count > 0)
            {
                string inQuery = " IN ( '" + string.Join("','", worksheetNumberList.ToArray()) + "' )";
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "SELECT L.�m�W AS ���u�m�W,  Sum(val(Format(D.QTY*P.UnitPrice,'#')))/" + Settings.HourlyPay + " AS �u�� " +
                                "FROM (Data as D INNER JOIN Product as P ON D.���~�s�� = P.�s�� AND D.�~�]�~�W�s�� = P.�~�]�~�W�s��) INNER JOIN Labor as L ON L.�s�� = D.�H���s�� " +
                                "WHERE �u�@�渹 " + inQuery +
                                "GROUP BY L.�m�W";
                cmd.Connection = _connection;

                Adapter.SelectCommand = cmd;
                Adapter.Fill(table);
            }
            return table;
        }

        public LaborWage���u�u��Table GetDataGroupByDate(DateTime from, DateTime to)
        {
            LaborWage���u�u��Table table = new LaborWage���u�u��Table();

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = _connection;
			cmd.CommandText = "SELECT L.�m�W AS ���u�m�W, Sum(val(Format(D.QTY * P.UnitPrice,'#')))/" + Settings.HourlyPay + " AS �u�� " +
                            "FROM (Data as D INNER JOIN Product as P ON D.���~�s�� = P.�s�� AND D.�~�]�~�W�s�� = P.�~�]�~�W�s��) INNER JOIN Labor  as L ON L.�s�� = D.�H���s�� " +
                            "WHERE ��� >= ? AND ��� <= ? " +
                            "GROUP BY L.�m�W";

            cmd.Parameters.Add(new OleDbParameter("���1", from));
            cmd.Parameters.Add(new OleDbParameter("���2", to));

            Adapter.SelectCommand = cmd;
            Adapter.Fill(table);

            return table;
        }

        public LaborWage���u�u��Table GetDataByDate(DateTime from, DateTime to)
        {
            LaborWage���u�u��Table table = new LaborWage���u�u��Table();

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = _connection;
			cmd.CommandText = "SELECT ���, L.�m�W AS ���u�m�W,  Sum(val(Format(D.QTY*P.UnitPrice,'#')))/" + Settings.HourlyPay + " AS �u�� " +
                            "FROM (Data as D INNER JOIN Product as P ON D.���~�s�� = P.�s�� AND D.�~�]�~�W�s�� = P.�~�]�~�W�s��) INNER JOIN Labor as L ON L.�s�� = D.�H���s�� " +
                            "WHERE ��� >= ? AND ��� <= ? " +
                            "GROUP BY ���, L.�m�W ";
            
            cmd.Parameters.Add(new OleDbParameter("���1", from));
            cmd.Parameters.Add(new OleDbParameter("���2", to));

            Adapter.SelectCommand = cmd;
            Adapter.Fill(table);

            return table;
        }

        public LaborWage�u�@��~��Table GetDataGroupByPartNumber(List<string> worksheetNumberList)
        {
            LaborWage�u�@��~��Table table = new LaborWage�u�@��~��Table();

            if (worksheetNumberList.Count > 0)
            {
                string inQuery = " IN ( '" + string.Join("','", worksheetNumberList.ToArray()) + "' )";

                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "SELECT D.�~�� AS �~��, Sum(val(Format(D.QTY*P.UnitPrice,'#'))) AS �~�]�u�� " +
                                "FROM (Data as D INNER JOIN Product as P ON D.���~�s�� = P.�s�� AND D.�~�]�~�W�s�� = P.�~�]�~�W�s��) " +
                                "WHERE �u�@�渹 " + inQuery +
                                "GROUP BY D.�~��";
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
                              " WHERE �u�@�渹 = ? AND �~�� = ? " +
                              " GROUP BY �u�@�渹,�~��";

            cmd.Parameters.Add(new OleDbParameter("�u�@�渹",worksheet));
            cmd.Parameters.Add(new OleDbParameter("�~��", partnumber));

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

    class LaborWage�u�@��~��Table : DataTable
    {
        public LaborWage�u�@��~��Table()
        {
            this.Columns.Add(new DataColumn("�u�@�渹", typeof(string)));
            this.Columns.Add(new DataColumn("�~��", typeof(string)));
            this.Columns.Add(new DataColumn("�~�]�u��", typeof(decimal)));
            this.Columns.Add(new DataColumn("���~�]�u��", typeof(decimal)));
            this.Columns.Add(new DataColumn("�ƶq", typeof(decimal)));
        }
    }

    class LaborWage���u�u��Table : DataTable
    {
        public LaborWage���u�u��Table()
        {
            this.Columns.Add(new DataColumn("���", typeof(DateTime)));
            this.Columns.Add(new DataColumn("���u�m�W", typeof(string)));
            this.Columns.Add(new DataColumn("�u��", typeof(decimal)));
        }
    }
}
