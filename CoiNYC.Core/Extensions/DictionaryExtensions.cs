using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CoiNYC.Core.Extensions
{
    public static class DictionaryExtensions
    {
        [Serializable]
        [XmlType(TypeName = "Item")]
        public class DictionaryItem
        {
            [XmlAttribute]
            public string Key { get; set; }
            [XmlElement]
            public string Value { get; set; }
        }

        public static string SerializeToXml(this Dictionary<string, string> dictionary, string rootElement)
        {
            StringBuilder sb = new StringBuilder();
            using (TextWriter writer = new StringWriter(sb))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(DictionaryItem[]),
                                 new XmlRootAttribute() { ElementName = rootElement });

                serializer.Serialize(writer, dictionary.Select(x => new DictionaryItem { Key = x.Key, Value = x.Value }).ToArray());
            }

            return sb.ToString();
        }

        public static Dictionary<string, string> XmlToDictionary(this string data, string rootElement)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            if (!String.IsNullOrEmpty(data))


                using (TextReader reader = new StringReader(data))
                {

                    XmlSerializer serializer = new XmlSerializer(typeof(DictionaryItem[]),
                                     new XmlRootAttribute() { ElementName = rootElement });

                    DictionaryItem[] serializedArray = (DictionaryItem[])serializer.Deserialize(reader);
                    for (int i = 0; i < serializedArray.Length; i++)
                    {
                        dictionary.Add(serializedArray[i].Key, serializedArray[i].Value);
                    }

                }
            return dictionary;
        }

        public static bool AddIfNotExists<TKey, TValue>(this Dictionary<TKey,TValue> dictionary, TKey key, TValue value) {
            if (!dictionary.ContainsKey(key))
            {
                dictionary.Add(key, value);
                return true;
            }
            return false;
        }
    }
}
