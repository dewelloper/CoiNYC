using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoiNYC.Features.Shared.Components.FinancialSlider
{
    public class CoinModel
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class FinancialSliderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(new List<CoinModel>() { new CoinModel() { Name  = "BTC", Value="7.001"} });
        }
    }
}
