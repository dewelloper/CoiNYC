using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using CoiNYC.Globalization;
using CoiNYC.Features.Shared;
using CoiNYC.Services;
using CoiNYC.Core.CQRS;
using CoiNYC.Services.Email;
using System.Security.Permissions;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace CoiNYC.Features.Home
{
    ////[Authorize]
    //[Route("")]
    //public class HomeController : Controller
    //{
    //    private readonly ILogger<HomeController> _logger;

    //    public HomeController(ILogger<HomeController> logger)
    //    {
    //        _logger = logger;
    //    }

    //    public IActionResult Index()
    //    {
    //        return View();
    //    }

    //}
    public class HomeController : BaseController
    {

        #region Fields
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ISitemapService _sitemapService;
        private readonly IMediator _mediator;
        //private readonly IEmailService _emailService;
        #endregion

        #region Constructors

        public HomeController(IHttpClientFactory httpClientFactory, ISitemapService sitemapService, IMediator mediator, ICurrencyService currency, ICacheService cache)
            : base(mediator, currency, cache)
        {
            _httpClientFactory = httpClientFactory;
            this._sitemapService = sitemapService;
            this._mediator = mediator;
        }

        #endregion

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Secret()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var idToken = await HttpContext.GetTokenAsync("id_token");
            var refreshToken = await HttpContext.GetTokenAsync("refresh_token");

            var claims = User.Claims.ToList();
            var _accessToken = new JwtSecurityTokenHandler().ReadJwtToken(accessToken);
            var _idToken = new JwtSecurityTokenHandler().ReadJwtToken(idToken);

            //var result = await GetSecret(accessToken);

            //await RefreshAccessToken();

            return View();
        }

        public IActionResult Logout()
        {
            return SignOut("Cookie", "oidc");
        }

        public async Task<string> GetSecret(string accessToken)
        {
            var apiClient = _httpClientFactory.CreateClient();

            apiClient.SetBearerToken(accessToken);

            var response = await apiClient.GetAsync("https://localhost:44337/secret");

            var content = await response.Content.ReadAsStringAsync();

            return content;
        }

        private async Task RefreshAccessToken()
        {
            var serverClient = _httpClientFactory.CreateClient();
            var discoveryDocument = await serverClient.GetDiscoveryDocumentAsync("https://localhost:443/");

            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var idToken = await HttpContext.GetTokenAsync("id_token");
            var refreshToken = await HttpContext.GetTokenAsync("refresh_token");
            var refreshTokenClient = _httpClientFactory.CreateClient();

            var tokenResponse = await refreshTokenClient.RequestRefreshTokenAsync(
                new RefreshTokenRequest
                {
                    Address = discoveryDocument.TokenEndpoint,
                    RefreshToken = refreshToken,
                    ClientId = "client_id_mvc",
                    ClientSecret = "client_secret_mvc"
                });

            var authInfo = await HttpContext.AuthenticateAsync("Cookie");

            authInfo.Properties.UpdateTokenValue("access_token", tokenResponse.AccessToken);
            authInfo.Properties.UpdateTokenValue("id_token", tokenResponse.IdentityToken);
            authInfo.Properties.UpdateTokenValue("refresh_token", tokenResponse.RefreshToken);

            await HttpContext.SignInAsync("Cookie", authInfo.Principal, authInfo.Properties);
        }

        [Route("changelang/{culture}", Name = "ChangeLanguage")]
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

            //return LocalRedirect(returnUrl);

            //if (CultureManager.SupportedCultures.Any(x => x == culture))
            //{
            //    //CultureManager.SetCulture(culture);
            //    SetCultureCookie(culture);
            //}

            //string referer = Request.Headers["Referer"].ToString();
            
            //if (!string.IsNullOrEmpty(referer))
            //{
            //    var location = new Uri(referer);

            //    if (Url.IsLocalUrl(location.LocalPath))
            //    {
            //        return Redirect(location.LocalPath);
            //    }
            //}

            //return RedirectToAction("Index");
        }

        [Route("changecurrency/{currency}", Name = "ChangeCurrency")]
        public ActionResult ChangeCurrency(string currency)
        {
            if (CurrencyService.GetAll().Any(x => x.Code == currency))
            {
                SetCurrencyCookie(currency);
            }

            string referer = Request.Headers["Referer"].ToString();
            var location = new Uri(referer);

            if (!string.IsNullOrEmpty(location?.LocalPath) && location?.LocalPath.Length > 1)
            {
                if (Url.IsLocalUrl(location?.LocalPath))
                {
                    return Redirect(location.LocalPath);
                }
            }

            //if (!string.IsNullOrEmpty(Request?.UrlReferrer?.LocalPath))
            //{
            //    if (Url.IsLocalUrl(Request?.UrlReferrer?.LocalPath))
            //    {
            //        return Redirect(Request.UrlReferrer.LocalPath);
            //    }
            //}
            return RedirectToAction("Index");
        }

    }
}
