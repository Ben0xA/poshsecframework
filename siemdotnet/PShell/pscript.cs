using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;

namespace siemdotnet.PShell
{
    class pscript
    {
        #region " Private Variables "
        private RunspaceConfiguration rspaceconfig;
        private Runspace rspace;
        private String scriptcontents;
        private StringBuilder rslts = new StringBuilder();
        #endregion

        #region " Public Events "
        public EventHandler<pseventargs> ScriptCompleted;
        #endregion

        #region " Public Methods "
        public void Test()
        {
            OnScriptComplete(new pseventargs("It worked!"));
        }

        public void RunScript()
        {            
            try
            {
                rspaceconfig = RunspaceConfiguration.Create();
                rspace = RunspaceFactory.CreateRunspace(rspaceconfig);
                rspace.Open();

                RunspaceInvoke rsinvoke = new RunspaceInvoke(rspace);                
                Pipeline pline = rspace.CreatePipeline();

                Command pscmd = new Command("C:\\pstest\\waucheck.ps1");

                // Handle Params Here
                CommandParameter kbs = new CommandParameter("kbs", "2862772");
                CommandParameter comp = new CommandParameter("computer", "APT0xA");
                pscmd.Parameters.Add(kbs);
                pscmd.Parameters.Add(comp);

                pline.Commands.Add(pscmd);
                //pline.Commands.Add("Out-String");
                
                Collection<PSObject> rslt = pline.Invoke();
                rspace.Close();

                if (rslt != null)
                {
                    foreach (PSObject po in rslt)
                    {
                        rslts.AppendLine(po.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                rslts.AppendLine("Script Failed to Run!\nError: " + e.Message);
            }
            OnScriptComplete(new pseventargs(rslts.ToString()));
        }
        #endregion

        #region " Private Methods "
        private void OnScriptComplete(pseventargs e)
        {
            EventHandler<pseventargs> handler = ScriptCompleted;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion

        #region " Public Properties "
        public String ScriptContents
        {
            set
            {
                this.scriptcontents = value;
            }
        }

        public String Results
        {
            get 
            {
                return this.rslts.ToString();
            }
        }
        #endregion
    }
}
