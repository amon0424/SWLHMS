using System.Data.OleDb;
using System.Data;

namespace Mong {


    partial class ViewDataSet
    {
    }
}

namespace Mong.ViewDataSetTableAdapters
{
    public partial class 品號ViewTableAdapter : global::System.ComponentModel.Component
    {
        System.Data.OleDb.OleDbCommand _updateCommand;
        System.Data.OleDb.OleDbCommand _insertCommand;
        System.Data.OleDb.OleDbCommand _deleteCommand;

        public System.Data.OleDb.OleDbCommand UpdateCommand
        {
            get
            {
                if (_updateCommand == null)
                {
                    _updateCommand = new System.Data.OleDb.OleDbCommand();
                    _updateCommand.Connection = this.Connection;
                    _updateCommand.CommandText = "UPDATE 產品品號 "+
                                                 "SET 品號 = ?, 系列名稱 = ?, 系列編號 = ?, 品名 = ?, 產線 =?, 工時 = ? " +
                                                 "WHERE (品號 = ?)";

                    _updateCommand.Parameters.Add(new OleDbParameter("品號", OleDbType.WChar, 255, ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "品號", DataRowVersion.Current, false, null));
                    _updateCommand.Parameters.Add(new OleDbParameter("系列名稱", OleDbType.WChar, 255, ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "系列名稱", DataRowVersion.Current, false, null));
                    _updateCommand.Parameters.Add(new OleDbParameter("產品編號", OleDbType.Integer, 0, ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "系列編號", DataRowVersion.Current, false, null));
                    _updateCommand.Parameters.Add(new OleDbParameter("品名", OleDbType.WChar, 255, ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "品名", DataRowVersion.Current, false, null));
                    _updateCommand.Parameters.Add(new OleDbParameter("產線", OleDbType.WChar, 255, ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "產線", DataRowVersion.Current, false, null));
                    _updateCommand.Parameters.Add(new OleDbParameter("工時", OleDbType.Numeric, 0, ParameterDirection.Input, ((byte)(18)), ((byte)(4)), "工時", DataRowVersion.Current, false, null));
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
                    _insertCommand.CommandText = "INSERT INTO 產品品號 " +
                                                 "(品號, 系列名稱, 系列編號, 品名, 產線, 工時) " +
                                                 "VALUES  (?,?,?,?,?,?)";

                    _insertCommand.Parameters.Add(new OleDbParameter("品號", OleDbType.WChar, 255, ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "品號", DataRowVersion.Current, false, null));
                    _insertCommand.Parameters.Add(new OleDbParameter("系列名稱", OleDbType.WChar, 255, ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "系列名稱", DataRowVersion.Current, false, null));
                    _insertCommand.Parameters.Add(new OleDbParameter("產品編號", OleDbType.Integer, 0, ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "系列編號", DataRowVersion.Current, false, null));
                    _insertCommand.Parameters.Add(new OleDbParameter("品名", OleDbType.WChar, 255, ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "品名", DataRowVersion.Current, false, null));
                    _insertCommand.Parameters.Add(new OleDbParameter("產線", OleDbType.WChar, 255, ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "產線", DataRowVersion.Current, false, null));
                    _insertCommand.Parameters.Add(new OleDbParameter("工時", OleDbType.Numeric, 0, ParameterDirection.Input, ((byte)(18)), ((byte)(4)), "工時", DataRowVersion.Current, false, null));
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
                    _deleteCommand.CommandText = "DELETE FROM 產品品號 WHERE (品號 = ?)";

                    _deleteCommand.Parameters.Add(new OleDbParameter("品號", OleDbType.WChar, 255, ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "品號", DataRowVersion.Original, false, null));
                }
                return _deleteCommand;
            }
            set { _deleteCommand = value; }
        }


        public int UpdateBy品號(ViewDataSet.品號ViewRow row)
        {
            return UpdateBy品號(row.品號, row.系列名稱, row.系列編號, row.品名, row.產線, row.工時, row["品號", System.Data.DataRowVersion.Original].ToString());
        }

        public int Update(ViewDataSet.品號ViewDataTable table)
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


    }
}
