namespace CoiNYC.Core.Extensions
{
    using System;
    using System.Text;
    using System.IO;
    using System.IO.Compression;
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;
    public static class StringExtensions
    {
        private static readonly CultureInfo CultureEn = new CultureInfo("en-US");
        public static string RemoveDiacritics(this string text)
        {
            if (String.IsNullOrEmpty(text))
                return text;

            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);

        }

        public static string ToGenericUpper(this string value, bool removeNonLetters = false)
        {
            if (!string.IsNullOrEmpty(value))
            {
                value = value.ToLower().Replace("ı", "i");
                value = value.ToUpper();
                value = value.Replace("İ", "I").Replace("Ü", "U").Replace("Ğ", "G").Replace("Ş", "S").Replace("Ç", "C").Replace("Ö", "O");

                if (removeNonLetters)
                    value = String.Concat(value.Where(c => Char.IsLetter(c) || Char.IsWhiteSpace(c)));

                value = value.Trim();
            }
            return value;
        }

        public static string ToGenericLower(this string value, bool removeNonLetters = false, bool withEnglishCulture = false)
        {

            if (!string.IsNullOrEmpty(value))
            {
                if (withEnglishCulture)
                    value = ToGenericUpper(value, removeNonLetters).ToLower(CultureEn);
                else
                    value = ToGenericUpper(value, removeNonLetters).ToLower();
            }
            return value;
        }

        public static string RemoveNonAlphaNumeric(this string value)
        {
            if (value == null)
                return null;

            MatchCollection col = Regex.Matches(value, "[A-Za-z0-9]+");
            StringBuilder sb = new StringBuilder();
            foreach (Match m in col)
                sb.Append(m.Value);
            return sb.ToString();
        }

        public static string RemoveNonNumbers(this string value)
        {
            return String.Concat(value.Where(c => Char.IsNumber(c)));
        }

        public static string ToTitleCase(this string text, CultureInfo cultureInfo = null)
        {
            if (cultureInfo == null)
                cultureInfo = new CultureInfo("en-US", false);

            TextInfo myTI = cultureInfo.TextInfo;
            return myTI.ToTitleCase(text.ToLower(cultureInfo));
        }

