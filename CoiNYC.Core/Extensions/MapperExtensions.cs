using System;
using System.Collections.Generic;
using System.Linq;
using CoiNYC.Core.Helpers;

namespace CoiNYC.Core.Extensions
{
    public static class MapperExtensions
    {
        public static ProjectionHelper<TSource> Project<TSource>(this IQueryable<TSource> query)
        {
            return new ProjectionHelper<TSource>(query);
        }

        public static T Clone<T>(this T @object) where T : class
        {
            return (T)ObjectMapper.Current.Map(@object, @object.GetType(), typeof(T));
        }

        public static TDestination MapTo<TDestination>(this object source) 
        {
            return (TDestination)ObjectMapper.Current.Map(source, source.GetType(), typeof(TDestination));
        }

        public static TDestination MapTo<TDestination>(this object source, TDestination destination)
        {
            return (TDestination)ObjectMapper.Current.Map(source, destination, source.GetType(), typeof(TDestination));
        }

        public static List<TDestination> MapTo<TDestination>(this IEnumerable<object> sourceList)
        {
            return (List<TDestination>)ObjectMapper.Current.Map(sourceList, sourceList.GetType(), typeof(List<TDestination>));
        }

        public static TDestination MapFrom<TDestination>(this TDestination destination, params object[] sources) where TDestination : class
        {
            if (sources == null)
                return destination;

            var nonNullSources = sources.Where(x => x != null).ToList();

            if (!nonNullSources.Any())
            {
                return destination;
            }

            var destinationType = typeof(TDestination);
            object mappingResult = destination;

            foreach (var source in nonNullSources)
            {
                var sourceType = source.GetType();
                mappingResult = ObjectMapper.Current.Map(source, mappingResult, sourceType, destinationType);
            }

            return (TDestination) mappingResult;
        }

    }

    public class ProjectionHelper<TSource>
    {
        private IQueryable<TSource> _query { get; set; }

        internal ProjectionHelper(IQueryable<TSource> query)
        {
            _query = query;
        }

        public IQueryable<TDestination> To<TDestination>()
        {
            return ObjectMapper.Current.ProjectTo<TSource, TDestination>(_query);
        }
    }
}
