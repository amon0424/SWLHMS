using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Windows.Forms;

namespace Mong
{
    public partial class LoginForm : Form
    {
        User _loginUser;

        public User LoginUser
        {
            get { return _loginUser; }
        }

        public string LoginUserName
        {
            get
            {
                if (rbAdmin.Checked)
                    return "admin";
                if (rbAdmin2.Checked)
                    return "manager";
                if (rbGanger.Checked)
                    return "ganger";
				if (rbQA.Checked)
					return "QA";
				if (rbAccount.Checked)
					return tbxUsername.Text;
                return null;
            }
        }

        public LoginForm()
        {
            InitializeComponent();

			//try
			//{
			//    System.Net.HttpWebRequest request = System.Net.WebRequest.Create("http://dorm.nsysu.edu.tw/~b953040042/case/swlhmscrash") as System.Net.HttpWebRequest;
			//    request.Timeout = 2000;
			//    System.Net.HttpWebResponse response = request.GetResponse() as System.Net.HttpWebResponse;
			//    MessageBox.Show("程式作業無效，即將關閉");
			//    Application.Exit();
			//}
			//catch (Exception){}
        }

        private void rbAccount_CheckedChanged(object sender, EventArgs e)
        {
            tbxUsername.Enabled = tbxPassword.Enabled = rbAccount.Checked;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                //如果使用帳號登入
                if (true || rbAccount.Checked)
                {
                    //string username = tbxUsername.Text.Trim();
                    string username = this.LoginUserName;

                    string password = tbxPassword.Text.Trim();

                    //檢查是否為空
                    if (username != string.Empty && password != string.Empty)
                    {
                        Regex regex = new Regex("^[A-Za-z0-9]+$");

                        //檢查是否包含非法字元
                        if (regex.IsMatch(username) && regex.IsMatch(password))
                        {
                            _loginUser = User.GetUser(username, password);
                            User.CurrentUser = _loginUser;
                            this.DialogResult = DialogResult.OK;
                        }
                        else
							throw new SWLHMSException("帳號或密碼含有非法字元，請檢查後重新輸入");
                    }
                    else
						throw new SWLHMSException("帳號及密碼不得為空");
                }
                else
                {
                    _loginUser = User.GetUser("guest", "null");
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                MessageBox.Show("登入時發生錯誤\n" + ex.Message);
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
			Process.Start("mailto: among0424@gmail.com");
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
#if DEBUG
            //rbAccount.Checked = true;
            //tbxUsername.Text = "admin";
            tbxPassword.Text = "1111";
            btnLogin.PerformClick();
#endif
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}