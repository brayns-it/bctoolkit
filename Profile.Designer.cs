namespace Brayns.BCT
{
    partial class Profile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            ckDbIntSecurity = new CheckBox();
            label7 = new Label();
            tbDbPassword = new TextBox();
            label6 = new Label();
            tbDbLogin = new TextBox();
            label5 = new Label();
            tbDbName = new TextBox();
            label4 = new Label();
            tbDbServer = new TextBox();
            tabPage2 = new TabPage();
            label3 = new Label();
            tbInstName = new TextBox();
            btBrowsePSPath = new Button();
            label2 = new Label();
            tbPSPath = new TextBox();
            tabPage3 = new TabPage();
            label1 = new Label();
            tbDevelPath = new TextBox();
            btLoad = new Button();
            label8 = new Label();
            tbApiPassword = new TextBox();
            label9 = new Label();
            tbApiLogin = new TextBox();
            label10 = new Label();
            tbApiBase = new TextBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(13, 13);
            tabControl1.Margin = new Padding(4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1073, 568);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(ckDbIntSecurity);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(tbDbPassword);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(tbDbLogin);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(tbDbName);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(tbDbServer);
            tabPage1.Location = new Point(4, 28);
            tabPage1.Margin = new Padding(4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(4);
            tabPage1.Size = new Size(1065, 536);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Database";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // ckDbIntSecurity
            // 
            ckDbIntSecurity.AutoSize = true;
            ckDbIntSecurity.Location = new Point(168, 171);
            ckDbIntSecurity.Name = "ckDbIntSecurity";
            ckDbIntSecurity.Size = new Size(144, 23);
            ckDbIntSecurity.TabIndex = 16;
            ckDbIntSecurity.Text = "Integrated Security";
            ckDbIntSecurity.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(20, 126);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(70, 19);
            label7.TabIndex = 15;
            label7.Text = "Password:";
            // 
            // tbDbPassword
            // 
            tbDbPassword.Location = new Point(168, 122);
            tbDbPassword.Margin = new Padding(4);
            tbDbPassword.Name = "tbDbPassword";
            tbDbPassword.Size = new Size(390, 26);
            tbDbPassword.TabIndex = 14;
            tbDbPassword.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(20, 92);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(46, 19);
            label6.TabIndex = 13;
            label6.Text = "Login:";
            // 
            // tbDbLogin
            // 
            tbDbLogin.Location = new Point(168, 88);
            tbDbLogin.Margin = new Padding(4);
            tbDbLogin.Name = "tbDbLogin";
            tbDbLogin.Size = new Size(390, 26);
            tbDbLogin.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 58);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(109, 19);
            label5.TabIndex = 11;
            label5.Text = "Database Name:";
            // 
            // tbDbName
            // 
            tbDbName.Location = new Point(168, 54);
            tbDbName.Margin = new Padding(4);
            tbDbName.Name = "tbDbName";
            tbDbName.Size = new Size(390, 26);
            tbDbName.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 24);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(90, 19);
            label4.TabIndex = 9;
            label4.Text = "Server Name:";
            // 
            // tbDbServer
            // 
            tbDbServer.Location = new Point(168, 20);
            tbDbServer.Margin = new Padding(4);
            tbDbServer.Name = "tbDbServer";
            tbDbServer.Size = new Size(390, 26);
            tbDbServer.TabIndex = 8;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(tbInstName);
            tabPage2.Controls.Add(btBrowsePSPath);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(tbPSPath);
            tabPage2.Location = new Point(4, 28);
            tabPage2.Margin = new Padding(4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(4);
            tabPage2.Size = new Size(1065, 536);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Service";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 24);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(103, 19);
            label3.TabIndex = 7;
            label3.Text = "Instance Name:";
            // 
            // tbInstName
            // 
            tbInstName.Location = new Point(165, 20);
            tbInstName.Margin = new Padding(4);
            tbInstName.Name = "tbInstName";
            tbInstName.Size = new Size(199, 26);
            tbInstName.TabIndex = 6;
            // 
            // btBrowsePSPath
            // 
            btBrowsePSPath.Location = new Point(541, 54);
            btBrowsePSPath.Margin = new Padding(4);
            btBrowsePSPath.Name = "btBrowsePSPath";
            btBrowsePSPath.Size = new Size(65, 26);
            btBrowsePSPath.TabIndex = 5;
            btBrowsePSPath.Text = "...";
            btBrowsePSPath.UseVisualStyleBackColor = true;
            btBrowsePSPath.Click += btBrowsePSPath_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 58);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(130, 19);
            label2.TabIndex = 4;
            label2.Text = "BC PowerShell Path:";
            // 
            // tbPSPath
            // 
            tbPSPath.Location = new Point(165, 54);
            tbPSPath.Margin = new Padding(4);
            tbPSPath.Name = "tbPSPath";
            tbPSPath.Size = new Size(368, 26);
            tbPSPath.TabIndex = 3;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(label8);
            tabPage3.Controls.Add(tbApiPassword);
            tabPage3.Controls.Add(label9);
            tabPage3.Controls.Add(tbApiLogin);
            tabPage3.Controls.Add(label10);
            tabPage3.Controls.Add(tbApiBase);
            tabPage3.Controls.Add(label1);
            tabPage3.Controls.Add(tbDevelPath);
            tabPage3.Location = new Point(4, 28);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1065, 536);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Development";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 24);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(132, 19);
            label1.TabIndex = 11;
            label1.Text = "Development Paths:";
            label1.Click += label1_Click;
            // 
            // tbDevelPath
            // 
            tbDevelPath.Location = new Point(170, 20);
            tbDevelPath.Margin = new Padding(4);
            tbDevelPath.Multiline = true;
            tbDevelPath.Name = "tbDevelPath";
            tbDevelPath.ScrollBars = ScrollBars.Vertical;
            tbDevelPath.Size = new Size(604, 164);
            tbDevelPath.TabIndex = 10;
            tbDevelPath.TextChanged += textBox1_TextChanged;
            // 
            // btLoad
            // 
            btLoad.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btLoad.Location = new Point(982, 589);
            btLoad.Margin = new Padding(4);
            btLoad.Name = "btLoad";
            btLoad.Size = new Size(100, 34);
            btLoad.TabIndex = 3;
            btLoad.Text = "Load";
            btLoad.UseVisualStyleBackColor = true;
            btLoad.Click += btLoad_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(22, 264);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(95, 19);
            label8.TabIndex = 21;
            label8.Text = "API Password:";
            // 
            // tbApiPassword
            // 
            tbApiPassword.Location = new Point(170, 260);
            tbApiPassword.Margin = new Padding(4);
            tbApiPassword.Name = "tbApiPassword";
            tbApiPassword.Size = new Size(390, 26);
            tbApiPassword.TabIndex = 20;
            tbApiPassword.UseSystemPasswordChar = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(22, 230);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(71, 19);
            label9.TabIndex = 19;
            label9.Text = "API Login:";
            // 
            // tbApiLogin
            // 
            tbApiLogin.Location = new Point(170, 226);
            tbApiLogin.Margin = new Padding(4);
            tbApiLogin.Name = "tbApiLogin";
            tbApiLogin.Size = new Size(390, 26);
            tbApiLogin.TabIndex = 18;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(22, 196);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(94, 19);
            label10.TabIndex = 17;
            label10.Text = "API base URL:";
            // 
            // tbApiBase
            // 
            tbApiBase.Location = new Point(170, 192);
            tbApiBase.Margin = new Padding(4);
            tbApiBase.Name = "tbApiBase";
            tbApiBase.Size = new Size(390, 26);
            tbApiBase.TabIndex = 16;
            // 
            // Profile
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1099, 636);
            Controls.Add(btLoad);
            Controls.Add(tabControl1);
            Margin = new Padding(4);
            Name = "Profile";
            Text = "Profile";
            Load += Profile_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button btBrowsePSPath;
        private Label label2;
        private TextBox tbPSPath;
        private Button btLoad;
        private Label label3;
        private TextBox tbInstName;
        private CheckBox ckDbIntSecurity;
        private Label label7;
        private TextBox tbDbPassword;
        private Label label6;
        private TextBox tbDbLogin;
        private Label label5;
        private TextBox tbDbName;
        private Label label4;
        private TextBox tbDbServer;
        private TabPage tabPage3;
        private Label label1;
        private TextBox tbDevelPath;
        private Label label8;
        private TextBox tbApiPassword;
        private Label label9;
        private TextBox tbApiLogin;
        private Label label10;
        private TextBox tbApiBase;
    }
}