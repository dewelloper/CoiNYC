namespace CoiNYC.Domain.Currencies
{
    using CoiNYC.Core.Data;
    public class CurrencyDto : BaseUniqueDTO
    {
        public string Symbol { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public bool IsDefault { get; set; }
        public decimal Rate { get; set; }
    }

    public class CurrencyGridDto : BaseUniqueDTO
    {
        public string Symbol { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsDefault { get; set; }
        public decimal Rate { get; set; }
        public bool Enabled { get; set; }
    }
}
