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

namespace CoiNYC.Features.Donate
{

    public class DonateController : BaseController
    {

        #region Fields
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ISitemapService _sitemapService;
        private readonly IMediator _mediator;
        #endregion

        #region Constructors

        public DonateController(IHttpClientFactory httpClientFactory, ISitemapService sitemapService, IMediator mediator, ICurrencyService currency, ICacheService cache)
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


    }
}
