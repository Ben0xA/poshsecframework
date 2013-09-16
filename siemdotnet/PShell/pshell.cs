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
        
        public void RunScript(string ScriptName)
        {
            String spath = Path.Combine(pspath, ScriptName);
            if(File.Exists(spath))
            {
                try
                {
                    ListViewItem lvw = new ListViewItem();
                    lvw.Text = ScriptName;
                    lvw.SubItems.Add("Running...");
                    lvw.ImageIndex = 4;

                    ps.ParentForm = frm;
                    ps.ScriptPath = spath;
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
            frm.DisplayOutput(rslts.Results, rslts.ScriptListView);
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
