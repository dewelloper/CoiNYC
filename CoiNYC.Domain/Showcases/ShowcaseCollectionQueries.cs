using CoiNYC.Core.CQRS;
using CoiNYC.Core.Data;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoiNYC.Domain.Showcases
{

    public class ShowcaseCollectionDtoQuery : QueryRequest<ShowcaseCollectionDto>
    {
        public int? Id { get; set; }
        public int? ShowcaseId { get; set; }
        public bool IsNameExactMatch { get; set; }
    }
}
