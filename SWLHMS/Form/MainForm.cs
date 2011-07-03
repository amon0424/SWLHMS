using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using System.Security.Permissions;
using System.Security;

using Mong.Report;

namespace Mong
{
	[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public partial class MainForm : Form
    {
        User _user;
        ProductForm _productForm;
        LineForm _lineForm;
        LaborForm _laborForm;
        NonProduceForm _npForm;
		QualityItemForm _qiForm;
		QAForm _qaForm;
        WorkingHourForm _whFrom;
        WorksheetForm _worksheetForm;
        HourDataForm _hourDataForm;
		UserForm _userForm;
		InspectForm _inspectForm;
		InspectListForm _inspectListForm;
		InspectedDeleteForm _inspectDelForm;
        List<Reporter> _reporterList; 

        public ProductForm ProductForm
        {
            get
            {
                if (_productForm == null || _productForm.IsDisposed)
                {
                    _productForm = new ProductForm();
                    _productForm.MdiParent = this;
                }

                return _productForm;
            }
            set { _productForm = value; }
        }
        public LineForm LineForm
        {
            get
            {
                if (_lineForm == null || _lineForm.IsDisposed)
                {
                    _lineForm = new LineForm();
                    _lineForm.MdiParent = this;
                }

                return _lineForm;
            }
            set { _lineForm = value; }
        }
        public LaborForm LaborForm
        {
            get
            {
                if (_laborForm == null || _laborForm.IsDisposed)
                {
                    _laborForm = new LaborForm();
                    _laborForm.MdiParent = this;
                }

                return _laborForm;
            }
            set { _laborForm = value; }
        }
        public NonProduceForm NPForm
        {
            get
            {
                if (_npForm == null || _npForm.IsDisposed)
                {
                    _npForm = new NonProduceForm();
                    _npForm.MdiParent = this;
                }
                return _npForm;
            }
            set { _npForm = value; }
        }
		public QualityItemForm QIForm
		{
			get
			{
				if (_qiForm == null || _qiForm.IsDisposed)
				{
					_qiForm = new QualityItemForm();
					_qiForm.MdiParent = this;
				}
				return _qiForm;
			}
			set { _qiForm = value; }
		}
		public QAForm QAForm
		{
			get
			{
				if (_qaForm == null || _qaForm.IsDisposed)
				{
					_qaForm = new QAForm();
					_qaForm.MdiParent = this;
				}
				return _qaForm;
			}
			set { _qaForm = value; }
		}
        public WorkingHourForm WHFrom
        {
            get
            {
                if (_whFrom == null || _whFrom.IsDisposed)
                {
                    _whFrom = new WorkingHourForm();
                    _whFrom.MdiParent = this;
                } 
                return _whFrom;
            }
            set { _whFrom = value; }
        }
        public WorksheetForm WorksheetForm
        {
            get 
            {
                if (_worksheetForm == null || _worksheetForm.IsDisposed)
                {
                    _worksheetForm = new WorksheetForm();
                    _worksheetForm.MdiParent = this;
                }

                if (_user.Authority > 3)
                    _worksheetForm.OnlySearch = true;

                return _worksheetForm;
            }
            set { _worksheetForm = value; }
        }
        public HourDataForm HourDataForm
        {
            get
            {
                if (_hourDataForm == null || _hourDataForm.IsDisposed)
                {
                    _hourDataForm = new HourDataForm();
                    _hourDataForm.MdiParent = this;
                } 
                
                return _hourDataForm;
            }
            set { _hourDataForm = value; }
        }
		public InspectForm InspectForm
		{
			get
			{
				if (_inspectForm == null || _inspectForm.IsDisposed)
				{
					_inspectForm = new InspectForm();
					_inspectForm.MdiParent = this;
				}

				return _inspectForm;
			}
			set { _inspectForm = value; }
		}
		public InspectListForm InspectListForm
		{
			get
			{
				if (_inspectListForm == null || _inspectListForm.IsDisposed)
				{
					_inspectListForm = new InspectListForm();
					_inspectListForm.MdiParent = this;
				}

				return _inspectListForm;
			}
			set { _inspectListForm = value; }
		}
		public InspectedDeleteForm InspectDeleteForm
		{
			get
			{
				if (_inspectDelForm == null || _inspectDelForm.IsDisposed)
				{
					_inspectDelForm = new InspectedDeleteForm();
					_inspectDelForm.MdiParent = this;
				}

				return _inspectDelForm;
			}
			set { _inspectDelForm = value; }
		}
		public UserForm UserForm
        {
            get
            {
                if (_userForm == null || _userForm.IsDisposed)
                {
					_userForm = new UserForm();
                    _userForm.MdiParent = this;
                } 
                
                return _userForm;
            }
            set { _userForm = value; }
        }
        List<Reporter> ReporterList
        {
            get
            {
                //if (_reporterList == null)
                {
                    _reporterList = new List<Reporter>();

                    if (_user.IsAdministrator)
                    {
                        _reporterList.Add(new FinishedWorksheetReporter());
                        _reporterList.Add(new UninishedWorksheetReporter());
                    }

					if (_user.Authority >= User.Ganger)
					{
						_reporterList.Add(new FinishedWorksheetReporterLine());
						_reporterList.Add(new UninishedWorksheetReporterLine());
					}

                    if (_user.Authority >= User.Manager)
                    {
                        _reporterList.Add(new LineLaborHourReporter());
                        _reporterList.Add(new LaborHourDetailReporter());
                        _reporterList.Add(new UnitPriceReporter());
                        _reporterList.Add(new MaterialsOrder());
                        _reporterList.Add(new WorksheetDetail());
                    }

					if (_user.Authority >= User.QA)
					{
						_reporterList.Add(new InspectListReport());
					}
                }

                return _reporterList;
            }
        }

		
        public MainForm()
        {
            InitializeComponent();
            this.Text = this.Text + " v" + Application.ProductVersion;

			//System.Data.OleDb.OleDbConnectionStringBuilder csBuilder = new System.Data.OleDb.OleDbConnectionStringBuilder();
			//csBuilder.ConnectionString = Properties.Settings.Default.dbConnectionString;
			//csBuilder.Add("Jet OLEDB:Database Password", "1111");

			//Properties.Settings.ChangeConnectionString(csBuilder.ConnectionString);

			
        }

        void UpdateReportMenu()
        {
            this.tsmiReport.DropDownItems.Clear();
            foreach (Reporter rpt in this.ReporterList)
            {
				if (rpt.Allow(_user.UserType))
				{
					ToolStripMenuItem item = new ToolStripMenuItem();
					item.Text = rpt.Name;
					item.Tag = rpt;
					item.Click += new EventHandler(ReportItem_Click);
					this.tsmiReport.DropDownItems.Add(item);
				}
            }
        }

        void ReportItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            Reporter rpt = (Reporter)item.Tag;
            if (rpt is IFormSettable)
                ((IFormSettable)rpt).OpenForm();
            else
                rpt.Export();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            OpenLoginForm();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ExcelApplication.Close();
        }

        private void tsmiProductManage_Click(object sender, EventArgs e)
        {
			if ((bool)tsmiProductManage.Tag)
                ProductForm.Show();
        }

        private void tsmiLineMangage_Click(object sender, EventArgs e)
        {
			if ((bool)tsmiLineMangage.Tag)
                LineForm.Show();
        }

        private void tsmiLaborManage_Click(object sender, EventArgs e)
        {
			if ((bool)tsmiLaborManage.Tag)
                LaborForm.Show();
        }

        private void tsmiNonProduceForm_Click(object sender, EventArgs e)
        {
			if ((bool)tsmiNonProduceForm.Tag)
                NPForm.Show();
        }

		private void tsmiQualityItem_Click(object sender, EventArgs e)
		{
			//if (_user.IsAdministrator)
			//if((bool)tsmiQualityItem.Tag)
			//    QIForm.Show();
		}

        private void tsmiWorkingHourManage_Click(object sender, EventArgs e)
        {
			if ((bool)tsmiWorkingHourManage.Tag)
                WHFrom.Show();
        }

        private void tsmiWorksheetManage_Click(object sender, EventArgs e)
        {
			if ((bool)tsmiWorksheetManage.Tag)
                WorksheetForm.Show();
        }

		private void tsmiHourDataManage_Click(object sender, EventArgs e)
		{
			if ((bool)tsmiHourDataManage.Tag)
				HourDataForm.Show();
		}

		private void tsmiUser_Click(object sender, EventArgs e)
		{
			if ((bool)tsmiUser.Tag)
				UserForm.Show();
		}

		private void tsmiInspectList_Click(object sender, EventArgs e)
		{
			if ((bool)tsmiInspectList.Tag)
				InspectListForm.Show();
		}

		private void tsmiInspect_Click(object sender, EventArgs e)
		{
			if ((bool)tsmiInspect.Tag)
				InspectForm.Show();
		}

		private void tsmiInspectDel_Click(object sender, EventArgs e)
		{
			if ((bool)tsmiInspectDel.Tag)
				InspectDeleteForm.Show();
		}


        void OpenLoginForm()
        {
            LoginForm form = new LoginForm();
            form.Location = new Point(this.Location.X + (this.Width - form.Width) / 2, this.Location.Y + (this.Height - form.Height) / 2);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                _user = form.LoginUser;

                bool managerUp = (_user.Authority >= User.Manager);
				tsmiManage.Tag = tsmiManage.Visible = managerUp;
				

				// for manager up
				tsmiProductManage.Tag = tsmiProductManage.Visible = managerUp;
				tsmiLineMangage.Tag = tsmiLineMangage.Visible = managerUp;
				tsmiNonProduceForm.Tag = tsmiNonProduceForm.Visible = managerUp;
				tsmiWorkingHourManage.Tag = tsmiWorkingHourManage.Visible = managerUp;
				tsmiWorksheetManage.Tag = tsmiWorksheetManage.Visible = managerUp;
				tsmiHourDataManage.Tag = tsmiHourDataManage.Visible = managerUp;
				tsmiInspectDel.Tag = tsmiInspectDel.Visible = managerUp;

				//for Administrator only
				tsmiLaborManage.Tag = tsmiLaborManage.Visible = _user.IsAdministrator;
				tsmiSettings.Tag = tsmiSettings.Visible = _user.IsAdministrator;
				tsmiUser.Tag = tsmiUser.Visible = _user.IsAdministrator;

				//for Ganger up
				bool gangerUp = (_user.Authority >= User.Ganger);
				tsmiWorksheet.Tag = tsmiWorksheet.Visible = gangerUp;
				tsmiDataFill.Tag = tsmiDataFill.Visible = gangerUp;
				tsmiNewWorksheet.Tag = tsmiNewWorksheet.Visible = gangerUp;

				//for QA up
				bool qaUp = (_user.Authority >= User.QA);
				tsmiQuality.Tag = tsmiQuality.Visible = qaUp;
				//tsmiInspectList.Tag = tsmiInspectList.Visible = qaUp;
				

				//for QA Only
				tsmiInspect.Tag = tsmiInspect.Visible = _user.IsQA || managerUp;
				tsmiBypassQA.Tag = tsmiBypassQA.Visible = _user.IsQA;

#if DEBUG
				tsmiInspect.Tag = tsmiInspect.Visible = true;
				tsmiBypassQA.Tag = tsmiBypassQA.Visible = true;
#endif

                UpdateReportMenu();
                menuStrip1.Visible = true;

				tsmiBypassQA.Checked = Settings.BypassQA;

            }
            else
            {
                Application.Exit();
            }
        }

