namespace KnapsackProblem
{
    using System;
    using System.Linq;

    public class Product
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Cost { get; set; }

        public Product(string name, int weight, int cost)
        {
            this.Name = name;
            this.Weight = weight;
            this.Cost = cost;
        }

        public override string ToString()
        {
            return "Product: " + this.Name + "; Weight: " + this.Weight + "; Cost: " + this.Cost;
        }
    }
}
