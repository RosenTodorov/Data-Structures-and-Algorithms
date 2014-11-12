namespace TradeCompanyArticles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Article : IComparable<Article>
    {
        private string p1;
        private string p2;
        private double p3;
        private string p4;

        public double Price { get; set; }
        public string Vendor { get; set; }
        public string Barcode { get; set; }
        public string Title { get; set; }

        public Article(string name, string venor, string barcode, double price)
        {
            this.Price = price;
            this.Title = name;
            this.Barcode = barcode;
            this.Vendor = venor;
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.Append("Article: ");
            output.AppendFormat("{0}, {1}, {2}, {3}", this.Title, this.Vendor, this.Barcode, this.Price);

            return output.ToString();
        }

        public int CompareTo(Article other)
        {
            return this.Price.CompareTo(other.Price);
        }
    }
}