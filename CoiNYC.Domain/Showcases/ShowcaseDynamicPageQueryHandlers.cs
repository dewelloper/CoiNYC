using CoiNYC.Core.CQRS;
using CoiNYC.Core.Extensions;
using CoiNYC.Domain.Repositories;
using System;
using System.Linq;

namespace CoiNYC.Domain.Showcases
{

    class ShowcaseDynamicPageDtoQueryHandler : QueryHandler<ShowcaseDynamicPageDtoQuery, ShowcaseDynamicPageDto>
    {
        public IDomainRepository DomainRepository { get; set; }

        protected override IQueryable<ShowcaseDynamicPageDto> CreateQuery(ShowcaseDynamicPageDtoQuery request)
        {
            var query = DomainRepository.GetQuery<ShowcaseDynamicPage>();

            if (request.Id.HasValue)
                query = query.Where(x => x.Id == request.Id.Value);

            if (request.ShowcaseId.HasValue)
                query = query.Where(x => x.ShowcaseId == request.ShowcaseId.Value);

            return query.Project().To<ShowcaseDynamicPageDto>();
        }

    }
}
