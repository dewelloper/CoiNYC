namespace CoiNYC.Domain.Showcases
{
    using CoiNYC.Core.Data;

    public class ShowcaseDynamicPage : Entity
    {
        public int ShowcaseId { get; set; }
        public string ButtonText { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public virtual Showcase Showcase { get; set; }
    }
}
