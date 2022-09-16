using CoiNYC.Core.CQRS;
using CoiNYC.Domain.Commons;
using System;
using System.Linq;

namespace CoiNYC.Domain.Settings
{
    public class SettingContactCommands
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

    public class SettingContactEdit : SettingContactCommands, IRequest<int>
    {
        public int Id { get; set; }
    }

    public class SettingSocialCommands
    {
        public string Facebook { get; set; }
        public string Google { get; set; }
        public string Instagram { get; set; }
        public string LinkedIn { get; set; }
        public string Pinterest { get; set; }
        public string Twitter { get; set; }
        public string Youtube { get; set; }
    }

    public class SettingSocialEdit : SettingSocialCommands, IRequest<int>
    {
        public int Id { get; set; }
    }

    public class SettingEmailCommands
    {
        public string SmtpHost { get; set; }
        public string SmtpPort { get; set; }
        public string SmtpUserName { get; set; }
        public string SmtpPassword { get; set; }
        public string OrderEmail { get; set; }
        public string NotificationEmail { get; set; }
        public string RegisterEmailTemplate { get; set; }
        public string RegisterEmailKeywords { get; set; }
        public string OrderEmailTemplate { get; set; }
        public string OrderEmailKeywords { get; set; }
    }

    public class SettingEmailEdit : SettingEmailCommands, IRequest<int>
    {
        public int Id { get; set; }
    }

    public class EmailTemplateEdit : IRequest<int>
    {
        public EmailType Type { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
