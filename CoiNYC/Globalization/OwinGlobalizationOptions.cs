using CoiNYC.Globalization.Internal;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoiNYC.Globalization
{
    public class OwinGlobalizationOptions
    {
        IDictionary<string, OwinGlobalizationCulture> supportedCultures;
        string defaultCulture, defaultUICulture;
        bool culturePathEnabled;
        bool alwaysRedirectOnCulturePath;
        bool cookieEnabled;
        internal List<ICultureSeeker> seekers = null;
        const string defaultCookiename = "preferred_culture";
        private string cookieName;
        public string CookieName { get { return cookieName; } set { cookieName = value; } }
        public bool CookieEnabled { get { return cookieEnabled; } }
        public bool CulturePathEnabled { get { return culturePathEnabled; } }
        public bool AlwaysRedirectOnCulturePath { get { return alwaysRedirectOnCulturePath; } }
        public string DefaultCulture { get { return defaultCulture; } }
        public string DefaultUICulture { get { return defaultUICulture; } }
        public string[] DisabledPaths { get; set; }
        public static bool ValidateCulture(string culture, bool weak = false)
        {
            if (string.IsNullOrWhiteSpace(culture)) return false;
            if (culture.Length != 2 && (culture.Length != 5 || culture[2] != '-')) return false;
            if (weak) return true;
            try
            {
                CultureInfo.GetCultureInfo(culture);
            }
            catch (CultureNotFoundException ex)
            {
                return false;
            }
            return true;
        }
        public OwinGlobalizationOptions(string defaultCulture, bool uIIsNeutral = false)
        {
            if (!ValidateCulture(defaultCulture)) throw new ArgumentException("defaultCulture");
            var defaultCultueInfos =
                new OwinGlobalizationCulture
                {
                    Name = defaultCulture,
                    UIIsNeutral = uIIsNeutral
                };
            this.defaultCulture = defaultCulture;
            this.defaultUICulture = defaultCultueInfos.GetUiCulture();
            supportedCultures = new Dictionary<string, OwinGlobalizationCulture>();
            CultureManager.supportedCultures.Clear();
            add(defaultCultueInfos);
            culturePathEnabled = true;
            alwaysRedirectOnCulturePath = true;
            cookieEnabled = true;
            cookieName = defaultCookiename;
        }
        private void add(OwinGlobalizationCulture x)
        {
            supportedCultures[x.Name.ToLowerInvariant()] = x;
            CultureManager.supportedCultures.Add(x.Name);
            if (x.Name.Length > 2)
            {
                var rc = x.Name.Substring(0, 2).ToLowerInvariant();
                if (!supportedCultures.ContainsKey(rc)) supportedCultures[rc] = x;
            }
        }
        public OwinGlobalizationOptions(
            string defaultCulture,
            params OwinGlobalizationCulture[] supportedCultures)
            : this(defaultCulture)
        {
            if (supportedCultures == null) return;
            int i = 0;
            foreach (var x in supportedCultures)
            {
                if (ValidateCulture(x.Name)) add(x);
                else throw new ArgumentException(string.Format("supportedCultures[{0}]",
                    i.ToString(CultureInfo.InvariantCulture)));

            }
        }
        public OwinGlobalizationOptions DisablePaths(params string[] paths)
        {
            DisabledPaths = paths;
            return this;
        }
        public OwinGlobalizationOptions Add(string culture, bool uIIsNeutral = false)
        {
            if (!ValidateCulture(culture)) throw new ArgumentException("culture");
            add(new OwinGlobalizationCulture { Name = culture, UIIsNeutral = uIIsNeutral });

            return this;
        }
        public OwinGlobalizationOptions AddCustomSeeker(ICultureSeeker x)
        {
            if (seekers == null) seekers = new List<ICultureSeeker>();
            seekers.Add(x);
            return this;
        }
        public OwinGlobalizationOptions DisableCultureInPath()
        {
            culturePathEnabled = false;
            alwaysRedirectOnCulturePath = false;
            return this;
        }
        public OwinGlobalizationOptions DisableRedirect()
        {
            alwaysRedirectOnCulturePath = false;
            return this;
        }
        public OwinGlobalizationOptions DisableCookie()
        {
            cookieEnabled = false;
            return this;
        }
        public OwinGlobalizationOptions CustomCookieName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("name");
            cookieName = name;
            return this;
        }
        internal OwinSupportedCulture ClosestSupported(string culture)
        {
            if (!ValidateCulture(culture, true)) return
                new OwinSupportedCulture
                {
                    Name = defaultCulture,
                    UIName = defaultUICulture,
                    MatchLevel = 0
                };
            culture = culture.ToLowerInvariant();
            OwinGlobalizationCulture res;
            if (supportedCultures.TryGetValue(culture, out res))
            {
                return new OwinSupportedCulture
                {
                    Name = res.Name,
                    UIName = res.GetUiCulture(),
                    MatchLevel = 2
                };
            }
            if (culture.Length > 2)
            {
                culture = culture.Substring(0, 2);
                if (supportedCultures.TryGetValue(culture, out res))
                {
                    return new OwinSupportedCulture
                    {
                        Name = res.Name,
                        UIName = res.GetUiCulture(),
                        MatchLevel = 1
                    };
                }
            }
            return new OwinSupportedCulture
            {
                Name = defaultCulture,
                UIName = defaultUICulture,
                MatchLevel = 0
            };
        }
    }
}
