namespace siemdotnet
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Local Network");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Networks", new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.stsMain = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblsbSpacer = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbStatus = new System.Windows.Forms.ToolStripProgressBar();
            this.tbMain = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.pnlMain = new System.Windows.Forms.SplitContainer();
            this.tvwNetworks = new System.Windows.Forms.TreeView();
            this.imgList16 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.pnlSystems = new System.Windows.Forms.SplitContainer();
            this.lvwSystems = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chMAC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chClientInstalled = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAlerts = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLastScan = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmnuHosts = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.powerShellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.waucheckps1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tcSystem = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.pbServer = new System.Windows.Forms.PictureBox();
            this.tbpAlerts = new System.Windows.Forms.TabPage();
            this.lvwAlerts = new System.Windows.Forms.ListView();
            this.chSeverity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chScript = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbPowerShell = new System.Windows.Forms.TabPage();
            this.txtPShellOutput = new System.Windows.Forms.TextBox();
            this.mnuMain.SuspendLayout();
            this.stsMain.SuspendLayout();
            this.tbMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.Panel1.SuspendLayout();
            this.pnlMain.Panel2.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSystems)).BeginInit();
            this.pnlSystems.Panel1.SuspendLayout();
            this.pnlSystems.Panel2.SuspendLayout();
            this.pnlSystems.SuspendLayout();
            this.cmnuHosts.SuspendLayout();
            this.tcSystem.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbServer)).BeginInit();
            this.tbpAlerts.SuspendLayout();
            this.tbPowerShell.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(1205, 24);
            this.mnuMain.TabIndex = 0;
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuScan,
            this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "&File";
            // 
            // mnuScan
            // 
            this.mnuScan.Name = "mnuScan";
            this.mnuScan.Size = new System.Drawing.Size(99, 22);
            this.mnuScan.Text = "Scan";
            this.mnuScan.Click += new System.EventHandler(this.mnuScan_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(99, 22);
            this.mnuExit.Text = "E&xit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // stsMain
            // 
            this.stsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblsbSpacer,
            this.pbStatus});
            this.stsMain.Location = new System.Drawing.Point(0, 623);
            this.stsMain.Name = "stsMain";
            this.stsMain.Size = new System.Drawing.Size(1205, 22);
            this.stsMain.TabIndex = 1;
            this.stsMain.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(39, 17);
            this.lblStatus.Text = "Ready";
            // 
            // lblsbSpacer
            // 
            this.lblsbSpacer.Name = "lblsbSpacer";
            this.lblsbSpacer.Size = new System.Drawing.Size(1151, 17);
            this.lblsbSpacer.Spring = true;
            // 
            // pbStatus
            // 
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.Size = new System.Drawing.Size(200, 16);
            this.pbStatus.Visible = false;
            // 
            // tbMain
            // 
            this.tbMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton4});
            this.tbMain.Location = new System.Drawing.Point(0, 24);
            this.tbMain.Name = "tbMain";
            this.tbMain.Size = new System.Drawing.Size(1205, 25);
            this.tbMain.TabIndex = 2;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::siemdotnet.Properties.Resources.Diagram;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::siemdotnet.Properties.Resources.ServerExecute;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "toolStripButton4";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 49);
            this.pnlMain.Name = "pnlMain";
            // 
            // pnlMain.Panel1
            // 
            this.pnlMain.Panel1.Controls.Add(this.tvwNetworks);
            this.pnlMain.Panel1.Controls.Add(this.toolStrip1);
            // 
            // pnlMain.Panel2
            // 
            this.pnlMain.Panel2.Controls.Add(this.pnlSystems);
            this.pnlMain.Size = new System.Drawing.Size(1205, 574);
            this.pnlMain.SplitterDistance = 226;
            this.pnlMain.TabIndex = 3;
            // 
            // tvwNetworks
            // 
            this.tvwNetworks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvwNetworks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwNetworks.FullRowSelect = true;
            this.tvwNetworks.HideSelection = false;
            this.tvwNetworks.ImageIndex = 0;
            this.tvwNetworks.ImageList = this.imgList16;
            this.tvwNetworks.Location = new System.Drawing.Point(0, 25);
            this.tvwNetworks.Name = "tvwNetworks";
            treeNode3.ImageKey = "Diagram.png";
            treeNode3.Name = "ndNone";
            treeNode3.SelectedImageKey = "Diagram.png";
            treeNode3.Tag = "1";
            treeNode3.Text = "Local Network";
            treeNode4.Name = "ndNetwork";
            treeNode4.Text = "Networks";
            this.tvwNetworks.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4});
            this.tvwNetworks.SelectedImageIndex = 1;
            this.tvwNetworks.ShowPlusMinus = false;
            this.tvwNetworks.ShowRootLines = false;
            this.tvwNetworks.Size = new System.Drawing.Size(226, 549);
            this.tvwNetworks.TabIndex = 1;
            // 
            // imgList16
            // 
            this.imgList16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList16.ImageStream")));
            this.imgList16.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList16.Images.SetKeyName(0, "FolderClosed.png");
            this.imgList16.Images.SetKeyName(1, "FolderOpen.png");
            this.imgList16.Images.SetKeyName(2, "Server.png");
            this.imgList16.Images.SetKeyName(3, "Diagram.png");
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(226, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // pnlSystems
            // 
            this.pnlSystems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSystems.Location = new System.Drawing.Point(0, 0);
            this.pnlSystems.Name = "pnlSystems";
            this.pnlSystems.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // pnlSystems.Panel1
            // 
            this.pnlSystems.Panel1.Controls.Add(this.lvwSystems);
            // 
            // pnlSystems.Panel2
            // 
            this.pnlSystems.Panel2.Controls.Add(this.tcSystem);
            this.pnlSystems.Size = new System.Drawing.Size(975, 574);
            this.pnlSystems.SplitterDistance = 357;
            this.pnlSystems.TabIndex = 0;
            // 
            // lvwSystems
            // 
            this.lvwSystems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvwSystems.CheckBoxes = true;
            this.lvwSystems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chIP,
            this.chMAC,
            this.chStatus,
            this.chClientInstalled,
            this.chAlerts,
            this.chLastScan});
            this.lvwSystems.ContextMenuStrip = this.cmnuHosts;
            this.lvwSystems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwSystems.FullRowSelect = true;
            this.lvwSystems.Location = new System.Drawing.Point(0, 0);
            this.lvwSystems.Name = "lvwSystems";
            this.lvwSystems.Size = new System.Drawing.Size(975, 357);
            this.lvwSystems.SmallImageList = this.imgList16;
            this.lvwSystems.TabIndex = 0;
            this.lvwSystems.UseCompatibleStateImageBehavior = false;
            this.lvwSystems.View = System.Windows.Forms.View.Details;
            // 
            // chName
            // 
            this.chName.Text = "Name";
            this.chName.Width = 182;
            // 
            // chIP
            // 
            this.chIP.Text = "IP Address";
            this.chIP.Width = 105;
            // 
            // chMAC
            // 
            this.chMAC.Text = "MAC Address";
            this.chMAC.Width = 117;
            // 
            // chStatus
            // 
            this.chStatus.Text = "Status";
            this.chStatus.Width = 101;
            // 
            // chClientInstalled
            // 
            this.chClientInstalled.Text = "SIEM.NET Client";
            this.chClientInstalled.Width = 101;
            // 
            // chAlerts
            // 
            this.chAlerts.Text = "Alerts";
            // 
            // chLastScan
            // 
            this.chLastScan.Text = "Last Scan";
            this.chLastScan.Width = 173;
            // 
            // cmnuHosts
            // 
            this.cmnuHosts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.powerShellToolStripMenuItem});
            this.cmnuHosts.Name = "cmnuHosts";
            this.cmnuHosts.Size = new System.Drawing.Size(136, 26);
            // 
            // powerShellToolStripMenuItem
            // 
            this.powerShellToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.windowsUpdatesToolStripMenuItem});
            this.powerShellToolStripMenuItem.Name = "powerShellToolStripMenuItem";
            this.powerShellToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.powerShellToolStripMenuItem.Text = "Power Shell";
            // 
            // windowsUpdatesToolStripMenuItem
            // 
            this.windowsUpdatesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.waucheckps1ToolStripMenuItem});
            this.windowsUpdatesToolStripMenuItem.Name = "windowsUpdatesToolStripMenuItem";
            this.windowsUpdatesToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.windowsUpdatesToolStripMenuItem.Text = "Windows Updates";
            // 
            // waucheckps1ToolStripMenuItem
            // 
            this.waucheckps1ToolStripMenuItem.Name = "waucheckps1ToolStripMenuItem";
            this.waucheckps1ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.waucheckps1ToolStripMenuItem.Text = "waucheck.ps1";
            // 
            // tcSystem
            // 
            this.tcSystem.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tcSystem.Controls.Add(this.tbpGeneral);
            this.tcSystem.Controls.Add(this.tbpAlerts);
            this.tcSystem.Controls.Add(this.tbPowerShell);
            this.tcSystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcSystem.Location = new System.Drawing.Point(0, 0);
            this.tcSystem.Name = "tcSystem";
            this.tcSystem.SelectedIndex = 0;
            this.tcSystem.Size = new System.Drawing.Size(975, 213);
            this.tcSystem.TabIndex = 0;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.pbServer);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 4);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tbpGeneral.Size = new System.Drawing.Size(967, 187);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            this.tbpGeneral.UseVisualStyleBackColor = true;
            // 
            // pbServer
            // 
            this.pbServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbServer.Image = global::siemdotnet.Properties.Resources.Server1;
            this.pbServer.Location = new System.Drawing.Point(849, 63);
            this.pbServer.Name = "pbServer";
            this.pbServer.Size = new System.Drawing.Size(118, 124);
            this.pbServer.TabIndex = 0;
            this.pbServer.TabStop = false;
            // 
            // tbpAlerts
            // 
            this.tbpAlerts.Controls.Add(this.lvwAlerts);
            this.tbpAlerts.Location = new System.Drawing.Point(4, 4);
            this.tbpAlerts.Name = "tbpAlerts";
            this.tbpAlerts.Padding = new System.Windows.Forms.Padding(3);
            this.tbpAlerts.Size = new System.Drawing.Size(967, 187);
            this.tbpAlerts.TabIndex = 1;
            this.tbpAlerts.Text = "Alerts (0)";
            this.tbpAlerts.UseVisualStyleBackColor = true;
            // 
            // lvwAlerts
            // 
            this.lvwAlerts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chSeverity,
            this.chMessage,
            this.chScript});
            this.lvwAlerts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwAlerts.FullRowSelect = true;
            this.lvwAlerts.HideSelection = false;
            this.lvwAlerts.Location = new System.Drawing.Point(3, 3);
            this.lvwAlerts.Name = "lvwAlerts";
            this.lvwAlerts.Size = new System.Drawing.Size(961, 181);
            this.lvwAlerts.TabIndex = 0;
            this.lvwAlerts.UseCompatibleStateImageBehavior = false;
            this.lvwAlerts.View = System.Windows.Forms.View.Details;
            // 
            // chSeverity
            // 
            this.chSeverity.Text = "Severity";
            // 
            // chMessage
            // 
            this.chMessage.Text = "Message";
            this.chMessage.Width = 648;
            // 
            // chScript
            // 
            this.chScript.Text = "Script";
            this.chScript.Width = 209;
            // 
            // tbPowerShell
            // 
            this.tbPowerShell.BackColor = System.Drawing.Color.Gray;
            this.tbPowerShell.Controls.Add(this.txtPShellOutput);
            this.tbPowerShell.Location = new System.Drawing.Point(4, 4);
            this.tbPowerShell.Name = "tbPowerShell";
            this.tbPowerShell.Padding = new System.Windows.Forms.Padding(3);
            this.tbPowerShell.Size = new System.Drawing.Size(967, 187);
            this.tbPowerShell.TabIndex = 2;
            this.tbPowerShell.Text = "PowerShell";
            // 
            // txtPShellOutput
            // 
            this.txtPShellOutput.BackColor = System.Drawing.Color.SteelBlue;
            this.txtPShellOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPShellOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPShellOutput.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPShellOutput.ForeColor = System.Drawing.Color.White;
            this.txtPShellOutput.Location = new System.Drawing.Point(3, 3);
            this.txtPShellOutput.Multiline = true;
            this.txtPShellOutput.Name = "txtPShellOutput";
            this.txtPShellOutput.ReadOnly = true;
            this.txtPShellOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPShellOutput.Size = new System.Drawing.Size(961, 181);
            this.txtPShellOutput.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 645);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.tbMain);
            this.Controls.Add(this.stsMain);
            this.Controls.Add(this.mnuMain);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMain;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SIEM.NET";
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.stsMain.ResumeLayout(false);
            this.stsMain.PerformLayout();
            this.tbMain.ResumeLayout(false);
            this.tbMain.PerformLayout();
            this.pnlMain.Panel1.ResumeLayout(false);
            this.pnlMain.Panel1.PerformLayout();
            this.pnlMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlSystems.Panel1.ResumeLayout(false);
            this.pnlSystems.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlSystems)).EndInit();
            this.pnlSystems.ResumeLayout(false);
            this.cmnuHosts.ResumeLayout(false);
            this.tcSystem.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbServer)).EndInit();
            this.tbpAlerts.ResumeLayout(false);
            this.tbPowerShell.ResumeLayout(false);
            this.tbPowerShell.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.StatusStrip stsMain;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStrip tbMain;
        private System.Windows.Forms.SplitContainer pnlMain;
        private System.Windows.Forms.ToolStripMenuItem mnuScan;
        private System.Windows.Forms.SplitContainer pnlSystems;
        private System.Windows.Forms.TreeView tvwNetworks;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ListView lvwSystems;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chIP;
        private System.Windows.Forms.ColumnHeader chStatus;
        private System.Windows.Forms.ImageList imgList16;
        private System.Windows.Forms.TabControl tcSystem;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.TabPage tbpAlerts;
        private System.Windows.Forms.ColumnHeader chMAC;
        private System.Windows.Forms.ColumnHeader chClientInstalled;
        private System.Windows.Forms.ColumnHeader chAlerts;
        private System.Windows.Forms.ColumnHeader chLastScan;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.PictureBox pbServer;
        private System.Windows.Forms.ToolStripStatusLabel lblsbSpacer;
        private System.Windows.Forms.ToolStripProgressBar pbStatus;
        private System.Windows.Forms.TabPage tbPowerShell;
        private System.Windows.Forms.TextBox txtPShellOutput;
        private System.Windows.Forms.ContextMenuStrip cmnuHosts;
        private System.Windows.Forms.ToolStripMenuItem powerShellToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsUpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem waucheckps1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ListView lvwAlerts;
        private System.Windows.Forms.ColumnHeader chSeverity;
        private System.Windows.Forms.ColumnHeader chMessage;
        private System.Windows.Forms.ColumnHeader chScript;
    }
}

