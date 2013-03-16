using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;

namespace siemdotnetclient.Network
{
    class netstat
    {
        #region Private Variables
        
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

        public String GetConnections()
        {
            String rtn = "";
            ProcessStartInfo psinfo = new ProcessStartInfo();
            psinfo.CreateNoWindow = true;
            psinfo.RedirectStandardError = true;
            psinfo.RedirectStandardOutput = true;
            psinfo.UseShellExecute = false;
            psinfo.FileName = "netstat.exe";
            psinfo.Arguments = "-aon";

            Process prc = Process.Start(psinfo);
            rtn = prc.StandardOutput.ReadToEnd();
            prc.WaitForExit();
            return rtn;
        }
        #endregion
    }
}
