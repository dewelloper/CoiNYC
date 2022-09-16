using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Linq;
using CoiNYC.Globalization;

namespace CoiNYC.Globalization
{
    public class CultureManager
    {
        public static string PreferenceToken { get { return "http://www.mvc-controls.com/globalization/preferred_culture"; } }
        internal static List<string> supportedCultures = new List<string>();
        public static IEnumerable<string> SupportedCultures { get { return supportedCultures; } }
        public static bool ValidateCulture(string x) { return OwinGlobalizationOptions.ValidateCulture(x); }
    }
    //public static class CultureManager
    //{
    //    static string _defaultCultureName;
    //    static string _dateFormat;
    //    static string _decimalSeperator;
    //    static string _groupSeperator;

    //    static CultureInfo DefaultCulture
    //    {
    //        get
    //        {
    //            return SupportedCultures[_defaultCultureName];
    //        }
    //    }

    //    static Dictionary<string, CultureInfo> SupportedCultures { get; set; }


    //    public static void AddSupportedCulture(params string[] names)
    //    {

    //        if (names != null && names.Length > 0)
    //        {
    //            foreach (string name in names)
    //            {
    //                if (!SupportedCultures.ContainsKey(name))
    //                {
    //                    SupportedCultures.Add(name, CultureInfo.CreateSpecificCulture(name));
    //                }

    //            }
    //        }
    //    }

    //    public static IEnumerable<CultureInfo> GetSupportedCultures()
    //    {
    //        return SupportedCultures.Values;
    //    }

    //    public static IEnumerable<string> GetSupportedCultureCodes()
    //    {
    //        return SupportedCultures.Values.Select(x=>x.TwoLetterISOLanguageName);
    //    }

    //    public static void SetDefaultCulture(string name)
    //    {
    //        _defaultCultureName = name;
    //    }

    //    public static void SetDateFormat(string dateFormat)
    //    {
    //        _dateFormat = dateFormat;
    //    }
    //    public static void SetDecimalSeperator(string decimalSeperator)
    //    {
    //        _decimalSeperator = decimalSeperator;
    //    }
    //    public static void SetGroupSeperator(string groupSeperator)
    //    {
    //        _groupSeperator = groupSeperator;
    //    }

    //    public static string GetDefaultCulture()
    //    {
    //        return SupportedCultures[_defaultCultureName].TwoLetterISOLanguageName;
    //    }


    //    static string ConvertToShortForm(string code)
    //    {
    //        return code.Substring(0, 2);
    //    }

    //    public static bool CultureIsSupported(string code)
    //    {
    //        if (string.IsNullOrWhiteSpace(code))
    //            return false;
    //        code = code.ToLowerInvariant();
    //        if (code.Length == 2)
    //            return SupportedCultures.ContainsKey(code);
    //        return CultureFormatChecker.FormattedAsCulture(code) && SupportedCultures.ContainsKey(ConvertToShortForm(code));
    //    }

    //    static CultureInfo GetCulture(string code)
    //    {
    //        if (!CultureIsSupported(code))
    //            return DefaultCulture;
    //        string shortForm = ConvertToShortForm(code).ToLowerInvariant(); ;
    //        return SupportedCultures[shortForm];
    //    }

    //    public static void SetCulture(string code)
    //    {
    //        CultureInfo cultureInfo = GetCulture(code);
    //        if (cultureInfo.TwoLetterISOLanguageName == "ar")
    //        {
    //            cultureInfo.DateTimeFormat.Calendar = cultureInfo.OptionalCalendars.Select(x => x as GregorianCalendar)
    //                .Where(x => x != null && x.CalendarType == GregorianCalendarTypes.Arabic).FirstOrDefault();
    //        }
    //        else
    //        if (cultureInfo.TwoLetterISOLanguageName == "fa")
    //        {
    //            cultureInfo.DateTimeFormat.Calendar = cultureInfo.OptionalCalendars.Select(x => x as GregorianCalendar)
    //                .Where(x => x != null && x.CalendarType == GregorianCalendarTypes.Localized).FirstOrDefault();
    //        }


    //        if (!string.IsNullOrEmpty(_dateFormat))
    //            cultureInfo.DateTimeFormat.ShortDatePattern = _dateFormat;
    //        if (!string.IsNullOrEmpty(_decimalSeperator))
    //            cultureInfo.NumberFormat.NumberDecimalSeparator = _decimalSeperator;
    //        if (!string.IsNullOrEmpty(_groupSeperator))
    //            cultureInfo.NumberFormat.NumberGroupSeparator = _groupSeperator;


    //        Thread.CurrentThread.CurrentUICulture = cultureInfo;
    //        Thread.CurrentThread.CurrentCulture = cultureInfo;
    //    }

    //    public static CultureInfo GetCurrentCulture()
    //    {
    //        return Thread.CurrentThread.CurrentCulture;
    //    }

    //    static CultureManager()
    //    {
    //        SupportedCultures = new Dictionary<string, CultureInfo>();
    //    }
    //}

}
