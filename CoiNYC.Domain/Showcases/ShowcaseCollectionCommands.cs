namespace CoiNYC.Domain.Collections
{
    using CoiNYC.Core.CQRS;

    public class ShowcaseCollectionsBaseCommands
    {
        public int ShowcaseId { get; set; }
        public int CollectionId { get; set; }
        public int DisplayOrder { get; set; }
    }

    public class ShowcaseCollectionsAdd : ShowcaseCollectionsBaseCommands, IRequest<int>
    {

    }

    public class ShowcaseCollectionsEdit : ShowcaseCollectionsBaseCommands, IRequest<int>
    {
        public int Id { get; set; }
    }

    public class ShowcaseCollectionsDelete : DeleteCommand
    {

    }
}
