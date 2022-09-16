using System.Collections.Generic;
using System.Linq;

namespace CoiNYC.Core.Data
{
    public interface ISummaryPagedList<T,S> : IPagedList<T>
    {
        S PageSummary { get; }
        S TotalSummary { get; }
    }
}
