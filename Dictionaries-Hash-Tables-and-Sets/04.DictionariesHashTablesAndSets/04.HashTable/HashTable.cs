namespace HashTable
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class HashTable<K, V> : IEnumerable<KeyValuePair<K, V>>
    {
        private const int InitialCapacity = 16;
        private const double ExtendClause = 0.75;
        private LinkedList<KeyValuePair<K, V>>[] elements;
        private int length;
        private int load;

        public HashTable()
        {
            this.length = InitialCapacity;
            this.load = 0;
            this.elements = new LinkedList<KeyValuePair<K, V>>[length];
        }

        public int Count
        {
            get
            {
                return this.load;
            }
        }

        public K[] Keys
        {
            get
            {
                var keys = new List<K>();
                foreach (var element in this.elements)
                {
                    if (element != null)
                    {
                        foreach (var pair in element)
                        {
                            keys.Add(pair.Key);
                        }
                    }
                }

                return keys.ToArray();
            }
        }

        // indexer
        public V this[K key]
        {
            get
            {
                int posIndex = Math.Abs((key.GetHashCode() + 1 + (((key.GetHashCode() >> 5) + 1) % (this.length - 1))) % this.length);

                if (this.elements[posIndex] != null)
                {
                    foreach (var pair in this.elements[posIndex])
                    {
                        if (pair.Key.Equals(key))
                        {
                            return pair.Value;
                        }
                    }
                }

                return default(V);
            }

            set
            {
                int posIndex = Math.Abs((key.GetHashCode() + 1 + (((key.GetHashCode() >> 5) + 1) % (this.length - 1))) % this.length);

                if (CheckForExistance(key, posIndex))
                {
                    var pairToModify = this.elements[posIndex].Where(x => x.Key.Equals(key));
                    this.elements[posIndex].Remove(pairToModify.First());
                    this.elements[posIndex].AddLast(new KeyValuePair<K, V>(key, value));
                }
                else
                {
                    if (this.elements[posIndex] == null)
                    {
                        this.elements[posIndex] = new LinkedList<KeyValuePair<K, V>>();
                    }

                    this.elements[posIndex].AddLast(new KeyValuePair<K, V>(key, value));
                }
            }
        }

        public void Add(K key, V value)
        {
            if (CheckForResize())
            {
                Resize();
            }

            int posIndex = Math.Abs((key.GetHashCode() + 1 + (((key.GetHashCode() >> 5) + 1) % (this.length - 1))) % this.length);

            if (this.elements[posIndex] == null)
            {
                this.elements[posIndex] = new LinkedList<KeyValuePair<K, V>>();
            }

            // if a duplicate exists, we remove it and we inser the new value with the same key
            if (CheckForExistance(key, posIndex))
            {
                var pairs = this.elements[posIndex].Where(x => x.Key.Equals(key));
                if (pairs.Count() != 0)
                {
                    this.elements[posIndex].Remove(pairs.First());
                    this.load--;
                }
            }

            // inserting the element
            this.elements[posIndex].AddLast(new KeyValuePair<K, V>(key, value));
            this.load++;
        }

        public void Remove(K key)
        {
            int posIndex = Math.Abs((key.GetHashCode() + 1 + (((key.GetHashCode() >> 5) + 1) % (this.length - 1))) % this.length);

            if (this.elements[posIndex] != null)
            {
                var pairToRemove = this.elements[posIndex].Where(x => x.Key.Equals(key));
                this.elements[posIndex].Remove(pairToRemove.First());
                this.load--;
            }
        }

        public V Find(K key)
        {
            int posIndex = Math.Abs((key.GetHashCode() + 1 + (((key.GetHashCode() >> 5) + 1) % (this.length - 1))) % this.length);

            if (this.elements[posIndex] != null)
            {
                foreach (var pair in this.elements[posIndex])
                {
                    if (pair.Key.Equals(key))
                    {
                        return pair.Value;
                    }
                }
            }

            return default(V);
        }

        public void Clear()
        {
            this.elements = new LinkedList<KeyValuePair<K, V>>[InitialCapacity];
            this.load = 0;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            for (int i = 0; i < this.elements.Length; i++)
            {
                if (this.elements[i] != null)
                {
                    var next = this.elements[i].First;
                    while (next != null)
                    {
                        yield return next.Value;
                        next = next.Next;
                    }
                }
            }
        }

        private bool CheckForResize()
        {
            bool inNeed = true;
            if (this.load + 1 != this.length * ExtendClause)
            {
                inNeed = false;
            }

            return inNeed;
        }

        private void Resize()
        {
            this.length = this.length * 2;
            var newElements = new LinkedList<KeyValuePair<K, V>>[this.length];

            for (int i = 0; i < this.elements.Length; i++)
            {
                if (this.elements[i] != null)
                {
                    foreach (var item in this.elements[i])
                    {
                        int newItemPos = Math.Abs((item.Key.GetHashCode() + 1 + (((item.Key.GetHashCode() >> 5) + 1) % (this.length - 1))) % this.length);

                        if (newElements[newItemPos] == null)
                        {
                            newElements[newItemPos] = new LinkedList<KeyValuePair<K, V>>();
                        }

                        newElements[newItemPos].AddLast(new KeyValuePair<K, V>(item.Key, item.Value));
                    }
                }
            }

            this.elements = newElements;
        }

        private bool CheckForExistance(K key, int posIndex)
        {
            // Checking for duplicates
            bool exists = false;
            if (this.elements[posIndex] != null)
            {
                foreach (var item in this.elements[posIndex])
                {
                    if (item.Key.Equals(key))
                    {
                        exists = true;
                    }
                }
            }

            return exists;
        }
    }
}

