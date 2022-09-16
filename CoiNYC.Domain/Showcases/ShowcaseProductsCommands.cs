namespace CoiNYC.Domain.Products
{
    using CoiNYC.Core.CQRS;

    public class ShowcaseProductsBaseCommands
    {
        public int ShowcaseId { get; set; }
        public int ProductId { get; set; }
        public int DisplayOrder { get; set; }
    }

    public class ShowcaseProductsAdd : ShowcaseProductsBaseCommands, IRequest<int>
    {

    }

    public class ShowcaseProductsEdit : ShowcaseProductsBaseCommands, IRequest<int>
    {
        public int Id { get; set; }
    }

    public class ShowcaseProductsDelete : DeleteCommand
    {

    }
}
