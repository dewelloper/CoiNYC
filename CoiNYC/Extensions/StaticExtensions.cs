using CoiNYC.Domain.Resources;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Web.Mvc.Html;

namespace CoiNYC.Extensions
{
    public static class Extensions
    {
        private static TimeZoneInfo shopTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time");
        public static DateTime ToShopDateTime(this DateTime dateTime)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(dateTime, shopTimeZone);
        }

        public static int GetProfileId(this IIdentity identity)
        {
            var claimsIdentity = identity as ClaimsIdentity;
            if (claimsIdentity != null)
            {
                var profileId = claimsIdentity.FindFirst(ClaimTypes.GroupSid)?.Value;
                if (profileId != null)
                {
                    return Convert.ToInt32(profileId);
                }
            }
            return 0;
        }

        public static string GetId(this IIdentity identity)
        {
            var claimsIdentity = identity as ClaimsIdentity;
            if (claimsIdentity != null)
            {
                return claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            }
            return null;
        }

        public static string GetDisplayName(this IIdentity identity)
        {
            var claimsIdentity = identity as ClaimsIdentity;
            if (claimsIdentity != null)
            {
                return claimsIdentity.FindFirst(ClaimTypes.GivenName)?.Value;
            }
            return null;
        }

        //public static MvcHtmlString RenderBlock(this HtmlHelper html, string code)
        //{
        //    try
        //    {
        //        var cacheService = DependencyResolver.Current.GetService<ICacheService>();
        //        string cacheKey = String.Format("Block:{0}:{1}", code, Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName);

        //        return cacheService.GetOrAdd(cacheKey, () =>
        //        {
        //            var mediator = DependencyResolver.Current.GetService<IMediator>();
        //            var block = mediator.Handle(new HtmlBlockSiteDtoQuery { Code = code, LanguageCode = Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName });
        //            if (!String.IsNullOrEmpty(block.CurrentLanguage.HTML))
        //                return html.Partial("_Block", block.CurrentLanguage.HTML);

        //            return new MvcHtmlString(String.Empty);
        //        }, 24.AsHour());

        //    }
        //    catch
        //    {

        //    }

        //    return new MvcHtmlString(String.Empty);
        //}
    }

    public static class Helpers
    {

        public static IEnumerable<SelectListItem> YesNoList
        {
            get
            {
                List<SelectListItem> list = new List<SelectListItem>();
                list.Add(new SelectListItem { Text = R.All, Value = String.Empty });
                list.Add(new SelectListItem { Text = R.Yes, Value = "true" });
                list.Add(new SelectListItem { Text = R.No, Value = "false" });

                return list;
            }
        }

        public static IEnumerable<SelectListItem> ActivePassiveList
        {
            get
            {
                List<SelectListItem> list = new List<SelectListItem>();
                list.Add(new SelectListItem { Text = R.All, Value = String.Empty });
                list.Add(new SelectListItem { Text = R.Active, Value = "true" });
                list.Add(new SelectListItem { Text = R.Passive, Value = "false" });

                return list;
            }
        }
    }
}