using System;
using System.Collections.Generic;
using System.Linq;

namespace CoiNYC.Core.Data
{
    [Serializable]
    public abstract class BaseUniqueDTO : BaseDTO, IUniqueable
    {
        public int Id { get; set; }

    }
}
