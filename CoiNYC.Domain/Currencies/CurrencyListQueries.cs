using CoiNYC.Core.CQRS;
using CoiNYC.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoiNYC.Domain.Currencies
{

    public class CurrencyDtoQuery : QueryRequest<CurrencyDto>
    {
        public int? Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsNameExactMatch { get; set; }
        public bool? Enabled { get; set; }
    }

    public class CurrencyGridQuery : PagedQueryRequest<IPagedList<CurrencyGridDto>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
