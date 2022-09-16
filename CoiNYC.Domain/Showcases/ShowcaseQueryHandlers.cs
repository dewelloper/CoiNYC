using CoiNYC.Core.CQRS;
using CoiNYC.Core.Extensions;
using CoiNYC.Domain.Products;
using CoiNYC.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;

namespace CoiNYC.Domain.Showcases
{
    class ShowcaseGridQueryHandler : PagedQueryHandler<ShowcaseGridQuery, ShowcaseGridDto>
    {
        public IDomainRepository DomainRepository { get; set; }

        protected override IQueryable<ShowcaseGridDto> CreateQuery(ShowcaseGridQuery request)
        {
            var query = DomainRepository.GetQuery<Showcase>();

            if (!String.IsNullOrEmpty(request.Name))
                query = query.Where(x => x.Name.Contains(request.Name));

            if (request.Enabled.HasValue)
                query = query.Where(x => x.Enabled == request.Enabled.Value);

            if (request.Type.HasValue)
                query = query.Where(x => x.Type == request.Type.Value);

            if (request.PositionId.HasValue)
                query = query.Where(x => x.ShowcasePositionId == request.PositionId.Value);


            return query.Project().To<ShowcaseGridDto>().OrderBy(x => x.Id);
        }
    }

    class ShowcaseDtoQueryHandler : QueryHandler<ShowcaseDtoQuery, ShowcaseDto>
    {
        public IDomainRepository DomainRepository { get; set; }

        protected override IQueryable<ShowcaseDto> CreateQuery(ShowcaseDtoQuery request)
        {
            var query = DomainRepository.GetQuery<Showcase>();

            if (request.Id.HasValue)
                query = query.Where(x => x.Id == request.Id.Value);

            return query.Project().To<ShowcaseDto>().OrderBy(x => x.DisplayOrder);
        }

    }

    class ShowcasePositionDtoQueryHandler : QueryHandler<ShowcasePositionDtoQuery, ShowcasePositionDto>
    {
        public IDomainRepository DomainRepository { get; set; }

        protected override IQueryable<ShowcasePositionDto> CreateQuery(ShowcasePositionDtoQuery request)
        {
            var query = DomainRepository.GetQuery<ShowcasePosition>();

            return query.Project().To<ShowcasePositionDto>().OrderBy(x => x.Id);
        }

    }



}
