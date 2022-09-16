using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Infrastructure
{
    public class GeneralSettingsIdentity4
    {
        public string AppMode { get; set; }
        public string RedirectUris_Local { get; set; }
        public string PostLogoutRedirectUris_Local { get; set; }
        public string RedirectUris_Prod { get; set; }
        public string PostLogoutRedirectUris_Prod { get; set; }
    }
}
