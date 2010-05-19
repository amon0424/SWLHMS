using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mong
{
	public partial class NGTipForm : Form
	{
		DataTable _ngTable;
		decimal _remainHour;
		bool _isHoliday;
		EditHourDataForm _editForm;
		ReinspectForm _reForm;

		DataTable NGTable
		{
			get { return _ngTable; }
			set 
			{ 
				_ngTable = value;
				bindingSource.DataSource = _ngTable;
				btnOK.Enabled = _ngTable != null && _ngTable.Rows.Count > 0;
				dgv.AutoResizeColumns();
			}
		}
		DataRow SelectedRow
		{
			get
			{
				if(dgv.CurrentCell == null)
					return null;

				return (dgv.CurrentCell.OwningRow.DataBoundItem as DataRowView).Row;
			}
		}
		public string SelectedHourDataID
		{
			get
			{
				if(this.SelectedRow == null)
					return null;
				return this.SelectedRow["工時資料編號"].ToString();
			}
		}
		public DatabaseSet.工時Row DataRow
		{
			get
			{
				return _reForm.DataRow;
			}
		}

		public NGTipForm()
		{
			InitializeComponent();
		}

		public DialogResult ShowDialog(EditHourDataForm owner, DataTable ngTable, decimal remainHour, bool isHoliday)
		{
			_isHoliday = isHoliday;
			_remainHour = remainHour;
			this.NGTable = ngTable;
			_editForm = (EditHourDataForm)owner;
			return this.ShowDialog(owner);
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			_reForm = new ReinspectForm();

			this.Hide();
			if (_reForm.ShowDialog(_editForm, bindingSource, _remainHour, _isHoliday) == DialogResult.OK)
				this.DialogResult = DialogResult.OK;
			else
				this.Show();
		}
	}
}
