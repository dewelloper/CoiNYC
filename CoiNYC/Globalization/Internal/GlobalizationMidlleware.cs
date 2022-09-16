using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CoiNYC.Globalization.Internal
{
    internal class GlobalizationMidlleware : OwinMiddleware
    {
        private OwinGlobalizationOptions options;
        private class BrowserLanguage
        {
            public string Name { get; set; }
            public float Q { get; set; }
        }
        public GlobalizationMidlleware(OwinMiddleware next, OwinGlobalizationOptions options)
            : base(next)
        {
            if (options == null) throw new ArgumentNullException("options");
            this.options = options;

        }
        private IEnumerable<BrowserLanguage> parseLanguages(string[] languages)
        {
            var res = new List<BrowserLanguage>();
            foreach (var lan in languages)
            {
                var y = lan.Trim();
                if (string.IsNullOrEmpty(y)) continue;
                var parts = y.Split(';');
                var toAdd = new BrowserLanguage { Name = parts[0].Trim(), Q = 1.0f };
                float pref;
                if (parts.Length > 1 && float.TryParse(parts[1].Trim(), out pref))
                {
                    if (pref < 0f) pref = 0;
                    else if (pref > 1.0f) pref = 1.0f;
                    toAdd.Q = pref;
                }
                res.Add(toAdd);
            }
            return res;
        }
        private bool verifyPaths(IOwinContext context)
        {
            var Path = context.Request.Path;
            if (options.DisabledPaths == null || options.DisabledPaths.Length == 0 || !Path.HasValue || Path.Value.Length == 0) return false;
            string toCompare = Path.Value;
            if (toCompare[0] == '/') toCompare = toCompare.Substring(1);
            foreach (var path in options.DisabledPaths)
                if (!string.IsNullOrEmpty(path) && toCompare.StartsWith(path)) return true;
            return false;
        }
        private OwinSupportedCulture BrowserBestMatch(IOwinContext context)
        {
            string[] acceptLanguageHeader = null;
            if (context.Request.Headers.TryGetValue("Accept-Language", out acceptLanguageHeader) && acceptLanguageHeader != null)
            {
                float maxVote = -1.0f;
                OwinSupportedCulture maxElement = null;
                if (acceptLanguageHeader.Length == 1 && acceptLanguageHeader[0].Contains(','))
                    acceptLanguageHeader = acceptLanguageHeader[0].Split(',');
                foreach (var language in parseLanguages(acceptLanguageHeader))
                {
                    OwinSupportedCulture currLanguage = options.ClosestSupported(language.Name);
                    if (currLanguage == null) continue;
                    float currVote = currLanguage.MatchLevel * 10 + language.Q;
                    if (currVote > maxVote)
                    {
                        maxVote = currVote;
                        maxElement = currLanguage;
                    }
                }
                return maxElement ?? new OwinSupportedCulture
                {
                    Name = options.DefaultCulture,
                    UIName = options.DefaultUICulture,
                    MatchLevel = 0
                };
            }
            else return new OwinSupportedCulture
            {
                Name = options.DefaultCulture,
                UIName = options.DefaultUICulture,
                MatchLevel = 0
            };
        }
        private string getPathLanguage(IOwinContext context)
        {
            if (!context.Request.Path.HasValue) return null;
            string res = context.Request.Path.Value;
            if (res.Length < 2) return null;
            if (res[0] == '/' || res[0] == '\\') res = res.Substring(1);
            int pos = res.IndexOfAny(new char[] { '/', '\\' });
            if (pos >= 0) res = res.Substring(0, pos);
            return OwinGlobalizationOptions.ValidateCulture(res) ? res : null;
        }
        private string getCookieLanguage(IOwinContext context)
        {
            var cookie = context.Request.Cookies[options.CookieName];
            return OwinGlobalizationOptions.ValidateCulture(cookie) ? cookie : null;
        }
        public override async Task Invoke(IOwinContext context)
        {
            if (verifyPaths(context))
            {
                await this.Next.Invoke(context);
                return;
            }
            string urlLanguage = options.CulturePathEnabled ? getPathLanguage(context) : null;
            string customLanguage = null;
            string priorityCustomLanguage = null;
            if (options.seekers != null)
            {
                foreach (var x in options.seekers) if (x != null && x.PriorityOnUrlCulture)
                    {
                        priorityCustomLanguage = x.Get(context);
                        if (customLanguage != null) break;
                    }
                foreach (var x in options.seekers) if (x != null && !x.PriorityOnUrlCulture)
                    {
                        customLanguage = x.Get(context);
                        if (customLanguage != null) break;
                    }
            }
            string cookieLanguage = options.CookieEnabled ? getCookieLanguage(context) : null;
            string currLanguage = priorityCustomLanguage ?? (urlLanguage ?? (customLanguage ?? cookieLanguage));

            OwinSupportedCulture chosenLanguage = currLanguage == null ?
                BrowserBestMatch(context) :
                options.ClosestSupported(currLanguage);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(chosenLanguage.UIName);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(chosenLanguage.Name);
            if (options.CulturePathEnabled && options.AlwaysRedirectOnCulturePath && chosenLanguage.Name != urlLanguage)
            {
                var Path = context.Request.Path;
                ;
                string fPath = null;
                if (!Path.HasValue) fPath = chosenLanguage.Name;
                else if (urlLanguage == null)
                {
                    fPath = chosenLanguage.Name +
                        (Path.Value[0] == '/' ? Path.Value :
                            "/" + Path.Value
                        );

                }
                else
                {
                    int position = Path.Value.Substring(1).IndexOf('/');
                    if (position < 0) fPath = chosenLanguage.Name;
                    else fPath = chosenLanguage.Name + Path.Value.Substring(position + 1);
                }
                var builder = new UriBuilder(context.Request.Uri);
                builder.Path = fPath;
                context.Response.Redirect(builder.Uri.AbsoluteUri);
                return;
            }
            if (options.CookieEnabled && cookieLanguage != chosenLanguage.Name)
            {
                context.Response.Cookies.Append(options.CookieName, chosenLanguage.Name);
            }
            await this.Next.Invoke(context);

        }

    }
}
