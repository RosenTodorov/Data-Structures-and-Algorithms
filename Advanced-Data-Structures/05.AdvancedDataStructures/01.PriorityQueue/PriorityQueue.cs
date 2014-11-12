namespace PriorityQueue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PriorityQueue<T> where T : IComparable<T> //за да може да се подреждат елементите по приоритет
    {
        private List<T> elements;

        public PriorityQueue()
        {
            this.elements = new List<T>();
        }

        public int Count
        {
            get
            {
                return this.elements.Count;
            }
        }

        public void Enque(T element)
        {
            this.elements.Add(element);

            int indexOfNewElement = this.Count - 1;
            int parentIndex = this.Count - 2;

            if (this.Count > 0)
            {
                while (indexOfNewElement >= 0)
                {
                    if (parentIndex < 0 || this.elements[indexOfNewElement].CompareTo(this.elements[parentIndex]) >= 0)
                    {
                        break;
                    }

                    T parElement = this.elements[parentIndex];
                    this.elements[parentIndex] = this.elements[indexOfNewElement];
                    this.elements[indexOfNewElement] = parElement;

                    indexOfNewElement--;
                    parentIndex--;
                }
            }
        }

        public T Peek()
        {
            return this.elements.First();
        }
     
        public T Deque()
        {
            if(this.Count == 0)
            {
                throw new InvalidOperationException("Priority queue is empty");
            }

            T result = this.elements.First();

            this.elements.RemoveAt(0);

            return result;
        }
    }
}
