using System;
using System.Collections.Generic;
using System.Linq;
//using System.Web;

namespace CoiNYC.Services
{
    public interface ICurrencyService
    {
        IList<CoiNYC.Domain.Currencies.CurrencyDto> GetAll();
        CoiNYC.Domain.Currencies.CurrencyDto GetCurrent();
        CoiNYC.Domain.Currencies.CurrencyDto GetCurrentByUI(string currencyCodeOnUI);
        void SetCurrent(string code);
    }
}