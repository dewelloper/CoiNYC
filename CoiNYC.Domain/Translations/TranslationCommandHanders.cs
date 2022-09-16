using CoiNYC.Core.CQRS;
using CoiNYC.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoiNYC.Domain.Translations
{
    class TranslationCommandHandlers : IRequestHandler<TranslationAdd, Unit>
    {
        public IDomainRepository DomainRepository { get; set; }

        public Unit Handle(TranslationAdd request)
        {
            if (request.Translations != null)
            {
                foreach (var translation in request.Translations)
                {
                    var existingEntity = DomainRepository.GetQuery<Translation>(x => x.ObjectId == request.ObjectId && x.Type == request.Type && x.LanguageCode == translation.LanguageCode).FirstOrDefault();
                    if (existingEntity != null)
                    {
                        existingEntity.Data = translation.Data;
                        DomainRepository.UnitOfWork.SaveChanges();
                    }
                    else
                    {
                        var entity = new Translation
                        {
                            LanguageCode = translation.LanguageCode.ToLower(),
                            ObjectId = request.ObjectId,
                            Type = request.Type,
                            Data = translation.Data
                        };
                        DomainRepository.Save(entity);
                    }
                }
            }


            return Unit.Value;

        }
    }
}
