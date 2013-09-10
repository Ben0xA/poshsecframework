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
        #endregion

        #region " Public Methods "
        public pshell()
        { 
           //Initialize rspaceconfig here if needed. 
            pspath = "C:\\pstest\\";
        }

        public void Test()
        {
            pscript ps = new pscript();
            ps.ScriptCompleted += new EventHandler<pseventargs>(ScriptCompleted);
            Thread thd = new Thread(ps.Test);
            thd.Start();
        }
        
        public void RunScript(string ScriptName)
        {
            String spath = Path.Combine(pspath, ScriptName + ".ps1");
            StringBuilder rslts = new StringBuilder();
            if(File.Exists(spath))
            {
                StreamReader script = File.OpenText(spath);
                String stext = script.ReadToEnd();
                script.Close();
                stext = stext.Trim();
                if(stext != "")
                {
                    pscript ps = new pscript();
                    ps.ScriptContents = stext;
                    ps.ScriptCompleted += new EventHandler<pseventargs>(ScriptCompleted);
                    Thread thd = new Thread(ps.RunScript);
                    thd.Start();
                }
            }
        }
        #endregion

        #region " Private Methods "
        private void ScriptCompleted(object sender, EventArgs e)
        {
            pseventargs rslts = (pseventargs)e;
            Console.WriteLine(rslts.Results);
            frm.DisplayOutput(rslts.Results);
        }
        #endregion

        #region " Public Properties "
        public frmMain UIForm
        {
            set
            {
                frm = value; 
            }
        }
        #endregion
    }
}
