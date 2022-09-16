using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoiNYC.Globalization.Internal
{
    internal class OwinSupportedCulture
    {
        public string Name { set; get; }
        public string UIName { set; get; }
        public int MatchLevel { get; set; }
    }
}
