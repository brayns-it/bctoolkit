namespace Brayns.BCT
{
    partial class MainForm
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            modifyToolStripMenuItem = new ToolStripMenuItem();
            refreshToolStripMenuItem = new ToolStripMenuItem();
            clearLogToolStripMenuItem = new ToolStripMenuItem();
            miscToolStripMenuItem = new ToolStripMenuItem();
            publishAPPToolStripMenuItem = new ToolStripMenuItem();
            publishSymbolsToolStripMenuItem = new ToolStripMenuItem();
            uploadLicenseToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            versionToolStripMenuItem = new ToolStripMenuItem();
            byBraynsitToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            statusInstance = new ToolStripStatusLabel();
            statusDB = new ToolStripStatusLabel();
            contextApps = new ContextMenuStrip(components);
            publishToolStripMenuItem = new ToolStripMenuItem();
            syncToolStripMenuItem = new ToolStripMenuItem();
            syncForceToolStripMenuItem = new ToolStripMenuItem();
            dataUpgradeToolStripMenuItem = new ToolStripMenuItem();
            installToolStripMenuItem = new ToolStripMenuItem();
            uninstallToolStripMenuItem = new ToolStripMenuItem();
            unpublishToolStripMenuItem = new ToolStripMenuItem();
            cleanToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripSeparator();
            upgradeToolStripMenuItem = new ToolStripMenuItem();
            splitContainer1 = new SplitContainer();
            tabControl = new TabControl();
            tabApps = new TabPage();
            lvApps = new ListView();
            tbLog = new TextBox();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            contextApps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tabControl.SuspendLayout();
            tabApps.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(18, 18);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, modifyToolStripMenuItem, miscToolStripMenuItem, toolStripMenuItem2 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(8, 3, 0, 3);
            menuStrip1.Size = new Size(1012, 29);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, editToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem, closeToolStripMenuItem, toolStripMenuItem1, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(43, 23);
            fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(140, 24);
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(140, 24);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(140, 24);
            editToolStripMenuItem.Text = "Edit";
            editToolStripMenuItem.Click += editToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(140, 24);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(140, 24);
            saveAsToolStripMenuItem.Text = "Save as...";
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(140, 24);
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(137, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(140, 24);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // modifyToolStripMenuItem
            // 
            modifyToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { refreshToolStripMenuItem, clearLogToolStripMenuItem });
            modifyToolStripMenuItem.Name = "modifyToolStripMenuItem";
            modifyToolStripMenuItem.Size = new Size(52, 23);
            modifyToolStripMenuItem.Text = "View";
            // 
            // refreshToolStripMenuItem
            // 
            refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            refreshToolStripMenuItem.ShortcutKeys = Keys.F5;
            refreshToolStripMenuItem.Size = new Size(155, 24);
            refreshToolStripMenuItem.Text = "Refresh";
            refreshToolStripMenuItem.Click += refreshToolStripMenuItem_Click;
            // 
            // clearLogToolStripMenuItem
            // 
            clearLogToolStripMenuItem.Name = "clearLogToolStripMenuItem";
            clearLogToolStripMenuItem.Size = new Size(155, 24);
            clearLogToolStripMenuItem.Text = "Clear log";
            clearLogToolStripMenuItem.Click += clearLogToolStripMenuItem_Click;
            // 
            // miscToolStripMenuItem
            // 
            miscToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { publishAPPToolStripMenuItem, publishSymbolsToolStripMenuItem, uploadLicenseToolStripMenuItem });
            miscToolStripMenuItem.Name = "miscToolStripMenuItem";
            miscToolStripMenuItem.Size = new Size(65, 23);
            miscToolStripMenuItem.Text = "Service";
            // 
            // publishAPPToolStripMenuItem
            // 
            publishAPPToolStripMenuItem.Name = "publishAPPToolStripMenuItem";
            publishAPPToolStripMenuItem.Size = new Size(194, 24);
            publishAPPToolStripMenuItem.Text = "Publish APP...";
            publishAPPToolStripMenuItem.Click += publishAPPToolStripMenuItem_Click;
            // 
            // publishSymbolsToolStripMenuItem
            // 
            publishSymbolsToolStripMenuItem.Name = "publishSymbolsToolStripMenuItem";
            publishSymbolsToolStripMenuItem.Size = new Size(194, 24);
            publishSymbolsToolStripMenuItem.Text = "Publish Symbols...";
            publishSymbolsToolStripMenuItem.Click += publishSymbolsToolStripMenuItem_Click;
            // 
            // uploadLicenseToolStripMenuItem
            // 
            uploadLicenseToolStripMenuItem.Name = "uploadLicenseToolStripMenuItem";
            uploadLicenseToolStripMenuItem.Size = new Size(194, 24);
            uploadLicenseToolStripMenuItem.Text = "Upload license";
            uploadLicenseToolStripMenuItem.Click += uploadLicenseToolStripMenuItem_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.DropDownItems.AddRange(new ToolStripItem[] { versionToolStripMenuItem, byBraynsitToolStripMenuItem });
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(29, 23);
            toolStripMenuItem2.Text = "?";
            // 
            // versionToolStripMenuItem
            // 
            versionToolStripMenuItem.Name = "versionToolStripMenuItem";
            versionToolStripMenuItem.Size = new Size(239, 24);
            versionToolStripMenuItem.Text = "Version";
            // 
            // byBraynsitToolStripMenuItem
            // 
            byBraynsitToolStripMenuItem.Image = Properties.Resources.icon;
            byBraynsitToolStripMenuItem.Name = "byBraynsitToolStripMenuItem";
            byBraynsitToolStripMenuItem.Size = new Size(239, 24);
            byBraynsitToolStripMenuItem.Text = "View brayns.it on GitHub";
            byBraynsitToolStripMenuItem.Click += byBraynsitToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(18, 18);
            statusStrip1.Items.AddRange(new ToolStripItem[] { statusInstance, statusDB });
            statusStrip1.Location = new Point(0, 553);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 19, 0);
            statusStrip1.Size = new Size(1012, 24);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // statusInstance
            // 
            statusInstance.Name = "statusInstance";
            statusInstance.Size = new Size(87, 19);
            statusInstance.Text = "#INSTANCE#";
            statusInstance.Click += toolStripStatusLabel1_Click;
            // 
            // statusDB
            // 
            statusDB.Name = "statusDB";
            statusDB.Size = new Size(43, 19);
            statusDB.Text = "#DB#";
            // 
            // contextApps
            // 
            contextApps.ImageScalingSize = new Size(18, 18);
            contextApps.Items.AddRange(new ToolStripItem[] { publishToolStripMenuItem, syncToolStripMenuItem, syncForceToolStripMenuItem, dataUpgradeToolStripMenuItem, installToolStripMenuItem, uninstallToolStripMenuItem, unpublishToolStripMenuItem, cleanToolStripMenuItem, toolStripMenuItem3, upgradeToolStripMenuItem });
            contextApps.Name = "contextApps";
            contextApps.Size = new Size(165, 226);
            // 
            // publishToolStripMenuItem
            // 
            publishToolStripMenuItem.Name = "publishToolStripMenuItem";
            publishToolStripMenuItem.Size = new Size(164, 24);
            publishToolStripMenuItem.Text = "Publish";
            publishToolStripMenuItem.Click += publishToolStripMenuItem_Click;
            // 
            // syncToolStripMenuItem
            // 
            syncToolStripMenuItem.Name = "syncToolStripMenuItem";
            syncToolStripMenuItem.Size = new Size(164, 24);
            syncToolStripMenuItem.Text = "Sync";
            syncToolStripMenuItem.Click += syncToolStripMenuItem_Click;
            // 
            // syncForceToolStripMenuItem
            // 
            syncForceToolStripMenuItem.Name = "syncForceToolStripMenuItem";
            syncForceToolStripMenuItem.Size = new Size(164, 24);
            syncForceToolStripMenuItem.Text = "Sync Force";
            syncForceToolStripMenuItem.Click += syncForceToolStripMenuItem_Click;
            // 
            // dataUpgradeToolStripMenuItem
            // 
            dataUpgradeToolStripMenuItem.Name = "dataUpgradeToolStripMenuItem";
            dataUpgradeToolStripMenuItem.Size = new Size(164, 24);
            dataUpgradeToolStripMenuItem.Text = "Data Upgrade";
            dataUpgradeToolStripMenuItem.Click += dataUpgradeToolStripMenuItem_Click;
            // 
            // installToolStripMenuItem
            // 
            installToolStripMenuItem.Name = "installToolStripMenuItem";
            installToolStripMenuItem.Size = new Size(164, 24);
            installToolStripMenuItem.Text = "Install";
            installToolStripMenuItem.Click += installToolStripMenuItem_Click;
            // 
            // uninstallToolStripMenuItem
            // 
            uninstallToolStripMenuItem.Name = "uninstallToolStripMenuItem";
            uninstallToolStripMenuItem.Size = new Size(164, 24);
            uninstallToolStripMenuItem.Text = "Uninstall";
            uninstallToolStripMenuItem.Click += uninstallToolStripMenuItem_Click;
            // 
            // unpublishToolStripMenuItem
            // 
            unpublishToolStripMenuItem.Name = "unpublishToolStripMenuItem";
            unpublishToolStripMenuItem.Size = new Size(164, 24);
            unpublishToolStripMenuItem.Text = "Unpublish";
            unpublishToolStripMenuItem.Click += unpublishToolStripMenuItem_Click;
            // 
            // cleanToolStripMenuItem
            // 
            cleanToolStripMenuItem.Name = "cleanToolStripMenuItem";
            cleanToolStripMenuItem.Size = new Size(164, 24);
            cleanToolStripMenuItem.Text = "Clean";
            cleanToolStripMenuItem.Click += cleanToolStripMenuItem_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(161, 6);
            // 
            // upgradeToolStripMenuItem
            // 
            upgradeToolStripMenuItem.Name = "upgradeToolStripMenuItem";
            upgradeToolStripMenuItem.ShortcutKeys = Keys.F9;
            upgradeToolStripMenuItem.Size = new Size(164, 24);
            upgradeToolStripMenuItem.Text = "Upgrade";
            upgradeToolStripMenuItem.Click += upgradeToolStripMenuItem_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 29);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tabControl);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tbLog);
            splitContainer1.Size = new Size(1012, 524);
            splitContainer1.SplitterDistance = 259;
            splitContainer1.TabIndex = 3;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabApps);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Margin = new Padding(4);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1012, 259);
            tabControl.TabIndex = 3;
            // 
            // tabApps
            // 
            tabApps.Controls.Add(lvApps);
            tabApps.Location = new Point(4, 28);
            tabApps.Name = "tabApps";
            tabApps.Padding = new Padding(3);
            tabApps.Size = new Size(1004, 227);
            tabApps.TabIndex = 1;
            tabApps.Text = "APPs";
            tabApps.UseVisualStyleBackColor = true;
            // 
            // lvApps
            // 
            lvApps.ContextMenuStrip = contextApps;
            lvApps.Dock = DockStyle.Fill;
            lvApps.FullRowSelect = true;
            lvApps.Location = new Point(3, 3);
            lvApps.MultiSelect = false;
            lvApps.Name = "lvApps";
            lvApps.Size = new Size(998, 221);
            lvApps.TabIndex = 0;
            lvApps.UseCompatibleStateImageBehavior = false;
            lvApps.View = View.Details;
            lvApps.ColumnClick += lvApps_ColumnClick;
            lvApps.SelectedIndexChanged += lvApps_SelectedIndexChanged;
            // 
            // tbLog
            // 
            tbLog.Dock = DockStyle.Fill;
            tbLog.Font = new Font("Courier New", 9.818182F, FontStyle.Regular, GraphicsUnit.Point);
            tbLog.Location = new Point(0, 0);
            tbLog.Margin = new Padding(4);
            tbLog.Multiline = true;
            tbLog.Name = "tbLog";
            tbLog.ReadOnly = true;
            tbLog.ScrollBars = ScrollBars.Vertical;
            tbLog.Size = new Size(1012, 261);
            tbLog.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1012, 577);
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4);
            Name = "MainForm";
            Text = "BC Toolkit";
            FormClosed += MainForm_FormClosed;
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            contextApps.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            tabApps.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private StatusStrip statusStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem versionToolStripMenuItem;
        private ToolStripMenuItem byBraynsitToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem modifyToolStripMenuItem;
        private ToolStripMenuItem clearLogToolStripMenuItem;
        private ToolStripMenuItem miscToolStripMenuItem;
        private ToolStripMenuItem uploadLicenseToolStripMenuItem;
        private ToolStripStatusLabel statusInstance;
        private ToolStripStatusLabel statusDB;
        private ContextMenuStrip contextApps;
        private ToolStripMenuItem unpublishToolStripMenuItem;
        private ToolStripMenuItem cleanToolStripMenuItem;
        private SplitContainer splitContainer1;
        private TabControl tabControl;
        private TabPage tabApps;
        private ListView lvApps;
        private TextBox tbLog;
        private ToolStripMenuItem refreshToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripMenuItem uninstallToolStripMenuItem;
        private ToolStripMenuItem installToolStripMenuItem;
        private ToolStripMenuItem publishToolStripMenuItem;
        private ToolStripMenuItem syncToolStripMenuItem;
        private ToolStripMenuItem dataUpgradeToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripMenuItem upgradeToolStripMenuItem;
        private ToolStripMenuItem publishAPPToolStripMenuItem;
        private ToolStripMenuItem publishSymbolsToolStripMenuItem;
        private ToolStripMenuItem syncForceToolStripMenuItem;
    }
}

