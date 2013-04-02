using System;
using System.Collections.Generic;
using System.Text;

namespace siemdotnetclient.Structures
{
    public struct netstatline
    {
        public String protocol;
        public String lcladdr;
        public String lclport;
        public String rmtaddr;
        public String rmtport;
        public String state;
        public String pid;

        public void FromString(String value)
        {
            if (value.Length >= 71)
            {
                String adport = value.Substring(9, 23).Trim();
                
                // TODO: IPv6 support. Messes up the output with those long addresses.
                if (adport.Contains(":") && adport.Contains("."))
                {
                    protocol = value.Substring(0, 9).Trim();
                    String[] adp = adport.Split(':');
                    lcladdr = adp[0];
                    lclport = adp[1];
                    adport = value.Substring(32, 23).Trim();
                    if (adport.Contains(":") && adport.Contains("."))
                    {
                        adp = adport.Split(':');
                        rmtaddr = adp[0];
                        rmtport = adp[1];
                    }
                    state = value.Substring(55, 16).Trim();
                    pid = value.Substring(71, value.Length - 71).Trim();
                }                
            }
        }

        public override String ToString()
        {
            String rtn = "";
            rtn += protocol + ",";
            rtn += lcladdr + ",";
            rtn += lclport + ",";
            rtn += rmtaddr + ",";
            rtn += rmtport + ",";
            rtn += state + ",";
            rtn += pid;
            return rtn;
        }
    }
}

