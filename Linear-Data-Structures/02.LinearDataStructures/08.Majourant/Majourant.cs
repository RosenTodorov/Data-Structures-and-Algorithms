/** The majorant of an array of size N is a value that occurs in 
 * it at least N/2 + 1 times. Write a program to find the majorant of given array (if exists).*/

namespace Majourant
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CountRepetitions;

    public class Majourant
    {
        private static int[] numbers = { 2, 2, 3, 3, 2, 3, 4, 3, 3 };

        public static void Main(string[] args)
        {
            var reps = CountRepetitions.ReadListItemsAndInsertToDiction(numbers);

            Console.WriteLine(DetermineMajourantElement(reps));
        }

        public static int GetMajourantValue(int[] arr)
        {
            return (arr.Length / 2) + 1;
        }

        public static int DetermineMajourantElement(IDictionary<int, int> elements)
        {
            var majourantValue = GetMajourantValue(numbers);
            var currentMajourantVal = 0;
            var majourantKey = 0;

            foreach (var pair in elements)
            {
                if (pair.Value >= majourantValue && currentMajourantVal <= pair.Value)
                {
                    majourantKey = pair.Key;
                }
            }

            return majourantKey;
        }
    }
}