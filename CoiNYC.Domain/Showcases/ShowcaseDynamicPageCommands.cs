namespace CoiNYC.Domain.Showcases
{
    using CoiNYC.Core.CQRS;

    public class ShowcaseDynamicPagesBaseCommands
    {
        public int ShowcaseId { get; set; }
        public string ButtonText { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }

    public class ShowcaseDynamicPagesAdd : ShowcaseDynamicPagesBaseCommands, IRequest<int>
    {

    }

    public class ShowcaseDynamicPagesEdit : ShowcaseDynamicPagesBaseCommands, IRequest<int>
    {
        public int Id { get; set; }
    }

    public class ShowcaseDynamicPagesDelete : DeleteCommand
    {

    }
}
