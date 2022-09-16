using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CoiNYC.Core.CQRS;
using CoiNYC.Features.Shared;
using CoiNYC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoiNYC.Areas.Manage
{
    [Area("Manage")]
    [Authorize]
    public class ManageController : BaseController
    {
        #region Fields
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ISitemapService _sitemapService;
        private readonly IMediator _mediator;
        //private readonly IEmailService _emailService;
        #endregion

        #region Constructors

        public ManageController(IHttpClientFactory httpClientFactory, ISitemapService sitemapService, IMediator mediator, ICurrencyService currency, ICacheService cache)
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

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
