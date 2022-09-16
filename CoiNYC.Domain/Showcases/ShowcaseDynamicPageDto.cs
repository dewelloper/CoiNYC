namespace CoiNYC.Domain.Showcases
{
    using CoiNYC.Core.Data;


    public class ShowcaseDynamicPageDto : BaseUniqueDTO
    {
        public int ShowcaseId { get; set; }
        public string ButtonText { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string ShowcaseName { get; set; }
    }
}