        public static string UpTo(this string input, int maxLength, string suffixToUseWhenTooLong = "...")
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;
            else
            {
                if (input.Length > maxLength)
                    return input.Substring(0, maxLength) + suffixToUseWhenTooLong;
                else
                    return input;
            }
        }

        public static string SplitUpperCase(this string source, string splitter = " ")
        {
            if (String.IsNullOrEmpty(source))
            {
                return source;
            }

            var r = new Regex(@"(?<=[A-Z])(?=[A-Z][a-z]) | (?<=[^A-Z])(?=[A-Z]) | (?<=[A-Za-z])(?=[^A-Za-z])", RegexOptions.IgnorePatternWhitespace);

            return r.Replace(source, splitter);
        }

        public static string Compress(this string text)
        {
            try
            {
                if (!String.IsNullOrEmpty(text))
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(text);
                    byte[] compressedData = null;
                    using (var msi = new MemoryStream(buffer))
                    using (var mso = new MemoryStream())
                    {
                        using (var gs = new GZipStream(mso, CompressionMode.Compress))
                        {
                            CopyTo(msi, gs);
                        }

                        compressedData = mso.ToArray();
                    }
                    return Convert.ToBase64String(compressedData);
                }
            }
            catch
            {
                return text;
            }

            return String.Empty;
        }

        public static string Decompress(this string compressedText)
        {
            try
            {
                if (!String.IsNullOrEmpty(compressedText))
                {
                    byte[] buffer = Convert.FromBase64String(compressedText);
                    using (var msi = new MemoryStream(buffer))
                    using (var mso = new MemoryStream())
                    {
                        using (var gs = new GZipStream(msi, CompressionMode.Decompress))
                        {
                            CopyTo(gs, mso);
                        }

                        return Encoding.UTF8.GetString(mso.ToArray());
                    }
                }
            }
            catch
            {
            }

            return String.Empty;
        }

        private static void CopyTo(Stream src, Stream dest)
        {
            byte[] bytes = new byte[4096];

            int cnt;

            while ((cnt = src.Read(bytes, 0, bytes.Length)) != 0)
            {
                dest.Write(bytes, 0, cnt);
            }
        }

        public static string ConvertToBase64(this string text)
        {
            Encoding encoding = Encoding.UTF8;
            return Convert.ToBase64String(encoding.GetBytes(text));
        }

        public static string ConvertFromBase64(this string text)
        {
            byte[] bytes = Convert.FromBase64String(text);

            return Encoding.UTF8.GetString(bytes);
        }

        public static string GetFromResource(this string key, Type resourceType, bool keyWhenNotFound, params object[] args)
        {
            string value = null;
            if (resourceType != null && resourceType.PropertyExists(key))
            {
                System.Resources.ResourceManager rm = new System.Resources.ResourceManager(resourceType);
                value = rm.GetString(key, System.Threading.Thread.CurrentThread.CurrentUICulture);

                if (args.Length > 0)
                    value = String.Format(value, args);
            }

            return value ?? (keyWhenNotFound ? key : null);
        }
        /// <summary>
        /// Query string appender
        /// </summary>
        /// <param name="url">e.g. www.google.com?param=1</param>
        /// <param name="parameter">param2=xxx</param>
        /// <returns>www.google.com?param=1&param2=xxx</returns>
        public static string AppendQueryString(this string url, string parameter)
        {
            if (url.IndexOf("?") == -1)
                url = url + "?";
            else
                url = url + "&";
            url = url + parameter;
            return url;
        }
        /// <summary>
        /// Query string appender
        /// </summary>
        /// <param name="url">e.g. www.google.com?param=1</param>
        /// <param name="key">param2</param>
        /// <param name="value">xxx</param>
        /// <returns>www.google.com?param=1&param2=xxx</returns>
        public static string AppendQueryString(this string url, string key, string value)
        {
            if (url.IndexOf("?") == -1)
                url = url + "?";
            else
                url = url + "&";
            url = string.Format("{0}{1}={2}", url, key, value);
            return url;
        }

        public static string Fixed(this string url)
        {
            if (url != null)
            {
                if (!url.StartsWith("/") && !url.StartsWith("http://") && !url.StartsWith("https://"))
                    return "/" + url;
            }
            return url;
        }


        public static string RemapInternationalCharToAscii(char c)
        {
            string s = c.ToString().ToLowerInvariant();
            if ("àåáâäãåą".Contains(s))
            {
                return "a";
            }
            else if ("èéêëę".Contains(s))
            {
                return "e";
            }
            else if ("ìíîïı".Contains(s))
            {
                return "i";
            }
            else if ("òóôõöøőð".Contains(s))
            {
                return "o";
            }
            else if ("ùúûüŭů".Contains(s))
            {
                return "u";
            }
            else if ("çćčĉ".Contains(s))
            {
                return "c";
            }
            else if ("żźž".Contains(s))
            {
                return "z";
            }
            else if ("śşšŝ".Contains(s))
            {
                return "s";
            }
            else if ("ñń".Contains(s))
            {
                return "n";
            }
            else if ("ýÿ".Contains(s))
            {
                return "y";
            }
            else if ("ğĝ".Contains(s))
            {
                return "g";
            }
            else if (c == 'ř')
            {
                return "r";
            }
            else if (c == 'ł')
            {
                return "l";
            }
            else if (c == 'đ')
            {
                return "d";
            }
            else if (c == 'ß')
            {
                return "ss";
            }
            else if (c == 'Þ')
            {
                return "th";
            }
            else if (c == 'ĥ')
            {
                return "h";
            }
            else if (c == 'ĵ')
            {
                return "j";
            }
            else
            {
                return "";
            }
        }

        public static string URLFriendly(this string title)
        {
            if (title == null) return "";

            const int maxlen = 80;
            int len = title.Length;
            bool prevdash = false;
            var sb = new StringBuilder(len);
            char c;

            for (int i = 0; i < len; i++)
            {
                c = title[i];
                if ((c >= 'a' && c <= 'z') || (c >= '0' && c <= '9'))
                {
                    sb.Append(c);
                    prevdash = false;
                }
                else if (c >= 'A' && c <= 'Z')
                {
                    // tricky way to convert to lowercase
                    sb.Append((char)(c | 32));
                    prevdash = false;
                }
                else if (c == ' ' || c == ',' || c == '.' || c == '/' ||
                    c == '\\' || c == '-' || c == '_' || c == '=')
                {
                    if (!prevdash && sb.Length > 0)
                    {
                        sb.Append('-');
                        prevdash = true;
                    }
                }
                else if ((int)c >= 128)
                {
                    int prevlen = sb.Length;
                    sb.Append(RemapInternationalCharToAscii(c));
                    if (prevlen != sb.Length) prevdash = false;
                }
                if (sb.Length == maxlen) break;
            }

            if (prevdash)
                return sb.ToString().Substring(0, sb.Length - 1);
            else
                return sb.ToString();
        }

        static string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" }; //Longs run out around EB

        public static string SizeBytesToString(this long byteCount)
        {
            if (byteCount == 0)
                return "0" + suf[0];
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num).ToString() +" "+ suf[place];
        }

    }
}
