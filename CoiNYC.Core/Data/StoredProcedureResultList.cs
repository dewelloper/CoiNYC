using System.Collections.Generic;
using System.Linq;
using System;

namespace CoiNYC.Core.Data
{

    public class StoredProcedureListResult<T> : IEnumerable<T> 
    {
        private int size;
        private T[] items;
        public StoredProcedureResult Result { get; set; }

        public StoredProcedureListResult(IEnumerable<T> items, string spName, int errorNo)
        {
            var array = items.ToArray();
            size = array.Length;
            this.items = array;
            Result = new StoredProcedureResult(spName,errorNo);
        }

        public StoredProcedureListResult(IEnumerable<T> items)
        {
            var array = items.ToArray();
            size = array.Length;
            this.items = array;
        }

        public virtual int Count
        {
            get { return size; }
        }

        public void Add(T item)
        {
            items[size] = item;
            size++;
        }

        public T Get(int index) { return items[index]; }

        public IEnumerator<T> GetEnumerator()
        {
            int counter = 0;

            while (counter < Count)
            {
                yield return items[counter];
                counter++;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            int counter = 0;

            while (counter < Count)
            {
                yield return items[counter];
                counter++;
            }
        }
    }
}
