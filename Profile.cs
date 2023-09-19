using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Brayns.BCT
{
    public partial class Profile : Form
    {
        ProfileData _data = new();

        public Profile()
        {
            InitializeComponent();
        }

        private void btBrowsePSPath_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "PowerShell Script Module|*.psm1";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var fi = new FileInfo(ofd.FileName);
                tbPSPath.Text = fi.DirectoryName;
            }
        }

        public void LoadProfile(ProfileData data)
        {
            tbPSPath.Text = data.PowerShellPath ?? "";
            tbInstName.Text = data.InstanceName ?? "";
            tbDbServer.Text = data.DatabaseServer;
            tbDbName.Text = data.DatabaseName;
            tbDbLogin.Text = data.DatabaseLogin;
            tbDbPassword.Text = Utility.DecryptString(data.DatabasePassword);
            ckDbIntSecurity.Checked = data.DatabaseIntegratedSecurity;
            tbDevelPath.Text = string.Join("\r\n", data.DevelopmentPaths);
            tbApiBase.Text = data.ApiBaseUrl;
            tbApiLogin.Text = data.ApiLogin;
            tbApiPassword.Text = data.ApiPassword;

            _data = data;
        }

        private void btLoad_Click(object sender, EventArgs e)
        {
            _data.PowerShellPath = tbPSPath.Text.Trim();
            _data.InstanceName = tbInstName.Text.Trim();
            _data.DatabaseServer = tbDbServer.Text.Trim();
            _data.DatabaseName = tbDbName.Text.Trim();
            _data.DatabaseLogin = tbDbLogin.Text.Trim();
            _data.DatabasePassword = Utility.EncryptString(tbDbPassword.Text.Trim());
            _data.DatabaseIntegratedSecurity = ckDbIntSecurity.Checked;
            _data.ApiBaseUrl = tbApiBase.Text.Trim();
            _data.ApiLogin = tbApiLogin.Text.Trim();
            _data.ApiPassword = tbApiPassword.Text.Trim();

            foreach (string line in tbDevelPath.Text.Split('\n'))
            {
                string l = line.Replace("\r", "").Trim();
                if (l.Length > 0)
                    _data.DevelopmentPaths.Add(l);
            }

            try
            {
                MainForm.Current!.LoadProfile(_data);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Profile_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
