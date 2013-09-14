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
using System.Management.Automation.Runspaces;
using System.Net;
using System.Text;
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
        public void DisplayOutput(String output)
        {
            if (this.InvokeRequired)
            {
                MethodInvoker del = delegate
                {
                    DisplayOutput(output);
                };
                this.Invoke(del);
            }
            else
            {
                txtPShellOutput.Text += output;
                txtPShellOutput.Text += Environment.NewLine + "psf > ";
                txtPShellOutput.SelectionStart = txtPShellOutput.Text.Length;
                txtPShellOutput.ScrollToCaret();
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
                ListViewItem lvwitm = new ListViewItem();
                lvwitm.Text = alerttype.ToString();
                lvwitm.ImageIndex = (int)alerttype;
                lvwitm.SubItems.Add(message);
                lvwitm.SubItems.Add(scriptname);
                lvwAlerts.Items.Add(lvwitm);
                lvwAlerts_Update();
            }
        }

        private void GetLibrary()
        {
            Runspace rspace = RunspaceFactory.CreateRunspace();
            Pipeline pline = rspace.CreatePipeline();
            rspace.Open();

            pline.Commands.AddScript("Import-Module C:\\pstest\\Modules\\PoshSecFramework\\PoshSecFramework.psm1" + Environment.NewLine + "Get-Command");
            Collection<PSObject> rslt = pline.Invoke();
            rspace.Close();
            if (rslt != null)
            {
                lvwLibrary.Items.Clear();
                lvwLibrary.BeginUpdate();
                foreach (PSObject po in rslt)
                {
                    ListViewItem lvw = null;
                    switch(po.BaseObject.GetType().Name)
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
                        lvwLibrary.Items.Add(lvw);
                    }
                    else
                    {
                        lvw = null;
                    }
                }
                lvwLibrary.EndUpdate();
            }
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

        #region " List View "
        private void lvwAlerts_Update()
        {
            tbpAlerts.Text = "Alerts (" + lvwAlerts.Items.Count.ToString() + ")";
        }
        #endregion

        #endregion

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            PShell.pshell p = new PShell.pshell();
            p.ParentForm = this;
            p.RunScript("psftest");
        }

        private void btnLibraryRefresh_Click(object sender, EventArgs e)
        {
            GetLibrary();
        }

        private void btnShowAliases_Click(object sender, EventArgs e)
        {
            btnShowAliases.Checked = !btnShowAliases.Checked;
            GetLibrary();
        }

        private void btnShowFunctions_Click(object sender, EventArgs e)
        {
            btnShowFunctions.Checked = !btnShowFunctions.Checked;
            GetLibrary();
        }

        private void btnShowCmdlets_Click(object sender, EventArgs e)
        {
            btnShowCmdlets.Checked = !btnShowCmdlets.Checked;
            GetLibrary();
        }

        private void cmbLibraryTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetLibrary();
        }

        private void btnClearAlerts_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear all of the alerts?", "Confirm", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                lvwAlerts.Items.Clear();
                lvwAlerts_Update();
            }
        }


    }
}