namespace Infrastructure.Entities
{
    public class PurchaseItemEntity
    {
        public Guid Id { get; set; }
        public Guid PurchaseId { get; set; }
        public PurchaseEntity Purchase { get; set; }
        public Guid ProductId { get; set; }
        public ProductEntity Product { get; set; }
        public int Quantity { get; set; }
    }
}
