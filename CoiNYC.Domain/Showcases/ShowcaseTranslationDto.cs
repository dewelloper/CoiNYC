using System;
using System.Linq;
using CoiNYC.Domain.Translations;
using CoiNYC.Domain.Commons;
using CoiNYC.Core.Data;

namespace CoiNYC.Domain.Showcases
{
    [TranslationOwner(OwnerType.Showcase)]
    public class ShowcaseTranslationDto : ITranslationDto
    {
        public string Name { get; set; }
    }
}
