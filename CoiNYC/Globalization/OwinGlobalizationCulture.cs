using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoiNYC.Globalization
{
    public class OwinGlobalizationCulture
    {
        public string Name { set; get; }
        public bool UIIsNeutral { set; get; }
        public string GetUiCulture()
        {
            if (UIIsNeutral && Name.Length > 2) return Name.Substring(0, 2);
            else return Name;
        }
    }
}
