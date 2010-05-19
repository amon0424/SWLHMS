using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Microsoft.Office.Interop.Excel;

using DataTable = System.Data.DataTable;
namespace Mong.Report
{
    class ReportSourceProfile
    {
        DataTable _table;
        Dictionary<DataColumn, ReportColumn> _columnMap = new Dictionary<DataColumn, ReportColumn>();
        List<ReportColumn> _columns = new List<ReportColumn>();
        string _reportName;
        XlHAlign _columnHeaderHAlign = XlHAlign.xlHAlignLeft;
        bool _columnHeaderBold = true;
        bool _columnHeaderHGrid = true;
        bool _columnHeaderVGrid = false;
        bool _horizontalGrid = false;
        bool _verticalGrid = false;
        bool _includeFormula = false;

        public DataTable Table
        {
            get { return _table; }
            set { _table = value; }
        }
        public List<ReportColumn> Columns
        {
            get { return _columns; }
            set { _columns = value; }
        }
        public Dictionary<DataColumn, ReportColumn> ColumnMap
        {
            get { return _columnMap; }
            set { _columnMap = value; }
        }
        public string ReportName
        {
            get { return _reportName; }
            set { _reportName = value; }
        }
        public XlHAlign ColumnHeaderHAlign
        {
            get { return _columnHeaderHAlign; }
            set { _columnHeaderHAlign = value; }
        }
        public bool ColumnHeaderBold
        {
            get { return _columnHeaderBold; }
            set { _columnHeaderBold = value; }
        }
        public bool ColumnHeaderHGrid
        {
            get { return _columnHeaderHGrid; }
            set { _columnHeaderHGrid = value; }
        }
        public bool ColumnHeaderVGrid
        {
            get { return _columnHeaderVGrid; }
            set { _columnHeaderVGrid = value; }
        }
        public bool HorizontalGrid
        {
            get { return _horizontalGrid; }
            set { _horizontalGrid = value; }
        }
        public bool VerticalGrid
        {
            get { return _verticalGrid; }
            set { _verticalGrid = value; }
        }
        public bool IncludeFormula
        {
            get { return _includeFormula; }
            set { _includeFormula = value; }
        }
        

        public ReportSourceProfile()
        {
        }

        public ReportSourceProfile(DataTable table)
        {
			this.Table = table;
        }

		public ReportColumn AddExportColumn(string colName)
        {
            return AddExportColumn(colName, null);
        }

		public ReportColumn AddExportColumn(string colName, string alias)
        {
            DataColumn col = _table.Columns[colName];
            if (col == null)
				throw new SWLHMSException("找不到資料行 '" + colName + "'");

            return AddExportColumn(col, alias);
        }

		public ReportColumn AddExportColumn(DataColumn column)
        {
            return AddExportColumn(column, null);
        }

		public ReportColumn AddExportColumn(DataColumn column, string alias)
        {
            ReportColumn rptCol = new ReportColumn(column);
            rptCol.Name = alias;

            AddExportColumn(rptCol);

			return rptCol;
        }

		public void AddExportColumn(IEnumerable<DataColumn> columns)
        {
            foreach (DataColumn column in columns)
                AddExportColumn(columns);
        }

        public void AddExportColumn(ReportColumn rptCol)
        {
			rptCol.Index = _columns.Count;
            _columns.Add(rptCol);
            _columnMap.Add(rptCol.Column, rptCol);
			
			rptCol.Column.ExtendedProperties["export"] = true;
        }

        public void ExcludeExportColumn(List<DataColumn> exclude)
        {
            _columns.Clear();
            _columnMap.Clear();
            foreach (DataColumn col in _table.Columns)
            {
                if (!exclude.Contains(col))
                    AddExportColumn(col);
            }
        }

        public bool Contains(DataColumn column)
        {
            //return _columnMap.ContainsKey(column);
			return column.ExtendedProperties.Contains("export") && (bool)column.ExtendedProperties["export"];
        }

		public int IndexOf(DataColumn column)
		{
			if (!this.Contains(column))
				return -1;

			return this.ColumnMap[column].Index;
			//foreach (ReportColumn col in this.Columns)
			//{
			//    //if (this.Contains(col))
			//    //    index++;

			//    //if (col == column)
			//    //    break;

			//    if (col.Column == column)
			//        return col.Index;
			//}

			//return -1;
		}

		public int IndexOf(string columnName)
		{
			return IndexOf(this.Table.Columns[columnName]);
		}
    }

    public class ReportColumn
    {
        DataColumn _column;
		int _mergeSpan = 0;
		string _mergeTitle;
        string _name;
		
		int _index;

        public DataColumn Column
        {
            get { return _column; }
            set { _column = value; }
        }
        public string Name
        {
            get 
            {
                if (_name == null)
                    return _column.Caption;
                return _name; 
            }
            set { _name = value; }
        }
		public int Index
		{
			get { return _index; }
			set { _index = value; }
		}
		public int MergeSpan
		{
			get { return _mergeSpan; }
			set { _mergeSpan = value; }
		}
		public string MergeTitle
		{
			get { return _mergeTitle; }
			set { _mergeTitle = value; }
		}

        public ReportColumn(DataColumn col)
        {
            _column = col;
        }
    }
}
