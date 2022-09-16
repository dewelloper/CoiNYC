using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace CoiNYC.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly ISettingsService settingsService;
        Microsoft.AspNetCore.Hosting.IWebHostEnvironment _env;

        public EmailService(ISettingsService settingsService, IWebHostEnvironment env)
        {
            this.settingsService = settingsService;
            this._env = env;
        }

        public async Task Send(EmailMessage mail)
        {
            var settings = settingsService.Get();
            if (settings != null)
            {
                var emailSettings = settings.Email;
                if (emailSettings != null)
                {
                    try
                    {
                        SmtpClient client = new SmtpClient(emailSettings.SmtpHost);
                        client.Credentials = new System.Net.NetworkCredential(emailSettings.SmtpUserName, emailSettings.SmtpPassword);
                        var message = new MailMessage
                        {
                            From = new MailAddress(emailSettings.SmtpUserName, "CoiNYC.net"),
                            Subject = mail.Subject,
                            IsBodyHtml = mail.IsBodyHtml,
                            Body = mail.Body,
                        };
                        message.To.Add(new MailAddress(mail.To));
                        if (!mail.IgnoreBcc)
                            message.Bcc.Add(new MailAddress(emailSettings.SmtpUserName));
                        if (!String.IsNullOrEmpty(mail.Cc))
                            message.CC.Add(new MailAddress(mail.Cc));

                        await client.SendMailAsync(message);
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            //var fileName = HttpContext.Current.Server.MapPath("/email.log");
                            var fileName = Path.Combine(_env.ContentRootPath, $"email.log");
                            using (StreamWriter sw = new StreamWriter(fileName, true))
                            {
                                sw.WriteLine(String.Format("-------------   {0}   ------------", DateTime.UtcNow));
                                sw.WriteLine(ex.Message);
                                sw.WriteLine(ex.StackTrace);
                                sw.Flush();
                                sw.Close();
                            }
                        }
                        catch {

                        }
                    }
                }
            }

        }

        public async Task SendAsync(IdentityMessage message)
        {
            await Send(new EmailMessage
            {
                Body = message.Body,
                Subject = message.Subject,
                To = message.Destination
            });
        }

      


    }
}