namespace Infrastructure.Entities
{
    public class PurchaseEntity
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public Guid ClientId { get; set; }
        public ClientEntity Client { get; set; }
        public List<PurchaseItemEntity> PurchaseItemEntities { get; set; }
        public ICollection<PurchaseItemEntity> PurchaseItems { get; set; } = new List<PurchaseItemEntity>();
    }
}