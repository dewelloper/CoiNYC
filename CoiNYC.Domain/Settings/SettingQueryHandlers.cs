using CoiNYC.Core.CQRS;
using CoiNYC.Core.Extensions;
using CoiNYC.Domain.Repositories;
using System;
using System.Linq;

namespace CoiNYC.Domain.Settings
{
    class SettingContactDtoQueryHandler : QueryHandler<SettingContactDtoQuery, SettingContactDto>
    {
        public IDomainRepository DomainRepository { get; set; }

        protected override IQueryable<SettingContactDto> CreateQuery(SettingContactDtoQuery request)
        {
            var query = DomainRepository.GetQuery<SettingContact>();

            return query.Project().To<SettingContactDto>().OrderBy(x => x.Id);
        }

    }

    class SettingEmailDtoQueryHandler : QueryHandler<SettingEmailDtoQuery, SettingEmailDto>
    {
        public IDomainRepository DomainRepository { get; set; }

        protected override IQueryable<SettingEmailDto> CreateQuery(SettingEmailDtoQuery request)
        {
            var query = DomainRepository.GetQuery<SettingEmail>();

            return query.Project().To<SettingEmailDto>().OrderBy(x => x.Id);
        }

    }

    class SettingSocialDtoQueryHandler : QueryHandler<SettingSocialDtoQuery, SettingSocialDto>
    {
        public IDomainRepository DomainRepository { get; set; }

        protected override IQueryable<SettingSocialDto> CreateQuery(SettingSocialDtoQuery request)
        {
            var query = DomainRepository.GetQuery<SettingSocial>();

            return query.Project().To<SettingSocialDto>().OrderBy(x => x.Id);
        }

    }

    class SettingsDtoQueryHandler : IRequestHandler<SettingsDtoQuery, SettingsDto>
    {
        public IDomainRepository DomainRepository { get; set; }

        public SettingsDto Handle(SettingsDtoQuery request)
        {
            return new SettingsDto
            {
                //Contact = DomainRepository.GetQuery<SettingContact>().Project().To<SettingContactDto>().FirstOrDefault(),
                //Social = DomainRepository.GetQuery<SettingSocial>().Project().To<SettingSocialDto>().FirstOrDefault(),
                Email = DomainRepository.GetQuery<SettingEmail>().Project().To<SettingEmailDto>().FirstOrDefault(),
                EmailTemplates = DomainRepository.GetQuery<EmailTemplate>().Project().To<EmailTemplateDto>().ToList()
            };
        }


    }

    class EmailTemplateDtoQueryHandler : QueryHandler<EmailTemplateDtoQuery, EmailTemplateDto>
    {
        public IDomainRepository DomainRepository { get; set; }

        protected override IQueryable<EmailTemplateDto> CreateQuery(EmailTemplateDtoQuery request)
        {
            var query = DomainRepository.GetQuery<EmailTemplate>();

            if (request.Type.HasValue)
                query = query.Where(x => x.Type == request.Type.Value);

            return query.Project().To<EmailTemplateDto>();
        }

    }
}
