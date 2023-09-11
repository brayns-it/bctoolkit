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
        }

        private void btLoad_Click(object sender, EventArgs e)
        {
            var data = new ProfileData();
            data.PowerShellPath = tbPSPath.Text.Trim();
            data.InstanceName = tbInstName.Text.Trim();
            data.DatabaseServer = tbDbServer.Text.Trim();
            data.DatabaseName = tbDbName.Text.Trim();
            data.DatabaseLogin = tbDbLogin.Text.Trim();
            data.DatabasePassword = Utility.EncryptString(tbDbPassword.Text.Trim());
            data.DatabaseIntegratedSecurity = ckDbIntSecurity.Checked;
            
            foreach (string line in tbDevelPath.Text.Split('\n'))
            {
                string l = line.Replace("\r", "").Trim();
                if (l.Length > 0)
                    data.DevelopmentPaths.Add(l);
            }

            try
            {
                MainForm.Current!.LoadProfile(data);
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
