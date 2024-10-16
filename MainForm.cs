using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Management.Automation.Runspaces;
using System.Management.Automation;

namespace Brayns.BCT
{
    public partial class MainForm : Form
    {
        private ListViewColumnSorter? _lvAppsSorter;
        private bool _profileLoaded = false;

        public static MainForm? Current { get; set; }

        public ProfileData ProfileData { get; set; }
        public string ProfileFileName { get; set; }
        public Runspace? Runspace { get; set; }
        public BC? BC { get; set; }
        public string SettingsFile { get; set; }
        public Settings Settings { get; set; }

        public MainForm()
        {
            InitializeComponent();
            Current = this;
            ProfileFileName = "";
            ProfileData = new ProfileData();
            Settings = new Settings();

            FileInfo fi = new FileInfo(Application.ExecutablePath);
            SettingsFile = fi.DirectoryName + "\\settings.json";

            _lvAppsSorter = new ListViewColumnSorter(lvApps);
            lvApps.ListViewItemSorter = _lvAppsSorter;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            versionToolStripMenuItem.Text += " " + fvi.FileVersion;

            try
            {
                if (File.Exists(SettingsFile))
                {
                    var sr = new StreamReader(SettingsFile);
                    Settings = JObject.Parse(sr.ReadToEnd()).ToObject<Settings>()!;
                    sr.Close();

                    if (Settings.WindowMaximized) WindowState = FormWindowState.Maximized;
                    if (Settings.WindowTop.HasValue) Top = Settings.WindowTop.Value;
                    if (Settings.WindowWidth.HasValue) Width = Settings.WindowWidth.Value;
                    if (Settings.WindowLeft.HasValue) Left = Settings.WindowLeft.Value;
                    if (Settings.WindowHeight.HasValue) Height = Settings.WindowHeight.Value;
                    if (Settings.WindowSplitSize.HasValue) splitContainer1.SplitterDistance = Settings.WindowSplitSize.Value;

                    if (Settings.LastProfile != null)
                        LoadProfileFromDisk(Settings.LastProfile);
                }
            }
            catch
            {
            }

            RefreshUI();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var prf = new Profile();
            prf.ShowDialog();
        }

        private void RefreshCaption()
        {
            Text = "BC Toolkit";
            if (ProfileFileName.Length > 0)
            {
                var fi = new FileInfo(ProfileFileName);
                Text += " | " + fi.Name;
            }
        }

        private void RefreshUI()
        {
            RefreshCaption();

            statusInstance.Text = ProfileData.InstanceName;
            if (ProfileData.DatabaseName.Length > 0)
                statusDB.Text = ProfileData.DatabaseName + " @ " + ProfileData.DatabaseServer;
            else
                statusDB.Text = "";

            newToolStripMenuItem.Enabled = true;
            openToolStripMenuItem.Enabled = true;
            editToolStripMenuItem.Enabled = _profileLoaded;
            saveToolStripMenuItem.Enabled = _profileLoaded;
            saveAsToolStripMenuItem.Enabled = _profileLoaded;
            uploadLicenseToolStripMenuItem.Enabled = _profileLoaded;
            refreshToolStripMenuItem.Enabled = _profileLoaded;
            closeToolStripMenuItem.Enabled = _profileLoaded;

            tabControl.TabPages.Clear();
            if (_profileLoaded)
            {
                tabControl.TabPages.Add(tabApps);
            }

            Application.DoEvents();
        }

        private void RefreshAppsUI()
        {
            lvApps.Clear();
            lvApps.Columns.Clear();

            lvApps.Columns.Add("Name", 300);
            lvApps.Columns.Add("Publisher", 200);
            lvApps.Columns.Add("Version", 150);
            lvApps.Columns.Add("Status", 150);

            if (BC == null)
                return;

            foreach (NavApp a in BC.Apps)
            {
                var itm = new ListViewItem();
                itm.Text = a.Name;
                itm.Tag = a;

                var sub = new ListViewItem.ListViewSubItem();
                sub.Text = a.Publisher;
                sub.Tag = a.Publisher;
                itm.SubItems.Add(sub);

                sub = new ListViewItem.ListViewSubItem();
                sub.Text = a.Version!.ToString();
                sub.Tag = a.Version;
                itm.SubItems.Add(sub);

                sub = new ListViewItem.ListViewSubItem();
                sub.Text = a.Status.ToString();
                sub.Tag = a.Status;
                itm.SubItems.Add(sub);

                lvApps.Items.Add(itm);
            }
        }

