using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace siemdotnet.PShell
{
    class pseventargs : EventArgs
    {
        #region " Private Variables "
        private String rslts;
        private ListViewItem lvw;
        #endregion

        #region " Public Methods "
        public pseventargs(String ResultsText, ListViewItem ScriptListView)
        {
            rslts = ResultsText;
            lvw = ScriptListView;
        }
        #endregion

        #region " Public Properties "
        public String Results
        {
            get
            {
                return rslts;
            }
        }

        public ListViewItem ScriptListView
        {
            get { return lvw; }
        }
        #endregion
    }
}
