namespace CoiNYC.Domain.Currencies
{
    using CoiNYC.Core.Data;
    public class Currency : Entity
    {
        public string Symbol { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsDefault { get; set; }
        public decimal Rate { get; set; }
        public bool Enabled { get; set; }
    }
}
