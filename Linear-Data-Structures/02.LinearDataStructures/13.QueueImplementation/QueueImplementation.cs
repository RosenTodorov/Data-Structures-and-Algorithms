/*Implement the ADT queue as dynamic linked list. Use generics (LinkedQueue<T>) to allow storing different data types in the queue.
*/

namespace QueueImplementation
{
    using System;
    using System.Linq;
    using Queue;

    public class QueueImplementation
    {
        public static void Main()
        {
            CustomQueue<int> q = new CustomQueue<int>();

            q.Enqueue(5);
            q.Enqueue(6);
            q.Enqueue(7);
            q.Enqueue(8);
            q.Enqueue(9);

            Console.WriteLine(q.Contains(9));
            Console.WriteLine(q.Dequeue());
            Console.WriteLine(q.Dequeue());
            Console.WriteLine(q.Dequeue());
            Console.WriteLine(q.Dequeue());
            Console.WriteLine(q.Contains(6));

            Console.WriteLine(q.Count);
        }
    }
}