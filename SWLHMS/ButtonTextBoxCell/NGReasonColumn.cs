using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Mong
{
	public class NGReasonColumn : DataGridViewColumn
	{
		public NGReasonColumn()
		{
			this.CellTemplate = new NGReasonCell();
		}
	}
}
