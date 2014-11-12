/*Write a recursive program that simulates the execution of n nested loops from 1 to n.*/

namespace NestedLoopsSimulatoin
{
    using System;
    using System.Linq;

    class NestedLoopsSimulatoin
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            NestedLoopSimulator(new int[n], 0, n);
        }

        private static void NestedLoopSimulator(int[] container, int start, int end)
        {
            if(start == end)
            {
                ShowData(container);
                return;
            }

            for (int i = 1; i < end; i++)
            {
                container[start] = i;
                NestedLoopSimulator(container, start + 1, end);
            }
        }

        private static void ShowData(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
        }
    }
} 
  
        

    
