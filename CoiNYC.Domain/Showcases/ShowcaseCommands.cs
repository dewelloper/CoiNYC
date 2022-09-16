using CoiNYC.Core.CQRS;
using System;
using System.Linq;

namespace CoiNYC.Domain.Showcases
{
    public class ShowcaseCommands
    {
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public int DisplayOrder { get; set; }
        public int ShowcasePositionId { get; set; }
        public bool GroupByCategory { get; set; }
    }

    public class ShowcaseAdd : ShowcaseCommands, IRequest<int>
    {
        public ShowcaseType Type { get; set; }
    }

    public class ShowcaseEdit : ShowcaseCommands, IRequest<int>
    {
        public int Id { get; set; }
    }

    public class ShowcaseDelete : DeleteCommand
    {

    }
}
