/*Write a program that finds a set of words (e.g. 1000 words)
 * in a large text (e.g. 100 MB text file). Print how many
 * times each word occurs in the text.
    Hint: you may find a C# trie in Internet.
*/

namespace CSharpTrie
{
    using System;
    using System.Linq;
    using System.IO;
    using rmandvikar.Trie;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            var words = ReadAllWords();
            var trie = TrieFactory.GetTrie();
            foreach (var word in words)
            {
                trie.AddWord(word);
            }

            var toSearch = new string[] { "curtain", "you", "well", "lighted" };

            foreach (var word in toSearch)
            {
                Console.WriteLine("{0} - {1}", word, trie.WordCount(word));
            }
        }

        private static ICollection<string> ReadAllWords()
        {
            using (StreamReader reader = new StreamReader("../../text.txt"))
            {
                string[] words = reader.ReadToEnd().Split(new char[] { ',', '.', ':', ';', '(', ')', '!', '?', '"', '-', ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                return words;
            }
        }
    }
}