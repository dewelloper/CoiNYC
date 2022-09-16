using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoiNYC.Infrastructure
{
    public class GeneralSettingsMvcClient
    {
        public string AppMode { get; set; }
        public string IdentityAuthorityLocal { get; set; }
        public string IdentityAuthorityProduction { get; set; }
    }
}
