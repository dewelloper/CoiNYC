using System;
using System.Collections.Generic;
using System.Configuration;

namespace App.Core.Configuration
{
    public static class ConfigReader
    {


        private static string GetValue(string Key)
        {
            string Value = ConfigurationManager.AppSettings[Key];
            if (!string.IsNullOrEmpty(Value))
            {
                return Value;
            }
            return string.Empty;
        }

        public static string GetString(string Key, string DefaultValue=null)
        {
            string Setting = GetValue(Key);
            if (!string.IsNullOrEmpty(Setting))
            {
                return Setting;
            }
            return DefaultValue;
        }

        public static bool GetBool(string Key, bool? DefaultValue = null)
        {
            string Setting = GetValue(Key);
            if (!string.IsNullOrEmpty(Setting))
            {
                switch (Setting.ToLower())
                {
                    case "false":
                    case "0":
                    case "n":
                        return false;
                    case "true":
                    case "1":
                    case "y":
                        return true;
                    default:
                        break;
                }
            }
            return DefaultValue ?? false;
        }

        public static int GetInt(string Key, int? DefaultValue=null)
        {
            string Setting = GetValue(Key);
            if (!string.IsNullOrEmpty(Setting))
            {
                int i;
                if (int.TryParse(Setting, out i))
                {
                    return i;
                }
            }
            return DefaultValue ?? 0;
        }

        public static double GetDouble(string Key, double? DefaultValue = null)
        {
            string Setting = GetValue(Key);
            if (!string.IsNullOrEmpty(Setting))
            {
                double d;
                if (double.TryParse(Setting, out d))
                {
                    return d;
                }
            }
            return DefaultValue ?? 0;
        }

        public static byte GetByte(string Key, byte? DefaultValue = null)
        {
            string Setting = GetValue(Key);
            if (!string.IsNullOrEmpty(Setting))
            {
                byte b;
                if (byte.TryParse(Setting, out b))
                {
                    return b;
                }
            }
            return DefaultValue ?? 0;
        }

    
    }
}
