using CoiNYC.Core.CQRS;
using CoiNYC.Infrastructure;
using CoiNYC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace CoiNYC.Features.Shared
{
    public class BaseController : Controller
    {
        public ICacheService CacheService { get; set; }
        public ICurrencyService CurrencyService { get; set; }

        private IMediator Mediator;

        public BaseController(IMediator mediator, ICurrencyService currency, ICacheService cache)
        {
            this.Mediator = mediator;
            this.CurrencyService = currency;

            this.CacheService = cache;
        }

        public string CurrentCultureCode
        {
            get
            {
                return Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName.ToLower();
            }
        }

        public string CurrentCurrencyCode
        {
            get
            {
                return CurrencyService.GetCurrent().Code;
            }
        }

        string GetCookieValueFromResponse(HttpResponse response, string cookieName)
        {
            foreach (var headers in response.Headers)
            {
                if (headers.Key != "Set-Cookie")
                    continue;
                string header = headers.Value;
                if (header.StartsWith($"{cookieName}="))
                {
                    var p1 = header.IndexOf('=');
                    var p2 = header.IndexOf(';');
                    return header.Substring(p1 + 1, p2 - p1 - 1);
                }
            }
            return null;
        }

        public void SetCultureCookie(string cultureCode)
        {
            CultureInfo ci = new CultureInfo(cultureCode);
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = ci;

            var aCookie = GetCookieValueFromResponse(HttpContext.Response, "lang");
            if (aCookie != null)
            {
                //CHECK !!if cookie comes as keyvalue than get its key for deleting
                HttpContext.Response.Cookies.Delete(aCookie);
            }

            //if (HttpContext.Response.Cookies["lang"] != null)
            //{
            //    HttpContext.Response.Cookies.Remove("lang");
            //}
            //CookieOptions option = new CookieOptions();
            //option.SameSite = SameSiteMode.Strict;
            //option.IsEssential = true;
            //option.Expires = DateTime.Now.AddMonths(1);
            HttpContext.Response.Cookies.Append("lang", cultureCode);

            //HttpContext.Response.Cookies.Add(new HttpCookie("lang", cultureCode));

        }
        public void SetCurrencyCookie(string code)
        {
            var aCookie = GetCookieValueFromResponse(HttpContext.Response, "currency");
            if (aCookie != null)
            {
                //CHECK !!if cookie comes as keyvalue than get its key for deleting
                HttpContext.Response.Cookies.Delete(aCookie);
            }

            HttpContext.Response.Cookies.Append("currency", code);

            //if (HttpContext.Response.Cookies["currency"] != null)
            //{
            //    HttpContext.Response.Cookies.Remove("currency");
            //}
            //HttpContext.Response.Cookies.Add(new HttpCookie("currency", code));
        }

        //public virtual RedirectResult AjaxAwareRedirect(string url)
        //{
        //    return new AjaxAwareRedirectResult(url);
        //}

        public ActionResult MessageView(string message, string title = null)
        {
            return PartialView("_Message", new MessageModel { Message = message, Title = title });
        }


        public void AppendUncoded(string key, string value, CookieOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            var setCookieHeaderValue = new SetCookieHeaderValue(
                Uri.EscapeDataString(key),
                Uri.EscapeDataString(value))
            {
                Domain = options.Domain,
                Path = options.Path,
                Expires = options.Expires,
                MaxAge = options.MaxAge,
                Secure = options.Secure,
                //SameSite = SameSiteMode)options.SameSite,
                HttpOnly = options.HttpOnly
            };

            var cookieValue = setCookieHeaderValue.ToString();

            Headers[HeaderNames.SetCookie] = StringValues.Concat(Headers[HeaderNames.SetCookie], cookieValue);
        }

        IHeaderDictionary Headers { get; set; }

    }


}
