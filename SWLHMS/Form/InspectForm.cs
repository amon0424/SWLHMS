using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mong
{
	public enum InspeceMode
	{
		ByPn, ByQcNo, OnlyUnre, OnlyNg
	}

	public partial class InspectForm : Form
	{
		DataGridViewCellStyle _okStyle;
		DataGridViewCellStyle _ngStyle;
		DataGridViewCellStyle _rejectStyle;
		DataGridViewCellStyle _unableStyle;
		DataGridViewCellStyle _concessionStyle;
		DataGridViewCellStyle _inspectImmStyle;
		DataGridViewCellStyle _expiredStyle;
		DataGridViewCellStyle _unexpiredStyle;

		DatabaseSet.待驗清單DataTable _table;
		DataTable _groupTable;
		
		InspeceMode _inspectMode;

		InspeceMode InspectMode
		{
			get { return _inspectMode; }
			set 
			{
				_inspectMode = value;

				bool inspectByPn = _inspectMode == InspeceMode.ByPn;

				colQCN.Visible = !inspectByPn;
				colInspectNum.Visible = !inspectByPn;
				col送檢次數.Visible = !inspectByPn;
				col原因.Visible = !inspectByPn;

				colAccNum.Visible = inspectByPn;
				colReinspectNum.Visible = inspectByPn;
				colGroupNum.Visible = inspectByPn;

				bool onlyUnre = _inspectMode == InspeceMode.OnlyUnre;

				this.colInspectNum.HeaderText = (onlyUnre ? "檢驗數量" : "待驗數量");
				this.colNG原因.Visible = !onlyUnre;
				this.colNG處理.Visible = !onlyUnre;
			}
		}
		public DataTable GroupTable
		{
			get 
			{
				if (_table == null)
					return null;

				if (_groupTable == null)
				{
					if (!_table.Columns.Contains("重檢"))
						_table.Columns.Add("重檢", typeof(int), "IIF(送檢次數>1,1,0)");

					DataTableHelper helper = new DataTableHelper();
					string field = "待驗提醒, MAX(日期) 日期, 產線, 工作單號, 品號, 總數量, 已完成, 預計完成日, SUM(待驗數量) 累計待驗數, 工品編號, COUNT(QCN) 筆數, SUM(重檢) 重檢";

					_groupTable = helper.CreateGroupByTable("GroupByPn", _table, field);
					//DataTable groupTable = helper.SelectGroupByInto("GroupByPn", _table, "待驗提醒, MAX(日期) 日期, 產線, 工作單號, 品號, 總數量, 已完成, 預計完成日, SUM(待驗數量) 累計待驗數", null, "產線, 工作單號, 品號");
					//DataTable groupTable = new DataTable();

					_groupTable.Columns.Add("項次", typeof(int));
					_groupTable.Columns.Add("檢驗", typeof(bool)).DefaultValue = false;
					_groupTable.Columns.Add("檢驗結果", typeof(bool)).DefaultValue = false;
					_groupTable.Columns.Add("NG處理", typeof(string));
					_groupTable.Columns.Add("NG原因", typeof(string)).DefaultValue = null;
					_groupTable.Columns.Add("舊NG原因", typeof(string));
					_groupTable.Columns.Add("特許", typeof(bool));
					//_groupTable.Columns.Add("筆數", typeof(int));

					helper.InsertGroupByInto(_groupTable, _table, field, null, "產線, 工作單號, 工品編號");
					_groupTable.DefaultView.Sort = "日期";
					
					int count = 0;
					foreach (DataRowView row in _groupTable.DefaultView)
						row.Row["項次"] = ++count;
				}

				return _groupTable; 
			}
			set { _groupTable = value; }
		}
		public InspectForm()
		{
			InitializeComponent();

			_okStyle = new DataGridViewCellStyle(dgv.DefaultCellStyle);
			_okStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			_okStyle.BackColor = _okStyle.SelectionBackColor = Color.LimeGreen;
			_okStyle.ForeColor = Color.White;

			_ngStyle = new DataGridViewCellStyle(dgv.DefaultCellStyle);
			_ngStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			_ngStyle.BackColor = _ngStyle.SelectionBackColor = Color.Red;
			_ngStyle.ForeColor = Color.White;

			_inspectImmStyle = new DataGridViewCellStyle(dgv.DefaultCellStyle);
			_inspectImmStyle.BackColor = _inspectImmStyle.SelectionBackColor = Color.Yellow;
			_inspectImmStyle.ForeColor = _inspectImmStyle.SelectionForeColor = Color.Black;

			_rejectStyle = new DataGridViewCellStyle(_ngStyle);
			_rejectStyle.Alignment = DataGridViewContentAlignment.TopLeft;

			_concessionStyle = new DataGridViewCellStyle(_inspectImmStyle);
			_concessionStyle.Alignment = DataGridViewContentAlignment.TopLeft;

			_unableStyle = new DataGridViewCellStyle(dgv.DefaultCellStyle);
			_unableStyle.BackColor = _unableStyle.SelectionBackColor = Color.DarkGray;

			_expiredStyle = new DataGridViewCellStyle(dgv.DefaultCellStyle);
			_expiredStyle.BackColor = _ngStyle.SelectionBackColor = Color.Red;
			_expiredStyle.ForeColor = Color.White;

			_unexpiredStyle = new DataGridViewCellStyle(dgv.DefaultCellStyle);
			_unexpiredStyle.BackColor = Color.Yellow;
			_unexpiredStyle.ForeColor = Color.Blue;

			//dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dgv.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

			//col檢驗結果.DefaultCellStyle = new DataGridViewCellStyle(col檢驗結果.DefaultCellStyle);
			//col檢驗結果.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

			this.InspectMode = InspeceMode.ByPn;
			this.WindowState = FormWindowState.Maximized;
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			if (rbOnlyUnreinspect.Checked)
				SearchUnreinspectList();
			else
				SearchList();
		}

		private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.Value == null || e.Value == DBNull.Value)
				return;

			if (e.ColumnIndex == col檢驗結果.Index ||
				e.ColumnIndex == colNG處理.Index ||
				e.ColumnIndex == col待驗提醒.Index)
			{
				UpdateCellColor(e.RowIndex);
			}
		}

		private void dgv_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			if (dgv.CurrentCell != null)
			{
				DataGridViewCell cell = dgv.CurrentCell;
				if (cell.ColumnIndex == col檢驗結果.Index || 
					cell.ColumnIndex == col檢驗.Index ||
					cell.ColumnIndex == colNG處理.Index) 
				{
					dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
				}
			}
		}

		private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex == -1)
				return;

			DataGridViewCell cell = dgv[e.ColumnIndex, e.RowIndex];
			if (cell.ColumnIndex == col檢驗結果.Index)
			{
				cell.OwningRow.Cells[col檢驗.Index].Value = true;
				UpdateCellColor(e.RowIndex);
			}
			else if (cell.ColumnIndex == col檢驗.Index)
			{
				if (!(bool)cell.Value)
					dgv.Rows[e.RowIndex].Cells[col檢驗結果.Index].Value = false;

				UpdateCellColor(e.RowIndex);
			}
			else if (cell.ColumnIndex == colNG處理.Index)
			{
				if (cell.Value != DBNull.Value && cell.Value != null)
				{
					bool concession = (string)cell.Value == (string)colNG處理.Items[1];
					dgv.Rows[e.RowIndex].Cells[col特許.Index].Value = concession;
				}

				UpdateCellColor(e.RowIndex);
			}
		}

		private void btnSend_Click(object sender, EventArgs e)
		{
			try
			{
				if(_table != null)
				{
					//檢查是否填寫完整
					DataTable table = this.InspectMode == InspeceMode.ByPn ? this.GroupTable : _table;

					DataRow[] rows = table.Select("檢驗=True AND 檢驗結果=False");
					
					StringBuilder error = new StringBuilder();
					
					foreach (DataRow row in rows)
					{
						if (string.IsNullOrEmpty(row["NG原因"] as string))
							error.AppendLine("項次" + row["項次"] + " 必須填寫NG原因");

						if (string.IsNullOrEmpty(row["NG處理"] as string))
							error.AppendLine("項次" + row["項次"] + " 必須選擇NG處理方式");

						if (error.Length > 100)
						{
							error.AppendLine("...");
							break;
						}
					}
					if (error.Length != 0)
						throw new SWLHMSException(error.ToString());

					if (MessageBox.Show("資料經送出後不可再修改，請確認後繼續", "送出確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
					{
						if (this.InspectMode == InspeceMode.ByPn)
						{
							//將GroupTable的內容回填到Table上
							rows = table.Select("檢驗=True");
							foreach (DataRow groupRow in rows)
							{
								if (!groupRow.IsNull("工作單號") && !groupRow.IsNull("工品編號"))
								{
									string worksheet = groupRow["工作單號"].ToString();
									int wpid = (int)groupRow["工品編號"];

									DataRow[] srcRow = _table.Select("工作單號= '" + worksheet + "' AND 工品編號=" + wpid);
									foreach (DataRow row in srcRow)
									{
										row["檢驗"] = true;
										row["檢驗結果"] = groupRow["檢驗結果"];
										row["特許"] = groupRow["特許"];
										row["NG處理"] = groupRow["NG處理"];
										row["NG原因"] = groupRow["NG原因"];
									}
								}
							}
						}
						int ok;
						int update = DatabaseSet.UpdateInspectList(_table, out ok);

						MessageBox.Show("更新了 " + update + " 筆檢驗資料\n共 " + ok + " 筆檢驗OK");
						SearchList();
					}
				}
			}
			catch(Exception ex)
			{
				Global.ShowError(ex);
			}
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			
			if (e.ColumnIndex == colNG原因.Index)
			{
				DataGridViewCell cell = dgv[e.ColumnIndex, e.RowIndex];
				bool notPass = !(bool)dgv[col檢驗結果.Index, e.RowIndex].Value &&
								(bool)dgv[col檢驗.Index, e.RowIndex].Value;

				cell.ReadOnly = !notPass;
				//UpdateNGReasonButton(cell);
				//btnNGReason.Visible = true;
				
			}
			else
			{
				//btnNGReason.Visible = false;
				//btnNGReason.Tag = null;
			}
		}

		private void btnNGReason_Click(object sender, EventArgs e)
		{
			try
			{
				DataGridViewCell cell = btnNGReason.Tag as DataGridViewCell;
				if (cell != null)
				{
					NGReasonForm form = new NGReasonForm();
					string oriReason = cell.Value as string;
					form.NGReason = oriReason;
					if (form.ShowDialog() == DialogResult.OK)
					{
						string newReason = form.NGReason;
						cell.Value = newReason;
						//cell.Value = cell.Value + "\n" + newReason;
					}
				}
			}
			catch (Exception ex)
			{
				Global.ShowError(ex);
			}
		}

		private void dgv_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.C)
			{
				if (dgv.CurrentCell != null && dgv.CurrentCell.Value != DBNull.Value)
				{
					try
					{
						Clipboard.SetText(dgv.CurrentCell.Value.ToString());
					}
					catch (Exception) { }
				}
			}
		}

		private void rbInspectByPn_CheckedChanged(object sender, EventArgs e)
		{
			if (rbInspectByPn.Checked)
			{
				if (this.InspectMode == InspeceMode.OnlyUnre)
					SearchList();

				this.InspectMode = InspeceMode.ByPn;
				bindingSource.DataSource = this.GroupTable;
			}
		}

		private void rbInspectByQcN_CheckedChanged(object sender, EventArgs e)
		{
			if (rbInspectByQcN.Checked)
			{
				if (this.InspectMode == InspeceMode.OnlyUnre)
					SearchList();

				this.InspectMode = InspeceMode.ByQcNo;
				bindingSource.DataSource = _table;
			}
		}

		private void rbOnlyUnreinspect_CheckedChanged(object sender, EventArgs e)
		{
			if (rbOnlyUnreinspect.Checked)
			{
				if (this.InspectMode != InspeceMode.OnlyUnre)
					SearchUnreinspectList();

				this.InspectMode = InspeceMode.OnlyUnre;
			}
		}

		private void bindingSource_ListChanged(object sender, ListChangedEventArgs e)
		{
			dgv.ColumnHeadersHeight = this.InspectMode == InspeceMode.ByPn ? 50 : 25;

			dgv.AutoResizeColumns();
			dgv.Columns[0].Width = 40;
			dgv.Columns[1].Width = 60;
			colNG原因.Width = colNG處理.Width = 100;
			col項次.Width = col序號.Width = 50;
			col檢驗結果.Width = col送檢次數.Width = this.InspectMode == InspeceMode.ByPn ? 120 : 80;

			col檢驗結果.HeaderText = this.InspectMode == InspeceMode.ByPn ? "整批\n檢驗處理" : "檢驗狀態";
			col檢驗結果.HeaderCell.Style = new DataGridViewCellStyle(dgv.ColumnHeadersDefaultCellStyle);
			if (this.InspectMode == InspeceMode.ByPn)
			{
				col檢驗結果.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
				col檢驗結果.HeaderCell.Style.WrapMode = DataGridViewTriState.True;
				
				Padding padding = col檢驗結果.HeaderCell.Style.Padding;
				padding.Left = 20;
				col檢驗結果.HeaderCell.Style.Padding = padding;
			}

			//dgv.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
			//col檢驗結果.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
		}

		void UpdateCellColor(int rowIndex)
		{
			DataGridViewCell cell = dgv[col檢驗結果.Index, rowIndex];

			object inspectedObj = cell.OwningRow.Cells[col檢驗.Index].Value;
			bool inspected = false;
			bool pass = false;
			if (inspectedObj != null && (bool)inspectedObj)
			{
				inspected = true;
				pass = (bool)cell.Value;
				cell.Style = pass ? _okStyle : _ngStyle;
			}
			else
				cell.Style = null;

			cell = dgv[col待驗提醒.Index, rowIndex];
			if (cell.Value != DBNull.Value)
				cell.Style = _inspectImmStyle;
			else
				cell.Style = null;

			cell = dgv[col特許.Index, rowIndex];
			DataGridViewCell ngCell = dgv[colNG處理.Index, rowIndex];
			DataGridViewCell reasonCell = dgv[colNG原因.Index, rowIndex];
			if (inspected && !pass)
			{
				if (cell.Value != DBNull.Value && cell.Value != null)
				{
					bool concession = (bool)cell.Value;
					ngCell.Style = concession ? _concessionStyle : _rejectStyle;
				}
				else
					ngCell.Style = null;

				ngCell.ReadOnly = false;
				reasonCell.Style = null;
				//reasonCell.Tag = true;
			}
			else
			{
				reasonCell.Style = ngCell.Style = _unableStyle;
				ngCell.ReadOnly = true;
				//reasonCell.Tag = null;
			}

			cell = dgv[colEstShipDate.Index, rowIndex];
			if (cell.Value != DBNull.Value)
			{
				DateTime date = (DateTime)cell.Value;
				TimeSpan interval = date.Subtract(DateTime.Today);
				if (interval.TotalDays <= 0)
					cell.Style = _expiredStyle;
				else if (interval.TotalDays <= 3)
					cell.Style = _unexpiredStyle;
				else
					cell.Style = null;
			}
			else
				cell.Style = null;
		}

		void SearchList()
		{
			string line = null;
			string name = null;

			DateTime from = DateTime.MinValue;
			DateTime to = DateTime.MaxValue;

			_table = DatabaseSet.GetInspectList(line, name, from, to);
			_table.Columns.Add("NG處理", typeof(string));

			string sort = bindingSource.Sort;
			bindingSource.Sort = null;

			bindingSource.DataSource = null;
			this.GroupTable = null;
			if (this.InspectMode == InspeceMode.ByPn)
			{
				bindingSource.DataSource = this.GroupTable;
			}
			else
			{
				bindingSource.DataSource = _table;
			}
			bindingSource.Sort = sort;

			btnSend.Enabled = _table.Rows.Count > 0;
			dgv.EditMode = DataGridViewEditMode.EditOnEnter;
		}

		void SearchUnreinspectList()
		{
			string line = null;
			string name = null;

			_table = DatabaseSet.GetUnreinspectList(line, name);
			_table.Columns.Add("NG處理", typeof(string));

			string sort = bindingSource.Sort;
			bindingSource.Sort = null;

			this.GroupTable = null;
			this.InspectMode = InspeceMode.OnlyUnre;
			bindingSource.DataSource = _table;
			bindingSource.Sort = sort;

			btnSend.Enabled = false;
			dgv.EditMode = DataGridViewEditMode.EditProgrammatically;
			
		}
		
	}
}
