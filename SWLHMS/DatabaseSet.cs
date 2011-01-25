using System.Data.OleDb;
using System.Data;
using System;

namespace Mong
{
    using Mong.DatabaseSetTableAdapters;

    partial class DatabaseSet
    {
		partial class 工作單品號DataTable
		{
		}
	
		partial class 待驗清單DataTable
		{
		}
	
        static DatabaseSet _instance;
        static bool _產線TableLoad;
        static bool _產品系列TableLoad;
        static bool _產品品號TableLoad;
        static bool _員工TableLoad;
        static bool _非生產TableLoad;
		static bool _品質原因TableLoad;

        public static DatabaseSet Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DatabaseSet();
                return _instance;
            }
        }

        public static 產線DataTable 產線Table
        {
            get
            {
                if (!_產線TableLoad)
                {
                    產線TableAdapter.Instance.Fill(Instance.產線);
                    _產線TableLoad = true;
                }

                return Instance.產線;
            }
        }

        public static 產品系列DataTable 產品系列Table
        {
            get
            {
                if (!_產品系列TableLoad)
                {
                    產品系列TableAdapter.Instance.Fill(Instance.產品系列);
                    _產品系列TableLoad = true;
                }

                return Instance.產品系列;
            }
        }

        public static 產品品號DataTable 產品品號Table
        {
            get
            {
                if (!_產品品號TableLoad)
                {
                    產品品號TableAdapter.Instance.Fill(Instance.產品品號);
                    _產品品號TableLoad = true;
                }

                return Instance.產品品號;
            }
        }

        public static 員工DataTable 員工Table
        {
            get
            {
                if (!_員工TableLoad)
                {
                    if (!_產線TableLoad)
                    {
                        產線TableAdapter.Instance.Fill(Instance.產線);
                        _產線TableLoad = true;
                    }

                    員工TableAdapter.Instance.Fill(Instance.員工);
                    _員工TableLoad = true;
                }

                return Instance.員工;
            }
        }

        public static 非生產DataTable 非生產Table
        {
            get
            {
                if (!_非生產TableLoad)
                {
                    非生產TableAdapter.Instance.Fill(Instance.非生產);
                    _非生產TableLoad = true;
                }

                return Instance.非生產;
            }
        }

		public static 品質原因DataTable 品質原因Table
		{
			get
			{
				if (!_品質原因TableLoad)
				{
					品質原因TableAdapter.Instance.Fill(Instance.品質原因);
					_品質原因TableLoad = true;
				}

				return Instance.品質原因;
			}
		}

        public static 假日ViewDataTable 假日ViewTable
        {
            get
            {
                return Instance.假日View;
            }
        }

        public static 工作單DataTable 工作單Table
        {
            get
            {
                return Instance.工作單;
            }
        }

    
        public partial class 產品系列Row : global::System.Data.DataRow
        {
            public void CheckValid()
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                if (this["編號"] == System.DBNull.Value)
                    sb.AppendLine("編號不得為空值");
                if (this["代號"] == System.DBNull.Value || this.代號 == string.Empty)
                    sb.AppendLine("代號不得為空值");
                if (sb.Length > 0)
                    throw new SWLHMSException(sb.ToString());
            }

            public void FillRow(int 編號, string 代號)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                if (編號 < 0)
                    sb.AppendLine("編號不得為負值");

                if (代號 == string.Empty)
                    sb.AppendLine("代號不得為空值");

                if (sb.Length > 0)
                    throw new SWLHMSException(sb.ToString());

                this.編號 = 編號;
                this.代號 = 代號;
            }
        }

        public partial class 產線Row : global::System.Data.DataRow
        {
            public void CheckValid()
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                if (this["產線"] == DBNull.Value || this.產線 == string.Empty)
                    sb.AppendLine("產線不得為空值");

                if (sb.Length > 0)
					throw new SWLHMSException(sb.ToString());
            }

            public void FillRow(string 產線, string 代號)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                if (產線 == string.Empty)
                    sb.AppendLine("產線不得為空值");

                if (sb.Length > 0)
					throw new SWLHMSException(sb.ToString());

                this.產線 = 產線;
                this["代號"] = (代號 == string.Empty ? DBNull.Value : (object)代號);
            }
        }

        public partial class 員工Row : global::System.Data.DataRow
        {
            public void CheckValid()
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                if (Convert.IsDBNull(this["編號"]) || this.編號 == string.Empty)
                    sb.AppendLine("編號不得為空值");
                if (Convert.IsDBNull(this["姓名"]) || this.姓名 == string.Empty)
                    sb.AppendLine("姓名不得為空值");
                if (this["薪水"] == System.DBNull.Value)
                    sb.AppendLine("薪水不得為空值");
                
                if (sb.Length > 0)
					throw new SWLHMSException(sb.ToString());
            }

            public void FillRow(string 編號, string 姓名, decimal 薪水, string 產線)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                if (編號 == string.Empty)
                    sb.AppendLine("編號不得為空值");

                if (姓名 == string.Empty)
                    sb.AppendLine("姓名不得為空值");

                if (sb.Length > 0)
					throw new SWLHMSException(sb.ToString());

                this.編號 = 編號;
                this.姓名 = 姓名;
                this.薪水 = 薪水;
                this["產線"] = (產線 == string.Empty ? DBNull.Value : (object)產線);
            }
        }

        public partial class 非生產Row : global::System.Data.DataRow
        {
            public void FillRow(int 編號, string 名稱)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                if (名稱 == string.Empty)
                    sb.AppendLine("名稱不得為空值");

                if (名稱 == "其他")
                    sb.AppendLine("名稱不得為 其他");

				if (System.Text.RegularExpressions.Regex.IsMatch(名稱, @"[\[\]]+"))
					sb.AppendLine("名稱不得含有特殊字元 [ ]");

                if (sb.Length > 0)
					throw new SWLHMSException(sb.ToString());

                this.編號 = 編號;
                this.名稱 = 名稱;
            }
        }

		public partial class 品質原因Row
		{
			public void FillRow(int 編號, string 名稱)
			{
				System.Text.StringBuilder sb = new System.Text.StringBuilder();

				if (名稱 == string.Empty)
					sb.AppendLine("名稱不得為空值");

				if (編號 < 0)
					sb.Append("編號必須為一個正整數");

				if (sb.Length > 0)
					throw new SWLHMSException(sb.ToString());

				this.編號 = 編號;
				this.名稱 = 名稱;
			}
		}

        public partial class 假日ViewRow : global::System.Data.DataRow
        {
            public void FillRow(DateTime 日期)
            {
                this.日期 = 日期;
                this.週六日 = (日期.DayOfWeek == DayOfWeek.Saturday || 日期.DayOfWeek == DayOfWeek.Sunday);
                this.類別 = this.週六日 ? "週六日" : "自訂";
            }

            public void FillRow(DateTime 日期, bool 週六日)
            {
                this.日期 = 日期;
                this.週六日 = 週六日;
                this.類別 = this.週六日 ? "週六日" : "自訂";
            }
        }

        public partial class 工作單品號Row : global::System.Data.DataRow
        {
            public void FillRow(string 單號,string 品號,decimal 數量)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                if (單號 == null || 單號.Trim() == string.Empty)
                    sb.AppendLine("單號不得為空值");

                if (品號 == null || 品號.Trim() == string.Empty)
                    sb.AppendLine("品號不得為空值");

                if (sb.Length > 0)
					throw new SWLHMSException(sb.ToString());

                this.單號 = 單號;
                this.品號 = 品號;
                this.數量 = 數量;
            }
        }

        public partial class 工時Row : global::System.Data.DataRow
        {
            public void FillRow(string 員工編號, DateTime 日期, string 工作單號, decimal 工時, int 數量, string 借入產線, string QCN, int 工品編號, HourType 工時類型)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                if (員工編號 == null || 員工編號.Trim() == string.Empty)
                    sb.AppendLine("員工編號不得為空值");

                if (工作單號 == null || 工作單號.Trim() == string.Empty)
                    sb.AppendLine("工作單號不得為空值");

				//if (品號 == null || 品號.Trim() == string.Empty)
				//    sb.AppendLine("品號不得為空值");

				if (QCN == null || QCN.Trim() == string.Empty && 數量 > 0)
					sb.AppendLine("QC#不得為空值");

                if (工時 < 0)
                    sb.AppendLine("工時必須為一個正整數");

                // For 1.03
                if (數量 < 0)
                    sb.AppendLine("數量必須為一個正整數");

                if (sb.Length > 0)
					throw new SWLHMSException(sb.ToString());

				this.編號 = Global.GenerateUniqueNumber();
                this.員工編號 = 員工編號;
                this.日期 = 日期;
                this.工作單號 = 工作單號;
                //this.品號 = 品號;
                this.工時 = 工時;
                this.非生產編號 = -1;
				if (this.Table.Columns.IndexOf("待驗數量") != -1)
					this["待驗數量"] = 數量;
				else
					this.數量 = 數量;
                this.借入產線 = 借入產線;
				this.QCN = QCN;
				this.工品編號 = 工品編號;
				this.工時類型 = (int)工時類型;

                this["備註"] = DBNull.Value;
            }

            public void FillRow(string 員工編號, DateTime 日期, decimal 工時, int 非生產編號,string 非生產名稱, string 備註)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                if (員工編號 == null || 員工編號.Trim() == string.Empty)
                    sb.AppendLine("員工編號不得為空值");

                if (工時 <= 0)
                    sb.AppendLine("工時必須為一個正整數");

                if (sb.Length > 0)
					throw new SWLHMSException(sb.ToString());

				this.編號 = Global.GenerateUniqueNumber();
                this.員工編號 = 員工編號;
                this.日期 = 日期;
                this["工作單號"] = DBNull.Value;
                this["品號"] = DBNull.Value;
                this.工時 = 工時;
                this.非生產編號 = 非生產編號;
                this.非生產名稱 = 非生產名稱;
				this.工時類型 = (int)HourType.一般工時;
                this.備註 = 備註;
            }
        }

        #region 自訂方法
        public static string GetLineByWorksheetNo(string worksheetNo)
        {
            OleDbConnection conn = DbConnection.Instance;
            ConnectionState oriConnState = conn.State;
            if ((conn.State & ConnectionState.Open) != ConnectionState.Open)
                conn.Open();

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT DISTINCT(產線) " +
                              "FROM (工作單 AS A INNER JOIN 工作單品號 AS B ON A.單號 = B.單號) "+
                                "INNER JOIN 產品品號 AS C ON B.品號 = C.品號 "+
                                "WHERE A.單號 = ?";
            cmd.Parameters.Add(new OleDbParameter("單號", worksheetNo));

            OleDbDataReader reader = cmd.ExecuteReader();
            string line = null;
            if(reader.Read())
                line = reader.GetString(0);
            reader.Close();

            if (oriConnState == ConnectionState.Closed)
                conn.Close();

            if (line == null)
				throw new SWLHMSException("找不到工作單號 '" + worksheetNo + "' 所屬產線");

            return line;
        }

		public static 待驗清單DataTable GetInspectList(string line, string name, DateTime from, DateTime to)
		{
			OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.dbConnectionString);
			OleDbCommand cmd = new OleDbCommand();
			cmd.Connection = conn;

			System.Collections.Generic.List<string> whereList = new System.Collections.Generic.List<string>();
			whereList.Add("檢驗 = False");
			if (line != null && line.Trim() != string.Empty)
			{
				cmd.Parameters.Add(new OleDbParameter("產線", line));
				whereList.Add("產線 = ?");
			}
			if (name != null && name.Trim() != string.Empty)
			{
				cmd.Parameters.Add(new OleDbParameter("姓名", name));
				whereList.Add("姓名 = ?");
			}

			if (from != DateTime.MinValue)
			{
				OleDbParameter param = new OleDbParameter("日期1", OleDbType.Date);
				param.Value = from;
				cmd.Parameters.Add(param);
				whereList.Add("送檢日期 >= ?");
			}

			if (to != DateTime.MaxValue)
			{

				OleDbParameter param = new OleDbParameter("日期2", OleDbType.Date);
				param.Value = to;
				cmd.Parameters.Add(param);
				whereList.Add("送檢日期 <= ?");
			}

			string cmdText = "SELECT 產線, 單據日期, 工作單號, P.品號, WP.數量 as 總數量, 待驗數量, 預計完成日, QCN, 送檢次數, 檢驗, 檢驗結果, 工時資料編號, 送檢日期 as 日期, 工品編號" +
							 " FROM ((((工時 as H INNER JOIN 產品檢驗 as Q on H.編號 = Q.工時資料編號) " + 
							 " INNER JOIN 工作單 as W on H.工作單號 = W.單號)" + 
							 " INNER JOIN 工作單品號 as WP ON H.工作單號 = WP.單號 AND H.工品編號 = WP.編號)" +
							 " INNER JOIN 產品品號 as P ON P.品號 = WP.品號)";
			if (whereList.Count > 0)
				cmdText += " WHERE " + string.Join(" AND ", whereList.ToArray());

			cmdText += " ORDER BY 送檢日期, 單據日期, 工作單號, 工品編號";
			
			cmd.CommandText = cmdText;
			OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);

			待驗清單DataTable table = new 待驗清單DataTable();
			adapter.Fill(table);

			//檢查是否立即待驗及取得完成數量
			table.Columns.Add("序號", typeof(int));
			table.Columns.Add("待驗提醒", typeof(string));
			table.Columns.Add("已完成", typeof(decimal)).DefaultValue = 0;
			table.Columns.Add("NG原因", typeof(string)).DefaultValue = null;
			table.Columns.Add("舊NG原因", typeof(string));
			table.Columns.Add("特許", typeof(bool));

			cmd = new OleDbCommand("SELECT SUM(待驗數量) + SUM(H.數量) >= WP.數量, SUM(H.數量) as 已完成" +
									" FROM ((工時 as H LEFT JOIN (SELECT * FROM 產品檢驗 WHERE 檢驗 = FALSE) as Q on H.編號 = Q.工時資料編號) " +
									" INNER JOIN 工作單品號 as WP ON H.工作單號 = WP.單號 AND H.工品編號 = WP.編號)" +
									" WHERE WP.單號=? AND WP.編號=? " +
									" GROUP BY 單號, WP.編號, WP.數量", conn);
			cmd.Parameters.Add("單號", OleDbType.VarWChar);
			cmd.Parameters.Add("編號", OleDbType.Integer);
			
			conn.Open();
			string curWorksheet = null;
			int curWpid = -1;

			foreach (DataRow row in table)
			{
				string worksheet = row["工作單號"].ToString();
				int wpid = (int)row["工品編號"];

				if (worksheet != curWorksheet || wpid != curWpid)
				{
					curWorksheet = worksheet;
					curWpid = wpid;
					DataRow[] rows = table.Select("工作單號='" + worksheet + "' AND 工品編號=" + wpid);
					int sn = 1;
					foreach (DataRow r in rows)
						r["序號"] = sn++;
				}

				cmd.Parameters[0].Value = worksheet;
				cmd.Parameters[1].Value = wpid;

				bool inspectImm = false;

				OleDbDataReader dr = cmd.ExecuteReader();
				if (dr.Read())
				{
					object result = dr[0];
					if (result != DBNull.Value)
						inspectImm = Convert.ToInt32(result) != 0;

					object complete = dr[1];
					if (complete != DBNull.Value)
						row["已完成"] = complete;
				}
				dr.Close();
				if (inspectImm)
					row["待驗提醒"] = "待驗";

				//取得舊NG原因
				string id = row["工時資料編號"].ToString();
				string[] ngReasons = GetNGReason(id);
				row["舊NG原因"] = string.Join("\n", ngReasons);
			}
			conn.Close();

			return table;
		}

		public static 待驗清單DataTable GetUnreinspectList(string line, string name)
		{
			OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.dbConnectionString);
			OleDbCommand cmd = new OleDbCommand();
			cmd.Connection = conn;

			System.Collections.Generic.List<string> whereList = new System.Collections.Generic.List<string>();
			whereList.Add("檢驗 = True AND 檢驗結果=False AND 特許=False AND 重驗=False");
			if (line != null && line.Trim() != string.Empty)
			{
				cmd.Parameters.Add(new OleDbParameter("產線", line));
				whereList.Add("產線 = ?");
			}
			if (name != null && name.Trim() != string.Empty)
			{
				cmd.Parameters.Add(new OleDbParameter("姓名", name));
				whereList.Add("姓名 = ?");
			}

			string cmdText = "SELECT 產線, 單據日期, 工作單號, P.品號, WP.數量 as 總數量, 待驗數量, 預計完成日, QCN, 送檢次數, 檢驗, 檢驗結果, 工時資料編號, 送檢日期 as 日期, 工品編號" +
							 " FROM ((((工時 as H INNER JOIN 產品檢驗 as Q on H.編號 = Q.工時資料編號) " +
							 " INNER JOIN 工作單 as W on H.工作單號 = W.單號)" +
							 " INNER JOIN 工作單品號 as WP ON H.工作單號 = WP.單號 AND H.工品編號 = WP.編號)" +
							 " INNER JOIN 產品品號 as P ON P.品號 = WP.品號)";
			if (whereList.Count > 0)
				cmdText += " WHERE " + string.Join(" AND ", whereList.ToArray());

			cmdText += " ORDER BY 送檢日期, 單據日期, 工作單號, 工品編號";

			cmd.CommandText = cmdText;
			OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);

			待驗清單DataTable table = new 待驗清單DataTable();
			adapter.Fill(table);

			//檢查是否立即待驗及取得完成數量
			table.Columns.Add("序號", typeof(int));
			table.Columns.Add("待驗提醒", typeof(string));
			table.Columns.Add("已完成", typeof(decimal)).DefaultValue = 0;
			table.Columns.Add("NG原因", typeof(string)).DefaultValue = null;
			table.Columns.Add("舊NG原因", typeof(string));
			table.Columns.Add("特許", typeof(bool));

			cmd = new OleDbCommand("SELECT SUM(待驗數量) + SUM(H.數量) >= WP.數量, SUM(H.數量) as 已完成" +
									" FROM ((工時 as H LEFT JOIN (SELECT * FROM 產品檢驗 WHERE 檢驗 = FALSE) as Q on H.編號 = Q.工時資料編號) " +
									" INNER JOIN 工作單品號 as WP ON H.工作單號 = WP.單號 AND H.工品編號 = WP.編號)" +
									" WHERE WP.單號=? AND WP.編號=? " +
									" GROUP BY 單號, WP.編號, WP.數量", conn);
			cmd.Parameters.Add("單號", OleDbType.VarWChar);
			cmd.Parameters.Add("編號", OleDbType.Integer);

			conn.Open();
			string curWorksheet = null;
			int curWpid = -1;

			foreach (DataRow row in table)
			{
				string worksheet = row["工作單號"].ToString();
				int wpid = (int)row["工品編號"];

				if (worksheet != curWorksheet || wpid != curWpid)
				{
					curWorksheet = worksheet;
					curWpid = wpid;
					DataRow[] rows = table.Select("工作單號='" + worksheet + "' AND 工品編號=" + wpid);
					int sn = 1;
					foreach (DataRow r in rows)
						r["序號"] = sn++;
				}

				cmd.Parameters[0].Value = worksheet;
				cmd.Parameters[1].Value = wpid;

				//bool inspectImm = false;

				OleDbDataReader dr = cmd.ExecuteReader();
				if (dr.Read())
				{
					//object result = dr[0];
					//if (result != DBNull.Value)
					//    inspectImm = Convert.ToInt32(result) != 0;

					object complete = dr[1];
					if (complete != DBNull.Value)
						row["已完成"] = complete;
				}
				dr.Close();
				//if (inspectImm)
				//    row["待驗提醒"] = "待驗";

				//取得舊NG原因
				string id = row["工時資料編號"].ToString();
				string[] ngReasons = GetNGReason(id);
				row["舊NG原因"] = string.Join("\n", ngReasons);
			}
			conn.Close();

			return table;
		}

		public static 待驗清單DataTable GetInspectCompleteList(string qcn, string partnumber, DateTime date)
		{
			OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.dbConnectionString);
			OleDbCommand cmd = new OleDbCommand();
			cmd.Connection = conn;

			System.Collections.Generic.List<string> whereList = new System.Collections.Generic.List<string>();
			whereList.Add("檢驗 = True AND 檢驗結果 = True ");
			if (!string.IsNullOrEmpty(qcn))
			{
				cmd.Parameters.Add(new OleDbParameter("QCN", qcn + "%"));
				whereList.Add("QCN LIKE ?");
			}
			if (!string.IsNullOrEmpty(partnumber))
			{
				cmd.Parameters.Add(new OleDbParameter("品號", partnumber + "%"));
				whereList.Add("品號 LIKE ?");
			}

			if (date != DateTime.MinValue)
			{
				OleDbParameter param = new OleDbParameter("日期", OleDbType.Date);
				param.Value = date;
				cmd.Parameters.Add(param);
				whereList.Add("datediff(\"d\", ?, Q.日期)=0");
				//whereList.Add("Q.日期 = ?");
			}

			string cmdText = "SELECT 單據日期, 工作單號, 品號, 客戶, WP.數量 as 總數量, 待驗數量, QCN, 檢驗結果, Q.日期 as 檢驗日期, 工品編號, 工時資料編號" +
							 " FROM (((工時 as H INNER JOIN 產品檢驗 as Q on H.編號 = Q.工時資料編號) " +
							 " INNER JOIN 工作單 as W on H.工作單號 = W.單號)" +
							 " INNER JOIN 工作單品號 as WP ON H.工作單號 = WP.單號 AND H.工品編號 = WP.編號)";
			if (whereList.Count > 0)
				cmdText += " WHERE " + string.Join(" AND ", whereList.ToArray());

			cmdText += " ORDER BY 單據日期, 工作單號, 工品編號";

			cmd.CommandText = cmdText;
			OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);

			待驗清單DataTable table = new 待驗清單DataTable();
			adapter.Fill(table);

			//取得完成數量
			table.Columns.Add("序號", typeof(int));
			table.Columns.Add("已完成", typeof(decimal)).DefaultValue = 0;

			cmd = new OleDbCommand("SELECT SUM(H.數量) as 已完成" +
									" FROM ((工時 as H LEFT JOIN (SELECT * FROM 產品檢驗 WHERE 檢驗 = FALSE) as Q on H.編號 = Q.工時資料編號) " +
									" INNER JOIN 工作單品號 as WP ON H.工作單號 = WP.單號 AND H.工品編號 = WP.編號)" +
									" WHERE WP.單號=? AND WP.編號=? " +
									" GROUP BY 單號, WP.編號, WP.數量", conn);

			cmd.Parameters.Add("單號", OleDbType.VarWChar);
			cmd.Parameters.Add("編號", OleDbType.Integer);

			conn.Open();
			string curWorksheet = null;
			int curWpid = -1;

			foreach (DataRow row in table)
			{
				string worksheet = row["工作單號"].ToString();
				int wpid = (int)row["工品編號"];

				if (worksheet != curWorksheet || wpid != curWpid)
				{
					curWorksheet = worksheet;
					curWpid = wpid;
					DataRow[] rows = table.Select("工作單號='" + worksheet + "' AND 工品編號=" + wpid);
					int sn = 1;
					foreach (DataRow r in rows)
						r["序號"] = sn++;
				}

				cmd.Parameters[0].Value = worksheet;
				cmd.Parameters[1].Value = wpid;

				OleDbDataReader dr = cmd.ExecuteReader();
				if (dr.Read())
				{
					object complete = dr[0];
					if (complete != DBNull.Value)
						row["已完成"] = complete;
				}
				dr.Close();
			}
			conn.Close();

			return table;
		}

		public static string[] GetNGReason(string id)
		{
			OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.dbConnectionString);
			OleDbCommand cmd = new OleDbCommand("SELECT * FROM NG原因 WHERE 工時資料編號=?",conn);
			cmd.Parameters.Add(new OleDbParameter("工時資料編號",id));
			conn.Open();
			OleDbDataReader dr = cmd.ExecuteReader();
			System.Collections.Generic.List<string> reasons = new System.Collections.Generic.List<string>();
			while (dr.Read())
			{
				string reason = dr["原因"].ToString();
				reasons.Add(reason);
			}
			dr.Close();
			conn.Close();

			return reasons.ToArray();
		}

		public static void UpdateWorksheetFinishDate(string worksheet)
		{
			DatabaseSet.工作單品號DataTable wsTable = 工作單品號TableAdapter.Instance.GetBy單號(worksheet);
			bool allFinished = true;
			DateTime maxDate = DateTime.MinValue;
			foreach (DatabaseSet.工作單品號Row wsRow in wsTable)
			{
				if (wsRow["實際完成日"] == DBNull.Value)
				{
					allFinished = false;
					break;
				}
				DateTime date = wsRow.實際完成日;
				if (date > maxDate)
					maxDate = date;
			}

			if (allFinished)
				工作單TableAdapter.Instance.SetFinishDate(maxDate, worksheet);
			else
				工作單TableAdapter.Instance.SetFinishDate(null, worksheet);
		}

		public static void UpdateWorksheetItemFinishDate(string worksheet, int wpid)
		{
			UpdateWorksheetItemFinishDate(worksheet, wpid, false);
		}

		public static void UpdateWorksheetItemFinishDate(string worksheet, int wpid, bool updateWorksheet)
		{
			DateTime finishDate;
			if (CheckFinish(worksheet, wpid, out finishDate))
				SetFinishDate(worksheet, wpid, finishDate);
			else
				SetFinishDate(worksheet, wpid, null);

			if (updateWorksheet)
				UpdateWorksheetFinishDate(worksheet);
		}

		public static void UpdateWorksheetFinishStatus(string worksheet)
		{
			DatabaseSet.工作單品號DataTable wsTable = 工作單品號TableAdapter.Instance.GetBy單號(worksheet);
			foreach (DatabaseSet.工作單品號Row wsRow in wsTable)
			{
				int wpid = wsRow.編號;
				UpdateWorksheetItemFinishDate(worksheet, wpid);
			}
			UpdateWorksheetFinishDate(worksheet);
		}

		public static int UpdateInspectList(待驗清單DataTable table, out int ok)
		{
			
			OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.dbConnectionString);

			//string cmdText = "UPDATE 工時 SET 數量 = 數量 + ? WHERE 編號 = ?";
			string cmdText = "UPDATE 工時 SET 數量 = ? WHERE 編號 = ?";
	
			OleDbCommand cmd = new OleDbCommand(cmdText, conn);
			cmd.Parameters.Add(new OleDbParameter("數量", OleDbType.Integer, -1, "待驗數量"));
			cmd.Parameters.Add(new OleDbParameter("編號", OleDbType.VarWChar, 255, "工時資料編號"));

			OleDbDataAdapter adapter = new OleDbDataAdapter();
			adapter.AcceptChangesDuringUpdate = false;
			adapter.UpdateCommand = cmd;

			//更新每一筆檢驗通過的工作單完成狀態
			DataRow[] rows = table.Select("(檢驗 = True AND (檢驗結果 = True OR 特許 = True)) ");
			ok = adapter.Update(rows);
			
			foreach (DataRow row in rows)
			{
				string worksheet = (string)row["工作單號"];
				int wpid = (int)row["工品編號"];
				//CheckFinish(worksheet, wpid, (DateTime)row["日期"]);

				DateTime finishDate;
				if (CheckFinish(worksheet, wpid, out finishDate))
					SetFinishDate(worksheet, wpid, DateTime.Today);

				//檢查並更新工作單完成狀態
				UpdateWorksheetFinishDate(worksheet);
			}

			cmdText = "UPDATE 產品檢驗 SET 最後檢驗紀錄=False WHERE 最後送檢編號=?";
			cmd = new OleDbCommand(cmdText, conn);
			//cmd.Parameters.Add(new OleDbParameter("最後送檢編號", OleDbType.VarWChar, 255, ParameterDirection.Input, false, 0, 0, "工時資料編號", DataRowVersion.Original, null));
			cmd.Parameters.Add(new OleDbParameter("最後送檢編號", OleDbType.VarWChar, 255, "工時資料編號"));
			adapter.UpdateCommand = cmd;
			rows = table.Select("檢驗 = True");
			//cmd.UpdatedRowSource = UpdateRowSource.None;
			adapter.Update(rows);

			//更新已檢驗的資料
			cmdText = "UPDATE 產品檢驗 SET 檢驗=?, 檢驗結果=?, 日期=?, 特許=?, 最後檢驗紀錄=True WHERE 工時資料編號=?";
			cmd = new OleDbCommand(cmdText, conn);
			cmd.Parameters.Add(new OleDbParameter("檢驗", OleDbType.Boolean, -1, "檢驗"));
			cmd.Parameters.Add(new OleDbParameter("檢驗結果", OleDbType.Boolean, -1, "檢驗結果"));
			//cmd.Parameters.Add(new OleDbParameter("品質原因", OleDbType.Integer, -1, "品質原因"));
			//cmd.Parameters.Add(new OleDbParameter("日期", DateTime.Now.ToString("s")));
			OleDbParameter paramDate = new OleDbParameter();
			paramDate.OleDbType = OleDbType.DBTimeStamp;
			paramDate.Value = DateTime.Now.ToString("s");
			cmd.Parameters.Add(paramDate);
			cmd.Parameters.Add(new OleDbParameter("特許", OleDbType.Boolean,-1, "特許"));
			cmd.Parameters.Add(new OleDbParameter("工時資料編號", OleDbType.VarWChar, 255, "工時資料編號"));
			

			adapter.UpdateCommand = cmd;
			adapter.AcceptChangesDuringUpdate = true;
			DataRow[] inspectedRows = table.Select("檢驗 = True");
			int update = adapter.Update(inspectedRows);

			//更新NG原因
			cmdText = "INSERT INTO NG原因 (工時資料編號, 原因, 來源編號) VALUES (?,?,?)";
			cmd = new OleDbCommand(cmdText, conn);
			cmd.Parameters.Add(new OleDbParameter("工時資料編號", OleDbType.VarWChar, 255, "工時資料編號"));
			cmd.Parameters.Add(new OleDbParameter("原因", OleDbType.LongVarWChar, -1, "NG原因"));
			cmd.Parameters.Add(new OleDbParameter("來源編號", OleDbType.VarWChar, 255, "工時資料編號"));
			adapter.InsertCommand = cmd;
			foreach (DataRow row in inspectedRows)
			{
				if (!string.IsNullOrEmpty(row["NG原因"] as string))
					row.SetAdded();
			}
			adapter.Update(inspectedRows);

			return update;
		}

		public static int UpdateInspectDeleteList(待驗清單DataTable table, out int delete)
		{
			OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.dbConnectionString);

			//減去刪除的數量
			string cmdText = "UPDATE 工時 SET 數量 = 0 WHERE 編號 = ?";

			OleDbCommand cmd = new OleDbCommand(cmdText, conn);
			//cmd.Parameters.Add(new OleDbParameter("數量", OleDbType.Integer, -1, "待驗數量"));
			cmd.Parameters.Add(new OleDbParameter("編號", OleDbType.VarWChar, 255, "工時資料編號"));

			OleDbDataAdapter adapter = new OleDbDataAdapter();
			adapter.UpdateCommand = cmd;
			DataRow[] rows = table.Copy().Select("刪除=True");
			delete = adapter.Update(rows);

			//判斷是否要回復未完成狀態
			foreach (DataRow row in rows)
			{
				string worksheet = (string)row["工作單號"];
				int wpid = (int)row["工品編號"];

				//若未完成則恢復成未完成狀態
				if (!CheckFinish(worksheet, wpid))
					SetFinishDate(worksheet, wpid, null);

				//取得工作單資料
				//工作單DataTable wsTable = 工作單TableAdapter.Instance.GetBy單號(worksheet);

				////如果設定了實際完成日，則檢查是否恢復成未完成狀態
				//if (wsTable[0][wsTable.實際完成日Column] != DBNull.Value)
				//{
				//    //檢查是否全部已完成
				//    DatabaseSet.工作單品號DataTable wpTable = 工作單品號TableAdapter.Instance.GetBy單號(worksheet);
				//    bool allFinished = true;
				//    foreach (DatabaseSet.工作單品號Row wsRow in wpTable)
				//    {
				//        if (wsRow["實際完成日"] == DBNull.Value)
				//        {
				//            allFinished = false;
				//            break;
				//        }
				//    }
				//    if (!allFinished)
				//        工作單TableAdapter.Instance.SetFinishDate(null, worksheet);
				//}

				UpdateWorksheetFinishDate(worksheet);
			}

			//更新已刪除的資料
			cmdText = "UPDATE 產品檢驗 SET 檢驗=False, 檢驗結果=False, 日期=NULL, 特許=False WHERE 工時資料編號=?";
			cmd = new OleDbCommand(cmdText, conn);
			cmd.Parameters.Add(new OleDbParameter("工時資料編號", OleDbType.VarWChar, 255, "工時資料編號"));

			adapter.UpdateCommand = cmd;
			DataRow[] inspectedRows = table.Select("刪除 = True");
			int update = adapter.Update(inspectedRows);

			return update;
		}

		public static void UpdateFinishAmount(DataTable table)
		{
			OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.dbConnectionString);

			string amountCmdTxt = "SELECT SUM(待驗數量) FROM 工時 as H INNER JOIN 產品檢驗 as Q ON H.編號 = Q.工時資料編號 " +
									" WHERE H.工作單號=? AND W.工品編號=? GROUP BY H.工作單號, W.工品編號";

			string cmdTxt = "UPDATE 工時 SET 數量 = (" + amountCmdTxt + ") WHERE 編號 = ?";

			OleDbCommand cmd = new OleDbCommand(cmdTxt, conn);
			cmd.Parameters.Add(new OleDbParameter("工作單號", OleDbType.VarWChar, 255, "工作單號"));
			cmd.Parameters.Add(new OleDbParameter("工品編號", OleDbType.Integer, -1, "工品編號"));
			cmd.Parameters.Add(new OleDbParameter("編號", OleDbType.VarWChar, 255, "工時資料編號"));

		}

		public static bool CheckFinish(string worksheet, int wpid, out DateTime finishDate)
		{
			finishDate = DateTime.MinValue;

			OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.dbConnectionString);

			string cmdText = "SELECT CBool(SUM(H.數量) >= WP.數量) FROM 工時 as H INNER JOIN 工作單品號 as WP ON H.工作單號 = WP.單號 AND H.工品編號 = WP.編號 " +
							 " WHERE H.工作單號 = ? AND H.工品編號 = ? GROUP BY H.工作單號, H.工品編號, WP.數量";

			OleDbCommand cmd = new OleDbCommand(cmdText, conn);
			cmd.Parameters.Add(new OleDbParameter("工作單號", worksheet));
			cmd.Parameters.Add(new OleDbParameter("工品編號", wpid));
			conn.Open();
			object result = cmd.ExecuteScalar();
			conn.Close();

			bool finish = (result != DBNull.Value && Convert.ToBoolean(result));

			if (finish)
			{
				cmd.CommandText = "SELECT MAX(Q.日期) FROM " +
									" 產品檢驗 as Q INNER JOIN 工時 as H ON Q.工時資料編號 = H.編號 " +
									" WHERE H.工作單號 = ? AND H.工品編號 = ? AND 最後檢驗紀錄 = TRUE AND (檢驗結果=TRUE OR 特許=TRUE)";

				conn.Open();
				result = cmd.ExecuteScalar();
				conn.Close();

				if (result != DBNull.Value)
					finishDate = ((DateTime)result).Date;		
			}

			return finish;
			
		}

		public static bool CheckFinish(string worksheet, int wpid)
		{
			DateTime finishDate;
			return CheckFinish(worksheet, wpid, out finishDate);
		}

		public static void SetFinishDate(string worksheet, int wpid, DateTime? finishDate)
		{
			OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.dbConnectionString);

			OleDbCommand cmd = new OleDbCommand();
			cmd.Connection = conn;

			if (finishDate != null)
			{
				//設定完成日期
				cmd.CommandText = "UPDATE 工作單品號 SET 實際完成日 = IIF(實際完成日>=?, 實際完成日, ?) WHERE 單號 = ? AND 編號 = ?";
				cmd.Parameters.Add(new OleDbParameter("實際完成日1", finishDate));
				cmd.Parameters.Add(new OleDbParameter("實際完成日2", finishDate));
			}
			else
			{
				cmd.CommandText = "UPDATE 工作單品號 SET 實際完成日 = NULL WHERE 單號 = ? AND 編號 = ?";
			}

			cmd.Parameters.Add(new OleDbParameter("單號", worksheet));
			cmd.Parameters.Add(new OleDbParameter("編號", wpid));

			conn.Open();
			cmd.ExecuteNonQuery();
			conn.Close();
		}

		public static int GetNGAmount(string worksheet, int wpid)
		{
			OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.dbConnectionString);
			string cmdText = "SELECT Sum(待驗數量) AS 退驗數量 " +
							 " FROM 產品檢驗 as Q INNER JOIN 工時 as H ON H.編號 = Q.工時資料編號 " +
							 " WHERE 檢驗=True AND 檢驗結果=False AND 特許=False AND 工作單號=? AND 工品編號=? GROUP BY 工作單號, 工品編號";
			OleDbCommand cmd = new OleDbCommand(cmdText, conn);
			cmd.Parameters.Add(new OleDbParameter("工作單號", worksheet));
			cmd.Parameters.Add(new OleDbParameter("工品編號", wpid));
			conn.Open();
			object result = cmd.ExecuteScalar();
			conn.Close();

			if (result != DBNull.Value && result != null)
				return Convert.ToInt32(result);
			else
				return 0;
		}

		public static int GetInspectedAmount(string worksheet, int wpid)
		{
			OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.dbConnectionString);
			string cmdText = "SELECT Sum(待驗數量) AS 待驗數 " +
							 " FROM 產品檢驗 as Q INNER JOIN 工時 as H ON H.編號 = Q.工時資料編號 " +
							 " WHERE 檢驗=False AND 工作單號=? AND 工品編號=? GROUP BY 工作單號, 工品編號";
			OleDbCommand cmd = new OleDbCommand(cmdText, conn);
			cmd.Parameters.Add(new OleDbParameter("工作單號", worksheet));
			cmd.Parameters.Add(new OleDbParameter("工品編號", wpid));
			conn.Open();
			object result = cmd.ExecuteScalar();
			conn.Close();

			if (result != DBNull.Value && result != null)
				return Convert.ToInt32(result);
			else
				return 0;
		}

		public static DataTable GetNGData(string labor)
		{
			OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.dbConnectionString);
			string cmdText = "SELECT 送檢日期 as 日期,Q.日期 AS 檢驗日期, 工作單號, 工品編號, 品號, 工時資料編號, QCN, 待驗數量, 送檢次數,客戶 " +
							 " FROM ((產品檢驗 as Q INNER JOIN 工時 as H ON H.編號 = Q.工時資料編號) " +
							 " INNER JOIN 工作單品號 as WP ON WP.單號 = H.工作單號 AND WP.編號 = H.工品編號)" +
							 " WHERE 檢驗=True AND 檢驗結果=False AND 特許=False AND 重驗=False AND 員工編號=?";

			OleDbCommand cmd = new OleDbCommand(cmdText, conn);
			cmd.Parameters.Add(new OleDbParameter("員工編號", labor));

			OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
			DataTable table = new DataTable();
			adapter.Fill(table);

			return table;
		}
        #endregion
    }
}

