using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoiNYC.Core.Common
{
    [Serializable]
    public class Range<T>
    {
        /// <summary>
        /// Initializes a new instance of the Range class.
        /// </summary>
        public Range()
        {

        }
        /// <summary>
        /// Initializes a new instance of the Range class.
        /// </summary>
        public Range(T min, T max)
        {
            Min = min;
            Max = max;
        }

        public T Min { get; set; }
        public T Max { get; set; }
    }
}
