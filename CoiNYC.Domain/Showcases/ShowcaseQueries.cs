using CoiNYC.Core.CQRS;
using CoiNYC.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoiNYC.Domain.Showcases
{

    public class ShowcaseDtoQuery : QueryRequest<ShowcaseDto>
    {
        public int? Id { get; set; }
    }

    public class ShowcasePositionDtoQuery : QueryRequest<ShowcasePositionDto>
    {

    }

    public class ShowcaseGridQuery : PagedQueryRequest<IPagedList<ShowcaseGridDto>>
    {
        public string Name { get; set; }
        public bool? Enabled { get; set; }
        public int? PositionId { get; set; }
        public ShowcaseType? Type { get; set; }
    }

    public class ShowcaseSiteDtoQuery : IRequest<List<ShowcaseSiteDto>>
    {
        public string Culture { get; set; }
        public string CurrencyCode { get; set; }
    }
}