        private void RefreshProfile()
        {
            BC = null;
            _profileLoaded = false;

            if (Runspace != null)
            {
                Runspace.Close();
                Runspace = null;
            }

            if (ProfileData.PowerShellPath.Length > 0)
            {
                AddLog("Loading PowerShell... ", false);

                if (!ProfileData.PowerShellPath.EndsWith("\\"))
                    ProfileData.PowerShellPath += "\\";

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Set-ExecutionPolicy Unrestricted");

                // V23
                var fi = new FileInfo(ProfileData.PowerShellPath + "Microsoft.Dynamics.Nav.Management.psd1");
                if (fi.Exists) sb.AppendLine("Import-Module '" + fi.FullName + "'");

                fi = new FileInfo(ProfileData.PowerShellPath + "Microsoft.Dynamics.Nav.Apps.Tools.psd1");
                if (fi.Exists) sb.AppendLine("Import-Module '" + fi.FullName + "'");

                fi = new FileInfo(ProfileData.PowerShellPath + "Microsoft.Dynamics.Nav.Apps.Management.psd1");
                if (fi.Exists) sb.AppendLine("Import-Module '" + fi.FullName + "'");

                // V24
                fi = new FileInfo(ProfileData.PowerShellPath + "NavAdminTool.ps1");
                if (fi.Exists) sb.AppendLine("Import-Module '" + fi.FullName + "'");

                var psi = new PowerShellProcessInstance(new Version(5, 1), null, ScriptBlock.Create(sb.ToString()), false);
                Runspace = RunspaceFactory.CreateOutOfProcessRunspace(null, psi);
                Runspace.Open();

                AddLog("done.");
            }

            if (ProfileData.DatabaseName.Length > 0)
            {
                AddLog("Reading BC status... ", false);

                BC = new BC(ProfileData);
                BC.Load();

                AddLog("done.");
            }

            _profileLoaded = true;
            RefreshAppsUI();
        }

        private void AddLog(string text, bool newLine = true)
        {
            tbLog.Text += text + (newLine ? "\r\n" : "");
            tbLog.SelectionStart = tbLog.Text.Length;
            tbLog.ScrollToCaret();
            Application.DoEvents();
        }

        private void SaveProfile()
        {
            var jo = JObject.FromObject(ProfileData);

            var sw = new StreamWriter(ProfileFileName);
            sw.Write(jo.ToString(Newtonsoft.Json.Formatting.Indented));
            sw.Close();

            RefreshCaption();
        }

        private string StripInvalidChars(string txt)
        {
            txt = txt.Replace("\\", "");
            txt = txt.Replace("/", "");
            txt = txt.Replace(":", "");
            txt = txt.Replace("*", "");
            txt = txt.Replace(">", "");
            txt = txt.Replace("<", "");
            txt = txt.Replace("?", "");
            return txt;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var sfd = new SaveFileDialog();
                if (ProfileFileName.Length > 0)
                    sfd.FileName = ProfileFileName;
                sfd.Filter = "Config File|*.json";
                sfd.OverwritePrompt = true;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ProfileFileName = sfd.FileName;
                    SaveProfile();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadProfileFromDisk(string fileName)
        {
            var sr = new StreamReader(fileName);
            var jo = JObject.Parse(sr.ReadToEnd());
            sr.Close();
            ProfileData = jo.ToObject<ProfileData>()!;
            ProfileFileName = fileName;

            RefreshProfile();
            RefreshUI();
        }

        public void LoadProfile(ProfileData data)
        {
            ProfileData = data;

            RefreshProfile();
            RefreshUI();
        }

        private void byBraynsitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("https://github.com/brayns-it/bctoolkit");
            psi.UseShellExecute = true;
            System.Diagnostics.Process.Start(psi);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ProfileFileName.Length == 0)
            {
                saveAsToolStripMenuItem.PerformClick();
                return;
            }

            try
            {
                SaveProfile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var ofd = new OpenFileDialog();
                ofd.Filter = "Config File|*.json";
                if (ofd.ShowDialog() == DialogResult.OK)
                    LoadProfileFromDisk(ofd.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ProfileFileName.Length > 0)
            {
                var prf = new Profile();
                prf.LoadProfile(ProfileData);
                prf.ShowDialog();
            }
        }

        private void clearLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbLog.Text = "";
        }

