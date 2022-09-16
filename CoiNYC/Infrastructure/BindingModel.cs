using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoiNYC.Infrastructure
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class BindingNameAttribute : Attribute
    {
        public string Name { get; set; }

        public BindingNameAttribute() { }

        public BindingNameAttribute(string name) { Name = name; }
    }
}
