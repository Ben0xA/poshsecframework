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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Local Network");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Networks", new System.Windows.Forms.TreeNode[] {
            treeNode1});
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
            this.imgList16 = new System.Windows.Forms.ImageList(this.components);
            this.pnlSystems = new System.Windows.Forms.SplitContainer();
            this.cmnuHosts = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.powerShellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.waucheckps1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tcSystem = new System.Windows.Forms.TabControl();
            this.tbpAlerts = new System.Windows.Forms.TabPage();
            this.tbpScripts = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.spltNetworks = new System.Windows.Forms.Splitter();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cmbLibraryTypes = new System.Windows.Forms.ToolStripComboBox();
            this.lvwLibrary = new System.Windows.Forms.ListView();
            this.chLibName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLibModule = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tvwNetworks = new System.Windows.Forms.TreeView();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.lvwAlerts = new System.Windows.Forms.ListView();
            this.chSeverity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chScript = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.tbpPowerShell = new System.Windows.Forms.TabPage();
            this.txtPShellOutput = new System.Windows.Forms.TextBox();
            this.tbpSystems = new System.Windows.Forms.TabPage();
            this.lvwSystems = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chMAC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chClientInstalled = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAlerts = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLastScan = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tcMain = new System.Windows.Forms.TabControl();
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
            this.tbpAlerts.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.tbpPowerShell.SuspendLayout();
            this.tbpSystems.SuspendLayout();
            this.tcMain.SuspendLayout();
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
            this.toolStripButton1.Image = global::poshsecframework.Properties.Resources.Diagram;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::poshsecframework.Properties.Resources.ServerExecute;
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
            this.pnlMain.Panel1.Controls.Add(this.spltNetworks);
            this.pnlMain.Panel1.Controls.Add(this.panel1);
            // 
            // pnlMain.Panel2
            // 
            this.pnlMain.Panel2.Controls.Add(this.pnlSystems);
            this.pnlMain.Size = new System.Drawing.Size(1205, 574);
            this.pnlMain.SplitterDistance = 226;
            this.pnlMain.TabIndex = 3;
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
            // pnlSystems
            // 
            this.pnlSystems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSystems.Location = new System.Drawing.Point(0, 0);
            this.pnlSystems.Name = "pnlSystems";
            this.pnlSystems.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // pnlSystems.Panel1
            // 
            this.pnlSystems.Panel1.Controls.Add(this.tcMain);
            // 
            // pnlSystems.Panel2
            // 
            this.pnlSystems.Panel2.Controls.Add(this.tcSystem);
            this.pnlSystems.Size = new System.Drawing.Size(975, 574);
            this.pnlSystems.SplitterDistance = 340;
            this.pnlSystems.TabIndex = 0;
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
            this.tcSystem.Controls.Add(this.tbpAlerts);
            this.tcSystem.Controls.Add(this.tbpScripts);
            this.tcSystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcSystem.Location = new System.Drawing.Point(0, 0);
            this.tcSystem.Name = "tcSystem";
            this.tcSystem.SelectedIndex = 0;
            this.tcSystem.Size = new System.Drawing.Size(975, 230);
            this.tcSystem.TabIndex = 0;
            // 
            // tbpAlerts
            // 
            this.tbpAlerts.Controls.Add(this.lvwAlerts);
            this.tbpAlerts.Controls.Add(this.toolStrip3);
            this.tbpAlerts.Location = new System.Drawing.Point(4, 4);
            this.tbpAlerts.Name = "tbpAlerts";
            this.tbpAlerts.Padding = new System.Windows.Forms.Padding(3);
            this.tbpAlerts.Size = new System.Drawing.Size(967, 204);
            this.tbpAlerts.TabIndex = 1;
            this.tbpAlerts.Text = "Alerts (0)";
            this.tbpAlerts.UseVisualStyleBackColor = true;
            // 
            // tbpScripts
            // 
            this.tbpScripts.BackColor = System.Drawing.Color.Transparent;
            this.tbpScripts.Location = new System.Drawing.Point(4, 4);
            this.tbpScripts.Name = "tbpScripts";
            this.tbpScripts.Padding = new System.Windows.Forms.Padding(3);
            this.tbpScripts.Size = new System.Drawing.Size(967, 187);
            this.tbpScripts.TabIndex = 2;
            this.tbpScripts.Text = "Active Scripts";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lvwLibrary);
            this.panel1.Controls.Add(this.toolStrip2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 288);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(226, 286);
            this.panel1.TabIndex = 1;
            // 
            // spltNetworks
            // 
            this.spltNetworks.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.spltNetworks.Location = new System.Drawing.Point(0, 281);
            this.spltNetworks.Name = "spltNetworks";
            this.spltNetworks.Size = new System.Drawing.Size(226, 7);
            this.spltNetworks.TabIndex = 2;
            this.spltNetworks.TabStop = false;
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.cmbLibraryTypes});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(226, 25);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.toolStripLabel1.Size = new System.Drawing.Size(53, 22);
            this.toolStripLabel1.Text = "Library";
            // 
            // cmbLibraryTypes
            // 
            this.cmbLibraryTypes.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cmbLibraryTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLibraryTypes.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.cmbLibraryTypes.Items.AddRange(new object[] {
            "CmdLets",
            "Functions"});
            this.cmbLibraryTypes.Name = "cmbLibraryTypes";
            this.cmbLibraryTypes.Size = new System.Drawing.Size(121, 25);
            // 
            // lvwLibrary
            // 
            this.lvwLibrary.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chLibName,
            this.chLibModule});
            this.lvwLibrary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwLibrary.Location = new System.Drawing.Point(0, 25);
            this.lvwLibrary.Name = "lvwLibrary";
            this.lvwLibrary.Size = new System.Drawing.Size(226, 261);
            this.lvwLibrary.TabIndex = 2;
            this.lvwLibrary.UseCompatibleStateImageBehavior = false;
            this.lvwLibrary.View = System.Windows.Forms.View.Details;
            // 
            // chLibName
            // 
            this.chLibName.Text = "Name";
            this.chLibName.Width = 102;
            // 
            // chLibModule
            // 
            this.chLibModule.Text = "Module";
            this.chLibModule.Width = 100;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(226, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tvwNetworks
            // 
            this.tvwNetworks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tvwNetworks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwNetworks.FullRowSelect = true;
            this.tvwNetworks.HideSelection = false;
            this.tvwNetworks.ImageIndex = 0;
            this.tvwNetworks.ImageList = this.imgList16;
            this.tvwNetworks.Location = new System.Drawing.Point(0, 25);
            this.tvwNetworks.Name = "tvwNetworks";
            treeNode1.ImageKey = "Diagram.png";
            treeNode1.Name = "ndNone";
            treeNode1.SelectedImageKey = "Diagram.png";
            treeNode1.Tag = "1";
            treeNode1.Text = "Local Network";
            treeNode2.Name = "ndNetwork";
            treeNode2.Text = "Networks";
            this.tvwNetworks.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.tvwNetworks.SelectedImageIndex = 1;
            this.tvwNetworks.ShowPlusMinus = false;
            this.tvwNetworks.ShowRootLines = false;
            this.tvwNetworks.Size = new System.Drawing.Size(226, 256);
            this.tvwNetworks.TabIndex = 5;
            // 
            // toolStrip3
            // 
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton3});
            this.toolStrip3.Location = new System.Drawing.Point(3, 3);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(961, 25);
            this.toolStrip3.TabIndex = 0;
            this.toolStrip3.Text = "toolStrip3";
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
            this.lvwAlerts.Location = new System.Drawing.Point(3, 28);
            this.lvwAlerts.Name = "lvwAlerts";
            this.lvwAlerts.Size = new System.Drawing.Size(961, 173);
            this.lvwAlerts.TabIndex = 1;
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
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // tbpPowerShell
            // 
            this.tbpPowerShell.Controls.Add(this.txtPShellOutput);
            this.tbpPowerShell.Location = new System.Drawing.Point(4, 22);
            this.tbpPowerShell.Name = "tbpPowerShell";
            this.tbpPowerShell.Padding = new System.Windows.Forms.Padding(3);
            this.tbpPowerShell.Size = new System.Drawing.Size(967, 314);
            this.tbpPowerShell.TabIndex = 1;
            this.tbpPowerShell.Text = "PowerShell";
            this.tbpPowerShell.UseVisualStyleBackColor = true;
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
            this.txtPShellOutput.Size = new System.Drawing.Size(961, 308);
            this.txtPShellOutput.TabIndex = 3;
            // 
            // tbpSystems
            // 
            this.tbpSystems.Controls.Add(this.lvwSystems);
            this.tbpSystems.Location = new System.Drawing.Point(4, 22);
            this.tbpSystems.Name = "tbpSystems";
            this.tbpSystems.Padding = new System.Windows.Forms.Padding(3);
            this.tbpSystems.Size = new System.Drawing.Size(967, 314);
            this.tbpSystems.TabIndex = 0;
            this.tbpSystems.Text = "Systems";
            this.tbpSystems.UseVisualStyleBackColor = true;
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
            this.lvwSystems.Location = new System.Drawing.Point(3, 3);
            this.lvwSystems.Name = "lvwSystems";
            this.lvwSystems.Size = new System.Drawing.Size(961, 308);
            this.lvwSystems.SmallImageList = this.imgList16;
            this.lvwSystems.TabIndex = 1;
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
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tbpSystems);
            this.tcMain.Controls.Add(this.tbpPowerShell);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Location = new System.Drawing.Point(0, 0);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(975, 340);
            this.tcMain.TabIndex = 0;
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
            this.Text = "PoshSec Framework";
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
            this.tbpAlerts.ResumeLayout(false);
            this.tbpAlerts.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.tbpPowerShell.ResumeLayout(false);
            this.tbpPowerShell.PerformLayout();
            this.tbpSystems.ResumeLayout(false);
            this.tcMain.ResumeLayout(false);
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
        private System.Windows.Forms.ImageList imgList16;
        private System.Windows.Forms.TabControl tcSystem;
        private System.Windows.Forms.TabPage tbpAlerts;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripStatusLabel lblsbSpacer;
        private System.Windows.Forms.ToolStripProgressBar pbStatus;
        private System.Windows.Forms.TabPage tbpScripts;
        private System.Windows.Forms.ContextMenuStrip cmnuHosts;
        private System.Windows.Forms.ToolStripMenuItem powerShellToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsUpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem waucheckps1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.Splitter spltNetworks;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lvwLibrary;
        private System.Windows.Forms.ColumnHeader chLibName;
        private System.Windows.Forms.ColumnHeader chLibModule;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cmbLibraryTypes;
        private System.Windows.Forms.TreeView tvwNetworks;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ListView lvwAlerts;
        private System.Windows.Forms.ColumnHeader chSeverity;
        private System.Windows.Forms.ColumnHeader chMessage;
        private System.Windows.Forms.ColumnHeader chScript;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tbpSystems;
        private System.Windows.Forms.ListView lvwSystems;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chIP;
        private System.Windows.Forms.ColumnHeader chMAC;
        private System.Windows.Forms.ColumnHeader chStatus;
        private System.Windows.Forms.ColumnHeader chClientInstalled;
        private System.Windows.Forms.ColumnHeader chAlerts;
        private System.Windows.Forms.ColumnHeader chLastScan;
        private System.Windows.Forms.TabPage tbpPowerShell;
        private System.Windows.Forms.TextBox txtPShellOutput;
    }
}

