using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoiNYC.Core.Extensions
{
    public static class ListExtensions
    {
        public static IEnumerable<IList<T>> Split<T>(this IList<T> list, int nSize)
        {
            List<T> partial = new List<T>();
            int index = 0;
            foreach (var item in list)
            {
                if (index < nSize)
                {
                    partial.Add(item);
                    index++;
                }
                else
                {
                    yield return partial;
                    index = 0;
                    partial = new List<T>();
                }
            }

            if (partial.Count> 0)
                yield return partial;
        }

        public static IEnumerable<List<T>> Split<T>(this List<T> list, int width, int height)
        {
            if (list.Count <= width || height == 1)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    yield return list.GetRange(i, 1);
                }
            }
            else
            if (list.Count >= ((width * height) - 1))
            {
                for (int i = 0; i < list.Count; i += height)
                {
                    yield return list.GetRange(i, Math.Min(height, list.Count - i));
                }
            }
            else
            {
                List<List<T>> matrix = new List<List<T>>();
                for (int i = 0; i < width; i++)
                {
                    matrix.Add(new List<T>());
                }

                for (int i = 0; i < list.Count; i++)
                {
                    matrix[i % width].Add(list[i]);
                }

                for (int i = 0; i < width; i++)
                {
                    yield return matrix[i];
                }
            }
        }

    }
}
