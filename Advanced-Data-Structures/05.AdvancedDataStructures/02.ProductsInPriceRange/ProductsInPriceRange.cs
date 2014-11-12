/*Write a program to read a large collection of products (name + price)
 * and efficiently find the first 20 products in the price range [a…b].
 * Test for 500 000 products and 10 000 price searches.
*/

namespace ProductsInPriceRange
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Wintellect.PowerCollections;

    public class ProductsInPriceRange
    {
        private static OrderedBag<Product> products = new OrderedBag<Product>();
        private static Random generator = new Random();

        public static void Main()
        {
            for (int i = 0; i < 500000; i++)
            {
                AddProduct();
            }

            PrintTop20Results(50, 90000, 10000);
        }

        private static void PrintTop20Results(int fromPrice, int toPrice, int searches)
        {
            var result = products.Range(new Product("start", fromPrice), true, new Product("end", toPrice), true).Take(searches);

            foreach(var product in result)
            {
                Console.WriteLine(product.Name + " " + product.Price);
            }
        }

        private static string GenerateName()
        {
            string name = string.Empty;

            for (int i = 0; i < 20; i++)
            {
                name += (char)(generator.Next(65, 91));
                name += (char)(generator.Next(97, 123));
            }

            return name;
        }

        private static int GeneratePrice()
        {
            return generator.Next(1, 150000);
        }

        private static void AddProduct()
        {
            string name = GenerateName();
            int price = GeneratePrice();
            products.Add(new Product(name, price));
        }
    }
}
