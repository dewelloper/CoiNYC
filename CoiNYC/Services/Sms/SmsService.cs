using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace CoiNYC.Services.Sms
{
    public class SmsService : ISmsService
    {
        public Task Send(SmsMessage message)
        {
            return Task.FromResult(0);
        }

        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }

}