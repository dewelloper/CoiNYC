using CoiNYC.Domain.Showcases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
//using System.Web;

namespace CoiNYC.Infrastructure
{
    public class SiteConfig
    {
        public static SiteConfig Default { get; private set; }
        public List<Language> Languages { get; set; }
        public List<ShowcaseType> ShowcaseTypes { get; set; }

        public bool IsMultiLangual
        {
            get
            {
                return Languages != null && Languages.Count > 1;
            }
        }
        public static void Load()
        {
            string resourceName = "config.json";
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                var manifestResourceName = assembly.GetManifestResourceNames().Where(x => x.EndsWith("." + resourceName)).FirstOrDefault();

                using (Stream stream = assembly.GetManifestResourceStream(manifestResourceName))
                using (StreamReader sr = new StreamReader(stream))
                {
                    var content = sr.ReadToEnd();
                    Default = Newtonsoft.Json.JsonConvert.DeserializeObject<SiteConfig>(content);
                }
            }
            catch (Exception ex)
            {
            }
        }

        public class Language
        {
            public string Code { get; set; }
            public bool IsDefault { get; set; }
        }
    }
}