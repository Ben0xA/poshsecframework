using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            txtScriptDirectory.Text = Properties.Settings.Default.ScriptPath;
            txtFrameworkDirectory.Text = Properties.Settings.Default.FrameworkPath;
            txtModuleDirectory.Text = Properties.Settings.Default.ModulePath;
            cmbScriptDefAction.SelectedIndex = Properties.Settings.Default.ScriptDefaultAction;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtScriptDirectory.Text) && File.Exists(txtFrameworkDirectory.Text) && Directory.Exists(txtModuleDirectory.Text))
            {
                Properties.Settings.Default["ScriptPath"] = txtScriptDirectory.Text;
                Properties.Settings.Default["FrameworkPath"] = txtFrameworkDirectory.Text;
                Properties.Settings.Default["ModulePath"] = txtModuleDirectory.Text;
                Properties.Settings.Default["ScriptDefaultAction"] = cmbScriptDefAction.SelectedIndex;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else if (!Directory.Exists(txtScriptDirectory.Text))
            {
                MessageBox.Show("The specified script directory does not exist. Please check the path.");
            }
            else if (!File.Exists(txtFrameworkDirectory.Text))
            {
                MessageBox.Show("The specified Framework file does not exist. Please check the path.");
            }
            else if (!Directory.Exists(txtModuleDirectory.Text))
            {
                MessageBox.Show("The specified module directory does not exist. Please check the path.");
            }
        }
    }
}
