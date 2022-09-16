namespace CoiNYC.Domain.Showcases
{
    using CoiNYC.Core.Data;
    using CoiNYC.Domain.Collections;

    public class ShowcaseCollection : Entity
    {
        public int CollectionId { get; set; }
        public int ShowcaseId { get; set; }
        public int DisplayOrder { get; set; }
        public virtual Showcase Showcase { get; set; }
    }
}