        private bool ExecutePowerShell(string command)
        {
            PowerShell ps = PowerShell.Create(Runspace);
            ps.AddScript(command);
            ps.Invoke();

            if (ps.Streams.Error.Count > 0)
            {
                foreach (ErrorRecord er in ps.Streams.Error)
                    AddLog(er.ToString());
                return false;
            }

            return true;
        }

        private void uploadLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var ofd = new OpenFileDialog();
                ofd.Filter = "FLF License|*.flf|BC License|*.bclicense";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    AddLog(string.Format("Uploading license '{0}'... ", ofd.FileName), false);
                    if (ExecutePowerShell("Import-NAVServerLicense -ServerInstance " + ProfileData.InstanceName + " -Force -Database NavDatabase -LicenseFile \"" + ofd.FileName + "\""))
                        AddLog("done.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private NavApp? GetSelectedApp()
        {
            if (lvApps.SelectedItems.Count == 0)
                return null;

            return (NavApp)lvApps.SelectedItems[0].Tag!;
        }

        private bool UnpublishApp(NavApp app)
        {
            AddLog(string.Format("Unpublish APP '{0}'... ", app.Name), false);
            if (ExecutePowerShell("Unpublish-NAVApp -ServerInstance " + ProfileData.InstanceName + " -Name \"" + app.Name + "\" -Version " + app.Version))
            {
                AddLog("done.");
                return true;
            }
            return false;
        }

        private void unpublishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var app = GetSelectedApp();
                if (app == null) return;

                if (MessageBox.Show(string.Format("Unpublish APP '{0}'?", app.Name), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                if (UnpublishApp(app))
                {
                    BC!.Load();
                    RefreshAppsUI();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CleanApp(NavApp app)
        {
            AddLog(string.Format("Clean APP '{0}'... ", app.Name), false);
            if (ExecutePowerShell("Sync-NAVApp -ServerInstance " + ProfileData.InstanceName + " -Mode Clean -Name \"" + app.Name + "\" -Publisher \"" + app.Publisher + "\" -Version " + app.Version))
            {
                AddLog("done.");
                return true;
            }
            return false;
        }

        private void cleanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var app = GetSelectedApp();
                if (app == null) return;

                if (MessageBox.Show(string.Format("Clean APP '{0}'?", app.Name), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                if (CleanApp(app))
                {
                    BC!.Load();
                    RefreshAppsUI();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (BC != null) BC!.Load();
                RefreshAppsUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (ProfileFileName.Length > 0)
                    SaveProfile();

                Settings.WindowHeight = Height;
                Settings.WindowTop = Top;
                Settings.WindowLeft = Left;
                Settings.WindowWidth = Width;
                Settings.LastProfile = ProfileFileName;
                Settings.WindowSplitSize = splitContainer1.SplitterDistance;

                var sw = new StreamWriter(SettingsFile);
                sw.Write(JObject.FromObject(Settings).ToString(Newtonsoft.Json.Formatting.Indented));
                sw.Close();
            }
            catch
            {
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveProfile();
                ProfileFileName = "";
                ProfileData = new ProfileData();
                BC = null;
                if (Runspace != null)
                {
                    Runspace.Close();
                    Runspace = null;
                }
                tabControl.TabPages.Clear();
                _profileLoaded = false;
                RefreshUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lvApps_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == _lvAppsSorter!.Column)
            {
                _lvAppsSorter.Descending = !_lvAppsSorter.Descending;
            }
            else
            {
                _lvAppsSorter.Column = e.Column;
                _lvAppsSorter.Descending = false;
            }

            lvApps.Sort();
        }

        private bool UninstallApp(NavApp app)
        {
            AddLog(string.Format("Uninstall APP '{0}'... ", app.Name), false);
            if (ExecutePowerShell("Uninstall-NAVApp -ServerInstance " + ProfileData.InstanceName + " -Name \"" + app.Name + "\" -Version " + app.Version))
            {
                AddLog("done.");
                return true;
            }
            return false;
        }

        private void uninstallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var app = GetSelectedApp();
                if (app == null) return;

                if (MessageBox.Show(string.Format("Uninstall APP '{0}'?", app.Name), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                if (UninstallApp(app))
                {
                    BC!.Load();
                    RefreshAppsUI();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool InstallApp(NavApp app)
        {
            AddLog(string.Format("Install APP '{0}'... ", app.Name), false);
            if (ExecutePowerShell("Install-NAVApp -ServerInstance " + ProfileData.InstanceName + " -Name \"" + app.Name + "\" -Version " + app.Version))
            {
                AddLog("done.");
                return true;
            }
            return false;
        }

        private void installToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var app = GetSelectedApp();
                if (app == null) return;

                if (MessageBox.Show(string.Format("Install APP '{0}'?", app.Name), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                if (InstallApp(app))
                {
                    BC!.Load();
                    RefreshAppsUI();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool PublishApp(NavApp app)
        {
            if (app.Name.Length > 0)
                AddLog(string.Format("Publish APP '{0}' from '{1}'... ", app.Name, app.FileName), false);
            else if (app.SymbolsOnly)
                AddLog(string.Format("Publish symbols from '{0}'... ", app.FileName), false);
            else
                AddLog(string.Format("Publish APP from '{0}'... ", app.FileName), false);

            string cmd = "Publish-NAVApp -ServerInstance " + ProfileData.InstanceName + " -Path \"" + app.FileName + "\" -SkipVerification";
            if (app.SymbolsOnly)
                cmd += " -PackageType SymbolsOnly";

            if (ExecutePowerShell(cmd))
            {
                AddLog("done.");
                return true;
            }
            return false;
        }

        private void publishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var app = GetSelectedApp();
                if (app == null) return;
                if (app.FileName.Length == 0) return;

                if (MessageBox.Show(string.Format("Publish APP '{0}'?", app.Name), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                if (PublishApp(app))
                {
                    BC!.Load();
                    RefreshAppsUI();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lvApps_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private bool SyncApp(NavApp app, bool force)
        {
            AddLog(string.Format("Sync APP '{0}' force '{1}'... ", app.Name, force), false);

            string cmd = "Sync-NAVApp -ServerInstance " + ProfileData.InstanceName + " -Name \"" + app.Name + "\" -Version " + app.Version;
            if (force) cmd += " -Mode ForceSync";

            if (ExecutePowerShell(cmd))
            {
                AddLog("done.");
                return true;
            }

            return false;
        }

        private void syncToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var app = GetSelectedApp();
                if (app == null) return;

                if (MessageBox.Show(string.Format("Sync APP '{0}'?", app.Name), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                SyncApp(app, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool DataUpgradeApp(NavApp app)
        {
            AddLog(string.Format("Data Upgrade APP '{0}'... ", app.Name), false);
            if (ExecutePowerShell("Start-NAVAppDataUpgrade -ServerInstance " + ProfileData.InstanceName + " -Force -Name \"" + app.Name + "\" -Version " + app.Version))
            {
                AddLog("done.");
                return true;
            }
            return false;
        }

        private void dataUpgradeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var app = GetSelectedApp();
                if (app == null) return;

                if (MessageBox.Show(string.Format("Data Upgrade APP '{0}'?", app.Name), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                DataUpgradeApp(app);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void upgradeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var app = GetSelectedApp();
                if (app == null) return;
                if (app.Status != NavAppStatus.Available)
                    if (BC!.NewerAppExists(app))
                        return;

                if (MessageBox.Show(string.Format("Upgrade APP '{0}'?", app.Name), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                foreach (NavApp a in BC!.Apps)
                {
                    if ((a.ID == app.ID) && (a.Status != NavAppStatus.Available) && (a.Version != app.Version))
                    {
                        if (a.Status == NavAppStatus.Installed)
                        {
                            UninstallApp(a);
                            UnpublishApp(a);
                        }
                        if (a.Status == NavAppStatus.Published)
                            UnpublishApp(a);
                    }
                }

                if (app.Status == NavAppStatus.Available)
                    PublishApp(app);

                SyncApp(app, false);
                DataUpgradeApp(app);
                InstallApp(app);

                BC!.Load();
                RefreshAppsUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void publishAPPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var ofd = new OpenFileDialog();
                ofd.Filter = "APP File|*.app";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var a = new NavApp();
                    a.FileName = ofd.FileName;
                    if (PublishApp(a))
                    {
                        BC!.Load();
                        RefreshAppsUI();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void publishSymbolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var ofd = new OpenFileDialog();
                ofd.Filter = "APP File|*.app";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var a = new NavApp();
                    a.FileName = ofd.FileName;
                    a.SymbolsOnly = true;
                    if (PublishApp(a))
                    {
                        BC!.Load();
                        RefreshAppsUI();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void syncForceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var app = GetSelectedApp();
                if (app == null) return;

                if (MessageBox.Show(string.Format("Force sync APP '{0}'?", app.Name), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                SyncApp(app, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
