namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            var buffer = MergeSort(collection);
            collection.Clear();

            foreach (var item in buffer)
            {
                collection.Add(item);
            }
        }

        private IList<T> MergeSort(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return collection;
            }

            int middle = collection.Count / 2;
            IList<T> left = new List<T>();
            IList<T> right = new List<T>();

            for (int i = 0; i < collection.Count; i++)
            {
                if (i < middle)
                {
                    left.Add(collection[i]);
                }
                else
                {
                    right.Add(collection[i]);
                }
            }

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        } // divide

        private IList<T> Merge(IList<T> left, IList<T> right)
        {
            IList<T> result = new List<T>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left[0].CompareTo(right[0]) < 1)
                    {
                        result.Add(left[0]);
                        left.RemoveAt(0);
                    }
                    else
                    {
                        result.Add(right[0]);
                        right.RemoveAt(0);
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left[0]);
                    left.RemoveAt(0);
                }
                else if (right.Count > 0)
                {
                    result.Add(right[0]);
                    right.RemoveAt(0);
                }
            }
            return result;
        } // conquer
    }
}
