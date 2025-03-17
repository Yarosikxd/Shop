namespace Infrastructure.Entities
{
    public class ProductEntity
    {
        public Guid Id { get;  set; }
        public string Name { get;  set; }
        public string Category { get;  set; }
        public string Article { get;  set; }
        public decimal Price { get;  set; }

        public ICollection<PurchaseItemEntity> PurchaseItems { get; set; } = new List<PurchaseItemEntity>();
    }
}
