using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Mong
{
	public partial class ButtonTextboxEditingControl : UserControl, IDataGridViewEditingControl
	{
		public event EventHandler ButtonClick;

		DataGridView m_dataGridView = null;
		int m_rowIndex = 0;
		bool m_valueChanged = false;
		string m_prevText = null;

		public string InputText
		{
			get
			{
				return textBox.Text;
			}
			set
			{
				textBox.Text = value;
			}
		}

		public ButtonTextboxEditingControl()
		{
			InitializeComponent();
			this.textBox.LostFocus += new EventHandler(textBox_LostFocus);
		}
		void textBox_LostFocus(object sender, EventArgs e)
		{
			NotifyChange();
		}

		private void browseButton_Click(object sender, EventArgs e)
		{
			try
			{
				if (ButtonClick != null)
					ButtonClick(sender, e);
			}
			catch (Exception ex)
			{
				Global.ShowError(ex.Message);
			}
		}

		protected void NotifyChange()
		{
			if (this.textBox.Text != m_prevText)
			{
				m_valueChanged = true;
				m_dataGridView.NotifyCurrentCellDirty(true);
			}
		}

		#region IDataGridViewEditingControl Members

		public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
		{
			// Do nothing
		}

		public Cursor EditingControlCursor
		{
			get 
			{
				return Cursors.IBeam;
			}
		}


		public Cursor EditingPanelCursor
		{
			get
			{
				return Cursors.IBeam;
			}
		}

		public DataGridView EditingControlDataGridView
		{
			get
			{
				return m_dataGridView;
			}
			set
			{
				m_dataGridView = value;
				this.Height = m_dataGridView.RowTemplate.Height;
			}
		}

		public object EditingControlFormattedValue
		{
			get
			{
				return this.textBox.Text;
			}
			set 
			{
				this.textBox.Text = value.ToString();
			}
		}

		public int EditingControlRowIndex
		{
			get
			{
				return m_rowIndex;
			}
			set
			{
				m_rowIndex = value;
			}
		}

		public bool EditingControlValueChanged
		{
			get
			{
				return m_valueChanged;
			}
			set
			{
				m_valueChanged = value;
			}
		}

		public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
		{
			switch (keyData)
			{
				case Keys.Tab:
					return true;
				case Keys.Home:
				case Keys.End:
				case Keys.Left:
					if (this.textBox.SelectionLength == this.textBox.Text.Length)
						return false;
					else
						return true;
				case Keys.Right:
					return true;
				case Keys.Delete:
					this.textBox.Text = "";
					return true;
				case Keys.Enter:
					NotifyChange();
					return false;
				default:
					return false;
			}
		}

		public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
		{
			return this.textBox.Text;
		}

		public void PrepareEditingControlForEdit(bool selectAll)
		{
			if (this.m_dataGridView.CurrentCell.Value == null)
				this.textBox.Text = "";
			else
				this.textBox.Text = this.m_dataGridView.CurrentCell.Value.ToString();
			if (selectAll)
				this.textBox.SelectAll();
			m_prevText = this.textBox.Text;
		}

		public bool RepositionEditingControlOnValueChange
		{
			get 
			{
				return false;
			}
		}

		#endregion
	}
}
