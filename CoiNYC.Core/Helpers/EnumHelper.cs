using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using CoiNYC.Core.Attributes;
using CoiNYC.Core.Extensions;

namespace CoiNYC.Core.Helpers
{
    public static class EnumFunc
    {
        #region generic methods

        internal static string GetLocalizedString(Type enumType, Type resourceType, object value)
        {
            string resourceKey = string.Format("{0}_{1}", enumType.Name, value);

            string stringValue = resourceKey.GetFromResource(resourceType, false);

            if (stringValue == null)
            {
                stringValue = GetDescription(value);
            }

            return stringValue;
        }

        public static string GetLocalizedString<TEnum>(TEnum value)
        {
            if (value == null)
                return String.Empty;

            var enumType = GetUnderlyingType(typeof(TEnum));
            var resourceType = GetResourceType(enumType);
            return GetLocalizedString(enumType, resourceType, value);
        }

        public static List<string> GetLocalizedString<TEnum>(IEnumerable<TEnum> enumList)
        {
            var enumType = GetUnderlyingType(typeof(TEnum));
            var resourceType = GetResourceType(enumType);
            List<string> list = new List<string>();

            foreach (TEnum enumValue in enumList)
                list.Add(GetLocalizedString(enumType, resourceType, enumValue));

            return list;
        }


        public static TEnum GetEnumFromStringValue<TEnum>(string value)
        {
            bool isEnum = EnumFunc.IsEnum(typeof(TEnum));

            if (!isEnum) throw new ArgumentException("T must be an enumerated type");

            TEnum result = default(TEnum);

            FieldInfo[] infos = typeof(TEnum).GetFields(BindingFlags.Public | BindingFlags.Static);

            foreach (FieldInfo item in infos)
            {
                if (item.GetCustomAttributes(typeof(StringValueAttribute), false).Select(p => (StringValueAttribute)p).Where(p => p.StringValue.Equals(value)).Count() > 0)
                {
                    result = (TEnum)item.GetValue(typeof(TEnum));
                    break;
                }
                else if (item.Name.Equals(value))
                {
                    result = (TEnum)item.GetValue(typeof(TEnum));
                    break;
                }
            }
            return result;
        }


        #endregion

        #region type based methods
        public static Dictionary<Enum, string> GetEnumValues(Type enumType, Type resourceType)
        {
            Type realEnumType = GetUnderlyingType(enumType);

            bool isEnum = IsEnum(realEnumType);

            if (!isEnum)
                throw new ArgumentException("Type must be an enumerated type");

            if (resourceType == null)
                resourceType = GetResourceType(realEnumType);

            var enumDictionary = new Dictionary<Enum, string>();

            IEnumerable<Enum> values = Enum.GetValues(realEnumType).Cast<Enum>();

            foreach (var value in values)
            {
                string localizedString = GetLocalizedString(realEnumType, resourceType, value);
                enumDictionary.Add(value, localizedString);
            }

            return enumDictionary;
        }

        public static Type GetUnderlyingType(Type type)
        {
            Type underlyingType = Nullable.GetUnderlyingType(type);

            if (underlyingType != null)
                return underlyingType;

            return type;
        }

        public static bool IsEnum(Type type)
        {
            return GetUnderlyingType(type).IsEnum;
        }



        #endregion

        #region eleminated
        private static string GetDescription(object value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            if (fi != null)
            {
                DescriptionAttribute attribute = fi.First<DescriptionAttribute>();
                if (attribute != null)
                    return attribute.Description;

            }

            return value.ToString();
        }

        private static Type GetResourceType(Type enumType)
        {
            var localizationAttribute = enumType.First<LocalizationEnumAttribute>();

            if (localizationAttribute != null)
                return localizationAttribute.ResourceClassType;

            return null;
        }
        #endregion
    }


}
