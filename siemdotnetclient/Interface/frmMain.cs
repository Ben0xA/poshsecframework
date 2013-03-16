using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using siemdotnetclient.Structures;
using siemdotnetclient.Systems;
using siemdotnetclient.Network;

namespace siemdotnetclient.Interface
{
    public partial class frmMain : Form
    {

        #region Initialize
        public frmMain()
        {
            InitializeComponent();
        }
        #endregion

        #region Private Methods
        private void ListLogs(String LogName)
        {
            Events evt = new Events();
            List<EventLogEntry> msgs = evt.ApplicationLogs();
            if (msgs != null)
            {
                foreach(EventLogEntry msg in msgs)
                {
                    txtOutput.Text += "[" + msg.TimeWritten.ToString("MM/dd/yyyy hh:mm tt") + "]: " + msg.Message + "\n\n";
                    txtOutput.Refresh();
                }
                MessageBox.Show(msgs.Count + " entries listed.");
            }
        }
        #endregion

        private void btnList_Click(object sender, EventArgs e)
        {
            //ListLogs("Application");
            netstat ns = new netstat();
            String nsout = ns.GetConnections();
            String[] nslines = nsout.Split('\n');
            if (nslines != null)
            {
                foreach (String nsline in nslines)
                {
                    netstatline line = new netstatline();
                    line.fromstring(nsline);
                    if (line.protocol == "TCP" || line.protocol == "UDP")
                    {
                        txtOutput.Text += line.ToString() + "\n";                    
                    }
                }
            }
            ns = null;
        }
    }
}
