/*Write a program based on dynamic programming to solve the "Knapsack Problem":
 * you are given N products, each has weight Wi and costs Ci and a knapsack of 
 * capacity M and you want to put inside a subset of the products with highest
 * cost and weight ≤ M. The numbers N, M, Wi and Ci are integers in the 
 * range [1..500]. Example: M=10 kg, N=6, products:
        beer – weight=3, cost=2
        vodka – weight=8, cost=12
        cheese – weight=4, cost=5
        nuts – weight=1, cost=4
        ham – weight=2, cost=3
        whiskey – weight=8, cost=13
*/
namespace KnapsackProblem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static int[,] auxilaryMatrix = new int[100, 100];
        private static int[,] pickedItems = new int[100, 100];

        static void Main()
        {
            Knapsack sack = new Knapsack(10);

            List<Product> items = new List<Product>()
            {
                new Product("beer", 3, 2),
                new Product("vodka", 8, 12),
                new Product("cheese", 4, 5),
                new Product("nuts", 1, 4),
                new Product("ham", 2, 3),
                new Product("whiskey", 8, 13)
            };

            ProcessItems(items.Count, 10, items);
        }

        private static void ProcessItems(int count, int weight, List<Product> items)
        {
            for (int i = 1; i <= count; i++)
            {
                for (int j = 0; j <= weight; j++)
                {
                    if (items[i - 1].Weight <= j)
                    {
                        auxilaryMatrix[i, j] = GetMaximumValue(auxilaryMatrix[i - 1, j], items[i - 1].Cost + auxilaryMatrix[i - 1, j - items[i - 1].Weight]);
                        if (items[i - 1].Cost + auxilaryMatrix[i - 1, j - items[i - 1].Weight] > auxilaryMatrix[i - 1, j])
                        {
                            pickedItems[i, j] = 1;
                        }
                        else
                        {
                            pickedItems[i, j] = -1;
                        }
                    }
                    else
                    {
                        pickedItems[i, j] = -1;
                        auxilaryMatrix[i, j] = auxilaryMatrix[i - 1, j];
                    }
                }
            }

            Console.WriteLine("Maximum cost: " + auxilaryMatrix[count, weight]);
            PrintDetailedProducts(items.Count, weight, items);
        }

        private static void PrintDetailedProducts(int item, int size, List<Product> items)
        {
            Console.WriteLine("--- Products: ---");
            while (item > 0)
            {
                if (pickedItems[item, size] == 1)
                {
                    Console.WriteLine(items[item - 1].ToString());
                    item--;
                    size -= items[item].Weight;
                }
                else
                {
                    item--;
                }
            }
        }

        private static int GetMaximumValue(int a, int b)
        {
            if (a > b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }
    }
}