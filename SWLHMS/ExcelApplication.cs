using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Office.Interop.Excel;

namespace Mong
{
    static class ExcelApplication
    {
        static Application _application;

        public static Application Instance
        {
            get
            {
                if (_application == null)
                {
                    _application = new Application();
                }

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
        }

        public static void Close()
        {
            try
            {
                if (!_application.Visible)
                {
                    _application.Quit();
                }
            }
            catch (Exception) { }
        }
    }
}
