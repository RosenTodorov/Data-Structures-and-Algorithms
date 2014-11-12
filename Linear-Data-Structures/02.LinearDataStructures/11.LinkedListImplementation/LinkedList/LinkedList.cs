namespace LinkedListImplementation.LinkedList
{
    using System;
    using System.Linq;

    public class CustomLinkedList<T>
    {
        private ListItem<T> firstElement;
        private int count = 0;

        public CustomLinkedList()
        {
        }

        public ListItem<T> FirstElement
        {
            get
            {
                return this.firstElement;
            }

            private set
            {
                this.firstElement = value;
            }
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public T this[int index]
        {
            get
            {
                var currentELement = this.FirstElement;
                int internalCount = 0;

                while (internalCount != index)
                {
                    currentELement = currentELement.NextItem;
                    internalCount++;
                }

                return currentELement.Value;
            }
        }

        public void AddFirst(T value)
        {
            if (this.FirstElement == null)
            {
                this.FirstElement = new ListItem<T>(value);
                this.count++;
            }
            else
            {
                var newItem = new ListItem<T>(value);

                newItem.NextItem = this.FirstElement;
                this.FirstElement = newItem;
                this.count++;
            }
        }

        public void AddLast(T value)
        {
            if (this.FirstElement == null)
            {
                this.FirstElement = new ListItem<T>(value);
                this.count++;
            }
            else
            {
                var currentElement = this.FirstElement;
                var internalCounter = 0;

                while (true)
                {
                    if (internalCounter == this.Count - 1)
                    {
                        currentElement.NextItem = new ListItem<T>(value);
                        this.count++;
                        break;
                    }

                    currentElement = currentElement.NextItem;
                    internalCounter++;
                }
            }
        }

        public void RemoveFirstElement()
        {
            this.FirstElement = this.FirstElement.NextItem;
            this.count--;
        }
    }
}