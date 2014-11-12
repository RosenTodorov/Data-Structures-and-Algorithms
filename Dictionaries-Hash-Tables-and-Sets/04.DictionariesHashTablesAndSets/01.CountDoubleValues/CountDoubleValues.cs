namespace CountDoubleValues
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CountDoubleValues
    {
        public static void Main()
        {
            double[] array = { 0, 5.5, 8, 6.4, 0, 78, 6, 5.5, 5.5, 9.4, 9.4, 6.3, 6.4 };

            Dictionary<double, int> matches = new Dictionary<double, int>();

            foreach(var doub in array)
            {
                if(matches.ContainsKey(doub))
                {
                    matches[doub]++;
                }
                else
                {
                    matches.Add(doub, 1);
                }
            }

            foreach (var pair in matches)
            {
                Console.WriteLine("{0} -> {1} times", pair.Key, pair.Value);
            }
        }
    }
}
