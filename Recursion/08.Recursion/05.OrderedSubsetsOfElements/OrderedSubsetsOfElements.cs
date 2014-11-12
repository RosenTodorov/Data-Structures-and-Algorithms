/*Write a recursive program for generating and printing all ordered k-element subsets from n-element set (variations Vkn).*/

namespace OrderedSubsetsOfElements
{
    using System;
    using System.Linq;

    class OrderedSubsetsOfElements
    {
        static void Main(string[] args)
        {
            string[] elements = new string[] { "hi", "a", "b" };
            Console.Write("Elements in subset ( <= {0}): ", elements.Length);
            int elementsInSubset = int.Parse(Console.ReadLine());

            GenerateSubsets(0, elements, new string[elementsInSubset]);
        }

        private static void GenerateSubsets(int index, string[] array, string[] result)
        {
            if(index == result.Length)
            {
                Print(result);
                return;
            }

            for (int i = 0; i < array.Length; i++)
            {
                result[index] = array[i];
                GenerateSubsets(index + 1, array, result);
            }
        }

        private static void Print(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
