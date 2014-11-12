namespace BigDictionary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BigDictionary<K1,K2,V>
    {
        private Dictionary<K1, V> firstHalfDictionary;
        private Dictionary<K2, V> secondHalfDictionary;
        private Dictionary<Tuple<K1, K2>, V> mainDictionary; /* Here, instead of Tuple class, KeyValuePair struct could be used.
                                                              * Both data structures have their benefits, but as if we need
                                                              * passing data as arguments, return value, search - Tuple has better
                                                              * performance. KeyValuePair is faster in allocationg its data
                                                              */
        
        public BigDictionary()
        {
            this.firstHalfDictionary = new Dictionary<K1, V>();
            this.secondHalfDictionary = new Dictionary<K2, V>();
            this.mainDictionary = new Dictionary<Tuple<K1, K2>, V>();
        }

           public void AddElement(K1 key1,K2 key2,V value)
        {
            this.firstHalfDictionary.Add(key1, value);
            this.secondHalfDictionary.Add(key2, value);
            this.mainDictionary.Add(new Tuple<K1, K2>(key1, key2), value);
        }

          public V FindElementByItsPrimaryKey(K1 key)
        {
            return firstHalfDictionary[key];
        }

        public V FindElementByItsSecondaryKey(K2 key)
        {
            return secondHalfDictionary[key];
        }


        public V FindElementByBothKeys(K1 key1, K2 key2)
        {
            var tempKvp = new Tuple<K1, K2>(key1, key2);
            return this.mainDictionary[tempKvp];
        }
    }
}
