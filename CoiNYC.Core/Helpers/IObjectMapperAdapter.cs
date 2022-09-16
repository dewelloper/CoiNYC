using System;
using System.Collections.Generic;
using System.Linq;

namespace CoiNYC.Core.Helpers
{
    public interface IObjectMapperAdapter : IDisposable
    {

        IQueryable<TDestination> ProjectTo<TSource, TDestination>(IQueryable<TSource> query);

        object Map(object source, Type sourceType, Type destinationType);
        object Map(object source, object destination, Type sourceType, Type destinationType);
    }
}
