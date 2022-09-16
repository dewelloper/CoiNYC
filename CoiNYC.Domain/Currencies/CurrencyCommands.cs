using CoiNYC.Core.CQRS;
using System;
using System.Linq;

namespace CoiNYC.Domain.Currencies
{
    public class CurrencyCommands
    {
        public string Symbol { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public bool IsDefault { get; set; }
        public decimal Rate { get; set; }
    }

    public class CurrencyAdd : CurrencyCommands, IRequest<int>
    {

    }

    public class CurrencyEdit : CurrencyCommands, IRequest<int>
    {
        public int Id { get; set; }
    }

    public class CurrencyDelete : DeleteCommand
    {

    }
}
