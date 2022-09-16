using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoiNYC.Core.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Replace<T>(this IEnumerable<T> collection, T source, T replacement)
        {
            IEnumerable<T> collectionWithout = collection;
            if (source != null)
            {
                collectionWithout = collectionWithout.Except(new[] { source });
            }
            return collectionWithout.Union(new[] { replacement });
        }

        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> collection)
        {
            HashSet<T> set = new HashSet<T>();

            foreach (T item in collection)
            {
                set.Add(item);
            }

            return set;
        }

        public static bool IsEmptyOrNull<T>(this IEnumerable<T> collection)
        {
            return collection == null || collection.Count() == 0;
        }
    }

}
