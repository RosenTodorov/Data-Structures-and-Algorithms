namespace TradeCompanyArticles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Wintellect.PowerCollections;

    public class ArticleProcessor
    {
        private readonly OrderedMultiDictionary<double, Article> articleCollection;

        public ArticleProcessor()
        {
            this.articleCollection = new OrderedMultiDictionary<double, Article>(true);
        }

        public void AddProduct(Article newItem)
        {
            this.articleCollection.Add(newItem.Price, newItem);
        }

        public IEnumerable<Article> GetArticlesFromGivenRange(double start, double end)
        {
            var range = this.articleCollection.Range(start, true, end, true);
            List<Article> result = new List<Article>();

            foreach (var value in range.Values)
            {
                result.Add(value);
            }
            return result;
        }
    }
}