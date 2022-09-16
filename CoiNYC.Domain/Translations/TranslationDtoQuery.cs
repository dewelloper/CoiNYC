using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoiNYC.Core.CQRS;
using CoiNYC.Domain.Commons;

namespace CoiNYC.Domain.Translations
{
    public class TranslationDtoQuery : QueryRequest<TranslationDto>
    {
        public int? Id { get; set; }
        public OwnerType? Type { get; set; }
        public int? ObjectId { get; set; }
        public string LanguageCode { get; set; }
    }
}
