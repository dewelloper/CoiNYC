using CoiNYC.Domain.Currencies;
using CoiNYC.Core.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoiNYC.Services
{
    public class CurrencyService : ICurrencyService
    {
        private CurrencyDto currency;
        private IMediator mediator;
        private IList<CurrencyDto> _currencies;

        public CurrencyService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public CurrencyDto GetCurrent()
        {
            if (currency == null)
            {
                currency = GetAll().OrderByDescending(x=>x.IsDefault).FirstOrDefault();
            }
            return currency;
        }

        public CurrencyDto GetCurrentByUI(string currencyCodeOnUI)
        {
            return _currencies.Where(_ => _.Code.ToUpper() == currencyCodeOnUI).FirstOrDefault();
        }

        public void SetCurrent(string code)
        {
            var selected = GetAll().Where(x => x.Code == code).FirstOrDefault();
            if (selected != null)
            {
                currency = selected;
            }
        }

        public IList<CurrencyDto> GetAll() {
            if (_currencies == null)
            {
                _currencies = mediator.Handle(new CurrencyDtoQuery { Enabled = true }.AsList());
            }

            return _currencies;
        }
    }
}