using System;

namespace CoiNYC.Core.Attributes
{
    public class StringValueAttribute : Attribute
    {

        public string StringValue { get; protected set; }

        public StringValueAttribute(string value)
        {
            StringValue = value;
        }
        protected StringValueAttribute()
        {
            
        }
         
    }
}
