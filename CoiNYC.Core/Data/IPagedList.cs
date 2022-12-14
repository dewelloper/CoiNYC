using System.Collections.Generic;
using System.Linq;

namespace CoiNYC.Core.Data
{
    public interface IPagedList<T> : IList<T>
    {
        int PageIndex { get; }
        int PageSize { get; }
        int TotalCount { get; }
        int TotalPages { get; }
        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
        void Initialize(IQueryable<T> source, int pageIndex, int pageSize);
    }
}