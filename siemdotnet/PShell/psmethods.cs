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
            private System.Windows.Forms.ListView lvw = null;

            public PSAlert(String ScriptName, ref System.Windows.Forms.ListView Parent)
            {
                scriptname = ScriptName;
                lvw = Parent;
            }

            public void Add(String message, String severity)
            {
                ListViewItem lvwitm = new ListViewItem();
                lvwitm.Text = severity;
                lvwitm.SubItems.Add(message);
                lvwitm.SubItems.Add(scriptname);
                lvw.Items.Add(lvwitm);
            }
        }
    }
}
