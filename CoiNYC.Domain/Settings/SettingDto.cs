namespace CoiNYC.Domain.Settings
{
    using CoiNYC.Core.Data;
    using CoiNYC.Domain.Commons;
    using CoiNYC.Domain.Translations;
    using System.Collections.Generic;

    public class SettingContactDto : BaseUniqueDTO
    {
        public string Address { get; set; }
        public string Long { get; set; }
        public string Lat { get; set; }
        public string ContactEmail { get; set; }
        public string WorkingHours { get; set; }
        public string ContactText { get; set; }
        public string BuyingAgreement { get; set; }
        public string Phone { get; set; }
    }

    public class SettingSocialDto : BaseUniqueDTO
    {
        public string Facebook { get; set; }
        public string Google { get; set; }
        public string Instagram { get; set; }
        public string LinkedIn { get; set; }
        public string Pinterest { get; set; }
        public string Twitter { get; set; }
        public string Youtube { get; set; }
    }

    public class SettingEmailDto : BaseUniqueDTO
    {
        public string SmtpHost { get; set; }
        public string SmtpPort { get; set; }
        public string SmtpUserName { get; set; }
        public string SmtpPassword { get; set; }
        public string OrderEmail { get; set; }
        public string NotificationEmail { get; set; }
        public string RegisterEmailTemplate { get; set; }
        public string OrderEmailTemplate { get; set; }
    }

    public class SettingsDto
    {
        //public SettingContactDto Contact { get; set; }
        //public SettingSocialDto Social { get; set; }
        public SettingEmailDto Email { get; set; }
        public List<EmailTemplateDto> EmailTemplates { get; set; }
    }

    public class EmailTemplateDto
    {
        public EmailType Type { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }

    [TranslationOwner(OwnerType.DynamicPage)]
    public class EmailTemplateTranslationDto : ITranslationDto
    {
        public string Subject { get; set; }
        [IsHtml]
        public string Body { get; set; }
    }

}