namespace Mong.DatabaseSetTableAdapters
{
    public partial class 產品品號TableAdapter
    {
        static 產品品號TableAdapter _instance;
        public static 產品品號TableAdapter Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new 產品品號TableAdapter();

                return _instance;
            }
        }

        string[] _columnList = new string[] { "品號", "系列編號", "品名", "產線", "工時", "標準工資", "單位標準工資" };
        string _tableName = "產品品號";

        OleDbCommand _updateCommand;
        OleDbCommand _insertCommand;
        OleDbCommand _deleteCommand;

        public System.Data.OleDb.OleDbCommand UpdateCommand
        {
            get
            {
                if (_updateCommand == null)
                {
                    _updateCommand = new System.Data.OleDb.OleDbCommand();
                    _updateCommand.Connection = this.Connection;


                    string[] setElements = new string[_columnList.Length];
                    for (int i = 0; i < setElements.Length; i++)
                    {
                        setElements[i] = _columnList[i] + "=?";
                    }

                    _updateCommand.CommandText = "UPDATE " + _tableName +
                                                 " SET " + string.Join(",", setElements) +
                                                 " WHERE (品號 = ?)";

                    for (int i = 0; i < _columnList.Length; i++)
                        _updateCommand.Parameters.Add(CreateParameter(_columnList[i]));

                    _updateCommand.Parameters.Add(new OleDbParameter("Original_品號", OleDbType.WChar, 255, ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "品號", DataRowVersion.Original, false, null));
                }
                return _updateCommand;
            }
            set { _updateCommand = value; }
        }
        public System.Data.OleDb.OleDbCommand InsertCommand
        {
            get
            {
                if (_insertCommand == null)
                {
                    _insertCommand = new System.Data.OleDb.OleDbCommand();
                    _insertCommand.Connection = this.Connection;

                    string[] paramList = new string[_columnList.Length];
                    for (int i = 0; i < paramList.Length; i++)
                        paramList[i] = "?";

                    _insertCommand.CommandText = "INSERT INTO " + _tableName +
                                                 " (" + string.Join(",", _columnList) + ") " +
                                                 " VALUES  (" + string.Join(",", paramList) + ")";

                    for (int i = 0; i < _columnList.Length; i++)
                        _insertCommand.Parameters.Add(CreateParameter(_columnList[i]));

                }
                return _insertCommand;
            }
            set { _insertCommand = value; }
        }
        public System.Data.OleDb.OleDbCommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new System.Data.OleDb.OleDbCommand();
                    _deleteCommand.Connection = this.Connection;
                    _deleteCommand.CommandText = "DELETE FROM " + _tableName + " WHERE (品號 = ?)";

                    _deleteCommand.Parameters.Add(CreateParameter("品號"));
                }
                return _deleteCommand;
            }
            set { _deleteCommand = value; }
        }
        

        public int UpdateEx(DatabaseSet.產品品號DataTable table)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter();

            adapter.UpdateCommand = UpdateCommand;
            adapter.InsertCommand = InsertCommand;
            adapter.DeleteCommand = DeleteCommand;

            this.Connection.Open();
            OleDbTransaction trans = this.Connection.BeginTransaction();
            adapter.InsertCommand.Transaction = trans;
            adapter.UpdateCommand.Transaction = trans;
            adapter.DeleteCommand.Transaction = trans;

            try
            {
                int count = 0;
                count = adapter.Update(table);
                trans.Commit();
                return count;
            }
            catch (System.Exception ex)
            {
                trans.Rollback();
                throw ex;
            }
            finally
            {
                this.Connection.Close();
            }
        }

        OleDbParameter CreateParameter(string paramName)
        {
            switch (paramName)
            {
                case "品號":
                    return new OleDbParameter("品號", OleDbType.WChar, 255, ParameterDirection.Input, 0, 0, "品號", DataRowVersion.Current, false, null);
                case "系列編號":
                    return new OleDbParameter("系列編號", OleDbType.Integer, 0, ParameterDirection.Input, 0, 0, "系列編號", DataRowVersion.Current, false, null);
                case "品名":
                    return new OleDbParameter("品名", OleDbType.WChar, 255, ParameterDirection.Input, 0, 0, "品名", DataRowVersion.Current, false, null);
                case "產線":
                    return new OleDbParameter("產線", OleDbType.WChar, 255, ParameterDirection.Input, 0, 0, "產線", DataRowVersion.Current, false, null);
                case "工時":
                    return new OleDbParameter("工時", OleDbType.Numeric, 0, ParameterDirection.Input, 18, 4, "工時", DataRowVersion.Current, false, null);
                case "標準工資":
                    return new OleDbParameter("標準工資", OleDbType.Numeric, 0, ParameterDirection.Input, 18, 4, "標準工資", DataRowVersion.Current, false, null);
                case "單位標準工資":
                    return new OleDbParameter("單位標準工資", OleDbType.Numeric, 0, ParameterDirection.Input, 18, 4, "單位標準工資", DataRowVersion.Current, false, null);
                default:
					throw new SWLHMSException("未知的參數名稱 '" + paramName + "'");
            }
        }
    }

    public partial class 產品系列TableAdapter
    {
        static 產品系列TableAdapter _instance;
        public static 產品系列TableAdapter Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new 產品系列TableAdapter();

                return _instance;
            }
        }
    }

    public partial class 產品品號ViewTableAdapter
    {
        static 產品品號ViewTableAdapter _instance;
        public static 產品品號ViewTableAdapter Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new 產品品號ViewTableAdapter();

                return _instance;
            }
        }
    }

    public partial class 產品品號ViewTableAdapter
    {
        string[] _columnList = new string[] { "品號", "系列編號", "品名", "產線", "工時", "標準工資", "單位標準工資" };
        string _tableName = "產品品號";

        OleDbCommand _updateCommand;
        OleDbCommand _insertCommand;
        OleDbCommand _deleteCommand;

        public System.Data.OleDb.OleDbCommand UpdateCommand
        {
            get
            {
                if (_updateCommand == null)
                {
                    _updateCommand = new System.Data.OleDb.OleDbCommand();
                    _updateCommand.Connection = this.Connection;
                    

                    string[] setElements = new string[_columnList.Length];
                    for(int i=0;i<setElements.Length;i++)
                    {
                        setElements[i] = _columnList[i] + "=?";
                    }

                    _updateCommand.CommandText = "UPDATE " + _tableName +
                                                 " SET " + string.Join(",", setElements) +
                                                 " WHERE (品號 = ?)";

                    for (int i = 0; i < _columnList.Length; i++)
                        _updateCommand.Parameters.Add(CreateParameter(_columnList[i]));

                    _updateCommand.Parameters.Add(new OleDbParameter("Original_品號", OleDbType.WChar, 255, ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "品號", DataRowVersion.Original, false, null));
                }
                return _updateCommand;
            }
            set { _updateCommand = value; }
        }
        public System.Data.OleDb.OleDbCommand InsertCommand
        {
            get
            {
                if (_insertCommand == null)
                {
                    _insertCommand = new System.Data.OleDb.OleDbCommand();
                    _insertCommand.Connection = this.Connection;

                    string[] paramList = new string[_columnList.Length];
                    for (int i = 0; i < paramList.Length; i++)
                        paramList[i] = "?";

                    _insertCommand.CommandText = "INSERT INTO " + _tableName +
                                                 " (" + string.Join(",", _columnList) + ") " +
                                                 " VALUES  (" + string.Join(",", paramList) + ")";

                    for (int i = 0; i < _columnList.Length; i++)
                        _insertCommand.Parameters.Add(CreateParameter(_columnList[i]));

                }
                return _insertCommand;
            }
            set { _insertCommand = value; }
        }
        public System.Data.OleDb.OleDbCommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new System.Data.OleDb.OleDbCommand();
                    _deleteCommand.Connection = this.Connection;
                    _deleteCommand.CommandText = "DELETE FROM " + _tableName + " WHERE (品號 = ?)";

                    _deleteCommand.Parameters.Add(CreateParameter("品號"));
                }
                return _deleteCommand;
            }
            set { _deleteCommand = value; }
        }

        public int UpdateBy品號(DatabaseSet.產品品號ViewRow row)
        {
            return UpdateBy品號(row.品號, row.系列名稱, row.系列編號, row.品名, row.產線, row.工時, row.標準工資, row.單位標準工資, row["品號", System.Data.DataRowVersion.Original].ToString());
        }

        public int Update(DatabaseSet.產品品號ViewDataTable table)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter();

            adapter.UpdateCommand = UpdateCommand;
            adapter.InsertCommand = InsertCommand;
            adapter.DeleteCommand = DeleteCommand;

            this.Connection.Open();
            OleDbTransaction trans = this.Connection.BeginTransaction();
            adapter.InsertCommand.Transaction = trans;
            adapter.UpdateCommand.Transaction = trans;
            adapter.DeleteCommand.Transaction = trans;

            try
            {
                int count = 0;
                count = adapter.Update(table);
                trans.Commit();
                return count;
            }
            catch (System.Exception ex)
            {
                trans.Rollback();
                throw ex;
            }
            finally
            {
                this.Connection.Close();
            }
        }

        OleDbParameter CreateParameter(string paramName)
        {
            switch (paramName)
            {
                case "品號":
                    return new OleDbParameter("品號", OleDbType.WChar, 255, ParameterDirection.Input, 0, 0, "品號", DataRowVersion.Current, false, null);
                case "系列編號":
                    return new OleDbParameter("系列編號", OleDbType.Integer, 0, ParameterDirection.Input, 0, 0, "系列編號", DataRowVersion.Current, false, null);
                case "品名":
                    return new OleDbParameter("品名", OleDbType.WChar, 255, ParameterDirection.Input, 0, 0, "品名", DataRowVersion.Current, false, null);
                case "產線":
                    return new OleDbParameter("產線", OleDbType.WChar, 255, ParameterDirection.Input, 0, 0, "產線", DataRowVersion.Current, false, null);
                case "工時":
                    return new OleDbParameter("工時", OleDbType.Numeric, 0, ParameterDirection.Input, 18, 4, "工時", DataRowVersion.Current, false, null);
                case "標準工資":
                    return new OleDbParameter("標準工資", OleDbType.Numeric, 0, ParameterDirection.Input, 18, 4, "標準工資", DataRowVersion.Current, false, null);
                case "單位標準工資":
                    return new OleDbParameter("單位標準工資", OleDbType.Numeric, 0, ParameterDirection.Input, 18, 4, "單位標準工資", DataRowVersion.Current, false, null);
               
                default:
					throw new SWLHMSException("未知的參數名稱 '" + paramName + "'");
            }
        }
    }

    public partial class 產線TableAdapter
    {
        static 產線TableAdapter _instance;
        public static 產線TableAdapter Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new 產線TableAdapter();

                return _instance;
            }
        }

		/// <summary>
		/// 若建立了新的產線則傳回True
		/// </summary>
		public bool CheckLineAndCreate(string line)
		{
			DatabaseSet.產線DataTable table = DatabaseSet.產線Table;

			if (table.Select("產線 = '" + line + "'").Length == 0)
			{
				DatabaseSet.產線Row row = table.New產線Row();
				row.產線 = line;
				table.Rows.Add(row);

				Instance.Update(row);
				return true;
			}

			return false;
		}
    }

    public partial class 員工TableAdapter
    {
        static 員工TableAdapter _instance;
        public static 員工TableAdapter Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new 員工TableAdapter();

                return _instance;
            }
        }

    }

    public partial class 假日TableAdapter
    {
        static 假日TableAdapter _instance;
        public static 假日TableAdapter Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new 假日TableAdapter();

                return _instance;
            }
        }

        OleDbCommand _selectByMonthCommand;
        OleDbCommand _selectByDateCommand;
        
        public OleDbCommand SelectByMonthCommand
        {
            get
            {
                if (_selectByMonthCommand == null)
                {
                    _selectByMonthCommand = new OleDbCommand();
                    _selectByMonthCommand.Connection = this.Connection;
                    _selectByMonthCommand.CommandText = "SELECT * FROM 假日 " +
                                                        "WHERE Year([日期]) =? AND Month([日期]) = ? ORDER BY 日期";

                    _selectByMonthCommand.Parameters.Add(new OleDbParameter("年份", OleDbType.Variant, 1024));
                    _selectByMonthCommand.Parameters.Add(new OleDbParameter("月份", OleDbType.Variant, 1024));
                } 
                
                return _selectByMonthCommand;
            }
            set { _selectByMonthCommand = value; }
        }

        public OleDbCommand SelectByDateCommand
        {
            get
            {
                if (_selectByDateCommand == null)
                {
                    _selectByDateCommand = new OleDbCommand();
                    _selectByDateCommand.Connection = this.Connection;
                    _selectByDateCommand.CommandText = "SELECT * FROM 假日 " +
                                                        "WHERE 日期 = ?";

                    _selectByDateCommand.Parameters.Add(new OleDbParameter("日期", OleDbType.Date));
                }

                return _selectByDateCommand;
            }
            set { _selectByDateCommand = value; }
        }

        public int FillBy月份(DatabaseSet.假日DataTable table,int 年份, int 月份)
        {
            this.Adapter.SelectCommand = SelectByMonthCommand;
            _selectByMonthCommand.Parameters["年份"].Value = 年份;
            _selectByMonthCommand.Parameters["月份"].Value = 月份;
            table.Clear();
            return this.Adapter.Fill(table);
        }

        public bool IsHoliday(DateTime date)
        {
            this.Adapter.SelectCommand = SelectByDateCommand;
            _selectByMonthCommand.Parameters["日期"].Value = date;
            DatabaseSet.假日DataTable table = new DatabaseSet.假日DataTable();
            this.Adapter.Fill(table);

            //如果不在資料庫裡
            if (table.Count == 0)
            {
                //判斷是否為周六日
                return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
            }
            //如果在資料庫裡
            else
            {
                DatabaseSet.假日Row row = table[0];
                return row.增加;
            }
        }

        public bool IsHoliday(DatabaseSet.假日DataTable table, DateTime date)
        {
            DataRow[] rows = table.Select("日期 = #" + date.ToString("yyyy/MM/dd") + "#");

            //如果不在資料庫裡
            if (rows.Length == 0)
            {
                //判斷是否為周六日
                return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
            }
            //如果在資料庫裡
            else
            {
                DatabaseSet.假日Row row = rows[0] as DatabaseSet.假日Row;
                return row.增加;
            }
        }
    }

    public partial class 假日ViewTableAdapter
    {
        static 假日ViewTableAdapter _instance;
        public static 假日ViewTableAdapter Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new 假日ViewTableAdapter();

                return _instance;
            }
        }

        OleDbCommand _updateCommand;
        OleDbCommand _insertCommand;
        OleDbCommand _deleteCommand;

        public System.Data.OleDb.OleDbCommand UpdateCommand
        {
            get
            {
                if (_updateCommand == null)
                {
                    _updateCommand = new System.Data.OleDb.OleDbCommand();
                    _updateCommand.Connection = this.Connection;
                    _updateCommand.CommandText = "UPDATE 假日 " +
                                                 "SET 日期 = ?, 增加 = ?" +
                                                 "WHERE (日期 = ?)";

                    _updateCommand.Parameters.Add(new OleDbParameter("日期", OleDbType.Date, 0, ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "日期", DataRowVersion.Original, false, null));
                    _updateCommand.Parameters.Add(new OleDbParameter("增加", OleDbType.Boolean));
                    _updateCommand.Parameters.Add(new OleDbParameter("Original_日期", OleDbType.Date, 0, ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "日期", DataRowVersion.Original, false, null));
                }
                return _updateCommand;
            }
            set { _updateCommand = value; }
        }
        public System.Data.OleDb.OleDbCommand InsertCommand
        {
            get
            {
                if (_insertCommand == null)
                {
                    _insertCommand = new System.Data.OleDb.OleDbCommand();
                    _insertCommand.Connection = this.Connection;
                    _insertCommand.CommandText = "INSERT INTO 假日 " +
                                                 "(日期, 增加) " +
                                                 "VALUES  (?,?)";

                    _insertCommand.Parameters.Add(new OleDbParameter("日期", OleDbType.Date, 0, ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "日期", DataRowVersion.Original, false, null));
                    _insertCommand.Parameters.Add(new OleDbParameter("增加", OleDbType.Boolean));
                }
                return _insertCommand;
            }
            set { _insertCommand = value; }
        }
        public System.Data.OleDb.OleDbCommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new System.Data.OleDb.OleDbCommand();
                    _deleteCommand.Connection = this.Connection;
                    _deleteCommand.CommandText = "DELETE FROM 假日 WHERE (日期 = ?)";

                    _deleteCommand.Parameters.Add(new OleDbParameter("日期", OleDbType.Date, 0, ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "日期", DataRowVersion.Original, false, null));
                }
                return _deleteCommand;
            }
            set { _deleteCommand = value; }
        }

        public int Update(DatabaseSet.假日ViewDataTable table)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter();

            adapter.UpdateCommand = UpdateCommand;
            adapter.InsertCommand = InsertCommand;
            adapter.DeleteCommand = DeleteCommand;

            this.Connection.Open();
            OleDbTransaction trans = this.Connection.BeginTransaction();
            adapter.InsertCommand.Transaction = trans;
            adapter.UpdateCommand.Transaction = trans;
            adapter.DeleteCommand.Transaction = trans;

            try
            {
                int count = 0;
                foreach (DatabaseSet.假日ViewRow row in table)
                {
                    switch (row.RowState)
                    {
                        case DataRowState.Added:
                            //如果要加入週六日
                            if (row.週六日)
                            {
                                adapter.DeleteCommand.Parameters["日期"].Value = row.日期;
                                count += adapter.DeleteCommand.ExecuteNonQuery();
                            }
                            else
                            {
                                adapter.InsertCommand.Parameters["日期"].Value = row.日期;
                                adapter.InsertCommand.Parameters["增加"].Value = true;
                                count += adapter.InsertCommand.ExecuteNonQuery();
                            }
                            break;
                        case DataRowState.Deleted:
                            //如果要移除週六日
                            if ((bool)row["週六日", DataRowVersion.Original])
                            {
                                adapter.InsertCommand.Parameters["日期"].Value = row["日期", DataRowVersion.Original];
                                adapter.InsertCommand.Parameters["增加"].Value = false;
                                count += adapter.InsertCommand.ExecuteNonQuery();
                            }
                            else
                            {
                                adapter.DeleteCommand.Parameters["日期"].Value = row["日期", DataRowVersion.Original];
                                count += adapter.DeleteCommand.ExecuteNonQuery();
                            }
                            break;
                        case DataRowState.Modified:
                            //adapter.UpdateCommand.Parameters["日期"].Value = row.日期;
                            //adapter.UpdateCommand.Parameters["Original_日期"].Value = row["日期", DataRowVersion.Original];
                            //count += adapter.UpdateCommand.ExecuteNonQuery();
                            break;
                        default:
                            break;
                    }
                }
                
                trans.Commit();
                return count;
            }
            catch (System.Exception ex)
            {
                trans.Rollback();
                throw ex;
            }
            finally
            {
                this.Connection.Close();
            }
        }
    }

    public partial class 工作單TableAdapter
    {
        static 工作單TableAdapter _instance;
        public static 工作單TableAdapter Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new 工作單TableAdapter();

                return _instance;
            }
        }

        public int Fill(DatabaseSet.工作單DataTable table, string 單號, int dateType, DateTime from, DateTime to,int doneOrNot)
        {
            單號 = 單號.Replace("'", "''");
            //客戶名稱 = 客戶名稱.Replace("'", "''");

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("SELECT * FROM 工作單 ");

            System.Collections.Generic.List<string> whereCond = new System.Collections.Generic.List<string>();
            if (單號.Trim() != string.Empty)
                whereCond.Add("單號 LIKE '%" + 單號 + "%'");
			//if (客戶名稱.Trim() != string.Empty)
			//    whereCond.Add("客戶名稱 LIKE'%" + 客戶名稱 + "%'");

            if (dateType > 0)
            {
                if (dateType == 1)
                {
                    whereCond.Add("單據日期 >= #" + from.ToString("yyyy/MM/dd") + "#");
                    whereCond.Add("單據日期 <= #" + to.ToString("yyyy/MM/dd") + "#");
                }
                else
                {
                    whereCond.Add("實際完成日 >= #" + from.ToString("yyyy/MM/dd") + "#");
                    whereCond.Add("實際完成日 <= #" + to.ToString("yyyy/MM/dd") + "#");
                }
            }

            if (doneOrNot > 0)
            {
                if (doneOrNot == 1)
                {
                    whereCond.Add("實際完成日 IS NOT NULL");
                }
                else
                {
                    whereCond.Add("實際完成日 IS NULL");
                }
            }


            if (whereCond.Count > 0)
            {
                string whereStr = string.Join(" AND ", whereCond.ToArray());
                sb.Append(" WHERE " + whereStr);
            }



            OleDbCommand cmd = new OleDbCommand(sb.ToString());
            cmd.Connection = this.Connection;
            this.Adapter.SelectCommand = cmd;

            return this.Adapter.Fill(table);
        }
    }

    public partial class 工作單品號TableAdapter
    {
        static 工作單品號TableAdapter _instance;
        public static 工作單品號TableAdapter Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new 工作單品號TableAdapter();

                return _instance;
            }
        }

		public int UpdateEx(DatabaseSet.工作單品號DataTable table)
		{
			int count = 0;
			foreach (DatabaseSet.工作單品號Row row in table)
			{
				if (row.RowState != DataRowState.Added)
					continue;

				string idCmdTxt = "SELECT MAX(編號) FROM 工作單品號 WHERE 單號 = ?";

				OleDbCommand cmd = new OleDbCommand(idCmdTxt, Instance.Connection);
				cmd.Parameters.Add(new OleDbParameter("單號", row.單號));
				Instance.Connection.Open();
				object result = cmd.ExecuteScalar();
				Instance.Connection.Close();

				int id = 0;
				if (result != DBNull.Value)
					id = Convert.ToInt32(result);

				row.編號 = id+1;

				count += Instance.Update(row);
			}

			//string insertCmdTxt = "INSERT INTO 工作單品號 (單號, 品號, 數量, 實際完成日, 客戶需貨日, 預計完成日, 客戶, 編號) " +
			//                "VALUES (?, ?, ?, ?, ?, ?, ?, (SELECT MAX(編號) FROM 工作單品號 WHERE 單號 = ?))";

			//string updateCmdTxt = "UPDATE 工作單品號 SET 單號=?, 品號=?, 數量=?, 實際完成日=?, 客戶需貨日=?, 預計完成日=?, 客戶 = ?, 編號 = ?";

			//OleDbCommand insertCmd = new OleDbCommand(insertCmdTxt, Instance.Connection);
			//insertCmd.Parameters.Add("單號", OleDbType.VarWChar);
			//insertCmd.Parameters.Add("品號", OleDbType.VarWChar);
			//insertCmd.Parameters.Add("數量", OleDbType.VarWChar);
			//insertCmd.Parameters.Add("實際完成日", OleDbType.Date);
			//insertCmd.Parameters.Add("客戶需貨日", OleDbType.Date);
			//insertCmd.Parameters.Add("預計完成日", OleDbType.Date);
			//insertCmd.Parameters.Add("客戶", OleDbType.VarWChar);
			//insertCmd.Parameters.Add("單號2", OleDbType.VarWChar,255,"單號");
			//Instance.Adapter.InsertCommand = insertCmd;

			////OleDbCommand updateCmd = new OleDbCommand(updateCmdTxt, Instance.Connection);
			////Instance.Adapter.UpdateCommand = updateCmd;

			count += Instance.Update(table);

			return count;
		}
    }

    public partial class 非生產TableAdapter
    {
        static 非生產TableAdapter _instance;
        public static 非生產TableAdapter Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new 非生產TableAdapter();

                return _instance;
            }
        }
    }

	public partial class 品質原因TableAdapter
	{
		static 品質原因TableAdapter _instance;
		public static 品質原因TableAdapter Instance
		{
			get
			{
				if (_instance == null)
					_instance = new 品質原因TableAdapter();

				return _instance;
			}
		}
	}

	public partial class 產品檢驗TableAdapter
	{
		static 產品檢驗TableAdapter _instance;
		public static 產品檢驗TableAdapter Instance
		{
			get
			{
				if (_instance == null)
					_instance = new 產品檢驗TableAdapter();

				return _instance;
			}
		}

		public int Reinspect(string from, string to, string qcn, int amount)
		{
			this.Connection.Open();
			OleDbTransaction transaction = this.Connection.BeginTransaction();
			int result = 0;

			try
			{
				string cmdText = "SELECT 送檢次數 FROM 產品檢驗 WHERE 工時資料編號 = ?";
				OleDbCommand cmd = new OleDbCommand(cmdText, this.Connection);
				cmd.Transaction = transaction;
				cmd.Parameters.Add(new OleDbParameter("工時資料編號", from));
				int num = Convert.ToInt32(cmd.ExecuteScalar());

				cmdText = "INSERT INTO 產品檢驗 (工時資料編號,QCN,待驗數量,送檢次數,最後送檢編號,送檢日期) VALUES (?,?,?,?,?,?)";

				cmd = new OleDbCommand(cmdText, this.Connection);
				cmd.Transaction = transaction;
				cmd.Parameters.Add(new OleDbParameter("工時資料編號1", to));
				cmd.Parameters.Add(new OleDbParameter("QCN", qcn));
				cmd.Parameters.Add(new OleDbParameter("待驗數量", amount));
				cmd.Parameters.Add(new OleDbParameter("送檢次數", num + 1));
				cmd.Parameters.Add(new OleDbParameter("最後送檢編號", to));
				//cmd.Parameters.Add(new OleDbParameter("送檢日期", DateTime.Today));
				OleDbParameter paramDate = new OleDbParameter();
				paramDate.OleDbType = OleDbType.DBTimeStamp;
				paramDate.Value = DateTime.Now.ToString("s");
				cmd.Parameters.Add(paramDate);

				result = cmd.ExecuteNonQuery();

				cmdText = "UPDATE 產品檢驗 SET 重驗 = True WHERE 工時資料編號 = ?";
				cmd = new OleDbCommand(cmdText, this.Connection);
				cmd.Transaction = transaction;
				//cmd.Parameters.Add(new OleDbParameter("最後送檢編號", to));
				cmd.Parameters.Add(new OleDbParameter("工時資料編號", from));
				cmd.ExecuteNonQuery();

				cmdText = "UPDATE 產品檢驗 SET 最後送檢編號 = ? WHERE 最後送檢編號 = ?";
				cmd = new OleDbCommand(cmdText, this.Connection);
				cmd.Transaction = transaction;
				cmd.Parameters.Add(new OleDbParameter("最後送檢編號1", to));
				cmd.Parameters.Add(new OleDbParameter("最後送檢編號2", from));
				cmd.ExecuteNonQuery();

				cmdText = "INSERT INTO NG原因 (工時資料編號, 原因, 來源編號) SELECT '" + to + "' as 工時資料編號, 原因, 來源編號 FROM NG原因 WHERE 工時資料編號 = ?";
				cmd = new OleDbCommand(cmdText, this.Connection);
				cmd.Transaction = transaction;
				cmd.Parameters.Add(new OleDbParameter("工時資料編號", from));
				cmd.ExecuteNonQuery();

				transaction.Commit();
				this.Connection.Close();

				return result;
			}
			catch (Exception ex)
			{
				transaction.Rollback();
				this.Connection.Close();
				throw ex;
			}
			
		}
	}

    public partial class 工時TableAdapter
    {
        static 工時TableAdapter _instance;
        public static 工時TableAdapter Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new 工時TableAdapter();

                return _instance;
            }
        }
		public static OleDbDataAdapter InstanceAdapter
		{
			get
			{
				return Instance.Adapter;
			}
		}

        public int FillFilledDataBy員工編號(DatabaseSet.工時DataTable table, string 員工編號)
        {
            員工編號 = 員工編號.Replace("'","''");

            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT 員工編號, 日期 FROM 工時 GROUP BY 員工編號, 日期" +
                             " HAVING 員工編號 = '" + 員工編號 + "' AND 日期 >= #" + Settings.UnfilledDate.ToString("yyyy/MM/dd") + "# AND 日期 <= #" + DateTime.Today.ToString("yyyy/MM/dd") + "# AND SUM(工時) >= " + Settings.WorkingHoursPerDay;
            cmd.Connection = this.Connection;

            this.Adapter.SelectCommand = cmd;
            return this.Adapter.Fill(table);
        }

        public DatabaseSet.工時DataTable GetFilledDataBy員工編號(string 員工編號)
        {
            DatabaseSet.工時DataTable table = new DatabaseSet.工時DataTable();
			table.PrimaryKey = null;
			table.Columns.Remove("編號");
            FillFilledDataBy員工編號(table, 員工編號);
            return table;
        }

        public DatabaseSet.工時DataTable GetUnfilledData()
        {
            DatabaseSet.工時DataTable table = new DatabaseSet.工時DataTable();
			table.PrimaryKey = null;
			table.Columns.Remove("編號");
            foreach (DatabaseSet.員工Row laborRow in DatabaseSet.員工Table)
            {
                DatabaseSet.工時DataTable tmpTable = GetFilledDataBy員工編號(laborRow.編號);
                DateTime from = Settings.UnfilledDate;
                DateTime to = DateTime.Today;
                DatabaseSet.假日DataTable holidayTable = 假日TableAdapter.Instance.GetByRange(from, to);
                for (DateTime date = from; date <= to; date = date.AddDays(1))
                {
                    if (!假日TableAdapter.Instance.IsHoliday(holidayTable, date))
                    {
                        DataRow[] rows = tmpTable.Select("日期 = #" + date.ToString("yyyy/MM/dd") + "#");
                        if (rows.Length == 0)
                        {
                            DatabaseSet.工時Row newRow = table.New工時Row();
                            newRow.員工姓名 = laborRow.姓名;
                            newRow.員工編號 = laborRow.編號;
                            newRow.日期 = date;
                            table.Add工時Row(newRow);
                        }
                    }
                }
            }
            //table.DefaultView.Sort = "日期, 員工編號";
            
            table.AcceptChanges();
            return table;
        }

        public int GetFinishProductAmount(string worksheet, int wpid)
        {
			string cmdTxt = "SELECT SUM(數量) FROM 工時 WHERE 工作單號 = '" + worksheet + "' AND 工品編號 = " + wpid + " GROUP BY 工作單號, 工品編號";
            OleDbCommand cmd = new OleDbCommand(cmdTxt);
            cmd.Connection = this.Connection;
            this.Connection.Open();
            object o = cmd.ExecuteScalar();
            int result = 0;
            if (o != null && o != DBNull.Value)
                result = (int)(double)o;
            this.Connection.Close();
            return result;
        }

        public int Fill(DatabaseSet.工時DataTable table, string 員工編號, string 工作單號, string 品號, bool date, DateTime from, DateTime to)
        {
            員工編號 = 員工編號.Replace("'", "''");
            工作單號 = 工作單號.Replace("'", "''");
            品號 = 品號.Replace("'", "''");

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append("SELECT 工時.編號, 借入產線, 員工編號, 工時.日期, 工作單號, 品號, 工時, 工時類型, 工時.數量, 待驗數量, 非生產編號, 備註, '無' AS 非生產名稱, 員工.姓名 AS 員工姓名, WP.編號 as 工品編號 " + 
						"FROM (((工時 INNER JOIN 員工 ON 工時.員工編號 = 員工.編號) "  +
								"LEFT JOIN 產品檢驗 ON 工時.編號 = 產品檢驗.工時資料編號 )" +
								"INNER JOIN 工作單品號 as WP ON 工時.工作單號 = WP.單號 AND 工時.工品編號 = WP.編號 )"
						);

            System.Collections.Generic.List<string> whereCond = new System.Collections.Generic.List<string>();

            whereCond.Add("非生產編號 = -1");

            if (員工編號.Trim() != string.Empty)
                whereCond.Add("員工編號 ='" + 員工編號 + "'");
            if (工作單號.Trim() != string.Empty)
                whereCond.Add("工作單號 LIKE '" + 工作單號 + "%'");
            if (品號.Trim() != string.Empty)
                whereCond.Add("品號 ='" + 品號 + "'");

            if (date)
            {
				whereCond.Add("工時.日期 >= #" + from.ToString("yyyy/MM/dd") + "#");
				whereCond.Add("工時.日期 <= #" + to.ToString("yyyy/MM/dd") + "#");
            }

            if (whereCond.Count > 0)
            {
                string whereStr = string.Join(" AND ", whereCond.ToArray());
                sb.Append(" WHERE " + whereStr);
            }

			sb.Append(" ORDER BY 工時.日期,工時.編號 ");

            OleDbCommand cmd = new OleDbCommand(sb.ToString());
            cmd.Connection = this.Connection;
            this.Adapter.SelectCommand = cmd;

            return this.Adapter.Fill(table);
        }

        public int Fill(DatabaseSet.工時DataTable table, string 員工編號, int 非生產編號, bool date, DateTime from, DateTime to)
        {
            員工編號 = 員工編號.Replace("'", "''");

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append("SELECT 工時.編號, 借入產線, 員工編號, 日期, 工作單號, NULL as 品號, 工時, 工時類型, 數量, NULL as 待驗數量, 非生產編號, 備註, 非生產.名稱 AS 非生產名稱, 員工.姓名 AS 員工姓名 FROM ( 工時 INNER JOIN 非生產 ON 工時.非生產編號 = 非生產.編號 ) INNER JOIN 員工 ON 工時.員工編號 = 員工.編號 ");

            System.Collections.Generic.List<string> whereCond = new System.Collections.Generic.List<string>();

            if (員工編號.Trim() != string.Empty)
                whereCond.Add("工時.員工編號 ='" + 員工編號 + "'");
            
            whereCond.Add("工時.非生產編號 =" + 非生產編號);

            if (date)
            {
                whereCond.Add("日期 >= #" + from.ToString("yyyy/MM/dd") + "#");
                whereCond.Add("日期 <= #" + to.ToString("yyyy/MM/dd") + "#");
            }

            if (whereCond.Count > 0)
            {
                string whereStr = string.Join(" AND ", whereCond.ToArray());
                sb.Append(" WHERE " + whereStr);
            }

            sb.Append(" ORDER BY 日期,工時.編號 ");

            OleDbCommand cmd = new OleDbCommand(sb.ToString());
            cmd.Connection = this.Connection;
            this.Adapter.SelectCommand = cmd;

            return this.Adapter.Fill(table);
        }

        public int Fill(DatabaseSet.工時DataTable table, string 員工編號, bool date, DateTime from, DateTime to)
        {
            員工編號 = 員工編號.Replace("'", "''");

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append("SELECT 工時.編號, 借入產線, 員工編號, 工時.日期, 工作單號, WP.編號 as 工品編號, 品號, 工時, 工時類型, 工時.數量, 待驗數量, QCN, 非生產編號, 備註, 非生產.名稱 as 非生產名稱, 員工.姓名 as 員工姓名 " + 
					  "FROM ((( 工時 INNER JOIN 非生產 ON 工時.非生產編號 = 非生產.編號 ) " +
						" LEFT JOIN 產品檢驗 ON 工時.編號 = 產品檢驗.工時資料編號 )" +
						" LEFT JOIN 工作單品號 as WP ON 工時.工作單號 = WP.單號 AND 工時.工品編號 = WP.編號) " +
						" INNER JOIN 員工 ON 工時.員工編號 = 員工.編號 ");

            System.Collections.Generic.List<string> whereCond = new System.Collections.Generic.List<string>();

            if (員工編號.Trim() != string.Empty)
                whereCond.Add("工時.員工編號 ='" + 員工編號 + "'");

            if (date)
            {
				whereCond.Add("工時.日期 >= #" + from.ToString("yyyy/MM/dd") + "#");
				whereCond.Add("工時.日期 <= #" + to.ToString("yyyy/MM/dd") + "#");
            }

            if (whereCond.Count > 0)
            {
                string whereStr = string.Join(" AND ", whereCond.ToArray());
                sb.Append(" WHERE " + whereStr);
            }

			sb.Append(" ORDER BY 工時.日期,工時.編號 ");

            OleDbCommand cmd = new OleDbCommand(sb.ToString());
            cmd.Connection = this.Connection;
            this.Adapter.SelectCommand = cmd;

            return this.Adapter.Fill(table);
        }

		public int DeleteEx(string id)
		{
			int retVal = 0;

			OleDbConnection conn = Instance.Connection;
			OleDbTransaction transaction = null;

			OleDbCommand cmd = new OleDbCommand();
			conn.Open();
			try
			{
				transaction = conn.BeginTransaction();

				cmd.Connection = conn;
				cmd.Transaction = transaction;

				//改正產品檢驗資料

				//取得產品檢驗資料
				cmd.CommandText = "SELECT * FROM 產品檢驗 WHERE 工時資料編號=?";
				cmd.Parameters.Clear();
				cmd.Parameters.Add(new OleDbParameter("工時資料編號", id));
				OleDbDataReader reader = cmd.ExecuteReader();
				if (reader.Read())
				{
					string last = reader["最後送檢編號"].ToString();
					int inspectDel = (int)reader["送檢次數"];

					reader.Close();

					cmd.CommandText = "SELECT * FROM 產品檢驗 WHERE 最後送檢編號=? AND 工時資料編號<>? ORDER BY 送檢次數 ASC";
					cmd.Parameters.Clear();
					cmd.Parameters.Add(new OleDbParameter("最後送檢編號old", last));
					cmd.Parameters.Add(new OleDbParameter("工時資料編號", id));

					OleDbDataReader reader2 = cmd.ExecuteReader();
					while (reader2.Read())
					{
						string nextID = reader2["工時資料編號"].ToString();
						int inspect = (int)reader2["送檢次數"];

						if (inspect > inspectDel)
						{
							//將該筆之後的檢驗資料做處理
							OleDbCommand cmd2 = new OleDbCommand();
							cmd2.Connection = conn;
							cmd2.Transaction = transaction;

							cmd2.CommandText = "UPDATE 產品檢驗 SET 送檢次數=送檢次數-1 WHERE 工時資料編號=?";
							cmd2.Parameters.Clear();
							cmd2.Parameters.Add(new OleDbParameter("工時資料編號", nextID));
							cmd2.ExecuteNonQuery();
						}
						else
						{
							//將該筆之前的檢驗資料做處理
						}
					}
					reader2.Close();

					//刪除產品檢驗資料
					cmd.CommandText = "DELETE FROM 產品檢驗 WHERE 工時資料編號=?";
					cmd.Parameters.Clear();
					cmd.Parameters.Add(new OleDbParameter("工時資料編號", id));
					cmd.ExecuteNonQuery();

					//挑出最後一筆檢驗紀錄
					cmd.CommandText = "SELECT 工時資料編號 FROM 產品檢驗 WHERE 最後送檢編號 =? ORDER BY 送檢次數 DESC";
					cmd.Parameters.Clear();
					cmd.Parameters.Add(new OleDbParameter("最後送檢編號old", last));

					reader2 = cmd.ExecuteReader();
					if (reader2.Read())
					{
						string maxID = reader2["工時資料編號"].ToString();
						reader2.Close();

						//將原有的最後檢驗紀錄更新
						cmd.CommandText = "UPDATE 產品檢驗 SET 最後送檢編號=?, 最後檢驗紀錄=FALSE, 重驗=TRUE WHERE 最後送檢編號=?";
						cmd.Parameters.Clear();
						cmd.Parameters.Add(new OleDbParameter("最後送檢編號new", maxID));
						cmd.Parameters.Add(new OleDbParameter("最後送檢編號old", last));
						cmd.ExecuteNonQuery();

						//將最後一筆設成最後檢驗記錄
						cmd.CommandText = "UPDATE 產品檢驗 SET 最後檢驗紀錄=TRUE, 重驗=FALSE WHERE 工時資料編號=?";
						cmd.Parameters.Clear();
						cmd.Parameters.Add(new OleDbParameter("工時資料編號", maxID));
						cmd.ExecuteNonQuery();
					}
					if (!reader2.IsClosed)
						reader2.Close();

				}
				if (!reader.IsClosed)
					reader.Close();

				//刪除工時資料
				cmd.CommandText = "DELETE FROM 工時 WHERE 編號=?";
				cmd.Parameters.Clear();
				cmd.Parameters.Add(new OleDbParameter("編號", id));
				retVal = cmd.ExecuteNonQuery();

				transaction.Commit();
			}
			catch (Exception ex)
			{
				try
				{
					transaction.Rollback();
				}
				catch (Exception) { }

				try
				{
					conn.Close();
				}
				catch (Exception) { }

				throw ex;
			}

			conn.Close();

			return retVal;
		}
    }

    public partial class 使用者TableAdapter
    {
        static 使用者TableAdapter _instance;
        public static 使用者TableAdapter Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new 使用者TableAdapter();

                return _instance;
            }
        }
    }
}
