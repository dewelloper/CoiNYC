namespace CoiNYC.Domain.Settings
{
    using CoiNYC.Core.Data;
    using CoiNYC.Domain.Commons;

    public class SettingContact : Entity
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

    public class SettingSocial : Entity
    {
        public string Facebook { get; set; }
        public string Google { get; set; }
        public string Instagram { get; set; }
        public string LinkedIn { get; set; }
        public string Pinterest { get; set; }
        public string Twitter { get; set; }
        public string Youtube { get; set; }
    }

    public class SettingEmail : Entity
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

    public class EmailTemplate : Entity
    {
        public EmailType Type { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
