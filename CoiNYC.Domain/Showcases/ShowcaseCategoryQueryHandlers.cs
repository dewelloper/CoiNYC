using CoiNYC.Core.CQRS;
using CoiNYC.Core.Extensions;
using CoiNYC.Domain.Repositories;
using System;
using System.Linq;

namespace CoiNYC.Domain.Showcases
{

    class ShowcaseCategoryDtoQueryHandler : QueryHandler<ShowcaseCategoryDtoQuery, ShowcaseCategoryDto>
    {
        public IDomainRepository DomainRepository { get; set; }

        protected override IQueryable<ShowcaseCategoryDto> CreateQuery(ShowcaseCategoryDtoQuery request)
        {
            var query = DomainRepository.GetQuery<ShowcaseCategory>();

            if (request.Id.HasValue)
                query = query.Where(x => x.Id == request.Id.Value);

            if (request.ShowcaseId.HasValue)
                query = query.Where(x => x.ShowcaseId == request.ShowcaseId.Value);

            return query.Project().To<ShowcaseCategoryDto>().OrderBy(x => x.CategoryId);
        }

    }
}
