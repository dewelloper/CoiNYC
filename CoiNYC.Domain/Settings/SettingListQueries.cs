using CoiNYC.Core.CQRS;
using CoiNYC.Core.Data;
using CoiNYC.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoiNYC.Domain.Settings
{

    public class SettingContactDtoQuery : QueryRequest<SettingContactDto>
    {
        public int Id { get; set; }
    }

    public class SettingEmailDtoQuery : QueryRequest<SettingEmailDto>
    {
        public int Id { get; set; }
    }

    public class SettingSocialDtoQuery : QueryRequest<SettingSocialDto>
    {
        public int Id { get; set; }
    }

    public class SettingsDtoQuery : IRequest<SettingsDto>
    {
        public string LanguageCode { get; set; }
    }

    public class EmailTemplateDtoQuery : QueryRequest<EmailTemplateDto>
    {
        public EmailType? Type { get; set; }
    }

    //public class SettingContactGridQuery : PagedQueryRequest<IPagedList<SettingContactGridDto>>
    //{

    //}
}
