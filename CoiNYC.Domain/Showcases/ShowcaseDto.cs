namespace CoiNYC.Domain.Showcases
{
    using CoiNYC.Core.Data;
    using System.Collections.Generic;

    public class ShowcaseDto : BaseUniqueDTO
    {
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public int ShowcasePositionId { get; set; }
        public string ShowcasePositionCode { get; set; }
        public ShowcaseType Type { get; set; }
        public bool Enabled { get; set; }
        public bool GroupByCategory { get; set; }
    }

    public class ShowcasePositionDto : BaseUniqueDTO
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class ShowcaseGridDto : BaseUniqueDTO
    {
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public string ShowcasePositionName { get; set; }
        public ShowcaseType Type { get; set; }
        public bool Enabled { get; set; }
    }

    
    public class ShowcaseSiteDto : LocalizedUniqueDto<ShowcaseTranslationDto>
    {
        public int DisplayOrder { get; set; }
        public string Name { get; set; }
        public string ShowcasePositionCode { get; set; }
        public ShowcaseType Type { get; set; }
    }
}
