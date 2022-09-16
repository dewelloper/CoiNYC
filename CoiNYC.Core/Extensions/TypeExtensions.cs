using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CoiNYC.Core.Extensions
{
    public static class TypeExtensions
    {
        public static ConcurrentDictionary<Type, HashSet<string>> _typeProperties = new ConcurrentDictionary<Type, HashSet<string>>();

        public static bool PropertyExists(this Type type, string propertyName)
        {
            if (type == null || propertyName == null)
            {
                return false;

            }

            HashSet<string> properties = null;

            if (!_typeProperties.TryGetValue(type, out properties))
            {
                properties = type.GetProperties().Select(x => x.Name).ToHashSet();
                _typeProperties.TryAdd(type, properties);
            }

            return properties.Contains(propertyName);
        }

        public static object GetDefault(this Type type)
        {
            object output = null;

            if (type.IsValueType)
            {
                output = Activator.CreateInstance(type);
            }

            return output;
        }

        public static void SwitchValues<T>(ref T first, ref T second)
        {
            T temp = first;
            first = second;
            second = temp;
        }


        public static bool IsNumericType(Type type)
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsSubclassOfRawGeneric(this Type toCheck, Type generic)
        {
            while (toCheck != null && toCheck != typeof(object))
            {
                var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
                if (generic == cur)
                {
                    return true;
                }
                toCheck = toCheck.BaseType;
            }
            return false;
        }

        public static List<PropertyInfo> GetStaticProperies(this Type type, HashSet<Type> ofType = null) {
            IEnumerable<PropertyInfo> staticProperties = type.GetProperties(BindingFlags.Public | BindingFlags.Static);
            if (ofType != null)
                staticProperties = staticProperties.Where(x => ofType.Contains(x.PropertyType));

            return staticProperties.ToList();
        }
    }
}
