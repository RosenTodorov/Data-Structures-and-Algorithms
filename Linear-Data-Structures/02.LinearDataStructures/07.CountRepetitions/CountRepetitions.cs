/*Write a program that finds in given array of integers (all belonging to the range [0..1000]) how many times each of them occurs.
*/

namespace CountRepetitions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CountRepetitions
    {
        private static int[] numbers = { 3, 4, 4, 2, 3, 3, 4, 3, 2 };

        public static void Main()
        {
            var reps = ReadListItemsAndInsertToDiction(numbers);

            foreach (var pair in reps)
            {
                Console.WriteLine("{0} -> {1} times", pair.Key, pair.Value);
            }
        }

        public static SortedDictionary<int, int> ReadListItemsAndInsertToDiction(int[] numbers)
        {
            SortedDictionary<int, int> repsCount = new SortedDictionary<int, int>();
            for (int i = 0; i < numbers.Length; i++)
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