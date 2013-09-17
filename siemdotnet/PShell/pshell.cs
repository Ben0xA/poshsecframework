using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace siemdotnet.PShell
{
    class pshell
    {
        #region " Private Variables "
        private String pspath;
        private frmMain frm;
        private pscript ps;
        private bool localecho;
        #endregion

        #region " Public Methods "
        public pshell()
        {
            pspath = "C:\\pstest\\";
            ps = new pscript();
        }

        public void Test()
        {
            ps.ScriptCompleted += new EventHandler<pseventargs>(ScriptCompleted);
            Thread thd = new Thread(ps.Test);
            thd.Start();
        }
        
        public void Run(string ScriptCommand, bool IsCommand = false, bool LocalEcho = true)
        {
            localecho = LocalEcho;
            String spath = "";
            if (!IsCommand)
            {
                spath = Path.Combine(pspath, ScriptCommand);
            } 
            if(IsCommand || File.Exists(spath))
            {
                try
                {
                    ListViewItem lvw = new ListViewItem();
                    lvw.Text = ScriptCommand;
                    lvw.SubItems.Add("Running...");
                    lvw.ImageIndex = 4;

                    ps.ParentForm = frm;
                    if (IsCommand)
                    {
                        ps.Script = ScriptCommand;
                    }
                    else
                    {
                        ps.Script = spath;
                    }
                    ps.IsCommand = IsCommand;
                    ps.LocalEcho = LocalEcho;
                    ps.ScriptListView = lvw;
                    ps.ScriptCompleted += new EventHandler<pseventargs>(ScriptCompleted);
                    
                    Thread thd = new Thread(ps.RunScript);
                    thd.SetApartmentState(ApartmentState.STA);
                    lvw.Tag = thd;

                    frm.AddActiveScript(lvw);
                    thd.Start();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Unhandled exception in script function." + Environment.NewLine + e.Message + Environment.NewLine + "Stack Trace:" + Environment.NewLine + e.StackTrace);
                }
                              
            }
        }
        #endregion

        #region " Private Methods "
        private void ScriptCompleted(object sender, EventArgs e)
        {
            pseventargs rslts = (pseventargs)e;
            frm.DisplayOutput(rslts.Results, rslts.ScriptListView, localecho);
        }
        #endregion

        #region " Public Properties "
        public frmMain ParentForm
        {
            set { frm = value; }
        }
        #endregion
    }
}
