using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoiNYC.Core.Extensions
{
    public static class TimeSpanExtensions
    {
        public static TimeSpan AsMinute(this int value)
        {
            return new TimeSpan(0, value, 0);
        }

        public static TimeSpan AsSeconds(this int value)
        {
            return new TimeSpan(0, 0, value);
        }

        public static TimeSpan AsHour(this int value)
        {
            return new TimeSpan(value, 0, 0);
        }
    }
}
