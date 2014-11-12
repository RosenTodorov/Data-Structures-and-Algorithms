/*Write a method that finds the longest subsequence of equal numbers in given
 * List<int> and returns the result as new List<int>. Write a program to test
 * whether the method works correctly.
*/

namespace FindLongestSubsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FindLongestSubsequence
    {
        private static List<int> numbers = new List<int> { 1, 4, 5, 6, 6, 6, 8, 1, 0, 45, 11, 89, 4, 8, 8, 8, 8, 10, 10, 10, 10, 10 };

        public static void Main()
        {
            var res = FindLongestSub(numbers);

            Console.WriteLine(string.Join(",", res));
        }

        private static List<int> FindLongestSub(List<int> numbers)
        {
            var longest = int.MinValue;

            var result = new List<int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                var count = 1;
                var start = i;
                var curIndex = i;

                while (curIndex < numbers.Count - 1 && numbers[curIndex + 1] == numbers[start])
                {
                    count++;
                    curIndex++;
                }

                if (count > longest)
                {
                    var res = numbers.GetRange(start, count);
                    if (res.Count > 1 && res.Count > result.Count)
                    {
                        result = res;
                    }
                }
            }

            return result;
        }
    }
}