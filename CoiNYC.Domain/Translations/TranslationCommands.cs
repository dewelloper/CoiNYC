using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoiNYC.Domain.Commons;
using CoiNYC.Core.CQRS;

namespace CoiNYC.Domain.Translations
{
    public class TranslationAdd : IRequest<Unit>
    {
        public int ObjectId { get; set; }
        public OwnerType Type { get; set; }
        public List<TranslationData> Translations { get; set; }
    }

    public class TranslationData
    {
        public string LanguageCode { get; set; }
        public string Data { get; set; }
    }
}
