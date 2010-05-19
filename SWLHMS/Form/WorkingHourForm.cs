using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

using Mong.DatabaseSetTableAdapters;

namespace Mong
{
    public partial class WorkingHourForm : Form
    {
        int _curMonth;
        int _curYear;
        bool _needSave;
        bool _initializing;
        DateTime _curDate;

        public bool NeedSave
        {
            get { return _needSave; }
            set 
            {
                _needSave = value;
                
                btnStoreHoliday.Enabled = _needSave;
            }
        }

        DateTime[] _curMonthHolidays;

        public WorkingHourForm()
        {
            _initializing = true;

            InitializeComponent();

            NeedSave = false;

            _curMonthHolidays = new DateTime[0];

            //tbxDayWH.Text = Settings.WorkingHoursPerDay.ToString();
            tbxDayWH.DataBindings.Add("Text", Settings.WorkingHoursPerDay, "", false, DataSourceUpdateMode.Never);

            monthCalendar1_DateChanged(null, null);
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            int month = monthCalendar1.SelectionStart.Month;
            int year = monthCalendar1.SelectionStart.Year;
            
            if (_curYear != year || _curMonth != month)
            {
                if (NeedSave)
                    if (!AlertSave())
                    {
                        monthCalendar1.SelectionStart = _curDate;
                        return;
                    }

                _curDate = monthCalendar1.SelectionStart;
                _curMonth = month;
                _curYear = year;
                
                LoadHoliday();
            }


            btnAddHoliday.Text = "�W�[ (" + monthCalendar1.SelectionStart.ToString("yyyy-MM-dd") + ")";
            monthCalendar1.BoldedDates = _curMonthHolidays;
        }

        private void WorkingHourForm_Load(object sender, EventArgs e)
        {
            _initializing = false;
        }

        private void WorkingHourForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !AlertSave();
        }

        private void dgvHolidays_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!_initializing)
            {
                NeedSave = true;
                UpdateHoliday();
            }
        }

        private void dgvHolidays_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvHolidays.CurrentRow != null)
            {
                monthCalendar1.SelectionStart = (DateTime)dgvHolidays.CurrentRow.Cells["col���"].Value;
            }
        }

        private void dgvHolidays_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            NeedSave = true;
            UpdateHoliday();
        }

        private void btnStoreHoliday_Click(object sender, EventArgs e)
        {
            StroeHolidays();
            LoadHoliday();
        }

        private void btnAddHoliday_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsHolidays.DataSource != null)
                {
                    DatabaseSet.����ViewDataTable table = bsHolidays.DataSource as DatabaseSet.����ViewDataTable;
                    DatabaseSet.����ViewRow newRow = table.New����ViewRow();
                    newRow.FillRow(monthCalendar1.SelectionStart);
                    table.Rows.Add(newRow);
                    UpdateHoliday();
                    NeedSave = true;
                }
            }
            catch (ConstraintException)
            {
                MessageBox.Show(monthCalendar1.SelectionStart.ToString("yyyy/MM/dd") + " �w�s�b");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnDelHoliday_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvHolidays.SelectedRows)
            {
                (row.DataBoundItem as DataRowView).Row.Delete();
                //DatabaseSet.����ViewTable.Rows.Remove((row.DataBoundItem as DataRowView).Row);
                NeedSave = true;
            }

            UpdateHoliday();
        }

        private void tbxDayWH_Validated(object sender, EventArgs e)
        {
            Settings.WorkingHoursPerDay = decimal.Parse(tbxDayWH.Text);
            UpdateWorkingHours();
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
                MessageBox.Show("�u�ɥ������@�ӥ����");
            }
        }

        void LoadHoliday()
        {
            int month = monthCalendar1.SelectionStart.Month;
            int year = monthCalendar1.SelectionStart.Year;

            bsHolidays.DataSource = Global.Get����ViewTable(year, month);
            UpdateHoliday();
        }

        void UpdateHoliday()
        {
            int month = monthCalendar1.SelectionStart.Month;
            int year = monthCalendar1.SelectionStart.Year;

            if (bsHolidays.DataSource != null)
            {
                DatabaseSet.����ViewDataTable table = bsHolidays.DataSource as DatabaseSet.����ViewDataTable;

                List<DateTime> holidays = new List<DateTime>();
                foreach (DatabaseSet.����ViewRow row in table)
                {
                    if (row.RowState != DataRowState.Deleted)
                        holidays.Add(row.���);
                }

                _curMonthHolidays = holidays.ToArray();

                UpdateWorkingHours();
            }

            monthCalendar1.BoldedDates = _curMonthHolidays;
        }

        public int GetWorkingDays(int year, int month)
        {
            int holidays = 0;
            int days = DateTime.DaysInMonth(year, month);

            for (int i = 1; i <= days; i++)
            {
                DateTime date = new DateTime(year, month, i);
                DayOfWeek dayofWeek = date.DayOfWeek;

                if (dayofWeek == DayOfWeek.Saturday || dayofWeek == DayOfWeek.Sunday)
                {
                    holidays += 1;
                }
            }

            DatabaseSet.����DataTable table = new DatabaseSet.����DataTable();
            ����TableAdapter.Instance.FillBy���(table, year, month);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                DateTime date = (DateTime)table[i]["���"];
                if ((bool)table[i]["�W�["])
                {
                    holidays += 1;
                }
                else
                {
                    holidays -= 1;
                }
            }

            return days - holidays;
        }

        public int GetWorkingDays(int year, int month, DatabaseSet.����ViewDataTable table)
        {
            //int holidays = table.Rows.Count;
            DataRow[] rows = table.Select(null, null, DataViewRowState.CurrentRows);
            int holidays = rows.Length;
            int days = DateTime.DaysInMonth(year, month);

            return days - holidays;
        }

        void UpdateWorkingHours()
        {
            int month = monthCalendar1.SelectionStart.Month;
            int year = monthCalendar1.SelectionStart.Year;

            int workingDays = GetWorkingDays(year, month, DatabaseSet.����ViewTable);
            decimal workingHours = workingDays * Settings.WorkingHoursPerDay;
            tbxWorkingDays.Text = workingDays.ToString();
            tbxWorkingHours.Text = workingHours.ToString("0.##");
        }

        void StroeHolidays()
        {
            try
            {
                if (bsHolidays.DataSource != null)
                {
                    NeedSave = false;
                    ����ViewTableAdapter.Instance.Update(bsHolidays.DataSource as DatabaseSet.����ViewDataTable);
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// �^��false�N��ϥΪ̫��U�F����
        /// </summary>
        bool AlertSave()
        {
            if (NeedSave)
            {
                DialogResult result = MessageBox.Show("�A���ܧ�|���x�s�A�O�_�x�s���~��?", "�O�_�x�s", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                switch (result)
                {
                    case DialogResult.Yes:
                        StroeHolidays();
                        return true;
                    case DialogResult.No:
                        NeedSave = false;
                        return true;
                    case DialogResult.Cancel:
                        return false;
                }
            }
            return true;
        }

        private void tbxDayWH_Enter(object sender, EventArgs e)
        {
            tbxDayWH.Text = Settings.WorkingHoursPerDay.ToString();
        }


    }
}