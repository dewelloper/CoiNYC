using System.Collections.Generic;
using System.Linq;

namespace CoiNYC.Core.CQRS
{
    
    public abstract class QueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>, IRequestHandler<TRequest,IList<TResponse>>, IRequestHandler<TRequest, ICount<TResponse>>
         where TRequest : QueryRequest<TResponse>
    {
        protected abstract IQueryable<TResponse> CreateQuery(TRequest request);


        TResponse IRequestHandler<TRequest, TResponse>.Handle(TRequest request)
        {
            var query = CreateQuery(request);
            return query.FirstOrDefault();
        }

        IList<TResponse> IRequestHandler<TRequest, IList<TResponse>>.Handle(TRequest request)
        {
            var query = CreateQuery(request);
            var result = query.ToList();
            return result;
        }

        ICount<TResponse> IRequestHandler<TRequest, ICount<TResponse>>.Handle(TRequest request)
        {
            var query = CreateQuery(request);
            var count = new ItemCount<TResponse>
            {
                Count = query.Count()
            };

            return count;
        }
    }
}
