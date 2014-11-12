/*Write a program that removes from given sequence all negative numbers.
*/

namespace RemoveAllNegativeNums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RemoveAllNegativeNums
    {
        private static List<int> numbers = new List<int>() { 1, 2, 6, -5, -8, 9, -10, -23, 45, 25, 20, 3985, -987, 65, 32, 0, -740 };

        public static void Main()
        {
            var positives = RemoveNegative(numbers);

            Console.WriteLine(string.Join(",", positives));
        }

        private static List<int> RemoveNegative(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] < 0)
                {
                    numbers.RemoveAt(i);
                    i--;
                }
            }

            return numbers;
        }
    }
}