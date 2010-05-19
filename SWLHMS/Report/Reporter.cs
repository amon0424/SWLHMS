using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

using Microsoft.Office.Interop.Excel;

namespace Mong.Report
{
    class Reporter
    {
        protected static object Missing = System.Reflection.Missing.Value;

		Application _application;
        Workbook _workbook;
        int _sheetsInNewWorkbook = 1;
        string _name;
		UserType _allowUser = UserType.Administrator;
		bool _useIndependentApp = false;
		bool _hideApp = false;

		public bool UseIndependentApp
		{
			get { return _useIndependentApp; }
			set { _useIndependentApp = value; }
		}
		public bool HideApp
		{
			get { return _hideApp; }
			set { _hideApp = value; }
		}

        public Application Application
        {
            get 
			{
				if (_useIndependentApp)
				{
					if (_application == null)
						_application = new Application();
					
					try
					{
						object o = _application.WindowState;
					}
					catch (System.Runtime.InteropServices.COMException)
					{
						_application = new Application();
					}

					return _application;
				}
				else
					return ExcelApplication.Instance; 
			}
        }
        public string Name
        {
            get
            {
                return _name;
            }
            protected set
            {
                _name = value;
            }
        }
		public UserType AllowUser
		{
			get { return _allowUser; }
			protected set { _allowUser = value; }
		}

        protected Workbook Workbook
        {
            get
            {
                return _workbook;
            }
        }

        protected int SheetsInNewWorkbook
        {
            get { return _sheetsInNewWorkbook; }
            set { _sheetsInNewWorkbook = value; }
        }


        public void Export()
        {
            try
            {
				_workbook = CreateWorkbook();
				this.Application.Visible = !_hideApp;

                BeforeExport();
                WriteHeader();
                WriteColumnHeader();
                WriteContent();
                AfterContentWritten();
            }
            catch (Exception ex)
            {
				try
				{
					Application.DisplayAlerts = false;
					if (_workbook != null)
						_workbook.Close(false, Missing, Missing);
					Application.DisplayAlerts = true;
				}
				catch (Exception) { }
                Global.ShowError(ex);
                //throw ex;
            }

			if (this.UseIndependentApp)
			{
				try
				{
					Application.DisplayAlerts = false;
					Application.Quit();
				}
				catch (Exception) { }
			}
        }

        protected virtual void BeforeExport()
        {
        }

        protected virtual void WriteHeader()
        {
        }

        protected virtual void WriteColumnHeader()
        {
        }

        protected virtual void WriteContent()
        {
            
        }

        protected virtual void OnRowWritten()
        {
        }

        protected virtual void AfterContentWritten()
        {
        }

		public bool Allow(UserType userType)
		{
			return (userType & this.AllowUser) != UserType.None;
				
		}

        Workbook CreateWorkbook()
        {
            int orinum = this.Application.SheetsInNewWorkbook;
            this.Application.SheetsInNewWorkbook = SheetsInNewWorkbook;
            return this.Application.Workbooks.Add(Missing);
            
        }
    }
}
