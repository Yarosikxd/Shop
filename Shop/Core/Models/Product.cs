namespace Core.Models
{
    public class Product
    {
        private Product(Guid id, string name, string category, string article, decimal price)
        {
            Id = id;
            Name = name;
            Category = category;
            Article = article;
            Price = price;
        }

        public Guid Id { get;  set; } = Guid.NewGuid();
        public string Name { get;  set; }
        public string Category { get;  set; }
        public string Article { get;  set; }
        public decimal Price { get;  set; }

        public static Product Create(Guid id, string  name, string category, string article, decimal price)
        {
            return new Product(Guid.NewGuid(), name, category, article, price);
        }
    }
}
