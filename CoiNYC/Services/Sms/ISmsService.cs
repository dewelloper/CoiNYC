using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CoiNYC.Services.Sms
{
    public class SmsMessage
    {
        public string Number { get; set; }
        public string Body { get; set; }
    }

    public interface ISmsService : IIdentityMessageService
    {
        Task Send(SmsMessage message);
    }

}