/*Write a program that reads N integers from the console and reverses them using a stack. Use the Stack<int> class.
*/

namespace ReverseViaStack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ReverseViaStack
    {
        private static Stack<int> numStack = new Stack<int>();
        private static IList<int> numList = new List<int>();

        public static void Main()
        {
            Console.Write("Input number of elements: ");
            var numOfElements = int.Parse(Console.ReadLine());

            ReadInput(numList, numStack, numOfElements);

            Console.WriteLine(PrintProperResult(numList));
            Console.WriteLine(PrintReversedResult(numStack));
        }

        private static void ReadInput(IList<int> container, Stack<int> reverser, int elements)
        {
            for (int i = 0; i < elements; i++)
            {
                try
                {
                    var element = int.Parse(Console.ReadLine());
                    reverser.Push(element);
                    container.Add(element);
                }
                catch (FormatException fe)
                {
                    i--;
                    Console.WriteLine(fe.Message + " Try again.");
                }
            }
        }

        public static string PrintProperResult(IList<int> numbers)
        {
            var result = string.Join(",", numbers);

            return result;
        }

        public static string PrintReversedResult(Stack<int> nums)
        {
            List<int> temp = new List<int>();
            while (nums.Count > 0)
            {
                temp.Add(nums.Pop());
            }

            var result = string.Join(",", temp);
            return result;
        }
    }
}