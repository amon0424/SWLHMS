namespace Mong
{
    partial class LoginForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該公開 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
			this.rbGenUser = new System.Windows.Forms.RadioButton();
			this.rbAccount = new System.Windows.Forms.RadioButton();
			this.btnLogin = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.tbxUsername = new System.Windows.Forms.TextBox();
			this.tbxPassword = new System.Windows.Forms.TextBox();
			this.btnExit = new System.Windows.Forms.Button();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.rbAdmin = new System.Windows.Forms.RadioButton();
			this.rbAdmin2 = new System.Windows.Forms.RadioButton();
			this.rbGanger = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rbQA = new System.Windows.Forms.RadioButton();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// rbGenUser
			// 
			this.rbGenUser.AutoSize = true;
			this.rbGenUser.Checked = true;
			this.rbGenUser.Location = new System.Drawing.Point(5, 51);
			this.rbGenUser.Name = "rbGenUser";
			this.rbGenUser.Size = new System.Drawing.Size(83, 16);
			this.rbGenUser.TabIndex = 0;
			this.rbGenUser.TabStop = true;
			this.rbGenUser.Text = "一般使用者";
			this.rbGenUser.UseVisualStyleBackColor = true;
			this.rbGenUser.Visible = false;
			// 
			// rbAccount
			// 
			this.rbAccount.AutoSize = true;
			this.rbAccount.Location = new System.Drawing.Point(89, 51);
			this.rbAccount.Name = "rbAccount";
			this.rbAccount.Size = new System.Drawing.Size(47, 16);
			this.rbAccount.TabIndex = 1;
			this.rbAccount.Text = "帳號";
			this.rbAccount.UseVisualStyleBackColor = true;
			this.rbAccount.Visible = false;
			this.rbAccount.CheckedChanged += new System.EventHandler(this.rbAccount_CheckedChanged);
			// 
			// btnLogin
			// 
			this.btnLogin.Location = new System.Drawing.Point(37, 216);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(83, 33);
			this.btnLogin.TabIndex = 2;
			this.btnLogin.Text = "登入";
			this.btnLogin.UseVisualStyleBackColor = true;
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(54, 189);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 12);
			this.label1.TabIndex = 3;
			this.label1.Text = "密碼";
			// 
			// tbxUsername
			// 
			this.tbxUsername.Enabled = false;
			this.tbxUsername.Location = new System.Drawing.Point(136, 48);
			this.tbxUsername.Name = "tbxUsername";
			this.tbxUsername.Size = new System.Drawing.Size(36, 22);
			this.tbxUsername.TabIndex = 0;
			this.tbxUsername.Visible = false;
			// 
			// tbxPassword
			// 
			this.tbxPassword.Location = new System.Drawing.Point(89, 184);
			this.tbxPassword.Name = "tbxPassword";
			this.tbxPassword.Size = new System.Drawing.Size(111, 22);
			this.tbxPassword.TabIndex = 1;
			this.tbxPassword.UseSystemPasswordChar = true;
			// 
			// btnExit
			// 
			this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnExit.Location = new System.Drawing.Point(137, 216);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(83, 33);
			this.btnExit.TabIndex = 3;
			this.btnExit.Text = "離開";
			this.btnExit.UseVisualStyleBackColor = true;
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.LinkArea = new System.Windows.Forms.LinkArea(4, 39);
			this.linkLabel1.Location = new System.Drawing.Point(4, 255);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(242, 19);
			this.linkLabel1.TabIndex = 7;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "程式: 謝孟原 among0424@gmail.com";
			this.linkLabel1.UseCompatibleTextRendering = true;
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold);
			this.label2.Location = new System.Drawing.Point(12, 14);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(168, 16);
			this.label2.TabIndex = 8;
			this.label2.Text = "SW生產工時管理系統";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(55, 36);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(179, 12);
			this.label3.TabIndex = 9;
			this.label3.Text = "SW Labor Hour Management System";
			// 
			// rbAdmin
			// 
			this.rbAdmin.AutoSize = true;
			this.rbAdmin.Checked = true;
			this.rbAdmin.Location = new System.Drawing.Point(19, 17);
			this.rbAdmin.Name = "rbAdmin";
			this.rbAdmin.Size = new System.Drawing.Size(83, 16);
			this.rbAdmin.TabIndex = 0;
			this.rbAdmin.TabStop = true;
			this.rbAdmin.Text = "系統管理員";
			this.rbAdmin.UseVisualStyleBackColor = true;
			// 
			// rbAdmin2
			// 
			this.rbAdmin2.AutoSize = true;
			this.rbAdmin2.Location = new System.Drawing.Point(19, 39);
			this.rbAdmin2.Name = "rbAdmin2";
			this.rbAdmin2.Size = new System.Drawing.Size(83, 16);
			this.rbAdmin2.TabIndex = 1;
			this.rbAdmin2.Text = "一般管理員";
			this.rbAdmin2.UseVisualStyleBackColor = true;
			this.rbAdmin2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
			// 
			// rbGanger
			// 
			this.rbGanger.AutoSize = true;
			this.rbGanger.Location = new System.Drawing.Point(19, 61);
			this.rbGanger.Name = "rbGanger";
			this.rbGanger.Size = new System.Drawing.Size(47, 16);
			this.rbGanger.TabIndex = 2;
			this.rbGanger.Text = "領班";
			this.rbGanger.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rbQA);
			this.groupBox1.Controls.Add(this.rbGanger);
			this.groupBox1.Controls.Add(this.rbAdmin);
			this.groupBox1.Controls.Add(this.rbAdmin2);
			this.groupBox1.Location = new System.Drawing.Point(34, 68);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(183, 106);
			this.groupBox1.TabIndex = 12;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "身分";
			// 
			// rbQA
			// 
			this.rbQA.AutoSize = true;
			this.rbQA.Location = new System.Drawing.Point(19, 83);
			this.rbQA.Name = "rbQA";
			this.rbQA.Size = new System.Drawing.Size(47, 16);
			this.rbQA.TabIndex = 3;
			this.rbQA.Text = "品保";
			this.rbQA.UseVisualStyleBackColor = true;
			// 
			// LoginForm
			// 
			this.AcceptButton = this.btnLogin;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(250, 272);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbxUsername);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.rbAccount);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.tbxPassword);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnLogin);
			this.Controls.Add(this.rbGenUser);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "LoginForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "登入";
			this.Load += new System.EventHandler(this.LoginForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbGenUser;
        private System.Windows.Forms.RadioButton rbAccount;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxUsername;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbAdmin2;
        private System.Windows.Forms.RadioButton rbAdmin;
        private System.Windows.Forms.RadioButton rbGanger;
        private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rbQA;
    }
}