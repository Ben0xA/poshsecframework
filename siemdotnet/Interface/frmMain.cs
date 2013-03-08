using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using siemdotnet.Interface;

namespace siemdotnet
{
    public partial class frmMain : Form
    {
        #region Private Variables 
        Network.NetworkBrowser scnr = new Network.NetworkBrowser();
        #endregion

        #region Load
        public frmMain()
        {
            InitializeComponent();
            GetNetworks();
        }
        #endregion

        #region Private Methods

        //Network Methods
        #region Network
        private void GetNetworks()
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

                TreeNode rootnode = tvwNetworks.Nodes[0];
                rootnode.Nodes.Add(node);
            }
            tvwNetworks.Nodes[0].Expand();
        }

        private void Scan()
        {
            lvwSystems.Items.Clear();
            if (tvwNetworks.SelectedNode != null && tvwNetworks.SelectedNode.Index != 0)
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
            else
            {
                MessageBox.Show("Please select a network first.");
            }
        }

        private void ScanbyIP()
        {
            lvwSystems.Items.Clear();            
            ArrayList rslts = scnr.ScanbyIP();
            if (rslts.Count > 0)
            {
                frmScanProgress frm = new frmScanProgress();
                frm.TopMost = true;
                frm.Show();
                foreach (String system in rslts)
                {
                    ListViewItem lvwItm = new ListViewItem();
                    
                    frm.SetStatus("Adding " + system + ", please wait...");
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
                    Application.DoEvents();
                }
                frm.Close();
                frm = null;
            }

            rslts = null;
        }
        #endregion

        #endregion                

        //Private Events
        #region Private Events

        #region Menu Clicks
        private void mnuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void scanActiveDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Scan();
        }

        private void scanByIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScanbyIP();
        }
        #endregion 

        #endregion        

    }
}