using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace siemdotnet.PShell
{
    class psmethods
    {
        public class PSMessageBox
        {
            public void Show(String message, String title = "Script Message")
            {
                System.Windows.Forms.MessageBox.Show(message, title);
            }
        }

        public class PSAlert
        {
            private String scriptname = "";
            private frmMain frm = null;

            public PSAlert(String ScriptName, frmMain ParentForm)
            {
                scriptname = ScriptName;
                frm = ParentForm;
            }

            public void Add(String message, String severity)
            {
                frm.AddAlert(message, severity, scriptname);
            }
        }
    }
}
