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
    /// ��ܤ@�ӨϥΪ�
    /// </summary>
    public class User
    {
        public class LoginFailException : Exception
        {
            public LoginFailException(string message) : base(message) { }
        }
        
        static DatabaseSetTableAdapters.�ϥΪ�TableAdapter _adapter;
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

        DatabaseSet.�ϥΪ�Row _dataRow;

        public DatabaseSet.�ϥΪ�Row DataRow
        {
            get { return _dataRow; }
            set 
			{
				_dataRow = value;
				this.UserType = _userTypeMapping[this.Authority];
			}
        }
        public string �b��
        {
            get { return _dataRow.�b��; }
        }
        public string �K�X
        {
            get { return _dataRow.�K�X; }
        }
        public int Authority
        {
            get { return -_dataRow.�v��; }
            //set { _dataRow.�v�� = value; }
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
            _adapter = new Mong.DatabaseSetTableAdapters.�ϥΪ�TableAdapter();
			_userTypeMapping = new Dictionary<int, UserType>();
			_userTypeMapping.Add(User.Administrator, UserType.Administrator);
			_userTypeMapping.Add(User.Manager, UserType.Manager);
			_userTypeMapping.Add(User.Ganger, UserType.Ganger);
			_userTypeMapping.Add(User.QA, UserType.QA);
			_userTypeMapping.Add(User.Guest, UserType.Guest);
        }

        public static User GetUser(string username, string password)
        {
            DatabaseSet.�ϥΪ�DataTable datatable = _adapter.GetByUsername_Password(username, password);
            if (datatable.Rows.Count > 0)
            {
                User user = new User();
                user.DataRow = datatable.Rows[0] as DatabaseSet.�ϥΪ�Row;
                return user;
            }
            else
            {
				throw new SWLHMSException("�b���αK�X���~�A���ˬd�᭫�s��J");
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

            if ( oriPassword == this.�K�X && regex.IsMatch(newPassword))
            {
                _dataRow.�K�X = newPassword;
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

            if (oriPassword == user.�K�X && regex.IsMatch(newPassword))
            {
                user.DataRow.�K�X = newPassword;
                user.Save();
                return true;
            }
            else
                return false;
        }
    }
}
