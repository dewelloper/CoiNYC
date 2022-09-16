using System;
using System.Collections.Generic;
using System.Linq;

namespace CoiNYC.Core.Extensions
{
    public static class DecimalExtensions
    {
        public static string ToMoneyString(this decimal value)
        {
            return string.Format("{0}", value.ToMoneyFormatString());
        }

        public static string ToMoneyFormatString(this decimal value, bool useThousandsSeparator = true)
        {
            return useThousandsSeparator ? value.ToString("#,0.00", System.Threading.Thread.CurrentThread.CurrentUICulture) : value.ToString("#0.00", System.Threading.Thread.CurrentThread.CurrentUICulture);
        }

    }
}
