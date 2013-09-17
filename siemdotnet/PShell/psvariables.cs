using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace psframework.PShell
{
    class psvariables
    {
        public class PSRoot : PSVariable
        {
            private String psroot = "C:\\pstest\\";

            public PSRoot(string name): base(name) { }

            public override Object Value
            {
                get { return psroot; }
            }
        }

        public class PSModRoot : PSVariable
        {
            private String psmodroot = "C:\\pstest\\Modules\\";

            public PSModRoot(string name) : base(name) { }

            public override Object Value
            {
                get { return psmodroot; }
            }
        }

        public class PSFramework : PSVariable
        {
            private String psf = "C:\\pstest\\Modules\\PoshSecFramework\\poshsecframework.psm1";

            public PSFramework(string name) : base(name) { }

            public override Object Value
            {
                get { return psf; }
            }
        }
    }

}
