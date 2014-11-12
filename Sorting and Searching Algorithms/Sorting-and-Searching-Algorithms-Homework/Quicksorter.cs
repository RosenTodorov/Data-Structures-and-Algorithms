namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            var buffer = QuickSort(collection);
            collection.Clear();
            foreach (var item in buffer)
            {
                collection.Add(item);
            }
        }

        private IList<T> QuickSort(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return collection;
            }

            int pivot = (collection.Count - 1) / 2;
            T pivotElement = collection[pivot];
            collection.RemoveAt(pivot);

            var less = new List<T>();
            var greater = new List<T>();

            foreach (var element in collection)
            {
                if (element.CompareTo(pivotElement) < 0)
                {
                    less.Add(element);
                }
                else
                {
                    greater.Add(element);
                }
            }
            var a = QuickSort(less);
            var b = QuickSort(greater);

            return collection = a.Concat(new List<T> { pivotElement }.Concat(b)).ToList();
        }
    }
}