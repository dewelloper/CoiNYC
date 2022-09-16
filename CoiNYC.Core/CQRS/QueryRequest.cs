using System.Collections.Generic;


namespace CoiNYC.Core.CQRS
{
    public abstract class QueryRequest<TResponse>: IRequest<TResponse>, IRequest<IList<TResponse>>, IRequest<ICount<TResponse>>
    {
        public QueryRequest()
        {
        }
        public bool IgnoreCache { get; set; }
        public IRequest<IList<TResponse>> AsList(){
            return this as IRequest<IList<TResponse>>;
        }
        public IRequest<TResponse> AsSingle()
        {
            return this as IRequest<TResponse>;
        }

        public IRequest<ICount<TResponse>> AsCount() {
            return this as IRequest<ICount<TResponse>>;
        }
    }

    public interface IPagedQueryRequest {
        int PageSize { get; set; }
        int PageIndex { get; set; }
        string SortDirection { get; set; }
        string SortColumn { get; set; }
    }

    public abstract class PagedQueryRequest<TResponse> : QueryRequest<TResponse>, IPagedQueryRequest
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string SortDirection { get; set; }
        public string SortColumn { get; set; }

    }
}
