using System;
using System.Collections;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Net;
using System.Text;
using System.Windows.Forms;
using siemdotnet.Structures;
using siemdotnet.Interface;

namespace siemdotnet.Network
{
    class NetworkBrowser
    {
        #region Initialize
        /// <summary>
        /// Creates an instance of the NetworkBrowser Class
        /// </summary>
        public NetworkBrowser()
        {
            //todo: Initialize
        }
        #endregion

        #region Public Methods

        #region Scan
        public ArrayList ScanActiveDirectory(String domain)
        {
            ArrayList systems = new ArrayList();
            DirectoryEntry hostPC = new DirectoryEntry();
            hostPC.Path = "WinNT://" + domain;

            foreach (DirectoryEntry netPC in hostPC.Children)
            {
                if (netPC.Name != "Schema" && netPC.SchemaClassName == "Computer")
                {
                    systems.Add(netPC);                    
                }
            }

            return systems;
        }

        public ArrayList ScanbyIP()
        {
            ArrayList systems = new ArrayList();
            frmScanProgress frm = new frmScanProgress();
            frm.TopMost = true;
            frm.Show();

            for (int ip = 1; ip < 256; ip++)
            {
                String host = "192.168.135." + ip.ToString();
                frm.SetStatus("Scanning " + host + ", please wait...");
                if (Ping(host, 1, 100))
                {
                    systems.Add(host);
                    Application.DoEvents();
                }
            }

            frm.Close();
            frm = null;

            return systems;
        }
        #endregion

        #endregion

        #region Public Functions

        #region Ping
        public bool Ping(string host, int attempts, int timeout)
        {
            bool rsp = false;
            System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingReply pingReply;

            for (int atmpt = 0; atmpt < attempts; atmpt++)
            {
                try
                {
                    pingReply = ping.Send(host, timeout);
                    if (pingReply != null && pingReply.Status == System.Net.NetworkInformation.IPStatus.Success)
                    {
                        rsp = true;
                    }
                }
                catch
                {
                    rsp = false;
                }                
            }
            return rsp;
        }
        #endregion

        #region GetIP
        public String GetIP(string host)
        {
            String ipadr = "";
            System.Net.IPHostEntry ipentry = null;
            try
            {
                ipentry = System.Net.Dns.GetHostEntry(host);
                System.Net.IPAddress[] addrs = ipentry.AddressList;
                foreach (System.Net.IPAddress addr in addrs)
                {
                    ipadr += addr.ToString();
                    Application.DoEvents();
                }
            }
            catch
            {
                ipadr = "0.0.0.0 (unknown host)";
            }
            return ipadr;
        }
        #endregion

        #region GetHostname
        public String GetHostname(String ip)
        {
            String host = "";
            System.Net.IPHostEntry ipentry = null;
            try
            {
                ipentry = System.Net.Dns.GetHostEntry(IPAddress.Parse(ip));
                host = ipentry.HostName;
            }
            catch
            {
                host = "N/A";
            }
            return host;
        }
        #endregion

        #endregion
    }
}
