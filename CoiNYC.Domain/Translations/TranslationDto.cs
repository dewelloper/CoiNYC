using CoiNYC.Core.Data;
using CoiNYC.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoiNYC.Domain.Translations
{
    public class TranslationDto : BaseUniqueDTO
    {
        public OwnerType Type { get; set; }
        public int ObjectId { get; set; }
        public string LanguageCode { get; set; }
        public string Data { get; set; }
    }
}
