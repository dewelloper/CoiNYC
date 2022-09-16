using System;
using System.Collections.Generic;
using System.Linq;

namespace CoiNYC.Core.CQRS
{
    public abstract class DeleteCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
