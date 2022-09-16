using CoiNYC.Domain.Settings;
using CoiNYC.Core.CQRS;
using System;
using System.Linq;
using System.Threading;

namespace CoiNYC.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly IMediator mediator;
        private readonly ICacheService cacheService;
        private SettingsDto settings;

        public SettingsService(IMediator mediator, ICacheService cacheService)
        {
            this.mediator = mediator;
            this.cacheService = cacheService;
        }

        public SettingsDto Get()
        {
            if (settings == null)
            {
                string languageCode = Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;
                settings = cacheService.GetOrAdd(String.Format("Settings:{0}",languageCode), 
                    ()=> mediator.Handle(new SettingsDtoQuery { LanguageCode = languageCode  }), 
                    1.AsHour());
            }
            return settings;
        }

        //public SpecificationDto GetSpecification(int shopId)
        //{
        //    var specifications = mediator.Handle(new SettingSpecificationDtoQuery() { ShopId = shopId }.AsSingle());
        //    return specifications;
        //}
    }

    public static class TimeSpanExtensions
    {
        public static TimeSpan AsMinute(this int value)
        {
            return new TimeSpan(0, value, 0);
        }

        public static TimeSpan AsSeconds(this int value)
        {
            return new TimeSpan(0, 0, value);
        }

        public static TimeSpan AsHour(this int value)
        {
            return new TimeSpan(value, 0, 0);
        }
    }

}