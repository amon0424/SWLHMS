using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mong
{
	public partial class NGReasonForm : Form
	{
		public string[] _reasonsType = { "尺寸", "外觀", "功能", "自訂" };

		string SelectedType
		{
			get 
			{
				if (cbbType.SelectedIndex == -1)
					return null;
				return cbbType.SelectedItem.ToString(); 
			}
		}

		public string NGReason
		{
			get
			{
				string type = this.SelectedType;
				if (type == null || cbbType.SelectedIndex == 3)
					return txtContent.Text;
				return type + "NG-(" + txtContent.Text + ")";
			}
			set
			{
				int index = 3;
				if (value != null && value.Length > 2)
				{
					index = Array.IndexOf<string>(_reasonsType, value.Substring(0, 2));
					if (index == -1)
						index = 3;
					else
					{
						int left = value.IndexOf('(');
						int right = value.LastIndexOf(')');
						if (left != -1 && right >= left)
						{
							cbbType.SelectedIndex = index;
							txtContent.Text = value.Substring(left+1, right - left -1);
						}
						else
							index = 3;
					}
				}
				
				if(index == 3)
				{
					cbbType.SelectedIndex = index;
					txtContent.Text = value;
				}
			}
		}

		public NGReasonForm()
		{
			InitializeComponent();
			cbbType.DataSource = _reasonsType;
			lbPreview.Text = string.Empty;
		}

		private void NGReasonForm_Load(object sender, EventArgs e)
		{
			
		}

		private void cbbType_SelectedIndexChanged(object sender, EventArgs e)
		{
			btnOK.Enabled = this.SelectedType != null;
			lbPreview.Text = this.NGReason;
		}

		private void txtContent_TextChanged(object sender, EventArgs e)
		{
			lbPreview.Text = this.NGReason;
		}
	}
}
