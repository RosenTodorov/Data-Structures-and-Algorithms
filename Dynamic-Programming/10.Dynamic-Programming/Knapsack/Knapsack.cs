namespace KnapsackProblem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Knapsack
    {
        public int AcceptableWeight { get; set; }
        private int currentWeight = 0;
        private IList<Product> content;

        public Knapsack(int weight)
        {
            this.AcceptableWeight = weight;
            this.content = new List<Product>();
        }
    }
}
