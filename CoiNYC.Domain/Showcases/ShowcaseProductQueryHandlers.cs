using CoiNYC.Core.CQRS;
using CoiNYC.Core.Extensions;
using CoiNYC.Domain.Repositories;
using System;
using System.Linq;

namespace CoiNYC.Domain.Showcases
{

    class ShowcaseProductDtoQueryHandler : QueryHandler<ShowcaseProductDtoQuery, ShowcaseProductDto>
    {
        public IDomainRepository DomainRepository { get; set; }

        protected override IQueryable<ShowcaseProductDto> CreateQuery(ShowcaseProductDtoQuery request)
        {
            var query = DomainRepository.GetQuery<ShowcaseProduct>();

            if (request.Id.HasValue)
                query = query.Where(x => x.Id == request.Id.Value);

            if (request.ShowcaseId.HasValue)
                query = query.Where(x => x.ShowcaseId == request.ShowcaseId.Value);

            return query.Project().To<ShowcaseProductDto>().OrderBy(x => x.ProductId);
        }

    }
}
