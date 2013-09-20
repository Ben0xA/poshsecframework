using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using siemdotnetclient.Structures;
using System.Text;

namespace siemdotnetclient.Network
{
    class netstat
    {
        #region Private Variables
        Exception lastError;
        #endregion
        
        #region Public Functions
        public String GetTcpConnections()
        {
            String rtn = "";
            IPGlobalProperties ipprop = IPGlobalProperties.GetIPGlobalProperties();
            TcpConnectionInformation[] tcpcons = ipprop.GetActiveTcpConnections();

            if (tcpcons != null)
            {
                foreach (TcpConnectionInformation tcpcon in tcpcons)
                {
                    rtn += tcpcon.LocalEndPoint.ToString() + " | " + tcpcon.RemoteEndPoint.ToString() + "\n";
                }
            }
            return rtn;
        }

        public List<netstatline> GetConnections()
        {
            String rtn = "";
            List<netstatline> nsrtn = new List<netstatline>();

            try
            {                
                ProcessStartInfo psinfo = new ProcessStartInfo();
                psinfo.CreateNoWindow = true;
                psinfo.RedirectStandardError = true;
                psinfo.RedirectStandardOutput = true;
                psinfo.UseShellExecute = false;
                psinfo.FileName = "netstat.exe";
                psinfo.Arguments = "-on";

                Process prc = Process.Start(psinfo);
                rtn = prc.StandardOutput.ReadToEnd();
                prc.WaitForExit();
            }
            catch (Exception e)
            {
                lastError = e;
                rtn = "";
            }

            if (rtn != "")
            {
                String[] nslines = rtn.Split('\n');
                if (nslines != null)
                {
                    foreach (String nsline in nslines)
                    {
                        netstatline line = new netstatline();
                        line.FromString(nsline);
                        if (line.protocol == "TCP" || line.protocol == "UDP")
                        {
                            nsrtn.Add(line);
                        }
                    }
                }
            }
            else
            {
                nsrtn = null;
            }            
            return nsrtn;
        }
        #endregion

        #region Public Properties
        public Exception LastError
        {
            get { return lastError; }
        }
        #endregion
    }
}
