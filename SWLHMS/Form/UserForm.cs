using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Mong.DatabaseSetTableAdapters;

namespace Mong
{
	public enum AuthorityType
	{
		系統管理員 = 0, 一般管理員 = 1, 領班 = 2, QA = 3
	}

    public partial class UserForm : Form
    {
		static string[] _authorityType = { "系統管理員", "一般管理員", "領班", "品保" };

		static List<string> _reservedUsername = new List<string>(new string[]{ "admin", "manager", "ganger", "qa", "guest" });

		DataGridViewCellStyle _specialStyle;
		EditStateType _editState;
		EditStateType EditState
		{
			get { return _editState; }
			set
			{
				_editState = value;
				UpdateUI();
			}
		}

		DatabaseSet.使用者DataTable Table
		{
			get{ return bindingSource.DataSource as DatabaseSet.使用者DataTable; }
			set
			{ 
				bindingSource.DataSource = value;
				if (value != null)
				{
					txtUsername.DataBindings.Add("Text", bindingSource, "帳號", true, DataSourceUpdateMode.Never);
					txtPassword.DataBindings.Add("Text", bindingSource, "密碼", true, DataSourceUpdateMode.Never);
					cbxAuthority.DataBindings.Add("SelectedIndex", bindingSource, "權限", true, DataSourceUpdateMode.Never);
				}
			}
		}
		DatabaseSet.使用者Row SelectedRow
		{
			get
			{
				if (bindingSource.Current == null)
					return null;
				return (bindingSource.Current as DataRowView).Row as DatabaseSet.使用者Row;
			}
		}
		int SelectedAuthority
		{
			get
			{
				//if (cbxAuthority.SelectedIndex == -1)
				//    return -1;
				//return (int)cbxAuthority.SelectedValue;

				return cbxAuthority.SelectedIndex;
			}
		}

        public UserForm()
        {
            InitializeComponent();

			_specialStyle = new DataGridViewCellStyle(dgv.DefaultCellStyle);
			_specialStyle.BackColor = Color.DarkGray;
			_specialStyle.ForeColor = Color.White;
			_specialStyle.SelectionBackColor = Color.DimGray;

			cbxAuthority.DataSource = _authorityType;
			

			this.EditState = EditStateType.None;
        }

		void LoadUserTable()
		{
			DatabaseSet.使用者DataTable table = 使用者TableAdapter.Instance.GetDataExcludeDefault();
			table.Columns.Add(new DataColumn("身分", typeof(string)));
			this.Table = table;

			UpdateIdentities();
		}

		void UpdateIdentities()
		{
			foreach (DataRow row in this.Table.Rows)
			{
				row["身分"] = _authorityType[(int)row["權限"]];
			}
		}

		private void UserForm_Load(object sender, EventArgs e)
		{
			LoadUserTable();
		}

		void UpdateUI()
		{
			bool editing = (this.EditState == EditStateType.Edit || this.EditState == EditStateType.New);
			txtUsername.ReadOnly = txtPassword.ReadOnly = !editing;
			cbxAuthority.Enabled = editing;
			dgv.Enabled = !editing;

			btnStore.Visible = btnCancel.Visible = editing;
			//btnDel.Visible = btnEdit.Visible = !editing;
			btnEdit.Visible = !editing;

			if (this.EditState == EditStateType.Edit && this.SelectedRow != null)
			{
				txtUsername.ReadOnly = _reservedUsername.Contains(this.SelectedRow.帳號.ToLower());
				cbxAuthority.Enabled = !txtUsername.ReadOnly;
			}

			if (this.EditState == EditStateType.New)
			{
				txtUsername.Clear();
				txtPassword.Clear();
				cbxAuthority.SelectedIndex = -1;
			}
			else
			{
				if (this.Table != null)
				{
					txtPassword.DataBindings[0].ReadValue();
					txtUsername.DataBindings[0].ReadValue();
					cbxAuthority.DataBindings[0].ReadValue();
				}
			}
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			this.EditState = EditStateType.New;
		}

		private void btnStore_Click(object sender, EventArgs e)
		{
			try
			{
				string username = txtUsername.Text = txtUsername.Text.Trim();
				string password = txtPassword.Text = txtPassword.Text.Trim();
				int authority = this.SelectedAuthority;
				try
				{
					if (authority == -1)
						throw new SWLHMSException("請選擇使用者身分");


					if (this.EditState == EditStateType.New && _reservedUsername.Contains(username.ToLower()))
						throw new SWLHMSException("登入名稱不可為關鍵字 \"admin\", \"manager\", \"ganger\", \"qa\", \"guest\"");

					if (this.EditState == EditStateType.Edit)
					{
						if (bindingSource.Current != null)
						{
							txtPassword.DataBindings[0].WriteValue();
							txtUsername.DataBindings[0].WriteValue();
							cbxAuthority.DataBindings[0].WriteValue();
							bindingSource.EndEdit();
							DatabaseSet.使用者Row row = this.SelectedRow;
							//row.帳號 = username;
							//row.密碼 = password;
							//row.權限 = authority;

							int a = 使用者TableAdapter.Instance.Update(row);
						}
					}
					else if (this.EditState == EditStateType.New)
					{
						DatabaseSet.使用者Row newRow = this.Table.New使用者Row();
						newRow.帳號 = username;
						newRow.密碼 = password;
						newRow.權限 = authority;

						this.Table.Rows.Add(newRow);

						使用者TableAdapter.Instance.Update(newRow);
					}

					this.EditState = EditStateType.None;
					this.UpdateIdentities();
				}
				catch (ConstraintException)
				{
					MessageBox.Show("已存在登入名稱 \"" + username + "\"，請指定其他名稱");

				}
			}
			catch (Exception ex)
			{
				Global.ShowError(ex);
			}
			finally
			{
				if (this.EditState == EditStateType.Edit)
				{
					txtPassword.DataBindings[0].ReadValue();
					txtUsername.DataBindings[0].ReadValue();
					cbxAuthority.DataBindings[0].ReadValue();
				}
			}
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			this.EditState = EditStateType.Edit;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.EditState = EditStateType.None;
		}

		private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (dgv.Columns[e.ColumnIndex].Name == "col帳號")
			{
				if (_reservedUsername.Contains(((string)e.Value).ToLower()))
					dgv.Rows[e.RowIndex].DefaultCellStyle = _specialStyle;
			}
		}

		private void bindingSource_CurrentChanged(object sender, EventArgs e)
		{
			DatabaseSet.使用者Row row = this.SelectedRow;
			btnEdit.Enabled = (row != null);
			if (row != null)
				btnDel.Enabled = !_reservedUsername.Contains(row.帳號.ToLower());

		}

		private void btnDel_Click(object sender, EventArgs e)
		{
			try
			{
				DatabaseSet.使用者Row row = this.SelectedRow;
				if (row != null)
				{
					if (MessageBox.Show("確定刪除使用者 " +  row.帳號, "刪除提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
					{
						row.Delete();
						使用者TableAdapter.Instance.Update(row);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
    }
}