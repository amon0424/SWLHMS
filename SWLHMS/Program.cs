using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Security.Permissions;
using System.Security;

namespace Mong
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
			try
			{
				//MessageBox.Show("run: " + Application.StartupPath + "\\設定SWLHMS安全性原則.bat");
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new MainForm());
			}
			catch (SecurityException)
			{
				Global.ShowError("權限要求錯誤: 請先執行程式目錄下的 \"設定SWLHMS安全性原則.bat\" 檔案後再執行此程式");
			}
        }
    }
}