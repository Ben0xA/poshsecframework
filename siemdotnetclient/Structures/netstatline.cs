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

        public void fromstring(String value)
        {
            if (value.Length >= 71)
            {
                protocol = value.Substring(0, 9).Trim();
                String adport = value.Substring(9, 23).Trim();
                
                if (adport.Contains(":") && adport.Contains("."))
                {
                    String[] adp = adport.Split(':');
                    lcladdr = adp[0];
                    lclport = adp[1];
                }
                else
                { 
                    //IPv6
                    int ip6end = value.IndexOf(']');
                    if (ip6end > -1)
                    {
                        adport = value.Substring(9, ip6end);
                        int lstidx = adport.LastIndexOf(']');
                        if (lstidx > -1)
                        {
                            lcladdr = adport.Substring(0, lstidx + 1).Trim();
                            lclport = adport.Substring(lstidx + 2, (adport.Length - 2) - lstidx).Trim();
                        }
                    }                    
                }
                adport = value.Substring(32, 23).Trim();
                if (adport.Contains(":") && adport.Contains("."))
                {
                    String[] adp = adport.Split(':');
                    rmtaddr = adp[0];
                    rmtport = adp[1];
                }
                else
                {
                    //IPv6
                    int ip6end = value.IndexOf(']', value.IndexOf(']') + 1);
                    if (ip6end > -1)
                    {
                        adport = value.Substring(32, value.Length - ip6end);
                        int lstidx = adport.LastIndexOf(']');
                        if (lstidx > -1)
                        {
                            rmtaddr = adport.Substring(0, lstidx + 1).Trim();
                            rmtport = adport.Substring(lstidx + 2, (adport.Length - 2) - lstidx).Trim();
                        }
                    }
                    
                }
                state = value.Substring(55, 16).Trim();
                pid = value.Substring(71, value.Length - 71).Trim();
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