        void LogOut()
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
                if (!form.IsDisposed)
                    return;
            }

            menuStrip1.Visible = false;
            OpenLoginForm();
        }

        private void tsmiNewWorksheet_Click(object sender, EventArgs e)
        {
            EditWorksheetForm form = new EditWorksheetForm();
            form.NewWorksheet();
            form.MdiParent = this;
            form.Show();
        }

        private void tsmiWorksheetSearch_Click(object sender, EventArgs e)
        {
            WorksheetForm.Show();
        }

        private void tsmiHourDataFill_Click(object sender, EventArgs e)
        {
            try
            {
                EditHourDataForm form = new EditHourDataForm();
                form.MdiParent = this;
                form.NewHourData();
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tsmiSettings_Click(object sender, EventArgs e)
        {
            SettingForm form = new SettingForm(_user);
            form.ShowDialog();
        }

        private void tsmiLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("確定要登出?", "登出確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                LogOut();
        }

        private void tsmiReport_Click(object sender, EventArgs e)
        {
            //ReportForm.Show();
        }

		private void tsmiBypassQA_Click(object sender, EventArgs e)
		{
			if ((bool)tsmiBypassQA.Tag)
			{
				string text = Settings.BypassQA ? "確定要取消略過產品檢驗步驟?" : "確定要略過產品檢驗步驟?";
				if (MessageBox.Show(this, text, "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
				{
					bool bypass = !Settings.BypassQA;
					Settings.BypassQA = bypass;
					tsmiBypassQA.Checked = bypass;
					Settings.Save();
				}
			}
		}

    }
}