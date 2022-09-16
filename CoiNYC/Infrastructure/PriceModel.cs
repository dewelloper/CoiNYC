namespace CoiNYC.Infrastructure
{
    using CoiNYC.Domain.Products;
    using CoiNYC.Domain.Resources;
    using CoiNYC.Services;
    using System.ComponentModel.DataAnnotations;

    public class PriceModel
    {
        public int? Id { get; set; }
        [Display(Name = "Price", ResourceType = typeof(R))]
        public decimal? Price { get; set; }
        [Display(Name = "DiscountPrice", ResourceType = typeof(R))]
        public decimal? DiscountPrice { get; set; }
        public int CurrencyId { get; set; }
        public string CurrencyCode { get; set; }
    }


}