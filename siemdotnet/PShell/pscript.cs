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
        private String scriptpath;
        private List<psparameter> scriptparams;
        private StringBuilder rslts = new StringBuilder();
        private psexception psexec = new psexception();
        private bool cancel = false;
        private frmMain frm = null;
        #endregion

        #region " Public Events "
        public EventHandler<pseventargs> ScriptCompleted;
        #endregion

        #region " Private Methods "
        private void InitializeScript()
        {
            rspaceconfig = RunspaceConfiguration.Create();
            rspace = RunspaceFactory.CreateRunspace(rspaceconfig);
            rspace.Open();
            rspace.SessionStateProxy.PSVariable.Set(new psvariables.PSRoot("PSRoot"));
            rspace.SessionStateProxy.PSVariable.Set(new psvariables.PSModRoot("PSModRoot"));
            rspace.SessionStateProxy.PSVariable.Set(new psvariables.PSFramework("PSFramework"));
            rspace.SessionStateProxy.SetVariable("PSMessageBox", new psmethods.PSMessageBox());
            rspace.SessionStateProxy.SetVariable("PSAlert", new psmethods.PSAlert(scriptpath, frm));
        }
        #endregion

        #region " Public Methods "
        public void Test()
        {
            OnScriptComplete(new pseventargs("It worked!"));
        }


        public Collection<PSObject> GetCommand()
        {
            InitializeScript();
            Pipeline pline = rspace.CreatePipeline();
            pline.Commands.AddScript("Import-Module C:\\pstest\\Modules\\PoshSecFramework\\PoshSecFramework.psm1" + Environment.NewLine + "Get-Command");
            Collection<PSObject> rslt = pline.Invoke();
            rspace.Close();
            return rslt;
        }

        public void RunScript()
        {
            try
            {
                rslts.AppendLine("Running script: " + scriptpath);
                InitializeScript();
                scriptparams = CheckForParams(rspace, scriptpath);
                if (!cancel)
                {
                    Command pscmd = new Command(scriptpath);
                    if (scriptparams != null)
                    {
                        foreach (psparameter param in scriptparams)
                        {
                            CommandParameter prm = new CommandParameter(param.Name, param.Value ?? param.DefaultValue);
                            pscmd.Parameters.Add(prm);
                        }
                    }

                    Pipeline pline = rspace.CreatePipeline();
                    pline.Commands.Add(pscmd);
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
                else
                {
                    rslts.AppendLine("Script cancelled by user.");
                }
            }
            catch (Exception e)
            {
                rslts.AppendLine(psexec.psexceptionhandler(e));
            }
            OnScriptComplete(new pseventargs(rslts.ToString()));
        }
        #endregion

        #region " Private Methods "
        private List<psparameter>CheckForParams(Runspace rspace, String scriptpath)
        {
            List<psparameter> parms = null;
            psparamtype parm = new psparamtype();

            Pipeline pline = rspace.CreatePipeline();

            pline.Commands.AddScript("Get-Help " + scriptpath + " -full");
            pline.Commands.Add("Out-String");

            Collection<PSObject> rslt = pline.Invoke();
            if (rslt != null)
            {
                if (rslt[0].ToString().Contains("PARAMETERS"))
                {
                    String[] lines = rslt[0].ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                    if (lines != null)
                    {
                        int idx = 0;
                        bool found = false;
                        do
                        {
                            String line = lines[idx];
                            if(line == "PARAMETERS")
                            {
                                found = true;
                            }
                            idx++;
                        }while( found == false && idx < lines.Length);

                        if (found)
                        {
                            String line = "";
                            do
                            {
                                line = lines[idx];
                                if (line.Trim() != "" && line.Trim().Substring(0, 1) == "-")
                                {
                                    psparameter prm = new psparameter();
                                    String param = line.Trim().Substring(1, line.Trim().Length - 1);
                                    String[] paramparts = param.Split(' ');
                                    prm.Name = paramparts[0].Trim();
                                    prm.Type = GetTypeFromString(paramparts[1]);
                                    idx++;
                                    line = lines[idx];
                                    prm.Description = line.Trim();
                                    idx += 2;
                                    line = lines[idx];
                                    if (line.Contains("true"))
                                    { 
                                        prm.Category = "Required";
                                    }
                                    else
                                    {
                                        prm.Category = "Optional";
                                    }
                                    idx += 2;
                                    line = lines[idx];
                                    String defval = line.Replace("Default value", "").Trim();
                                    if (defval != "")
                                    {
                                        if (defval.ToLower() == "true" || defval.ToLower() == "false")
                                        {
                                            prm.DefaultValue = bool.Parse(defval);
                                        }
                                        else 
                                        {
                                            prm.DefaultValue = defval;
                                        }                                        
                                    }
                                    parm.Properties.Add(prm);
                                }
                                idx++;
                            }while(line.Substring(0,1) == " " && idx < lines.Length);
                        }
                    }
                }
            }
            pline.Commands.Clear();
            pline.Dispose();

            if (parm.Properties.Count > 0)
            {
                Interface.frmParams frm = new Interface.frmParams();
                frm.SetParameters(parm);
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    parms = parm.Properties;
                }
                else
                {
                    cancel = true;
                }
            }            
            return parms;
        }

        private Type GetTypeFromString(String typename)
        {
            Type rtn = null;
            switch (typename)
            { 
                case "<String>":
                    rtn = typeof(string);
                    break;
                case "<Boolean>":
                    rtn = typeof(Boolean);
                    break;
                default:
                    rtn = typeof(Object);
                    break;
            }
            return rtn;
        }

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
        public String ScriptPath
        {
            set { this.scriptpath = value;  }
        }

        public List<psparameter> Parameters
        {
            set { this.scriptparams = value; }
        }

        public String Results
        {
            get { return this.rslts.ToString(); }
        }

        public frmMain ParentForm
        {
            set { frm = value; }
        }
        #endregion
    }
}
