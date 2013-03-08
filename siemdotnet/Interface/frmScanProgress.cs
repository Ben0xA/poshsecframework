using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace siemdotnet.Interface
{
    public partial class frmScanProgress : Form
    {
        public frmScanProgress()
        {
            InitializeComponent();
        }

        public void SetStatus(String message)
        {
            lblStatus.Text = message;
            Refresh();
            Application.DoEvents();
        }
    }
}