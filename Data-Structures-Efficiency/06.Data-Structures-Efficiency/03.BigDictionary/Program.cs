/*Implement a class BiDictionary<K1,K2,T> that allows adding
 * triples {key1, key2, value} and fast search by key1, key2 
 * or by both key1 and key2. Note: multiple values can be 
 * stored for given key.
*/

namespace BigDictionary
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            BigDictionary<int, string, string> dict = new BigDictionary<int, string, string>();

            dict.AddElement(12, "key", "first key - 12, second - key");
            dict.AddElement(15, "keyy", "first key - 15, second - keyy");
            dict.AddElement(20, "keyz", "first key - 20, second - keyz");
            dict.AddElement(50, "keys", "first key - 50, second - keys");

            Console.WriteLine(dict.FindElementByBothKeys(50, "keys"));
            Console.WriteLine(dict.FindElementByItsPrimaryKey(15));
            Console.WriteLine(dict.FindElementByItsSecondaryKey("keyz"));
        }
    }
}
