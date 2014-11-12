/*
 4.Implement SortableCollection.LinearSearch() method using linear search
 5.Implement SortableCollection.BinarySearch() method using binary search algorithm
 6.Implement SortableCollection.Shuffle() method using shuffle algorithm of your choice
*/
namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (this.items[i].CompareTo(item) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
                 int min = 0;
            int max = this.items.Count;


            while (max >= min)
            {
                int mid = (min + max) / 2;
                if (this.items[mid].CompareTo(item) == 0)
                {
                    return true;
                }
                else if (this.items[mid].CompareTo(item) < 0)
                {
                    min = mid + 1;
                }
                else
                {
                    max = mid - 1;
                }
            }

            return false;
        }

        public void Shuffle()
        {
            var generator = new Random();
            for (int i = 0; i < this.items.Count; i++)
            {
                int position = generator.Next(0, this.items.Count - i);

                T buffer = this.items[i];
                this.items[i] = this.items[position];
                this.items[position] = buffer;

            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
