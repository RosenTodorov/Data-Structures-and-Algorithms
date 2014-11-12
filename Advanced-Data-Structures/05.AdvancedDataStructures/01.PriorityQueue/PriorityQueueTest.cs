namespace PriorityQueue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PriorityQueue
    {
        public static void Main()
        {
            PriorityQueue<int> pq = new PriorityQueue<int>();

            pq.Enque(2);
            pq.Enque(3);
            pq.Enque(4);
            pq.Enque(1);

            Console.WriteLine(pq.Peek());
            Console.WriteLine(pq.Deque());
            Console.WriteLine(pq.Peek());
            Console.WriteLine(pq.Count);
        }
    }
}