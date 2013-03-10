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
using siemdotnetclient.Systems;

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
            txtOutput.Text = "Getting Application Logs, please wait...\n";
            txtOutput.Refresh();
            ListLogs("Application");
        }
    }
}
