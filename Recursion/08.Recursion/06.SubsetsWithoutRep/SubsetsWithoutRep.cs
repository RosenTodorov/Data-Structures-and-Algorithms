/*Write a program for generating and printing all subsets of k strings from given set of strings.*/

namespace SubsetsWithoutRep
{
    using System;
    using System.Linq;

    class SubsetsWithoutRep
    {
        static void Main(string[] args)
        {
            string[] elements = new string[] { "test", "rock", "fun" };
            Console.Write("Elements in subset ( <= {0}): ", elements.Length);
            int elementsInSubset = int.Parse(Console.ReadLine());

            GenerateSubsets(0, 0, elements, new string[elementsInSubset]);
        }

        private static void GenerateSubsets(int index, int current, string[] array, string[] result)
        {
            if (index == result.Length)
            {
                Print(result);
                return;
            }

            for (int i = current; i < array.Length; i++)
            {
                result[index] = array[i];
                GenerateSubsets(index + 1, i + 1, array, result);
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
