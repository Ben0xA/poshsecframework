using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
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
        #endregion

        #region Load
        public frmMain()
        {
            InitializeComponent();
            scnr.ParentForm = this;
            GetNetworks();
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
                txtPShellOutput.Text = output;
                txtPShellOutput.SelectionStart = txtPShellOutput.Text.Length;
                tcSystem.SelectedTab = tbPowerShell;
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

        #endregion        

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            PShell.pshell p = new PShell.pshell();
            p.UIForm = this;
            p.RunScript("waucheck");
        }

    }
}