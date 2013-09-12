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
        private ListView lvw;
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
            String spath = Path.Combine(pspath, ScriptName + ".ps1");
            if(File.Exists(spath))
            {
                ps.AlertListView = lvw;
                ps.ScriptPath = spath;
                ps.ScriptCompleted += new EventHandler<pseventargs>(ScriptCompleted);
                Thread thd = new Thread(ps.RunScript);
                thd.SetApartmentState(ApartmentState.STA);
                thd.Start();               
            }
        }
        #endregion

        #region " Private Methods "
        private void ScriptCompleted(object sender, EventArgs e)
        {
            pseventargs rslts = (pseventargs)e;
            frm.DisplayOutput(rslts.Results);
        }
        #endregion

        #region " Public Properties "
        public frmMain ParentForm
        {
            set { frm = value; }
        }

        public ListView AlertListView
        {
            set { lvw = value; }
        }
        #endregion
    }
}
