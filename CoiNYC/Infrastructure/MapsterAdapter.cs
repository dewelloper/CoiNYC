using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using CoiNYC.Core.Helpers;

namespace CoiNYC.Infrastructure
{
    public class MapsterAdapter : IObjectMapperAdapter
    {

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return TypeAdapter.Adapt(source, sourceType, destinationType);
        }

        public object Map(object source, object destination, Type sourceType, Type destinationType)
        {
            return TypeAdapter.Adapt(source, destination, sourceType, destinationType);
        }

        public IQueryable<TDestination> ProjectTo<TSource, TDestination>(IQueryable<TSource> query)
        {
            return query.ProjectToType<TDestination>();
        }


        public void Dispose()
        {
        }

    }
}
