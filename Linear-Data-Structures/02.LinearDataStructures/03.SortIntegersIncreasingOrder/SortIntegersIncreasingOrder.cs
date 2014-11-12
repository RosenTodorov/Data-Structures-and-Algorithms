/*Write a program that reads a sequence of integers (List<int>) ending with an empty line and sorts them in an increasing order.
*/

namespace SortIntegersIncreasingOrder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ReverseViaStack; 
    using SumAverageListElements;

    public class SortIntegersIncreasingOrder
    {
        private static List<int> nums = new List<int>();

        public static void Main(string[] args)
        {
            // using the read input method from task 1
            SumAverageListElements.ReadInput(nums);

            nums.Sort();
            Console.WriteLine(ReverseViaStack.PrintProperResult(nums));
        }
    }
}