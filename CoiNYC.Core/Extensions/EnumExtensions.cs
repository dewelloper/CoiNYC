using CoiNYC.Core.Attributes;
using CoiNYC.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CoiNYC.Core.Extensions
{
    public static class EnumExtensions
    {
        public static string GetLocalizedString(this Enum enumObject, Type resourceType)
        {
            return EnumFunc.GetLocalizedString(enumObject.GetType(), resourceType, enumObject);
        }

        public static string GetStringValue(this Enum value)
        {
            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());
            var attribute = fieldInfo.First<StringValueAttribute>();
            return attribute != null ? attribute.StringValue : value.ToString();
        }
    }
}
