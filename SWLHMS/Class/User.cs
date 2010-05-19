using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;


namespace Mong
{
	[Flags]
	public enum UserType
	{
		Administrator = 1, Manager = 2, Ganger = 4, QA = 8, Guest = 16, None = 0
	}
    /// <summary>
    /// 表示一個使用者
    /// </summary>
    public class User
    {
        public class LoginFailException : Exception
        {
            public LoginFailException(string message) : base(message) { }
        }
        
        static DatabaseSetTableAdapters.使用者TableAdapter _adapter;
        static User _currentUser;
		static Dictionary<int, UserType> _userTypeMapping;

		UserType _userType;

		

        public static User CurrentUser
        {
            get { return User._currentUser; }
            set { User._currentUser = value; }
        }
		public UserType UserType
		{
			get { return _userType; }
			set { _userType = value; }
		}

        DatabaseSet.使用者Row _dataRow;

        public DatabaseSet.使用者Row DataRow
        {
            get { return _dataRow; }
            set 
			{
				_dataRow = value;
				this.UserType = _userTypeMapping[this.Authority];
			}
        }
        public string 帳號
        {
            get { return _dataRow.帳號; }
        }
        public string 密碼
        {
            get { return _dataRow.密碼; }
        }
        public int Authority
        {
            get { return -_dataRow.權限; }
            //set { _dataRow.權限 = value; }
        }
        public bool IsAdministrator
        {
			get { return this.UserType == UserType.Administrator; }
        }
        public bool IsManager
        {
			get { return this.UserType == UserType.Manager; }
        }
        public bool IsGanger
        {
			get { return this.UserType == UserType.Ganger; }
        }
		public bool IsQA
		{
			get { return this.UserType == UserType.QA; }
		}
		public bool IsGuest
		{
			get { return this.UserType == UserType.Guest; }
		}
		public static int Administrator
		{
			get { return 0; }
		}
        public static int Manager
        {
			get { return -1; }
        }
		public static int Ganger
		{
			get { return -2; }
		}
		public static int QA
		{
			get { return -3; }
		}
		public static int Guest
		{
			get { return -4; }
		}

        static User()
        {
            _adapter = new Mong.DatabaseSetTableAdapters.使用者TableAdapter();
			_userTypeMapping = new Dictionary<int, UserType>();
			_userTypeMapping.Add(User.Administrator, UserType.Administrator);
			_userTypeMapping.Add(User.Manager, UserType.Manager);
			_userTypeMapping.Add(User.Ganger, UserType.Ganger);
			_userTypeMapping.Add(User.QA, UserType.QA);
			_userTypeMapping.Add(User.Guest, UserType.Guest);
        }

        public static User GetUser(string username, string password)
        {
            DatabaseSet.使用者DataTable datatable = _adapter.GetByUsername_Password(username, password);
            if (datatable.Rows.Count > 0)
            {
                User user = new User();
                user.DataRow = datatable.Rows[0] as DatabaseSet.使用者Row;
                return user;
            }
            else
            {
				throw new SWLHMSException("帳號或密碼錯誤，請檢查後重新輸入");
            }
        }

        private User()
        {

        }

        public void Save()
        {
            _adapter.Update(_dataRow);
        }

        public bool ChangePassword(string oriPassword, string newPassword)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[A-Za-z0-9]+$");

            if ( oriPassword == this.密碼 && regex.IsMatch(newPassword))
            {
                _dataRow.密碼 = newPassword;
                this.Save();
                return true;
            }
            else
                return false;
        }

        public static bool ChangePassword(string username, string oriPassword, string newPassword)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[A-Za-z0-9]+$");

            User user = User.GetUser(username, oriPassword);

            if (oriPassword == user.密碼 && regex.IsMatch(newPassword))
            {
                user.DataRow.密碼 = newPassword;
                user.Save();
                return true;
            }
            else
                return false;
        }
    }
}
