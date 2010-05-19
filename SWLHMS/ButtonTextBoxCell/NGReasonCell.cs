using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Mong
{
	public class NGReasonCell : DataGridViewTextBoxCell
	{
		static NGReasonEditingControl editingControl = null;

		public NGReasonCell()
		{
			editingControl = new NGReasonEditingControl();
		}

		public override Type EditType
		{
			get 
			{
				return typeof(NGReasonEditingControl);
			}
		}

		protected override Size GetPreferredSize(Graphics graphics, DataGridViewCellStyle cellStyle, int rowIndex, Size constraintSize)
		{
			try
			{
				if (this.IsInEditMode)
					return editingControl.Size;
				else
					return base.GetPreferredSize(graphics, cellStyle, rowIndex, constraintSize);
			}
			catch
			{
				return base.GetPreferredSize(graphics, cellStyle, rowIndex, constraintSize);
			}
		}


	}// class
}// namespace
