using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;

namespace CoiNYC.Core.Extensions
{
    public static class NameValueCollectionExtensions
    {
        public static Dictionary<Type, List<PropertyMapInfo>> TypeProperties = new Dictionary<Type, List<PropertyMapInfo>>();

        public class PropertyMapInfo{
            public Type UnderlyingType { get; set; }
            public PropertyInfo PropertyInfo { get; set; }
        }

        public static T MapTo<T>(this NameValueCollection collection) where T : new()
        {
            T model = new T();

            var mapInfoList = GetTypeMapInfo(typeof(T));

            foreach (var mapInfo in mapInfoList)
            {
                string[] stringValues = collection.GetValues(mapInfo.PropertyInfo.Name);
                if (stringValues != null && stringValues.Length > 0)
                {
                    try
                    {
                        object value;
                        if (mapInfo.UnderlyingType.IsEnum)
                            value = Enum.Parse(mapInfo.UnderlyingType, stringValues[0]);
                        else
                            value = Convert.ChangeType(stringValues[0], mapInfo.UnderlyingType);


                        mapInfo.PropertyInfo.SetValue(model, value);
                    }
                    catch
                    {

                    }
                }
            }

            return model;
        }

        private static List<PropertyMapInfo> GetTypeMapInfo(Type type)
        {
            List<PropertyMapInfo> properties = null;

            if (TypeProperties.ContainsKey(type))
                properties = TypeProperties[type];
            else
            {

                properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(x => x.CanWrite)
                    .Select(x => new PropertyMapInfo { PropertyInfo = x })
                    .ToList();

                properties.ForEach(x =>
                {
                    if (x.PropertyInfo.PropertyType.IsGenericType && (x.PropertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                        x.UnderlyingType = Nullable.GetUnderlyingType(x.PropertyInfo.PropertyType);
                    else
                        x.UnderlyingType = x.PropertyInfo.PropertyType;
                });
                Type stringType = typeof(string);
                properties.RemoveAll(x => !x.UnderlyingType.IsValueType && !x.UnderlyingType.IsEnum && x.UnderlyingType != stringType);

                TypeProperties.Add(type, properties);
            }

            return properties;
        }
        
    }
}
