using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoiNYC.Globalization
{
    public class CultureFromPreferences : ICultureSeeker
    {
        public string Get(Microsoft.Owin.IOwinContext context)
        {
            var res = context.Authentication != null && context.Authentication.User != null ? context.Authentication.User.FindFirst(CultureManager.PreferenceToken) : null;
            if (res == null) return null;
            else return res.Value;
        }
        public bool PriorityOnUrlCulture { get { return true; } }
    }
}
