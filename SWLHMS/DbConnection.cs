using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
namespace Mong
{
    static class DbConnection
    {
        static OleDbConnection _instance;

        public static OleDbConnection Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new OleDbConnection(Properties.Settings.Default.dbConnectionString);

                return _instance;
            }
        }
    }
}
