using System.Collections.Generic;

namespace CoiNYC.Domain.Showcases
{
    using CoiNYC.Core.Attributes;
    using CoiNYC.Core.Data;
    using CoiNYC.Domain.Resources;

    public class Showcase : Entity
    {
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public bool Enabled { get; set; }
        public int ShowcasePositionId { get; set; }
        public ShowcaseType Type { get; set; }
        public bool GroupByCategory { get; set; }

        public virtual ShowcasePosition ShowcasePosition { get; set; }
        public virtual List<ShowcaseProduct> Products { get; set; }
        public virtual List<ShowcaseCategory> Categories { get; set; }
        public virtual List<ShowcaseCollection> Collections { get; set; }
    }

    [LocalizationEnum(typeof(E))]
    public enum ShowcaseType : byte
    {
        Product = 0,
        Category = 1,
        Collection = 2,
        DynamicPage = 3
    }
}
