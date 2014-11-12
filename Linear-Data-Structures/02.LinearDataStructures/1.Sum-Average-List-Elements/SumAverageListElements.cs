/*Write a program that reads from the console a sequence of positive integer numbers.
 * The sequence ends when empty line is entered. Calculate and print the sum and 
 * average of the elements of the sequence. Keep the sequence in List<int>.
*/

namespace SumAverageListElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumAverageListElements
    {
        private static List<int> nums = new List<int>();

        public static void Main()
        {
            ReadInput(nums);

            var average = CalculateAverage(nums);
            var sum = CalculateSum(nums);

            Console.WriteLine("Sum is: {0} and Average is: {1:0.00}", sum, average);
        }

        public static void ReadInput(List<int> nums)
        {
            Console.WriteLine("Input numbers (type empty line to break input):");

            while (true)
            {
                try
                {
                    int num;
                    var input = Console.ReadLine();
                    var tryPar = int.TryParse(input, out num);

                    if (!tryPar)
                    {
                        if (string.IsNullOrEmpty(input))
                        {
                            break;
                        }
                        else
                        {
                            throw new ArgumentException("Input numbers only");
                        }
                    }
                    else
                    {
                        if (num < 0)
                        {
                            throw new ArgumentException("The number should be positive");
                        }

                        nums.Add(num);
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }

        private static int CalculateSum(IList<int> numbers)
        {
            int sum = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }

            return sum;
        }

        private static double CalculateAverage(IList<int> numbers)
        {
            double average = CalculateSum(numbers);

            return average / numbers.Count;
        }
    }
}