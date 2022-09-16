using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoiNYC.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class FilterFromGridAttribute : Attribute
    {
        public Type GridType { get; protected set; }

        public FilterFromGridAttribute(Type gridType)
        {
            GridType = gridType;
        }
    }
}
