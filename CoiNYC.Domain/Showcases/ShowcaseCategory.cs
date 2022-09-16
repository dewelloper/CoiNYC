namespace CoiNYC.Domain.Showcases
{
    using CoiNYC.Core.Data;

    public class ShowcaseCategory : Entity
    {
        public int CategoryId { get; set; }
        public int ShowcaseId { get; set; }
        public int DisplayOrder { get; set; }
        public virtual Showcase Showcase { get; set; }
    }
}
