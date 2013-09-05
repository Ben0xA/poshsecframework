using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace siemdotnet.PShell
{
    class pseventargs : EventArgs
    {
        #region " Private Variables "
        private String rslts;
        #endregion

        #region " Public Methods "
        public pseventargs(String ResultsText)
        {
            rslts = ResultsText;
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
        #endregion
    }
}
