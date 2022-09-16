using System;
using System.Collections.Generic;
using System.Linq;
using CoiNYC.Core.Data;
using CoiNYC.Core.Extensions;

namespace CoiNYC.Core.CQRS
{
    public abstract class PagedQueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, IPagedList<TResponse>>
          where TRequest : PagedQueryRequest<IPagedList<TResponse>>
    {
        protected abstract IQueryable<TResponse> CreateQuery(TRequest request);

        IPagedList<TResponse> IRequestHandler<TRequest, IPagedList<TResponse>>.Handle(TRequest request)
        {
            var query = CreateQuery(request);

            query = ApplyFilterSorting(query, request);

            return DoPostQuery(new PagedList<TResponse>(query, request.PageIndex, request.PageSize));
        }

        protected virtual PagedList<TResponse> DoPostQuery(PagedList<TResponse> list){
            return list;
        }

        public IQueryable<TResponse> ApplyFilterSorting(IQueryable<TResponse> query, IPagedQueryRequest queryRequest)
        {
            if (!String.IsNullOrEmpty(queryRequest.SortColumn))
            {

                string[] columns = queryRequest.SortColumn.Trim().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                string[] seperator = new string[] { " " };

                for (int i = 0; i < columns.Length; i++)
                {
                    string[] columnParts = columns[i].Split(seperator, StringSplitOptions.RemoveEmptyEntries);
                    bool isSortAscending = columnParts.Length < 2 ? (queryRequest.SortDirection == "asc") : (columnParts[1] == "asc");
                    query = query.Order(columnParts[0], isSortAscending, i != 0);
                }
            }

            return query;
        }
    }
}
