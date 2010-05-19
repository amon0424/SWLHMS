using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mong
{
    public partial class DateForm : Form
    {
        public event EventHandler ExportClick;

        string _dateTypeName;
       
        public DateTime StartDate
        {
            get
            {
                if (AllTime)
                    return DateTime.MinValue;
                return dtpFrom.Value;
            }
            set
            {
               
                dtpFrom.Value = value;
            }
        }
        public DateTime EndDate
        {
            get
            {
                if (AllTime)
                    return DateTime.MaxValue;
                return dtpTo.Value;
            }
            set
            {
                dtpTo.Value = value;
            }
        }
        public bool AllowAllTime
        {
            get
            {
                return ckbAllTime.Visible;
            }
            set
            {
                ckbAllTime.Visible = value;
            }
        }
        public bool AllTime
        {
            get
            {
                return ckbAllTime.Checked;
            }
        }
        public string DateTypeName
        {
            get { return _dateTypeName; }
            set 
            {
                _dateTypeName = value;
                groupBox1.Text = _dateTypeName;
            }
        }
        public DateForm()
        {
            InitializeComponent();
            DateTime now = DateTime.Now;

            StartDate = new DateTime(now.Year, now.Month, 1);
            EndDate = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month));
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportClick(this, e);
        }

        private void ckbAllTime_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = !ckbAllTime.Checked;
        }
    }
}