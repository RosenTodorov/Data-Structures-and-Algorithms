/*
 * We are given numbers N and M and the following operations:
    N = N+1
    N = N+2
    N = N*2
Write a program that finds the shortest sequence of operations from the list above that starts from N and finishes in M. Hint: use a queue.
 */

namespace ShortestSequenceOfOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ShortestSequenceOfOperations
    {
        public static void Main()
        {
            Console.Write("Input N: ");
            int startNumber = int.Parse(Console.ReadLine());

            Console.Write("Input M: ");
            int endNumber = int.Parse(Console.ReadLine());

            var queue = new Queue<Tuple<int, int>>();
            queue.Enqueue(new Tuple<int, int>(startNumber, 0));

            var buffer = queue.Peek();
            int number = buffer.Item1;
            int occurances = buffer.Item2;

            while (number != endNumber)
            {
                queue.Enqueue(new Tuple<int, int>(number + 1, occurances + 1));
                queue.Enqueue(new Tuple<int, int>(number + 2, occurances + 1));
                queue.Enqueue(new Tuple<int, int>(number * 2, occurances + 1));
                buffer = queue.Dequeue();
                number = buffer.Item1;
                occurances = buffer.Item2;
            }

            Console.WriteLine(occurances);
        }
    }
}