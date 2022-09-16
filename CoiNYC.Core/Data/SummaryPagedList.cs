using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CoiNYC.Core.Data
{
    public class SummaryPagedList<T, S> : PagedList<T>, ISummaryPagedList<T, S>
    {
        public SummaryPagedList()
        {

        }

        public SummaryPagedList(IQueryable<T> source, int pageIndex, int pageSize, Expression<Func<T, T>> columns)
            : base(source, pageIndex, pageSize, columns)
        {

        }

        public SummaryPagedList(IQueryable<T> source, int pageIndex, int pageSize)
            : base(source, pageIndex, pageSize)
        {

        }

        public SummaryPagedList(IEnumerable<T> source, int pageIndex, int pageSize)
            : base(source, pageIndex, pageSize)
        {

        }

        public SummaryPagedList(IEnumerable<T> source, int pageIndex, int pageSize, int totalCount)
            : base(source, pageIndex, pageSize, totalCount)
        {

        }
        

        public S PageSummary { get; set; }
        public S TotalSummary { get; set; }
    }
}

