using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Management.Automation;
using System.Net;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace siemdotnet
{
    public partial class frmMain : Form
    {

        #region Private Variables 
        Network.NetworkBrowser scnr = new Network.NetworkBrowser();

        enum SystemType
        { 
            Local = 1,
            Domain
        }

        enum LibraryImages
        { 
            Function,
            Cmdlet,
            Command,
            Alias
        }
        #endregion

        #region Load
        public frmMain()
        {
            InitializeComponent();
            scnr.ParentForm = this;
            cmbLibraryTypes.SelectedIndex = 1;
            GetNetworks();
            GetLibrary();
            GetCommand();
        }
        #endregion

        #region Private Methods

        #region Network
        private void GetNetworks()
        {
            try
            {
                //Get Domain Name
                Forest hostForest = Forest.GetCurrentForest();
                DomainCollection domains = hostForest.Domains;

                foreach (Domain domain in domains)
                {
                    TreeNode node = new TreeNode();
                    node.Text = domain.Name;
                    node.SelectedImageIndex = 3;
                    node.ImageIndex = 3;
                    node.Tag = SystemType.Domain;
                    TreeNode rootnode = tvwNetworks.Nodes[0];
                    rootnode.Nodes.Add(node);
                }
            }
            catch
            {
                //fail silently because it's not on A/D   
            }

            try
            {
                //Add Local IP/Host to Local Network
                String localHost = Dns.GetHostName();
                String localIP = scnr.GetIP(localHost);

                ListViewItem lvwItm = new ListViewItem();

                lvwItm.Text = localHost;
                lvwItm.SubItems.Add(localIP);
                lvwItm.SubItems.Add("00-00-00-00-00-00");
                lvwItm.SubItems.Add("Up");
                lvwItm.SubItems.Add("Not Installed");
                lvwItm.SubItems.Add("0");
                lvwItm.SubItems.Add(DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));

                lvwItm.ImageIndex = 2;
                lvwSystems.Items.Add(lvwItm);
                lvwSystems.Refresh();

                tvwNetworks.Nodes[0].Expand();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "\n" + e.StackTrace);
            }
        }

        private void Scan()
        {
            lvwSystems.Items.Clear();
            if (tvwNetworks.SelectedNode != null && tvwNetworks.SelectedNode.Tag != null)
            {
                SystemType typ = (SystemType)Enum.Parse(typeof(SystemType), tvwNetworks.SelectedNode.Tag.ToString());
                switch (typ)
                {
                    case SystemType.Local:
                        ScanbyIP();
                        break;
                    case SystemType.Domain:
                        ScanAD();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Please select a network first.");
            }
        }

        private void ScanAD()
        {
            String domain = tvwNetworks.SelectedNode.Text;
            ArrayList rslts = scnr.ScanActiveDirectory(domain);
            if (rslts.Count > 0)
            {
                foreach (DirectoryEntry system in rslts)
                {
                    ListViewItem lvwItm = new ListViewItem();
                    lvwItm.Text = system.Name.ToString();

                    String ipadr = scnr.GetIP(system.Name);
                    lvwItm.SubItems.Add(ipadr);
                    lvwItm.SubItems.Add("00-00-00-00-00-00");
                    bool isup = false;
                    if (ipadr != "0.0.0.0 (unknown host)")
                    {
                        isup = scnr.Ping(system.Name, 1, 500);
                    }
                    if (isup)
                    {
                        lvwItm.SubItems.Add("Up");
                    }
                    else
                    {
                        lvwItm.SubItems.Add("Down");
                    }
                    lvwItm.SubItems.Add("Not Installed");
                    lvwItm.SubItems.Add("0");
                    lvwItm.SubItems.Add(DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));

                    lvwItm.ImageIndex = 2;
                    lvwSystems.Items.Add(lvwItm);
                    lvwSystems.Refresh();
                    Application.DoEvents();
                }
            }

            rslts = null;
        }

        private void ScanbyIP()
        {
            lvwSystems.Items.Clear();            
            ArrayList rslts = scnr.ScanbyIP();
            if (rslts.Count > 0)
            {
                SetProgress(0, rslts.Count);
                foreach (String system in rslts)
                {
                    ListViewItem lvwItm = new ListViewItem();
                    
                    SetStatus("Adding " + system + ", please wait...");
                    
                    lvwItm.Text = scnr.GetHostname(system);
                    lvwItm.SubItems.Add(system);
                    lvwItm.SubItems.Add("00-00-00-00-00-00");
                    lvwItm.SubItems.Add("Up");
                    lvwItm.SubItems.Add("Not Installed");
                    lvwItm.SubItems.Add("0");
                    lvwItm.SubItems.Add(DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));

                    lvwItm.ImageIndex = 2;
                    lvwSystems.Items.Add(lvwItm);
                    lvwSystems.Refresh();

                    pbStatus.Value += 1;
                    Application.DoEvents();
                }
            }

            rslts = null;
            HideProgress();
            lblStatus.Text = "Ready";
        }
        #endregion

        #region Status
        public void SetStatus(String message)
        {
            lblStatus.Text = message;
            Application.DoEvents();
        }
        #endregion

        #region ProgressBar
        public void SetProgress(int Value, int Maximum)
        {
            pbStatus.Visible = true;
            if (pbStatus.Maximum != Maximum)
            {
                pbStatus.Maximum = Maximum;
            }
            if (Value <= Maximum)
            {
                pbStatus.Value = Value;            
            }
        }

        public void HideProgress()
        {
            pbStatus.Visible = false;
        }
        #endregion

        #region "PowerShell"
        public void DisplayOutput(String output, ListViewItem lvw)
        {
            if (this.InvokeRequired)
            {
                MethodInvoker del = delegate
                {
                    DisplayOutput(output, lvw);
                };
                this.Invoke(del);
            }
            else
            {
                txtPShellOutput.Text += output;
                txtPShellOutput.Text += Environment.NewLine + "psf > ";
                txtPShellOutput.SelectionStart = txtPShellOutput.Text.Length;
                txtPShellOutput.ScrollToCaret();
                if (lvw != null)
                {
                    lvw.Remove();
                }                
            }
            
        }

        public void AddAlert(String message, PShell.psmethods.PSAlert.AlertType alerttype, String scriptname)
        {
            if (this.InvokeRequired)
            {
                MethodInvoker del = delegate
                {
                    AddAlert(message, alerttype, scriptname);
                };
                this.Invoke(del);
            }
            else 
            {
                try
                {
                    ListViewItem lvwitm = new ListViewItem();
                    lvwitm.Text = alerttype.ToString();
                    lvwitm.ImageIndex = (int)alerttype;
                    lvwitm.SubItems.Add(message);
                    lvwitm.SubItems.Add(scriptname);
                    lvwAlerts.Items.Add(lvwitm);
                    lvwAlerts_Update();
                }
                catch (Exception e)
                {
                    DisplayError(e);
                }                
            }
        }

        public void AddActiveScript(ListViewItem lvw)
        {
            if (this.InvokeRequired)
            {
                MethodInvoker del = delegate
                {
                    AddActiveScript(lvw);
                };
                this.Invoke(del);
            }
            else
            {
                lvwActiveScripts.Items.Add(lvw);
            }
        }

        private void GetCommand()
        {
            try
            {
                PShell.pscript ps = new PShell.pscript();
                Collection<PSObject> rslt = ps.GetCommand();
                ps = null;
                if (rslt != null)
                {
                    lvwCommands.Items.Clear();
                    lvwCommands.BeginUpdate();
                    foreach (PSObject po in rslt)
                    {
                        ListViewItem lvw = null;
                        switch (po.BaseObject.GetType().Name)
                        {
                            case "AliasInfo":
                                AliasInfo ai = (AliasInfo)po.BaseObject;
                                if (btnShowAliases.Checked)
                                {
                                    lvw = new ListViewItem();
                                    lvw.Text = ai.Name;
                                    lvw.ToolTipText = ai.Name;
                                    lvw.SubItems.Add(ai.ModuleName);
                                    lvw.ImageIndex = (int)LibraryImages.Alias;
                                }
                                break;
                            case "FunctionInfo":
                                FunctionInfo fi = (FunctionInfo)po.BaseObject;
                                if (btnShowFunctions.Checked)
                                {
                                    lvw = new ListViewItem();
                                    lvw.Text = fi.Name;
                                    lvw.ToolTipText = fi.Name;
                                    lvw.SubItems.Add(fi.ModuleName);
                                    lvw.ImageIndex = (int)LibraryImages.Function;
                                }
                                break;
                            case "CmdletInfo":
                                CmdletInfo cmi = (CmdletInfo)po.BaseObject;
                                if (btnShowCmdlets.Checked)
                                {
                                    lvw = new ListViewItem();
                                    lvw.Text = cmi.Name;
                                    lvw.ToolTipText = cmi.Name;
                                    lvw.SubItems.Add(cmi.ModuleName);
                                    lvw.ImageIndex = (int)LibraryImages.Cmdlet;
                                }
                                break;
                            default:
                                Console.WriteLine(po.BaseObject.GetType().Name);
                                break;
                        }
                        if (lvw != null && (cmbLibraryTypes.Text == "All" || cmbLibraryTypes.Text == lvw.SubItems[1].Text))
                        {
                            lvwCommands.Items.Add(lvw);
                        }
                        else
                        {
                            lvw = null;
                        }
                    }
                    lvwCommands.EndUpdate();
                }
            }
            catch (Exception e)
            {
                DisplayError(e);
            }
        }

        private void GetLibrary()
        {
            try
            {
                String scriptroot = "C:\\pstest\\"; // Get this variable from Settings.
                String[] scpaths = Directory.GetFiles(scriptroot, "*.ps1", SearchOption.TopDirectoryOnly);
                if (scpaths != null)
                {
                    foreach (String scpath in scpaths)
                    { 
                        ListViewItem lvw = new ListViewItem();
                        lvw.Text = new FileInfo(scpath).Name;
                        lvw.ImageIndex = 4;
                        lvw.Tag = scpath;
                        lvwScripts.Items.Add(lvw);
                    }
                }
            }
            catch (Exception e)
            {
                DisplayError(e);
            }
        }
        #endregion

        #region " Display Error "
        private void DisplayError(Exception e)
        {
            DisplayOutput(Environment.NewLine + "Unhandled exception." + Environment.NewLine + e.Message + Environment.NewLine + "Stack Trace:" + Environment.NewLine + e.StackTrace, null);
            tcMain.SelectedTab = tbpPowerShell;
        }
        #endregion

        #endregion

        #region Private Events

        #region Menu Clicks
        private void mnuExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void mnuScan_Click(object sender, EventArgs e)
        {
            Scan();
        }
        #endregion 

        #region List View
        private void lvwAlerts_Update()
        {
            tbpAlerts.Text = "Alerts (" + lvwAlerts.Items.Count.ToString() + ")";
        }

        private void lvwScripts_DoubleClick(object sender, EventArgs e)
        {
            if (lvwScripts.SelectedItems.Count > 0)
            {
                ListViewItem lvw = lvwScripts.SelectedItems[0];
                PShell.pshell p = new PShell.pshell();
                p.ParentForm = this;
                p.RunScript(lvw.Text);
                p = null;
            }
        }
        #endregion

        #region Button Clicks
        private void btnLibraryRefresh_Click(object sender, EventArgs e)
        {
            GetCommand();
        }

        private void btnShowAliases_Click(object sender, EventArgs e)
        {
            btnShowAliases.Checked = !btnShowAliases.Checked;
            GetCommand();
        }

        private void btnShowFunctions_Click(object sender, EventArgs e)
        {
            btnShowFunctions.Checked = !btnShowFunctions.Checked;
            GetCommand();
        }

        private void btnShowCmdlets_Click(object sender, EventArgs e)
        {
            btnShowCmdlets.Checked = !btnShowCmdlets.Checked;
            GetCommand();
        }

        private void cmnuActiveScripts_Opening(object sender, CancelEventArgs e)
        {
            if (lvwActiveScripts.SelectedItems.Count == 0)
            {
                e.Cancel = true;
            }
        }

        private void cmbtnCancelScript_Click(object sender, EventArgs e)
        {
            if (lvwActiveScripts.SelectedItems.Count > 0)
            {
                ListViewItem lvw = lvwActiveScripts.SelectedItems[0];
                Thread thd = (Thread)lvw.Tag;
                thd.Abort();
                lvw.SubItems[1].Text = "Aborting... ThreadState = " + thd.ThreadState.ToString();
            }
            else
            {
                MessageBox.Show("Please select an active script.");
            }
        }

        private void btnClearAlerts_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear all of the alerts?", "Confirm", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                lvwAlerts.Items.Clear();
                lvwAlerts_Update();
            }
        }
        #endregion

        #region ComboBox Events
        private void cmbLibraryTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCommand();
        }
        #endregion
        
        #endregion
        
    }
}