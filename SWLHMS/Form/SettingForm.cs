using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mong
{
    public partial class SettingForm : Form
    {
        bool _passwordChanged;
        bool _gangerPasswordChanged;
        bool _admin2PasswordChanged;
        bool _dateChanged;
        bool _hourChanged;
		bool _hourPayChanged;
        bool _laborwageDirChanged;
        User _user;

        public SettingForm(User user)
        {
            InitializeComponent();
            _user = user;

            dtpTip.DataBindings.Add("Value", Settings.UnfilledDate, "", true, DataSourceUpdateMode.Never);
            tbxDayWH.DataBindings.Add("Text", Settings.WorkingHoursPerDay, "", true, DataSourceUpdateMode.Never);
			txtHourlyPay.DataBindings.Add("Text", Settings.HourlyPay, "", true, DataSourceUpdateMode.Never);

            if (Settings.LaborWageDatabaseFile != string.Empty)
                tbxLaborWageDir.Text = System.IO.Path.GetDirectoryName(Settings.LaborWageDatabaseFile);

			Type t = folderBrowserDialog1.GetType();
			System.Reflection.FieldInfo fi = t.GetField("rootFolder", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
			fi.SetValue(folderBrowserDialog1, (System.Environment.SpecialFolder)0x003d);
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void tbxDayWH_Validated(object sender, EventArgs e)
        {
            _hourChanged = true;
        }

        private void dtpTip_ValueChanged(object sender, EventArgs e)
        {
            _dateChanged = true;
        }

		private void txtHourlyPay_TextChanged(object sender, EventArgs e)
		{
			_hourPayChanged = true;
		}


        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
				//if (!((tbxOldPassword.Text == string.Empty && tbxNewPassword.Text == string.Empty) ||
				//     (tbxOldPassword.Text != string.Empty && tbxNewPassword.Text != string.Empty)))
				//    throw new Exception("若要更改密碼請輸入正確的目前密碼與新密碼");

                if (_hourChanged)
                {
                    decimal hour = decimal.Parse(tbxDayWH.Text);
                    Settings.WorkingHoursPerDay = hour;
                }

				if (_hourPayChanged)
				{
					int hourlyPay = int.Parse(txtHourlyPay.Text);
					Settings.HourlyPay = hourlyPay;
				}

                if (_dateChanged)
                    Settings.UnfilledDate = dtpTip.Value;

				//if (_passwordChanged)
				//{
				//    if (_user.ChangePassword(tbxOldPassword.Text, tbxNewPassword.Text))
				//        MessageBox.Show("系統管理者密碼已成功變更");
				//    else
				//        MessageBox.Show("系統管理者密碼更改失敗，請確定目前密碼輸入正確及密碼是否含有特殊字元");
				//}

				//if (_admin2PasswordChanged)
				//{
				//    if (User.ChangePassword("manager", txtGangerOldPwd.Text, txtGangerNewPwd.Text))
				//        MessageBox.Show("一般管理者密碼已成功變更");
				//    else
				//        MessageBox.Show("一般管理者密碼更改失敗，請確定目前密碼輸入正確及密碼是否含有特殊字元");
				//}

				//if (_gangerPasswordChanged)
				//{
				//    if (User.ChangePassword("ganger", txtGangerOldPwd.Text, txtGangerNewPwd.Text))
				//        MessageBox.Show("領班密碼已成功變更");
				//    else
				//        MessageBox.Show("領班密碼更改失敗，請確定目前密碼輸入正確及密碼是否含有特殊字元");
				//}

                

                if (_laborwageDirChanged)
                {
                    if (System.IO.Directory.Exists(tbxLaborWageDir.Text))
                    {
                        string dbFile = tbxLaborWageDir.Text + @"\db.mdb";
                        if (!System.IO.File.Exists(dbFile))
                            MessageBox.Show("找不到資料庫檔案 " + dbFile + "，請檢查是否為正確的LaborWage程式目錄");

                        Settings.LaborWageDatabaseFile = dbFile;
                    }
                    else
                        MessageBox.Show("找不到路徑 " + tbxLaborWageDir.Text + "，請檢查是否為正確的LaborWage程式目錄");
                }

                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbxDayWH_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (decimal.Parse(tbxDayWH.Text) <= 0)
					throw new SWLHMSException();
            }
            catch (Exception)
            {
                e.Cancel = true;
                MessageBox.Show("工時必須為一個正整數");
            }
        }

		private void txtHourlyPay_Validating(object sender, CancelEventArgs e)
		{
			try
			{
				if (int.Parse(txtHourlyPay.Text) <= 0)
					throw new SWLHMSException();
			}
			catch (Exception)
			{
				e.Cancel = true;
				MessageBox.Show("時薪必須為一個正整數");
			}
		}

		//private void tbxPassword_Validated(object sender, EventArgs e)
		//{
		//    tbxOldPassword.Text = tbxOldPassword.Text.Trim();

		//}

		//private void tbxNewPassword_Validated(object sender, EventArgs e)
		//{
		//    tbxNewPassword.Text = tbxNewPassword.Text.Trim();
            
		//    _passwordChanged = tbxNewPassword.Text != string.Empty;
		//}

		//private void txtGangerOldPwd_Validated(object sender, EventArgs e)
		//{
		//    txtGangerOldPwd.Text = txtGangerOldPwd.Text.Trim();
		//}

		//private void txtGangerNewPwd_Validated(object sender, EventArgs e)
		//{
		//    txtGangerNewPwd.Text = txtGangerNewPwd.Text.Trim();

		//    _gangerPasswordChanged = txtGangerNewPwd.Text != string.Empty;
		//}

		//private void tbxAdmin2OldPwd_Validated(object sender, EventArgs e)
		//{
		//    tbxAdmin2OldPwd.Text = tbxAdmin2OldPwd.Text.Trim();

		//    _admin2PasswordChanged = txtGangerNewPwd.Text != string.Empty;
		//}

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tbxLaborWageDir.Text = folderBrowserDialog1.SelectedPath;
                _laborwageDirChanged = true;
            }
        }

		

		



       

       
    }
}