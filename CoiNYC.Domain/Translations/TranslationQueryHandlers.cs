using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoiNYC.Core.CQRS;
using CoiNYC.Domain.Repositories;
using CoiNYC.Core.Helpers;
using CoiNYC.Core.Extensions;

namespace CoiNYC.Domain.Translations
{
    class TranslationDtoQueryHandler : QueryHandler<TranslationDtoQuery, TranslationDto>
    {
        public IDomainRepository DomainRepository { get; set; }
        protected override IQueryable<TranslationDto> CreateQuery(TranslationDtoQuery request)
        {
            var query = DomainRepository.GetQuery<Translation>();
            if (request.Id.HasValue)
                query = query.Where(x => x.Id == request.Id.Value);

            if (request.ObjectId.HasValue)
                query = query.Where(x => x.ObjectId == request.ObjectId.Value);

            if (request.Type.HasValue)
                query = query.Where(x => x.Type == request.Type.Value);

            if (!String.IsNullOrEmpty(request.LanguageCode))
                query = query.Where(x => x.LanguageCode == request.LanguageCode.ToLower());

            return query.Project().To<TranslationDto>();
        }
    }
}
