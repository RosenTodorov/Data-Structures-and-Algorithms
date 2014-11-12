/*Write a program that counts how many times each word from given text
 * file words.txt appears in it. The character casing differences should
 * be ignored. The result words should be ordered by their number of
 * occurrences in the text.*/

namespace WordOccurancesInText
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;

    public class WordOccurancesInText
    {
        private const string FilePath = "../../words.txt";

        public static void Main()
        {
            var words = ExtractWords(FilePath);

            foreach(var pairs in GetOccurances(words))
            {
                Console.WriteLine("{0} --> {1}", pairs.Key, pairs.Value);
            }
        }

        public static string[] ExtractWords(string path)
        {
            var reader = new StreamReader(path);
            string text = string.Empty;

            using (reader)
            {
                text = reader.ReadToEnd();
            }

            var words = text.Split(new char[] { ',', '.', '!', '–', '?', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            return words;
        }
        
        public static Dictionary<string, int> GetOccurances(string[] array)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (var str in array)
            {
                var strLow = str.ToLower();
                if(dict.ContainsKey(strLow))
                {
                    dict[strLow]++;
                }
                else
                {
                    dict.Add(strLow, 1);
                }
            }

            return dict;
        }
    }
}
