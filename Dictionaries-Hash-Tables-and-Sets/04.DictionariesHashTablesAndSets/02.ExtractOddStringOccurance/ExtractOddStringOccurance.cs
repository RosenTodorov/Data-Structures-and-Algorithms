/*Write a program that extracts from a given sequence of 
 * strings all elements that present in it odd number of times.*/

namespace ExtractOddStringOccurance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ExtractOddStringOccurance
    {
        public static void Main()
        {
            string[] array = { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };

            var matches = new Dictionary<string, int>();

            foreach (var str in array)
            {
                if (matches.ContainsKey(str))
                {
                    matches[str]++;
                }
                else
                {
                    matches.Add(str, 1);
                }
            }
            var oddOccurs = ExtractOddOccurences(matches);
            Console.WriteLine("{{ {0} }}", string.Join(" , ", oddOccurs));
        }

        public static List<string> ExtractOddOccurences(Dictionary<string, int> dict)
        {
            var result = new List<string>();

            foreach (var pairs in dict)
            {
                if (pairs.Value % 2 != 0)
                {
                    result.Add(pairs.Key);
                }
            }

            return result;
        }
    }
}
 
