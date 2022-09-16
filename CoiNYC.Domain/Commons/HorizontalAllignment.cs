using CoiNYC.Core.Attributes;
using CoiNYC.Domain.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoiNYC.Domain.Commons
{
    [LocalizationEnum(typeof(E))]
    public enum HorizontalAlignment : byte
    {
        Left,
        Center,
        Right

    }
}
