using CoiNYC.Core.CQRS;
using CoiNYC.Core.Extensions;
using CoiNYC.Domain.Repositories;
using System;
using System.Linq;

namespace CoiNYC.Domain.Currencies
{
    class CurrencyGridQueryHandler : PagedQueryHandler<CurrencyGridQuery, CurrencyGridDto>
    {
        public IDomainRepository DomainRepository { get; set; }

        protected override IQueryable<CurrencyGridDto> CreateQuery(CurrencyGridQuery request)
        {
            var query = DomainRepository.GetQuery<Currency>();

            if (!String.IsNullOrEmpty(request.Name))
                query = query.Where(x => x.Name.Contains(request.Name));

            return query.Project().To<CurrencyGridDto>().OrderBy(x => x.Id);
        }
    }

    class CurrencyDtoQueryHandler : QueryHandler<CurrencyDtoQuery, CurrencyDto>
    {
        public IDomainRepository DomainRepository { get; set; }

        protected override IQueryable<CurrencyDto> CreateQuery(CurrencyDtoQuery request)
        {
            var query = DomainRepository.GetQuery<Currency>();

            if (request.Id.HasValue)
                query = query.Where(x => x.Id == request.Id.Value);

            if (request.Enabled.HasValue)
                query = query.Where(x => x.Enabled == request.Enabled.Value);

            if (!String.IsNullOrEmpty(request.Code))
                query = query.Where(x => x.Code == request.Code);

            if (!String.IsNullOrEmpty(request.Name))
                query = query.Where(x => x.Name.Contains(request.Name));

            return query.Project().To<CurrencyDto>().OrderBy(x => x.Id);
        }

    }
}
