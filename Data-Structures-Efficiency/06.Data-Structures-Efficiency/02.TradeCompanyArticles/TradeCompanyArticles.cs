/*A large trade company has millions of articles, each described by barcode,
 * vendor, title and price. Implement a data structure to store them that allows
 * fast retrieval of all articles in given price range [x…y].
 * Hint: use OrderedMultiDictionary<K,T> from Wintellect's Power Collections for .NET. 
*/
namespace TradeCompanyArticles
{
    using System;
    using System.Linq;
    using System.Text;

    class TradeCompanyArticles
    {
        static Random generator = new Random();

        static void Main(string[] args)
        {
            ArticleProcessor catalog = new ArticleProcessor();

            Console.WriteLine("Adding products...");
            for (int i = 0; i < 1000000; i++)
            {
                Article newProd = new Article(GenerateString(),
                    GenerateString(), GenerateString(), generator.NextDouble() * 1000);

                catalog.AddProduct(newProd);
            }
            Console.WriteLine("Finished adding products");

            var results = catalog.GetArticlesFromGivenRange(10, 20);

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }

        public static string GenerateString()
        {
            StringBuilder currentString = new StringBuilder();
            int length = generator.Next(4, 10);
            for (int i = 0; i < length; i++)
            {
                char currentChar = (char)(generator.Next('a', 'z'));
                currentString.Append(currentChar);
            }

            return currentString.ToString();
        }
    }
}