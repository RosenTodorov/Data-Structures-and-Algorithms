/*Implement the data structure "set" in a class HashedSet<T> using your
 * class HashTable<K,T> to hold the elements. Implement all standard set
 * operations like Add(T), Find(T), Remove(T), Count, Clear(), union and
 * intersect.
*/

namespace HashedSet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using HashTable;

    public class HashedSet<T>
    {
        private HashTable<T, int> table;

        public HashedSet()
        {
            this.table = new HashTable<T, int>();
        }

        public int Count
        {
            get
            {
                return this.table.Count;
            }
        }

        public T[] Keys
        {
            get
            {
                return this.table.Keys;
            }
        }

        public void Add(T value)
        {
            this.table.Add(value, (default(int) + 1));
        }

        public void Remove(T value)
        {
            this.table.Remove(value);
        }

        public void Clear()
        {
            this.table.Clear();
        }

        // since we have key only and value is default, we return true/false if value(in that case key) exists in the table
        public bool Find(T value)
        {
            var result = this.table.Find(value);

            if (result == default(int))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public HashedSet<T> Union(HashedSet<T> other)
        {
            HashedSet<T> result = new HashedSet<T>();

            foreach (var item in other.Keys)
            {
                if (!this.Find(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public HashedSet<T> Intersect(HashedSet<T> other)
        {
            HashedSet<T> result = new HashedSet<T>();

            foreach (var item in other.Keys)
            {
                if (this.Find(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }
    }
}