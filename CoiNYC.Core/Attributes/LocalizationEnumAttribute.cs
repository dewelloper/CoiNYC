using System;

namespace CoiNYC.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Enum, AllowMultiple = false, Inherited = true)]
    public class LocalizationEnumAttribute : Attribute
    {
        public Type ResourceClassType { get; protected set; }

        public LocalizationEnumAttribute(Type resourceClassType)
        {
            ResourceClassType = resourceClassType;
        }
        protected LocalizationEnumAttribute()
        {
            
        }
         
    }
}
