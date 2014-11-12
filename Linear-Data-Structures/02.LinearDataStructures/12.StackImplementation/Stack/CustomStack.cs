namespace StackImplementation.Stack
{
    using System;
    using System.Linq;

    public class CustomStack<T>
    {
        private const int InitialCapacity = 10;
        private int count;
        private T[] elements;

        public CustomStack()
        {
            this.elements = new T[InitialCapacity];
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

        #region appropriate Stack Methods
        public void Push(T value)
        {
            if (this.DetermineExtendCapacity())
            {
                this.ExtendCapacity();
            }

            this.elements[this.Count] = value;
            this.Count++;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new ArgumentException("Custom stack is empty");
            }

            return this.elements[this.Count - 1];
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new ArgumentException("Custom stack is empty");
            }

            var result = this.elements[this.Count - 1];
            this.elements[this.Count - 1] = default(T);
            this.Count--;

            return result;
        }

        public bool Contains(T value)
        {
            if (this.Count == 0)
            {
                return false;
            }

            for (int i = 0; i < this.elements.Length; i++)
            {
                if (this.elements[i].Equals(value))
                {
                    return true;
                }
            }

            return false;
        }

        public void Clear()
        {
            this.elements = new T[InitialCapacity];
            this.count = 0;
        }

        #endregion

        private bool DetermineExtendCapacity()
        {
            if (this.Count == this.elements.Length - 1)
            {
                return true;
            }

            return false;
        }

        private void ExtendCapacity()
        {
            T[] newArrayOfElements = new T[this.elements.Length * 2];

            for (int i = 0; i < this.elements.Length; i++)
            {
                newArrayOfElements[i] = this.elements[i];
            }

            this.elements = newArrayOfElements;
        }
    }
}