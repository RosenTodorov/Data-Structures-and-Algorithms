namespace HashedSet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class HashedSetTesting
    {
        static void Main()
        {
            HashedSet<int> hSet = new HashedSet<int>();

            hSet.Add(5);
            hSet.Add(15);
            hSet.Add(5);

            Console.WriteLine(hSet.Find(45));
            Console.WriteLine(hSet.Find(15));
            hSet.Remove(5);
            Console.WriteLine(hSet.Find(5));

            hSet.Clear();

            Console.WriteLine(hSet.Count);

            hSet.Add(5);
            hSet.Add(15);
            hSet.Add(25);
            hSet.Add(35);

            HashedSet<int> hSetTwo = new HashedSet<int>();
            hSetTwo.Add(4);
            hSetTwo.Add(24);
            hSetTwo.Add(25);
            hSetTwo.Add(35);

            var newIntersectedSet = hSet.Intersect(hSetTwo);

            foreach (var item in newIntersectedSet.Keys)
            {
                Console.WriteLine(item);
            }

            var newUnitedSet = hSet.Union(hSetTwo);

            foreach (var item in newUnitedSet.Keys)
            {
                Console.WriteLine(item);
            }
        }
    }
}
