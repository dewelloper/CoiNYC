using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CoiNYC.Core.Data
{
    [JsonObject(MemberSerialization.Fields)]
    public class PagedList<T> : List<T>, IPagedList<T>
    {

        public PagedList()
        {

        }

        public PagedList(IQueryable<T> source, int pageIndex, int pageSize, Expression<Func<T, T>> columns)
        {
            int total = source.Count();
            TotalCount = total;
            TotalPages = total / pageSize;

            if (total % pageSize > 0)
                TotalPages++;

            PageSize = pageSize;
            PageIndex = pageIndex;
            if (TotalCount > 0)
                AddRange(source.Skip((pageIndex - 1) * pageSize).Take(pageSize).Select<T, T>(columns).ToList());
        }

        public void Initialize(IQueryable<T> source, int pageIndex, int pageSize)
        {
            int total = source.Count();
            TotalCount = total;
            TotalPages = total / pageSize;

            if (total % pageSize > 0)
                TotalPages++;

            PageSize = pageSize;
            PageIndex = pageIndex;
            if (TotalCount > 0)
                AddRange(source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList());

        }

        public PagedList(IQueryable<T> source, int pageIndex, int pageSize)
        {
            if (pageSize <= 0) { pageSize = 10; }
            if (pageIndex <= 0) { pageIndex = 1; }

            int total = source.Count();
            TotalCount = total;

            TotalPages = total / pageSize;

            if (total % pageSize > 0)
                TotalPages++;

            PageSize = pageSize;
            PageIndex = pageIndex;
            if (TotalCount > 0)
            {
                List<T> list = null;
                if (pageSize != Int32.MaxValue)
                    list = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                else
                    list = source.ToList();

                if (list != null)
                    AddRange(list);
            }
        }

        public PagedList(IEnumerable<T> source, int pageIndex, int pageSize)
        {
            TotalCount = source.Count();
            TotalPages = TotalCount / pageSize;

            if (TotalCount % pageSize > 0)
                TotalPages++;

            PageSize = pageSize;
            PageIndex = pageIndex;
            if (TotalCount > 0)
                AddRange(source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList());
        }

        public PagedList(IEnumerable<T> source, int pageIndex, int pageSize, int totalCount)
        {
            TotalCount = totalCount;
            TotalPages = TotalCount / pageSize;

            if (TotalCount % pageSize > 0)
                TotalPages++;

            PageSize = pageSize;
            PageIndex = pageIndex;
            AddRange(source);
        }

        public PagedList(int capacity)
            : base(capacity)
        {
            
        }
        private PagedList(IEnumerable<T> collection)
            : base(collection)
        {
            
        }


        [JsonProperty]
        public int PageIndex { get; set; }
        [JsonProperty]
        public int PageSize { get; set; }
        [JsonProperty]
        public int TotalCount { get; set; }
        [JsonProperty]
        public int TotalPages { get; set; }

        public bool HasPreviousPage
        {
            get { return (PageIndex > 0); }
        }
        public bool HasNextPage
        {
            get { return (PageIndex + 1 < TotalPages); }
        }

    }
}