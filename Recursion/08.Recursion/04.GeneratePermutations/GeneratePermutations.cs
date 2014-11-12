/*Write a recursive program for generating and printing all
 * permutations of the numbers 1, 2, ..., n for given integer number n. */

namespace GeneratePermutations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class GeneratePermutations
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Generate(0, new int[n], new bool[n], n);
        }

        private static void Generate(int index, int[] array, bool[] used, int max)
        {
            if(index == max)
            {
                PrintResult(array);
                return;
            }

            for (int i = 1; i <= max; i++)
            {
                if (!used[i - 1])
                {
                    array[index] = i;
                    used[i - 1] = true;
                    Generate(index + 1, array, used, max);
                    used[i - 1] = false;
                }
            }
        }

        private static void PrintResult(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
