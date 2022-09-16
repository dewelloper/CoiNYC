using Newtonsoft.Json.Serialization;
using System;
using System.Reflection;

namespace CoiNYC.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class ValueProviderAttribute : Attribute
    {
        public abstract IValueProvider GetProvider(PropertyInfo pi);
    }
}
