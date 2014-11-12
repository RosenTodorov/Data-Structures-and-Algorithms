/*Write a program that removes from given sequence all numbers that occur odd number of times.*/

namespace RemoveOddRepetitions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RemoveOddRepetitions
    {
        private static List<int> numbers = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };

        public static void Main()
        {
            Console.WriteLine(string.Join(",", RemoveOddReps(numbers)));

        }

        public static List<int> RemoveOddReps(List<int> numbers)
        {
            var repsCount = ReadListItemsAndInsertToDiction(numbers);
            var result = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (repsCount[numbers[i]] % 2 == 0)
                {
                    result.Add(numbers[i]);
                }
            }

            return result;
        }

        public static Dictionary<int, int> ReadListItemsAndInsertToDiction(IList<int> numbers)
        {
            Dictionary<int, int> repsCount = new Dictionary<int, int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (repsCount.ContainsKey(numbers[i]))
                {
                    repsCount[numbers[i]]++;
                }
                else
                {
                    repsCount.Add(numbers[i], 1);
                }
            }

            return repsCount;
        }
    }
}