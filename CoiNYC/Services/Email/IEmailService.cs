using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace CoiNYC.Services.Email
{
    public class EmailMessage{
        public string To { get; set; }
        public string Cc { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
        public bool IsBodyHtml { get; set; }
        public bool IgnoreBcc { get; set; }
    }

    public interface IEmailService : IIdentityMessageService
    {
        Task Send(EmailMessage mail);
        //Task SendOrderInfo(string toEmail, OrderOverviewDto order, string overviewUrl);
    }
}