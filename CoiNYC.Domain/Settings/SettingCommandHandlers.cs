using CoiNYC.Core.CQRS;
using CoiNYC.Core.Data;
using CoiNYC.Domain.Repositories;
using System;
using System.Linq;

namespace CoiNYC.Domain.Settings
{
    class SettingCommandHandler :
            IRequestHandler<SettingContactEdit, int>,
            IRequestHandler<SettingSocialEdit, int>,
            IRequestHandler<SettingEmailEdit, int>,
            IRequestHandler<EmailTemplateEdit, int>
    {
        public IDomainRepository DomainRepository { get; set; }

        int IRequestHandler<SettingContactEdit, int>.Handle(SettingContactEdit request)
        {
            SettingContact entity = DomainRepository.GetQuery<SettingContact>(x => x.Id == request.Id).FirstOrDefault();
            bool isNew = false;
            if (entity == null)
            {
                entity = new SettingContact();
            }

            entity.Address = request.Address;
            entity.BuyingAgreement = request.BuyingAgreement;
            entity.ContactEmail = request.ContactEmail;
            entity.ContactText = request.ContactText;
            entity.Lat = request.Lat;
            entity.Long = request.Long;
            entity.WorkingHours = request.WorkingHours;

            if (isNew)
            {
                DomainRepository.Save(entity);
            }
            else
            {
                DomainRepository.Update(entity);
            }
            DomainRepository.SaveChanges();

            return entity.Id;

        }

        int IRequestHandler<SettingSocialEdit, int>.Handle(SettingSocialEdit request)
        {
            SettingSocial entity = DomainRepository.GetQuery<SettingSocial>(x => x.Id == request.Id).FirstOrDefault();

            bool isNew = false;
            if (entity == null)
            {
                isNew = true;
                entity = new SettingSocial();
            }


            entity.Facebook = request.Facebook;
            entity.Google = request.Google;
            entity.Instagram = request.Instagram;
            entity.LinkedIn = request.LinkedIn;
            entity.Pinterest = request.Pinterest;
            entity.Twitter = request.Twitter;
            entity.Youtube = request.Youtube;

            if (isNew)
            {
                DomainRepository.Save(entity);
            }
            else
            {
                DomainRepository.Update(entity);
            }
            DomainRepository.SaveChanges();

            return entity.Id;

        }

        int IRequestHandler<SettingEmailEdit, int>.Handle(SettingEmailEdit request)
        {
            SettingEmail entity = DomainRepository.GetQuery<SettingEmail>(x => x.Id == request.Id).FirstOrDefault();

            bool isNew = false;
            if (entity == null)
            {
                isNew = true;
                entity = new SettingEmail();
            }

            entity.NotificationEmail = request.NotificationEmail;
            entity.OrderEmail = request.OrderEmail;
            entity.SmtpHost = request.SmtpHost;
            entity.SmtpPort = request.SmtpPort;
            entity.SmtpUserName = request.SmtpUserName;
            entity.SmtpPassword = request.SmtpPassword;
            entity.OrderEmailTemplate = request.OrderEmailTemplate;
            entity.RegisterEmailTemplate = request.RegisterEmailTemplate;

            if (isNew)
            {
                DomainRepository.Save(entity);
            }
            else
            {
                DomainRepository.Update(entity);
            }
            DomainRepository.SaveChanges();

            return entity.Id;

        }

        int IRequestHandler<EmailTemplateEdit, int>.Handle(EmailTemplateEdit request)
        {
            EmailTemplate entity = DomainRepository.GetQuery<EmailTemplate>(x => x.Type == request.Type).FirstOrDefault();

            bool isNew = false;
            if (entity == null)
            {
                isNew = true;
                entity = new EmailTemplate();
            }

            entity.Body = String.IsNullOrEmpty(request.Body) ? String.Empty : request.Body;
            entity.Subject = String.IsNullOrEmpty(request.Subject) ? String.Empty : request.Subject;
            entity.Type = request.Type;

            if (isNew)
            {
                DomainRepository.Save(entity);
            }
            else
            {
                DomainRepository.Update(entity);
            }
            DomainRepository.SaveChanges();
            return entity.Id;

        }
    }
}
