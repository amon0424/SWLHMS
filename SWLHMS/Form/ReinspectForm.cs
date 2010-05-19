using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mong
{
	public partial class ReinspectForm : Form
	{
		BindingSource _oriBindingSource;
		DatabaseSet.工時DataTable _dataTable;
		EditHourDataForm _editForm;

		DatabaseSet.工時Row _dataRow;
		decimal _remainHour;
		bool _isHoliday;

		public bool IsHoliday
		{
			get { return _isHoliday; }
			set 
			{
				_isHoliday = value;

				ckbOvertime.Visible = !_isHoliday;
			}
		}

		BindingSource OriBindingSource
		{
			get
			{
				return _oriBindingSource;
			}
			set
			{
				_oriBindingSource = value;

				if (_dataTable == null)
					throw new SWLHMSException("必須先設定資料表");

				if (_oriBindingSource != null && bindingSource.Current != null)
				{
					DataRow sourceRow = this.SourceDataRow;
					
					//table.Columns.Add("工時", typeof(decimal)).DefaultValue = 0;

					_dataRow["取代編號"] = sourceRow["工時資料編號"];
					_dataRow["工作單號"] = sourceRow["工作單號"];
					_dataRow["品號"] = sourceRow["品號"];
					_dataRow["工品編號"] = sourceRow["工品編號"];
					_dataRow["QCN"] = sourceRow["QCN"];
					_dataRow["待驗數量"] = sourceRow["待驗數量"];
					_dataRow["工時"] = 0;
 
					//row["工時資料編號"] = 

					//txtWorksheet.DataBindings.Add("Text", _oriBindingSource, "工作單號", false, DataSourceUpdateMode.Never);
					//txtPartNumber.DataBindings.Add("Text", _oriBindingSource, "品號", false, DataSourceUpdateMode.Never);
					//txtAmount.DataBindings.Add("Text", _oriBindingSource, "待驗數量", false, DataSourceUpdateMode.Never);
					//txtQCN.DataBindings.Add("Text", _oriBindingSource, "QCN", false, DataSourceUpdateMode.Never);
					//txtHour.DataBindings.Add("Text", _oriBindingSource, "工時", false, DataSourceUpdateMode.Never);
				}
			}
		}
		DatabaseSet.工時DataTable DataTable
		{
			get { return _dataTable; }
			set 
			{
				_dataTable = value;

				if (_dataTable != null)
				{
					_dataTable.Columns["編號"].AllowDBNull = true;

					_dataRow = _dataTable.New工時Row();
					_dataTable.Rows.Add(_dataRow);
					bindingSource.DataSource = _dataTable;

					txtWorksheet.DataBindings.Add("Text", bindingSource, "工作單號", false, DataSourceUpdateMode.Never);
					txtPartNumber.DataBindings.Add("Text", bindingSource, "品號", false, DataSourceUpdateMode.Never);
					txtAmount.DataBindings.Add("Text", bindingSource, "待驗數量", true, DataSourceUpdateMode.OnValidation, 0);
					txtQCN.DataBindings.Add("Text", bindingSource, "QCN", false, DataSourceUpdateMode.OnValidation);
					txtHour.DataBindings.Add("Text", bindingSource, "工時", true, DataSourceUpdateMode.OnValidation, 0);
				}
			}
		}
		decimal RemainHour
		{
			get { return _remainHour; }
			set 
			{ 
				_remainHour = value;
				lbRemain.Text = this.IsHoliday ? "本日為假日" : "本日尚餘" + _remainHour.ToString("0.##") + "小時";
			}
		}
		DataRow SourceDataRow
		{
			get
			{
				if (this.OriBindingSource.Current == null)
					return null;
				return (this.OriBindingSource.Current as DataRowView).Row;
			}
		}
		public DatabaseSet.工時Row DataRow
		{
			get { return _dataRow; }
			set { _dataRow = value; }
		}

		public ReinspectForm()
		{
			InitializeComponent();
		}

		public DialogResult ShowDialog(EditHourDataForm owner, BindingSource dataSource, decimal remainHour, bool isHoliday)
		{
			this.IsHoliday = isHoliday;
			this.DataTable = owner.CreateDataTable();
			this.RemainHour = remainHour;
			this.OriBindingSource = dataSource;

			return this.ShowDialog(owner);
		}

		private void ReinspectForm_Load(object sender, EventArgs e)
		{
			
		}

		private void ckbOvertime_CheckedChanged(object sender, EventArgs e)
		{
			lbRemain.Visible = !ckbOvertime.Checked;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			try
			{
				int hour = int.Parse(txtHour.Text);
				if (hour < 0)
					throw new SWLHMSException("填寫時數不得小於0");

				if (!ckbOvertime.Checked && hour > _remainHour && !this.IsHoliday)
					throw new SWLHMSException("填寫時數大於剩餘時數");

				this.DialogResult = DialogResult.OK;
			}
			catch (Exception ex)
			{
				Global.ShowError(ex);
			}

		}
	}
}
