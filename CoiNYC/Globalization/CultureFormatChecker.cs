using System.Text.RegularExpressions;

namespace CoiNYC.Globalization
{
    public static class CultureFormatChecker
    {
        readonly static Regex _cultureRegexPattern = new Regex(@"^([a-zA-Z]{2})(-[a-zA-Z]{2})?$", RegexOptions.IgnoreCase & RegexOptions.Compiled);

        public static bool FormattedAsCulture(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return false;
            return _cultureRegexPattern.IsMatch(code);

        }
    }
}
