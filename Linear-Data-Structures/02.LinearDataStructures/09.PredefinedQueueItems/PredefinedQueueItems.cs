/*
 We are given the following sequence:
    S1 = N;
    S2 = S1 + 1;
    S3 = 2*S1 + 1;
    S4 = S1 + 2;
    S5 = S2 + 1;
    S6 = 2*S2 + 1;
    S7 = S2 + 2;
...
Using the Queue<T> class write a program to print its first 50 members for given N.

 */

namespace PredefinedQueueItems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PredefinedQueueItems
    {
        public static void Main()
        {
            var counter = 0;
            var items = new Queue<int>();
            Console.Write("Input start number: ");
            var n = int.Parse(Console.ReadLine());
            items.Enqueue(n);

            while (counter < 50)
            {
                var curItem = items.Dequeue();
                Console.Write(curItem + " ");
                counter++;

                items.Enqueue(curItem + 1);
                items.Enqueue((2 * curItem) + 1);
                items.Enqueue(curItem + 2);
            }
        }
    }
}
