using System;
using System.Data;
using System.Data.OleDb;

namespace Mong {
    
    
    public partial class ReportDataSet 
	{
		partial class InspectListReportDataTable
		{
			public static InspectListReportDataTable GetData(DateTime from, DateTime to, string partNumber, string qcn, string worksheetFrom, string worksheetTo, bool group, string line)
			{
				OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.dbConnectionString);
				OleDbCommand cmd = new OleDbCommand();
				cmd.Connection = conn;

				System.Collections.Generic.List<string> whereList = new System.Collections.Generic.List<string>();
				whereList.Add("檢驗 = True");

				//處理條件
				if (!string.IsNullOrEmpty(qcn))
				{
					cmd.Parameters.Add(new OleDbParameter("QCN", qcn + "%"));
					whereList.Add("QCN LIKE ?");
				}

				if (!string.IsNullOrEmpty(partNumber))
				{
					cmd.Parameters.Add(new OleDbParameter("品號", partNumber + "%"));
					whereList.Add("P.品號 LIKE ?");
				}

				if (!string.IsNullOrEmpty(worksheetFrom))
				{
					cmd.Parameters.Add(new OleDbParameter("工作單號1", worksheetFrom));
					whereList.Add("W.單號 >= ?");
				}

				if (!string.IsNullOrEmpty(worksheetTo))
				{
					cmd.Parameters.Add(new OleDbParameter("工作單號2", worksheetTo));
					whereList.Add("W.單號 <= ?");
				}

				if (from != DateTime.MinValue)
				{
					OleDbParameter param = new OleDbParameter("日期1", OleDbType.Date);
					param.Value = from;
					cmd.Parameters.Add(param);
					whereList.Add("Q.日期 >= ?");
				}

				if (to != DateTime.MaxValue)
				{
					OleDbParameter param = new OleDbParameter("日期2", OleDbType.Date);
					param.Value = to;
					cmd.Parameters.Add(param);
					whereList.Add("Q.日期 <= ?");
				}

				if (!string.IsNullOrEmpty(line))
				{
					cmd.Parameters.Add(new OleDbParameter("產線", line));
					whereList.Add("產線 = ?");
				}

				if (group)
				{
					whereList.Add("最後檢驗紀錄 = True");
				}

				string cmdText = "SELECT Q.日期 as 檢驗日期, 產線, W.單號 as 工作單號, P.品號, 客戶 as 客戶名稱, WP.數量 as 總數量, 待驗數量 as 檢驗數量, 送檢次數, QCN, IIF(檢驗結果,'OK',IIF(特許,'Concession','NG')) as 檢驗狀態, 工時資料編號, 最後送檢編號, 最後檢驗紀錄, WP.編號 as 工品編號" +
								" FROM ((((工時 as H INNER JOIN 產品檢驗 as Q on H.編號 = Q.工時資料編號)" +
								" INNER JOIN 工作單 as W ON H.工作單號 = W.單號)" +
								" INNER JOIN 工作單品號 as WP ON H.工作單號 = WP.單號 AND H.工品編號 = WP.編號)" +
								" INNER JOIN 產品品號 as P ON WP.品號 = P.品號)";

				if (whereList.Count > 0)
					cmdText += " WHERE " + string.Join(" AND ", whereList.ToArray());

				cmdText += " ORDER BY 單據日期, W.單號, P.品號, WP.編號, 最後送檢編號, 送檢次數";

				cmd.CommandText = cmdText;
				OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);

				InspectListReportDataTable table = new InspectListReportDataTable();
				adapter.Fill(table);

				//取得品質履歷
				foreach (DataRow row in table)
				{
					//取得舊NG原因
					string id = row["工時資料編號"].ToString();
					string[] ngReasons = DatabaseSet.GetNGReason(id);
					row["品質履歷"] = string.Join("\n", ngReasons);
				}

				return table;
			}

			public static InspectListReportDataTable GetHistoryData(string lastID)
			{
				OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.dbConnectionString);
				OleDbCommand cmd = new OleDbCommand();
				cmd.Connection = conn;

				string cmdText = "SELECT Q.日期 as 檢驗日期, 產線, P.品號, QCN, 待驗數量 as 檢驗數量, W.單號 as 工作單號,送檢次數, IIF(檢驗結果,'OK',IIF(特許,'Concession','NG')) as 檢驗狀態, 客戶 as 客戶名稱, 工時資料編號" +
								" FROM ((((工時 as H INNER JOIN 產品檢驗 as Q on H.編號 = Q.工時資料編號)" +
								" INNER JOIN 工作單 as W ON H.工作單號 = W.單號)" +
								" INNER JOIN 工作單品號 as WP ON H.工作單號 = WP.單號 AND H.工品編號 = WP.編號)" +
								" INNER JOIN 產品品號 as P ON WP.品號 = P.品號)" +
								" WHERE 重驗=True AND 最後送檢編號=?"+
								" ORDER BY 單據日期, W.單號, P.品號, WP.編號, 送檢次數";

				cmd.CommandText = cmdText;
				cmd.Parameters.Add(new OleDbParameter("最後送檢編號", lastID));

				OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);

				InspectListReportDataTable table = new InspectListReportDataTable();
				adapter.Fill(table);

				//取得品質履歷
				foreach (DataRow row in table)
				{
					//取得舊NG原因
					string id = row["工時資料編號"].ToString();
					string[] ngReasons = DatabaseSet.GetNGReason(id);
					row["品質履歷"] = string.Join("\n", ngReasons);
				}

				return table;
			}
		}
	
        partial class UnfinishedWorksheetReportSourceDataTable
        {
        }
    
        partial class LineLaborHourReportSourceDataTable
        {
        }
    
        partial class UnitPriceReportDataTable
        {
        }
    
        partial class FinishedWorksheetReportSourceDataTable
        {
        }
    }
}

namespace Mong.ReportDataSetTableAdapters {
    
    
    public partial class FinishedWorksheetReportSourceTableAdapter {
    }
}
