using CoiNYC.Domain.Commons;
using System;
using System.Linq;

namespace CoiNYC.Domain.Translations
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class TranslationOwnerAttribute : Attribute
    {
        public OwnerType OwnerType { get; private set; }
        public TranslationOwnerAttribute(OwnerType ownerType)
        {
            this.OwnerType = ownerType;
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple =false, Inherited =false)]
    public class IsHtmlAttribute: Attribute {
    }
}
