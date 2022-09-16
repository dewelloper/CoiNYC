namespace CoiNYC.Domain.Showcases
{
    using CoiNYC.Core.Data;
    using CoiNYC.Domain.Products;

    public class ShowcaseProduct : Entity
    {
        public int ProductId { get; set; }
        public int ShowcaseId { get; set; }
        public int DisplayOrder { get; set; }
        public virtual Showcase Showcase { get; set; }
    }
}
