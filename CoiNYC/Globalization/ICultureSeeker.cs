using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoiNYC.Globalization
{
    public interface ICultureSeeker
    {
        string Get(IOwinContext context);
        bool PriorityOnUrlCulture { get; }
    }
}
