using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CoiNYC.Core.Common;
using CoiNYC.Core.CQRS;
using CoiNYC.Features.Shared;
using CoiNYC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoiNYC.Extensions;
using Microsoft.AspNetCore.Localization;

namespace CoiNYC.Areas.Panel
{
    [Area("Panel")]
    [Authorize]
    public class PanelController : BaseController
    {
        #region Fields
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ISitemapService _sitemapService;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        #endregion


        public PanelController(IHttpClientFactory httpClientFactory, ISitemapService sitemapService, IMediator mediator, ICurrencyService currency, ICacheService cache, IHttpContextAccessor httpContextAccessor)
            : base(mediator, currency, cache)
        {
            _httpClientFactory = httpClientFactory;
            this._sitemapService = sitemapService;
            this._mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
        }


        public ActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(
                 CookieRequestCultureProvider.DefaultCookieName,
                 CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
             new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
             );

            string referer = Request.Headers["Referer"].ToString();
            if (!string.IsNullOrEmpty(referer))
            {
                var location = new Uri(referer);

                if (Url.IsLocalUrl(location.LocalPath))
                {
                    return Redirect(location.LocalPath);
                }
            }

            return RedirectToAction("Index");


        }
    }
}