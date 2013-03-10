using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace siemdotnetclient.Network
{
    class netstat
    {
        #region Private Variables
        //[DllImport("iphlpapi.dll", SetLastError = true)]
        //static extern uint GetExtendedTcpTable(IntPtr pTcpTable, ref int dwOutBufLen, bool sort, int ipVersion, TcpTable tblClass, int reserved);

        enum ConnectionType
        {
            TcpConnections = 1,
            UdpConnections,
            Both
        }
        #endregion
    }
}
