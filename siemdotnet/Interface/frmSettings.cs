using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace poshsecframework.Interface
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
            cmbScriptDefAction.SelectedIndex = 0;
            LoadSettings();
        }

        private void LoadSettings()
        {
            txtScriptDirectory.Text = Properties.Settings.Default["ScriptPath"].ToString();
            txtFrameworkDirectory.Text = Properties.Settings.Default["FrameworkPath"].ToString();
            txtModuleDirectory.Text = Properties.Settings.Default["ModulePath"].ToString();
            cmbScriptDefAction.SelectedIndex = (int)Properties.Settings.Default["ScriptDefaultAction"];
        }
    }
}
