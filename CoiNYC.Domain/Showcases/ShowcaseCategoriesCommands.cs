namespace CoiNYC.Domain.Categorys
{
    using CoiNYC.Core.CQRS;

    public class ShowcaseCategorysBaseCommands
    {
        public int ShowcaseId { get; set; }
        public int CategoryId { get; set; }
        public int DisplayOrder { get; set; }
    }

    public class ShowcaseCategorysAdd : ShowcaseCategorysBaseCommands, IRequest<int>
    {

    }

    public class ShowcaseCategorysEdit : ShowcaseCategorysBaseCommands, IRequest<int>
    {
        public int Id { get; set; }
    }

    public class ShowcaseCategorysDelete : DeleteCommand
    {

    }
}
