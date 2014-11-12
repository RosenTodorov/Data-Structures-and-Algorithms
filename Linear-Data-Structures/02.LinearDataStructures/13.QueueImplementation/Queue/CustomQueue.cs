namespace QueueImplementation.Queue
{
    using System;
    using System.Linq;
    using LinkedListImplementation.LinkedList;

    public class CustomQueue<T>
    {
        private int count;
        private CustomLinkedList<T> elements;

        public CustomQueue()
        {
            this.elements = new CustomLinkedList<T>();
            this.Count = 0;
        }

        public int Count
        {
            get
            {
                return this.count;
            }

            private set
            {
                this.count = value;
            }
        }

        public void Enqueue(T value)
        {
            this.elements.AddLast(value);
            this.Count++;
        }

        public T Dequeue()
        {
            var result = this.elements.FirstElement.Value;
            this.elements.RemoveFirstElement();
            this.Count--;
            return result;
        }

        public void Clear()
        {
            this.elements = new CustomLinkedList<T>();
            this.Count = 0;
        }

        public bool Contains(T value)
        {
            if (this.Count == 0)
            {
                return false;
            }

            for (int i = 0; i < this.elements.Count; i++)
            {
                if (this.elements[i].Equals(value))
                {
                    return true;
                }
            }

            return false;
        }
    }
}