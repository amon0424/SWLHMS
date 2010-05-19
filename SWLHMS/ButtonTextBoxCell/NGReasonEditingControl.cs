using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mong
{
	public partial class NGReasonEditingControl : Mong.ButtonTextboxEditingControl
	{
		public NGReasonEditingControl()
		{
			InitializeComponent();
			this.ButtonClick += new EventHandler(editingControl_ButtonClick);
		}

		void editingControl_ButtonClick(object sender, EventArgs e)
		{
			NGReasonForm form = new NGReasonForm();
			string oriReason = this.InputText;
			form.NGReason = oriReason;
			if (form.ShowDialog() == DialogResult.OK)
			{
				string newReason = form.NGReason;
				this.InputText = newReason;
				//cell.Value = cell.Value + "\n" + newReason;
				this.NotifyChange();
			}
		}
	}
}
