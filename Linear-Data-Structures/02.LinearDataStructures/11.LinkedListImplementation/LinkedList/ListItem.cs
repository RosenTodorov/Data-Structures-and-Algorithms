namespace LinkedListImplementation.LinkedList
{
    using System;
    using System.Linq;

    public class ListItem<T>
    {
        private T value;
        private ListItem<T> nextItem;

        public ListItem(T value)
        {
            this.Value = value;
        }

        public ListItem(T value, ListItem<T> next)
            : this(value)
        {
            this.NextItem = next;
        }

        public T Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
            }
        }

        public ListItem<T> NextItem
        {
            get
            {
                return this.nextItem;
            }

            set
            {
                this.nextItem = value;
            }
        }
    }
}